/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 规格属性值 变更(Changed)事件消息体
    /// </summary>
    [Serializable, GlobalEventMessage]
    public class AttributeValuesChangedMessageBody : MessageBodyBase
    {
        /// <summary>
        /// 规格属性值编号
        /// </summary>
        public int ValuesId { get; set; }
    }
}
