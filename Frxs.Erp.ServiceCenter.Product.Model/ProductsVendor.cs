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
    /// 供应商商品表ProductsVendor实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductsVendor : BaseModel
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
        /// 仓库ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID")]
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
        /// 商品主供应商
        /// </summary>
        [DataMember]
        [DisplayName("商品主供应商")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int VendorID { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        [DataMember]
        [DisplayName("库存单位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位采购价格
        /// </summary>
        [DataMember]
        [DisplayName("库存单位采购价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double BuyPrice { get; set; }

        /// <summary>
        /// 是否为主供应商(0:不是;1:是)
        /// </summary>
        [DataMember]
        [DisplayName("是否为主供应商(0:不是;1:是)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsMaster { get; set; }

        /// <summary>
        /// 库存单位最新进价
        /// </summary>
        [DataMember]
        [DisplayName("库存单位最新进价")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double LastBuyPrice { get; set; }

        /// <summary>
        /// 最新采购入库时间
        /// </summary>
        [DataMember]
        [DisplayName("最新采购入库时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime LastBuyTime { get; set; }

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

        #region 扩展

        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        [DisplayName("产品名称")]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [DataMember]
        [DisplayName("SKU")]
        public string SKU { get; set; }

        /// <summary>
        /// 基本分类1
        /// </summary>
        [DataMember]
        [DisplayName("基本分类1")]
        public string CategoryName1 { get; set; }
        /// <summary>
        /// 基本分类2
        /// </summary>
        [DataMember]
        [DisplayName("基本分类2")]
        public string CategoryName2 { get; set; }
        /// <summary>
        /// 基本分类3
        /// </summary>
        [DataMember]
        [DisplayName("基本分类3")]
        public string CategoryName3 { get; set; }

        /// <summary>
        /// 国际条码
        /// </summary>
        [DataMember]
        [DisplayName("国际条码")]
        public string BarCode { get; set; }

        /// <summary>
        /// 包装数
        /// </summary>
        [DataMember]
        [DisplayName("包装数")]
        public string BigPackingQty { get; set; }



        #endregion

    }
}