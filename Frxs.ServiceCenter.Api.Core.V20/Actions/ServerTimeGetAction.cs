/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/1 10:47:45
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core.Actions
{
    /// <summary>
    /// 获取服务器时间；返回一个字符串时间数据，格式为：yyyy-MM-dd HH:mm:ss.fff
    /// </summary>
    [ActionName("API.ServerTime.Get"), AllowAnonymous]
    public class ServerTimeGetAction : ActionBase<NullRequestDto, string>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {
            return this.SuccessActionResult(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
    }
}
