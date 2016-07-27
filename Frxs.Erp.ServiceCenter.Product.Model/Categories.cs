
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
    /// Categories实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Categories : BaseModel
    {

        #region 模型
        /// <summary>
        /// 分类ID
        /// </summary>
        [DataMember]
        [DisplayName("分类ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        [DisplayName("名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        [DisplayName("显示顺序")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int DisplaySequence { get; set; }

        /// <summary>
        /// 你级分类ID
        /// </summary>
        [DataMember]
        [DisplayName("你级分类ID")]

        public int ParentCategoryId { get; set; }

        /// <summary>
        /// 级别(0:顶级;1:一级;2:二级;3:三级)
        /// </summary>
        [DataMember]
        [DisplayName("级别(0:顶级;1:一级;2:二级;3:三级)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Depth { get; set; }

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

        #endregion
    }
}