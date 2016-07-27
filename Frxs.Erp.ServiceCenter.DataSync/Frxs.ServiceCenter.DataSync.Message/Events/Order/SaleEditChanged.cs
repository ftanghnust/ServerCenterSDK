/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售改单 变更(Changed)事件
    /// 备注：当 销售改单（SaleEdit）在变更的时候（同步所有关联数据SaleEditDetails、SaleEditDetailsExt、SaleEditOrders），需要发布此事件
    /// 使用范围：销售改单（SaleEdit）变更、销售退货单明细（SaleEditDetails）增删改、销售退货单扩展（SaleEditDetailsExt）增删改、SaleEditOrders修改 操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleEdit.02")]
    public class SaleEditChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        ///销售改单 编号
        /// </summary>
        public string EditID { get; set; }
    }
}
