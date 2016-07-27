/*********************************************************
 * FRXS 小马哥 2016/6/6 16:00:10
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 判断登录用户的货位是否存在
    /// </summary>
    [ActionName("CheckShelfOfLogin")]
    public class CheckShelfOfLoginAction : ActionBase<CheckShelfOfLoginAction.CheckShelfOfLoginActionRequestDto, bool>
    {
        /// <summary>
        /// 接口调用上传参数
        /// </summary>
        public class CheckShelfOfLoginActionRequestDto : RequestDtoBase
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
            /// 货位编号
            /// </summary>
            [Required]
            public string ShelfCode { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<bool> Execute()
        {
            string strMsg = string.Empty;
            //获取账户
            string strUserAccount = this.RequestDto.UserAccount;
            //获取密码
            string strUserPwd = this.RequestDto.UserPwd;
            //获取货位编号
            string strShelfCode = this.RequestDto.ShelfCode;
            WarehouseEmpInfo modelWarehouseEmp = WarehouseEmpBLO.PickingLogin(strUserAccount, Utils.StrToInt(1, 0));
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
            bool result = WarehouseEmpBLO.CheckShelfOfLogin(modelWarehouseEmp.EmpID, strShelfCode);
            if (result)
            {
                return SuccessActionResult(true);
            }
            else
            {
                strMsg = "该帐号没有此货位信息";
                return ErrorActionResult(strMsg);
            }
        }
    }
}
