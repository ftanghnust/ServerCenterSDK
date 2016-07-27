/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// ProductsDescription实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductsDescription : BaseModel
    {

        #region 模型
        /// <summary>
        /// 商品母表ID（初始值和BaseProduct.BaseProductID一样)
        /// </summary>
        [DataMember]
        [DisplayName("商品母表ID（初始值和BaseProduct.BaseProductID一样)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int BaseProductId { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        [DataMember]
        [DisplayName("商品描述")]

        public string Description { get; set; }

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改删除时间")]

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
}