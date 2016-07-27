/***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/14/2016 6:00:16 PM (4.0.30319.42000)
 * *************************************************************************/
using System;
using Frxs.ServiceCenter.Api.Core;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Actions
{
    /// <summary>
    /// 创建仓库消息存储介质，创建成功后，Data返回存储介质名称
    /// </summary>
    [ActionName("MessageStore.Create")]
    public class MessageStoreCreateAction : ActionBase<MessageStoreCreateAction.MessageStoreCreateActionRequestDto, string>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class MessageStoreCreateActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private IMessageStoreManager _messageStoreManager;

        /// <summary>
        /// 构造函数注入需要的参数
        /// </summary>
        /// <param name="messageStoreManager"></param>
        public MessageStoreCreateAction(IMessageStoreManager messageStoreManager)
        {
            this._messageStoreManager = messageStoreManager;
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {
            //创建是否成功
            var messageStoreName = this._messageStoreManager.CreateMessageStore(this.RequestDto.WID);

            //返回消息
            return !messageStoreName.IsNullOrEmpty() ?
                this.SuccessActionResult(messageStoreName) : this.ErrorActionResult(null);
        }

    }
}
