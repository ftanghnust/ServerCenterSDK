
/*****************************
* Author:TangFan
*
* Date:2016-03-10
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// BuyBackPreDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class BuyBackPreDetails : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号（仓库ID+GUID)
        /// </summary>
        [DataMember]
        [DisplayName("编号（仓库ID+GUID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 采购单编号
        /// </summary>
        [DataMember]
        [DisplayName("采购单编号")]

        public string BackID { get; set; }

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
        /// 采购单位
        /// </summary>
        [DataMember]
        [DisplayName("采购单位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string BackUnit { get; set; }

        /// <summary>
        /// 采购单位包装数
        /// </summary>
        [DataMember]
        [DisplayName("采购单位包装数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BackPackingQty { get; set; }

        /// <summary>
        /// 采购单位数量
        /// </summary>
        [DataMember]
        [DisplayName("采购单位数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BackQty { get; set; }

        /// <summary>
        /// 采购单位价格
        /// </summary>
        [DataMember]
        [DisplayName("采购单位价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double BackPrice { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        [DataMember]
        [DisplayName("库存单位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位数量=(BuyPackingQty*BuyQty)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位数量=(BuyPackingQty*BuyQty)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal UnitQty { get; set; }

        /// <summary>
        /// 库存单位价格
        /// </summary>
        [DataMember]
        [DisplayName("库存单位价格")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double UnitPrice { get; set; }

        /// <summary>
        /// 采购的总金额(=UnitQty*UnitPrice)
        /// </summary>
        [DataMember]
        [DisplayName("采购的总金额(=UnitQty*UnitPrice)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double SubAmt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Remark { get; set; }

        /// <summary>
        /// 序号(输入的序号,每一个单据从1开始)
        /// </summary>
        [DataMember]
        [DisplayName("序号(输入的序号,每一个单据从1开始)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SerialNumber { get; set; }

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
        [Required(ErrorMessage = "{0}不能为空")]
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }

        /// <summary>
        /// 配送价
        /// </summary>
        [DataMember]
        [DisplayName("配送价")]
        public decimal? SalePrice { get; set; }


        /// <summary>
        /// 状态 add:1 edit:2 del:3
        /// </summary>
        public int Status { get; set; }
        #endregion
    }
}