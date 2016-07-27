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
    [ActionName("WStationNumber.TableList")]
    public class WStationNumberTableListAction : ActionBase<RequestDto.WStationNumberListRequest, ActionResultPagerData<Model.WStationNumber>>
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.WStationNumber>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.WStationNumber> page = new PageListBySql<Model.WStationNumber>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();           
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.WStationNumber> models = WStationNumberBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.WStationNumber>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
   
}
