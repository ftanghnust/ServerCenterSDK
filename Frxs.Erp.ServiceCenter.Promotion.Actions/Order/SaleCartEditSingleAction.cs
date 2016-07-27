using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 单行修改购物车商品
    /// </summary>
    [ActionName("SaleCart.EditSingle")]
    public class SaleCartEditSingleAction : ActionBase<RequestDto.SaleCartEditSingleRequestDto, int>
    {
        public override ActionResult<int> Execute()
        {
            var dto = this.RequestDto;

            if(dto.EditType<0 || dto.EditType>2)
            {
                return this.ErrorActionResult("错误的操作类型");
            }
            var user = new BaseUserModel() {UserId = dto.UserId, UserName = dto.UserName};
            var model = dto.Cart.MapTo<SaleCart>();
            if(dto.EditType==0)//添加
            {
                model.ShopID = dto.ShopId;
                model.ModifyTime = DateTime.Now;
                model.CreateTime = DateTime.Now;
                var result = SaleCartBLO.Save(model, dto.WarehouseId);
                if (result>0)
                {
                    return this.SuccessActionResult();
                }
                else
                {
                    return this.ErrorActionResult("添加购物车商品失败");
                }
            }
            else if (dto.EditType == 1)//修改
            {
                 model.ShopID = dto.ShopId;
                model.ModifyTime = DateTime.Now;
                var result = SaleCartBLO.EditCart(model, dto.WarehouseId,user);
                if (result.IsSuccess)
                {
                    return this.SuccessActionResult();
                }
                else
                {
                    return this.ErrorActionResult(result.Message);
                }
            }
            else
            {
                var list = new List<int>();
                list.Add(model.ProductID);
                var result = SaleCartBLO.DeleteProduct(dto.ShopId,list,dto.WarehouseId);
                if (result.IsSuccess)
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
}
