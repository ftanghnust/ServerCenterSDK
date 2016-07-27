using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/3 9:55:14
 * *******************************************************/
using System.IO;
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Actions
{
    /// <summary>
    /// 消息消费客户端代码生成器接口
    /// </summary>
    public class ConsumerEventArgsCodeGeneratorAction : ActionBase<NullRequestDto, object>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IEvenSelector _eventMessageBodyMapManager;
        private readonly IMediaTypeFormatterFactory _mediaTypeFormatterFactory;
        private readonly IActionSelector _actionSelector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventMessageBodyMapManager">时间消息摘要映射管理类</param>
        /// <param name="mediaTypeFormatterFactory">格式化器创建器</param>
        /// <param name="actionSelector">接口搜索器</param>
        public ConsumerEventArgsCodeGeneratorAction(
            IEvenSelector eventMessageBodyMapManager,
            IMediaTypeFormatterFactory mediaTypeFormatterFactory,
            IActionSelector actionSelector)
        {
            this._eventMessageBodyMapManager = eventMessageBodyMapManager;
            this._mediaTypeFormatterFactory = mediaTypeFormatterFactory;
            this._actionSelector = actionSelector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<object> Execute()
        {
            //请求的内部接口
            string actionName = "Frxs.DataSync.ConsumerEventArgsItemCodeGenerator";

            //循环当前注册的所有模型
            foreach (var item in this._eventMessageBodyMapManager.GetEventDescriptors())
            {
                //上送参数
                var requestDto = new ConsumerEventArgsItemCodeGeneratorAction
                    .ConsumerEventArgsItemCodeGeneratorActionRequestDto
                {
                    EventName = item.EventName,
                    UserId = 0,
                    UserName = "system"
                };

                //原始请求参数
                var requestParams = new RequestParams()
                {
                    ActionName = actionName,
                    Data = requestDto.SerializeObjectToJosn(),
                    Format = "View",
                    AppKey = "",
                    Sign = "",
                    TimeStamp = DateTime.Now.ToString(),
                    Version = ""
                };

                //构造请求上下文
                var requestContext = new RequestContext(
                            httpContext: this.RequestContext.HttpContext,
                            systemOptions: SystemOptionsManager.Current,
                            requestDto: requestDto,
                            actionDescriptor: this._actionSelector.GetActionDescriptor(actionName, ""),
                            rawRequestParams: requestParams,
                            decryptedRequestParams: requestParams.MapTo<RequestParams>());

                //构造接口对象
                IAction action = new ConsumerEventArgsItemCodeGeneratorAction(this._eventMessageBodyMapManager, this._mediaTypeFormatterFactory);
                action.RequestContext = requestContext;
                action.RequestDto = requestDto;
                action.ActionDescriptor = (ActionDescriptor)requestContext.ActionDescriptor;

                //执行文档生成器接口（当成服务使用）
                var actionResult = action.Execute();

                //格式化器，默认使用view
                var mediaTypeFormatter = this._mediaTypeFormatterFactory.Create(ResponseFormat.VIEW);

                //格式化后的数据
                var serializedActionResultToString = mediaTypeFormatter.SerializedActionResultToString(requestContext,
                    new ActionResult()
                    {
                        Data = actionResult.Data,
                        Flag = ActionResultFlag.SUCCESS,
                        Info = "OK"
                    });

                //文件夹
                string dp = this.RequestContext.HttpContext.Server
                        .MapPath("~/ConsumerClient/EventArgs/{0}".With(item.GroupName));

                //新建文件夹
                if (!Directory.Exists(dp))
                {
                    Directory.CreateDirectory(dp);
                }

                //输出到文件
                using (var streamWriter = new StreamWriter(this.RequestContext.HttpContext.Server
                    .MapPath((item.GroupName.IsNullOrEmpty() ?
                    "~/ConsumerClient/EventArgs/{1}EventArgs.cs" : "~/ConsumerClient/EventArgs/{0}/{1}EventArgs.cs")
                    .With(item.GroupName, item.EventName))))
                {
                    streamWriter.WriteLine(serializedActionResultToString);
                }
            }

            //生成接口成功
            return this.SuccessActionResult("OK");
        }

    }
}