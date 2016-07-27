/*****************************
* Author:叶求
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
    /// 供应商类型VendorType实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class VendorType : BaseModel
    {

        #region 模型
        /// <summary>
        /// 供应商分类ID
        /// </summary>
        [DataMember]
        [DisplayName("供应商分类ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int VendorTypeID { get; set; }

        /// <summary>
        /// 供应商分类名称
        /// </summary>
        [DataMember]
        [DisplayName("供应商分类名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string VendorTypeName { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除);
        /// </summary>
        [DataMember]
        [DisplayName("是否删除(0:未删除;1:已删除);")]
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
