/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购补货返配申请单 创建(Created)事件
    /// 备注：当  采购补货返配申请单(BuyPreApp)在创建的时候（同步所有关联数据BuyPreAppBills、BuyPreAppDetails、BuyPreAppDetailsExt），需要发布此事件
    /// 使用范围：  采购补货返配申请单（BuyPreApp）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyPreApp.01")]
    public class BuyPreAppCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购补货返配申请单编号
        /// </summary>
        public string AppID { get; set; }
    }
}
