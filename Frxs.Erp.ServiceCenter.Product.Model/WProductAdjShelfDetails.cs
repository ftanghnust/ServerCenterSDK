
/*****************************
* Author:CR
*
* Date:2016-03-25
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库商品货架调整明细表WProductAdjShelfDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductAdjShelfDetails : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long ID { get; set; }

        /// <summary>
        /// 调整ID(WProductAdjPrice.AdjID)
        /// </summary>
        [DataMember]
        [DisplayName("调整ID(WProductAdjPrice.AdjID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AdjID { get; set; }

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
        public int ProductId { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        [DataMember]
        [DisplayName("库存单位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 原货架ID
        /// </summary>
        [DataMember]
        [DisplayName("原货架ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int OldShelfID { get; set; }

        /// <summary>
        /// 原货架编号
        /// </summary>
        [DataMember]
        [DisplayName("原货架编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OldShelfCode { get; set; }

        /// <summary>
        /// 新货架ID
        /// </summary>
        [DataMember]
        [DisplayName("新货架ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShelfID { get; set; }

        /// <summary>
        /// 新货架编号
        /// </summary>
        [DataMember]
        [DisplayName("新货架编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShelfCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Remark { get; set; }

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

        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        #endregion

        #region 扩展

        /// <summary>
        /// 包装数
        /// </summary>
        [DataMember]
        [DisplayName("BigPackingQty")]
        public decimal BigPackingQty { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [DataMember]
        [DisplayName("商品编码")]
        public string SKU { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        [DisplayName("商品名称")]
        public string ProductName { get; set; }
      
        /// <summary>
        /// 商品条码
        /// </summary>
        [DataMember]
        [DisplayName("商品条码")]
        public string BarCode { get; set; }

        #endregion
    }
}