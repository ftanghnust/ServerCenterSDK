﻿/*********************************************************
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
    ///  订单信息
    /// </summary>
    [ActionName("GetDeliverOrderInfo")]
    public class GetDeliverOrderInfotAction : ActionBase<GetDeliverOrderInfotAction.GetDeliverOrderInfotActionRequestDto, GetDeliverOrderInfotAction.GetDeliverOrderInfotActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class GetDeliverOrderInfotActionRequestDto : RequestDtoBase
        {
            #region 查询参数




            /// <summary>
            /// 仓库ID
            /// </summary>
            [Required]

            public string WID { get; set; }

            /// <summary>
            /// 订单编号
            /// </summary>
            [Required]
            public string OrderId { get; set; }
            #endregion

        }

        /// <summary>
        /// 接口调用输出
        /// </summary>
        public class GetDeliverOrderInfotActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 单号
            /// </summary>
            public string OrderId { get; set; }

            /// <summary>
            /// 下单时间
            /// </summary>
            public DateTime OrderDate { get; set; }

            /// <summary>
            /// 流水号
            /// </summary>
            public int StationNumber { get; set; }

            /// <summary>
            /// 订单数量
            /// </summary>
            public decimal SaleQty { get; set; }

            /// <summary>
            /// 商品金额  对应 saleOrderPre.TotalProductAmt
            /// </summary>
            public decimal PayAmount { get; set; }

            /// <summary>
            /// 门店积分
            /// </summary>
            public decimal TotalPoint { get; set; }

            /// <summary>
            /// 周转箱
            /// </summary>
            public int Package1Qty { get; set; }

            /// <summary>
            /// 纸箱数
            /// </summary>
            public int Package2Qty { get; set; }

            /// <summary>
            /// 易碎品
            /// </summary>
            public int Package3Qty { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Remark { get; set; }


        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetDeliverOrderInfotActionResponseDto> Execute()
        {
            GetDeliverOrderInfotActionRequestDto reqDto = RequestDto;

            DeliverOrderInfo deliverOrderInfo = SaleOrderPreBLO.GetDeliverOrderInfo(reqDto.OrderId, reqDto.WID);
          
            return SuccessActionResult(new GetDeliverOrderInfotActionResponseDto()
            {
                OrderId = deliverOrderInfo.OrderId,
                OrderDate = deliverOrderInfo.OrderDate,
                Package1Qty = deliverOrderInfo.Package1Qty,
                Package2Qty = deliverOrderInfo.Package2Qty,
                Package3Qty = deliverOrderInfo.Package3Qty,
                PayAmount = deliverOrderInfo.PayAmount,
                Remark = deliverOrderInfo.Remark,
                SaleQty = deliverOrderInfo.SaleQty,
                StationNumber = deliverOrderInfo.StationNumber,
                TotalPoint = deliverOrderInfo.TotalPoint

            });
        }
    }
}
