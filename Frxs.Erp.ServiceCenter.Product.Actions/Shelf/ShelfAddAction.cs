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
    [ActionName("Shelf.Save")]
    public class ShelfSaveAction : ActionBase<RequestDto.ShelfSaveRequest, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            
            var requestDto = this.RequestDto;       
            Frxs.Erp.ServiceCenter.Product.Model.Shelf mode = requestDto.MapTo<Frxs.Erp.ServiceCenter.Product.Model.Shelf>();
            if (ShelfBLO.Exists(mode))
            {
                if (ShelfBLO.ExistsShelfCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "货位编号已经存在！"
                    };
                }
                else
                {
                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;                    
                    ShelfBLO.Edit(mode);
                }
            }
            else
            {
                if (ShelfBLO.ExistsShelfCode(mode))
                {
                    return new ActionResult<int>()
                    {
                        Flag = ActionResultFlag.FAIL,
                        Info = "货位编号已经存在！"
                    };
                }
                else
                {
                    mode.ModifyUserID = requestDto.UserId;
                    mode.ModifyUserName = requestDto.UserName;
                    mode.Status = requestDto.Status;
                    ShelfBLO.Save(mode);
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
