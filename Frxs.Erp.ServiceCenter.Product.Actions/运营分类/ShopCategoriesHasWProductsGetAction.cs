using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/31 13:57:23
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.IOCFactory;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取所有有仓库商品的运营分类;在仓库中没有商品信息的运营分类不会检索处理
    /// </summary>
    [ActionName("ShopCategories.HasWProducts.Get")]
    public class ShopCategoriesHasWProductsGetAction : ActionBase<ShopCategoriesHasWProductsGetAction.ShopCategoriesHasWProductGetActionRequestDto, List<ShopCategories>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ShopCategoriesHasWProductGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库ID
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 门店ID
            /// </summary>
            public int ShopId { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ShopCategories>> Execute()
        {
            var cats = DALFactory.GetLazyInstance<IShopCategoriesDAO>()
                    .ShopCategoriesHasWProductsGet(this.RequestDto.WID)
                    .OrderBy(o => o.DisplaySequence)
                    .ToList();
            return this.SuccessActionResult(cats);
        }
    }
}
