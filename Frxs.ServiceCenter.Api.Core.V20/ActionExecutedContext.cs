/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/26 11:29:02
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 接口执行后，接口执行器上下文
    /// </summary>
    public class ActionExecutedContext : ActionContext
    {
        /// <summary>
        /// 初始化当前上下文对象
        /// </summary>
        /// <param name="action">接口实例</param>
        /// <param name="actionResult">接口执行Execute()方法后返回的执行结果</param>
        public ActionExecutedContext(IAction action, ActionResult actionResult)
            : base(action, action.RequestContext, action.ActionDescriptor, action.RequestDto)
        {
            this.Result = actionResult;
        }
    }
}
