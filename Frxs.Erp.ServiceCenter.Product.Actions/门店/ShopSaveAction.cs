/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/21 15:03:47
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Shop
{
    /// <summary>
    /// 门店信息保存 
    /// 保存时会验证帐号并更新帐号门店关联表 (经过沟通确认，这里的需求暂时不需要采用事务)
    /// </summary>
    [ActionName("Shop.Save")]
    public class ShopSaveAction : ActionBase<ShopSaveRequestDto, int>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns>ActionResult</returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;

            Model.Shop requestModel = requestDto.MapTo<Model.Shop>();

            try
            {
                if (ShopBLO.Exists(requestModel))
                {
                    #region 修改门店信息 更新帐号信息
                    if (ShopBLO.ExistsShopCode(requestModel))
                    {
                        return this.ErrorActionResult("门店编号已经存在！");
                    }
                    else if (ShopBLO.ExistsShopName(requestModel))
                    {
                        return this.ErrorActionResult("门店名称已经存在！");
                    }
                    else
                    {

                        Model.Shop shopToSave = ShopBLO.GetModel(requestModel.ShopID);       //取出数据库中现有的值

                        #region 判断 修改了帐号信息才更新帐号信息和帐号映射表
                        if (shopToSave.ShopAccount.Trim() != requestModel.ShopAccount.Trim())              //对比数据库中的值和上传参数中的值判断帐号是否被修改
                        {
                            bool accountModi = SaveAccount(requestModel.ShopAccount, requestModel.ShopID);
                            if (accountModi == false)
                            {
                                return ErrorActionResult("操作失败! 修改门店帐号信息失败!");//门店帐号更新失败则不会更新门店信息，所以此处不需要采用事务
                            }
                        }
                        #endregion

                        #region 更新门店对象的值
                        shopToSave.ModifyTime = DateTime.Now;
                        shopToSave.ModifyUserID = requestDto.UserId;
                        shopToSave.ModifyUserName = requestDto.UserName;
                        shopToSave.Address = requestDto.Address;
                        shopToSave.AreaPrincipal = requestDto.AreaPrincipal;
                        shopToSave.BankAccount = requestDto.BankAccount;
                        shopToSave.BankAccountName = requestDto.BankAccountName;
                        shopToSave.BankType = requestDto.BankType;
                        shopToSave.CardID = requestDto.CardID;
                        shopToSave.CityID = requestDto.CityID;
                        shopToSave.CreditAmt = requestDto.CreditAmt;
                        shopToSave.CreditLevel = requestDto.CreditLevel;
                        shopToSave.FullAddress = requestDto.FullAddress;
                        shopToSave.Latitude = requestDto.Latitude;
                        shopToSave.LegalPerson = requestDto.LegalPerson;
                        shopToSave.ProvinceID = requestDto.ProvinceID;
                        shopToSave.RegionID = requestDto.RegionID;
                        shopToSave.RegionMaster = requestDto.RegionMaster;
                        shopToSave.SettleTimeType = requestDto.SettleTimeType;
                        shopToSave.SettleType = requestDto.SettleType;
                        shopToSave.LinkMan = requestDto.LinkMan;
                        shopToSave.ShopAccount = requestDto.ShopAccount.Trim();
                        shopToSave.ShopArea = requestDto.ShopArea;
                        shopToSave.ShopCode = requestDto.ShopCode;
                        shopToSave.ShopName = requestDto.ShopName;
                        shopToSave.ShopType = requestDto.ShopType;
                        shopToSave.Telephone = requestDto.Telephone;
                        shopToSave.TotalPoint = requestDto.TotalPoint;
                        shopToSave.WID = requestDto.WID;
                        shopToSave.Longitude = requestDto.Longitude;
                        #endregion

                        ShopBLO.Edit(shopToSave);
                    }
                    #endregion
                }
                else
                {
                    #region 新增门店信息 更新帐号信息

                    if (ShopBLO.ExistsShopCode(requestModel))
                    {
                        return this.ErrorActionResult("门店编号已经存在！");
                    }
                    else if (ShopBLO.ExistsShopName(requestModel))
                    {
                        return this.ErrorActionResult("门店名称已经存在！");
                    }
                    else
                    {
                        #region 添加门店信息,得到 门店shopID
                        requestModel.Status = 1;
                        requestModel.IsDeleted = 0;
                        requestModel.CreateTime = DateTime.Now;
                        requestModel.CreateUserID = this.RequestDto.UserId;
                        requestModel.CreateUserName = this.RequestDto.UserName;
                        requestModel.ModifyTime = DateTime.Now;
                        requestModel.ModifyUserID = this.RequestDto.UserId;
                        requestModel.ModifyUserName = this.RequestDto.UserName;

                        #endregion

                        //开启事务连接
                        var connection = DALFactory.GetLazyInstance<IShopDAO>().GetConnection();
                        connection.Open();
                        var trans = connection.BeginTransaction();

                        try
                        {
                            int shopID = ShopBLO.Save(requestModel, connection, trans); //保存后的ShopID

                            if (shopID > 0)
                            {
                                bool accountAdded = SaveAccount(requestModel.ShopAccount.Trim(), shopID);
                                if (accountAdded == false)
                                {
                                    trans.Rollback();
                                    return ErrorActionResult("门店帐号添加失败!");
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                return this.ErrorActionResult("门店添加失败!");
                            }
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return ErrorActionResult(string.Format("操作失败!发生异常! {0}", ex.Message));
                            //throw;
                        }
                        finally
                        {
                            trans.Dispose();
                            connection.Close();
                            connection.Dispose();
                        }

                    }
                    #endregion
                }

                return this.SuccessActionResult();
            }
            catch (Exception ex)
            {
                return this.ErrorActionResult(ex.Message);
                //throw;
            }

        }

        /// <summary>
        /// 调用会员中心的SDK 保存帐号信息  
        /// 添加 兴盛用户表(B2B,O2O,线下会员) 信息,同时更新相关的门店帐号关联表
        /// </summary>
        /// <param name="shopAccount">帐号</param>
        /// <param name="shopID">门店ID</param>
        /// <returns>是否成功</returns>
        public bool SaveAccount(string shopAccount, int shopID)
        {
            if (shopID <= 0 || string.IsNullOrWhiteSpace(shopAccount))
            {
                return false;
            }

            var workContext = WorkContext.GetErpMemberSDKClient();
            var memberRequest = new Frxs.Erp.ServiceCenter.Member.SDK.Request.FrxsErpMemberXSUserSaveInfoRequest();

            memberRequest.ShopID = shopID;
            memberRequest.UserAccount = shopAccount.Trim();

            memberRequest.CreateUserName = RequestDto.UserName;
            memberRequest.UserId = RequestDto.UserId;

            memberRequest.UserName = RequestDto.UserName;
            memberRequest.UserType = 1;//1表示 门店帐号
            memberRequest.XSUserName = RequestDto.ShopAccount;
            memberRequest.UserMobile = RequestDto.Telephone;

            memberRequest.Password = shopAccount;           //帐号的初始密码是在会员中心的SDK的方法中统一设置的默认值，这里其实可以不传值
            memberRequest.PasswordSalt = shopAccount;       //帐号的密码盐值是在会员中心的SDK中的统一设置的，这里其实可以不传值

            var respMember = workContext.Execute(memberRequest);
            if (respMember == null || respMember.Flag != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
