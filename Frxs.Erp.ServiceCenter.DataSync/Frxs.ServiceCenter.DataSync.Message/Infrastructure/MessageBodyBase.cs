/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/8/2016 5:07:27 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 消息摘要基类，实现类尽量使用简易参数，不要使用复杂的数据类型
    /// </summary>
    [Serializable]
    public abstract class MessageBodyBase : IMessageBody { }
}
