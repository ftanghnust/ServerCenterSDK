using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleEditAddRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 操作状态 0：添加 1：修改
        /// </summary>
        [Required]
        public int Type { get; set; }

        /// <summary>
        /// 改单主表
        /// </summary>
        [Required]
        public SaleEditModelRequestDto SaleEdit { get; set; }

        /// <summary>
        /// 改单订单表
        /// </summary>
        [Required]
        public IList<SaleEditOrderRequestDto> Order { get; set; }

        /// <summary>
        /// 改单明细表
        /// </summary>
        [Required]
        public IList<SaleEditDetailsRequestDto> Details { get; set; }

        /// <summary>
        /// 改单明细扩展表
        /// </summary>
        [Required]
        public IList<SaleEditDetailExtsRequestDto> DetailExts { get; set; }


        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.Type < 0 || this.Type > 1)
            {
                yield return new RequestDtoValidatorResultError("Type", "错误的操作标志");
            }
        }

    }
}
