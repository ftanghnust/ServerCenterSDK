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
    /// 更新商品规格属性
    /// </summary>
    [ActionName("Products.Attributes.Update")]
    public class ProductsAttributesUpdateAction : ActionBase<ProductsAttributesUpdateRequestDto, NullResponseDto>
    {
        /// <summary>
        ///执行逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //获取请求参数
            var dto = this.RequestDto;

            IList<ProductsAttributes> attrs = new List<ProductsAttributes>();
            ProductsAttributesPicture attributesPicture = new ProductsAttributesPicture();

            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(dto.ProductId), () =>
                                                            ProductsBLO.GetModel(dto.ProductId));
            if (null == product)
            {
                return this.ErrorActionResult("找不到商品");
            }
            var baseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId), () =>
                                                            BaseProductsBLO.GetModel(product.BaseProductId, false));
            if (null == baseProduct)
            {
                return this.ErrorActionResult("找不到母商品");
            }

            if (baseProduct.IsMutiAttribute != dto.IsMutiAttribute)
            {
                if (baseProduct.IsBaseProductId == 1)
                {
                    if (dto.IsMutiAttribute == 1)
                    {
                        if (product.BaseProductId != product.ProductId)
                        {
                            return this.ErrorActionResult("不允许将无规格商品转换有多规格商品");
                        }
                        else
                        {
                            var allProducts = ProductsBLO.GetBaseProductChildren(baseProduct.BaseProductId);
                            if (allProducts != null && allProducts.Count > 1)
                            {
                                return this.ErrorActionResult("商品母商品下包含其他子商品，不允许将无规格商品转换为多规格商品");
                            }
                        }
                    }
                    else
                    {
                        if (product.BaseProductId != product.ProductId)
                        {
                            return this.ErrorActionResult("不允许将多规格商品转换为无规格商品");
                        }
                        else
                        {
                            var allProducts = ProductsBLO.GetBaseProductChildren(baseProduct.BaseProductId);
                            if (allProducts != null && allProducts.Count > 1)
                            {
                                return this.ErrorActionResult("商品母商品下包含其他子商品，不允许将多规格商品转换为无规格商品");
                            }
                        }
                    }
                }
            }


            if (dto.IsMutiAttribute == 1)
            {
                if (dto.ProductsAttributes == null)
                {
                    return this.ErrorActionResult("请设置规格属性");
                }
                //属性规格集合
                foreach (var item in dto.ProductsAttributes)
                {
                    var tmpCount = dto.ProductsAttributes.Count(x => x.AttributeId == item.AttributeId);
                    if (tmpCount > 1)
                    {
                        return this.ErrorActionResult("存在重复的规格");
                    }
                    attrs.Add(new ProductsAttributes()
                    {
                        AttributeId = item.AttributeId,
                        AttributeName = item.AttributeName,
                        ModifyTime = DateTime.Now,
                        ModifyUserID = dto.UserId,
                        ModifyUserName = dto.UserName,
                        ProductId = dto.ProductId,
                        ValuesId = item.ValuesId,
                        ValueStr = item.ValueStr
                    });
                }

                #region 规格检查
                var result = ActionCommon.CheckProductAttribute(product, baseProduct, attrs, false);
                if (result.Flag != ActionResultFlag.SUCCESS)
                {
                    return ErrorActionResult(result.Info);
                }
                #endregion


                //规格图片
                attributesPicture = new ProductsAttributesPicture()
                {
                    CreateTime = DateTime.Now,
                    CreateUserID = dto.UserId,
                    CreateUserName = dto.UserName,
                    ProductId = dto.ProductId,
                    ImageUrl120x120 = dto.ProductsAttributesPicture.ImageUrl120X120,
                    ImageUrl200x200 = dto.ProductsAttributesPicture.ImageUrl200X200,
                    ImageUrl400x400 = dto.ProductsAttributesPicture.ImageUrl400X400,
                    ImageUrl60x60 = dto.ProductsAttributesPicture.ImageUrl60X60,
                    ImageUrlOrg = dto.ProductsAttributesPicture.ImageUrlOrg
                };

                var picCheckResult = ActionCommon.CheckAttributePicture(attributesPicture);
                if (picCheckResult.Flag != ActionResultFlag.SUCCESS)
                {
                    return ErrorActionResult(picCheckResult.Info);
                }
            }
            else
            {
                attrs = null;
            }


            //提交规格属性
            var backMsg = ProductsAttributesBLO.ProductsAttributesUpdate(dto.ProductId, attrs, attributesPicture, dto.IsMutiAttribute);

            //成功
            if (backMsg.IsSuccess)
            {
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.ProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTES_LIST_KEY.With(product.ProductId));
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTEPICTURE_KEY.With(product.ProductId));
                return SuccessActionResult(backMsg.Message, null);
            }

            return ErrorActionResult(backMsg.Message);

        }
    }
}
