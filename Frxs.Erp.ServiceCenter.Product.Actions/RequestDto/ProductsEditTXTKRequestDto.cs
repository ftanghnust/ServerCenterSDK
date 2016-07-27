using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 更新天下图库编号输入对象
    /// </summary>
    public class ProductsEditTxtkRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 天下图库编号
        /// </summary>
        public string Txtkid { get; set; }

        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (ProductId <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductId", "没有指定商品编号");
            }

            if (string.IsNullOrWhiteSpace(Txtkid))
            {
                yield return new RequestDtoValidatorResultError("Txtkid", "没有指定关联的天下图库编号");
            }
        }
    }
}
