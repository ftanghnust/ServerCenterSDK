using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Promotion.BLL;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 用户是否存在未确认订单
    /// </summary>
    [ActionName("OrderShop.bExistUnConfirmOrder")]
    public class OrderShopExistUnConfirmOrderAction : ActionBase<RequestDto.OrderBaseRequestDto, OrderShopResponseDto>
    {
        public override ActionResult<OrderShopResponseDto> Execute()
        {
            var dto = this.RequestDto;
  
            if(!dto.ShopId.HasValue)
            {
                return this.ErrorActionResult("请输入门店ID");
            }
            var result = SaleOrderShopBLO.ExistsUnConfirm(dto.ShopId.Value,dto.WarehouseId);
            if (result==null)
            {
                return this.SuccessActionResult(null);
            }
            else
            {
                var m = result.MapTo<OrderShopResponseDto>();
                return this.SuccessActionResult(m);
            }
        }
    }
}
