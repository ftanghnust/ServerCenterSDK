/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售退货订单表_待处理单据 移除(Remove)事件
    /// 备注：当 销售退货订单表_待处理单据（SaleBackPre）在移除的时候，需要发布此事件
    /// 使用范围：销售退货订单表_待处理单据（SaleBackPre）移除操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleBackPre.03")]
    public class SaleBackPreRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        ///销售退货单_待处理单据 编号
        /// </summary>
        public string BackID { get; set; }
    }
}
