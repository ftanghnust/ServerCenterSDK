/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售退货单 创建(Created)事件
    /// 备注：当 销售退货单(SaleBack)在创建的时候（同步所有关联数据SaleBackDetails、SaleBackDetailsExt），需要发布此事件
    /// 使用范围： 销售退货单（SaleBack）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleBack.01")]
    public class SaleBackCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        ///销售退货单 编号
        /// </summary>
        public string BackID { get; set; }
    }
}
