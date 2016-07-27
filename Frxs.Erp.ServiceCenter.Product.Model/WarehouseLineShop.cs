
/*****************************
* Author:CR
*
* Date:2016-03-15
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库配送线路门店关系表WarehouseLineShop实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WarehouseLineShop : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键(ID)
        /// </summary>
        [DataMember]
        [DisplayName("主键(ID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 线路ID(WarehouseLine.LineID)
        /// </summary>
        [DataMember]
        [DisplayName("线路ID(WarehouseLine.LineID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int LineID { get; set; }

        /// <summary>
        /// 门店ID(Shop.Shop)
        /// </summary>
        [DataMember]
        [DisplayName("门店ID(Shop.Shop)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 发货排序
        /// </summary>
        [DataMember]
        [DisplayName("发货排序")]

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

        /// <summary>
        /// 门店名称
        /// </summary>
        [DataMember]
        [DisplayName("门店名称")]
        public string ShopName { get; set; }

        #endregion
    }
}