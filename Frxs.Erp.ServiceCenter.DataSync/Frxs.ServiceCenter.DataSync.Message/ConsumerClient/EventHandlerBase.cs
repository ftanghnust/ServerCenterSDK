/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/9/2016 4:16:56 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 时间执行类基类，所有事件执行类需要继承此抽象基类
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    public abstract class EventHandlerBase<TEventArgs> : IEventHandler, IDisposable where TEventArgs : EventArgsBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        bool IEventHandler.Execute(object eventArgs)
        {
            return this.Execute((TEventArgs)eventArgs);
        }

        /// <summary>
        /// 具体的实现类需要实现此方法
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        public abstract bool Execute(TEventArgs eventArgs);

        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose() { }
    }
}
