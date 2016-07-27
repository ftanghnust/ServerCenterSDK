/*********************************************************
 * FRXS 小马哥 2016/4/20 20:29:45
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL.Order;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.Utility;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 获取打印订单列表
    /// </summary>
    [ActionName("GetPrintOrderList")]
    public class GetPrintOrderListAction : ActionBase<Frxs.Erp.ServiceCenter.Order.Actions.GetPrintOrderListAction.GetPrintOrderListActionRequestDto, Frxs.Erp.ServiceCenter.Order.Actions.GetPrintOrderListAction.GetPrintOrderListActionResponseDto>
    {
        /// <summary>
        /// 接口传入参数
        /// </summary>
        public class GetPrintOrderListActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public string WID { get; set; }

            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderID { get; set; }
        }
        /// <summary>
        /// 接口输出数据
        /// </summary>
        public class GetPrintOrderListActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 订单列表
            /// </summary>
            public IList<vSaleOrder> OrderList { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetPrintOrderListActionResponseDto> Execute()
        {
            IList<vSaleOrder> list = vSaleOrderBLO.GetPrintList("5,6,7", Utils.StrToInt(RequestDto.WID, 0), RequestDto.OrderID);
            GetPrintOrderListActionResponseDto respDto = new GetPrintOrderListActionResponseDto();
            if (list.Count > 0)
            {
                respDto.OrderList = new List<vSaleOrder>();
                respDto.OrderList = list;
                return SuccessActionResult(respDto);
            }
            else
            {
                return ErrorActionResult("为查询到数据");
            }
        }
    }
}
