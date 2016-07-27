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
    ///  查询对账单汇总信息
    /// </summary>
    [ActionName("GetSaleOrderTotalInfo")]
    public class GetSaleOrderTotalInfoAction : ActionBase<GetSaleOrderTotalInfoAction.GetSaleOrderTotalInfoActionRequestDto, GetSaleOrderTotalInfoAction.GetSaleOrderTotalInfoActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class GetSaleOrderTotalInfoActionRequestDto : RequestDtoBase
        {
            #region 查询参数
            
            /// <summary>
            /// 查询月份（yyyy-MM）
            /// </summary>
            [Required]
            public string SearchMonth { get; set; }
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
        public class GetSaleOrderTotalInfoActionResponseDto : ResponseDtoBase
        {

            /// <summary>
            /// 查询时间（格式：yyyy-MM-dd）
            /// </summary>
            public string PackingTime { get; set; }
            /// <summary>
            /// 总金额
            /// </summary>
            public decimal? TotalProductAmt { get; set; }
            /// <summary>
            /// 总积分
            /// </summary>
            public decimal? TotalPoint { get; set; }
            /// <summary>
            /// 总绩效分
            /// </summary>
            public decimal? TotalBasePoint { get; set; }
            /// <summary>
            /// 订单数
            /// </summary>
            public int TotalOrderCount { get; set; }

            /// <summary>
            /// 对账信息
            /// </summary>
            public IList<SaleDeliverOrderInfo> SaleOrderData { get; set; }
        }


        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetSaleOrderTotalInfoActionResponseDto> Execute()
        {
            GetSaleOrderTotalInfoActionRequestDto reqDto = RequestDto;

            IList<SaleDeliverOrderInfo> saleOrderData = SaleOrderPreBLO.GetSaleOrderTotalInfo(reqDto.SearchMonth, reqDto.EmpId, reqDto.WID, reqDto.LineIDs);
            string packingTime = RequestDto.SearchMonth;
            decimal totalProductAmt = 0;
            decimal totalPoint = 0;
            decimal totalBasePoint = 0;
            int totalOrderCount = 0;

            if (saleOrderData != null && saleOrderData.Count > 0)
            {
                foreach (SaleDeliverOrderInfo orderObj in saleOrderData)
                {
                    totalProductAmt += orderObj.TotalProductAmt.Value;
                    totalPoint += orderObj.TotalPoint.Value;
                    totalBasePoint += orderObj.TotalBasePoint.Value;
                    totalOrderCount += orderObj.TotalOrderCount.Value;
                }
            }


            return SuccessActionResult(new GetSaleOrderTotalInfoActionResponseDto()
            {
                TotalProductAmt = totalProductAmt,
                TotalPoint = totalPoint,
                TotalBasePoint = totalBasePoint,
                TotalOrderCount = totalOrderCount,
                SaleOrderData = saleOrderData,

            });
        }
    }
}
