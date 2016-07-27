/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/9/2016 4:33:57 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 事件处理类描述对象
    /// </summary>
    public class EventDescriptor
    {
        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// 处理类型
        /// </summary>
        public Type EventType { get; set; }

        /// <summary>
        /// 事件参数类型
        /// </summary>
        public Type EventArgsType { get; set; }

    }
}
