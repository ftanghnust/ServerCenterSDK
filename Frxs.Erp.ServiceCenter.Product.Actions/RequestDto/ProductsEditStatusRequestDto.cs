using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 商品状态输入参数
    /// </summary>
    public class ProductsEditStatusRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品编号列表
        /// </summary>
        public ICollection<int> ProductIds { get; set; }

        /// <summary>
        /// 改变后的状态
        /// </summary>
        public int Status { get; set; }


        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (ProductIds == null)
            {
                yield return new RequestDtoValidatorResultError("ProductIds", "没有指定商品编号参数");
            }

            if (Status < 0)
            {
                yield return new RequestDtoValidatorResultError("Status", "要改变的状态输入不正确");
            }
        }
    }
}
