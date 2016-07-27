
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
    /// SaleSettleDetail实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleSettleDetail : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID(WID+GUID)
        /// </summary>
        [DataMember]
        [DisplayName("主键ID(WID+GUID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

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
        /// 单据类型(0:销售订单;1:销售退货单;2:销售费用单)
        /// </summary>
        [DataMember]
        [DisplayName("单据类型(0:销售订单;1:销售退货单;2:销售费用单)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int BillType { get; set; }

        /// <summary>
        /// 单据ID(SaleOrder.OrderID,SaleBack.backID,SaleFee.FeeID)
        /// </summary>
        [DataMember]
        [DisplayName("单据ID(SaleOrder.OrderID,SaleBack.backID,SaleFee.FeeID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string BillID { get; set; }

        /// <summary>
        /// 单据明细ID(SaleFeeDetails.ID 只有费用才有值)
        /// </summary>
        [DataMember]
        [DisplayName("单据明细ID(SaleFeeDetails.ID 只有费用才有值)")]

        public string BillDetailsID { get; set; }

        /// <summary>
        /// 单据日期(SaleOrder.OrderDate,SaleBack.BackDate,SaleFee.FeeDate)
        /// </summary>
        [DataMember]
        [DisplayName("单据日期(SaleOrder.OrderDate,SaleBack.BackDate,SaleFee.FeeDate)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime BillDate { get; set; }

        /// <summary>
        /// 金额(SaleAmt,BackAmt[为负],FeeAmt[为费用金额时可以正负])
        /// </summary>
        [DataMember]
        [DisplayName("金额(SaleAmt,BackAmt[为负],FeeAmt[为费用金额时可以正负])")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BillAmt { get; set; }

        /// <summary>
        /// 平台费金额(提点率) 销售费用单该值为0;
        /// </summary>
        [DataMember]
        [DisplayName("平台费金额(提点率) 销售费用单该值为0;")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BillAddAmt { get; set; }

        /// <summary>
        /// =BillAmt+BillAddAmt
        /// </summary>
        [DataMember]
        [DisplayName("=BillAmt+BillAddAmt")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal BillPayAmt { get; set; }

        /// <summary>
        /// 费用项目ID(数据字典; SaleFeeCode)
        /// </summary>
        [DataMember]
        [DisplayName("费用项目ID(数据字典; SaleFeeCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FeeCode { get; set; }

        /// <summary>
        /// 费用二级项目名称
        /// </summary>
        [DataMember]
        [DisplayName("费用二级项目名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FeeName { get; set; }

        /// <summary>
        /// 费用原因/退货原因
        /// </summary>
        [DataMember]
        [DisplayName("费用原因/退货原因")]

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

        /// <summary>
        /// 单据类型(0:销售订单;1:销售退货单;2:销售费用单)
        /// </summary>
        [DataMember]
        [DisplayName("单据类型(0:销售订单;1:销售退货单;2:销售费用单)")]        
        public string BillTypeStr { get; set; }
        #endregion
    }
}