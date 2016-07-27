/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/28/2015 3:08:51 PM
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// IACTION接口扩展
    /// </summary>
    internal static class IActionExtension
    {
        /// <summary>
        /// 获取当前action的描述信息
        /// </summary>
        /// <param name="action">具体的IAction示例</param>
        /// <returns></returns>
        public static ActionDescriptor GetActionDescriptor(this IAction action)
        {
            return new ReflectedActionDescriptor(action.GetType()).GetActionDescriptor();
        }
    }
}