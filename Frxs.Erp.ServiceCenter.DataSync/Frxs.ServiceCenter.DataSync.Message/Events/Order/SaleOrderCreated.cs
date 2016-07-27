/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 1:55:02 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售订单更改
    /// 备注：当 销售订单(SaleOrder)在创建的时候（同步所有关联数据SaleOrderDetails、SaleOrderDetailsExt、
    /// SaleOrderDetailsPick、SaleOrderPacking、SaleOrderSendNumber、SaleOrderShelfArea、SaleOrderTrack），需要发布此事件
    /// 使用范围：销售订单（SaleOrder）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleOrder.01")]
    public class SaleOrderCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 销售订单编号
        /// </summary>
        public string OrderId { get; set; }

    }
}