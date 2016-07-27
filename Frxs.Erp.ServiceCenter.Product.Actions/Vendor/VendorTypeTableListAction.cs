using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Vendor
{
    /// <summary>
    /// 获取供应商列表
    /// </summary>
    [ActionName("VendorType.ListGet")]
    public class VendorTypeTableListAction : ActionBase<VendorTypeTableListRequestDTO, ActionResultPagerData<VendorType>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.VendorType>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.VendorType> page = new PageListBySql<Model.VendorType>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;

            var requestDtoDict = requestDto.GetAttributes(false);

            PageListBySql<Model.VendorType> models = VendorTypeBLO.GetPageList(page, requestDtoDict);
            if (models == null)
            {
                return this.ErrorActionResult("查询供应商信息列表失败！");
            }
            return this.SuccessActionResult(new ActionResultPagerData<Model.VendorType>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }
    }
}
