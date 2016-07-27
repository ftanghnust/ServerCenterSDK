using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 修改商品KeyWord接口（SEO）
    /// </summary>
    [ActionName("Product.KeyWord.Update")]
    public class ProductsKeyWordUpdateAction : ActionBase<ProductsKeyWordUpdateRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //获取到dto
            var dto = this.RequestDto;

            //更新商品关键词
            ProductsBLO.ProductKeyWordUpdate(dto.ProductId, dto.KeyWord);

            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(dto.ProductId));

            //修改成功
            return this.SuccessActionResult();
        }
    }
}
