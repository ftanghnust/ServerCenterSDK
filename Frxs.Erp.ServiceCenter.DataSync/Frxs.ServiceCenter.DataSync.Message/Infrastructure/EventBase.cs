/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/18/2016 10:12:33 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 所有事件需要继承此抽象基类
    /// </summary>
    [Serializable]
    public abstract class EventBase : IEvent
    {
    }
}
