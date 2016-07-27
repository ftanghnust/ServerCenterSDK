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
    /// 产品关键字seo 查询
    /// </summary>‘
    [ActionName("Product.KeyWord.Get")]
    public class ProductsKeyWordGetAction : ActionBase<ProductsKeyWordGetRequestDto, ProductsKeyWordGetAction.ProductsKeyWordGetResponseDto>
    {
        public class ProductsKeyWordGetResponseDto
        {
            /// <summary>
            /// 商品ID
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 商品SEO关键词
            /// </summary>
            public string KeyWord { get; set; }

        }


        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ProductsKeyWordGetResponseDto> Execute()
        {
            //获取到dto
            var dto = this.RequestDto;

            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(dto.ProductId), ()
                => ProductsBLO.ProductsGet(dto.ProductId));
            if (null == product)
            {
                return ErrorActionResult("商品不存在,不能修改天下图库编号");
            }

            //获取成功
            return this.SuccessActionResult(new ProductsKeyWordGetResponseDto { ProductId = product.ProductId, KeyWord = product.Keywords });
        }
    }
}
