using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.WarehouseEmp
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WarehouseEmp.Save")]
    public class WarehouseEmpSaveAction : ActionBase<RequestDto.WarehouseEmpSaveRequest, int>
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmp mode = requestDto.MapTo<Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmp>();
            if (WarehouseEmpBLO.Exists(mode))
            {
                if (WarehouseEmpBLO.ExistsWarehouseEmpCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "账号已经存在！"
                    };
                }
                else
                {
                    Frxs.Erp.ServiceCenter.Product.Model.WarehouseEmp modelOld = WarehouseEmpBLO.GetModel(mode.EmpID);

                    if (modelOld.UserType != mode.UserType)
                    {
                        var result = WarehouseEmpBLO.ExistsWarehouseEmp(mode.EmpID, modelOld.UserType);

                        if (!result.IsNullOrEmpty())
                        {

                            return new ActionResult<int>()
                            {
                                Flag = ActionResultFlag.FAIL,
                                Info = modelOld.EmpName + "已经在" + result + "绑定数据，请清除绑定后再操作！"

                            };
                        }
                    }

                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;
                    WarehouseEmpBLO.Edit(mode);
                    WarehouseEmpBLO.DeleteCache(mode.EmpID);
                }
            }
            else
            {
                if (WarehouseEmpBLO.ExistsWarehouseEmpCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "账号已经存在！"
                    };
                }
                else
                {
                    mode.IsFrozen = 0;
                    mode.IsLocked = 0;
                    mode.IsDeleted = 0;
                    mode.PasswordSalt = Frxs.Platform.Utility.DEncrypt.DEncrypt.GetSalt();
                    mode.Password = Frxs.Platform.Utility.DEncrypt.CryptHelper.MD5(Frxs.Platform.Utility.ConstDefinition.PRODUCT_INITIAL_PASSWORD + mode.PasswordSalt);
                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;
                    mode.CreateUserID = requestDto.UserId;
                    mode.CreateUserName = requestDto.UserName;
                    WarehouseEmpBLO.Save(mode);
                }
            }


            return new ActionResult<int>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK"
            };
        }
    }
}
