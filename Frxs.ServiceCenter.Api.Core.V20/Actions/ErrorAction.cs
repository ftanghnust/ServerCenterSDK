/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 错误action返回
    /// </summary>
    [ActionName("API.ERROR"), DisablePackageSdk]
    internal class ErrorAction : ActionBase<NullRequestDto, NullResponseDto>, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Exception _exception;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception">异常信息</param>
        /// <param name="requestContext">当前请求上下文</param>
        public ErrorAction(Exception exception, RequestContext requestContext)
        {
            //判断null,直接抛出异常
            exception.CheckNullThrowArgumentNullException("exception");
            requestContext.CheckNullThrowArgumentNullException("requestContext");

            this._exception = exception;
            this.ActionDescriptor = new ReflectedActionDescriptor(this.GetType()).GetActionDescriptor();
            this.RequestContext = requestContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            return this.ErrorActionResult(Resource.CoreResource.ErrorAction_ErrInfo.With(_exception.Message, _exception.StackTrace));
        }
    }
}