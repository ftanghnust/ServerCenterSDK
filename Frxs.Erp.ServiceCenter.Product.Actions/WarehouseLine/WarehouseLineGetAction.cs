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
    [ActionName("WarehouseLine.Get")]
    public class WarehouseLineGetAction : ActionBase<RequestDto.WarehouseLineGetRequest, Model.WarehouseLine>
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.WarehouseLine> Execute()
        {

            var requestDto = this.RequestDto;

            Model.WarehouseLine mode = WarehouseLineBLO.GetModel(requestDto.LineID);

            if (mode == null)
            {
                return new ActionResult<Model.WarehouseLine>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "查找不到线路信息！"
                    
                };
            }
            return new ActionResult<Model.WarehouseLine>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = mode
            };
        }
    }
}
