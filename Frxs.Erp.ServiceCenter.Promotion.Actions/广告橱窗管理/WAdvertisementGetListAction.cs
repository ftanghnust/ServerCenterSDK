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
    /// 广告橱窗分页查询
    /// </summary>
    [ActionName("WAdvertisement.GetList")]
    public class WAdvertisementGetListAction : ActionBase<RequestDto.WAdvertisementGetListActionRequestDto, ActionResultPagerData<WAdvertisement>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WAdvertisement>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<WAdvertisement> page = new PageListBySql<WAdvertisement>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<WAdvertisement> models = WAdvertisementBLO.GetPageList(page, requestDtoDict, requestDto.WID.ToString());
            return this.SuccessActionResult(new ActionResultPagerData<WAdvertisement>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
