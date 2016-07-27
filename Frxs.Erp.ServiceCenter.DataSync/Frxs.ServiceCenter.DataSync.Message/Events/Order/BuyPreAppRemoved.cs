/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购补货返配申请单移除(Remove)事件
    /// 备注：当 采购补货返配申请单（BuyPreApp）在移除的时候，需要发布此事件
    /// 使用范围：采购补货返配申请单（BuyPreApp）移除操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyPreApp.03")]
    public class BuyPreAppRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购补货返配申请单编号
        /// </summary>
        public string AppID { get; set; }
    }
}
