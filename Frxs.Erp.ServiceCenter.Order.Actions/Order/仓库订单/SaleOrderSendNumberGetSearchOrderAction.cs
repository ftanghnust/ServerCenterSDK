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
    /// 发货顺序接口-调整线路顺序
    /// </summary>
    [ActionName("SaleOrderSendNumberGetSearchOrder")]
    public class SaleOrderSendNumberGetSearchOrderAction : ActionBase<RequestDto.SaleOrderSendNumberGetSearchOrderRequestDto, SaleOrderSendNumberGetSearchOrderResponseDto>
    {
        public override ActionResult<SaleOrderSendNumberGetSearchOrderResponseDto> Execute()
        {
            var dto = this.RequestDto;
            var result = SaleOrderSendNumberBLO.GetSaleOrderSendNumberSearchOrder(dto.WarehouseId, dto.ShopCode, dto.OrderId);
            var saleOrderPre = result.MapTo<SaleOrderPreResponseDto>();
            return this.SuccessActionResult(new SaleOrderSendNumberGetSearchOrderResponseDto() { SaleOrderPre = saleOrderPre });
            //if (result != null)
            //{
            //    var saleOrderPre = result.MapTo<SaleOrderPreResponseDto>();
            //    return this.SuccessActionResult(new SaleOrderSendNumberGetSearchOrderResponseDto() { SaleOrderPre = saleOrderPre });
            //}
            //else
            //{
            //    return this.ErrorActionResult("没有找到数据");
            //}
        }
    }
}
