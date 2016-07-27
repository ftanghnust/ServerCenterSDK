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
    [ActionName("ShelfArea.TableList")]
    public class ShelfAreaTableListAction : ActionBase<RequestDto.ShelfAreaTableListRequest, ActionResultPagerData<Model.ShelfArea>>
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.ShelfArea>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.ShelfArea> page = new PageListBySql<Model.ShelfArea>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();           
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.ShelfArea> models = ShelfAreaBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.ShelfArea>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
   
}
