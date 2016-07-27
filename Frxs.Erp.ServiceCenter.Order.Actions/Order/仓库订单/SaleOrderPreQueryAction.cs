using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 查询订单以及明细集合信息
    /// </summary>
    [ActionName("SaleOrderPre.Query")]
    public class SaleOrderPreQueryAction : ActionBase<RequestDto.SaleOrderPreBaseRequestDto, SaleOrderPreQueryResponseDto>
    {
        public override ActionResult<SaleOrderPreQueryResponseDto> Execute()
        {
            var dto = this.RequestDto; 

            var query = dto.MapTo<OrderQuery>();
            if (dto.Status.HasValue)
            {
                query.Status = (OrderStatus)dto.Status;
            }

            //list不能直接mapTo，只能add
            if (dto.FilterStatus != null && dto.FilterStatus.Count > 0)
            {
                query.FilterStatus = new List<int>();
                foreach (var statu in dto.FilterStatus)
                {
                    query.FilterStatus.Add(statu);
                }
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
            query.WID = dto.WarehouseId;
            var total = 0;
            //执行查询
            var result = SaleOrderPreBLO.Query(query, out total, dto.WarehouseId);
            //循环订单明细
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
                return this.SuccessActionResult(new SaleOrderPreQueryResponseDto() { Orders = list, TotalCount = total });
            }
            else
            {
                return this.ErrorActionResult("没有找到数据");
            }
        }
    }
}
