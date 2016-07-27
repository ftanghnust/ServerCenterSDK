using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 10:48:58
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取分类子类集合；返回分类对象集合（按照排序索引优先级排序）
    /// </summary>
    [ActionName("Categories.Childs.Get"), ActionResultCache(CategoriesCacheKey.FRXS_CATEGORIES_PATTERN_KEY)]
    public class CategoriesChildsGetAction : ActionBase<CategoriesChildsGetAction.CategoriesChildsGetActionRequestDto, List<Categories>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class CategoriesChildsGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 分类ID；注意：如果为空则直接返回【根节点】集合
            /// </summary>
            public int? CategoryId { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<Categories>> Execute()
        {
            var model = !this.RequestDto.CategoryId.HasValue
                   ? DALFactory.GetLazyInstance<ICategoriesDAO>()
                       .GetList(new Dictionary<string, object>().Append("ParentCategoryId", -1))
                       .OrderBy(o => o.DisplaySequence)
                       .ToList()
                   : DALFactory.GetLazyInstance<ICategoriesDAO>().GetChilds(this.RequestDto.CategoryId.Value).ToList();

            //根节点
            return this.SuccessActionResult(model);
        }
    }
}
