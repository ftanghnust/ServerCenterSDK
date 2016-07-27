using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:51:25
 * *******************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 基本分类更新
    /// </summary>
    [ActionName("Categories.Update")]
    public class CategoriesUpdateAction : ActionBase<CategoriesUpdateAction.CategoriesUpdateActionRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class CategoriesUpdateActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 运营分类
            /// </summary>
            public int CategoryId { get; set; }

            /// <summary>
            /// 基本分类名称
            /// </summary>
            [Required, StringLength(50)]
            public string Name { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //先校验是否存在
            ICategoriesDAO iCategories = DALFactory.GetLazyInstance<ICategoriesDAO>();
            var model = iCategories.GetModel(this.RequestDto.CategoryId);
            if (model.IsNull())
            {
                return this.ErrorActionResult("分类信息不存在");
            }

            //检测是否存在了相同的名称
            var category = iCategories.GetModel(new Dictionary<string, object>()
                .Append("Name", this.RequestDto.Name)
                .Append("IsDeleted", 0));
            if (!category.IsNull() && category.CategoryId != this.RequestDto.CategoryId)
            {
                return this.ErrorActionResult("名称 {0} 已经存在".With(this.RequestDto.Name));
            }

            //修改分类名称
            model.Name = this.RequestDto.Name.Trim();
            iCategories.Edit(model);

            //编辑成功
            return this.SuccessActionResult();
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(CategoriesCacheKey.FRXS_CATEGORIES_PATTERN_KEY);
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
        }
    }
}
