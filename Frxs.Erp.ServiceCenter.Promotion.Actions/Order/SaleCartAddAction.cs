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
    /// 添加或修改购物车接口
    /// </summary>
    [ActionName("SaleCart.AddOrEdit")]
    public class SaleCartAddOrEditAction : ActionBase<RequestDto.SaleCartAddOrEditListRequestDto, int>
    {
        public override ActionResult<int> Execute()
        {
            var dto = this.RequestDto;

            var list = new List<SaleCart>();
            if (dto.CartList == null || dto.CartList.Count <= 0)
            {
                return this.ErrorActionResult("购物车内容为空");
            }
            if(dto.Flag!=0 && dto.Flag!=1)
            {
                return this.ErrorActionResult("操作标志错误");
            }
            foreach (var cart in dto.CartList)
            {
                var model = cart.MapTo<SaleCart>();
                list.Add(model);
            }
            var user = new BaseUserModel()
                           {
                               UserId = dto.UserId,
                               UserName = dto.UserName
                           };
            var result = SaleCartBLO.AppendProduct(list,user, dto.Flag == 1 ? true : false,dto.WarehouseId);
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
