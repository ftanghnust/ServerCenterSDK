
/*****************************
* Author:leidong
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
    /// SaleOrderTrack实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleOrderTrack : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号(仓库ID+GUID)
        /// </summary>
        [DataMember]
        [DisplayName("编号(仓库ID+GUID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [DataMember]
        [DisplayName("订单编号")]

        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        [DataMember]
        [DisplayName("操作内容")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Remark { get; set; }

        /// <summary>
        /// 在用户端是否显示(0:不显示;1:显示)
        /// </summary>
        [DataMember]
        [DisplayName("在用户端是否显示(0:不显示;1:显示)")]

        public int? IsDisplayUser { get; set; }

        /// <summary>
        /// 状态编号(对于Order.OrderStatus)
        /// </summary>
        [DataMember]
        [DisplayName("状态编号(对于Order.OrderStatus)")]

        public int? OrderStatus { get; set; }

        /// <summary>
        /// 状态编号名称(对于Order.OrderStatus)
        /// </summary>
        [DataMember]
        [DisplayName("状态编号名称(对于Order.OrderStatus)")]

        public string OrderStatusName { get; set; }

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

        public int? CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]

        public string CreateUserName { get; set; }

        #endregion
    }
}