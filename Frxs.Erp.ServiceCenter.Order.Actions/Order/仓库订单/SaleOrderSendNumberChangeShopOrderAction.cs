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
    /// 发货顺序接口-调整门店顺序
    /// </summary>
    [ActionName("SaleOrderSendNumberChangeShopOrder")]
    public class SaleOrderSendNumberChangeShopOrderAction : ActionBase<RequestDto.SaleOrderSendNumberChangeShopOrderRequestDto, SaleOrderSendNumberChangeShopOrderResponseDto>
    {
        public override ActionResult<SaleOrderSendNumberChangeShopOrderResponseDto> Execute()
        {
            var dto = this.RequestDto;
            var result = SaleOrderSendNumberBLO.ChangeSaleOrderSendNumberShopOrder(dto.WarehouseId, dto.LineID, dto.OrderId, dto.ChangeType);
            if (result > 0)
            {
                var responseDto = new SaleOrderSendNumberChangeShopOrderResponseDto();
                responseDto.result = result;
                return this.SuccessActionResult(responseDto);
            }
            else if (result == -1)
            {
                return this.ErrorActionResult("单据已在其他地方处理,请手动刷新");
            }
            else
            {
                return this.ErrorActionResult("线路中门店顺序调整失败");
            }
        }
    }
}
