using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 创建母商品
    /// </summary>
    [ActionName("BaseProduct.AddToBind")]
    public class BaseProductCreateAndBindAction : ActionBase<BaseProductCreateAndBindRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑方法
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //反序列化
            var obj = this.RequestDto;
            //if (obj.ProductId <= 0)
            //{
            //    return ErrorActionResult("没有传入商品信息");
            //}

            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(obj.ProductId), ()
                => ProductsBLO.ProductsGet(obj.ProductId));

            if (null == product)
            {
                return ErrorActionResult("没有找到这个商品信息");
            }

            var baseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId), () => BaseProductsBLO.GetModel(product.BaseProductId, false));
            if (null == baseProduct)
            {
                return ErrorActionResult("找不到商品的原有母商品信息，无法创建新的母商品");
            }

            baseProduct.BaseProductId = product.ProductId;
            baseProduct.ProductBaseName = string.IsNullOrEmpty(obj.BaseProductName) ? "" : obj.BaseProductName.Trim();
            baseProduct.CreateTime = DateTime.Now;
            baseProduct.CreateUserID = obj.UserId;
            baseProduct.CreateUserName = obj.UserName;
            baseProduct.ModifyTime = DateTime.Now;
            baseProduct.ModifyUserID = obj.UserId;
            baseProduct.ModifyUserName = obj.UserName;
            baseProduct.IsBaseProductId = 1;

            product.BaseProductId = baseProduct.BaseProductId;
            product.ModifyTime = DateTime.Now;
            product.ModifyUserID = obj.UserId;
            product.ModifyUserName = obj.UserName;

            if (BaseProductsBLO.ExistProductBaseName(baseProduct))
            {
                return ErrorActionResult("母商品名已被使用");
            }

            var data = ProductsBLO.ProductEdit(baseProduct, product, null, null, null, null, null);
            if (!data.IsSuccess)
            {
                return ErrorActionResult(data.Message);
            }

            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.ProductId));
            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId));
            return SuccessActionResult();

        }
    }
}
