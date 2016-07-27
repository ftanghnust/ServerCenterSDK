using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto.Order;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 获取订单跟踪信息
    /// </summary>
    [ActionName("SaleOrder.GetTrack")]
    public class SaleOrderGetTrackAction : ActionBase<RequestDto.OrderBaseRequestDto, SaleOrderTracksGetResponseDto>
    {
        public override ActionResult<SaleOrderTracksGetResponseDto> Execute()
        {
            var dto = this.RequestDto;
            if (string.IsNullOrEmpty(dto.OrderId))
            {
                return this.ErrorActionResult("错误的订单号");
            }

            var result = SaleOrderTrackBLO.GetTracks(dto.OrderId, dto.WarehouseId);
            if (result==null || result.Count<=0)
            {
                return this.ErrorActionResult("没有订单跟踪数据");
            }
            else
            {
                var tracks = new SaleOrderTracksGetResponseDto();
                tracks.Tracks = new List<OrderTrackGetResponseDto>();
                foreach (var track in result.OrderBy(x=>x.CreateTime))
                {
                    tracks.Tracks.Add(track.MapTo<OrderTrackGetResponseDto>());
                }
                return this.SuccessActionResult(tracks);
            }

        }
    }
}
