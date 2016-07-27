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
    ///  商品明细(用于后台)
    /// </summary>
    [ActionName("GetDeliverProductInfoExt")]
    public class GetDeliverProductInfoExttAction : ActionBase<GetDeliverProductInfoExttAction.GetDeliverProductInfoExtActionRequestDto, GetDeliverProductInfoExttAction.GetDeliverProductInfoExtActionResponseDto>
    {
        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class GetDeliverProductInfoExtActionRequestDto : RequestDtoBase
        {
            #region 查询参数


            /// <summary>
            /// WID
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
        public class GetDeliverProductInfoExtActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 单号
            /// </summary>
            public string OrderId { get; set; }

            /// <summary>
            /// 
            /// </summary>

            public IList<ProductDetailExt> ProductData { get; set; }
            
        }


        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetDeliverProductInfoExtActionResponseDto> Execute()
        {
            GetDeliverProductInfoExtActionRequestDto reqDto = RequestDto;
            IList<ProductDetailExt> productData = SaleOrderPreBLO.GetProductDataExt(reqDto.WID, reqDto.OrderId);

            return SuccessActionResult(new GetDeliverProductInfoExtActionResponseDto()
          {
              OrderId = reqDto.OrderId,
              ProductData = productData
          });
        }
    }
}
