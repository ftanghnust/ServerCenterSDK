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
    /// 仓库消息分页查询
    /// </summary>
    [ActionName("WarehouseMessage.GetList")]
    public class WarehouseMessageGetListAction : ActionBase<RequestDto.WarehouseMessageGetListActionRequestDto, ActionResultPagerData<WarehouseMessage>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WarehouseMessage>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<WarehouseMessage> page = new PageListBySql<WarehouseMessage>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false,false);
            PageListBySql<WarehouseMessage> models = WarehouseMessageBLO.GetPageList(page, requestDtoDict, requestDto.WareHouseId.ToString());

            return this.SuccessActionResult(new ActionResultPagerData<WarehouseMessage>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
