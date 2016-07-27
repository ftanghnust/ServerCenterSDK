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
    /// 多规格属性表Attributes实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Attributes : BaseModel
    {

        #region 模型
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        [DisplayName("主键ID")]
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
        /// 是否删除(0:未删除;1:已删除)
        /// </summary>
        [DataMember]
        [DisplayName("是否删除(0:未删除;1:已删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDeleted { get; set; }

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

        /// <summary>
        /// 最新修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最新修改时间")]
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

        #endregion
    }


    /// <summary>
    /// 规格包含商品
    /// </summary>
    [Serializable]
    [DataContract]
    public class AttributesProducts : BaseModel
    {
        #region 模型
        /// <summary>
        /// 商品ID(主键)SKUNumberService.ID取得
        /// </summary>
        [DataMember]
        [DisplayName("商品ID(主键)SKUNumberService.ID取得")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品编码(0000001,0000002),最长7个长度;唯一（SKUNumberService.ID取得补0)
        /// </summary>
        [DataMember]
        [DisplayName("商品编码(0000001,0000002),最长7个长度;唯一（SKUNumberService.ID取得补0)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SKU { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        [DisplayName("商品名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ProductName { get; set; }


        /// <summary>
        /// Erp编码
        /// </summary>
        [DataMember]
        [DisplayName("Erp编码")]
        public string ErpCode { get; set; }

        /// <summary>
        /// 规格值
        /// </summary>
        [DataMember]
        [DisplayName("规格值")]
        public string ValueStr { get; set; }
        #endregion
    }
}