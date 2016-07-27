using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:50:59
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 基本分类新增；添加成功后，返回分类ID
    /// </summary>
    [ActionName("Categories.Add")]
    public class CategoriesAddAction : ActionBase<CategoriesAddAction.CategoriesAddActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class CategoriesAddActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 分类编码
            /// </summary>
            [NotNull]
            public int? CategoryId { get; set; }

            /// <summary>
            /// 基本分类名称
            /// </summary>
            [Required, StringLength(50)]
            public string Name { get; set; }

            /// <summary>
            /// 父节点(当父节点为null的时候，表示添加的是根节点)
            /// </summary>
            public int? ParentCategoryId { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            //当前节点深度
            int depth = 0;

            //父节点信息
            Categories parentCategorie = null;

            //分类编号
            int categoryId = this.RequestDto.CategoryId.Value;

            //上传了父节点
            if (this.RequestDto.ParentCategoryId.HasValue)
            {
                parentCategorie = DALFactory.GetLazyInstance<ICategoriesDAO>().GetModel(this.RequestDto.ParentCategoryId.Value);
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

            //数据访问
            ICategoriesDAO iCategories = DALFactory.GetLazyInstance<ICategoriesDAO>();

            //检测是否存在
            var model = iCategories.GetModel(categoryId);
            if (!model.IsNull())
            {
                return this.ErrorActionResult("基本分类编码{0}已经存在".With(this.RequestDto.CategoryId.Value));
            }

            //检测是否存在了相同的名称
            var categorys = iCategories.GetList(new Dictionary<string, object>()
                .Append("Name", this.RequestDto.Name)
                .Append("IsDeleted", 0));
            if (!categorys.IsNull() && !categorys.IsEmpty())
            {
                return this.ErrorActionResult("名称 {0} 已经存在".With(this.RequestDto.Name));
            }

            if (depth == 0 && categoryId.ToString().Length != 1)
            {
                return this.ErrorActionResult("一级分类编码长度必须为1");
            }
            if (depth == 1 && categoryId.ToString().Length != 3)
            {
                return this.ErrorActionResult("二级分类编码长度必须为3");
            }

            if (depth == 2 && categoryId.ToString().Length != 5)
            {
                return this.ErrorActionResult("三级分类编码长度必须为5");
            }

            //录入到系统
            iCategories.Save(new Categories()
            {
                Name = this.RequestDto.Name,
                ParentCategoryId = parentCategorie.IsNull() ? -1 : parentCategorie.CategoryId,
                Depth = depth,
                DisplaySequence = 0,
                IsDeleted = 0,
                CreateTime = DateTime.Now,
                CreateUserID = this.RequestDto.UserId,
                CreateUserName = this.RequestDto.UserName,
                ModifyTime = DateTime.Now,
                ModifyUserID = this.RequestDto.UserId,
                ModifyUserName = this.RequestDto.UserName,
                CategoryId = categoryId
            });

            //更新排序流水码
            model = iCategories.GetModel(categoryId);
            model.DisplaySequence = categoryId;
            iCategories.Edit(model);

            //成功返回
            return this.SuccessActionResult(categoryId);

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
