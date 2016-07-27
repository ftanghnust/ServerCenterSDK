/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/25 14:10:09
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.Actions
{
    /// <summary>
    /// 清掉所有系统缓存
    /// </summary>
    [ActionName("Api.Cache.Clear"), UnloadCachekeys("_SYS_"), AllowAnonymous]
    [DisablePackageSdk, DisableDataSignatureTransmission, EnableRecordApiLog(false)]
    public class ClearCacheAction : ActionBase<NullRequestDto, bool>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {
            return this.SuccessActionResult(true);
        }
    }
}
