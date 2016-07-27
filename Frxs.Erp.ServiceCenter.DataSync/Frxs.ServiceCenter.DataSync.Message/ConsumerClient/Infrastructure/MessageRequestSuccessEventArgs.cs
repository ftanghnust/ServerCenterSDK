/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 11:33:47 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 请求消费消息成功参数
    /// </summary>
    [Serializable]
    public class MessageRequestSuccessEventArgs : System.EventArgs
    {
        /// <summary>
        /// 消息体
        /// </summary>
        public MessageConsumeResult<dynamic> MessageConsumeResult { get; set; }
    }
}
