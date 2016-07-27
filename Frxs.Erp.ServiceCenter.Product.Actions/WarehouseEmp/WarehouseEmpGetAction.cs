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
    [ActionName("WarehouseEmp.Get")]
    public class WarehouseEmpGetAction : ActionBase<RequestDto.WarehouseEmpGetRequest, Model.WarehouseEmp>
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.WarehouseEmp> Execute()
        {

            var requestDto = this.RequestDto;

            Model.WarehouseEmp mode = WarehouseEmpBLO.GetModel(requestDto.EmpID);

            return new ActionResult<Model.WarehouseEmp>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = mode
            };
        }
    }
}
