/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/26 17:50:11
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.Actions
{
    /// <summary>
    /// 重启服务器
    /// </summary>
    [ActionName("Api.Reset"), DisablePackageSdk]
    public class ApiResetAction : ActionBase<NullRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            if (!this.RequestContext.HttpContext.IsNull() && HostHelper.TryWriteWebConfig())
            {
                this.RequestContext.HttpContext.Response.Redirect("~/", true);
            }
            return this.ErrorActionResult("重启接口服务失败", -1);
        }
    }
}
