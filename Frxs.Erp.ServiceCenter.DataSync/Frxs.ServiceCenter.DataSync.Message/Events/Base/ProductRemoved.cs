/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 商品移除(Remove)事件
    /// 备注： 只同步商品（Product）中的数据（更改状态）过来
    /// 使用范围：商品移除 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Product.03")]
    public class ProductRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }
    }
}
