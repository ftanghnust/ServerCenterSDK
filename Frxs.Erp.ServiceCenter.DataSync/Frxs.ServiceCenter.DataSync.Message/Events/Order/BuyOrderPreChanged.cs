/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 预采购收货单变更 (Changed)事件
    /// 备注：当预采购收货单（BuyOrderPre）在变更的时候（同步所有关联数据BuyOrderPreDetails、BuyOrderPreDetailsExt），需要发布此事件
    /// 使用范围：预采购收货单（BuyOrderPre）变更、预采购收货单明细（BuyOrderPreDetails）增删改、预采购收货单扩展（BuyOrderPreDetailsExt）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyOrderPre.02")]
    public class BuyOrderPreChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 预采购收货单编号
        /// </summary>
        public string BuyID { get; set; }
    }
}
