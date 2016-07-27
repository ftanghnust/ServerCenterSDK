/*********************************************************
 * FRXS chujl 2016/4/11 8:58:56
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
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    ///  完成配送
    /// </summary>
    [ActionName("SetDeliveredStatus")]
    public class SetDeliveredStatustAction : ActionBase<SetDeliveredStatustAction.SetDeliveredStatustActionRequestDto, SetDeliveredStatustAction.SetDeliveredStatustActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class SetDeliveredStatustActionRequestDto : RequestDtoBase
        {
            #region 查询参数

            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderId { get; set; }

            /// <summary>
            /// 用户编号
            /// </summary>
            [Required]
            public string EmpId { get; set; }

            /// <summary>
            /// 用户名称
            /// </summary>
            [Required]
            public string EmpName { get; set; }

            /// <summary>
            /// 仓库ID
            /// </summary>
            [Required]
            public string WID { get; set; }

            #endregion

        }

        /// <summary>
        /// 接口调用输出
        /// </summary>
        public class SetDeliveredStatustActionResponseDto : ResponseDtoBase
        {

        }


        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SetDeliveredStatustActionResponseDto> Execute()
        {
            SetDeliveredStatustActionRequestDto reqDto = RequestDto;
            int result = SaleOrderPreBLO.ChangeStatusToDelivered(reqDto.OrderId, reqDto.EmpId, reqDto.EmpName, int.Parse(reqDto.WID));

            if (result > 0)
            {
                return SuccessActionResult(new SetDeliveredStatustActionResponseDto());
            }
            else
            {

                return ErrorActionResult("装车失败！");
            }
        }
    }
}
