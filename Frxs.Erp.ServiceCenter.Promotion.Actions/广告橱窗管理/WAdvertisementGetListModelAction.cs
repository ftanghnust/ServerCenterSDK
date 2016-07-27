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
    [ActionName("WAdvertisement.GetListModel")]
    public class WAdvertisementGetListModelAction : ActionBase<RequestDto.WAdvertisementGetListActionRequestDto, IList<ResponseDto.WAdvertisementGetModelActionResponseDto>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<ResponseDto.WAdvertisementGetModelActionResponseDto>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<WAdvertisement> page = new PageListBySql<WAdvertisement>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<WAdvertisement> models = WAdvertisementBLO.GetPageList(page, requestDtoDict, requestDto.WID.ToString());

            IList<ResponseDto.WAdvertisementGetModelActionResponseDto> respModel = new List<ResponseDto.WAdvertisementGetModelActionResponseDto>();

            foreach (WAdvertisement item in models.ItemList)
            {
                ResponseDto.WAdvertisementGetModelActionResponseDto model = new ResponseDto.WAdvertisementGetModelActionResponseDto();

                WAdvertisement orderTemp = WAdvertisementBLO.GetModel(DataTypeHelper.GetInt(item.AdvertisementID), item.WID.ToString());
                Dictionary<string, object> conditionDictItem = new Dictionary<string, object>();
                conditionDictItem.Add("WID", orderTemp.WID);
                conditionDictItem.Add("AdvertisementID", orderTemp.AdvertisementID);
                IList<WAdvertisementProduct> products = WAdvertisementProductBLO.GetList(conditionDictItem, orderTemp.WID.ToString());

                model.order = orderTemp;
                model.products = products;

                respModel.Add(model);

            }

            return this.SuccessActionResult(respModel);
        }

    }
}
