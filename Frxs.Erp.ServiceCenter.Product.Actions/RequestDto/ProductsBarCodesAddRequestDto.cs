using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 国际条码 新增 输入参数
    /// </summary>
    public class ProductsBarCodesAddRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 国际条码列表
        /// </summary>
        public IList<ProductsBarCodesRequestDto> ProductsBarCodes { get; set; }

        /// <summary>
        /// 验证数据准确性
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.ProductsBarCodes == null || this.ProductsBarCodes.Count <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductsBarCodes", "条码记录为空");
            }
        }

    }
}
