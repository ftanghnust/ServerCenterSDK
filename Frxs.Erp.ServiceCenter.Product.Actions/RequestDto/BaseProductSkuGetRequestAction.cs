using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseProductSkuGetRequestAction : RequestDtoBase
    {
        /// <summary>
        /// 子商品编号
        /// </summary>
        public int ProductId { get; set; }

        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.ProductId <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductId", "子商品编号传入参数错误");
            }
        }
    }
}
