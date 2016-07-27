/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/05/2015 9:09:00 AM
 * *******************************************************/
using System;
using System.ComponentModel;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 将DTO转化成T类型
    /// </summary>
    public static class IRequestDtoExtensions
    {
        /// <summary>
        /// 注意：T类型和dto类型的映射，只是简单的属性映射，不会涉及复杂对象映射，比如：集合
        /// T类型必须包含无参构造函数
        /// </summary>
        /// <typeparam name="T">需要映射属性值的对象，必须包含无参构造函数</typeparam>
        /// <param name="dto">当前dto对象</param>
        /// <param name="ignoreCase">是否忽略属性大小写，默认true</param>
        /// <param name="isAutoSetTime">是否自动将T对象有datetime类型的属性值，自动赋值成  DateTime.Now</param>
        /// <param name="isTrim">是否将字符串类型前后空格删除</param>
        /// <returns>返回指定T类型对象实例</returns>
        public static T MapTo<T>(this IRequestDto dto, bool ignoreCase = true, bool isAutoSetTime = true, bool isTrim = true)
        {
            try
            {
                //创建映射的对象
                var obj = Activator.CreateInstance<T>();

                //在传输对象为null情况下，直接返回空的转换对象，所有字段值都是默认的
                if (null == dto)
                {
                    return obj;
                }

                //获取DTO所有属性
                var dtoPropertys = dto.GetType().GetPropertiesInfo();

                //循环待映射对象的所有属性
                obj.GetType().GetPropertiesInfo().ToList().ForEach(p =>
                {
                    //自动赋值时间
                    if (p.PropertyType == typeof(DateTime) && isAutoSetTime)
                    {
                        p.SetValue(obj, DateTime.Now);
                    }

                    //循环所有DTO对象，查找属性名称是否一致
                    foreach (var dtoProperty in dtoPropertys)
                    {
                        if (p.Name.Equals(dtoProperty.Name, (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)))
                        {
                            //对异常不处理
                            try
                            {
                                //待转换成的数据类型
                                Type convertType = p.PropertyType;
                                //判断下映射实体属性是否是可空类型;是空类型需要特殊处理
                                if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                                {
                                    NullableConverter nullableConverter = new NullableConverter(p.PropertyType);
                                    convertType = nullableConverter.UnderlyingType;
                                }

                                //获取属性值
                                var dtoPropertyValue = Convert.ChangeType(dtoProperty.GetValue(dto), convertType);

                                //如果是字符串类型的且需要将前后空格删除就重新赋值
                                if (p.PropertyType == typeof(string) && isTrim && !string.IsNullOrEmpty(dtoPropertyValue.ToString()))
                                {
                                    p.SetValue(obj, dtoPropertyValue.ToString().Trim());
                                }
                                else
                                {
                                    p.SetValue(obj, dtoPropertyValue);
                                }

                                //数据转型
                                var propertyValue = Convert.ChangeType(dtoProperty.GetValue(dto), convertType);
                                //设置属性值
                                p.SetValue(obj, propertyValue);
                            }
                            catch { }
                        }
                    }
                });
                return obj;
            }
            catch (Exception ex)
            {
                throw new ApiException("MapTo<{0}>类型失败，详细错误：{1}".With(typeof(T).FullName, ex.StackTrace));
            }
        }
    }
}
