
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
    /// 仓库系统参数表SysParamsWH实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SysParamsWH : BaseModel
    {

        #region 模型
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        [DisplayName("编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int ID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [DataMember]
        [DisplayName("仓库ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

        /// <summary>
        /// 参数编号
        /// </summary>
        [DataMember]
        [DisplayName("参数编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ParamCode { get; set; }

        /// <summary>
        /// 参数值(全系统预设值)
        /// </summary>
        [DataMember]
        [DisplayName("参数值(全系统预设值)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ParamValue { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        [DisplayName("修改时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 修改用户ID
        /// </summary>
        [DataMember]
        [DisplayName("修改用户ID")]

        public int ModifyUserID { get; set; }

        /// <summary>
        /// 修改用户名称
        /// </summary>
        [DataMember]
        [DisplayName("修改用户名称")]

        public string ModifyUserName { get; set; }

        #endregion
    }
}