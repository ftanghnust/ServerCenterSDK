using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 排列订单发货顺序
    /// </summary>
    [ActionName("SaleOrderPre.SendNumber")]
    public class SaleOrderPreSendNumberAction : ActionBase<RequestDto.SaleOrderSendNumberRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            if(string.IsNullOrEmpty(dto.OrderID))
            {
                return this.ErrorActionResult("错误的订单号");
            }
            if(dto.LineSerialNumber<=0)
            {
                return this.ErrorActionResult("错误的线路顺序号");
            }
            if(dto.SendNumber<=0|| dto.SendNumber>9999)
            {
                return this.ErrorActionResult("错误的调整顺序号");
            }
            var m = dto.MapTo<SaleOrderSendNumber>();
            var user = new BaseUserModel()
                           {
                               UserId = dto.UserId,
                               UserName = dto.UserName
                           };
            var result = SaleOrderPreBLO.OrderSendNumber(dto.OrderID,m.SendNumber,m.WID,user);
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
