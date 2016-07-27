/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/29 14:36:42
 * *******************************************************/
using System.Collections.Generic;
using Frxs.Platform.IOCFactory;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 仓库商品价格调整表 删除，返回删除成功的条数
    /// 同步删除 仓库商品价格调整明细表 WProductAdjPriceDetails
    /// </summary>
    [ActionName("WProduct.AdjustPrice.Del")]
    public class WProductAdjPriceDelAction : ActionBase<WProductAdjPriceDelAction.WProductAdjPriceDelActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductAdjPriceDelActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 调价单编号
            /// </summary>
            [Required]
            public List<int> AdjIds { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            //执行的成功数
            int success = 0;

            //消息详细
            List<string> errmessage = new List<string>();

            //条件单访问接口
            var wproductAdjPriceDao = DALFactory.GetLazyInstance<IWProductAdjPriceDAO>();

            //循环删除
            foreach (var item in this.RequestDto.AdjIds)
            {

                //获取调价单
                var ajdPrice = wproductAdjPriceDao.GetModel(item);
                if (ajdPrice.IsNull())
                {
                    continue;
                }

                //只有待确认的条件单才能删除
                if (ajdPrice.Status != 0)
                {
                    errmessage.Add("调价单：{0}状态错误".With(item));
                    continue;
                }

                //删除调价表
                wproductAdjPriceDao.Delete(item);

                //成功数+1
                success++;
            }

            //输出成功
            if (this.RequestDto.AdjIds.Count == success)
            {
                return this.SuccessActionResult(success);
            }
            else
            {
                return this.ErrorActionResult(string.Join("|", errmessage.ToArray()), success);
            }
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(WProductAdjPriceCacheKey.FRXS_WPRODUCT_ADJPRICE_PATTERN_KEY);
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
        }
    }
}
