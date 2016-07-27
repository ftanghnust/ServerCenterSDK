
/*****************************
* Author:CR
*
* Date:2016-04-25
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// BuyPreAppDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class BuyPreAppDetails : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号(仓库ID+GUID)
        /// </summary>
        [DataMember]
        [DisplayName("编号(仓库ID+GUID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 申请编号(BuyPreApp.AppID)
        /// </summary>
        [DataMember]
        [DisplayName("申请编号(BuyPreApp.AppID)")]

        public string AppID { get; set; }

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
        /// 申请单位(即采购单位)
        /// </summary>
        [DataMember]
        [DisplayName("申请单位(即采购单位)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AppUnit { get; set; }

        /// <summary>
        /// 申请单位包装数(即采购单位包装数)
        /// </summary>
        [DataMember]
        [DisplayName("申请单位包装数(即采购单位包装数)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal AppPackingQty { get; set; }

        /// <summary>
        /// 申请单位数量(采购单位数量)
        /// </summary>
        [DataMember]
        [DisplayName("申请单位数量(采购单位数量)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal AppQty { get; set; }

        /// <summary>
        /// 采购单位价格(UnitPrice*AppPackingQty)
        /// </summary>
        [DataMember]
        [DisplayName("采购单位价格(UnitPrice*AppPackingQty)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal AppPrice { get; set; }

        /// <summary>
        /// 库存单位（WProducts.Unit)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位（WProducts.Unit)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位数量(=AppPackingQty*AppQty)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位数量(=AppPackingQty*AppQty)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal UnitQty { get; set; }

        /// <summary>
        /// 库存单位价格(WProduct.BuyPrice)
        /// </summary>
        [DataMember]
        [DisplayName("库存单位价格(WProduct.BuyPrice)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 采购的总金额(=UnitQty*UnitPrice)
        /// </summary>
        [DataMember]
        [DisplayName("采购的总金额(=UnitQty*UnitPrice)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal SubAmt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

        /// <summary>
        /// 序号(输入的序号,每一个单据从1开始)
        /// </summary>
        [DataMember]
        [DisplayName("序号(输入的序号,每一个单据从1开始)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SerialNumber { get; set; }

        /// <summary>
        /// 商品主供应商ID(WProductBuy.VendorID)
        /// </summary>
        [DataMember]
        [DisplayName("商品主供应商ID(WProductBuy.VendorID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int VendorID { get; set; }

        /// <summary>
        /// 商品主供应商编号
        /// </summary>
        [DataMember]
        [DisplayName("商品主供应商编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string VendorCode { get; set; }

        /// <summary>
        /// 商品主供应商名称
        /// </summary>
        [DataMember]
        [DisplayName("商品主供应商名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string VendorName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户ID")]

        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }


        /// <summary>
        /// 采购员ID(WarehouseEmp.EmpID and UserType=4)
        /// </summary>
        [DataMember]
        [DisplayName("采购员ID(WProductsBuyEmp.EmpID and SerialNumber=1  )")]

        public int? BuyEmpID { get; set; }

        /// <summary>
        /// 采购员名称(WarehouseEmp.EmpName and UserType=4)
        /// </summary>
        [DataMember]
        [DisplayName("采购员名称(WProductsBuyEmp.EmpName and SerialNumber=1 )")]

        public string BuyEmpName { get; set; }

        #endregion
    }
}