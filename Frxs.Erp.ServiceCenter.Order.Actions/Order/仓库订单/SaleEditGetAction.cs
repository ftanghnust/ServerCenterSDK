using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 改单详情获取
    /// </summary>
    [ActionName("SaleEdit.Get")]
    public class SaleEditGetAction : ActionBase<RequestDto.SaleEditBaseRequestDto, SaleEditGetResponseDto>
    {
        public override ActionResult<SaleEditGetResponseDto> Execute()
        {
            var dto = this.RequestDto;
            if (string.IsNullOrEmpty(dto.EditId))
            {
                return this.ErrorActionResult("错误的改单编号");
            }
            var edit = SaleEditBLO.GetModel(dto.EditId, dto.WarehouseId.ToString());
            if (edit == null)
            {
                return this.ErrorActionResult("没有这个改单数据");
            }
            var order = SaleEditBLO.GetOrders(dto.EditId, dto.WarehouseId);

            if (order == null || order.Count <= 0)
            {
                return this.ErrorActionResult("改单缺少订单信息");
            }

            var detail = SaleEditBLO.GetDetail(dto.EditId, dto.WarehouseId);
            if (detail == null || detail.Count <= 0)
            {
                return this.ErrorActionResult("改单缺少明细信息");
            }
            var detailExt = SaleEditBLO.GetDetailExt(dto.EditId, dto.WarehouseId);
            if (detailExt == null || detailExt.Count <= 0)
            {
                return this.ErrorActionResult("改单缺少明细扩展信息");
            }
            var result = new SaleEditGetResponseDto();
            result.SaleEdit = edit.MapTo<SaleEditResponseDto>();
            result.Order = order.MapToList<SaleEditOrderResponseDto>().ToList();
            foreach (var item in result.Order)
            {
                var orderPre = vSaleOrderBLO.GetModel(item.OrderID, dto.WarehouseId);
                item.SendDate = orderPre.SendDate;
                item.LineID = orderPre.LineID;
                item.LineName = orderPre.LineName;
                item.Status = orderPre.Status;
                item.StatusName = SaleOrderPreBLO.ConvertStatusToString(item.Status.Value);
                item.PayAmount = orderPre.PayAmount;
                item.ShopTypeName = SaleOrderPreBLO.ConvertShopTypeToString(orderPre.ShopType);
            }
            result.Details = detail.MapToList<SaleEditDetailResponseDto>().ToList();
            result.DetailExts = detailExt.MapToList<SaleEditDetailExtsResponseDto>().ToList();
            return this.SuccessActionResult(result);
        }
    }
}
