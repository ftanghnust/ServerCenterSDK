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
    [ActionName("OrderPre.Print")]
    public class OrderPrePrintAction : ActionBase<RequestDto.OrderPrintRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;

            var isPrinted = 1;
            if(dto.IsPrinted.HasValue)
            {
                isPrinted = dto.IsPrinted.Value;
            }
            var user = new BaseUserModel(dto.UserId, dto.UserName);
            var result = SaleOrderPreBLO.Print(dto.OrderId, dto.WarehouseId, user, isPrinted);
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
