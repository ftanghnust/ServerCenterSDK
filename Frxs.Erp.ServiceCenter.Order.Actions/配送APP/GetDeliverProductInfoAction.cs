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
    ///  订单信息
    /// </summary>
    [ActionName("GetDeliverProductInfo")]
    public class GetDeliverProductInfotAction : ActionBase<GetDeliverProductInfotAction.GetDeliverProductInfotActionRequestDto, GetDeliverProductInfotAction.GetDeliverProductInfotActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class GetDeliverProductInfotActionRequestDto : RequestDtoBase
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
        public class GetDeliverProductInfotActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 单号
            /// </summary>
            public string OrderId { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public IList<ProductData> ProductData { get; set; }

        }


        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetDeliverProductInfotActionResponseDto> Execute()
        {
            GetDeliverProductInfotActionRequestDto reqDto = RequestDto;
            IList<ProductData> productData = SaleOrderPreBLO.GetProductData(reqDto.WID, reqDto.OrderId);
            var model = new GetDeliverProductInfotActionResponseDto();
            model.OrderId = reqDto.OrderId;

            foreach (var data in productData)
            {
                data.ProdcutDetailList = data.ProdcutDetailList.OrderBy(o => o.ShelfCode).ToList();
            }
            productData = productData.OrderBy(o => (string.IsNullOrEmpty(o.ShelfAreaCode) ? 999999 : int.Parse(o.ShelfAreaCode))).ToList();

            model.ProductData = productData;
            return SuccessActionResult(model);
        }
    }
}
