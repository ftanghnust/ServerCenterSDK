/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购预订单变更 (Changed)事件
    /// 备注：当采购预订单（PreBuyOrder）在变更的时候（同步所有关联数据PreBuyOrderDetails、PreBuyOrderDetailsExt），需要发布此事件
    /// 使用范围：采购预订单（PreBuyOrder）变更、采购预订单明细（PreBuyOrderDetails）增删改、采购预订单扩展（PreBuyOrderDetailsExt）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "PreBuyOrder.02")]
    public class PreBuyOrderChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购预订单编号
        /// </summary>
        public string PreBuyID { get; set; }

    }
}
