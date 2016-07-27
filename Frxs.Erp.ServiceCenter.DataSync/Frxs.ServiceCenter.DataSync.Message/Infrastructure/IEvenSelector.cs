/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 4:19:56 PM
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 事件名称和事件消息体映射关系查找器
    /// </summary>
    public interface IEvenSelector
    {
        /// <summary>
        /// 根据事件获取到消息类型
        /// </summary>
        /// <param name="eventName">事件名称</param>
        /// <returns>未找到返回null</returns>
        EventDescriptor GetEventDescriptor(string eventName);

        /// <summary>
        /// 获取所有映射集合
        /// </summary>
        /// <returns>未找到则返回空集合</returns>
        IEnumerable<EventDescriptor> GetEventDescriptors();
    }
}
