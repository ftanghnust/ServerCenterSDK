/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 门店结算单 移除(Remove)事件
    /// 备注：当 门店结算单（SaleSettle）在移除的时候，需要发布此事件
    /// 使用范围：门店结算单（SaleSettle）移除操作中使用 
    /// </summary>
    [Serializable, EventGroup("Order", "SaleSettle.03")]
    public class SaleSettleRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        ///门店结算单 编号
        /// </summary>
        public string SettleID { get; set; }
    }
}
