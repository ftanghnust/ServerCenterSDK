using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    class WarehouseEmpRequest
    {
    }

    /// <summary>
    ///  WarehouseEmp.TableList
    /// </summary>
    public class  WarehouseEmpTableListRequest : PageListRequestDto
    {
        /// <summary>
        /// 用户名称
        /// </summary>       
        public string EmpName { get; set; }

        /// <summary>
        /// 用户类型(1:拣货员;2:配送员;3:装箱员)
        /// </summary>        
        public string UserType { get; set; }

        /// <summary>
        /// 用户登录帐户(手机号码;员工编号;唯一[不包括删除的])
        /// </summary>       
        public string UserAccount { get; set; }

        /// <summary>
        /// 是否冻结(0:未冻结;1:已冻结)
        /// </summary>        
        public string IsFrozen { get; set; }

        /// <summary>
        /// 所属仓库(Warehouse.WID)
        /// </summary>        
        public int WID { get; set; }

    }

    /// <summary>
    ///  WarehouseEmp.Save
    /// </summary>
    public class  WarehouseEmpSaveRequest : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// 用户编号
        /// </summary>       
        public int EmpID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>       
        public string EmpName { get; set; }

        /// <summary>
        /// 用户登录帐户(手机号码;员工编号;唯一[不包括删除的])
        /// </summary>       
        public string UserAccount { get; set; }

        /// <summary>
        /// 用户类型(1:拣货员;2:配送员;3:装箱员)
        /// </summary>        
        public int UserType { get; set; }

        /// <summary>
        /// 是否为组长(0:不是;1:是)
        /// </summary>        
        public int IsMaster { get; set; }

        /// <summary>
        /// 所属仓库(Warehouse.WID)
        /// </summary>        
        public int WID { get; set; }

        /// <summary>
        /// 用户联络手机号码(手机号码注册同登录帐号)
        /// </summary>        
        public string UserMobile { get; set; }

        /// <summary>
        /// 密码(MD5[pwd]+密码盐值)
        /// </summary>        
        public string Password { get; set; }

        /// <summary>
        /// 密码盐值
        /// </summary>        
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 是否冻结(0:未冻结;1:已冻结)
        /// </summary>        
        public int IsFrozen { get; set; }

        /// <summary>
        /// 是否锁定(0:未锁定;1:已锁定)
        /// </summary>        
        public int IsLocked { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除)
        /// </summary>        
        public int IsDeleted { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>        
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后修改密码时间
        /// </summary>        
        public DateTime LastPasswordChangeTime { get; set; }

        /// <summary>
        /// 密码错误次数(连续6次后锁定;登录后归0)
        /// </summary>        
        public int FailedPasswordCount { get; set; }

        /// <summary>
        /// 密码错误锁定时间
        /// </summary>        
        public DateTime FailedPasswordLockTime { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>        
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>        
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>        
        public string CreateUserName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>        
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>        
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>        
        public string ModifyUserName { get; set; }

        #endregion

    }

    /// <summary>
    ///  WarehouseEmp.Del
    /// </summary>
    public class  WarehouseEmpDelRequest : RequestDtoBase
    {
        /// <summary>
        /// 用户编号
        /// </summary>       
        public string EmpID { get; set; }      

    }

    /// <summary>
    ///  WarehouseEmp.Get
    /// </summary>
    public class  WarehouseEmpGetRequest : RequestDtoBase
    {
        /// <summary>
        /// 用户编号
        /// </summary>       
        public int EmpID { get; set; }

    }

    /// <summary>
    ///  WarehouseEmp.Get
    /// </summary>
    public class WarehouseEmpIsFrozenRequest : RequestDtoBase
    {
        /// <summary>
        /// 用户编号
        /// </summary>       
        public string EmpID { get; set; }

        /// <summary>
        /// 是否冻结(0:未冻结;1:已冻结)
        /// </summary>       
        public int IsFrozen { get; set; }

    }
}
