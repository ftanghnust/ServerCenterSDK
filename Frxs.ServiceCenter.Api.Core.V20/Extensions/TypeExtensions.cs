/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/1/11 8:54:16
 * *******************************************************/
using System;
using System.Runtime.CompilerServices;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 类型扩展
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// 判断一个类型是否是匿名类型
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static bool IsAnonymousType(this Type type)
        {
            type.CheckNullThrowArgumentNullException("Type");
            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                && type.IsGenericType
                && type.Name.Contains("AnonymousType")
                && (type.Name.StartsWith("<>", StringComparison.OrdinalIgnoreCase) 
                    || 
                    type.Name.StartsWith("VB$", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 是否是可空类型
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            type.CheckNullThrowArgumentNullException("Type");
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
