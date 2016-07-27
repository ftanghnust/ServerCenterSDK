/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/22 14:28:52
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
    /// 兴盛用户表(B2B,O2O,线下会员)
    /// 优先根据帐号查询，也可以根据用户ID查询
    /// </summary>
    [ActionName("XSUser.Get")]
    public class XSUserGetAction : ActionBase<XSUserGetAction.XSUserGetActionRequestDto, XSUser>
    {
        /// <summary>
        /// 获取用户信息XSUser 上送的参数对象
        /// </summary>
        public class XSUserGetActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {

            /// <summary>
            /// 用户ID
            /// </summary>
            public int? XSUserID { get; set; }

            /// <summary>
            /// 用户帐号 优先根据帐号查询
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
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<XSUser> Execute()
        {
            var requestDto = this.RequestDto;
            Model.XSUser mode = null;
            
            if(!string.IsNullOrWhiteSpace(requestDto.UserAccount))
            {
                mode = XSUserBLO.GetModelByAccount(requestDto.UserAccount);
            }
            else if ((requestDto.XSUserID.HasValue))
            {
                mode = XSUserBLO.GetModel(requestDto.XSUserID.Value);                
            }
            return this.SuccessActionResult(mode);
            
        }
    }
}
