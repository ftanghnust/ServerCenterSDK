
/*****************************
* Author:CR
*
* Date:2016-04-05
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库待装区表WStationNumber实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WStationNumber : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 待装区编号(同一个仓库不能重复)
        /// </summary>
        [DataMember]
        [DisplayName("待装区编号(同一个仓库不能重复)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int StationNumber { get; set; }

        /// <summary>
        /// 状态(0:空闲;1:正在使用;2:冻结; 可以物理删除)
        /// </summary>
        [DataMember]
        [DisplayName("状态(0:空闲;1:正在使用;2:冻结; 可以物理删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 门店ID(status=1时才有值)
        /// </summary>
        [DataMember]
        [DisplayName("门店ID(status=1时才有值)")]

        public int ShopID { get; set; }

        /// <summary>
        /// 订单编号(status=1时才有值)
        /// </summary>
        [DataMember]
        [DisplayName("订单编号(status=1时才有值)")]

        public string OrderID { get; set; }

        /// <summary>
        /// 配送日期(status=1时才有值 填入值为 SaleOrder.ConfDate)
        /// </summary>
        [DataMember]
        [DisplayName("配送日期(status=1时才有值 填入值为 SaleOrder.ConfDate)")]

        public DateTime? OrderConfDate { get; set; }

        /// <summary>
        /// 所属路线(status=1时才有值)
        /// </summary>
        [DataMember]
        [DisplayName("所属路线(status=1时才有值)")]

        public int LineID { get; set; }

        /// <summary>
        /// 订单状态(status=1时才有值; 值：3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中)
        /// </summary>
        [DataMember]
        [DisplayName("订单状态(status=1时才有值; 值：3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中)")]

        public int OrderStatus { get; set; }

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

        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改删除时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户ID")]

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        [DataMember]
        [DisplayName("最后修改删除用户名称")]

        public string ModifyUserName { get; set; }

        #endregion
    }

    public partial class WStationNumber : BaseModel
    {
         /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        [DisplayName("门店编号")]
        public string ShopCode { get; set; }

         /// <summary>
        /// 门店名称
        /// </summary>
        [DataMember]
        [DisplayName("门店名称")]
        public string ShopName { get; set; }

         /// <summary>
        /// 配送线路
        /// </summary>
        [DataMember]
        [DisplayName("配送线路")]
        public string LineName { get; set; }

         /// <summary>
        /// 配送员
        /// </summary>
        [DataMember]
        [DisplayName("配送员")]
        public string EmpName { get; set; }
    }
}