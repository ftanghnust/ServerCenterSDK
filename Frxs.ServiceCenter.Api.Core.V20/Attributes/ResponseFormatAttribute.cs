/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 6/29/2016 12:51:52 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 允许输出的格式
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ResponseFormatAttribute : ActionRequestValidatorAttribute
    {
        /// <summary>
        /// 允许输出的格式
        /// </summary>
        public ResponseFormat ResponseFormat { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseFormat">VIEW/XML/JSON</param>
        public ResponseFormatAttribute(ResponseFormat responseFormat)
        {
            this.ResponseFormat = responseFormat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        /// <returns></returns>
        public override ActionRequestValidatorResult ValidForRequest(RequestContext requestContext)
        {
            if (this.ResponseFormat.ToString().Contains(requestContext.DecryptedRequestParams.Format))
            {
                return ActionRequestValidatorResult.Success;
            }
            var errorMessage =
                Resource.CoreResource.ResponseFormatAttribute_ResponseFormat_Error.With(
                    requestContext.ActionDescriptor.ActionName, requestContext.ActionDescriptor.ActionType.FullName,
                    this.ResponseFormat.ToString());
            return new ActionRequestValidatorResult(new ActionResult() { Flag = ActionResultFlag.FAIL, Info = errorMessage }, false);
        }
    }
}
