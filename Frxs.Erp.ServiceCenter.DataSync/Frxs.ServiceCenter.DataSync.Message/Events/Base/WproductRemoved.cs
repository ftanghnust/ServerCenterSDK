/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库商品移除(Remove)事件
    /// 备注：在仓库商品（Wproduct）移除的同事 移除 仓库商品采购信息（WproductBuy）
    /// 使用范围：仓库商品（Wproduct）移除,仓库商品采购信息（WproductBuy）移除 操作中使用
    /// </summary>
    [Serializable, EventGroup("Base", "Wproduct.03")]
    public class WproductRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库商品编号
        /// </summary>
        public long WProductID { get; set; }
    }
}
