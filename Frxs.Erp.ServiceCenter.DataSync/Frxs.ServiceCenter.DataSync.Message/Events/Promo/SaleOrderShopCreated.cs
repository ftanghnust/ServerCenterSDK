/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售订单表_门店 创建(Created)事件
    /// 备注：当 销售订单表_门店 (SaleOrderShop)在创建的时候（同步SaleOrderShopDetails列表、SaleOrderShopDetailsExt列表），需要发布此事件
    /// 使用范围：销售订单表_门店（SaleOrderShop）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Promo", "SaleOrderShop.01")]
    public class SaleOrderShopCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 销售订单表_门店 编号
        /// </summary>
        public string OrderId { get; set; }
    }
}
