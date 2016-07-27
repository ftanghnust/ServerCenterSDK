using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:25:57
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 品牌分类列表
    /// </summary>
    [ActionName("BrandCategorie.Get"), ActionResultCache(BrandCategorieCacheKey.FRXS_BRAND_CATEGORIE_PATTERN_KEY)]
    public class BrandCategorieListAction : ActionBase<BrandCategorieListAction.BrandCategorieListActionRequestDto, ActionResultPagerData<Model.BrandCategories>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BrandCategorieListActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 品牌ID集合；
            /// 1.如果此参数设置为null，则查询出所有的品牌分类集合
            /// 2.如果指定了参数，那么值查询出指定的品牌分类集合
            /// </summary>
            public List<int> BrandIds { get; set; }

            /// <summary>
            /// 品牌名称(允许输入关键词)
            /// </summary>
            public string BrandName { get; set; }

            /// <summary>
            /// 是否含有LOGO（可空，不指定查询出所有的）
            /// </summary>
            public bool? HasLogo { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<BrandCategories>> Execute()
        {
            var srver = DALFactory.GetLazyInstance<IBrandCategorieQueryDAO>();
            srver.PageIndex = this.RequestDto.PageIndex;
            srver.PageSize = this.RequestDto.PageSize;
            srver.SearchParams = new Model.BrandCategorieQueryParams()
            {
                BrandIds = this.RequestDto.BrandIds,
                BrandName = this.RequestDto.BrandName,
                HasLogo = this.RequestDto.HasLogo
            };

            var model = new ActionResultPagerData<Model.BrandCategories>()
            {
                TotalRecords = srver.GetCount(),
                ItemList = srver.GetList().ToList()
            };

            return this.SuccessActionResult(model);
        }
    }
}
