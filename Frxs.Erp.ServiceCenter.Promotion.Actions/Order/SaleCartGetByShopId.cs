using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 由门店ID取购物车及详情
    /// </summary>
    [ActionName("SaleCart.GetByShopId")]
    public class SaleCartGetByShopIdAction : ActionBase<RequestDto.SaleCartQueryRequestDto, SaleCartGetByShopIdResponseDto>
    {
        public override ActionResult<SaleCartGetByShopIdResponseDto> Execute()
        {
            var dto = this.RequestDto;
 
            if(dto.ShopID<=0)
            {
                return this.ErrorActionResult("错误的门店ID");
            }
            var result = SaleCartBLO.GetCartList(dto.ShopID,dto.WarehouseId);

            if (result!=null&& result.Count>0)
            {
                var carts = new SaleCartGetByShopIdResponseDto();
                carts.Carts=new List<SaleCartBaseResponseDto>();
                foreach (var saleCart in result)
                {
                    var cart = saleCart.MapTo<SaleCartBaseResponseDto>();
                    carts.Carts.Add(cart);
                }
                return this.SuccessActionResult(carts);
            }
            else
            {
                return this.ErrorActionResult("购物车中没有商品");
            }
        }
    }
}
