/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库商品变更(Changed)事件
    /// 备注：在仓库商品（Wproduct）、仓库商品采购信息（WproductBuy）中的使用（Wproduct和WproductBuy1对1关系）
    /// 使用范围：仓库商品（Wproduct）编辑,仓库商品采购信息（WproductBuy）编辑 操作中使用
    /// </summary>
    [Serializable, EventGroup("Base", "Wproduct.02")]
    public class WproductChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库商品编号
        /// </summary>
        public long WProductID { get; set; }

    }
}
