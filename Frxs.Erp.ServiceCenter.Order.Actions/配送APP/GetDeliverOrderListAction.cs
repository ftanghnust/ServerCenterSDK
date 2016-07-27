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
    ///   正在配送列表
    /// </summary>
    [ActionName("GetDeliverOrderList")]
    public class GetDeliverOrderListtAction : ActionBase<GetDeliverOrderListtAction.GetDeliverOrderListtActionRequestDto, GetDeliverOrderListtAction.GetDeliverOrderListtActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class GetDeliverOrderListtActionRequestDto : RequestDtoBase
        {
            #region 查询参数

         
            /// <summary>
            /// 用户编号
            /// </summary>
            [Required]
            public string EmpId { get; set; }

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
        public class GetDeliverOrderListtActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 数据总条数
            /// </summary>
            public int DeliverCount { get; set; }
        
            /// <summary>
            /// 配送门店集合
            /// </summary>
            public IList<WaitDeliverData> WaitDeliverData { get; set; }
        }


        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetDeliverOrderListtActionResponseDto> Execute()
        {
            GetDeliverOrderListtActionRequestDto reqDto = RequestDto;

            IList<WaitDeliverData> waitDeliverData = SaleOrderPreBLO.GetWaitDeliverData("", reqDto.EmpId, reqDto.WID,"" , "6");
            int deliverCount = 0;
            if (waitDeliverData != null && waitDeliverData.Count > 0)
            {
                deliverCount = waitDeliverData.Count;
            }
            return SuccessActionResult(new GetDeliverOrderListtActionResponseDto()
            {
                DeliverCount = deliverCount,
                WaitDeliverData = waitDeliverData
            });
        }
    }
}
