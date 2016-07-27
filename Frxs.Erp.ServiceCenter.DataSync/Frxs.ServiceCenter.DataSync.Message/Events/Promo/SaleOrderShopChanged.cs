/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售订单表_门店 变更(Changed)事件
    /// 备注：在  销售订单表_门店（SaleOrderShop）变更 的时候（同步SaleOrderShopDetails列表、SaleOrderShopDetailsExt列表），需要发布此事件
    /// 使用范围： 销售订单表_门店（SaleOrderShop）编辑,销售订单商品明细_门店（SaleOrderShopDetails）列表增删改、
    /// 销售订单商品明细扩展（SaleOrderShopDetailsExt）列表增删改 操作中使用
    /// </summary>
    [Serializable, EventGroup("Promo", "SaleOrderShop.02")]
    public class SaleOrderShopChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 销售订单表_门店 编号
        /// </summary>
        public string OrderId { get; set; }
    }
}
