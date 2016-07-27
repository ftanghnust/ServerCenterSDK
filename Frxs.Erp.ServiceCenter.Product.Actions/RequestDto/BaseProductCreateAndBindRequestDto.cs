using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{

    /// <summary>
    /// 母商品创建和绑定输入对象
    /// </summary>
    public class BaseProductCreateAndBindRequestDto : RequestDtoBase
    {
        private const string ErrorMessage = "母商品名称必填";
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 母商品名称
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage)]
        [StringLength(100)]
        public string BaseProductName { get; set; }


        public override IEnumerable<RequestDtoValidatorResultError> Valid()
        {
            if (this.ProductId <= 0)
            {
                yield return new RequestDtoValidatorResultError("ProductId", "商品编号传入参数错误");
            }
        }
    }
}
