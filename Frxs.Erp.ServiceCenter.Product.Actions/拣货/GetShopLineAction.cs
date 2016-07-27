/*********************************************************
 * FRXS 小马哥 2016/5/4 16:59:52
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取门店所属线路
    /// </summary>
    [ActionName("GetShopLineAction")]
    public class GetShopLineAction : ActionBase<Frxs.Erp.ServiceCenter.Product.Actions.GetShopLineAction.GetShopLineActionRequestDto, Frxs.Erp.ServiceCenter.Product.Actions.GetShopLineAction.GetShopLineActionResponseDto>
    {
        /// <summary>
        /// 传入参数
        /// </summary>
        public class GetShopLineActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 门店编号
            /// </summary>
            [Required]
            public int ShopID { get; set; }
        }

        /// <summary>
        /// 输出参数
        /// </summary>
        public class GetShopLineActionResponseDto : ResponseDtoBase
        {
            /// <summary>
            /// 线路编号
            /// </summary>
            public int LineID { get; set; }

            /// <summary>
            /// 线路编号
            /// </summary>
            public string LineCode { get; set; }

            /// <summary>
            /// 线路名称
            /// </summary>
            public string LineName { get; set; }
        }

        /// <summary>
        /// 执行逻辑操作
        /// </summary>
        /// <returns></returns>
        public override ActionResult<GetShopLineAction.GetShopLineActionResponseDto> Execute()
        {
            Model.WarehouseLine model = ShopBLO.GetShopLine(RequestDto.ShopID);
            if (model != null)
            {
                return SuccessActionResult(new GetShopLineActionResponseDto()
                {
                    LineID = model.LineID,
                    LineCode = model.LineCode,
                    LineName = model.LineName
                });
            }
            else
            {
                return ErrorActionResult("为找到该门店所属的线路信息");
            }
        }
    }
}
