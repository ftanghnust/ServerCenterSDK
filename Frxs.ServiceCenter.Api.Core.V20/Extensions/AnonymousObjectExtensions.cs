/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/25 18:14:00
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 匿名对象扩展方法
    /// </summary>
    public static class AnonymousObjectExtensions
    {
        /// <summary>
        /// 对象转化成字典类型 key:属性名称， val:属性值
        /// </summary>
        /// <param name="anonymousObject">任意对象</param>
        /// <param name="appendNullValueToDictionary">指示属性值为null是否添加到字典；默认true，将全部属性都添加到字典</param>
        /// <param name="appendEmptyValueToDictionary">指示字符串类型的属性，当字符串为空的时候，是否将属性加入到字典，默认为true，将全部属性加入到字典</param>
        /// <returns>返回一个字典，key值为对象属性名称，value为属性值，如果anonymousObject=null则返回一个空的字典</returns>
        public static IDictionary<string, object> GetAttributes(
            this object anonymousObject,
            bool appendNullValueToDictionary = true,
            bool appendEmptyValueToDictionary = true)
        {
            //初始化一个空的字典(排序字典，方便后续签名等调用)
            SortedDictionary<string, object> attributes = new SortedDictionary<string, object>();

            //对象为null，直接返回一个空的字典
            if (anonymousObject.IsNull())
            {
                return attributes;
            }

            //获取对象所有的属性
            var properties = TypeDescriptor.GetProperties(anonymousObject);

            //循环将对象属性添加到字典
            foreach (PropertyDescriptor property in properties)
            {
                //获取属性值
                var value = property.GetValue(anonymousObject);

                //值类型数据，可空类型的，且值为null的，不加入到字典
                if (property.PropertyType.IsGenericType
                    && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && value.IsNull() && !appendNullValueToDictionary)
                {
                    continue;
                }

                //引用类型的，如果值为null且设置了不需要加入，就不加入到字段对象
                if (value.IsNull() && !appendNullValueToDictionary)
                {
                    continue;
                }

                //字符串类型，如果为空字符串，也忽略加入到字典
                if (property.PropertyType == typeof(string)
                    && (value.IsNull() || (value as string).IsNullOrEmpty())
                    && !appendEmptyValueToDictionary)
                {
                    continue;
                }

                //加入
                attributes.Add(property.Name, property.GetValue(anonymousObject));
            }

            return attributes;
        }

        /// <summary>
        /// 将任意对象转化成JSON字符串
        /// 此方法未对循环依赖对象失败做处理；直接让其抛出异常，外部调用需要进行异常的捕捉
        /// </summary>
        /// <param name="anonymousObject">任意对象</param>
        /// <returns>格式化后的JSON字符串</returns>
        public static string SerializeObjectToJosn(this object anonymousObject)
        {
            return ((IJosnSerializer)new DefaultJosnSerializer()).Serialize(anonymousObject);
        }

        /// <summary>
        /// 检测对象是否未null，为null的话就直接抛出 ArgumentNullException 异常
        /// </summary>
        /// <param name="anonymousObject">所有对象</param>
        /// <param name="argumentName">参数名称</param>
        public static void CheckNullThrowArgumentNullException(this object anonymousObject, string argumentName)
        {
            if (anonymousObject.IsNull())
            {
                throw new ArgumentNullException(argumentName);
            }
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
        /// 如果对象为空，则返回默认指定的值，不为空返回本身
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anonymousObject">任意对象</param>
        /// <param name="defaultFactoryFunc">当对象为空的时候，返回默认委托里的值</param>
        /// <returns></returns>
        public static T NullBackDefault<T>(this object anonymousObject, Func<T> defaultFactoryFunc)
        {
            defaultFactoryFunc.CheckNullThrowArgumentNullException("default");

            //当前对象为空，直接返回默认的对象
            if (anonymousObject.IsNull())
            {
                return defaultFactoryFunc();
            }

            //对象无法转换直接返回null
            if (!(anonymousObject is T))
            {
                throw new ApiException("anonymousObject对象无法转换成类型：{0}".With(typeof(T)));
            }

            return (T)anonymousObject;
        }

        /// <summary>
        /// 将匿名的所有对象映射到指定的对象；映射过程中，只要数据类型键可以相互转换，无需2个转换对象属性类型完全一致
        /// </summary>
        /// <typeparam name="T">指定需要转换的类型;实体对象必须带无参构造函数</typeparam>
        /// <param name="anonymousObject">所有的实体对象，包括匿名类型</param>
        /// <param name="ignoreCase">是否忽略属性名称大小写</param>
        /// <returns>待转换类型anonymousObject=null的时候返回null，创建T类型的时候失败也会返回null，请注意转换结果null的判断</returns>
        public static T MapTo<T>(this object anonymousObject, bool ignoreCase = true)
        {
            return ((IObjectMapper)new DefaultObjectMapper()).MapTo<T>(anonymousObject, ignoreCase);
        }

        /// <summary>
        /// 将匿名的所有对象映射到指定的对象集合
        /// </summary>
        /// <typeparam name="T">指定需要转换的类型;实体对象必须带无参构造函数</typeparam>
        /// <param name="anonymousObjects">待转换的对象集合</param>
        /// <param name="ignoreCase">是否忽略属性名称大小写</param>
        /// <returns></returns>
        public static IEnumerable<T> MapToList<T>(this IEnumerable<object> anonymousObjects, bool ignoreCase = true)
        {
            return anonymousObjects.Select(item => item.MapTo<T>(ignoreCase));
        }

        /// <summary>
        /// 执行对象中的某个方法
        /// </summary>
        /// <param name="anonymousObject">任意对象</param>
        /// <param name="methodName">方法名称(注意区分大小写)</param>
        /// <param name="parameters">方法参数</param>
        public static object Invoke(this object anonymousObject, string methodName, params object[] parameters)
        {
            return anonymousObject.GetType().GetMethod(methodName).Invoke(anonymousObject, parameters: parameters);
        }
    }
}
