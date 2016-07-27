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
    /// 销售结算单据列表查询
    /// </summary>
    [ActionName("SaleSettle.GetList")]
    public class SaleSettleGetListAction : ActionBase<SaleSettleGetListAction.SaleSettleGetListActionRequestDto, ResponseDto.SaleSettleGetListActionResponseDto>
    {

        /// <summary>
        /// SaleSettle.GetList
        /// </summary>
        public class SaleSettleGetListActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 门店编号
            /// </summary>
            public int? ShopID { get; set; }

            /// <summary>
            /// 状态
            /// </summary>
            public int? Status { get; set; }

            /// <summary>
            /// 结算单号
            /// </summary>
            public string SettleID { get; set; }

            /// <summary>
            /// 结算开始时间
            /// </summary>
            public DateTime? StartTime { get; set; }

            /// <summary>
            /// 结算结束时间
            /// </summary>
            public DateTime? EndTime { get; set; }


            /// <summary>
            /// 门店编号 addluojing
            /// </summary>
            public string ShopCode { get; set; }

            /// <summary>
            /// 门店名称 addluojing
            /// </summary>
            public string ShopName { get; set; }


            /// <summary>
            /// 结算方式 addluojing
            /// </summary>
            public string SettleType { get; set; }


            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (WID <= 0)
                {
                    yield return new RequestDtoValidatorResultError("WID");
                }
            }

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.SaleSettleGetListActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<SaleSettle> page = new PageListBySql<SaleSettle>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false,false);
            decimal totalAmt = 0.0m;
            PageListBySql<SaleSettle> models = SaleSettleBLO.GetPageList(page, requestDtoDict, requestDto.WID.ToString(),out totalAmt);

            return this.SuccessActionResult(new ResponseDto.SaleSettleGetListActionResponseDto()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList(),
                SubAmt = totalAmt
            });
        }

    }
}
