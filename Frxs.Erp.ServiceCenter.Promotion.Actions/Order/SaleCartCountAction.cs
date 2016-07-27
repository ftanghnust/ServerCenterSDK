using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 计算购物车商品总数量
    /// </summary>
    [ActionName("SaleCart.Count")]
    public class SaleCartCountAction : ActionBase<RequestDto.SaleCartBaseRequestDto, decimal>
    {
        public override ActionResult<decimal> Execute()
        {
            var dto = this.RequestDto;
            var result = SaleCartBLO.CountCarts(dto.ShopID, dto.WarehouseId,dto.ProductId);
            if (result.IsSuccess)
            {
                return this.SuccessActionResult(result.Data);
            }
            else
            {
                return this.ErrorActionResult(result.Message);
            }
        }
    }
}
