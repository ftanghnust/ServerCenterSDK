/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售改单 创建(Created)事件
    /// 备注：当 销售改单(SaleEdit)在创建的时候（同步所有关联数据SaleEditDetails、SaleEditDetailsExt、SaleEditOrders），需要发布此事件
    /// 使用范围：销售改单（SaleEdit）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleEdit.01")]
    public class SaleEditCreated : MessageBodyBase, IEvent
    {
         /// <summary>
        ///销售改单 编号
        /// </summary>
        public string EditID { get; set; }
    }
}
