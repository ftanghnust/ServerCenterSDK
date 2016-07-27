using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取商品国际条码接口
    /// </summary>
    [ActionName("ProductBarCode.Get")]
    public class ProductsBarCodeGetAction : ActionBase<ProductsBarCodeGetAction.ProductsBarCodesGetAllRequestDto, ProductsBarCodeGetAction.ProductsBarCodesGetAllResponseDto>
    {
        /// <summary>
        /// 输入参数
        /// </summary>
        public class ProductsBarCodesGetAllRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 商品ID(product.ProductId)
            /// </summary>
            public int ProductId { get; set; }

            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.ProductId <= 0)
                {
                    yield return new RequestDtoValidatorResultError("ProductId", "商品编号未指定,不能查询国际条码数据");
                }
            }
        }


        /// <summary>
        /// 输出参数
        /// </summary>
        public class ProductsBarCodesGetAllResponseDto
        {
            /// <summary>
            /// 商品ID(product.ProductId)
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 商品国际条码列表
            /// </summary>
            public IList<ProductsBarCodes> ProductsBarCodes { get; set; }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ProductsBarCodesGetAllResponseDto> Execute()
        {
            var dto = this.RequestDto;

            var backMsg = ProductsBarCodesBLO.ProductsBarCodesGet(dto.ProductId);
            if (backMsg != null && backMsg.Count > 0)
            {
                return this.SuccessActionResult(new ProductsBarCodesGetAllResponseDto { ProductId = dto.ProductId, ProductsBarCodes = backMsg });
            }
            else
            {
                return this.ErrorActionResult("没有找到对应的条码信息");
            }
        }
    }
}
