/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 采购退货单创建(Created)事件
    /// 备注：当采购退货单在创建的时候（同步所有关联数据BuyBackDetails、BuyBackDetailsExt），需要发布此事件
    /// 使用范围：采购退货单（BuyBack）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyBack.01")]
    public class BuyBackCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 采购退货单编号
        /// </summary>
        public string BackID { get; set; }
    }
}
