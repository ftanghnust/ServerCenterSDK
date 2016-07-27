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
    [ActionName("WarehouseLineShop.TableList")]
    public class WarehouseLineShopTableListAction : ActionBase<RequestDto.WarehouseLineShopTableListRequest, ActionResultPagerData<Model.WarehouseLineShop>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.WarehouseLineShop>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.WarehouseLineShop> page = new PageListBySql<Model.WarehouseLineShop>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<Model.WarehouseLineShop> models = WarehouseLineShopBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<Model.WarehouseLineShop>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }
    }
}
