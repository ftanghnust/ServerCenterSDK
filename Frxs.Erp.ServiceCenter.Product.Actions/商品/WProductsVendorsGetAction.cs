using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/5 9:53:20
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取仓库商品供应商列表
    /// </summary>
    [ActionName("WProducts.Vendors.Get")]
    public class WProductsVendorsGetAction : ActionBase<WProductsVendorsGetAction.WProductsVendorsGetActionRequestDto, List<ProductVendorModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsVendorsGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品编号
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.ProductId <= 0) yield return new RequestDtoValidatorResultError("ProductId");
                if (this.WID <= 0) yield return new RequestDtoValidatorResultError("WID");
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ProductVendorModel>> Execute()
        {
            return this.SuccessActionResult(DALFactory.GetLazyInstance<IWProductsDAO>().GetProductVendors(this.RequestDto.WID, this.RequestDto.ProductId).ToList());
        }

    }
}
