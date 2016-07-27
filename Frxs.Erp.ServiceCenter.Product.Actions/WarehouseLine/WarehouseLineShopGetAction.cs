using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.WarehouseLine
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WarehouseLine.Shop.Get")]
    public class WarehouseLineShopGetAction : ActionBase<RequestDto.WarehouseLineShopGetRequest, Model.WarehouseLine>
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.WarehouseLine> Execute()
        {

            var requestDto = this.RequestDto;

            Model.WarehouseLine mode = WarehouseLineBLO.GetShopModel(requestDto.ShopID);

            return new ActionResult<Model.WarehouseLine>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = mode
            };
        }
    }
}
