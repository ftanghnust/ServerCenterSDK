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
    /// 改单查询
    /// </summary>
    [ActionName("SaleEdit.Query")]
    public class SaleEditQueryAction : ActionBase<RequestDto.SaleEditQueryRequestDto, SaleEditQueryResponseDto>
    {
        public override ActionResult<SaleEditQueryResponseDto> Execute()
        {
            var dto = this.RequestDto;
            int total = 0;
            var query = dto.MapTo<SaleEditQuery>();
            query.WID = dto.WarehouseId;
            var result = SaleEditBLO.Query(query, out total, dto.WarehouseId);
            if(result==null || result.Count<=0)
            {
                return this.ErrorActionResult("没有找到改单数据");
            }
            else
            {
                var data = result.MapToList<SaleEditResponseDto>();
                return this.SuccessActionResult(new SaleEditQueryResponseDto() {ItemList = data.ToList(),Total = total});
            }
        }
    }
}
