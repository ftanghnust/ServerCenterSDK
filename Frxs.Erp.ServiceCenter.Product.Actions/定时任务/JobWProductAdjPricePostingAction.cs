using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/23 15:56:31
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 调价单作业任务接口
    /// </summary>
    [ActionName("Job.WProductAdjPrice.Posting")]
    public class JobWProductAdjPricePostingAction : ActionBase<JobWProductAdjPricePostingAction.JobWProductAdjPricePostingActionRequestDto, int>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class JobWProductAdjPricePostingActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 调价单类型：0:采购(进货)价，1:配送(批发)价，2:费率及积分
            /// </summary>
            [NotNull, In(0, 1, 2)]
            public int? AdjType { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (!new int[] { 0, 1, 2 }.Any(o => o == this.AdjType.Value))
                {
                    yield return new RequestDtoValidatorResultError("调价单类型只能为：0,1,2");
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //执行作业
            var result = DALFactory.GetLazyInstance<IWProductAdjPriceDAO>().JobPosting(this.RequestDto.AdjType.Value);

            //失败
            if (result == -1)
            {
                return this.ErrorActionResult("作业失败，调价单类型错误");
            }

            //删除相关的缓存
            this.CacheManager.RemoveByPattern(WProductAdjPriceCacheKey.FRXS_WPRODUCT_ADJPRICE_PATTERN_KEY);
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);

            //成功
            return this.SuccessActionResult(result);
        }
    }
}
