using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Shelf
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("Shelf.Get")]
    public class ShelfGetAction : ActionBase<RequestDto.ShelfGetRequest, Model.Shelf>
    {

       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.Shelf> Execute()
        {

            var requestDto = this.RequestDto;

            Model.Shelf mode = ShelfBLO.GetModel(requestDto.ShelfID);

            return new ActionResult<Model.Shelf>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data=mode
            };
        }
    }
}
