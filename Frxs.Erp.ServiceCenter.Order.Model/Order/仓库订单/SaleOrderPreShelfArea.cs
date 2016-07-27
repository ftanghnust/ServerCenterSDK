/*********************************************************
 * FRXS 小马哥 2016/4/12 17:46:08
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// SaleOrderPreShelfArea实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleOrderPreShelfArea : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID(WID + GUID)
        /// </summary>
        [DataMember]
        [DisplayName("主键ID(WID + GUID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

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
        /// 周转箱数(预留)
        /// </summary>
        [DataMember]
        [DisplayName("周转箱数(预留)")]

        public int? Package1Qty { get; set; }

        /// <summary>
        /// 纸箱数(预留)
        /// </summary>
        [DataMember]
        [DisplayName("纸箱数(预留)")]

        public int? Package2Qty { get; set; }

        /// <summary>
        /// 易碎品箱数(预留)
        /// </summary>
        [DataMember]
        [DisplayName("易碎品箱数(预留)")]

        public int? Package3Qty { get; set; }

        /// <summary>
        /// 备注(预留)
        /// </summary>
        [DataMember]
        [DisplayName("备注(预留)")]

        public int Remark { get; set; }

        /// <summary>
        /// 货架号区号ID
        /// </summary>
        [DataMember]
        [DisplayName("货架号区号ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 仓库货区编号(数据字典：ShelfAreaCode)
        /// </summary>
        [DataMember]
        [DisplayName("仓库货区编号(数据字典：ShelfAreaCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区名称
        /// </summary>
        [DataMember]
        [DisplayName("货区名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShelfAreaName { get; set; }

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
        /// 开始拣货时间
        /// </summary>
        [DataMember]
        [DisplayName("开始拣货时间")]

        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 完成拣货时间
        /// </summary>
        [DataMember]
        [DisplayName("完成拣货时间")]

        public DateTime? EndTime { get; set; }

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
        /// 对货时间
        /// </summary>
        [DataMember]
        [DisplayName("对货时间")]
        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 对货用户ID
        /// </summary>
        [DataMember]
        [DisplayName("对货用户ID")]
        public int? CheckUserID { get; set; }

        /// <summary>
        /// 对货用户名称
        /// </summary>
        [DataMember]
        [DisplayName("对货用户名称")]
        public string CheckUserName { get; set; }

        #endregion
    }
}
