
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
    /// BuyPreApp实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class BuyPreApp : BaseModel
    {

        #region 模型
        /// <summary>
        /// 申请ID
        /// </summary>
        [DataMember]
        [DisplayName("申请ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AppID { get; set; }

        /// <summary>
        /// 申请类型(0:返配;1:补货)
        /// </summary>
        [DataMember]
        [DisplayName("申请类型(0:返配;1:补货)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AppType { get; set; }

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
        /// 仓库柜台
        /// </summary>
        [DataMember]
        [DisplayName("仓库柜台")]
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
        /// 申请时间
        /// </summary>
        [DataMember]
        [DisplayName("申请时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime AppDate { get; set; }

        /// <summary>
        /// 采购员ID(WarehouseEmp.EmpID and UserType=4)(采购员没有起作用)
        /// </summary>
        [DataMember]
        [DisplayName("采购员ID(WarehouseEmp.EmpID and UserType=4)")]

        public int? BuyEmpID { get; set; }

        /// <summary>
        /// 采购员名称(WarehouseEmp.EmpName and UserType=4)(采购员没有起作用)
        /// </summary>
        [DataMember]
        [DisplayName("采购员名称(WarehouseEmp.EmpName and UserType=4)")]

        public string BuyEmpName { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已提交;2:已过帐)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:未提交;1:已提交;2:已过帐)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 总金额sum(BuyPreEditDetail.SubAmt)
        /// </summary>
        [DataMember]
        [DisplayName("总金额sum(BuyPreEditDetail.SubAmt)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal TotalAmt { get; set; }

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

        public int? ConfUserID { get; set; }

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

        public int? PostingUserID { get; set; }

        /// <summary>
        /// 过帐用户名称
        /// </summary>
        [DataMember]
        [DisplayName("过帐用户名称")]

        public string PostingUserName { get; set; }

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
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户ID")]

        public int? CreateUserID { get; set; }

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
        /// 状态扩展列
        /// </summary>
        [DataMember]
        [DisplayName("状态扩展列")]
        public string StatusStr { get; set; }

        #endregion
    }
}