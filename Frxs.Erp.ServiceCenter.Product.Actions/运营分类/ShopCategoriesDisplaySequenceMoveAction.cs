using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/11 16:37:20
 * *******************************************************/
using System;
using System.Transactions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 向上向下移动位置
    /// </summary>
    [ActionName("ShopCategories.DisplaySequence.Move")]
    public class ShopCategoriesDisplaySequenceMoveAction : ActionBase<ShopCategoriesDisplaySequenceMoveAction.ShopCategoriesDisplaySequenceMoveActionRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopCategoriesDisplaySequenceMoveActionRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 分类ID
            /// </summary>
            public int CategoryId { get; set; }

            /// <summary>
            /// 移动方向：DOWN（向下），UP（向上），不区分大小写
            /// </summary>
            [Required, In("DOWN", "UP")]
            public string Direction { get; set; }

            /// <summary>
            /// 改变下参数
            /// </summary>
            public override void BeforeValid()
            {
                if (!this.Direction.IsNullOrEmpty())
                {
                    this.Direction = this.Direction.ToUpper();
                }
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //当前分类对象
            IShopCategoriesDAO iShopCategories = DALFactory.GetLazyInstance<IShopCategoriesDAO>();
            var currentCategorie = iShopCategories.GetModel(this.RequestDto.CategoryId);
            if (currentCategorie.IsNull())
            {
                return this.ErrorActionResult("当前分类不存在");
            }

            //待交换的分类
            ShopCategories changeModel = null;

            //上移或者下移
            switch (this.RequestDto.Direction)
            {
                case "DOWN":
                    changeModel = iShopCategories.GetNextModel(this.RequestDto.CategoryId);
                    break;
                case "UP":
                    changeModel = iShopCategories.GetPreModel(this.RequestDto.CategoryId);
                    break;
            }

            //带交换的不存在
            if (changeModel.IsNull())
            {
                return this.ErrorActionResult("无法移动");
            }

            //保存当前节点的排序流水码
            int displaySequence = currentCategorie.DisplaySequence;

            //交换下流水码
            currentCategorie.DisplaySequence = changeModel.DisplaySequence;
            changeModel.DisplaySequence = displaySequence;

            //更新
            using (TransactionScope scope = new TransactionScope())
            {
                iShopCategories.Edit(currentCategorie);
                iShopCategories.Edit(changeModel);
                //提交
                scope.Complete();
            }


            //返回成功
            return this.SuccessActionResult();
        }

        /// <summary>
        /// 删除匹配到的缓存键
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            this.CacheManager.RemoveByPattern(ShopCategoriesCacheKey.FRXS_SHOP_CATEGORIES_PATTERN_KEY);
        }
    }
}
