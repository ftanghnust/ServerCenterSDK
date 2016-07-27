using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 商品关键字（SEO）优化字段更新
    /// </summary>
    public class ProductsKeyWordUpdateRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品SEO关键词
        /// </summary>
        public string KeyWord { get; set; }

        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (ProductId <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductId", "没有指定商品编号");
            }
        }
    }
}
