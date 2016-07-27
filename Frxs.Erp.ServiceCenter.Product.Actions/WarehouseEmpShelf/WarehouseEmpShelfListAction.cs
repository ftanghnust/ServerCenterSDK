using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Json;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WarehouseEmpShelf.List")]
    public class WarehouseEmpShelfListAction : ActionBase<RequestDto.WarehouseEmpShelfListGetRequest, IList<Model.WarehouseEmpShelf>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<Model.WarehouseEmpShelf>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.WarehouseEmpShelf> page = new PageListBySql<Model.WarehouseEmpShelf>(
                        1,
                        10000);
            page.OrderFields = "id";
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            IList<Model.WarehouseEmpShelf> models = WarehouseEmpShelfBLO.GetPageShelfList(page, requestDtoDict).ItemList;

            return this.SuccessActionResult(models);
        }
    }
}
