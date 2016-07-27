/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/9 17:15:02
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
    /// 采购收货单(待处理)分页查询
    /// </summary>
    [ActionName("BuyOrderPre.GetList")]
    public class BuyOrderPreGetListAction : ActionBase<RequestDto.BuyOrderPreGetListActionRequestDto, ResponseDto.BuyOrderPreGetListActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override  ActionResult<ResponseDto.BuyOrderPreGetListActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto.WID <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }
            PageListBySql<BuyOrderPre> page = new PageListBySql<BuyOrderPre>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            BuyOrderPageModel pagemode = new BuyOrderPageModel()
            {
                pageModel = page,
                SubAmt = 0
            };
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            BuyOrderPageModel models = BuyOrderPreBLO.GetPageList(pagemode, requestDtoDict, requestDto.WID.ToString());

            return this.SuccessActionResult(new ResponseDto.BuyOrderPreGetListActionResponseDto()
            {
                TotalRecords = models.pageModel.TotalRecords,
                ItemList = models.pageModel.ItemList.ToList(),
                SubAmt = models.SubAmt
            });
        }

    }
}
