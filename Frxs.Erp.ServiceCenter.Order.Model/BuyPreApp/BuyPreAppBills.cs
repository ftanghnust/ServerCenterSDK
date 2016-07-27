
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
    /// BuyPreAppBills实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class BuyPreAppBills : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号(仓库ID+GUID)只有申请单过帐后，才会有值:
        /// </summary>
        [DataMember]
        [DisplayName("编号(仓库ID+GUID)只有申请单过帐后，才会有值:")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ID { get; set; }

        /// <summary>
        /// 申请编号(BuyPreApp.AppID)
        /// </summary>
        [DataMember]
        [DisplayName("申请编号(BuyPreApp.AppID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AppID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 单据ID(AppType=0:BuyBackPre.BackID;AppType=1:BuyOrderPre.BuyID)
        /// </summary>
        [DataMember]
        [DisplayName("单据ID(AppType=0:BuyBackPre.BackID;AppType=1:BuyOrderPre.BuyID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string BillID { get; set; }

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