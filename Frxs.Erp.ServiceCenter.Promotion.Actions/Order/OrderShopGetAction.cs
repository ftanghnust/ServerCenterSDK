using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 订单详情
    /// </summary>
    [ActionName("OrderShop.Get")]
    public class OrderShopGetAction : ActionBase<RequestDto.OrderBaseRequestDto, OrderShopGetResoponseDto>
    {
        public override ActionResult<OrderShopGetResoponseDto> Execute()
        {
            var dto = this.RequestDto;

            if (string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("请传入订单编号");
            }
            var order = SaleOrderShopBLO.GetModel(dto.OrderId, Wid: dto.WarehouseId);
            if (order == null)
            {
                return this.ErrorActionResult("没有这个订单");
            }
            var details = SaleOrderShopBLO.GetDetailByOrderId(dto.OrderId, dto.WarehouseId);
            var detailsExts = SaleOrderShopBLO.GetDetailExsByOrderId(dto.OrderId, dto.WarehouseId);
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
