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
    /// 取消订单
    /// </summary>
    [ActionName("OrderShop.Cancel")]
    public class OrderShopCancelAction : ActionBase<RequestDto.OrderCancelRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;

            if(dto.OrderIdList==null || dto.OrderIdList.Count<=0)
            {
                return this.ErrorActionResult("没有订单编号");
            }
            if(dto.Status!=8 && dto.Status!=9)
            {
                return this.ErrorActionResult("请传入正确的订单取消状态");
            }
            
            var user = new BaseUserModel(dto.UserId, dto.UserName);
            var result = SaleOrderShopBLO.CloseOrders(dto.WarehouseId,dto.OrderIdList,dto.Status,dto.CloseReason,user);
            if (result.IsSuccess)
            {
                return this.SuccessActionResult(true);
            }
            else
            {
                return this.ErrorActionResult(result.Message);
            }
        }
    }
}
