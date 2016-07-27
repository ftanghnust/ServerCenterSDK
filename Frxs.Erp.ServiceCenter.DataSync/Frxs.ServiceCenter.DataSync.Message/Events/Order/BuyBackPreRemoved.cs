/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 预采购退货单 移除(Remove)事件
    /// 备注：当预采购退货单(BuyBackPre)在移除的时候，需要发布此事件
    /// 使用范围：预采购退货单（BuyBackPre）移除操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyBackPre.03")]
    public class BuyBackPreRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 预采购退货单编号
        /// </summary>
        public string BackID { get; set; }
    }
}
