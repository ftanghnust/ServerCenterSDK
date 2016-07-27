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

namespace Frxs.Erp.ServiceCenter.Order.Actions.Order.仓库订单
{
    /// <summary>
    /// 发货顺序接口-等待拣货订单
    /// </summary>
    [ActionName("GetSaleOrderSendNumberShopList")]
    public class SaleOrderSendNumberShopListAction : ActionBase<RequestDto.SaleOrderSendNumberShopListRequestDto, SaleOrderSendNumberOrderShopListResponseDto>
    {
        public override ActionResult<SaleOrderSendNumberOrderShopListResponseDto> Execute()
        {
            var dto = this.RequestDto;
            var result = SaleOrderSendNumberBLO.GetSaleOrderSendNumberOrderShopList(dto.WarehouseId, dto.LineID);
            if (result != null && result.Count > 0)
            {
                var list = new List<SaleOrderSendNumberShopOrderResponseDto>();
                foreach (var orderShop in result)
                {
                    var m = orderShop.MapTo<SaleOrderSendNumberShopOrderResponseDto>();
                    list.Add(m);
                }
                return this.SuccessActionResult(new SaleOrderSendNumberOrderShopListResponseDto() { SaleOrderSendNumberShopList = list });
            }
            else
            {
                return this.ErrorActionResult("没有找到数据");
            }
        }
    }
}
