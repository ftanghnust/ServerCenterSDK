/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 商品变更(Changed)事件
    /// 备注：在母商品（BaseProduct）、商品规格属性关系（ProductAttribute）、商品规格属性图片（ProductAttributesPicture）、
    ///         商品条码（ProductBarCodes）、母商品图文详情（ProductDescription、ProductDescriptionPicture）、
    ///         商品主图（ProductPictureDetail）、商品供应商关系（ProductsVendor）、商品单位（ProductUnit）中的使用
    /// 使用范围：商品更改、母商品增删改,商品规格属性关系列表增删改、商品规格属性图片增删改、商品条码列表增删改、母商品图文详情增删改、
    ///          商品主图增删改、商品供应商关系列表增删改、商品单位列表增删改 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Product.02")]
    public class ProductChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }
    }
}
