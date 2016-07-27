
/*****************************
* Author:CR
*
* Date:2016-03-31
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库商品限购明细表WProductNoSaleDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductNoSaleDetails : BaseModel
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
        /// 限购ID(WProductNoSale.NoSaleID)
        /// </summary>
        [DataMember]
        [DisplayName("限购ID(WProductNoSale.NoSaleID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string NoSaleID { get; set; }

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
    }

    /// <summary>
    /// 扩展属性，提供给前台显示
    /// </summary>
    public partial class WProductNoSaleDetails : BaseModel
    {
        /// <summary>
        /// 库存单位
        /// </summary>
        [DataMember]
        public string Unit { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }
        
        /// <summary>
        /// 配送单位包装数
        /// </summary>
        [DataMember]
        public decimal BigPackingQty { get; set; }

        /// <summary>
        /// 配送单位
        /// </summary>
        [DataMember]
        public string BigUnit { get; set; }

        /// <summary>
        /// 配送价格 SalePrice*包装数
        /// </summary>
        [DataMember]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        [DataMember]
        public string BarCode { get; set; }

        /// <summary>
        /// ERP编码
        /// </summary>
        [DataMember]
        public string SKU { get; set; }
    }

}