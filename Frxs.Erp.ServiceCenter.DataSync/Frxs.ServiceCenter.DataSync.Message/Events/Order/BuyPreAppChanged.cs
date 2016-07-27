/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购补货返配申请单 变更(Changed)事件
    /// 备注：当采购补货返配申请单（BuyPreApp）在变更的时候（同步所有关联数据BuyPreAppBills、BuyPreAppDetails、BuyPreAppDetailsExt），需要发布此事件
    /// 使用范围：采购补货返配申请单（BuyPreApp）变更、采购补货返配申请生成单据表（BuyPreAppBills）增删改、
    /// 采购补货返配申请单明细（BuyPreAppDetails）增删改、采购补货返配申请单扩展（BuyPreAppDetailsExt）增删改 操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyPreApp.02")]
    public class BuyPreAppChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购补货返配申请单编号
        /// </summary>
        public string AppID { get; set; }
    }
}
