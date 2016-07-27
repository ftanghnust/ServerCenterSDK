/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// BaseProducts实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class BaseProducts : BaseModel
    {

        #region 模型
        /// <summary>
        /// 商品母表ID（初始值和Product.productID一样)
        /// </summary>
        [DataMember]
        [DisplayName("商品母表ID（初始值和Product.productID一样)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int BaseProductId { get; set; }

        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类一级分类ID(Category.CategoryId)")]

        public int CategoryId1 { get; set; }

        /// <summary>
        /// 基本分类二级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类二级分类ID(Category.CategoryId)")]

        public int CategoryId2 { get; set; }

        /// <summary>
        /// 基本分类三级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类三级分类ID(Category.CategoryId)")]

        public int CategoryId3 { get; set; }

        /// <summary>
        /// 运营一级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营一级分类ID(ShopCategory.ShopCategoryId)")]

        public int ShopCategoryId1 { get; set; }

        /// <summary>
        /// 运营二级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营二级分类ID(ShopCategory.ShopCategoryId)")]

        public int ShopCategoryId2 { get; set; }

        /// <summary>
        /// 运营三级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营三级分类ID(ShopCategory.ShopCategoryId)")]

        public int ShopCategoryId3 { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("品牌ID")]

        public int BrandId1 { get; set; }

        /// <summary>
        /// 子品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("子品牌ID")]

        public int BrandId2 { get; set; }

        /// <summary>
        /// 是否为多规格属性商品(0:不是;1:是)
        /// </summary>
        [DataMember]
        [DisplayName("是否为多规格属性商品(0:不是;1:是)")]

        public int IsMutiAttribute { get; set; }

        /// <summary>
        /// 是否为母商品(0:不是;1:是)
        /// </summary>
        [DataMember]
        [DisplayName("是否为母商品(0:不是;1:是)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsBaseProductId { get; set; }

        /// <summary>
        /// 母表商品名称（只有为母商品时才会有值)
        /// </summary>
        [DataMember]
        [DisplayName("母表商品名称（只有为母商品时才会有值)")]

        public string ProductBaseName { get; set; }

        /// <summary>
        /// 是否为第三方商品(0:不是;1:是 B2B固定为0)
        /// </summary>
        [DataMember]
        [DisplayName("是否为第三方商品(0:不是;1:是 B2B固定为0)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsVendor { get; set; }

        /// <summary>
        /// 删除状态(0:未删除;1:已删除;2:子商品另外挂到其它商品)
        /// </summary>
        [DataMember]
        [DisplayName("删除状态(0:未删除;1:已删除;2:子商品另外挂到其它商品)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        public int CreateUserID { get; set; }

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


    //public partial class BaseProducts : BaseModel
    //{
    //    /// <summary>
    //    /// 母商品文字详情
    //    /// </summary>
    //    [DataMember]
    //    [DisplayName("母商品文字详情")]
    //    public ProductsDescription ProductsDescription { get; set; }

    //    /// <summary>
    //    /// 母商品图文
    //    /// </summary>
    //    [DataMember]
    //    [DisplayName("母商品图文")]
    //    public ICollection<ProductsDescriptionPicture> ProductsDescriptionPictures { get; set; }

    //    /// <summary>
    //    /// 母商品供应商
    //    /// </summary>
    //    [DataMember]
    //    [DisplayName("母商品供应商")]
    //    public ICollection<ProductsVendor> ProductsVendor { get; set; }
    //}
}