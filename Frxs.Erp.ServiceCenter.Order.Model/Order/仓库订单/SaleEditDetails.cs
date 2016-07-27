
/*****************************
* Author:leidong
*
* Date:2016-04-20
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleEditDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleEditDetails : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号(仓库ID+GUID)
        /// </summary>
        [DataMember]
        [DisplayName("编号(仓库ID+GUID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 改单ID
        /// </summary>
        [DataMember]
        [DisplayName("改单ID")]

        public string EditID { get; set; }

        /// <summary>
        /// 订单编号(SaleEdit.OrderID)
        /// </summary>
        [DataMember]
        [DisplayName("订单编号(SaleEdit.OrderID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

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
        /// 仓库商品主键ID（WCProduct.WCProductID）
        /// </summary>
        [DataMember]
        [DisplayName("仓库商品主键ID（WCProduct.WCProductID）")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WCProductID { get; set; }

        /// <summary>
        /// 配送(销售)单位
        /// </summary>
        [DataMember]
        [DisplayName("配送(销售)单位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SaleUnit { get; set; }

        /// <summary>
        /// 配送(销售)单位包装数
        /// </summary>
        [DataMember]
        [DisplayName("配送(销售)单位包装数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal SalePackingQty { get; set; }

        /// <summary>
        /// 配送(销售)单位价格(UnitPrice*SalePackingQty)
        /// </summary>
        [DataMember]
        [DisplayName("配送(销售)单位价格(UnitPrice*SalePackingQty)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 推荐数量
        /// </summary>
        [DataMember]
        [DisplayName("推荐数量")]

        public decimal? SaleQty { get; set; }

        /// <summary>
        /// 库存单位(WProducts.Unit)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位(WProducts.Unit)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位实发数量=SalePackingQty*SaleQty
        /// </summary>
        [DataMember]
        [DisplayName("库存单位实发数量=SalePackingQty*SaleQty")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal UnitQty { get; set; }

        /// <summary>
        /// 库存单位价格(WProduct.SalePrice 四舍五入到4位小数)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位价格(WProduct.SalePrice 四舍五入到4位小数)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 库存单位促销价格(WProductPromotionDetails.PromotionPrice 预留)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位促销价格(WProductPromotionDetails.PromotionPrice 预留)")]

        public decimal? PromotionUnitPrice { get; set; }

        /// <summary>
        /// 调整后的最终金额(=ifnull(PromotionPrice,UnitPrice) *UnitQty)
        /// </summary>
        [DataMember]
        [DisplayName("调整后的最终金额(=ifnull(PromotionPrice,UnitPrice) *UnitQty)")]

        public decimal? SubAmt { get; set; }

        /// <summary>
        /// 门店库存单位平台率(%)(=WProducts.ShopAddPerc)
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位平台率(%)(=WProducts.ShopAddPerc)")]

        public decimal? ShopAddPerc { get; set; }

        /// <summary>
        /// 门店库存单位积分(=WProducts.ShopPoint)
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位积分(=WProducts.ShopPoint)")]

        public decimal? ShopPoint { get; set; }

        /// <summary>
        /// 门店库存单位促销积分(=WProductPromotionDetails.PromotionShopPoint)
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位促销积分(=WProductPromotionDetails.PromotionShopPoint)")]

        public decimal? PromotionShopPoint { get; set; }

        /// <summary>
        /// 库存单位绩效积分(=WProducts.BasePoint)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位绩效积分(=WProducts.BasePoint)")]

        public decimal? BasePoint { get; set; }

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
        /// 小计门店积分(=ifnull(PromotionShopPoint,ShopPoint)*UnitQty)
        /// </summary>
        [DataMember]
        [DisplayName("小计门店积分(=ifnull(PromotionShopPoint,ShopPoint)*UnitQty)")]

        public decimal? SubPoint { get; set; }

        /// <summary>
        /// 小计绩效积分(=BasePoint*UnitQty)
        /// </summary>
        [DataMember]
        [DisplayName("小计绩效积分(=BasePoint*UnitQty)")]

        public decimal? SubBasePoint { get; set; }

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
        /// 序号(输入的序号,每一个单据从1开始)(推荐到订单明细时固定为 9999)
        /// </summary>
        [DataMember]
        [DisplayName("序号(输入的序号,每一个单据从1开始)(推荐到订单明细时固定为 9999)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SerialNumber { get; set; }

        /// <summary>
        /// 货架号区号
        /// </summary>
        [DataMember]
        [DisplayName("货架号区号")]

        public int? ShelfAreaID { get; set; }

        /// <summary>
        /// 仓库货区编号(数据字典：ShelfAreaCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库货区编号(数据字典：ShelfAreaCode)")]

        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区名称
        /// </summary>
        [DataMember]
        [DisplayName("货区名称")]

        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 货位ID
        /// </summary>
        [DataMember]
        [DisplayName("货位ID")]

        public int? ShelfID { get; set; }

        /// <summary>
        /// 货位编号
        /// </summary>
        [DataMember]
        [DisplayName("货位编号")]

        public string ShelfCode { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        [DataMember]
        [DisplayName("库存数量")]

        public decimal? StockQty { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]

        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }

        #endregion
    }
}