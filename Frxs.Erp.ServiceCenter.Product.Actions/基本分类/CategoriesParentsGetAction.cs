using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/22 9:42:17
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取基本分类的祖父节点；按照根节点到叶子节点排序
    /// </summary>
    [ActionName("Categories.Parents.Get"), ActionResultCache(CategoriesCacheKey.FRXS_CATEGORIES_PATTERN_KEY)]
    public class CategoriesParentsGetAction : ActionBase<CategoriesParentsGetAction.CategoriesParentActionRequestDto, List<Categories>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class CategoriesParentActionRequestDto : RequestDtoBase
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
        public override ActionResult<List<Categories>> Execute()
        {
            var cats = DALFactory.GetLazyInstance<ICategoriesDAO>().GetParents(this.RequestDto.CategoryId).ToList();
            return this.SuccessActionResult(cats);
        }
    }
}
