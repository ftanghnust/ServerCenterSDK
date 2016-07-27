/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/24 10:58:01
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Member.Model;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Member.BLL;

namespace Frxs.Erp.ServiceCenter.Member.Actions
{
    /// <summary>
    /// 兴盛用户表(B2B,O2O,线下会员)
    /// 修改密码
    /// </summary>
    [ActionName("XSUser.EditPassword")]
    public class UserEditPasswordAction : ActionBase<UserEditPasswordAction.UserEditPasswordActionRequestDto, int>
    {
         /// <summary>
        /// 获取用户信息XSUser 上送的参数对象
        /// </summary>
        public class UserEditPasswordActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 旧密码
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string OldPassword { get; set; }

            /// <summary>
            /// 新密码
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string NewPassword { get; set; }

            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }
        }

         /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            Member.Model.XSUser user = new XSUser();

            user.XSUserID = requestDto.UserId;
            if (XSUserBLO.Exists(user))
            {
                user = XSUserBLO.GetModel(requestDto.UserId);
                if (user.Password == MD5.Encrypt(requestDto.OldPassword + user.PasswordSalt))//TODO 加密 加盐 验证
                {
                    user.Password = Frxs.Platform.Utility.DEncrypt.CryptHelper.MD5(requestDto.NewPassword + user.PasswordSalt);

                    user.ModifyTime = DateTime.Now;
                    user.ModifyUserID = requestDto.UserId;
                    user.ModifyUserName = requestDto.UserName;
                    XSUserBLO.Edit(user);
                }
                else
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "原始密码错误！"
                    };
                }
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "账户不存在！"
                };
            }




            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK"                
            };
        }
    }
}
