/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/1/20 8:55:42
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 当前调用接口的用户信息
    /// </summary>
    public class UserIdentity
    {
        /// <summary>
        /// 当前请求操作用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 当前请求操作用户名称
        /// </summary>
        public string UserName { get; set; }
    }
}
