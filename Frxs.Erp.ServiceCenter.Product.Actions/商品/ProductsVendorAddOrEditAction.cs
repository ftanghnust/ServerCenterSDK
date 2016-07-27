using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Product;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 增加OR修改商品库商品供应商关系表( )
    /// </summary>
    [ActionName("ProductsVendor.AddOrEdit"), UnloadCachekeys(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY, "_sys_")]
    public class ProductsVendorAddOrEditAction : ActionBase<RequestDto.ProductsVendorAddOrEditActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;

            var productsVendorList = new List<ProductsVendor>();
         
                if (requestDto.productsVendorList != null && requestDto.productsVendorList.Count > 0)
                {
                    int i = 0;
                    foreach (var model in requestDto.productsVendorList)
                    {
                        i = i + 1;
                        ProductsVendor orderdetail = model.MapTo<ProductsVendor>();
                        orderdetail.CreateTime = DateTime.Now;
                        orderdetail.CreateUserID = requestDto.UserId;
                        orderdetail.CreateUserName = requestDto.UserName;

                        orderdetail.ModifyTime = DateTime.Now;
                        orderdetail.ModifyUserID = requestDto.UserId;
                        orderdetail.ModifyUserName = requestDto.UserName;
                        orderdetail.WID = requestDto.WID;
                        orderdetail.VendorID = requestDto.VendorID;
                        orderdetail.LastBuyPrice = 0.00;
                        orderdetail.LastBuyTime = DateTime.Now.ToLocalTime();
                        productsVendorList.Add(orderdetail);
                    }
                }
          

            string result = ProductsVendorBLO.Save( productsVendorList); 

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
