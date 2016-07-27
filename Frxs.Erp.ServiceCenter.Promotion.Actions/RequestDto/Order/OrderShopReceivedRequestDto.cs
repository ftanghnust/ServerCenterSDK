using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    public class OrderShopReceivedRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; set; }
    }
}
