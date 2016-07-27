/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/22 16:30:45
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 当前操作用户
    /// </summary>
    public class ApiUser
    {
        /// <summary>
        /// 当前请求接口用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 当前请求接口用户名称
        /// </summary>
        public string UserName { get; set; }
    }
}
