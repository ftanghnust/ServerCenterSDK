using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleEditUpdateStatusRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 修改状态
        /// </summary>
        [Required]
        public int Status { get; set; }

        /// <summary>
        /// 改单号
        /// </summary>
           [Required]
        public string EditId { get; set; }
    }
}
