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
    /// 查询所有订单以及明细集合信息（包含saleOrderPre和saleOrder）
    /// </summary>
    [ActionName("vSaleOrder.Query")]
    public class vSaleOrderQueryAction : ActionBase<RequestDto.SaleOrderPreBaseRequestDto, SaleOrderPreQueryResponseDto>
    {
        public override ActionResult<SaleOrderPreQueryResponseDto> Execute()
        {
            var dto = this.RequestDto;

            var query = dto.MapTo<OrderQuery>();

            //list不能直接mapTo，只能add
            if(dto.FilterStatus!=null && dto.FilterStatus.Count>0)
            {
                query.FilterStatus=new List<int>();
                foreach (var statu in dto.FilterStatus)
                {
                    query.FilterStatus.Add(statu);
                }
            }

            if (dto.Status.HasValue)
            {
                query.Status = (OrderStatus)dto.Status;
            }

            if (query.PageIndex <= 0)
            {
                query.PageIndex = 1;
            }
            if (query.PageSize <= 0)
            {
                query.PageSize = int.MaxValue;
            }
            if (string.IsNullOrEmpty(query.SortBy))
            {
                query.SortBy = " OrderId desc ";
            }
            var total = 0;
            var totalAmt = 0m;
            query.WID = dto.WarehouseId;
            var result = vSaleOrderBLO.Query(query, out total,out totalAmt, dto.WarehouseId);
            if (result != null && result.Count > 0)
            {
                var list = new List<SaleOrderPreResponseDto>();
                foreach (var orderShop in result)
                {
                    var m = orderShop.MapTo<SaleOrderPreResponseDto>();
                    m.ShopTypeName = SaleOrderPreBLO.ConvertShopTypeToString(m.ShopType);
                    m.StatusName = SaleOrderPreBLO.ConvertStatusToString(m.Status);
                    list.Add(m);
                }
                return this.SuccessActionResult(new SaleOrderPreQueryResponseDto() { Orders = list, TotalCount = total,TotalAmt=totalAmt });
            }
            else
            {
                return this.ErrorActionResult("没有找到数据");
            }
        }
    }
}
