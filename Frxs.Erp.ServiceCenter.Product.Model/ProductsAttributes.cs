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
    /// 商品多规格属性值表ProductsAttributes实体类
    /// </summary>
    [Serializable]
    public partial class ProductsAttributes : BaseModel
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
        /// 商品ID(Product.ProductId)
        /// </summary>
        [DataMember]
        [DisplayName("商品ID(Product.ProductId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductId { get; set; }

        /// <summary>
        /// 属性表ID(Attribute.AttributeId）
        /// </summary>
        [DataMember]
        [DisplayName("属性表ID(Attribute.AttributeId）")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int AttributeId { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        [DataMember]
        [DisplayName("属性名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AttributeName { get; set; }

        /// <summary>
        /// 属性值表ID(AttributeValues.ValueId）
        /// </summary>
        [DataMember]
        [DisplayName("属性值表ID(AttributeValues.ValueId）")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ValuesId { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [DataMember]
        [DisplayName("值")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ValueStr { get; set; }

        /// <summary>
        /// 最新修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改时间")]
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

        #endregion
    }
}