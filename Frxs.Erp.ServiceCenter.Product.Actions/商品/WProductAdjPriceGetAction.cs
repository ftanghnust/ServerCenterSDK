using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/7 15:10:55
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.IOCFactory;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取调整单详情
    /// </summary>
    [ActionName("WProduct.AdjPrice.Get"), ActionResultCache(WProductAdjPriceCacheKey.FRXS_WPRODUCT_ADJPRICE_PATTERN_KEY)]
    public class WProductAdjPriceGetAction : ActionBase<WProductAdjPriceGetAction.WProductAdjPriceGetActionRequestDto, WProductAdjPriceGetAction.WProductAdjPriceGetActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductAdjPriceGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 调价单编号
            /// </summary>
            public int AdjID { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.WID <= 0) yield return new RequestDtoValidatorResultError("WID");
                if (this.AdjID <= 0) yield return new RequestDtoValidatorResultError("AdjID");
            }

        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class WProductAdjPriceGetActionResponseDto
        {
            /// <summary>
            /// 调价单详情
            /// </summary>
            public Model.WProductAdjPrice WProductAdjPrice { get; set; }

            /// <summary>
            /// 调价单明细
            /// </summary>
            public List<Model.WProductAdjPriceDetailsExt> Details { get; set; }

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductAdjPriceGetActionResponseDto> Execute()
        {
            //获取调价单详情
            var wproductAdjPrice =
                DALFactory.GetLazyInstance<IWProductAdjPriceDAO>()
                    .GetModel(new Dictionary<string, object>().Append("WID", this.RequestDto.WID)
                        .Append("AdjID", this.RequestDto.AdjID));

            //调价单为空
            if (wproductAdjPrice.IsNull())
            {
                return this.ErrorActionResult("调价单不存在");
            }

            //获取明细
            var details =
                DALFactory.GetLazyInstance<IWProductAdjPriceDetailsDAO>()
                    .GetWProductAdjPriceDetails(this.RequestDto.AdjID);

            //调价单对象
            var model = new WProductAdjPriceGetActionResponseDto()
            {
                WProductAdjPrice = wproductAdjPrice,
                Details = details.ToList()
            };

            //返回
            return this.SuccessActionResult(model);
        }
    }
}
