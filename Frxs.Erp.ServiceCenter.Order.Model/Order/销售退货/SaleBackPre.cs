
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleBackPre实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleBackPre : BaseModel
    {

        #region 模型
        /// <summary>
        /// 退货单编号
        /// </summary>
        [DataMember]
        [DisplayName("退货单编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string BackID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 仓库编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(Warehouse.WCode)")]

        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称(Warehouse.WName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称(Warehouse.WName)")]

        public string WName { get; set; }

        /// <summary>
        /// 仓库柜台ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SubWID { get; set; }

        /// <summary>
        /// 仓库柜台编号(Warehouse.WCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台编号(Warehouse.WCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SubWCode { get; set; }

        /// <summary>
        /// 仓库柜台名称(Warehouse.WName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台名称(Warehouse.WName)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SubWName { get; set; }

        /// <summary>
        /// 退货日期(格式:yyyy-MM-dd)
        /// </summary>
        [DataMember]
        [DisplayName("退货日期(格式:yyyy-MM-dd)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime BackDate { get; set; }

        /// <summary>
        /// 兴盛用户ID(预留)
        /// </summary>
        [DataMember]
        [DisplayName("兴盛用户ID(预留)")]

        public long XSUserID { get; set; }

        /// <summary>
        /// 下单门店ID
        /// </summary>
        [DataMember]
        [DisplayName("下单门店ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 下单门店编号
        /// </summary>
        [DataMember]
        [DisplayName("下单门店编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 下单门店名称
        /// </summary>
        [DataMember]
        [DisplayName("下单门店名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopName { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已确认;2:已过帐;3:已结算)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未提交;1:已确认;2:已过帐;3:已结算)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 退货金额(SaleBackDetails.BackAmt)
        /// </summary>
        [DataMember]
        [DisplayName("退货金额(SaleBackDetails.BackAmt)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal TotalBackAmt { get; set; }

        /// <summary>
        /// 积分(SaleBackDetails.SubPoint)
        /// </summary>
        [DataMember]
        [DisplayName("积分(SaleBackDetails.SubPoint)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal TotalBasePoint { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        [DataMember]
        [DisplayName("总数量")]
        public decimal TotalBackQty { get; set; }

        /// <summary>
        /// 门店合计提点金额sum(SaleBackDettail.SubAddAmt)
        /// </summary>
        [DataMember]
        [DisplayName("门店合计提点金额sum(SaleBackDettail.SubAddAmt)")]
        public decimal? TotalAddAmt { get; set; }

        /// <summary>
        /// 最后计算金额/应退金额（=TotalBackAmtt+TotalAddAmt)
        /// </summary>
        [DataMember]
        [DisplayName("最后计算金额/应退金额（=TotalBackAmtt+TotalAddAmt)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal PayAmount { get; set; }



        /// <summary>
        /// 提交时间
        /// </summary>
        [DataMember]
        [DisplayName("提交时间")]
        public DateTime? ConfTime { get; set; }

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
        public DateTime? PostingTime { get; set; }

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
        public DateTime? SettleTime { get; set; }

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
        /// 结算ID(SaleSettle.SettleID)
        /// </summary>
        [DataMember]
        [DisplayName("结算ID(SaleSettle.SettleID)")]
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


    /// <summary>
    /// 查询显示实体
    /// </summary>
    public partial class SaleBackPre : BaseModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        [DisplayName("状态")]
        public string StatusStr { get; set; }
    }
}