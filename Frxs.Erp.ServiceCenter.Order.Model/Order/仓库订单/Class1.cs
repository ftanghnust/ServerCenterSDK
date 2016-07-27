
/*****************************
* Author:leidong
*
* Date:2016-04-13
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleOrderPreDetailsPick实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleOrderPreDetailsPick : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号(=SaleOrderDetails.ID)
        /// </summary>
        [DataMember]
        [DisplayName("编号(=SaleOrderDetails.ID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [DataMember]
        [DisplayName("订单编号")]

        public string OrderID { get; set; }

        /// <summary>
        /// 商品编号(Prouct.ProductID)
        /// </summary>
        [DataMember]
        [DisplayName("商品编号(Prouct.ProductID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductID { get; set; }

        /// <summary>
        /// WCProduct.WCProductID
        /// </summary>
        [DataMember]
        [DisplayName("WCProduct.WCProductID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WCProductID { get; set; }

        /// <summary>
        /// 商品SKU
        /// </summary>
        [DataMember]
        [DisplayName("商品SKU")]
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
        /// 商品图片用于PC端(Products.ImageUrl200*200)
        /// </summary>
        [DataMember]
        [DisplayName("商品图片用于PC端(Products.ImageUrl200*200)")]

        public string ProductImageUrl400 { get; set; }

        /// <summary>
        /// 货架号区号ID
        /// </summary>
        [DataMember]
        [DisplayName("货架号区号ID")]

        public int? ShelfAreaID { get; set; }

        /// <summary>
        /// 货位ID
        /// </summary>
        [DataMember]
        [DisplayName("货位ID")]

        public int? ShelfID { get; set; }

        /// <summary>
        /// 货位编号
        /// </summary>
        [DataMember]
        [DisplayName("货位编号")]

        public string ShelfCode { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        [DataMember]
        [DisplayName("购买数量")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal SaleQty { get; set; }

        /// <summary>
        /// 购买单位
        /// </summary>
        [DataMember]
        [DisplayName("购买单位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SaleUnit { get; set; }

        /// <summary>
        /// 购买单位包装数
        /// </summary>
        [DataMember]
        [DisplayName("购买单位包装数")]

        public int? SalePackingQty { get; set; }

        /// <summary>
        /// 拣货数量
        /// </summary>
        [DataMember]
        [DisplayName("拣货数量")]

        public decimal? PickQty { get; set; }

        /// <summary>
        /// 拣货人员ID
        /// </summary>
        [DataMember]
        [DisplayName("拣货人员ID")]

        public int? PickUserID { get; set; }

        /// <summary>
        /// 拣货人员名称
        /// </summary>
        [DataMember]
        [DisplayName("拣货人员名称")]

        public string PickUserName { get; set; }

        /// <summary>
        /// 拣货时间
        /// </summary>
        [DataMember]
        [DisplayName("拣货时间")]

        public DateTime? PickTime { get; set; }

        /// <summary>
        /// 对货时间
        /// </summary>
        [DataMember]
        [DisplayName("对货时间")]

        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 对货人员ID
        /// </summary>
        [DataMember]
        [DisplayName("对货人员ID")]

        public int? CheckUserID { get; set; }

        /// <summary>
        /// 对货人员名称
        /// </summary>
        [DataMember]
        [DisplayName("对货人员名称")]

        public string CheckUserName { get; set; }

        /// <summary>
        /// 对货是否正确(0:错误;1:正确）
        /// </summary>
        [DataMember]
        [DisplayName("对货是否正确(0:错误;1:正确）")]

        public int? IsCheckRight { get; set; }

        /// <summary>
        /// 是否为后来添加商品(0:不是;1:是的)
        /// </summary>
        [DataMember]
        [DisplayName("是否为后来添加商品(0:不是;1:是的)")]

        public int? IsAppend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

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

        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }

        #endregion
    }
}