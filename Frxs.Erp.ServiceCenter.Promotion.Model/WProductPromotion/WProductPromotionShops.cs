
/*****************************
* Author:CR
*
* Date:2016-04-08
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Promotion.Model
{
    /// <summary>
    /// WProductPromotionShops实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WProductPromotionShops : BaseModel
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
        /// 促销ID(WProductPromotion.PromotionID)
        /// </summary>
        [DataMember]
        [DisplayName("促销ID(WProductPromotion.PromotionID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string PromotionID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID 二级)
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID(Warehouse.WID 二级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 门店ID(Shop.ShopID)
        /// </summary>
        [DataMember]
        [DisplayName("门店ID(Shop.ShopID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopID { get; set; }

        /// <summary>
        /// 门店编号(Shop.ShopCode)
        /// </summary>
        [DataMember]
        [DisplayName("门店编号(Shop.ShopCode)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称(Shop.ShopName)
        /// </summary>
        [DataMember]
        [DisplayName("门店名称(Shop.ShopName)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ShopName { get; set; }

        /// <summary>
        /// 门店类型(0:加盟店;1:签约店;)
        /// </summary>
        [DataMember]
        [DisplayName("门店类型(0:加盟店;1:签约店;)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ShopType { get; set; }

        /// <summary>
        /// 门店地址全称
        /// </summary>
        [DataMember]
        [DisplayName("门店地址全称")]

        public string FullAddress { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]

        public DateTime? CreateTime { get; set; }

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