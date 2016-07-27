
/*****************************
* Author:CR
*
* Date:2016-03-22
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Frxs.Erp.ServiceCenter.Member.Model
{
    /// <summary>
    /// 兴盛用户表(B2B,O2O,线下会员)XSUser实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class XSUser : BaseModel
    {

        #region 模型
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        [DisplayName("用户编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int XSUserID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [DataMember]
        [DisplayName("用户名称")]

        public string XSUserName { get; set; }

        /// <summary>
        /// 用户登录帐户(注册手机号码,第三方登录ID;英数字)
        /// </summary>
        [DataMember]
        [DisplayName("用户登录帐户(注册手机号码,第三方登录ID;英数字)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string UserAccount { get; set; }

        /// <summary>
        /// 用户类型(0:普通会员;1:门店人员;)
        /// </summary>
        [DataMember]
        [DisplayName("用户类型(0:普通会员;1:门店人员;)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int UserType { get; set; }

        /// <summary>
        /// 用户联络手机号码(手机号码注册同登录帐号)
        /// </summary>
        [DataMember]
        [DisplayName("用户联络手机号码(手机号码注册同登录帐号)")]

        public string UserMobile { get; set; }

        /// <summary>
        /// 密码(MD5[pwd]+密码盐值)
        /// </summary>
        [DataMember]
        [DisplayName("密码(MD5[pwd]+密码盐值)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Password { get; set; }

        /// <summary>
        /// 密码盐值
        /// </summary>
        [DataMember]
        [DisplayName("密码盐值")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 是否冻结(0:未冻结;1:已冻结)
        /// </summary>
        [DataMember]
        [DisplayName("是否冻结(0:未冻结;1:已冻结)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsFrozen { get; set; }

        /// <summary>
        /// 是否锁定(0:未锁定;1:已锁定)
        /// </summary>
        [DataMember]
        [DisplayName("是否锁定(0:未锁定;1:已锁定)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsLocked { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除)
        /// </summary>
        [DataMember]
        [DisplayName("是否删除(0:未删除;1:已删除)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [DataMember]
        [DisplayName("最后登录时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后修改密码时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改密码时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime LastPasswordChangeTime { get; set; }

        /// <summary>
        /// 密码错误次数(连续6次后锁定;登录后归0)
        /// </summary>
        [DataMember]
        [DisplayName("密码错误次数(连续6次后锁定;登录后归0)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int FailedPasswordCount { get; set; }

        /// <summary>
        /// 密码错误锁定时间
        /// </summary>
        [DataMember]
        [DisplayName("密码错误锁定时间")]

        public DateTime FailedPasswordLockTime { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        [DisplayName("创建日期")]
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
        [Required(ErrorMessage = "{0}不能为空")]
        public string ModifyUserName { get; set; }

        #endregion
    }

    public partial class XSUser :BaseModel
    {


    }
}