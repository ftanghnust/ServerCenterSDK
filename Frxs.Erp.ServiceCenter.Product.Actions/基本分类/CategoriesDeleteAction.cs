using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using System.Linq;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:51:48
 * *******************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 基本分类删除
    /// </summary>
    [ActionName("Categories.Delete")]
    public class CategoriesDeleteAction : ActionBase<CategoriesDeleteAction.CategoriesDeleteActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class CategoriesDeleteActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 待删除的分类,由于界面的改动，没有批量删除功能，但是为了保证接口稳定，入参不改变
            /// </summary>
            [Required]
            public List<int> CategoryIds { get; set; }

            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.CategoryIds.Count > 1 || this.CategoryIds.IsEmpty())
                {
                    yield return new RequestDtoValidatorResultError("CategoryIds", "请只输入一个分类ID");
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            var categoriesDao = DALFactory.GetLazyInstance<ICategoriesDAO>();

            var categoryId = this.RequestDto.CategoryIds[0];

            //检测下面的子节点
            var childs = categoriesDao.GetChilds(categoryId).ToList();
            if (childs.Any())
            {
                return this.ErrorActionResult(this.L("Exist_Sub_Cats", "含有子分类不能删除"));
            }

            //是否被商品引用
            var isReferenceByProduct = categoriesDao.IsReferenceByProduct(categoryId);
            if (isReferenceByProduct)
            {
                return this.ErrorActionResult(this.L("Cat_Is_Refed", "分类被商品引用，不能删除"));
            }

            //删除
            categoriesDao.LogicDelete(categoryId);

            //删除成功
            return this.SuccessActionResult(1);
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
