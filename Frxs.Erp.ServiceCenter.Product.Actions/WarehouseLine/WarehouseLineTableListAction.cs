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
    [ActionName("WarehouseLine.TableList")]
    public class WarehouseLineTableListAction : ActionBase<RequestDto.WarehouseLineTableListRequest, ActionResultPagerData<Model.WarehouseLine>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.WarehouseLine>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.WarehouseLine> page = new PageListBySql<Model.WarehouseLine>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.WarehouseLine> models = WarehouseLineBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.WarehouseLine>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }
    }
}
