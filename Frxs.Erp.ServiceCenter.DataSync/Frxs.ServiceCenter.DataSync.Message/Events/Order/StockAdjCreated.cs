/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 盘盈盘亏单 创建(Created)事件
    /// 备注：当 盘盈盘亏单(StockAdj)在创建的时候（同步所有关联数据StockAdjDetail、StockAdjDetailsExt），需要发布此事件
    /// 使用范围：盘盈盘亏单（StockAdj）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "StockAdj.01")]
    public class StockAdjCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        ///盘盈盘亏单 编号
        /// </summary>
        public string AdjID { get; set; }
    }
}
