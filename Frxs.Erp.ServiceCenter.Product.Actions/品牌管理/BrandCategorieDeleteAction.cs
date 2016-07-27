using System.Transactions;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:16:36
 * *******************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 删除品牌分类；删除成功后，返回删除成功的品牌ID集合
    /// </summary>
    [ActionName("BrandCategorie.Delete")]
    public class BrandCategorieDeleteAction : ActionBase<BrandCategorieDeleteAction.BrandCategorieDeleteActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BrandCategorieDeleteActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 待删除的品牌ID集合
            /// </summary>
            [Required]
            public List<int> BrandIds { get; set; }

            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.BrandIds.IsEmpty())
                {
                    yield return new RequestDtoValidatorResultError("BrandIds");
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            //删除成功数
            int result = 0;

            foreach (var brandId in this.RequestDto.BrandIds)
            {
                var productName = DALFactory.GetLazyInstance<IBrandCategoriesDAO>().UsedName(brandId);
                if (!string.IsNullOrEmpty(productName))
                {
                    string msg = "删除失败：商品[" + productName + "]关联了该品牌";
                    return ErrorActionResult(msg, result);
                }
            }

            //更新
            using (TransactionScope scope = new TransactionScope())
            {
                this.RequestDto.BrandIds.ForEach(brandId =>
                                                     {
                                                         result += DALFactory.GetLazyInstance<IBrandCategoriesDAO>().LogicDelete(brandId);
                                                     });
                //提交
                scope.Complete();
            }

            //返回
            return this.SuccessActionResult(result);
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(BrandCategorieCacheKey.FRXS_BRAND_CATEGORIE_PATTERN_KEY);
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
        }
    }
}
