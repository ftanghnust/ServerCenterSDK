/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/23 13:21:02
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 匿名对象扩展方法
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 根据表达式树获取属性名称
        /// </summary>
        /// <typeparam name="T">输入的对象类型</typeparam>
        /// <param name="predicate">获取对象属性名称委托</param>
        /// <returns>返回输入的属性名称集合</returns>
        private static string[] GetPropertyNames<T>(Expression<Func<T, dynamic>> predicate)
        {
            IList<string> propertyNames = new List<string>();
            var body = predicate.Body;
            //转换
            if (body.NodeType == ExpressionType.Convert)
            {
                var expression = (body as UnaryExpression).Operand;
                propertyNames.Add(((expression as MemberExpression).Member as PropertyInfo).Name);
            }
            //方法访问
            else if (body.NodeType == ExpressionType.MemberAccess)
            {
                propertyNames.Add(((body as MemberExpression).Member as PropertyInfo).Name);
            }
            else if (body.NodeType == ExpressionType.New)
            {
                var o = body as NewExpression;
                foreach (var member in o.Members)
                {
                    propertyNames.Add(member.Name);
                }
            }
            //数组
            else if (body.NodeType == ExpressionType.NewArrayInit)
            {
                var expressions = (body as NewArrayExpression).Expressions;
                foreach (var expression in expressions)
                {
                    if (expression.NodeType == ExpressionType.Convert)
                    {
                        var o = (expression as UnaryExpression).Operand;
                        propertyNames.Add(((o as MemberExpression).Member as PropertyInfo).Name);
                    }
                    else if (expression.NodeType == ExpressionType.MemberAccess)
                    {
                        propertyNames.Add(((expression as MemberExpression).Member as PropertyInfo).Name);
                    }
                }
            }
            //返回属性名称集合
            return propertyNames.ToArray();
        }

        /// <summary>
        /// 对象是否未空
        /// </summary>
        /// <param name="anonymousObject">任意对象</param>
        /// <returns></returns>
        public static bool IsNull(this object anonymousObject)
        {
            return (null == anonymousObject);
        }

        /// <summary>
        /// 将匿名的所有对象映射到指定的对象；映射过程中，只要数据类型键可以相互转换，无需2个转换对象属性类型完全一致
        /// </summary>
        /// <typeparam name="T">指定需要转换的类型;实体对象必须带无参构造函数</typeparam>
        /// <param name="anonymousObject">所有的实体对象，包括匿名类型</param>
        /// <param name="ignoreCase">是否忽略属性名称大小写</param>
        /// <returns>待转换类型anonymousObject=null的时候返回null，创建T类型的时候失败也会返回null，请注意转换结果null的判断</returns>
        /// <param name="skipPropertyNames">跳过那些属性不赋值(此属性为T类型属性集合)</param>
        public static T MapTo<T>(this object anonymousObject, bool ignoreCase = true, Expression<Func<T, dynamic>> skipPropertyNames = null)
        {
            //创建映射的对象
            var defaultObj = default(T);

            //在传输对象为null情况下，直接返回空的转换对象，所有字段值都是默认的
            if (anonymousObject.IsNull())
            {
                return defaultObj;
            }

            //创建映射的对象
            try
            {
                defaultObj = Activator.CreateInstance<T>();
            }
            catch (Exception exc)
            {
                //throw new FRXSException("MapTo<{0}>类型失败，详细错误：{1}".With(typeof(T).FullName, ex.StackTrace));
                return defaultObj;
            }

            //赋值
            anonymousObject.MapTo<T>(defaultObj, ignoreCase, skipPropertyNames);

            //返回新创建的对象
            return defaultObj;
        }

        /// <summary>
        /// 将匿名的所有对象映射到指定的对象；映射过程中，只要数据类型键可以相互转换，无需2个转换对象属性类型完全一致
        /// </summary>
        /// <typeparam name="T">指定需要转换的类型;实体对象必须带无参构造函数</typeparam>
        /// <param name="anonymousObject">所有的实体对象，包括匿名类型</param>
        /// <param name="ignoreCase">是否忽略属性名称大小写</param>
        /// <param name="entity">待赋值的实体对象</param>
        /// <param name="skipPropertyNames">跳过那些属性不赋值(此属性为T类型属性集合)</param>
        /// <returns></returns>
        public static void MapTo<T>(this object anonymousObject, T entity, bool ignoreCase = true, Expression<Func<T, dynamic>> skipPropertyNames = null)
        {
            //创建映射的对象
            var defaultObj = entity;

            //获取匿名对象所有属性
            var anonymousObjectPropertys = anonymousObject.GetType().GetProperties();

            //跳过那些属性
            var skips = null != skipPropertyNames ? GetPropertyNames<T>(skipPropertyNames) : new List<string>().ToArray();

            //循环待映射对象的所有属性
            defaultObj.GetType().GetProperties().ToList().ForEach(p =>
            {
                //跳过那些属性不赋值，保持对象默认属性
                if (skips.Any() && skips.Contains(p.Name, StringComparer.OrdinalIgnoreCase))
                {
                    return;
                }

                //查找属性名称是否一致
                foreach (var property in anonymousObjectPropertys)
                {
                    //是否忽略属性名称大小写
                    if (p.Name.Equals(property.Name, (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)))
                    {
                        //待转换成的数据类型
                        Type convertType = p.PropertyType;
                        //判断下映射实体属性是否是可空类型;是空类型需要特殊处理
                        if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                        {
                            NullableConverter nullableConverter = new NullableConverter(p.PropertyType);
                            convertType = nullableConverter.UnderlyingType;
                        }
                        //对异常不处理
                        try
                        {
                            //数据转型
                            var propertyValue = Convert.ChangeType(property.GetValue(anonymousObject), convertType);
                            //设置属性值
                            p.SetValue(defaultObj, propertyValue);
                        }
                        catch { }
                    }
                }
            });
        }
    }
}
