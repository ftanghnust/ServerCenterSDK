using System;
using System.Collections.Generic;
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
    /// 设置主供应商
    /// </summary>
    [ActionName("ProductsVendor.UpdateLastBuyPrice")]
    public class ProductsVendorUpdateLastBuyPriceAction : ActionBase<RequestDto.ProductsVendorUpdateLastBuyPriceRequestDto, int>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            DateTime currentdt = DateTime.Now;
            List<ProductsVendor> productsVendorBuyPriceList = new List<ProductsVendor>();
            foreach (ProductsVendorUpdateLastBuyPriceRequestDto.ProductsVendorUnitPriceRequestDto item in requestDto.ProductsVendorBuyPriceList)
            {
                ProductsVendor model = new ProductsVendor
                                           {
                                               ProductId = item.ProductId,
                                               LastBuyPrice = item.BuyPrice,
                                               BuyPrice = item.BuyPrice,
                                               ModifyTime = currentdt,
                                               LastBuyTime = currentdt,
                                               ModifyUserID = requestDto.UserId,
                                               ModifyUserName = requestDto.UserName,
                                               Unit = item.Unit,
                                               VendorID = requestDto.VendorID,
                                               WID = requestDto.Wid
                                           };
                productsVendorBuyPriceList.Add(model);
            }

            string result = ProductsVendorBLO.UpdateLastBuyPrices(requestDto.VendorID, requestDto.Wid, productsVendorBuyPriceList);
            if (result == "1")
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "OK"
                };
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = result
                };
            }

        }


    }
}
