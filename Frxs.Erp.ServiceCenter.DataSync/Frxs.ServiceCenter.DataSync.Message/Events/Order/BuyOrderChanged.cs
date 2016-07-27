/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购收货单变更(Changed)事件
    /// 备注：当采购收货单（BuyOrder）在创建的时候（同步所有关联数据BuyOrderDetails、BuyOrderDetailsExt），需要发布此事件
    /// 使用范围：采购收货单（BuyOrder）创建、采购收货单明细（BuyOrderDetails）增删改、采购收货单扩展（BuyOrderDetailsExt）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyOrder.02")]
    public class BuyOrderChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购收货单编号
        /// </summary>
        public string BuyID { get; set; }
    }
}
