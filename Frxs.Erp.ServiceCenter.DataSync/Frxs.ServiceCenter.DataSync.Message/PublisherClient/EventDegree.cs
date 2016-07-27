/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/27/2016 8:47:24 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.PublisherClient
{
    /// <summary>
    /// 事件消息的重要度
    /// </summary>
    public enum EventDegree
    {
        /// <summary>
        /// 重要度高（消息必须到到）
        /// </summary>
        High = 0,

        /// <summary>
        /// 正常，可以再重试后如果还不成功，可以丢弃
        /// </summary>
        Normal,

        /// <summary>
        /// 最低，发送失败，直接丢弃
        /// </summary>
        Low
    }
}
