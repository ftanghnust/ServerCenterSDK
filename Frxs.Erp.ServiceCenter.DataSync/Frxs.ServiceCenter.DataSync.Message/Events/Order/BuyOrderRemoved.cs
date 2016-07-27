/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购收货单移除(Remove)事件
    /// 备注：当采购收货单（BuyOrder）在移除的时候，需要发布此事件
    /// 使用范围：采购收货单（BuyOrder）移除操作中使用
    ///  </summary>
    [Serializable, EventGroup("Order", "BuyOrder.03")]
    public class BuyOrderRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购收货单编号
        /// </summary>
        public string BuyID { get; set; }
    }
}
