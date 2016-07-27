/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/20 8:45:25
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// JSON格式化器
    /// </summary>
    public class JsonMediaTypeFormatter : IMediaTypeFormatter
    {
        /// <summary>
        /// JSON格式化器
        /// </summary>
        /// <param name="requestContext">当前请求上下文</param>
        /// <param name="actionResult">ActionResult对象</param>
        /// <returns>输出序列化后的字符串</returns>
        public virtual string SerializedActionResultToString(RequestContext requestContext, ActionResult actionResult)
        {
            //返回格式化数据
            return actionResult.ToJson();
        }
    }
}
