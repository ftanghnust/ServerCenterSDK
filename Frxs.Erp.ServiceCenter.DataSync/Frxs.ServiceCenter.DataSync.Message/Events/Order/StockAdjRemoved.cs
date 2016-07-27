/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 盘盈盘亏单 移除(Remove)事件
    /// 备注：当 盘盈盘亏单（StockAdj）在移除的时候，需要发布此事件
    /// 使用范围：盘盈盘亏单（StockAdj）移除操作中使用 
    /// </summary>
    [Serializable, EventGroup("Order", "StockAdj.03")]
    public class StockAdjRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        ///盘盈盘亏单 编号
        /// </summary>
        public string AdjID { get; set; }
    }
}
