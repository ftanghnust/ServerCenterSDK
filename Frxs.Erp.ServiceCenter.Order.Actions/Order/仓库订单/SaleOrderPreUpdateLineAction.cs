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
    /// 修改订单线路信息
    /// </summary>
    [ActionName("SaleOrderPre.UpdateLine")]
    public class SaleOrderPreUpdateLineAction : ActionBase<RequestDto.SaleOrderPreUpdateLineRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            if (String.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("错误的订单号");
            }
            var user = new BaseUserModel()
            {
                UserId = dto.UserId,
                UserName = dto.UserName
            };
            var res = SaleOrderPreBLO.UpdateLine(new SaleOrderPre()
            {
                OrderId = dto.OrderId,
                LineID = dto.LineId,
                LineName = dto.LineName
            }, user, dto.WarehouseId);
            if (res.IsSuccess)
            {
                return this.SuccessActionResult(true);
            }
            else
            {
                return this.ErrorActionResult(res.Message);
            }

        }
    }
}
