using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.BLL.Order;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 订单详情
    /// </summary>
    [ActionName("vSaleOrder.Get")]
    public class vSaleOrderGetAction : ActionBase<RequestDto.OrderBaseRequestDto, SaleOrderPreGetResponseDto>
    {
        public override ActionResult<SaleOrderPreGetResponseDto> Execute()
        {
            var dto = this.RequestDto;

            if (string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("请传入订单编号");
            }
            var order = vSaleOrderBLO.GetModel(dto.OrderId,dto.WarehouseId);
            if (order == null)
            {
                return this.ErrorActionResult("没有这个订单");
            }
            if(order.Status==(int)OrderStatus.Finished)
            {
                var details = SaleOrderBLO.GetDetailByOrderId(dto.OrderId, dto.WarehouseId);
                var detailsExts = SaleOrderBLO.GetDetailExsByOrderId(dto.OrderId, dto.WarehouseId);
                var resp = new SaleOrderPreGetResponseDto();
                resp.Order = order.MapTo<SaleOrderPreResponseDto>();
                resp.Order.ShopTypeName = SaleOrderPreBLO.ConvertShopTypeToString(resp.Order.ShopType);
                resp.Order.StatusName = SaleOrderPreBLO.ConvertStatusToString(resp.Order.Status);
                resp.Details = details.MapToList<SaleOrderPreDetailRequestDto>().ToList();
                resp.DetailExts = detailsExts.MapToList<SaleOrderPreDetailExtsRequestDto>().ToList();
                return this.SuccessActionResult(resp);
            }
            else
            {
                var details = SaleOrderPreBLO.GetDetailByOrderId(dto.OrderId, dto.WarehouseId);
                var detailsExts = SaleOrderPreBLO.GetDetailExsByOrderId(dto.OrderId, dto.WarehouseId);
                var resp = new SaleOrderPreGetResponseDto();
                resp.Order = order.MapTo<SaleOrderPreResponseDto>();
                resp.Order.ShopTypeName = SaleOrderPreBLO.ConvertShopTypeToString(resp.Order.ShopType);
                resp.Order.StatusName = SaleOrderPreBLO.ConvertStatusToString(resp.Order.Status);
                resp.Details = details.MapToList<SaleOrderPreDetailRequestDto>().ToList();
                resp.DetailExts = detailsExts.MapToList<SaleOrderPreDetailExtsRequestDto>().ToList();
                return this.SuccessActionResult(resp);
            }
        }
    }
}
