/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 5:21:28 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 事件描述对象
    /// </summary>
    public class EventDescriptor
    {
        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// 事件消息体类型
        /// </summary>
        public Type MessageBodyType { get; set; }

        /// <summary>
        /// 是否是全局事件消息
        /// </summary>
        public bool IsGloablEventMessage { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 子分组
        /// </summary>
        public string SubGroupName { get; set; }

        /// <summary>
        /// 事件的重要度，一定会有值，默认为:Degree.Normal
        /// </summary>
        public Degree EventDegree { get; set; }
    }
}