/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售订单__待处理单据 删除(Remove)事件
    /// 备注：当 销售订单__待处理单据（SaleOrderPre）在移除的时候，需要发布此事件
    /// 使用范围：销售订单__待处理单据（SaleOrderPre）物理删除操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleOrderPre.03")]
    public class SaleOrderPreRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 销售订单__待处理单据 编号
        /// </summary>
        public string OrderId { get; set; }
    }
}
