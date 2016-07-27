/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/10 9:50:27
 * *******************************************************/

using System.Collections.Generic;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取一个商品所有的规格属性和规格图片信息
    /// </summary>
    [ActionName("Products.Attributes.Get")]
    public class ProductsAttributesGetAction : ActionBase<ProductsAttributesGetRequestDto, ProductsAttributesGetAction.ProductsAttributesGetResponseDto>
    {
        /// <summary>
        /// 返回参数
        /// </summary>
        public class ProductsAttributesGetResponseDto
        {
            /// <summary>
            /// 是否多规格图片
            /// </summary>
            public int IsMutiAttribute { get; set; }

            /// <summary>
            /// 商品编号
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 天下图库商品编号
            /// </summary>
            public string Txtkid { get; set; }

            /// <summary>
            /// 母商品编号（关联母商品信息）
            /// </summary>
            public int BaseProductId { get; set; }

            /// <summary>
            /// 是否为母商品
            /// </summary>
            public int IsBaseProductId { get; set; }

            /// <summary>
            /// 商品规格图片
            /// </summary>
            public ProductsAttributesPicture ProductsAttributesPicture { get; set; }

            /// <summary>
            /// 商品规格列表
            /// </summary>
            public IEnumerable<ProductsAttributes> ProductsAttributes { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ProductsAttributesGetResponseDto> Execute()
        {
            //获取客户端提交参数
            var dto = this.RequestDto;

            //未提交商品ID
            if (!dto.ProductId.HasValue)
            {
                return this.ErrorActionResult("productId参数未提交");
            }

            //1.获取商品ID
            int productId = dto.ProductId.Value;

            //2.获取商品信息
            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(productId), () => ProductsBLO.ProductsGet(productId));


            //商品信息不存在
            if (product == null)
            {
                return this.ErrorActionResult("请求的商品不存在");
            }

            //3.获取母商品信息
            var baseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId), () =>
                                                            BaseProductsBLO.GetModel(product.BaseProductId, false));

            //4.读取商品规格信息
            var productsAttributes = this.CacheManager.GetList(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTES_LIST_KEY.With(productId),
                () => ProductsAttributesBLO.ProductsAttributesGet(dto.ProductId.Value));

            //5.规格图片信息
            var productsAttributesPicture = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTEPICTURE_KEY.With(productId),
                () => ProductsAttributesPictureBLO.ProductsAttributesPictureGet(dto.ProductId.Value));


            ProductsAttributesGetResponseDto data = new ProductsAttributesGetResponseDto
                                                        {
                                                            BaseProductId = product.BaseProductId,
                                                            IsBaseProductId = baseProduct.IsBaseProductId,
                                                            IsMutiAttribute = baseProduct.IsMutiAttribute,
                                                            ProductId = product.ProductId,
                                                            Txtkid = product.TXTKID,
                                                            ProductsAttributesPicture =
                                                                productsAttributesPicture == null ? null
                                                                    : new ProductsAttributesPicture
                                                                          {
                                                                              ImageUrlOrg = productsAttributesPicture.ImageUrlOrg,
                                                                              ImageUrl120x120 = productsAttributesPicture.ImageUrl120x120,
                                                                              ImageUrl200x200 = productsAttributesPicture.ImageUrl200x200,
                                                                              ImageUrl400x400 = productsAttributesPicture.ImageUrl400x400,
                                                                              ImageUrl60x60 = productsAttributesPicture.ImageUrl60x60
                                                                          },
                                                            ProductsAttributes = from item in productsAttributes
                                                                                 select new ProductsAttributes
                                                                                            {
                                                                                                //属性id
                                                                                                AttributeId = item.AttributeId,
                                                                                                //属性名称
                                                                                                AttributeName = item.AttributeName,
                                                                                                //属性值ID
                                                                                                ValuesId = item.ValuesId,
                                                                                                //属性值字符串
                                                                                                ValueStr = item.ValueStr,
                                                                                                //修改时间
                                                                                                ModifyTime = item.ModifyTime,
                                                                                                //修改用户ID
                                                                                                ModifyUserID = item.ModifyUserID,
                                                                                                //修改用户名称
                                                                                                ModifyUserName = item.ModifyUserName
                                                                                            }
                                                        };

            //返回参数
            return SuccessActionResult(data);

        }


    }
}

