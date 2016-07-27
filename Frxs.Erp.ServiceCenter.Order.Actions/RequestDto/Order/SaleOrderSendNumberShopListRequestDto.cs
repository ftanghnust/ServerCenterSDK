using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleOrderSendNumberShopListRequestDto : RequestDtoParent
    {
        public int WID { get; set; }

        public int LineID { get; set; }
    }
}
