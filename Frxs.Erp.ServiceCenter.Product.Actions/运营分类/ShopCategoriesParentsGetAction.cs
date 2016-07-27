using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/22 10:02:38
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取运营分类的祖父节点；按照根节点到叶子节点排序
    /// </summary>
    [ActionName("ShopCategories.Parents.Get"), ActionResultCache(ShopCategoriesCacheKey.FRXS_SHOP_CATEGORIES_PATTERN_KEY)]
    public class ShopCategoriesParentsGetAction : ActionBase<ShopCategoriesParentsGetAction.ShopCategoriesParentsGetActionRequestDto, List<ShopCategories>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopCategoriesParentsGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 当前分类ID
            /// </summary>
            public int CategoryId { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ShopCategories>> Execute()
        {
            var cats = DALFactory.GetLazyInstance<IShopCategoriesDAO>().GetParents(this.RequestDto.CategoryId).ToList();
            return this.SuccessActionResult(cats);
        }
    }
}
