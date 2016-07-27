using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ShelfArea
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("ShelfArea.Save")]
    public class ShelfAreaSaveAction : ActionBase<RequestDto.ShelfAreaSaveRequest, int>
    {
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {

            var requestDto = this.RequestDto;
            Frxs.Erp.ServiceCenter.Product.Model.ShelfArea mode = requestDto.MapTo<Frxs.Erp.ServiceCenter.Product.Model.ShelfArea>();
            if (ShelfAreaBLO.Exists(mode))
            {
                if (ShelfAreaBLO.ExistsShelfAreaCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "货区编号或货区名称已经存在！"
                    };
                }
                else
                {
                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;
                    ShelfAreaBLO.Edit(mode);
                }
            }
            else
            {
                if (ShelfAreaBLO.ExistsShelfAreaCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "货区编号或货区名称已经存在！"
                    };
                }
                else
                {
                    mode.CreateUserID = requestDto.UserId;
                    mode.CreateUserName = requestDto.UserName;
                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;
                    ShelfAreaBLO.Save(mode);
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
