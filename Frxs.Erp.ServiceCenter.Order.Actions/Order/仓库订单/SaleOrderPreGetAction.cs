using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 订单详情
    /// </summary>
    [ActionName("SaleOrderPre.Get")]
    public class SaleOrderPreAction : ActionBase<RequestDto.OrderBaseRequestDto, SaleOrderPreGetResponseDto>
    {
        public override ActionResult<SaleOrderPreGetResponseDto> Execute()
        {
            var dto = this.RequestDto;

            if (string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("请传入订单编号");
            }
            var order = SaleOrderPreBLO.GetModel(dto.OrderId, Wid: dto.WarehouseId);
            if (order == null)
            {
                return this.ErrorActionResult("没有这个订单");
            }
            var details = SaleOrderPreBLO.GetDetailByOrderId(dto.OrderId, dto.WarehouseId);
            var detailsExts = SaleOrderPreBLO.GetDetailExsByOrderId(dto.OrderId, dto.WarehouseId);
            var resp = new SaleOrderPreGetResponseDto();
            resp.Order = order.MapTo<SaleOrderPreResponseDto>();

            //转换门店类型为字符串
            resp.Order.ShopTypeName = SaleOrderPreBLO.ConvertShopTypeToString(resp.Order.ShopType); 
            //转换订单类型为字符串
            resp.Order.StatusName = SaleOrderPreBLO.ConvertStatusToString(resp.Order.Status);

            resp.Details = new List<SaleOrderPreDetailRequestDto>();
            foreach (var saleOrderShopDetailse in details)
            {
                var d = saleOrderShopDetailse.MapTo<SaleOrderPreDetailRequestDto>();
                resp.Details.Add(d);
            }

            resp.DetailExts = new List<SaleOrderPreDetailExtsRequestDto>();
            foreach (var saleOrderShopDetailsExt in detailsExts)
            {
                var d = saleOrderShopDetailsExt.MapTo<SaleOrderPreDetailExtsRequestDto>();
                resp.DetailExts.Add(d);
            }
            return this.SuccessActionResult(resp);
        }
    }
}
