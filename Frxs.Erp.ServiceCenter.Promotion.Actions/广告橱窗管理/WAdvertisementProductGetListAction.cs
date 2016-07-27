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
    /// 广告橱窗商品查询
    /// </summary>
    [ActionName("WAdvertisementProduct.GetList")]
    public class WAdvertisementProductGetListAction : ActionBase<RequestDto.WAdvertisementProductGetListActionRequestDto, ActionResultPagerData<WAdvertisementProduct>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<WAdvertisementProduct>> Execute()
        {
            //var requestDto = this.RequestDto;
            //var requestDtoDict = requestDto.GetAttributes(false);
            //IList<WAdvertisementProduct> models = WAdvertisementProductBLO.GetList(requestDtoDict);

            //return this.SuccessActionResult(new ActionResultPagerData<WAdvertisementProduct>()
            //{
            //    TotalRecords = models.Count,
            //    ItemList = models.ToList()
            //});

            var requestDto = this.RequestDto;
            PageListBySql<WAdvertisementProduct> page = new PageListBySql<WAdvertisementProduct>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            //PageListBySql<WAdvertisementProduct> models = WAdvertisementProductBLO.GetPageList(page, requestDtoDict, requestDto.WID.ToString());
            //return this.SuccessActionResult(new ActionResultPagerData<WAdvertisementProduct>()
            //{
            //    TotalRecords = models.TotalRecords,
            //    ItemList = models.ItemList.ToList()
            //});
            conditionDict.Add("WID", requestDtoDict["WID"]);
            conditionDict.Add("AdvertisementID", requestDtoDict["AdvertisementID"]);
            IList<WAdvertisementProduct> models = WAdvertisementProductBLO.GetList(conditionDict, requestDto.WID.ToString());
            return this.SuccessActionResult(new ActionResultPagerData<WAdvertisementProduct>()
            {
                TotalRecords = models.Count,
                ItemList = models.ToList()
            });
        }
    }
}
