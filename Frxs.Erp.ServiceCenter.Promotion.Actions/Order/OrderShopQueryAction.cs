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
    /// 订单查询
    /// </summary>
    [ActionName("OrderShop.Query")]
    public class OrderShopQueryAction : ActionBase<RequestDto.OrderQueryRequestDto, OrderShopQueryResponseDto>
    {
        public override ActionResult<OrderShopQueryResponseDto> Execute()
        {
            var dto = this.RequestDto;
 
            var query = dto.MapTo<OrderQuery>();
            if(dto.Status.HasValue)
            {
                query.Status = (OrderStatus)dto.Status;
            }
           
            if (query.PageIndex <= 0)
            {
                query.PageIndex = 1;
            }
            if(query.PageSize<=0)
            {
                query.PageSize = int.MaxValue;
            }
            if(string.IsNullOrEmpty(query.SortBy))
            {
                query.SortBy = " OrderId desc ";
            }
            query.WID = dto.WarehouseId;
            var total = 0;
            var result = SaleOrderShopBLO.Query(query, out total, dto.WarehouseId);
            if(result!=null && result.Count>0)
            {
                var list = new List<OrderShopResponseDto>();
                foreach (var orderShop in result)
                {
                    var m = orderShop.MapTo<OrderShopResponseDto>();
                    m.ShopTypeName = SaleOrderShopBLO.ConvertShopTypeToString(m.ShopType);
                    m.StatusName = SaleOrderShopBLO.ConvertStatusToString(m.Status);
                    list.Add(m);
                }
                return this.SuccessActionResult(new OrderShopQueryResponseDto() {Orders = list,TotalCount = total});
            }
            else
            {
                return this.ErrorActionResult("没有找到数据");
            }
        }
    }
}
