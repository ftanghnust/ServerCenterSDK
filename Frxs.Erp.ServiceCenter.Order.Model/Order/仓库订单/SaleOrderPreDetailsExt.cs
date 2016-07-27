
/*****************************
* Author:leidong
*
* Date:2016-04-05
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleOrderPreDetailsExt实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleOrderPreDetailsExt : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号(SaleOrderDetails.ID)
        /// </summary>
        [DataMember]
        [DisplayName("编号(SaleOrderDetails.ID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 订单编号(SaleOrder.OrderID)
        /// </summary>
        [DataMember]
        [DisplayName("订单编号(SaleOrder.OrderID)")]

        public string OrderID { get; set; }

        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类一级分类ID(Category.CategoryId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CategoryId1 { get; set; }

        /// <summary>
        /// 基本分类一级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类一级分类名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CategoryId1Name { get; set; }

        /// <summary>
        /// 基本分类二级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类二级分类ID(Category.CategoryId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CategoryId2 { get; set; }

        /// <summary>
        /// 基本分类二级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类二级分类名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CategoryId2Name { get; set; }

        /// <summary>
        /// 基本分类三级分类ID(Category.CategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("基本分类三级分类ID(Category.CategoryId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 基本分类三级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("基本分类三级分类名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CategoryId3Name { get; set; }

        /// <summary>
        /// 运营一级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营一级分类ID(ShopCategory.ShopCategoryId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopCategoryId1 { get; set; }

        /// <summary>
        /// 运营一级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营一级分类名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCategoryId1Name { get; set; }

        /// <summary>
        /// 运营二级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营二级分类ID(ShopCategory.ShopCategoryId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopCategoryId2 { get; set; }

        /// <summary>
        /// 运营二级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营二级分类名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCategoryId2Name { get; set; }

        /// <summary>
        /// 运营三级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        [DataMember]
        [DisplayName("运营三级分类ID(ShopCategory.ShopCategoryId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopCategoryId3 { get; set; }

        /// <summary>
        /// 运营三级分类名称
        /// </summary>
        [DataMember]
        [DisplayName("运营三级分类名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCategoryId3Name { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("品牌ID")]

        public int BrandId1 { get; set; }

        /// <summary>
        /// 品牌ID名称
        /// </summary>
        [DataMember]
        [DisplayName("品牌ID名称")]

        public string BrandId1Name { get; set; }

        /// <summary>
        /// 子品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("子品牌ID")]

        public int BrandId2 { get; set; }

        /// <summary>
        /// 子品牌名称
        /// </summary>
        [DataMember]
        [DisplayName("子品牌名称")]

        public string BrandId2Name { get; set; }

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