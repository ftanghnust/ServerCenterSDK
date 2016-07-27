using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WarehouseLine.Save")]
    public class WarehouseLineSaveAction : ActionBase<RequestDto.WarehouseLineSaveRequest, int>
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            Frxs.Erp.ServiceCenter.Product.Model.WarehouseLine mode = requestDto.MapTo<Frxs.Erp.ServiceCenter.Product.Model.WarehouseLine>();
            if (WarehouseLineBLO.Exists(mode))
            {
                if (WarehouseLineBLO.ExistsWarehouseLineCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "线路编号或名称已经存在！"
                    };
                }
                else
                {
                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;
                    WarehouseLineBLO.Edit(mode);
                    WarehouseLineBLO.DeleteCache(mode.LineID);
                }
            }
            else
            {
                if (WarehouseLineBLO.ExistsWarehouseLineCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "线路编号或名称已经存在！"
                    };
                }
                else
                {
                   
                    mode.IsLocked = 0;
                    mode.IsDeleted = 0;                   
                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;
                    mode.CreateUserID = requestDto.UserId;
                    mode.CreateUserName = requestDto.UserName;
                    WarehouseLineBLO.Save(mode);
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
