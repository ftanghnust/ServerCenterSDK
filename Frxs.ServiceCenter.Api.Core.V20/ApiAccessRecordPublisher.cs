/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/18 11:44:59
 * *******************************************************/
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// API日志记录器发布者，给所有订阅者进行接口信息发布
    /// </summary>
    internal class ApiAccessRecordPublisher
    {
        /// <summary>
        /// 发布日志访问消息；会逐个调用订阅者，进行发布
        /// </summary>
        /// <param name="actionResultString">执行结果的字符串</param>
        /// <param name="requestContext">当前请求上下文</param>
        /// <param name="actionLifeTime">Action对象的执行时间对象</param>
        public static void Publish(string actionResultString, RequestContext requestContext, ActionLifeTime actionLifeTime)
        {
            //不记录访问日志，直接返回
            if (!SystemOptionsManager.Current.EnableAccessRecorder || !requestContext.ActionDescriptor.EnableRecordApiLog)
            {
                return;
            }

            //获取所有注册的消费者
            var apiAccessRecorders = ServicesContainer.Current.ResolverAll<IApiAccessRecorder>();

            //获取当前操作用户信息
            var currentUserIdentity = requestContext.GetCurrentUserIdentity(() => new UserIdentity() { UserId = -1, UserName = "unknown" });

            //构造出记录器需要的参数
            var args = new ApiAccessRecorderArgs()
            {
                RequestStartTime = actionLifeTime.StartTime,
                RequestEndTime = actionLifeTime.EndTime,
                RequestUsedTotalMilliseconds = actionLifeTime.UsedTotalMilliseconds,
                HttpMethod = requestContext.HttpContext.Request.HttpMethod,
                Ip = requestContext.HttpContext.Request.GetClientIp(),
                RequestData = requestContext.DecryptedRequestParams.Data ?? string.Empty,
                ResponseData = actionResultString,
                ResponseFormat = requestContext.DecryptedRequestParams.Format,
                UserId = currentUserIdentity.UserId,
                UserName = currentUserIdentity.UserName,
                ActionDescriptor = requestContext.ActionDescriptor,
                RequestParams = requestContext.DecryptedRequestParams
            };

            //获取所有已经注册的接口
            apiAccessRecorders.OrderByDescending(x => x.Priority).ToList().ForEach(item =>
            {
                try
                {
                    item.Record(args);
                }
                catch
                {
                    // ignored
                }
            });
        }
    }
}
