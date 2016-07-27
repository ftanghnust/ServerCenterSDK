

/*****************************
* Author:CR
*
* Date:2016-03-14
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 从原表Buymoo_BrandCategories 复制结构及名称BrandCategories实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class BrandCategories : BaseModel
    {
        #region 模型
        /// <summary>
        /// 品牌ID
        /// </summary>
        [DataMember]
        [DisplayName("品牌ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int BrandId { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [DataMember]
        [DisplayName("品牌名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string BrandName { get; set; }

        /// <summary>
        /// 品牌英文名称
        /// </summary>
        [DataMember]
        [DisplayName("品牌英文名称")]

        public string BrandEnName { get; set; }

        /// <summary>
        /// 品牌URL
        /// </summary>
        [DataMember]
        [DisplayName("品牌URL")]
        public string Logo { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        [DisplayName("显示顺序")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int DisplaySequence { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除)
        /// </summary>
        [DataMember]
        [DisplayName("是否删除(0:未删除;1:已删除)")]
        public int IsDeleted { get; set; }

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

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改时间")]
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

