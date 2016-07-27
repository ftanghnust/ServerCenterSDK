/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 预采购收货单被创建的时候触发事件需要传送的参数
    /// 备注：当 预采购收货单(BuyOrderPre)在创建的时候（同步所有关联数据BuyOrderPreDetails、BuyOrderPreDetailsExt），需要发布此事件
    /// 使用范围： 预采购收货单（BuyOrderPre）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyOrderPre.01")]
    public class BuyOrderPreCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 预采购收货单编号
        /// </summary>
        public string BuyID { get; set; }
    }
}
