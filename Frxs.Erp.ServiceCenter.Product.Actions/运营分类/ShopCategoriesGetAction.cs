using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:49:20
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 运营分类列表
    /// </summary>
    [ActionName("ShopCategories.Get"), ActionResultCache(ShopCategoriesCacheKey.FRXS_SHOP_CATEGORIES_PATTERN_KEY)]
    public class ShopCategoriesGetAction : ActionBase<ShopCategoriesGetAction.ShopCategoriesListRequestDto, List<ShopCategories>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopCategoriesListRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 获取指定分类集合ID，如果上送值为null，则返回所有集合
            /// </summary>
            public List<int> CategoryIds { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ShopCategories>> Execute()
        {
            var cats = DALFactory.GetLazyInstance<IShopCategoriesDAO>().GetList(this.RequestDto.CategoryIds).ToList();
            return this.SuccessActionResult(cats);
        }
    }
}
