using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 9:00:23
 * *******************************************************/
using System;
using System.ComponentModel.DataAnnotations;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 新增一个品牌分类；如果新建成功，返回值为建立好的品牌ID
    /// </summary>
    [ActionName("BrandCategorie.Add")]
    public class BrandCategorieAddAction : ActionBase<BrandCategorieAddAction.BrandCategorieAddActionRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class BrandCategorieAddActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 品牌名称，50汉字以内
            /// </summary>
            [Required]
            [StringLength(50)]
            public string BrandName { get; set; }

            /// <summary>
            /// 英文名称，50字以内
            /// </summary>
            [StringLength(50)]
            public string BrandEnName { get; set; }

            /// <summary>
            /// LOGO地址，255汉字以内
            /// </summary>
            [StringLength(255)]
            public string Logo { get; set; }

            /// <summary>
            /// 给个修改数据的机会
            /// </summary>
            public override void BeforeValid()
            {
                this.BrandEnName = this.BrandEnName ?? string.Empty;
                this.Logo = this.Logo ?? string.Empty;
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            //先判断是否有重复
            IBrandCategoriesDAO iBrandCategories = DALFactory.GetLazyInstance<IBrandCategoriesDAO>();
            var brandCategories = new Model.BrandCategories
                                                          {
                                                              BrandName = this.RequestDto.BrandName,
                                                              BrandEnName = this.RequestDto.BrandEnName,
                                                              Logo = this.RequestDto.Logo,
                                                              IsDeleted = 0,
                                                              DisplaySequence = 0,
                                                              ModifyTime = DateTime.Now,
                                                              CreateTime = DateTime.Now,
                                                              CreateUserID = this.RequestDto.UserId,
                                                              CreateUserName = this.RequestDto.UserName,
                                                              ModifyUserID = this.RequestDto.UserId,
                                                              ModifyUserName = this.RequestDto.UserName
                                                          };

            bool isexistName = iBrandCategories.ExistsName(brandCategories);
            if (isexistName)
            {
                return this.ErrorActionResult("存在有相同名称" + brandCategories.BrandName + "的数据,不能保存");
            }

            //添加数据
            var result = iBrandCategories.Save(brandCategories);

            //直接修改下排序索引使得排序索引与当前的ID值一致，方便后续上下调整位置
            brandCategories = iBrandCategories.GetModel(result);
            if (!brandCategories.IsNull())
            {
                brandCategories.DisplaySequence = result;
                iBrandCategories.Edit(brandCategories);
            }

            //直接返回当前分类ID
            return this.SuccessActionResult(result);
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
