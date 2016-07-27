
/*****************************
* Author:CR
*
* Date:2016-04-09
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库商品价格调整明细表WProductAdjPriceDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductAdjPriceDetails : BaseModel
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
        /// 调整ID(WProductAdjPrice.AdjID)
        /// </summary>
        [DataMember]
        [DisplayName("调整ID(WProductAdjPrice.AdjID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdjID { get; set; }

        /// <summary>
        /// 仓库商品ID(WProducts.WProductID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库商品ID(WProducts.WProductID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WProductID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID 二级)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID 二级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 商品ID(product.ProductID)
        /// </summary>
        [DataMember]
        [DisplayName("商品ID(product.ProductID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductID { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        [DataMember]
        [DisplayName("库存单位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位原配送价格/原进货(采购)价
        /// </summary>
        [DataMember]
        [DisplayName("库存单位原配送价格/原进货(采购)价")]

        public decimal? OldPrice { get; set; }

        /// <summary>
        /// 库存单位新配送价格/新进货(采购)价
        /// </summary>
        [DataMember]
        [DisplayName("库存单位新配送价格/新进货(采购)价")]

        public decimal? Price { get; set; }

        /// <summary>
        /// 原库存单位门店建议零售价
        /// </summary>
        [DataMember]
        [DisplayName("原库存单位门店建议零售价")]

        public decimal? OldMarketPrice { get; set; }

        /// <summary>
        /// 库存单位建议门店零售价
        /// </summary>
        [DataMember]
        [DisplayName("库存单位建议门店零售价")]

        public decimal? MarketPrice { get; set; }

        /// <summary>
        /// 原门店库存单位积分
        /// </summary>
        [DataMember]
        [DisplayName("原门店库存单位积分")]

        public decimal? OldShopPoint { get; set; }

        /// <summary>
        /// 原门店库存单位提点率(%)
        /// </summary>
        [DataMember]
        [DisplayName("原门店库存单位提点率(%)")]

        public decimal? OldShopAddPerc { get; set; }

        /// <summary>
        /// 门店库存单位积分
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位积分")]

        public decimal? ShopPoint { get; set; }

        /// <summary>
        /// 门店库存单位提点率(%)
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位提点率(%)")]

        public decimal? ShopPerc { get; set; }

        /// <summary>
        /// 原库存单位绩效积分(司机及门店共用)
        /// </summary>
        [DataMember]
        [DisplayName("原库存单位绩效积分(司机及门店共用)")]

        public decimal? OldBasePoint { get; set; }

        /// <summary>
        /// 库存单位绩效积分(司机及门店共用)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位绩效积分(司机及门店共用)")]

        public decimal? BasePoint { get; set; }

        /// <summary>
        /// 原库存单位物流费率(供应商) (%)
        /// </summary>
        [DataMember]
        [DisplayName("原库存单位物流费率(供应商) (%)")]

        public decimal? OldVendorPerc1 { get; set; }

        /// <summary>
        /// 原库存单位仓储费率(供应商)(%)
        /// </summary>
        [DataMember]
        [DisplayName("原库存单位仓储费率(供应商)(%)")]

        public decimal? OldVendorPerc2 { get; set; }

        /// <summary>
        /// 库存单位物流费率(供应商) (%)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位物流费率(供应商) (%)")]

        public decimal? VendorPerc1 { get; set; }

        /// <summary>
        /// 库存单位仓储费率(供应商)(%)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位仓储费率(供应商)(%)")]

        public decimal? VendorPerc2 { get; set; }

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
}