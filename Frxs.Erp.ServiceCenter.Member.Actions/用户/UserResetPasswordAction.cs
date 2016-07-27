/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/6 11:29:02
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Member.Model;
using Frxs.Erp.ServiceCenter.Member.BLL;

namespace Frxs.Erp.ServiceCenter.Member.Actions
{
    /// <summary>
    /// 用户密码重置接口
    /// </summary>
    [ActionName("User.ResetPassword")]
    public class UserResetPasswordAction : ActionBase<UserResetPasswordAction.UserResetPasswordActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class UserResetPasswordActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 用户帐号
            /// </summary>
            public string UserAccount { get; set; }

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
        /// 下送的数据
        /// </summary>
        public class UserResetPasswordActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            Member.Model.XSUser user = new XSUser();

            user.UserAccount = requestDto.UserAccount;

            if (XSUserBLO.ExistsAccount(requestDto.UserAccount))
            {
                user = XSUserBLO.GetModelByAccount(requestDto.UserAccount);
                user.PasswordSalt = Frxs.Platform.Utility.DEncrypt.DEncrypt.GetSalt();
                user.Password = Frxs.Platform.Utility.DEncrypt.CryptHelper.MD5(Frxs.Platform.Utility.ConstDefinition.PRODUCT_INITIAL_PASSWORD + user.PasswordSalt);
                
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
