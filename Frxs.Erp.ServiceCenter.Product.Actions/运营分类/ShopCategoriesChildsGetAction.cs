using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 10:55:28
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取运营分类子分类
    /// </summary>
    [ActionName("ShopCategories.Childs.Get"), ActionResultCache(ShopCategoriesCacheKey.FRXS_SHOP_CATEGORIES_PATTERN_KEY)]
    public class ShopCategoriesChildsGetAction : ActionBase<ShopCategoriesChildsGetAction.ShopCategoriesChildsGetActionRequestDto, List<ShopCategories>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopCategoriesChildsGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 分类ID；注意：如果不上送此值，则返回运营分类【根节点】集合
            /// </summary>
            public int? CategoryId { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ShopCategories>> Execute()
        {
            //未指定获取根节点
            var model = !this.RequestDto.CategoryId.HasValue
                  ? DALFactory.GetLazyInstance<IShopCategoriesDAO>()
                      .GetList(new Dictionary<string, object>().Append("ParentCategoryId", -1))
                      .OrderBy(o => o.DisplaySequence)
                      .ToList()
                  : DALFactory.GetLazyInstance<IShopCategoriesDAO>().GetChilds(this.RequestDto.CategoryId.Value).ToList();

            //子节点
            return this.SuccessActionResult(model);
        }
    }
}
