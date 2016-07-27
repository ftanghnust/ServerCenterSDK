/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 库存盘点计划表 移除(Remove)事件
    /// 备注：当 库存盘点计划表（StockCheckPlan）在移除的时候，需要发布此事件
    /// 使用范围：库存盘点计划表（StockCheckPlan）移除操作中使用 
    /// </summary>
    [Serializable, EventGroup("Order", "StockCheckPlan.03")]
    public class StockCheckPlanRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        ///库存盘点计划表 编号
        /// </summary>
        public string PlanID { get; set; }
    }
}
