using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:47:04
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 添加运营分类；添加成功后返回分类ID
    /// </summary>
    [ActionName("ShopCategories.Add")]
    public class ShopCategoriesAddAction : ActionBase<ShopCategoriesAddAction.ShopCategoriesAddActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopCategoriesAddActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 分类编码
            /// </summary>
            [NotNull]
            public int? CategoryId { get; set; }

            /// <summary>
            /// 运营分类名称
            /// </summary>
            [Required, StringLength(100)]
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
            /// 父节点ID，如果为null则将当前节点添加为根节点
            /// </summary>
            public int? ParentCategoryId { get; set; }

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
        public override ActionResult<int?> Execute()
        {
            //深度
            int depth = 0;

            //父节点信息
            ShopCategories parentCategorie = null;

            //分类编号
            int categoryId = this.RequestDto.CategoryId.Value;

            //上传了父节点
            IShopCategoriesDAO iShopCategories = DALFactory.GetLazyInstance<IShopCategoriesDAO>();
            if (this.RequestDto.ParentCategoryId.HasValue)
            {
                parentCategorie = iShopCategories.GetModel(this.RequestDto.ParentCategoryId.Value);
                if (parentCategorie.IsNull())
                {
                    return this.ErrorActionResult("父节点不存在");
                }
                //层级为当前父节点+1
                depth = parentCategorie.Depth + 1;

                if (depth > 2)
                {
                    return this.ErrorActionResult("最多只能加三级");
                }
            }

            //是否存在
            var model = iShopCategories.GetModel(categoryId);
            if (!model.IsNull())
            {
                return this.ErrorActionResult("运营分类编码{0}已经存在".With(categoryId));
            }

            //检测是否存在了相同的名称
            var categorys = iShopCategories.GetList(new Dictionary<string, object>()
                .Append("CategoryName", this.RequestDto.CategoryName)
                .Append("IsDeleted", 0));
            if (!categorys.IsNull() && !categorys.IsEmpty())
            {
                return this.ErrorActionResult("名称 {0} 已经存在".With(this.RequestDto.CategoryName));
            }

            //添加分类
            iShopCategories.Save(new ShopCategories()
            {
                CategoryId = categoryId,
                CategoryImage = this.RequestDto.CategoryImage,
                CategoryName = this.RequestDto.CategoryName,
                Depth = depth,
                ParentCategoryId = parentCategorie.IsNull() ? -1 : parentCategorie.CategoryId,
                PageHomeImage = this.RequestDto.PageHomeImage,
                DisplaySequence = 0,
                IsDeleted = 0,
                CreateTime = DateTime.Now,
                CreateUserID = this.RequestDto.UserId,
                CreateUserName = this.RequestDto.UserName,
                ModifyTime = DateTime.Now,
                ModifyUserID = this.RequestDto.UserId,
                ModifyUserName = this.RequestDto.UserName
            });

            //更新排序流水码
            model = iShopCategories.GetModel(categoryId);
            model.DisplaySequence = categoryId;
            iShopCategories.Edit(model);


            //成功返回
            return this.SuccessActionResult(categoryId);
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
