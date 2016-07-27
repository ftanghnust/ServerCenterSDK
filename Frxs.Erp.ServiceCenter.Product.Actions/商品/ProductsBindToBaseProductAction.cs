using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 绑定商品
    /// </summary>
    [ActionName("Product.Bind")]
    public class ProductsBindToBaseProductAction : ActionBase<ProductsBindToBaseProductRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //反序列化
            var obj = this.RequestDto;
            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(obj.ProductId), ()
                    => ProductsBLO.ProductsGet(obj.ProductId));

            if (!obj.ProductIdAddto.HasValue)
            {
                return ErrorActionResult("没有指定母商品编号");
            }

            var oldProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(obj.ProductIdAddto.Value), ()
                => ProductsBLO.ProductsGet(obj.ProductIdAddto.Value));
            if (oldProduct == null)
            {
                return ErrorActionResult("没有指定母商品编号");
            }
            var newBaseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(oldProduct.BaseProductId), () =>
                                                    BaseProductsBLO.GetModel(oldProduct.BaseProductId, false));
            if (newBaseProduct.IsBaseProductId == 0)
            {
                return ErrorActionResult("指定的母商品不能包含子商品");
            }

            var oldBaseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId), () =>
                                                    BaseProductsBLO.GetModel(product.BaseProductId, false));

            //商品本身是母商品时，如果还有其他子商品，不能解除绑定
            if (product.ProductId == product.BaseProductId)
            {
                var products = ProductsBLO.ProductsGetByBaseProductId(product.BaseProductId);
                var bFlag = false;
                if (products != null)
                {
                    foreach (var productse in products)
                    {
                        if (productse.ProductId != product.ProductId)
                        {
                            bFlag = true;
                            break;
                        }
                    }
                }
                if (bFlag)
                {
                    return ErrorActionResult("商品本身为母商品，且母商品下还包含其他的子商品，不能再绑定到新的母商品");
                }
            }

            if (oldBaseProduct.ShopCategoryId1 == newBaseProduct.ShopCategoryId1
                && oldBaseProduct.ShopCategoryId2 == newBaseProduct.ShopCategoryId2)
            {
                var newAttrs = ProductsAttributesBLO.ProductsAttributesGet(product.ProductId);
                if (!(newAttrs != null && newAttrs.Count > 0))
                {
                    return ErrorActionResult("指定规格后的商品才能进行绑定");
                }

                var result = ActionCommon.CheckProductAttribute(product, newBaseProduct, newAttrs, false);
                if (result.Flag != ActionResultFlag.SUCCESS)
                {
                    return ErrorActionResult(result.Info);
                }

                product.ModifyUserID = obj.UserId;
                product.ModifyUserName = obj.UserName;
                product.ModifyTime = DateTime.Now;

                BaseProductsBLO.BindToBaseProduct(new BaseProducts() { BaseProductId = oldProduct.BaseProductId }, product);
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.ProductId));
            }
            else
            {
                return ErrorActionResult("指定的母商品与原有商品的运营分类不一致，无法绑定");
            }

            return SuccessActionResult("绑定母商品成功", null);

        }
    }
}
