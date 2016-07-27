
/*****************************
* Author:CR
*
* Date:2016-04-02
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// WProductsBuy实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductsBuy : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID(WProduct.WProductID 1对1的关系)
        /// </summary>
        [DataMember]
        [DisplayName("主键ID(WProduct.WProductID 1对1的关系)")]
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
        /// 库存单位采购价格
        /// </summary>
        [DataMember]
        [DisplayName("库存单位采购价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// 大(采购)单位总部的商品多单位ID(ProductsUnit.ID)
        /// </summary>
        [DataMember]
        [DisplayName("大(采购)单位总部的商品多单位ID(ProductsUnit.ID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int BigProductsUnitID { get; set; }

        /// <summary>
        /// 大(采购)单位包装数(冗余设计 选中配送单位时,同步该表,没有时该值为库存单位)
        /// </summary>
        [DataMember]
        [DisplayName("大(采购)单位包装数(冗余设计 选中配送单位时,同步该表,没有时该值为库存单位)")]

        public decimal BigPackingQty { get; set; }

        /// <summary>
        /// 大(采购)单位(冗余设计 选中配送单位时,同步该表,没有时该值为1)
        /// </summary>
        [DataMember]
        [DisplayName("大(采购)单位(冗余设计 选中配送单位时,同步该表,没有时该值为1)")]

        public string BigUnit { get; set; }

        /// <summary>
        /// 商品主供应商ID(Vendor.VendorID)
        /// </summary>
        [DataMember]
        [DisplayName("商品主供应商ID(Vendor.VendorID)")]

        public int VendorID { get; set; }

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改删除时间")]

        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户ID")]

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户名称")]

        public string ModifyUserName { get; set; }

        #endregion
    }

    /// <summary>
    /// WProductsBuy实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductsBuyQModel : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID(WProduct.WProductID 1对1的关系)
        /// </summary>
        [DataMember]
        [DisplayName("主键ID(WProduct.WProductID 1对1的关系)")]
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
        /// 库存单位采购价格
        /// </summary>
        [DataMember]
        [DisplayName("库存单位采购价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// 大(采购)单位总部的商品多单位ID(ProductsUnit.ID)
        /// </summary>
        [DataMember]
        [DisplayName("大(采购)单位总部的商品多单位ID(ProductsUnit.ID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int BigProductsUnitID { get; set; }

        /// <summary>
        /// 大(采购)单位包装数(冗余设计 选中配送单位时,同步该表,没有时该值为库存单位)
        /// </summary>
        [DataMember]
        [DisplayName("大(采购)单位包装数(冗余设计 选中配送单位时,同步该表,没有时该值为库存单位)")]

        public decimal BigPackingQty { get; set; }

        /// <summary>
        /// 大(采购)单位(冗余设计 选中配送单位时,同步该表,没有时该值为1)
        /// </summary>
        [DataMember]
        [DisplayName("大(采购)单位(冗余设计 选中配送单位时,同步该表,没有时该值为1)")]

        public string BigUnit { get; set; }

        /// <summary>
        /// 商品主供应商ID(Vendor.VendorID)
        /// </summary>
        [DataMember]
        [DisplayName("商品主供应商ID(Vendor.VendorID)")]

        public int VendorID { get; set; }

        [DataMember]
        public string VendorCode { get; set; }

        [DataMember]
        public string VendorName { get; set; }
        #endregion
    }
}