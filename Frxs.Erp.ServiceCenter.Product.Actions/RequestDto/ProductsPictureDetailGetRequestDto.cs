
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 得到商品主图列表输入参数
    /// </summary>
    public class ProductsPictureDetailGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        public override System.Collections.Generic.IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.ProductId <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductId", "商品编号输入参数错误");
            }
        }
    }
}
