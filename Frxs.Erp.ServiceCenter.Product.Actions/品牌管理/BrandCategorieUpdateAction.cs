using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:23:23
 * *******************************************************/
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 更新品牌分类
    /// </summary>
    [ActionName("BrandCategorie.Update")]
    public class BrandCategorieUpdateAction : ActionBase<BrandCategorieUpdateAction.BrandCategorieUpdateActionRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BrandCategorieUpdateActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 品牌ID
            /// </summary>
            public int BrandId { get; set; }

            /// <summary>
            /// 命名名称
            /// </summary>
            [Required]
            [StringLength(50)]
            public string BrandName { get; set; }

            /// <summary>
            /// 品牌LOGO
            /// </summary>
            [StringLength(500)]
            public string Logo { get; set; }

            /// <summary>
            /// 给个修改数据的机会
            /// </summary>
            public override void BeforeValid()
            {
                this.Logo = this.Logo ?? string.Empty;
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //先获取
            IBrandCategoriesDAO iBrandCategories = DALFactory.GetLazyInstance<IBrandCategoriesDAO>();
            var brandCategorie = iBrandCategories.GetModel(this.RequestDto.BrandId);
            if (brandCategorie.IsNull())
            {
                return this.ErrorActionResult("分类ID：{0}不存在".With(this.RequestDto.BrandId));
            }

            //修改字段
            brandCategorie.BrandName = this.RequestDto.BrandName;
            brandCategorie.Logo = this.RequestDto.Logo;

            //判断是否重名
            bool isexistName = iBrandCategories.ExistsName(brandCategorie);
            if (isexistName)
            {
                return this.ErrorActionResult("存在有相同名称" + brandCategorie.BrandName + "的数据,不能保存");
            }

            //修改
            iBrandCategories.Edit(brandCategorie);

            //返回
            return this.SuccessActionResult();
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
