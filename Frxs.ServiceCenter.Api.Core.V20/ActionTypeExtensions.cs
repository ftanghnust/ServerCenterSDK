/*********************************************************
 * FRXS zhangliang@frxs.com 10/30/2015 5:28:06 PM
 * *******************************************************/
using System;
using System.Reflection;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 类型检查
    /// </summary>
    internal static class ActionTypeExtensions
    {
        /// <summary>
        /// 类型是否继承了ActionBase
        /// </summary>
        /// <param name="type">当前类型</param>
        /// <returns></returns>
        public static bool IsAssignableToActionBase(this Type type)
        {
            return !type.IsAbstract
                && typeof(IAction).IsAssignableFrom(type)
                && !type.BaseType.IsNull()
                && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(ActionBase<,>);
        }

        /// <summary>
        /// 类型是否继承自IRequestDto
        /// </summary>
        /// <param name="type">当前类型</param>
        /// <returns></returns>
        public static bool IsAssignableToIRequestDto(this Type type)
        {
            return !type.IsAbstract && typeof(IRequestDto).IsAssignableFrom(type);
        }

        /// <summary>
        /// 类型是否继承自IResponseDto
        /// </summary>
        /// <param name="type">当前类型</param>
        /// <returns></returns>
        public static bool IsAssignableToIResponseDto(this Type type)
        {
            return !type.IsAbstract && typeof(IResponseDto).IsAssignableFrom(type);
        }

        /// <summary>
        /// 获取所有实例属性，默认参数：
        /// System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance
        /// </summary>
        /// <param name="type">当前类型</param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertiesInfo(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
