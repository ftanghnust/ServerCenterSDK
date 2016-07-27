/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 1:55:02 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 商品创建(Created)事件
    /// 备注：商品创建会同时将其关联的母商品（BaseProduct）、商品规格属性关系列表（ProductAttribute）、商品规格图片（ProductAttributesPicture）、
    ///       商品条码列表（ProductBarCodes）、母商品文字详情（ProductDescription）、母商品图片详情列表（ProductDescriptionPicture）
    ///       商品主图列表（ProductPictureDetail）、商品供应商关系列表（ProductsVendor）、商品单位列表（ProductUnit） 同步过来
    /// 使用范围：商品创建 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Product.01")]
    public class ProductCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

    }
}