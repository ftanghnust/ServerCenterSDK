/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/9/2016 3:02:11 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 所有时间必须继承此基类
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// 执行事件的具体业务逻辑
        /// </summary>
        /// <param name="eventArgs">业务参数，继承自：EventArgsBase的事件参数类</param>
        /// <returns></returns>
        bool Execute(object eventArgs);

    }
}
