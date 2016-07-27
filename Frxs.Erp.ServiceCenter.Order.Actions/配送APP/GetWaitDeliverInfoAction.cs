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
    ///  查询等待配送信息
    /// </summary>
    [ActionName("GetWaitDeliverInfo")]
    public class GetWaitDeliverInfotAction : ActionBase<GetWaitDeliverInfotAction.GetWaitDeliverInfotActionRequestDto, GetWaitDeliverInfotAction.GetWaitDeliverInfotActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class GetWaitDeliverInfotActionRequestDto : RequestDtoBase
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

            /// <summary>
            /// 线路集合ID
            /// </summary>
            [Required]
            public string LineIDs { get; set; }
            #endregion

        }

        /// <summary>
        /// 接口调用输出
        /// </summary>
        public class GetWaitDeliverInfotActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 数据总条数
            /// </summary>
            public int TotalCount { get; set; }
            /// <summary>
            /// 等待配送数
            /// </summary>
            public int WaitDeliverCount { get; set; }
            /// <summary>
            /// 正在拣货数
            /// </summary>
            public int PickingCount { get; set; }

            /// <summary>
            /// 等待配送的门店集合
            /// </summary>
            public IList<WaitDeliverData> WaitDeliverData { get; set; }


            /// <summary>
            /// 正在拣货门店集合
            /// </summary>
            public IList<PickingData> PickingData { get; set; }
        }


        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetWaitDeliverInfotActionResponseDto> Execute()
        {
            GetWaitDeliverInfotActionRequestDto reqDto = RequestDto;
        
            IList<WaitDeliverData> waitDeliverData = SaleOrderPreBLO.GetWaitDeliverData("", "", reqDto.WID, reqDto.LineIDs, "5");
            IList<PickingData> pickingData = SaleOrderPreBLO.GetPickingData(reqDto.WID, reqDto.LineIDs);
            int pickingCount = 0;
            int waitDeliverCount = 0;
            if (waitDeliverData != null && waitDeliverData.Count > 0)
            {
                waitDeliverCount = waitDeliverData.Count;
            }
            if (pickingData != null && pickingData.Count > 0)
            {
                pickingCount = pickingData.Count;
            }
            return SuccessActionResult(new GetWaitDeliverInfotActionResponseDto()
            {
                TotalCount = waitDeliverCount + pickingCount,
                PickingCount = pickingCount,
                WaitDeliverCount = waitDeliverCount,
                PickingData = pickingData,
                WaitDeliverData = waitDeliverData
            });
        }
    }
}
