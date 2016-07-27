/*********************************************************
 * FRXS 小马哥 2016/4/8 15:11:40
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 拣货接口-修改密码
    /// </summary>
    [ActionName("PickingUpdatePwd")]
    public class PickingUpdatePwdAction : ActionBase<PickingUpdatePwdAction.PickingUpdatePwdActionRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 接口调用上传参数
        /// </summary>
        public class PickingUpdatePwdActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 登录名
            /// </summary>
            [Required]
            public string UserAccount { get; set; }

            /// <summary>
            /// 旧密码
            /// </summary>
            [Required]
            public string OldUserPwd { get; set; }

            /// <summary>
            /// 新密码
            /// </summary>
            [Required]
            public string NewUserPwd { get; set; }

            /// <summary>
            /// 用户类型
            /// </summary>
            [Required]
            public string UserType { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            string strMsg = string.Empty;
            //获取登录帐号
            string strUserAccount = this.RequestDto.UserAccount;
            //获取新密码
            string strNewUserPwd = this.RequestDto.NewUserPwd;
            //获取旧密码
            string strOldUserPwd = this.RequestDto.OldUserPwd;
            //获取用户信息
            Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmp model = WarehouseEmpBLO.PickingGetModelByAccount(strUserAccount, Utils.StrToInt(RequestDto.UserType, 0));
            if (model == null)
            {
                strMsg = "没有此用户信息";
                return base.ErrorActionResult(strMsg);
            }
            //处理旧密码加密
            string strToPwd = strOldUserPwd + model.PasswordSalt;
            string strMD5ToPwd = Utils.MD5(strToPwd);
            
            if (!strMD5ToPwd.ToUpper().Equals(model.Password.ToUpper()))
            {
                strMsg = "原始密码错误";
                return base.ErrorActionResult(strMsg);
            }
            //设置新密码的值
            model.Password = Utils.MD5(strNewUserPwd + model.PasswordSalt);
            model.ModifyUserID = this.RequestDto.UserId;
            model.ModifyUserName = this.RequestDto.UserName;
            int result = WarehouseEmpBLO.EditResetPassWord(model);
            if (result > 0)
            {
                strMsg = "密码修改成功";
                return base.SuccessActionResult();
            }
            else
            {
                strMsg = "密码修改失败";
                return base.ErrorActionResult(strMsg);
            }
        }
    }
}
