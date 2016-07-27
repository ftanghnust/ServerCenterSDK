/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/4/2016 6:50:51 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 触发消息参数基类
    /// </summary>
    [Serializable]
    public abstract class EventArgsBase : System.EventArgs
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public Message<dynamic> Message { get; set; }
    }
}
