
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
    /// SaleOrderSendNumber实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SaleOrderSendNumber : BaseModel
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
        /// 线路顺序(WarehouseLine.SerialNumber)
        /// </summary>
        [DataMember]
        [DisplayName("线路顺序(WarehouseLine.SerialNumber)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int LineSerialNumber { get; set; }

        /// <summary>
        /// 门店顺序(WarehouseLineShop.SerialNumber)
        /// </summary>
        [DataMember]
        [DisplayName("门店顺序(WarehouseLineShop.SerialNumber)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopSerialNumber { get; set; }

        /// <summary>
        /// 手动调整顺序(置顶为1;置底为9999; 订单确认时默认值为999);
        /// </summary>
        [DataMember]
        [DisplayName("手动调整顺序(置顶为1;置底为9999; 订单确认时默认值为999);")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SendNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public int? Remark { get; set; }

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