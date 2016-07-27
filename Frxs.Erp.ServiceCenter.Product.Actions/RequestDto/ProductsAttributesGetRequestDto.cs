using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 获取商品规格属性接口上传参数DTO
    /// </summary>
    public class ProductsAttributesGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品ID；值类型的最好定义成可空类型，这样可以在程序里判断客户端是否提交了值，方便判断
        /// </summary>
        public int? ProductId { get; set; }

        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            //未传出商品ID参数
            if (!this.ProductId.HasValue || this.ProductId <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductId", "参数ProductId未传入或商品ID参数错误");                
            }
          
        }
    }
}
