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
    /// 添加 兴盛用户表(B2B,O2O,线下会员) 信息,同时更新相关的门店帐号关联表
    /// 注意，这个会维护XSUser和XSUserShop 这 2张表的信息
    /// </summary>
    [ActionName("XSUser.SaveInfo")]
    public class XSUserSaveInfoAction : ActionBase<XSUserSaveInfoAction.XSUserSaveActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class XSUserSaveActionRequestDto : RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            #region 模型
            /// <summary>
            /// 门店ID
            /// </summary>
            public int ShopID { get; set; }

            /// <summary>
            /// 用户名称
            /// </summary>
            public string XSUserName { get; set; }

            /// <summary>
            /// 用户登录帐户(注册手机号码,第三方登录ID;英数字)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string UserAccount { get; set; }

            /// <summary>
            /// 用户类型(0:普通会员;1:门店人员;)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int UserType { get; set; }

            /// <summary>
            /// 用户联络手机号码(手机号码注册同登录帐号)
            /// </summary>
            public string UserMobile { get; set; }

            /// <summary>
            /// 密码(MD5[pwd]+密码盐值)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string Password { get; set; }

            /// <summary>
            /// 密码盐值
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public string PasswordSalt { get; set; }

            /// <summary>
            /// 创建用户名称
            /// </summary>
            public string CreateUserName { get; set; }

            #endregion

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
            string userAccount = requestDto.UserAccount.Trim();//帐号
            int xSUserID = 0;//准备存入XSUserShop表的帐号ID

            #region 先判断对应的帐号在现有的表中是否已经存在，如果已经存在，不新增
            if (!string.IsNullOrWhiteSpace(userAccount))
            {
                if (XSUserBLO.ExistsAccount(userAccount))
                {
                    Member.Model.XSUser user = XSUserBLO.GetModelByAccount(userAccount);
                    xSUserID = user.XSUserID;//取出帐号ID，用来更新关系映射表
                    bool usSave = UserShopSave(requestDto.ShopID, xSUserID);//更新关系映射表
                    if (usSave == false)
                    {
                        return ErrorActionResult("操作失败:更新帐号门店映射关系失败!", -1);
                    }
                }
                else
                {
                    #region 尝试新增帐号信息

                    #region 赋值给要保存的XSUser对象
                    XSUser xsuser = new XSUser();
                    xsuser.XSUserName = requestDto.XSUserName;
                    xsuser.UserAccount = requestDto.UserAccount;
                    xsuser.UserMobile = requestDto.UserMobile;
                    xsuser.UserType = requestDto.UserType;

                    //丁凡 2016-4-8 修改
                    xsuser.PasswordSalt = Frxs.Platform.Utility.DEncrypt.DEncrypt.GetSalt();
                    xsuser.Password = Frxs.Platform.Utility.DEncrypt.CryptHelper.MD5(Frxs.Platform.Utility.ConstDefinition.PRODUCT_INITIAL_PASSWORD + xsuser.PasswordSalt);

                    //xsuser.PasswordSalt = requestDto.PasswordSalt;       //TODO 加密 加盐 调用方法需找亮哥和蔡总确认 DES3.Encrypt()
                    //xsuser.Password = requestDto.Password;           //TODO 加密调用方法需找亮哥和蔡总确认 DES3.Encrypt()

                    xsuser.LastLoginTime = DateTime.Now;
                    xsuser.LastPasswordChangeTime = DateTime.Now;

                    xsuser.FailedPasswordCount = 0;
                    xsuser.FailedPasswordLockTime = DateTime.Now;

                    xsuser.IsDeleted = 0;
                    xsuser.IsFrozen = 0;
                    xsuser.IsLocked = 0;

                    xsuser.CreateTime = DateTime.Now;
                    xsuser.CreateUserID = requestDto.UserId;
                    xsuser.CreateUserName = requestDto.UserName;

                    xsuser.ModifyTime = DateTime.Now;
                    xsuser.ModifyUserID = requestDto.UserId;
                    xsuser.ModifyUserName = requestDto.UserName;
                    #endregion

                    try
                    {
                        xSUserID = XSUserBLO.Save(xsuser);
                        if (xSUserID > 0)
                        {
                            bool usSave = UserShopSave(requestDto.ShopID, xSUserID);
                            if (usSave == false)
                            {
                                return ErrorActionResult("操作失败:新增帐号门店映射关系失败!", -1);
                            }
                        }
                        else
                        {
                            return this.ErrorActionResult("操作失败:新增帐号失败!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return this.ErrorActionResult("操作失败:" + ex.Message + ", " + ex.StackTrace, -1);
                        //throw;
                    }
                    #endregion
                }
            }
            else
            {
                return this.ErrorActionResult("操作失败:未获取到帐号信息", -1);
            }
            #endregion
            return this.SuccessActionResult("操作成功!", 1);
        }

        #region 更新帐号和门店关系映射表XSUserShop的方法
        /// <summary>
        /// 更新帐号和门店关系映射表XSUserShop
        /// 删除原有的映射关系再建立新的映射关系，确保一个门店只对应一个帐号
        /// </summary>
        /// <param name="shopId">门店ID</param>
        /// <param name="userID">帐号ID</param>
        /// <returns>是否成功</returns>
        public bool UserShopSave(int shopId, int userID)
        {
            bool success = true;
            if (shopId <= 0 || userID <= 0)
            {
                return false;
            }
            #region 先确保有相关帐号，再更新帐号和门店关系映射表XSUserShop
            //if (XSUserShopBLO.ExistsShopID(ShopId)) //检查是否已经有帐号关联关系存在 不需要检测是否存在，根据具体ShopId删除老记录即可
            {
                XSUserShopBLO.DeleteByShopID(shopId);//删除原有的映射关系 没有则不会删除
            }
            Member.Model.XSUserShop UserShop = new Member.Model.XSUserShop();
            UserShop.CreateTime = DateTime.Now;
            UserShop.CreateUserID = this.RequestDto.UserId;
            UserShop.CreateUserName = this.RequestDto.UserName;
            UserShop.XSUserID = userID;
            UserShop.ShopID = shopId;
            int us = XSUserShopBLO.Save(UserShop);
            if (us <= 0)
            {
                success = false;
            }
            #endregion
            return success;
        }
        #endregion
    }
}
