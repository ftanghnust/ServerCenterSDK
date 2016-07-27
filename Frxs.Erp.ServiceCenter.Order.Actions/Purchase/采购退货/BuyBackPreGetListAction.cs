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
    /// 采购退货单(待处理)分页查询
    /// </summary>
    [ActionName("BuyBackPre.GetList")]
    public class BuyBackPreGetListAction : ActionBase<RequestDto.BuyBackPreGetListActionRequestDto, ResponseDto.BuyBackPreGetListActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.BuyBackPreGetListActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto.WID <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }
            PageListBySql<BuyBackPre> page = new PageListBySql<BuyBackPre>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            BuyBackPageModel pagemode = new BuyBackPageModel()
            {
                pageModel = page,
                SubAmt = 0
            };
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            BuyBackPageModel models = BuyBackPreBLO.GetPageList(pagemode, requestDtoDict, requestDto.WID.ToString());

            return this.SuccessActionResult(new ResponseDto.BuyBackPreGetListActionResponseDto()
            {
                TotalRecords = models.pageModel.TotalRecords,
                ItemList = models.pageModel.ItemList.ToList(),
                SubAmt = models.SubAmt
            });
        }
    }
}
