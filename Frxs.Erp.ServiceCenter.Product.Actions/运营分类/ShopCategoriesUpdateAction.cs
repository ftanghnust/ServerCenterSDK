using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:47:54
 * *******************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 更新运营分类
    /// </summary>
    [ActionName("ShopCategories.Update")]
    public class ShopCategoriesUpdateAction : ActionBase<ShopCategoriesUpdateAction.ShopCategoriesUpdateActionRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopCategoriesUpdateActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 分类ID
            /// </summary>
            public int CategoryId { get; set; }

            /// <summary>
            /// 运营分类名称
            /// </summary>
            [Required, StringLength(50)]
            public string CategoryName { get; set; }

            /// <summary>
            /// 分类图标
            /// </summary>
            [StringLength(500)]
            public string CategoryImage { get; set; }

            /// <summary>
            /// 分类图标
            /// </summary>
            [StringLength(500)]
            public string PageHomeImage { get; set; }

            /// <summary>
            /// 给个修改数据的机会
            /// </summary>
            public override void BeforeValid()
            {
                this.CategoryImage = this.CategoryImage ?? string.Empty;
                this.PageHomeImage = this.PageHomeImage ?? string.Empty;
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //获取实体对象
            IShopCategoriesDAO iShopCategories = DALFactory.GetLazyInstance<IShopCategoriesDAO>();
            var model = iShopCategories.GetModel(this.RequestDto.CategoryId);
            if (model.IsNull())
            {
                return this.ErrorActionResult("分类信息不存在");
            }

            //检测是否存在了相同的名称
            var category = iShopCategories.GetModel(new Dictionary<string, object>()
                .Append("CategoryName", this.RequestDto.CategoryName)
                .Append("IsDeleted", 0));
            if (!category.IsNull() && category.CategoryId != this.RequestDto.CategoryId)
            {
                return this.ErrorActionResult("名称 {0} 已经存在".With(this.RequestDto.CategoryName));
            }

            //修改
            model.CategoryName = this.RequestDto.CategoryName;
            model.CategoryImage = this.RequestDto.CategoryImage;
            model.PageHomeImage = this.RequestDto.PageHomeImage;
            iShopCategories.Edit(model);

            //返回
            return this.SuccessActionResult();
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
