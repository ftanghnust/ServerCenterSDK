/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 门店结算单 变更(Changed)事件
    /// 备注：当 门店结算单（SaleSettle）在变更的时候（同步所有关联数据SaleSettleDetail），需要发布此事件
    /// 使用范围：门店结算单（SaleSettle）变更、门店结算单明细（SaleSettleDetail）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleSettle.02")]
    public class SaleSettleChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        ///门店结算单 编号
        /// </summary>
        public string SettleID { get; set; }
    }
}
