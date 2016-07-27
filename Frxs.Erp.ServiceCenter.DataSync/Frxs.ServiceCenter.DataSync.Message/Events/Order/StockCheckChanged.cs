/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 库存盘点单 变更(Changed)事件
    /// 备注：当 库存盘点单（StockCheck）在变更的时候（同步所有关联数据StockCheckDetails），需要发布此事件
    /// 使用范围：库存盘点单（StockCheck）变更、库存盘点单明细（StockCheckDetails）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "StockCheck.02")]
    public class StockCheckChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        ///库存盘点单 编号
        /// </summary>
        public string StockCheckID { get; set; }
    }
}
