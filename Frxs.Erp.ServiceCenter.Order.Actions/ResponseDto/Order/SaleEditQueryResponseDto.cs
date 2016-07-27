using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    public class SaleEditQueryResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 改单列表
        /// </summary>
        public IList<SaleEditResponseDto> ItemList { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int Total { get; set; }
    }
}
