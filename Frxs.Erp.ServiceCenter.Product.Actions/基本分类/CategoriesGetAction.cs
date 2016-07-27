using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:52:18
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 基本分类列表获取
    /// </summary>
    [ActionName("Categories.Get"), ActionResultCache(CategoriesCacheKey.FRXS_CATEGORIES_PATTERN_KEY)]
    public class CategoriesGetAction : ActionBase<CategoriesGetAction.CategoriesListActionRequestDto, List<Categories>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class CategoriesListActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 查询出分类集合，此参数如果设置为null，则查询出所有的分类
            /// </summary>
            public List<int> CategoryIds { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<Categories>> Execute()
        {
            var cats = DALFactory.GetLazyInstance<ICategoriesDAO>().GetList(this.RequestDto.CategoryIds).ToList();
            //加载全部的分类
            return this.SuccessActionResult(cats);
        }
    }
}
