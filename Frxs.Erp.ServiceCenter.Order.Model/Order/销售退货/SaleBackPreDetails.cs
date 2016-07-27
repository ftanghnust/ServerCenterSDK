
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleBackPreDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleBackPreDetails : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号(GUID)
        /// </summary>
        [DataMember]
        [DisplayName("编号(GUID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 退货编号(SaleOrders.OrderID)
        /// </summary>
        [DataMember]
        [DisplayName("退货编号(SaleOrders.OrderID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string BackID { get; set; }

        /// <summary>
        /// 商品编号(Prouct.ProductID)
        /// </summary>
        [DataMember]
        [DisplayName("商品编号(Prouct.ProductID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品SKU(ERP编码)
        /// </summary>
        [DataMember]
        [DisplayName("商品SKU(ERP编码)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SKU { get; set; }

        /// <summary>
        /// 描述商品名称(Product.ProductName)
        /// </summary>
        [DataMember]
        [DisplayName("描述商品名称(Product.ProductName)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品的国际条码
        /// </summary>
        [DataMember]
        [DisplayName("商品的国际条码")]

        public string BarCode { get; set; }

        /// <summary>
        /// 商品图片用于移动端(Products.ImageUrl200*200)
        /// </summary>
        [DataMember]
        [DisplayName("商品图片用于移动端(Products.ImageUrl200*200)")]

        public string ProductImageUrl200 { get; set; }

        /// <summary>
        /// 商品图片用于PC端(Products.ImageUrl400*400)
        /// </summary>
        [DataMember]
        [DisplayName("商品图片用于PC端(Products.ImageUrl400*400)")]

        public string ProductImageUrl400 { get; set; }

        /// <summary>
        /// 退货单位
        /// </summary>
        [DataMember]
        [DisplayName("退货单位")]

        public string BackUnit { get; set; }

        /// <summary>
        /// 退货单位包装数(固定为库存单位)
        /// </summary>
        [DataMember]
        [DisplayName("退货单位包装数(固定为库存单位)")]
        public decimal BackPackingQty { get; set; }

        /// <summary>
        /// 退货单位数量
        /// </summary>
        [DataMember]
        [DisplayName("退货单位数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BackQty { get; set; }

        /// <summary>
        /// 采购单位价格
        /// </summary>
        [DataMember]
        [DisplayName("采购单位价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BackPrice { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        [DataMember]
        [DisplayName("库存单位")]
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位数量(=BackPackingQty*BackQty)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位数量(=BackPackingQty*BackQty)")]
        public decimal UnitQty { get; set; }

        /// <summary>
        /// 库存单位价格
        /// </summary>
        [DataMember]
        [DisplayName("库存单位价格")]
        public decimal UnitPrice { get; set; }


        /// <summary>
        /// 库存单位积分
        /// </summary>
        [DataMember]
        [DisplayName("库存单位积分")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BasePoint { get; set; }

        /// <summary>
        /// 调整后的金额(=UnitQty*UnitPrice)
        /// </summary>
        [DataMember]
        [DisplayName("调整后的金额(=UnitQty*UnitPrice)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal SubAmt { get; set; }

        /// <summary>
        /// 小计积分(=ShopPoint*UnitQty)
        /// </summary>
        [DataMember]
        [DisplayName("小计积分(=ShopPoint*UnitQty)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal SubBasePoint { get; set; }

        /// <summary>
        /// 门店库存单位平台率(%)(=WProducts.ShopAddPerc)
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位平台率(%)(=WProducts.ShopAddPerc)")]
        public decimal? ShopAddPerc { get; set; }

        /// <summary>
        /// 库存单位物流费率(=WProducts.VendorPerc1)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位物流费率(=WProducts.VendorPerc1)")]
        public decimal? VendorPerc1 { get; set; }

        /// <summary>
        /// 库存单位仓储费率(=WProducts.VendorPerc2)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位仓储费率(=WProducts.VendorPerc2)")]
        public decimal? VendorPerc2 { get; set; }

        /// <summary>
        /// 小计门店提点金额,平台费用(=ShopAddPerc*SubAmt)
        /// </summary>
        [DataMember]
        [DisplayName("小计门店提点金额,平台费用(=ShopAddPerc*SubAmt)")]
        public decimal? SubAddAmt { get; set; }

        /// <summary>
        /// 小计供应商物流费(=VendorPerc1*SubAmt)
        /// </summary>
        [DataMember]
        [DisplayName("小计供应商物流费(=VendorPerc1*SubAmt)")]
        public decimal? SubVendor1Amt { get; set; }

        /// <summary>
        /// 小计供应商仓储费(=VendorPerc2*SubAmt)
        /// </summary>
        [DataMember]
        [DisplayName("小计供应商仓储费(=VendorPerc2*SubAmt)")]
        public decimal? SubVendor2Amt { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

        /// <summary>
        /// 序号(输入的序号,每一个单据从1开始)
        /// </summary>
        [DataMember]
        [DisplayName("序号(输入的序号,每一个单据从1开始)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SerialNumber { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }

        #endregion
    }
}