
/*****************************
* Author:CR
*
* Date:2016-04-11
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleSettle实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleSettle : BaseModel
    {

        #region 模型
        /// <summary>
        /// 结算ID
        /// </summary>
        [DataMember]
        [DisplayName("结算ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SettleID { get; set; }

        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(WarehouseID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 状态(0:未结算[预留];1:已确认[预留];2:已过帐)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未结算[预留];1:已确认[预留];2:已过帐)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 销售总金额(sum(SaleSettleDetail.BillPayAmt))
        /// </summary>
        [DataMember]
        [DisplayName("销售总金额(sum(SaleSettleDetail.BillPayAmt))")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal SaleAmt { get; set; }

        /// <summary>
        /// 退货总金额(Sum(SaleSettleDetail.BillPayAmt))
        /// </summary>
        [DataMember]
        [DisplayName("退货总金额(Sum(SaleSettleDetail.BillPayAmt))")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BackAmt { get; set; }

        /// <summary>
        /// 费用总金额(sum(SaleSettleDetail.BillPayAmt))
        /// </summary>
        [DataMember]
        [DisplayName("费用总金额(sum(SaleSettleDetail.BillPayAmt))")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal FeeAmt { get; set; }

        /// <summary>
        /// 结算总金额(只能>0; =销售总金额-退货总金额+费用总金额)
        /// </summary>
        [DataMember]
        [DisplayName("结算总金额(只能>0; =销售总金额-退货总金额+费用总金额)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal SettleAmt { get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        [DataMember]
        [DisplayName("结算时间")]

        public DateTime? SettleTime { get; set; }

        /// <summary>
        /// 订单ID(SaleOrder.OrderID)
        /// </summary>
        [DataMember]
        [DisplayName("订单ID(SaleOrder.OrderID)")]

        public string OrderID { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember]
        [DisplayName("门店ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        [DisplayName("门店编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// </summary>
        [DataMember]
        [DisplayName("门店类型(0:加盟店;1:签约店;)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopType { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        [DataMember]
        [DisplayName("门店名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopName { get; set; }

        /// <summary>
        /// 信用额度
        /// </summary>
        [DataMember]
        [DisplayName("信用额度")]

        public decimal? CreditAmt { get; set; }

        /// <summary>
        /// 银行帐号
        /// </summary>
        [DataMember]
        [DisplayName("银行帐号")]

        public string BankAccount { get; set; }

        /// <summary>
        /// 银行开户名称
        /// </summary>
        [DataMember]
        [DisplayName("银行开户名称")]

        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行类型(开户行)
        /// </summary>
        [DataMember]
        [DisplayName("银行类型(开户行)")]

        public string BankType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

        /// <summary>
        /// 结帐方式(0:现金 + 数据字典: ShopSettleType =Shop.SettleType)
        /// </summary>
        [DataMember]
        [DisplayName("结帐方式(0:现金 + 数据字典: ShopSettleType =Shop.SettleType)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SettleType { get; set; }

        /// <summary>
        /// 结帐方式名称(数据字典: ShopSettleType 对应的Label)
        /// </summary>
        [DataMember]
        [DisplayName("结帐方式名称(数据字典: ShopSettleType 对应的Label)")]

        public string SettleName { get; set; }

        /// <summary>
        /// 提交时间(预留)
        /// </summary>
        [DataMember]
        [DisplayName("提交时间(预留)")]

        public DateTime? ConfTime { get; set; }

        /// <summary>
        /// 提交用户ID(预留)
        /// </summary>
        [DataMember]
        [DisplayName("提交用户ID(预留)")]

        public int? ConfUserID { get; set; }

        /// <summary>
        /// 提交用户名称(预留)
        /// </summary>
        [DataMember]
        [DisplayName("提交用户名称(预留)")]

        public string ConfUserName { get; set; }

        /// <summary>
        /// 过帐时间(预留)
        /// </summary>
        [DataMember]
        [DisplayName("过帐时间(预留)")]

        public DateTime? PostingTime { get; set; }

        /// <summary>
        /// 过帐用户ID(预留)
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户ID(预留)")]

        public int? PostingUserID { get; set; }

        /// <summary>
        /// 过帐用户名称(预留)
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户名称(预留)")]

        public string PostingUserName { get; set; }

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
        [Required(ErrorMessage = "{0}不能为空")]
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

        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称")]

        public string WName { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号")]

        public string WCode { get; set; }

        #endregion
    }
}