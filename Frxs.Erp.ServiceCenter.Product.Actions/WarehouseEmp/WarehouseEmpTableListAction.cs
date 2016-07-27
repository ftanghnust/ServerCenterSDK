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

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [ActionName("WarehouseEmp.TableList")]
    public class WarehouseEmpTableListAction : ActionBase<RequestDto.WarehouseEmpTableListRequest, ActionResultPagerData<Model.WarehouseEmp>>
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.WarehouseEmp>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.WarehouseEmp> page = new PageListBySql<Model.WarehouseEmp>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();           
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.WarehouseEmp> models = WarehouseEmpBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.WarehouseEmp>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
   
}
