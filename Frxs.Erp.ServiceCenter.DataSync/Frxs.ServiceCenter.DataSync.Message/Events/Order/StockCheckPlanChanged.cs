/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 库存盘点计划表 变更(Changed)事件
    /// 备注：当 库存盘点计划表（StockCheckPlan）在变更的时候（同步所有关联数据StockCheckPlanDetail），需要发布此事件
    /// 使用范围：库存盘点计划表（StockCheckPlan）变更、库存盘点单计划表明细（StockCheckPlanDetail）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "StockCheckPlan.02")]
    public class StockCheckPlanChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        ///库存盘点计划表 编号
        /// </summary>
        public string PlanID { get; set; }
    }
}
