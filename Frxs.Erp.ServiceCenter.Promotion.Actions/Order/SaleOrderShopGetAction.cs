using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Promotion.Model;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 用于门店排单
    /// </summary>
    [ActionName("SaleOrderShop.Get")]
    public class SaleOrderShopGetAction : ActionBase<RequestDto.OrderBaseRequestDto, IList<Model.ShopOrder>>
    {
        public override ActionResult<IList<Model.ShopOrder>> Execute()
        {
            var dto = this.RequestDto;

           
            IList<ShopOrder> shopOrder = SaleOrderShopBLO.GetShopOrder(dto.SearchDate, dto.WarehouseId);

            return this.SuccessActionResult(shopOrder);
        }
    }
}
