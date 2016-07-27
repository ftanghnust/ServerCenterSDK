using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{

    /// <summary>
    /// 根据商品编号获取到对应的母商品ERP编码 信息
    /// </summary>
    [ActionName("BaseProduct.GetSKU")]
    public class BaseProductSkuGetAction : ActionBase<BaseProductSkuGetRequestAction, string>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {
            //反序列化
            var obj = this.RequestDto;
            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(obj.ProductId), ()
                => ProductsBLO.ProductsGet(obj.ProductId));
            if (null == product)
            {
                return ErrorActionResult("没有找到传入子商品的信息");
            }

            var baseProductSub = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.BaseProductId), ()
            => ProductsBLO.ProductsGet(product.BaseProductId));
            if (baseProductSub == null)
            {
                return this.ErrorActionResult("没有找到子商品相关的母商品信息");
            }

            return SuccessActionResult(baseProductSub.SKU);
        }
    }
}
