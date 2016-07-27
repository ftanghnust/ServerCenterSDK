using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Promotion.BLL;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 确认收货
    /// </summary>
    [ActionName("OrderShop.Received")]
    public class OrderShopReceivedAction : ActionBase<RequestDto.OrderShopReceivedRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
      
            if (string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("没有订单编号");
            }
            var user = new BaseUserModel(dto.UserId, dto.UserName);
            var result = SaleOrderShopBLO.ConfirmReceiver(dto.OrderId,dto.WarehouseId);
            if (result.IsSuccess)
            {
                return this.SuccessActionResult();
            }
            else
            {
                return this.ErrorActionResult(result.Message);
            }
        }
    }
}
