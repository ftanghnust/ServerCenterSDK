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
    /// 未确认订单商品转入购物车
    /// </summary>
    [ActionName("OrderShop.ToCart")]
    public class OrderShopLoadToCartAction : ActionBase<RequestDto.OrderBaseRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;

            if (string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("没有订单编号");
            }
            if(!dto.ShopId.HasValue)
            {
                return this.ErrorActionResult("请传入门店ID");
            }
            if(!dto.WID.HasValue)
            {
                return this.ErrorActionResult("请传入仓库ID");
            }

            var order = SaleOrderShopBLO.GetModel(dto.OrderId,dto.WarehouseId);
            if(order==null)
            {
                return this.ErrorActionResult("没有这个订单");
            }
            if(order.Status!=0 && order.Status!=1)
            {
                return this.ErrorActionResult("已确认的订单不能修改");
            }
             var user = new BaseUserModel(dto.UserId, dto.UserName);
            var result = SaleOrderShopBLO.LoadOrderToCart(dto.OrderId, dto.ShopId.Value, dto.WID.Value,user);
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
