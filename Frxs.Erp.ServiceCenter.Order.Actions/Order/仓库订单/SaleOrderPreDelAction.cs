using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 删除代课订单以及明细集合信息
    /// </summary>
    [ActionName("SaleOrderPre.Del")]
    public class SaleOrderPreDelAction : ActionBase<RequestDto.SaleOrderPreBaseRequestDto, int>
    {
        public override ActionResult<int> Execute()
        {
            var dto = this.RequestDto;
            if (dto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }
            var order = dto.MapTo<SaleOrderPre>();

            //执行删除
            var result = SaleOrderPreBLO.DeleteOrder(order,dto.WarehouseId);
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
