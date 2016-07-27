
using Frxs.Erp.ServiceCenter.Order.Model;
/*****************************
* Author:TangFan
*
* Date:2016-03-17
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.ServiceCenter.Order.Model
{
    /// <summary>
    /// BuyOrder实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class BuyOrder : BaseModel
    {

        #region 模型
        /// <summary>
        /// 采购单编号
        /// </summary>
        [DataMember]
        [DisplayName("采购单编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string BuyID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 仓库柜台
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SubWID { get; set; }

        /// <summary>
        /// 预定订单编号(预留)
        /// </summary>
        [DataMember]
        [DisplayName("预定订单编号(预留)")]

        public string PreBuyID { get; set; }

        /// <summary>
        /// 采购入库时间(OrderStatus=1;格式:yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [DataMember]
        [DisplayName("采购入库时间(OrderStatus=1;格式:yyyy-MM-dd HH:mm:ss)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(Warehouse.WCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称(Warehouse.WName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称(Warehouse.WName)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string WName { get; set; }

        /// <summary>
        /// 仓库子机构编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构编号(Warehouse.WCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SubWCode { get; set; }

        /// <summary>
        /// 仓库子机构名称(Warehouse.WName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构名称(Warehouse.WName)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SubWName { get; set; }

        /// <summary>
        /// 供应商分类ID
        /// </summary>
        [DataMember]
        [DisplayName("供应商分类ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int VendorID { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [DataMember]
        [DisplayName("供应商编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [DataMember]
        [DisplayName("供应商名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string VendorName { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已提交;2:已过帐;3:已结算)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未提交;1:已提交;2:已过帐;3:已结算)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 采购总金额(BuyOrderDetails.SubBuyAmt)
        /// </summary>
        [DataMember]
        [DisplayName("采购总金额(BuyOrderDetails.SubBuyAmt)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double TotalOrderAmt { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        [DataMember]
        [DisplayName("提交时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ConfTime { get; set; }

        /// <summary>
        /// 提交用户ID
        /// </summary>
        [DataMember]
        [DisplayName("提交用户ID")]

        public int ConfUserID { get; set; }

        /// <summary>
        /// 提交用户名称
        /// </summary>
        [DataMember]
        [DisplayName("提交用户名称")]

        public string ConfUserName { get; set; }

        /// <summary>
        /// 过帐时间
        /// </summary>
        [DataMember]
        [DisplayName("过帐时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime PostingTime { get; set; }

        /// <summary>
        /// 过帐用户ID
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户ID")]

        public int PostingUserID { get; set; }

        /// <summary>
        /// 过帐用户名称
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户名称")]

        public string PostingUserName { get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        [DataMember]
        [DisplayName("结算时间")]

        public DateTime SettleTime { get; set; }

        /// <summary>
        /// 结算用户ID
        /// </summary>
        [DataMember]
        [DisplayName("结算用户ID")]

        public int SettleUserID { get; set; }

        /// <summary>
        /// 结算用户名称
        /// </summary>
        [DataMember]
        [DisplayName("结算用户名称")]

        public string SettleUserName { get; set; }

        /// <summary>
        /// 结算ID(BuySettle.SettleID)
        /// </summary>
        [DataMember]
        [DisplayName("结算ID(BuySettle.SettleID)")]

        public string SettleID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        [DisplayName("创建日期")]
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