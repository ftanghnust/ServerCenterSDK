
/*****************************
* Author:CR
*
* Date:2016-03-23
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// SysParams实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SysParams : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        [DisplayName("编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ParamCode { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        [DataMember]
        [DisplayName("参数名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ParamName { get; set; }

        /// <summary>
        /// 参数值(全系统预设值)
        /// </summary>
        [DataMember]
        [DisplayName("参数值(全系统预设值)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ParamValue { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [DisplayName("备注")]

        public string Remark { get; set; }

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