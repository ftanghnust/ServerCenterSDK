/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/9 17:15:02
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 销售退货单(待处理)分页查询
    /// </summary>
    [ActionName("SaleBackPre.GetList")]
    public class SaleBackPreGetListAction : ActionBase<RequestDto.SaleBackPreGetListActionRequestDto, ActionResultPagerData<SaleBackPre>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<SaleBackPre>> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto.WID <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }
            PageListBySql<SaleBackPre> page = new PageListBySql<SaleBackPre>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<SaleBackPre> models = SaleBackPreBLO.GetPageList(page, requestDtoDict, requestDto.WID.ToString());

            return this.SuccessActionResult(new ActionResultPagerData<SaleBackPre>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }

    }
}
