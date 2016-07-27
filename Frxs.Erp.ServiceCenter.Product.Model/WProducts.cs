
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
    /// 仓库商品表WProducts实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProducts : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long WProductID { get; set; }

        /// <summary>
        /// 仓库ID(一级)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(一级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 商品ID(product.ProductID)
        /// </summary>
        [DataMember]
        [DisplayName("商品ID(product.ProductID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductId { get; set; }

        /// <summary>
        /// 仓库商品副标题(加入时，为空，由仓库自行定行, 商品详情如果仓库有时，显示自己的，没有时显示总部的)
        /// </summary>
        [DataMember]
        [DisplayName("仓库商品副标题(加入时，为空，由仓库自行定行, 商品详情如果仓库有时，显示自己的，没有时显示总部的)")]

        public string ProductName2 { get; set; }

        /// <summary>
        /// 仓库商品状态(0:已移除1:正常;2:淘汰;3:冻结;) ;淘汰商品和冻结商品不能销售;加入或重新加入时为正常；移除后再加入时为正常
        /// </summary>
        [DataMember]
        [DisplayName("仓库商品状态(0:已移除1:正常;2:淘汰;3:冻结;) ;淘汰商品和冻结商品不能销售;加入或重新加入时为正常；移除后再加入时为正常")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WStatus { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        [DataMember]
        [DisplayName("库存单位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位销售价格
        /// </summary>
        [DataMember]
        [DisplayName("库存单位销售价格")]

        public decimal? SalePrice { get; set; }

        /// <summary>
        /// 建议门店零售价
        /// </summary>
        [DataMember]
        [DisplayName("建议门店零售价")]

        public decimal? MarketPrice { get; set; }

        /// <summary>
        /// 建议门店零售单位
        /// </summary>
        [DataMember]
        [DisplayName("建议门店零售单位")]

        public string MarketUnit { get; set; }

        /// <summary>
        /// 大(配送)单位总部的商品多单位ID(ProductsUnit.ID)
        /// </summary>
        [DataMember]
        [DisplayName("大(配送)单位总部的商品多单位ID(ProductsUnit.ID)")]

        public int? BigProductsUnitID { get; set; }

        /// <summary>
        /// 大(配送)单位包装数(冗余设计 选中配送单位时,同步该表,没有时该值为库存单位)
        /// </summary>
        [DataMember]
        [DisplayName("大(配送)单位包装数(冗余设计 选中配送单位时,同步该表,没有时该值为库存单位)")]

        public decimal? BigPackingQty { get; set; }

        /// <summary>
        /// 大(配送)单位(冗余设计 选中配送单位时,同步该表,没有时该值为1)
        /// </summary>
        [DataMember]
        [DisplayName("大(配送)单位(冗余设计 选中配送单位时,同步该表,没有时该值为1)")]

        public string BigUnit { get; set; }

        /// <summary>
        /// 货架ID(Shelf.ShelfID)
        /// </summary>
        [DataMember]
        [DisplayName("货架ID(Shelf.ShelfID)")]

        public int? ShelfID { get; set; }

        /// <summary>
        /// 门店库存单位提点率(%)
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位提点率(%)")]

        public decimal? ShopAddPerc { get; set; }

        /// <summary>
        /// 门店库存单位积分
        /// </summary>
        [DataMember]
        [DisplayName("门店库存单位积分")]

        public decimal? ShopPoint { get; set; }

        /// <summary>
        /// 库存单位绩效积分（司机及门店绩效分)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位绩效积分（司机及门店绩效分)")]

        public decimal? BasePoint { get; set; }

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
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

        public string SaleBackFlag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]

        public int? BackDays { get; set; }

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

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改删除时间")]

        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户ID")]

        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户名称")]

        public string ModifyUserName { get; set; }

        #endregion

    }

    /// <summary>
    /// 扩展 
    /// </summary>
    [Serializable]
    [DataContract]
    public class WProductExt : WProducts
    {
        #region 扩展字段
        /// <summary>
        /// 配送销售总价（销售配送价 * 包装数）
        /// </summary>
        [DataMember]
        [DisplayName("配送销售总价（销售配送价 * 包装数）")]
        public decimal BigSalePrice { get; set; }

        
        /// <summary>
        /// WProductsBuy 表中
        /// </summary>
        [DataMember]
        [DisplayName("WProductsBuy 表中")]
        public decimal BuyPrice { get; set; }


        
        /// <summary>
        /// 配送积分兑物总价（销售配送价 * 包装数）
        /// </summary>
        [DataMember]
        [DisplayName("配送积分兑物总价（销售配送价 * 包装数）")]
        public decimal BigShopPoint { get; set; }

        /// <summary>
        /// 商口明细图片400x400
        /// </summary>
        [DataMember]
        [DisplayName("商口明细图片400x400")]
        public string ImageUrl400x400 { get; set; }

        /// <summary>
        /// 商口明细图片200x200
        /// </summary>
        [DataMember]
        [DisplayName("商口明细图片200x200")]
        public string ImageUrl200x200 { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        [DisplayName("商品名称")]
        public string ProductName { get; set; }

        
        /// <summary>
        /// MaxOrderQty
        /// </summary>
        [DataMember]
        [DisplayName("MaxOrderQty")]
        public decimal MaxOrderQty { get; set; }


        /// <summary>
        /// SKU
        /// </summary>
        [DataMember]
        [DisplayName("SKU")]
        public string SKU { get; set; }

        
        /// <summary>
        /// BarCode
        /// </summary>
        [DataMember]
        [DisplayName("BarCode")]
        public string BarCode { get; set; }
        /// <summary>
        /// CategoryName1
        /// </summary>
        [DataMember]
        [DisplayName("CategoryName1")]
        public string CategoryName1 { get; set; }
        /// <summary>
        /// CategoryName2
        /// </summary>
        [DataMember]
        [DisplayName("CategoryName2")]
        public string CategoryName2 { get; set; }
        /// <summary>
        /// CategoryName3
        /// </summary>
        [DataMember]
        [DisplayName("CategoryName3")]
        public string CategoryName3 { get; set; }

        /// <summary>
        /// CategoryId1
        /// </summary>
        [DataMember]
        [DisplayName("CategoryId1")]
        public int CategoryId1 { get; set; }
        /// <summary>
        /// CategoryId2
        /// </summary>
        [DataMember]
        [DisplayName("CategoryId2")]
        public int CategoryId2 { get; set; }
        /// <summary>
        /// CategoryId3
        /// </summary>
        [DataMember]
        [DisplayName("CategoryId3")]
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 货位区域ID
        /// </summary>
        [DataMember]
        [DisplayName("ShelfAreaID")]
        public int ShelfAreaID { get; set; }
        /// <summary>
        /// 货位区域编码
        /// </summary>
        [DataMember]
        [DisplayName("ShelfAreaCode")]
        public string ShelfAreaCode { get; set; }
        /// <summary>
        /// 货位编码
        /// </summary>
        [DataMember]
        [DisplayName("ShelfCode")]
        public string ShelfCode { get; set; }
        /// <summary>
        /// 货位区域名称
        /// </summary>
        [DataMember]
        [DisplayName("ShelfAreaName")]
        public string ShelfAreaName { get; set; }

        /// 促销积分
        /// </summary>
        [DataMember]
        [DisplayName("PromotionShopPoint")]
        public decimal? PromotionShopPoint { set; get; }
        
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("VendorID")]
        public int? VendorID { get; set; }

        
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("VendorName")]
        public string VendorName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("VendorCode")]
        public string VendorCode { get; set; }

        /// <summary>
        /// 采购员ID
        /// </summary>
        [DataMember]
        [DisplayName("EmpID")]
        public string EmpID { get; set; }

        /// <summary>
        /// 采购员
        /// </summary>
        [DataMember]
        [DisplayName("EmpName")]
        public string EmpName { get; set; }

        

        #endregion
    }
}
