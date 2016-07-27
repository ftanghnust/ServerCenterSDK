/*********************************************************
 * FRXS 小马哥 2016/4/8 10:04:14
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 拣货接口-登录
    /// </summary>
    [ActionName("PickingLogin")]
    public class PickingLoginAction : ActionBase<PickingLoginAction.PickingLoginActionRequestDto, PickingLoginAction.PickingLoginActionResponseDto>
    {
        /// <summary>
        /// 接口调用上传参数
        /// </summary>
        public class PickingLoginActionRequestDto : RequestDtoBase //,IRequiredUserIdAndUserName  如果强制接口需要上送操作用户信息可以直接实现次空接口即可
        {
            /// <summary>
            /// 登录名
            /// </summary>
            [Required]
            public string UserAccount { get; set; }

            /// <summary>
            /// 密码
            /// </summary>
            [Required]
            public string UserPwd { get; set; }

            /// <summary>
            /// 用户类型(1:拣货员;2:配送员;3:装箱员;4:采购员)
            /// </summary>
            [Required]
            public string UserType { get; set; }
        }

        /// <summary>
        /// 接口调用返回参数
        /// </summary>
        public class PickingLoginActionResponseDto : ResponseDtoBase
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
            /// 所属仓库编号
            /// </summary>
            public int WarehouseWID { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<PickingLoginActionResponseDto> Execute()
        {
            string strMsg = string.Empty;
            //获取账户
            string strUserAccount = this.RequestDto.UserAccount;
            //获取密码
            string strUserPwd = this.RequestDto.UserPwd;
            string strUserType = this.RequestDto.UserType;
            WarehouseEmpInfo modelWarehouseEmp = WarehouseEmpBLO.PickingLogin(strUserAccount, Utils.StrToInt(strUserType, 0));
            if (modelWarehouseEmp == null)
            {
                strMsg = "没有此用户信息";
                return base.ErrorActionResult(strMsg);
            }
            if (modelWarehouseEmp.IsDeleted == 1)
            {
                strMsg = "此帐号已删除";
                return base.ErrorActionResult(strMsg);
            }
            if (modelWarehouseEmp.IsFrozen == 1)
            {
                strMsg = "此帐号已冻结";
                return base.ErrorActionResult(strMsg);
            }
            if (modelWarehouseEmp.IsLocked == 1)
            {
                strMsg = "此帐号已锁定";
                return base.ErrorActionResult(strMsg);
            }
            string strToPwd = strUserPwd + modelWarehouseEmp.PasswordSalt;
            string strMD5ToPwd = Utils.MD5(strToPwd);//MD5加密后密码
            if (!strMD5ToPwd.ToUpper().Equals(modelWarehouseEmp.Password.ToUpper()))
            {
                strMsg = "密码输入错误";
                return base.ErrorActionResult(strMsg);
            }
            strMsg = "登录成功";
            PickingLoginActionResponseDto modelPickingLoginResponse = new PickingLoginActionResponseDto();
            modelPickingLoginResponse.EmpID = modelWarehouseEmp.EmpID;
            modelPickingLoginResponse.EmpName = modelWarehouseEmp.EmpName;
            modelPickingLoginResponse.UserType = modelWarehouseEmp.UserType;
            modelPickingLoginResponse.ShelfAreaID = modelWarehouseEmp.ShelfAreaID;
            modelPickingLoginResponse.WID = modelWarehouseEmp.WID;
            modelPickingLoginResponse.ShelfAreaCode = modelWarehouseEmp.ShelfAreaCode;
            modelPickingLoginResponse.ShelfAreaName = modelWarehouseEmp.ShelfAreaName;
            modelPickingLoginResponse.PickingMaxRecord = modelWarehouseEmp.PickingMaxRecord;
            modelPickingLoginResponse.IsMaster = modelWarehouseEmp.IsMaster;
            modelPickingLoginResponse.UserMobile = modelWarehouseEmp.UserMobile;
            modelPickingLoginResponse.Remark = modelWarehouseEmp.Remark;
            modelPickingLoginResponse.WarehouseWID = modelWarehouseEmp.WareHouseWID;
            return base.SuccessActionResult(strMsg, modelPickingLoginResponse);
        }
    }
}
