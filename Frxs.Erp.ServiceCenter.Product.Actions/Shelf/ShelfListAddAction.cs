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
    [ActionName("Shelf.List.Save")]
    public class ShelfListSaveAction : ActionBase<RequestDto.ShelfListSaveRequest, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            
            var requestDto = this.RequestDto;       
            var modeList = requestDto.ShelfList;

            string message = ShelfBLO.SaveList(modeList, requestDto.UserId, requestDto.UserName);

            if (message == String.Empty)
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "OK"
                };
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = message
                };
            }
        }
    }
}
