/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售订单__待处理单据 变更(Changed)事件
    /// 备注：当 销售订单__待处理单据（SaleOrderPre）在变更的时候（同步所有关联数据SaleOrderPreDetails、SaleOrderPreDetailsExt、
    /// SaleOrderPreDetailsPick、SaleOrderPrePacking、SaleOrderPreShelfArea），需要发布此事件
    /// 使用范围：销售订单__待处理单据（SaleOrderPre）变更、预销售订单明细（SaleOrderPreDetails）列表增删改、
    /// SaleOrderPreDetailsExt列表增删改、SaleOrderPreDetailsPick列表增删改、SaleOrderPrePacking增删改、SaleOrderPreShelfArea列表增删改的操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleOrderPre.02")]
    public class SaleOrderPreChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 销售订单__待处理单据 编号
        /// </summary>
        public string OrderId { get; set; }
    }
}
