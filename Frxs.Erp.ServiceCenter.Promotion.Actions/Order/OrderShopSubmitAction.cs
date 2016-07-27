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
    /// 提交订单
    /// </summary>
    [ActionName("OrderShop.Submit")]
    public class OrderShopSubmitAction : ActionBase<RequestDto.OrderSubmitRequestDto, int>
    {
        public override ActionResult<int> Execute()
        {
            var dto = this.RequestDto;
     
            var order = dto.OrderShop.MapTo<SaleOrderShop>();
            var details = new List<SaleOrderShopDetails>();
            var detailExts = new List<SaleOrderShopDetailsExt>();
            BaseUserModel user=new BaseUserModel()
                                   {
                                       UserId = dto.UserId,
                                       UserName = dto.UserName
                                   };
            foreach (var detail in dto.Details)
            {
                var d = detail.MapTo<SaleOrderShopDetails>();
                details.Add(d);
            }
            foreach (var detailExt in dto.DetailExts)
            {
                var d = detailExt.MapTo<SaleOrderShopDetailsExt>();
                detailExts.Add(d);
            }
            var result = SaleOrderShopBLO.SubmitOrder(dto.WarehouseId,dto.ShopId, order, details, detailExts,dto.bDeleteOld,user);
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
