/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/8/2016 6:59:22 PM
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 消费消息结果(系统消息中心读取消息后需要转换成此对象)
    /// </summary>
    /// <typeparam name="T">事件消息参数对象类型</typeparam>
    public class MessageConsumeResult<T> where T : IMessageBody
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages">消息列表</param>
        public MessageConsumeResult(IEnumerable<Message<T>> messages)
        {
            this.Messages = messages ?? new List<Message<T>>();
        }

        /// <summary>
        /// 当前消息集合中最大MessageId值
        /// </summary>
        public string LastConsumeMessageId
        {
            get
            {
                return this.Messages.Any() ? this.Messages.Max(o => o.Id) : "";
            }
        }

        /// <summary>
        /// 当前消息的实际数量
        /// </summary>
        public int Count
        {
            get
            {
                return this.Messages.Count();
            }
        }

        /// <summary>
        /// 消息列表
        /// </summary>
        public IEnumerable<Message<T>> Messages { get; private set; }
    }
}
