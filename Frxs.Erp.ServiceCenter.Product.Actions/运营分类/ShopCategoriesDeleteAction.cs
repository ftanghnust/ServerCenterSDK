using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using System.Linq;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:47:32
 * *******************************************************/
using System.Collections.Generic;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 删除运营分类
    /// </summary>
    [ActionName("ShopCategories.Delete")]
    public class ShopCategoriesDeleteAction : ActionBase<ShopCategoriesDeleteAction.ShopCategoriesDeleteActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopCategoriesDeleteActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 待删除的分类,由于界面的改动，没有批量删除功能，但是为了保证接口稳定，入参不改变
            /// </summary>
            [Required]
            public List<int> CategoryIds { get; set; }

            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.CategoryIds.Count > 1 || this.CategoryIds.IsEmpty())
                {
                    yield return new RequestDtoValidatorResultError("CategoryIds", "请只输入一个分类ID");
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {

            var shopCategoriesDao = DALFactory.GetLazyInstance<IShopCategoriesDAO>();

            var categoryId = this.RequestDto.CategoryIds[0];

            //子节点
            var childs = shopCategoriesDao.GetChilds(categoryId).ToList();

            if (childs.Any())
            {
                return this.ErrorActionResult("含有子分类不能删除");
            }

            //是否被商品引用
            var isReferenceByProduct = shopCategoriesDao.IsReferenceByProduct(categoryId);
            if (isReferenceByProduct)
            {
                return this.ErrorActionResult("分类被商品引用，不能删除");
            }

            shopCategoriesDao.LogicDelete(categoryId);

            //下面有子节点
            return this.SuccessActionResult(1);
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(ShopCategoriesCacheKey.FRXS_SHOP_CATEGORIES_PATTERN_KEY);
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
        }
    }
}
