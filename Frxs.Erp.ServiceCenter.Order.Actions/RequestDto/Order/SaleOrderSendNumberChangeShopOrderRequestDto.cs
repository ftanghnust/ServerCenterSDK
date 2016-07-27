using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleOrderSendNumberChangeShopOrderRequestDto : RequestDtoParent
    {
        public int ChangeType { get; set; }
        public int LineID { get; set; }
        public string OrderId { get; set; }
    }
}
