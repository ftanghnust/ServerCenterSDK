using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.BLL.Order;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 用于门店排单
    /// </summary>
    [ActionName("vSaleOrder.GetExt")]
    public class vSaleOrderGetExtAction : ActionBase<RequestDto.OrderBaseExtRequestDto, IList<SaleOrderExt>>
    {
        public override ActionResult<IList<SaleOrderExt>> Execute()
        {
            var dto = this.RequestDto;

            IList<SaleOrderExt> shopOrder = vSaleOrderBLO.GetShopOrder(dto.SearchDate, dto.WID);

            return this.SuccessActionResult(shopOrder);
        }
    }
}
