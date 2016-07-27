using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Product;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取供应商商品关系表（带分页和不分页两种）
    /// </summary>
    [ActionName("ProductsVendor.Get")]
    public class ProductsVendorGetAction : ActionBase<RequestDto.ProductsVendorGetListActionRequestDto, ActionResultPagerData<ProductsVendor>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<ProductsVendor>> Execute()
        {
            var requestDto = this.RequestDto; 
            var searchCondition = new Dictionary<string, object>();
            
            if ( this.RequestDto.WID.HasValue)
            {
                searchCondition.Add("WID", this.RequestDto.WID);
            }

            if (this.RequestDto.VendorID.HasValue)
            {
                searchCondition.Add("VendorID", this.RequestDto.VendorID);
            }

            if (this.RequestDto.IsMaster.HasValue)
            {
                searchCondition.Add("IsMaster", this.RequestDto.IsMaster);
            }
           
            if (!string.IsNullOrEmpty(this.RequestDto.KeyWord))
            {
                searchCondition.Add("KeyWord", this.RequestDto.KeyWord);
            }

            searchCondition.Add("PageIndex", this.RequestDto.PageIndex);

            searchCondition.Add("PageSize", this.RequestDto.PageSize);
            if (!string.IsNullOrEmpty(this.RequestDto.SortBy))
            {
                searchCondition.Add("SortBy", this.RequestDto.SortBy);
            }

            var requestDtoDict = requestDto.GetAttributes(false);
            IList<ProductsVendor> wProductVendorList = null;
            if (requestDto.IsPage == 1)
            {

             PageListBySql<ProductsVendor> page = new PageListBySql<ProductsVendor>(
                            requestDto.PageIndex,
                            requestDto.PageSize);
                page.OrderFields = requestDto.SortBy;
                var wProductVendorObj = ProductsVendorBLO.GetListExtByPage( searchCondition);

               

                return this.SuccessActionResult(new ActionResultPagerData<ProductsVendor>()
                {
                    TotalRecords = int.Parse(wProductVendorObj["totalCount"].ToString()),
                    ItemList = (List<ProductsVendor>)wProductVendorObj["itemList"]
                });
            }
            else
            {
               
                wProductVendorList = ProductsVendorBLO.GetListNoPage(requestDtoDict);
                return this.SuccessActionResult(new ActionResultPagerData<ProductsVendor>()
                {
                    TotalRecords = wProductVendorList.Count,
                    ItemList = wProductVendorList.ToList<ProductsVendor>()
                });
            }
            
        }
    }
}
