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
    ///  完成装车
    /// </summary>
    [ActionName("SetDeliverStatus")]
    public class SetDeliverStatustAction : ActionBase<SetDeliverStatustAction.SetDeliverStatustActionRequestDto, SetDeliverStatustAction.SetDeliverStatustActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class SetDeliverStatustActionRequestDto : RequestDtoBase
        {
            #region 查询参数

            /// <summary>
            /// 订单编号
            /// </summary>

            public string OrderId { get; set; }

            /// <summary>
            /// 用户编号
            /// </summary>

            public string EmpId { get; set; }

            /// <summary>
            /// 用户名称
            /// </summary>

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
        public class SetDeliverStatustActionResponseDto : ResponseDtoBase
        {

        }


        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<SetDeliverStatustActionResponseDto> Execute()
        {
            SetDeliverStatustActionRequestDto reqDto = RequestDto;

            string result = SaleOrderPreBLO.ChangeStatusToDeliver(reqDto.OrderId, reqDto.EmpId, reqDto.EmpName, int.Parse(reqDto.WID));

            if (result == "1")
            {
                return SuccessActionResult(new SetDeliverStatustActionResponseDto());
            }
            else
            {

                return ErrorActionResult(result);
            }
        }
    }
}
