using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class OrderPrintRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        [Required]
        public string OrderId { get; set; }

        /// <summary>
        /// 打印状态
        /// </summary>
        public int? IsPrinted { get; set; }
    }
}
