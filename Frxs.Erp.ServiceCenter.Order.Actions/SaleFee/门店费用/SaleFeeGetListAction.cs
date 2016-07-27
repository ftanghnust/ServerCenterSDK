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
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 门店费用 分页查询
    /// </summary>
    [ActionName("SaleFee.GetList")]
    public class SaleFeeGetListAction : ActionBase<RequestDto.SaleFeeGetListActionRequestDto, ResponseDto.SaleFeeGetListActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.SaleFeeGetListActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<SaleFee> page = new PageListBySql<SaleFee>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            decimal totalAmt = 0.0m;
            PageListBySql<SaleFee> models = SaleFeeBLO.GetPageList(requestDto.WarehouseID, page, requestDtoDict, out totalAmt);

            return this.SuccessActionResult(new ResponseDto.SaleFeeGetListActionResponseDto()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList(),
                SubAmt = totalAmt
            });
        }

    }
}
