using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/3 9:55:14
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Actions
{
    /// <summary>
    /// 发布消息接口
    /// </summary>
    public class MessagePublisherAction : ActionBase<MessagePublisherAction.MessagePublisherActionRequestDto, string>
    {
        /// <summary>
        /// 入参
        /// </summary>
        public class MessagePublisherActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 消息属于哪个仓库，注意：全局消息WID为0
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 触发的事件
            /// </summary>
            public string Topic { get; set; }

            /// <summary>
            /// 消息body,使用JSON来表示;每个事件的body体不一样
            /// {OrderId:"0001"}
            /// </summary>
            public string Body { get; set; }

            /// <summary>
            /// 发布时间
            /// </summary>
            public DateTime Created { get; set; }
        }

        /// <summary>
        /// 消息发布器
        /// </summary>     
        private readonly IMessagePublisher<IMessageBody> _messagePublisher;
        private readonly IEvenSelector _evenSelector;
        private readonly IMessageBodyFormatter _messageBodyFormatter;
        private readonly IMessageStoreCache _messageStoreCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messagePublisher">消息发布器</param>
        /// <param name="evenSelector">事件与其接收对象映射</param>
        /// <param name="messageBodyFormatter">事件消息摘要格式化器</param>
        /// <param name="messageStoreCache"></param>
        public MessagePublisherAction(
            IMessagePublisher<IMessageBody> messagePublisher,
            IEvenSelector evenSelector,
            IMessageBodyFormatter messageBodyFormatter,
            IMessageStoreCache messageStoreCache)
        {
            this._messagePublisher = messagePublisher;
            this._evenSelector = evenSelector;
            this._messageBodyFormatter = messageBodyFormatter;
            this._messageStoreCache = messageStoreCache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {
            ////检测仓库是否在消息中心注册了
            if (!this._messageStoreCache.MessageStoreExists(this.RequestDto.WID))
            {
                return this.ErrorActionResult(Resource.Resource.MessagePublisherAction_WID_Not_Reg.With(this.RequestDto.WID));
            }

            //从Topic事件反序列化出对象
            var messageBodyDescriptor = this._evenSelector.GetEventDescriptor(this.RequestDto.Topic);
            if (messageBodyDescriptor.IsNull())
            {
                return this.ErrorActionResult(Resource.Resource.MessagePublisherAction_NotFindBodyType);
            }

            //映射出事件的body数据(实际可用不需要反序列化，但是为了校验准确性，还是进行了反序列化 - 永远不要相信或者假设用户的输入)
            var messageBody = this._messageBodyFormatter.Deserialize(this.RequestDto.Body, messageBodyDescriptor.MessageBodyType);

            //构造一个消息体
            var message = new Message<IMessageBody>()
            {
                Body = messageBody,
                WID = this.RequestDto.WID,
                Created = DateTime.Now,
                Topic = messageBodyDescriptor.EventName
            };

            //发布事件
            var result = this._messagePublisher.Publish(message);

            //返回
            return result ? this.SuccessActionResult(message.Id) :
                this.ErrorActionResult(Resource.Resource.MessagePublisherAction_PublishError);
        }
    }
}