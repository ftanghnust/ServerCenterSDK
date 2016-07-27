using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleEditBaseRequestDto : RequestDtoParent
    {
       /// <summary>
       /// 改单ID
       /// </summary>
        public string EditId { get; set; }
    }
}
