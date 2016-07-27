using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.Order
{
    /// <summary>
    /// 获取未确认订单详情，没有未确认定单时，返回true，但data是空
    /// </summary>
    [ActionName("OrderShop.UnConfirm")]
    public class OrderShopGetUnConfirmAction : ActionBase<RequestDto.OrderBaseRequestDto, OrderShopGetResoponseDto>
    {
        public override ActionResult<OrderShopGetResoponseDto> Execute()
        {
            var dto = this.RequestDto;

            if ((!dto.ShopId.HasValue) || dto.ShopId.Value<=0)
            {
                return this.ErrorActionResult("请传入门店编号");
            }
            var order = SaleOrderShopBLO.ExistsUnConfirm(dto.ShopId.Value, dto.WarehouseId);
            if (order == null)
            {
                return this.SuccessActionResult();
            }
            var details = SaleOrderShopBLO.GetDetailByOrderId(order.OrderId, dto.WarehouseId);
            var detailsExts = SaleOrderShopBLO.GetDetailExsByOrderId(order.OrderId, dto.WarehouseId);
            var resp = new OrderShopGetResoponseDto();
            resp.Order = order.MapTo<OrderShopResponseDto>();
            resp.Order.ShopTypeName = SaleOrderShopBLO.ConvertShopTypeToString(resp.Order.ShopType);
            resp.Order.StatusName = SaleOrderShopBLO.ConvertStatusToString(resp.Order.Status);

            resp.Details = new List<OrderDetailRequestDto>();
            foreach (var saleOrderShopDetailse in details)
            {
                var d = saleOrderShopDetailse.MapTo<OrderDetailRequestDto>();
                d.BigPackingQty = d.SalePackingQty;
                resp.Details.Add(d);
            }

            resp.DetailExts = new List<OrderDetailExtsRequestDto>();
            foreach (var saleOrderShopDetailsExt in detailsExts)
            {
                var d = saleOrderShopDetailsExt.MapTo<OrderDetailExtsRequestDto>();
                resp.DetailExts.Add(d);
            }
            return this.SuccessActionResult(resp);
        }
    }
}
