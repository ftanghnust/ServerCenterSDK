﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 库存 变更(Changed)事件
    /// 备注：当 库存（StockQty）在变更的时候，需要发布此事件
    /// 使用范围：库存（StockQty）变更操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "StockQty.02")]
    public class StockQtyChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 库存 编号
        /// </summary>
        public int ID { get; set; }
    }
}
