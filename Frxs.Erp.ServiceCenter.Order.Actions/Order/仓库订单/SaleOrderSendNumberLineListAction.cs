/*********************************************************
 * 周进 2016/4/26
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 发货顺序接口-等待拣货订单
    /// </summary>
    [ActionName("GetSaleOrderSendNumberLineList")]
    public class SaleOrderSendNumberLineListAction : ActionBase<RequestDto.SaleOrderSendNumberLineListRequestDto, SaleOrderSendNumberLineListResponseDto>
    {
        public override ActionResult<SaleOrderSendNumberLineListResponseDto> Execute()
        {
            var dto = this.RequestDto;
            var result = SaleOrderSendNumberBLO.GetSaleOrderSendNumberLineList(dto.WarehouseId);
            if (result != null && result.Count > 0)
            {
                var list = new List<SaleOrderSendNumberLineResponseDto>();
                foreach (var orderShop in result)
                {
                    var m = orderShop.MapTo<SaleOrderSendNumberLineResponseDto>();
                    list.Add(m);
                }
                return this.SuccessActionResult(new SaleOrderSendNumberLineListResponseDto() { SaleOrderSendNumberLineList = list });
            }
            else
            {
                return this.ErrorActionResult("没有找到数据");
            }
        }
    }
}
