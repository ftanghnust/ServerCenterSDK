/*********************************************************
 * FRXS 小马哥 2016/4/11 15:18:04
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 拣货接口-待拣货详细商品
    /// </summary>
    [ActionName("GetWaitPickDetails")]
    public class GetWaitPickDetailsAction : ActionBase<GetWaitPickDetailsAction.GetWaitPickDetailsActionRequestDto, GetWaitPickDetailsAction.GetWaitPickDetailsActionResponseDto>
    {
        /// <summary>
        /// 待拣货详细商品传入参数
        /// </summary>
        public class GetWaitPickDetailsActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderID { get; set; }

            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }

            /// <summary>
            /// 货区编号
            /// </summary>
            public string ShelfAreaID { get; set; }
        }

        /// <summary>
        /// 待拣货详细商品输出
        /// </summary>
        public class GetWaitPickDetailsActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 等待拣货订单商品列表
            /// </summary>
            public SaleOrderPreWaitPickingList WaitPickDetailsData { get; set; }
        }

        /// <summary>
        /// 执行逻辑业务
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetWaitPickDetailsActionResponseDto> Execute()
        {
            SaleOrderPreWaitPickingList model = null;
            if (!string.IsNullOrWhiteSpace(RequestDto.ShelfAreaID) && Utils.StrToInt(RequestDto.ShelfAreaID, 0) > 0)
            {
                model = SaleOrderPreBLO.GetWaitPickDetails(RequestDto.OrderID, RequestDto.WID, Utils.StrToInt(RequestDto.ShelfAreaID, 0));
            }
            else
            {
                model = SaleOrderPreBLO.GetWaitPickDetails(RequestDto.OrderID, RequestDto.WID);
            }
            return SuccessActionResult(new GetWaitPickDetailsActionResponseDto()
            {
                WaitPickDetailsData = model
            });
        }
    }
}
