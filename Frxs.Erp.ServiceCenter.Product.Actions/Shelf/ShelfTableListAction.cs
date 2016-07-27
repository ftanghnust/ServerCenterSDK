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
    [ActionName("Shelf.TableList")]
    public class ShelfTableListAction : ActionBase<RequestDto.ShelfTableListRequest, ActionResultPagerData<Model.Shelf>>
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.Shelf>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.Shelf> page = new PageListBySql<Model.Shelf>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();           
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.Shelf> models = ShelfBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.Shelf>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }

}
