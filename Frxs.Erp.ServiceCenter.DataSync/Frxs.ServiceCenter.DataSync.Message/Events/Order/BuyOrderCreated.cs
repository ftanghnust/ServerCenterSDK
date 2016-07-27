/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/4/2016 5:16:39 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购收货单被创建的时候触发事件需要传送的参数
    /// 备注：当采购收货单(BuyOrder)在创建的时候（同步所有关联数据BuyOrderDetails、BuyOrderDetailsExt），需要发布此事件
    /// 使用范围：采购收货单（BuyOrder）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order","BuyOrder.01")]
    public class BuyOrderCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购收货单编号
        /// </summary>
        public string BuyID { get; set; }
    }
}