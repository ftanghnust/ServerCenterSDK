/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购退货单变更(Changed)事件
    /// 备注：当采购退货单在变更的时候（同步所有关联数据BuyBackDetails、BuyBackDetailsExt），需要发布此事件
    /// 使用范围：采购退货单（BuyBack）变更、采购退货单明细（BuyBackDetails）增删改、采购退货单扩展（BuyBackDetailsExt）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyBack.02")]
    public class BuyBackChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购退货单编号
        /// </summary>
        public string BackID { get; set; }
    }
}
