/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/11/2016 12:19:22 PM
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 消费消息结果
    /// </summary>
    public class MessageConsumeResult<T>
    {
        /// <summary>
        /// 当前消息最大ID值
        /// </summary>
        public string LastConsumeMessageId { get; set; }

        /// <summary>
        /// 当前消息的实际数量
        /// </summary>
        public int Count
        {
            get
            {
                return null == this.Messages ? 0 : this.Messages.Count();
            }
        }

        /// <summary>
        /// 消息列表
        /// </summary>
        public IEnumerable<Message<T>> Messages { get; set; }

    }
}
