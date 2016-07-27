/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购预订单被创建的时候触发事件需要传送的参数
    /// 备注：当 采购预订单(PreBuyOrder)在创建的时候（同步所有关联数据PreBuyOrderDetails、PreBuyOrderDetailsExt），需要发布此事件
    /// 使用范围： 采购预订单（PreBuyOrder）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "PreBuyOrder.01")]
    public class PreBuyOrderCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购预订单编号
        /// </summary>
        public string PreBuyID { get; set; }
    }
}
