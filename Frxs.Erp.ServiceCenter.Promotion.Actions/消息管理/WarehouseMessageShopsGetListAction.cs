/*********************************************************
 * FRXS(ISC) chujl 2016/3/23  
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Promotion.BLL;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 仓库消息门店分组分页查询
    /// </summary>
    [ActionName("WarehouseMessageShops.GetList")]
    public class WarehouseMessageShopsGetListAction : ActionBase<RequestDto.WarehouseMessageShopsGetListActionRequestDto, ActionResultPagerData<WarehouseMessageShops>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WarehouseMessageShops>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<WarehouseMessageShops> page = new PageListBySql<WarehouseMessageShops>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<WarehouseMessageShops> models = WarehouseMessageShopsBLO.GetPageList(page, requestDtoDict,requestDto.WarehouseId.ToString());

            return this.SuccessActionResult(new ActionResultPagerData<WarehouseMessageShops>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
