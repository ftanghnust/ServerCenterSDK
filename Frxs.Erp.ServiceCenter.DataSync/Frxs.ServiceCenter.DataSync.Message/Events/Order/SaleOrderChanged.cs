/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 1:55:02 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售订单 更改
    /// 备注：当 销售订单（SaleOrder）在变更的时候（同步所有关联数据SaleOrderDetails、SaleOrderDetailsExt、
    /// SaleOrderDetailsPick、SaleOrderPacking、SaleOrderSendNumber、SaleOrderShelfArea、SaleOrderTrack），需要发布此事件
    /// 使用范围：销售订单（SaleOrder）变更、销售订单明细（SaleOrderDetails）列表增删改、
    /// SaleOrderDetailsExt列表增删改、SaleOrderDetailsPick列表增删改、SaleOrderPacking增删改、SaleOrderSendNumber增删改、
    /// SaleOrderShelfArea列表增删改、SaleOrderTrack增删改
    /// 操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleOrder.02")]
    public class SaleOrderChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 销售订单编号
        /// </summary>
        public string OrderId { get; set; }
    }
}