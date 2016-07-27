using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 确认订单
    /// </summary>
    [ActionName("OrderShop.Confirm")]
    public class OrderShopConfirmAction : ActionBase<RequestDto.OrderBaseRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
 
            if (string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("没有订单编号");
            }
            var user = new BaseUserModel(dto.UserId, dto.UserName);
            var result = SaleOrderShopBLO.ConfirmOrderShop(dto.OrderId, dto.WarehouseId);
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
