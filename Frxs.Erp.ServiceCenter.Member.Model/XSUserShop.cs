
/*****************************
* Author:CR
*
* Date:2016-03-22
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Member.Model
{
    /// <summary>
    /// 兴盛用户门店表XSUserShop实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class XSUserShop : BaseModel
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
        /// 用户编号
        /// </summary>
        [DataMember]
        [DisplayName("用户编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int XSUserID { get; set; }

        /// <summary>
        /// 门店ID(Shop.ShopID)
        /// </summary>
        [DataMember]
        [DisplayName("门店ID(Shop.ShopID)")]

        public int ShopID { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        [DisplayName("创建日期")]
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

        #endregion
    }

    
    public partial class XSUserShop : BaseModel
    {

    }
}