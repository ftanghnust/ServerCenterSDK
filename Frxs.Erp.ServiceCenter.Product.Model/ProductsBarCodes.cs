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
    /// 商品国际条码ProductsBarCodes实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ProductsBarCodes : BaseModel
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
        /// 商品ID(product.ProductId)
        /// </summary>
        [DataMember]
        [DisplayName("商品ID(product.ProductId)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        [DataMember]
        [DisplayName("商品条码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string BarCode { get; set; }

        /// <summary>
        /// 排序(固定从1开始;1就是主条码)
        /// </summary>
        [DataMember]
        [DisplayName("排序(固定从1开始;1就是主条码)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int SerialNumber { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        [DisplayName("创建时间")]

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