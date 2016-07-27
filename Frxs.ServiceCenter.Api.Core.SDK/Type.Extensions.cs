/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/12 11:35:44
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 
    /// </summary>
    internal static class TypeExtensions
    {
        /// <summary>
        /// 获取类型属性信息，参数类型为：System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="propertyName">属性名称；忽略大小写</param>
        /// <returns></returns>
        public static System.Reflection.PropertyInfo GetPropertyInfo(this Type type, string propertyName)
        {
            return type.GetProperty(propertyName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
        }
    }
}
