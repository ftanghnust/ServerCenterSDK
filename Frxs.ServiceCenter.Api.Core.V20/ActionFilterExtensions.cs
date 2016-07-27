/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/31 8:40:34
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 过滤器接口扩展
    /// </summary>
    internal static class ActionFilterExtensions
    {
        /// <summary>
        /// 将过滤器转换成内部过滤器包装类
        /// </summary>
        /// <param name="actionFilter">接口过滤器</param>
        /// <returns>返回过滤器包装类</returns>
        public static ActionFilterWrapper AsActionFilterWrapper(this IActionFilter actionFilter)
        {
            actionFilter.CheckNullThrowArgumentNullException("actionFilter");
            return new ActionFilterWrapper(actionFilter);
        }
    }
}
