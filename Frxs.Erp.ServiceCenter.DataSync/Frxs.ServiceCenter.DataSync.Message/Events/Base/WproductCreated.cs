/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库商品创建(Created)事件
    /// 备注：在仓库商品（Wproduct）创建 的同时会 创建 仓库商品采购信息（WproductBuy）
    /// 使用范围：仓库商品（Wproduct）创建,仓库商品采购信息（WproductBuy）创建 操作中使用
    /// </summary>
    [Serializable, EventGroup("Base", "Wproduct.01")]
    public class WproductCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库商品编号
        /// </summary>
        public long WProductID { get; set; }

    }
}
