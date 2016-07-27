
/*****************************
* Author:CR
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
    /// 仓库用户员工表WarehouseEmp实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WarehouseEmp : BaseModel
    {

        #region 模型
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        [DisplayName("用户编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int EmpID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [DataMember]
        [DisplayName("用户名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string EmpName { get; set; }

        /// <summary>
        /// 用户登录帐户(手机号码;员工编号;唯一[不包括删除的])
        /// </summary>
        [DataMember]
        [DisplayName("用户登录帐户(手机号码;员工编号;唯一[不包括删除的])")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string UserAccount { get; set; }

        /// <summary>
        /// 用户类型(1:拣货员;2:配送员;3:装箱员)
        /// </summary>
        [DataMember]
        [DisplayName("用户类型(1:拣货员;2:配送员;3:装箱员)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int UserType { get; set; }

        /// <summary>
        /// 是否为组长(0:不是;1:是)
        /// </summary>
        [DataMember]
        [DisplayName("是否为组长(0:不是;1:是)")]

        public int IsMaster { get; set; }

        /// <summary>
        /// 所属仓库(Warehouse.WID)
        /// </summary>
        [DataMember]
        [DisplayName("所属仓库(Warehouse.WID)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int WID { get; set; }

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

        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后修改密码时间
        /// </summary>
        [DataMember]
        [DisplayName("最后修改密码时间")]

        public DateTime LastPasswordChangeTime { get; set; }

        /// <summary>
        /// 密码错误次数(连续6次后锁定;登录后归0)
        /// </summary>
        [DataMember]
        [DisplayName("密码错误次数(连续6次后锁定;登录后归0)")]

        public int FailedPasswordCount { get; set; }

        /// <summary>
        /// 密码错误锁定时间
        /// </summary>
        [DataMember]
        [DisplayName("密码错误锁定时间")]
        [Required(ErrorMessage = "{0}不能为空")]
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
        [Required(ErrorMessage = "{0}不能为空")]
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

    /// <summary>
    /// 查询显示实体
    /// </summary>
    public partial class WarehouseEmp : BaseModel
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        [DisplayName("仓库名称")]
        public string WName { get; set; }
      
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        [DisplayName("状态")]
        public string StatusStr { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [DataMember]
        [DisplayName("职位")]
        public string UserTypeStr { get; set; }
    }

    /// <summary>
    /// 库用户拣货区表WarehouseEmpShelf类使用的新增实体
    /// </summary>
    public partial class WarehouseEmp : BaseModel
    {
        /// <summary>
        /// 货区名称
        /// </summary>
        [DataMember]
        [DisplayName("货区名称")]        
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 货位数量
        /// </summary>
        [DataMember]
        [DisplayName("货位数量")]
        public int ShelfNum { get; set; }

        /// <summary>
        /// 货区ID
        /// </summary>
        [DataMember]
        [DisplayName("货区ID")]
        public string ShelfAreaID { get; set; }
    }

    /// <summary>
    /// 根据商品编号获取拣货人员信息新增实体
    /// </summary>
    public partial class WarehouseEmp : BaseModel
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductID { get; set; }
    }
}