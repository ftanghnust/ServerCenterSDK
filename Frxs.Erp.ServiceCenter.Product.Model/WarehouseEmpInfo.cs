/*********************************************************
 * FRXS 小马哥 2016/4/8 10:57:45
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 仓库用户员工相关信息
    /// </summary>
    [Serializable]
    [DataContract]
    public class WarehouseEmpInfo
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int EmpID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 用户类型(1:拣货员;2:配送员;3:装箱员;4:采购员)
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 密码盐值
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 货位编号
        /// </summary>
        public int ShelfID { get; set; }

        /// <summary>
        /// 货区编号
        /// </summary>
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 网仓编号
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 仓库货区编码
        /// </summary>
        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区名称
        /// </summary>
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 拣货APP最大显示数
        /// </summary>
        public int PickingMaxRecord { get; set; }

        /// <summary>
        /// 是否是组长
        /// </summary>
        public int IsMaster { get; set; }

        /// <summary>
        /// 用户联络手机号码
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否冻结
        /// </summary>
        public int IsFrozen { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public int IsLocked { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 所属仓库
        /// </summary>
        public int WareHouseWID { get;set;}
    }
}
