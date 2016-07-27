
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
    /// SaleSettle零时表
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleSettleTemp : BaseModel
    {

        #region 模型
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("订单ID")]        
        public string OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("订单ID")]        
        public string BillID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("明细ID")]        
        public string BillDetailsID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("时间")]        
        public DateTime BillDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("单据类型(0:销售订单;1:销售退货单;2:销售费用单)")]        
        public int BillType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("金额")]
        public decimal BillAmt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("平台费金额(提点率) 销售费用单该值为0;")]
        public decimal BillAddAmt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("")]
        public decimal BillPayAmt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("费用项目ID(数据字典; SaleFeeCode)")]        
        public string FeeCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("费用二级项目名称")]        
        public string FeeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("费用原因/退货原因")]
        public string Remark { get; set; }

        #endregion

    }
}