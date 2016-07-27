using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 商品国际条码新增接口
    /// </summary>
    [ActionName("ProductBarCode.Add")]
    public class ProductsBarCodeAddAction : ActionBase<ProductsBarCodesAddRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var dto = this.RequestDto;

            ICollection<ProductsBarCodes> codes = new Collection<ProductsBarCodes>();
            foreach (var productsBarCodese in dto.ProductsBarCodes)
            {
                var code = productsBarCodese.MapTo<ProductsBarCodes>();
                code.CreateTime = DateTime.Now;
                code.CreateUserID = dto.UserId;
                code.CreateUserName = dto.UserName;
                code.ProductId = dto.ProductId;
                codes.Add(code);
            }

            var backMsg = ProductsBarCodesBLO.ProductBarCodesAddOrEdit(dto.ProductId, codes);
            return backMsg.IsSuccess ? SuccessActionResult(backMsg.Message, backMsg.Data) : ErrorActionResult(backMsg.Message);


        }
    }
}
