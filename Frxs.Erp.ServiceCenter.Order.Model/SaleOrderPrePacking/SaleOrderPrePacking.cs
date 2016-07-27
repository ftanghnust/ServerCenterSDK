
/*****************************
* Author:CR
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
    /// SaleOrderPrePacking实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleOrderPrePacking : BaseModel
    {

        #region 模型
        /// <summary>
        /// 订单编号(SaleOrder.OrderID)
        /// </summary>
        [DataMember]
        [DisplayName("订单编号(SaleOrder.OrderID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 周转箱数
        /// </summary>
        [DataMember]
        [DisplayName("周转箱数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Package1Qty { get; set; }

        /// <summary>
        /// 纸箱数
        /// </summary>
        [DataMember]
        [DisplayName("纸箱数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Package2Qty { get; set; }

        /// <summary>
        /// 易碎品箱数
        /// </summary>
        [DataMember]
        [DisplayName("易碎品箱数")]

        public int? Package3Qty { get; set; }

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