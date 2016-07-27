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
    /// 删除购物车列表
    /// </summary>
    [ActionName("SaleCart.Delete")]
    public class SaleCartDeleteAction : ActionBase<RequestDto.SaleCartDeleteRequestDto, int>
    {
        public override ActionResult<int> Execute()
        {
            var dto = this.RequestDto;
  
            if(dto.ShopID<=0)
            {
                return this.ErrorActionResult("没有传入门店Id");
            }
            List<int> list;
            if(dto.ProductIds!=null && dto.ProductIds.Count>0)
            {
                list=new List<int>();
                foreach (var productId in dto.ProductIds)
                {
                    list.Add(productId);
                }
            }
            else
            {
                list = null;
            }
            var result = SaleCartBLO.DeleteProduct(dto.ShopID, list,dto.WarehouseId);
            if(result.IsSuccess)
            {
                return this.SuccessActionResult();
            }
            else
            {
                return this.ErrorActionResult(result.Message);
            }
        }
    }
}
