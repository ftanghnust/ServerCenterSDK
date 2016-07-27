using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 订单完成
    /// </summary>
    [ActionName("OrderPre.Finished")]
    public class OrderPreFinishedAction : ActionBase<RequestDto.OrderBaseRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {

            var dto = this.RequestDto;
            if(string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("错误的订单编号");
            }
            var user = new BaseUserModel(dto.UserId, dto.UserName);
            var result = SaleOrderBLO.FinishOrder(dto.OrderId, user, dto.WarehouseId);
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
