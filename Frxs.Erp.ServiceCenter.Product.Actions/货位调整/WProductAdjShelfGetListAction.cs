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
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 货位调整 分页查询
    /// </summary>
    [ActionName("WProductAdjShelf.GetList")]
    public class WProductAdjShelfGetListAction : ActionBase<RequestDto.WProductAdjShelfGetListActionRequestDto, ActionResultPagerData<WProductAdjShelf>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WProductAdjShelf>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<WProductAdjShelf> page = new PageListBySql<WProductAdjShelf>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<WProductAdjShelf> models = WProductAdjShelfBLO.GetPageList(page, requestDtoDict);

            return this.SuccessActionResult(new ActionResultPagerData<WProductAdjShelf>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
