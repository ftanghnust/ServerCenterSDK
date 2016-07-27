using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;

using System.ComponentModel;
using System.Runtime.Serialization;
using System;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor;
using System.Collections.Generic;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Vendor
{
    /// <summary>
    /// 获取供应商列表
    /// </summary>
    [ActionName("Vendor.TableList")]
    public class VendorTableListAction : ActionBase<VendorTableListActionRequestDto, ActionResultPagerData<Model.Vendor>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<Model.Vendor>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<Model.Vendor> page = new PageListBySql<Model.Vendor>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;

            var requestDtoDict = requestDto.GetAttributes(false);
            
            PageListBySql<Model.Vendor> models = VendorBLO.GetPageList(page, requestDtoDict);
            if (models == null)
            {
                return this.ErrorActionResult("查询供应商信息列表失败！");
            }
            return this.SuccessActionResult(new ActionResultPagerData<Model.Vendor>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }
    }
}
