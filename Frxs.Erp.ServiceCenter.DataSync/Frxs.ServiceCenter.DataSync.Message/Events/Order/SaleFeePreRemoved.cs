/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    ///  门店费用表_待处理单据 移除(Remove)事件
    /// 备注：当 门店费用表_待处理单据（SaleFeePre）在移除的时候，需要发布此事件
    /// 使用范围：门店费用表_待处理单据（SaleFeePre）移除操作中使用 
    /// </summary>
    [Serializable, EventGroup("Order", "SaleFeePre.03")]
    public class SaleFeePreRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 门店费用表_待处理单据 编号
        /// </summary>
        public string FeeID { get; set; }
    }
}
