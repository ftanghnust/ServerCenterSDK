/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 11:34:23 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 消费消息完成触发事件参数
    /// </summary>
    [Serializable]
    public class MessageConsumeCompleteEventArgs : System.EventArgs
    {
        /// <summary>
        /// 消息体
        /// </summary>
        public MessageConsumeResult<dynamic> MessageConsumeResult { get; set; }
    }
}
