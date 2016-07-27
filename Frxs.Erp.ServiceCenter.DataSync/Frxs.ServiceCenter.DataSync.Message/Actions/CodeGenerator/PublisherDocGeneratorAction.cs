using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/3 9:55:14
 * *******************************************************/
using System.IO;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Actions
{
    /// <summary>
    /// 消息发布者客户端代码生成器接口
    /// </summary>
    public class PublisherDocGeneratorAction : ActionBase<NullRequestDto, IEvenSelector>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IEvenSelector _eventMessageBodyMapManager;
        private readonly IMediaTypeFormatterFactory _mediaTypeFormatterFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventMessageBodyMapManager">时间消息摘要映射管理类</param>
        /// <param name="mediaTypeFormatterFactory">格式化器创建器</param>
        public PublisherDocGeneratorAction(
            IEvenSelector eventMessageBodyMapManager,
            IMediaTypeFormatterFactory mediaTypeFormatterFactory)
        {
            this._eventMessageBodyMapManager = eventMessageBodyMapManager;
            this._mediaTypeFormatterFactory = mediaTypeFormatterFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IEvenSelector> Execute()
        {
            return this.SuccessActionResult(this._eventMessageBodyMapManager);
        }

        /// <summary>
        /// 直接将生产的文件保存到指定文件夹
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            //格式化器，默认使用view
            var mediaTypeFormatter = this._mediaTypeFormatterFactory.Create(ResponseFormat.VIEW);

            //格式化后的数据
            var serializedActionResultToString = mediaTypeFormatter.SerializedActionResultToString(this.RequestContext,
                new ActionResult()
                {
                    Data = actionExecutedContext.Result.Data,
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "OK"
                });

            //输出到文件
            using (var streamWriter = new StreamWriter(this.RequestContext.HttpContext.Server
                .MapPath("~/PublisherClient/MessagePublisherDoc.html")))
            {
                streamWriter.WriteLine(serializedActionResultToString);
            }
        }
    }
}