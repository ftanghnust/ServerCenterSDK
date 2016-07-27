/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/2 16:15:04
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.Product.Api.GlobalRequestHanderInterceptors
{
    /// <summary>
    /// 默认的全局连接器实现;为实现任何的拦截操作
    /// </summary>
    public class DefaultGlobalRequestHanderInterceptor : ActionFilterBaseAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutingContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            //附加下属性看执行效果
            actionExecutingContext.Action.RequestContext.AdditionDatas.Add("{0}.OnActionExecuting".With(this.GetType().FullName), "OK");
            base.OnActionExecuting(actionExecutingContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            //附加下属性看执行效果
            actionExecutedContext.Action.RequestContext.AdditionDatas.Add("{0}.OnActionExecuted".With(this.GetType().FullName), "OK");
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
