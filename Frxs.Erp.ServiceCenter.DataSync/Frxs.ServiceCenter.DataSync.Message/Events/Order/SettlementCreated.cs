/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 日结算单 创建(Created)事件
    /// 备注：当 日结算单(Settlement)在创建的时候（同步所有关联数据SettlementDetail），需要发布此事件
    /// 使用范围：日结算单（Settlement）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "Settlement.01")]
    public class SettlementCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 日结算单 编号
        /// </summary>
        public string ID { get; set; }
    }
}
