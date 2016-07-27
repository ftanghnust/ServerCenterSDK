
/*****************************
* Author:chujl
*
* Date:2016-03-28
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleFeePreDetails实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleFeePreDetails : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID(GUID)
        /// </summary>
        [DataMember]
        [DisplayName("主键ID(GUID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 仓库ID(WarehouseID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(WarehouseID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 费用ID(SaleFee.FeeID)
        /// </summary>
        [DataMember]
        [DisplayName("费用ID(SaleFee.FeeID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FeeID { get; set; }

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
        /// 门店名称
        /// </summary>
        [DataMember]
        [DisplayName("门店名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopName { get; set; }

        /// <summary>
        /// 费用项目ID(数据字典; SaleFeeCode)
        /// </summary>
        [DataMember]
        [DisplayName("费用项目ID(数据字典; SaleFeeCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int FeeCode { get; set; }

        /// <summary>
        /// 费用项目名称
        /// </summary>
        [DataMember]
        [DisplayName("费用项目名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FeeName { get; set; }

        /// <summary>
        /// 费用原因
        /// </summary>
        [DataMember]
        [DisplayName("费用原因")]

        public string Reason { get; set; }

        /// <summary>
        /// 费用订单编号(SaleOrders.OrderId)
        /// </summary>
        [DataMember]
        [DisplayName("费用订单编号(SaleOrders.OrderId)")]

        public string OrderId { get; set; }

        /// <summary>
        /// 费用金额(小于0代表销售退回;大于0代表销售增加)
        /// </summary>
        [DataMember]
        [DisplayName("费用金额(小于0代表销售退回;大于0代表销售增加)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double FeeAmt { get; set; }

        /// <summary>
        /// 结算ID
        /// </summary>
        [DataMember]
        [DisplayName("结算ID")]

        public string SettleID { get; set; }

        /// <summary>
        /// 结算完成时间
        /// </summary>
        [DataMember]
        [DisplayName("结算完成时间")]

        public DateTime? SettleTime { get; set; }

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