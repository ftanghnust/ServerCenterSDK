using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/3 9:55:14
 * *******************************************************/

namespace Frxs.ServiceCenter.DataSync.Message.Server.Actions
{
    /// <summary>
    /// 消费消息接口
    /// </summary>
    public class MessageConsumerAction :
        ActionBase<MessageConsumerAction.MessageConsumerActionRequestDto,
            MessageConsumeResult<IMessageBody>>
    {
        /// <summary>
        /// 入参
        /// </summary>
        public class MessageConsumerActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 此次消息消息的起始消息编号（不包含）
            /// </summary>
            public string StartMessageId { get; set; }

            /// <summary>
            /// 需要消费的消息总数
            /// </summary>
            public int Number { get; set; }

            /// <summary>
            /// 重写下消费数量，如果小于等于0，那么默认返回100条
            /// </summary>
            public override void BeforeValid()
            {
                if (this.Number <= 0)
                {
                    this.Number = 100;
                }
                if (this.Number > 500)
                {
                    this.Number = 500;
                }
            }
        }

        /// <summary>
        /// 消息消费器
        /// </summary>
        private readonly IMessageConsumer<IMessageBody> _messageConsume;
        private readonly IMessageStoreCache _messageStoreCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageConsume">消息消息器</param>
        /// <param name="messageStoreCache"></param>
        public MessageConsumerAction(
            IMessageConsumer<IMessageBody> messageConsume,
            IMessageStoreCache messageStoreCache)
        {
            this._messageConsume = messageConsume;
            this._messageStoreCache = messageStoreCache;
        }

        /// <summary>
        /// 获取消息接口
        /// </summary>
        /// <returns></returns>
        public override ActionResult<MessageConsumeResult<IMessageBody>> Execute()
        {
            //检测仓库是否在消息中心注册了
            if (!this._messageStoreCache.MessageStoreExists(this.RequestDto.WID))
            {
                return this.ErrorActionResult(Resource.Resource.MessagePublisherAction_WID_Not_Reg
                    .With(this.RequestDto.WID));
            }

            //读取消息
            return this.SuccessActionResult(this._messageConsume.Consume(
                                                                    this.RequestDto.WID,
                                                                    this.RequestDto.StartMessageId,
                                                                    this.RequestDto.Number));
        }
    }
}