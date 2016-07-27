

using System.Collections.Generic;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductDeleteRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品编号列表
        /// </summary>
        public ICollection<int> ProductIds { get; set; }

    }
}
