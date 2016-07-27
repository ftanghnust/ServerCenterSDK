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
    [ActionName("ShelfArea.Get")]
    public class ShelfAreaGetAction : ActionBase<RequestDto.ShelfAreaGetRequest, Model.ShelfArea>
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.ShelfArea> Execute()
        {

            var requestDto = this.RequestDto;

            Model.ShelfArea mode = ShelfAreaBLO.GetModel(requestDto.ShelfAreaID);

            return new ActionResult<Model.ShelfArea>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = mode
            };
        }
    }
}
