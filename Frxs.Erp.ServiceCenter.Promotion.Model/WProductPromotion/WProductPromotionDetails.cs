/*****************************
* Author:
*
* Date:2016-04-07
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Promotion.Model
{
    /// <summary>
    /// WProductPromotionDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductPromotionDetails : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 促销ID(WProductPromotion.PromotionID)
        /// </summary>
        [DataMember]
        [DisplayName("促销ID(WProductPromotion.PromotionID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string PromotionID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID 二级)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID 二级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 仓库商品ID(WProducts.WProductID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库商品ID(WProducts.WProductID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WProductID { get; set; }

        /// <summary>
        /// 商品ID(product.ProductID)
        /// </summary>
        [DataMember]
        [DisplayName("商品ID(product.ProductID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductID { get; set; }

        /// <summary>
        /// 商品编码(Product.SKU)
        /// </summary>
        [DataMember]
        [DisplayName("商品编码(Product.SKU)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SKU { get; set; }

        /// <summary>
        /// 商品名称(Products.ProductName)
        /// </summary>
        [DataMember]
        [DisplayName("商品名称(Products.ProductName)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ProductName { get; set; }

        /// <summary>
        /// 库存单位(WProducts.Unit)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位(WProducts.Unit)")]

        public string Unit { get; set; }

        /// <summary>
        /// 配送(销售)单位包装数)( WProducts.BigPackingQty)  2016-6-20 按照会议要求，类型统一由int改成decimal
        /// </summary>
        [DataMember]
        [DisplayName("配送(销售)单位包装数)( WProducts.BigPackingQty)")]

        public decimal? PackingQty { get; set; }

        /// <summary>
        /// 配送(销售)单位( WProducts.BigUnit)
        /// </summary>
        [DataMember]
        [DisplayName("配送(销售)单位( WProducts.BigUnit)")]

        public string SaleUnit { get; set; }

        /// <summary>
        /// 库存单位销售价格(WProducts.SalePrice)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位销售价格(WProducts.SalePrice)")]

        public decimal? SalePrice { get; set; }

        /// <summary>
        /// 门店库存单位原积分(PomotionType=1:WProducts.ShopPoint;PomotionType=2: WProducts.AddShopPerc)
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位原积分(PomotionType=1:WProducts.ShopPoint;PomotionType=2: WProducts.AddShopPerc)")]

        public decimal? OldPoint { get; set; }

        /// <summary>
        /// PomotionType=1:门店库存单位促销积分;PomotionType=2:门店库存单位平台费率
        /// </summary>
        [DataMember]
        [DisplayName("PomotionType=1:门店库存单位促销积分;PomotionType=2:门店库存单位平台费率")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal Point { get; set; }

        /// <summary>
        /// 每单订购上限数量(库存单位; 0:不受限;>0 受限) PomotionType=1才有用到;
        /// </summary>
        [DataMember]
        [DisplayName("每单订购上限数量(库存单位; 0:不受限;>0 受限) PomotionType=1才有用到;")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal MaxOrderQty { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        public int? CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        #endregion

    }

    public partial class WProductPromotionDetails : BaseModel
    {
        /// <summary>
        /// 商品条码
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]
        public string BarCode { get; set; }
    }
}
