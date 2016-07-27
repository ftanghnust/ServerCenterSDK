using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.Order
{
    /// <summary>
    /// 查询购物车列表
    /// </summary>
    [ActionName("SaleCart.Query")]
    public class SaleCartQueryAction : ActionBase<RequestDto.SaleCartQueryRequestDto, SaleCartQueryResponseDto>
    {
        public override ActionResult<SaleCartQueryResponseDto> Execute()
        {
            var dto = this.RequestDto;

            if(dto.ShopID<=0)
            {
                return this.ErrorActionResult("门店编码错误");
            }
            var wid = dto.WID.HasValue ? dto.WID.Value : 0;
            var data = SaleCartBLO.GetCartList(dto.ShopID, wid);
            if(data==null || data.Count<=0)
            {
                return this.ErrorActionResult("没有数据");
            }
            var list = new List<SaleCartDetail>();
            var result = SaleCartBLO.GetProductInfo(data, list,dto.WarehouseId);
            if(!result.IsSuccess)
            {
                return this.ErrorActionResult("获取商品信息失败");
            }
            result = SaleCartBLO.GetProductPromotionInfo(data, list,dto.WarehouseId);
            if(!result.IsSuccess)
            {
                return this.ErrorActionResult("获取商品促销和积分信息失败");
            }
            return this.SuccessActionResult(new SaleCartQueryResponseDto()
                                                {
                                                    List = list
                                                });
        }
    }
}
