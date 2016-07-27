/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 3:45:24 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 事件接收参数和触发事件名称映射
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EventNameAttribute : Attribute
    {
        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName { get; private set; }

        /// <summary>
        /// 映射消息体和事件名称
        /// </summary>
        /// <param name="eventName">触发的事件名称</param>
        public EventNameAttribute(string eventName)
        {
            this.EventName = eventName;
        }
    }
}