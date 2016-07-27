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
    /// 取消订单
    /// </summary>
    [ActionName("OrderPre.Cancel")]
    public class OrderPreCancelAction : ActionBase<RequestDto.OrderCancelRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;

            if (dto.OrderIdList == null || dto.OrderIdList.Count <= 0)
            {
                return this.ErrorActionResult("没有订单编号");
            }
            if (dto.Status != 8 && dto.Status != 9)
            {
                return this.ErrorActionResult("请传入正确的订单取消状态");
            }

            var user = new BaseUserModel(dto.UserId, dto.UserName);
            var result = SaleOrderPreBLO.CloseOrders(dto.WarehouseId, dto.OrderIdList, dto.Status, dto.CloseReason, user);
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
