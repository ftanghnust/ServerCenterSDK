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
    /// ProductsAttributesPicture实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductsAttributesPicture : BaseModel
    {

        #region 模型
        /// <summary>
        /// 商品ID(Product.ProductId)
        /// </summary>
        [DataMember]
        [DisplayName("商品ID(Product.ProductId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductId { get; set; }

        /// <summary>
        /// 原图800*800路径
        /// </summary>
        [DataMember]
        [DisplayName("原图800*800路径")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrlOrg { get; set; }

        /// <summary>
        /// zip为400*400的图路径
        /// </summary>
        [DataMember]
        [DisplayName("zip为400*400的图路径")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrl400x400 { get; set; }

        /// <summary>
        /// zip为200*200的图路径
        /// </summary>
        [DataMember]
        [DisplayName("zip为200*200的图路径")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrl200x200 { get; set; }

        /// <summary>
        /// zip为120*120的图路径
        /// </summary>
        [DataMember]
        [DisplayName("zip为120*120的图路径")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrl120x120 { get; set; }

        /// <summary>
        /// zip为60*60的图路径
        /// </summary>
        [DataMember]
        [DisplayName("zip为60*60的图路径")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ImageUrl60x60 { get; set; }

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

        #endregion
    }
}