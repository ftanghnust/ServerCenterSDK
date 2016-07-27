using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class OrderBaseRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; set; }

    }


    public class OrderBaseExtRequestDto : RequestDtoParent
    {

        /// <summary>
        /// 
        /// </summary>
        public string SearchDate { get; set; }
        
        /// <summary>
        ///WID
        /// </summary>
        public int WID { get; set; }
    }
}
