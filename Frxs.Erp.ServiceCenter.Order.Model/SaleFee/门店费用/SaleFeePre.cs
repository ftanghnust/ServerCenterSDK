
/*****************************
* Author:chujl
*
* Date:2016-03-28
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleFeePre实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleFeePre : BaseModel
    {

        #region 模型
        /// <summary>
        /// 费用ID(SaleFee.FeeID)
        /// </summary>
        [DataMember]
        [DisplayName("费用ID(SaleFee.FeeID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FeeID { get; set; }

        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(WarehouseID)")]
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
        /// 仓库名称(Warehouse.WarehouseName)
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称(Warehouse.WarehouseName)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string WName { get; set; }

        /// <summary>
        /// 仓库子机构ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库子机构ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SubWID { get; set; }

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
        /// 状态(0:录单;1:确认;2:过帐;3:结算)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:录单;1:确认;2:过帐;3:结算)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 费用金额(小于0代表销售退回;大于0代表销售增加)(=sum(SaleFeeDetail.FeeAmt)
        /// </summary>
        [DataMember]
        [DisplayName("费用金额(小于0代表销售退回;大于0代表销售增加)(=sum(SaleFeeDetail.FeeAmt)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double TotalFeeAmt { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        [DataMember]
        [DisplayName("提交时间")]
        [Required(ErrorMessage = "{0}不能为空")]
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
        [Required(ErrorMessage = "{0}不能为空")]
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

        public int? SettleUserID { get; set; }

        /// <summary>
        /// 结算用户名称
        /// </summary>
        [DataMember]
        [DisplayName("结算用户名称")]

        public string SettleUserName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

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

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改用户名称")]

        public string ModifyUserName { get; set; }

        /// <summary>
        /// 费用日期
        /// </summary>
        [DataMember]
        [DisplayName("费用日期")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime FeeDate { get; set; }



        #region 扩展

        /// <summary>
        /// 状态(0:录单;1:确认;2:过帐;3:结算)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:录单;1:确认;2:过帐;3:结算)")]

        public string StatusToStr { get; set; }

        #endregion

        /// <summary>
        /// 明细列表
        /// </summary>
        [DataMember]
        public IList<SaleFeePreDetails> detailList;
        #endregion
    }
}