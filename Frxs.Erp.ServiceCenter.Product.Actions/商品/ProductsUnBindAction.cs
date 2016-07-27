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
    /// 将商品从母商品上解绑
    /// </summary>
    [ActionName("Product.UnBind")]
    public class ProductsUnBindAction : ActionBase<ProductsBindToBaseProductRequestDto, NullResponseDto>
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
                    return ErrorActionResult("商品本身为母商品，且母商品下还包含其他的子商品，不能解绑");
                }
            }

            product.ModifyUserID = obj.UserId;
            product.ModifyUserName = obj.UserName;
            product.ModifyTime = DateTime.Now;

            BaseProductsBLO.UnBindToBaseProduct(product);
            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.ProductId));
            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId));
            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTPICTUREDETAILS_LIST_KEY.With(product.ImageProductId));
            return SuccessActionResult("解绑母商品成功", null);


        }
    }
}
