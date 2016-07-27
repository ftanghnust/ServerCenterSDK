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
    /// 添加订单跟踪
    /// </summary>
    [ActionName("SaleOrder.AddTrack")]
    public class SaleOrderAddTrackAction : ActionBase<RequestDto.OrderTrackAddRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            if (string.IsNullOrEmpty(dto.OrderID))
            {
                return this.ErrorActionResult("错误的订单号");
            }
            if((!dto.OrderStatus.HasValue) || dto.OrderStatus.Value<0 || dto.OrderStatus.Value>9)
            {
                return this.ErrorActionResult("错误的订单状态");
            }
            var track = dto.MapTo<SaleOrderTrack>();
            track.CreateTime = DateTime.Now;
            track.CreateUserID = dto.UserId;
            track.CreateUserName = dto.UserName;
            track.OrderStatusName = SaleOrderPreBLO.ConvertStatusToString(dto.OrderStatus.Value);
            track.WID = dto.WarehouseId;
            track.ID = dto.WarehouseId.ToString() + Guid.NewGuid();

            var result = SaleOrderTrackBLO.Save(track,dto.WarehouseId.ToString());
            if (result>0)
            {
                return this.SuccessActionResult();
            }
            else
            {
                return this.ErrorActionResult("添加跟踪信息失败");
            }

        }
    }
}
