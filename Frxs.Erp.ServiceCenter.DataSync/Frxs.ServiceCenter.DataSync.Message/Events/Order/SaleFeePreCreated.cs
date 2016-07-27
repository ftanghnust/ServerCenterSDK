/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 门店费用表_待处理单据 创建(Created)事件
    /// 备注：当 门店费用表_待处理单据(SaleFeePre)在创建的时候（同步所有关联数据SaleFeePreDetails），需要发布此事件
    /// 使用范围：门店费用表_待处理单据（SaleFeePre）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleFeePre.01")]
    public class SaleFeePreCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 门店费用表_待处理单据 编号
        /// </summary>
        public string FeeID { get; set; }
    }
}
