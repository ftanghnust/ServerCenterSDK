/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 日结算单 移除(Remove)事件
    /// 备注：当 日结算单（Settlement）在移除的时候，需要发布此事件
    /// 使用范围：日结算单（Settlement）移除操作中使用 
    /// </summary>
    [Serializable, EventGroup("Order", "Settlement.03")]
    public class SettlementRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 日结算单 编号
        /// </summary>
        public string ID { get; set; }
    }
}
