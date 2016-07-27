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
    /// 优先根据帐号查询，也可以根据用户ID查询
    /// </summary>
    [ActionName("XSUser.Login")]
    public class UserLoginAction : ActionBase<UserLoginAction.XSUserLoginActionRequestDto, ResponseDto.XSUserLoginResponseDto>
    {
        /// <summary>
        /// 获取用户信息XSUser 上送的参数对象
        /// </summary>
        public class XSUserLoginActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 用户登录帐户(注册手机号码,第三方登录ID;英数字)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string UserAccount { get; set; }

            /// <summary>
            /// 密码(MD5[pwd]+密码盐值)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string Password { get; set; }

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
        public override ActionResult<ResponseDto.XSUserLoginResponseDto> Execute()
        {
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();
            //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
            //    (
            //        new Platform.Utility.Log.NormalLog
            //        {
            //            LogTime = DateTime.Now,
            //            LogContent = "计时开始",
            //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
            //            LogOperation = "获取请求参数开始",
            //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
            //        }
            //    );

            var requestDto = this.RequestDto;
            string userAccount = requestDto.UserAccount.Trim();//帐号
            Member.Model.XSUser user = new XSUser();
            IList<Frxs.Erp.ServiceCenter.Member.Model.XSUserShop> shops = null;

            //sw.Stop();
            //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
            //    (
            //        new Platform.Utility.Log.NormalLog
            //        {
            //            LogTime = DateTime.Now,
            //            LogContent = string.Format("计时结束，耗时{0}毫秒", sw.ElapsedMilliseconds),
            //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
            //            LogOperation = "获取请求参数结束",
            //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
            //        }
            //    );

            if (!string.IsNullOrWhiteSpace(userAccount))
            {
                //sw.Reset();
                //sw.Start();
                //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
                //    (
                //        new Platform.Utility.Log.NormalLog
                //        {
                //            LogTime = DateTime.Now,
                //            LogContent = "计时开始",
                //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
                //            LogOperation = "验证账户是否存在开始",
                //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
                //        }
                //    );
                bool isExistsUser = XSUserBLO.ExistsAccount(userAccount);
                //sw.Stop();
                //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
                //    (
                //        new Platform.Utility.Log.NormalLog
                //        {
                //            LogTime = DateTime.Now,
                //            LogContent = string.Format("计时结束，耗时{0}毫秒", sw.ElapsedMilliseconds),
                //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
                //            LogOperation = "验证账户是否存在结束",
                //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
                //        }
                //    );

                if (isExistsUser)
                {
                    //sw.Reset();
                    //sw.Start();
                    //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
                    //    (
                    //        new Platform.Utility.Log.NormalLog
                    //        {
                    //            LogTime = DateTime.Now,
                    //            LogContent = "计时开始",
                    //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
                    //            LogOperation = "获取账户信息开始",
                    //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
                    //        }
                    //    );
                    user = XSUserBLO.GetModelByAccount(userAccount);
                    //sw.Stop();
                    //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
                    //    (
                    //        new Platform.Utility.Log.NormalLog
                    //        {
                    //            LogTime = DateTime.Now,
                    //            LogContent = string.Format("计时结束，耗时{0}毫秒", sw.ElapsedMilliseconds),
                    //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
                    //            LogOperation = "获取账户信息结束",
                    //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
                    //        }
                    //    );

                    //sw.Reset();
                    //sw.Start();
                    //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
                    //    (
                    //        new Platform.Utility.Log.NormalLog
                    //        {
                    //            LogTime = DateTime.Now,
                    //            LogContent = "计时开始",
                    //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
                    //            LogOperation = "密码校验开始",
                    //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
                    //        }
                    //    );
                    bool isPass = user.Password == MD5.Encrypt(requestDto.Password + user.PasswordSalt);
                    //sw.Stop();
                    //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
                    //    (
                    //        new Platform.Utility.Log.NormalLog
                    //        {
                    //            LogTime = DateTime.Now,
                    //            LogContent = string.Format("计时结束，耗时{0}毫秒", sw.ElapsedMilliseconds),
                    //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
                    //            LogOperation = "密码校验结束",
                    //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
                    //        }
                    //    );

                    if (isPass)
                    {
                        //sw.Reset();
                        //sw.Start();
                        //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
                        //    (
                        //        new Platform.Utility.Log.NormalLog
                        //        {
                        //            LogTime = DateTime.Now,
                        //            LogContent = "计时开始",
                        //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
                        //            LogOperation = "获取用户门店信息开始",
                        //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
                        //        }
                        //    );
                        Dictionary<string, object> conditionDict = new Dictionary<string, object>();
                        conditionDict.Add("XSUserID", user.XSUserID);
                        shops = XSUserShopBLO.GetList(conditionDict);
                        //sw.Stop();
                        //Frxs.Platform.Utility.Log.Logger.GetInstance().DebugLog
                        //    (
                        //        new Platform.Utility.Log.NormalLog
                        //        {
                        //            LogTime = DateTime.Now,
                        //            LogContent = string.Format("计时结束，耗时{0}毫秒", sw.ElapsedMilliseconds),
                        //            LogSource = "Frxs.Erp.ServiceCenter.Member.Actions.UserLoginAction.Execute",
                        //            LogOperation = "获取用户门店信息结束",
                        //            LogIp = this.RequestContext.HttpContext.Request.GetClientIp()
                        //        }
                        //    );
                    }
                    else
                    {
                        return new ActionResult<ResponseDto.XSUserLoginResponseDto>()
                        {
                            Flag = ActionResultFlag.FAIL,
                            Info = "用户名或密码错误！"
                        };
                    }
                }
                else
                {
                    return new ActionResult<ResponseDto.XSUserLoginResponseDto>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "账户不存在！"
                    };
                }


            }

            return new ActionResult<ResponseDto.XSUserLoginResponseDto>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = new ResponseDto.XSUserLoginResponseDto() { model = user, shops = shops }
            };
        }
    }
}
