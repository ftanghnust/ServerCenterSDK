using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.Order
{
    /// <summary>
    /// 取消订单
    /// </summary>
    [ActionName("OrderShop.EditSingle")]
    public class OrderShopEditSingleAction : ActionBase<RequestDto.OrderShopEditSingleRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            if(string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("没有订单编号");
            }
            var order = SaleOrderShopBLO.GetModel(dto.OrderId, dto.WarehouseId);
            if(order==null)
            {
                return this.ErrorActionResult("没有这个订单");
            }
            if(order.Status!=1)
            {
                return this.ErrorActionResult("订单状态不能进行编辑");
            }
            var detail = dto.Detail.MapTo<SaleOrderShopDetails>();
            var detailExt = dto.DetailExt.MapTo<SaleOrderShopDetailsExt>();
            var user = new BaseUserModel(dto.UserId, dto.UserName);
            var result = SaleOrderShopBLO.EditSingleDetail(dto.OrderId, detail, detailExt, dto.EditType, user, dto.WID.Value);
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
