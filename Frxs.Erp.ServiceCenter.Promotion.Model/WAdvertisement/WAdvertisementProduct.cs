
/*****************************
* Author:zhoujin
*
* Date:2016-03-29
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Promotion.Model
{
    /// <summary>
    /// 仓库--广告商品表WAdvertisementProduct实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WAdvertisementProduct : BaseModel
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
        /// 仓库编号(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("仓库编号(Warehouse.WID)")]

        public int WID { get; set; }

        /// <summary>
        /// 广告ID
        /// </summary>
        [DataMember]
        [DisplayName("广告ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AdvertisementID { get; set; }

        /// <summary>
        /// 促销ID、分类ID、商品ID
        /// </summary>
        [DataMember]
        [DisplayName("促销ID、分类ID、商品ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户 ID
        /// </summary>
        [DataMember]
        [DisplayName("创建用户 ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        [DisplayName("创建用户名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CreateUserName { get; set; }

        #endregion
    }
}