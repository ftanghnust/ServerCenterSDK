/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 预采购退货单变更(Changed)事件
    /// 备注：当 预采购退货单（BuyBackPre）在变更的时候（同步所有关联数据BuyBackPreDetails、BuyBackPreDetailsExt），需要发布此事件
    /// 使用范围： 预采购退货单（BuyBackPre）变更、 预采购退货单明细（BuyBackPreDetails）增删改、 预采购退货单扩展（BuyBackPreDetailsExt）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyBack.03")]
    public class BuyBackPreChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 预采购退货单编号
        /// </summary>
        public string BackID { get; set; }
    }
}
