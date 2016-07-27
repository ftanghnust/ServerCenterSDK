/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/4/28 9:44:40
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.ID.Model;
using Frxs.Erp.ServiceCenter.ID.BLL;
using Frxs.Erp.ServiceCenter.ID.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.ID.Actions.ResponseDto;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.ID.Actions
{
    /// <summary>
    /// 操作日志查询方法
    /// </summary>
    [ActionName("XSOperatorLog.GetList")]
    public class XSOperatorLogGetList : ActionBase<XSOperatorLogGetListRequestDto, ActionResultPagerData<XSOperatorLog>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<XSOperatorLog>> Execute()
        {
            var requestDto = this.RequestDto;
            PageListBySql<XSOperatorLog> page = new PageListBySql<XSOperatorLog>(
                        requestDto.PageIndex,
                        requestDto.PageSize);
            page.OrderFields = requestDto.SortBy;
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            PageListBySql<XSOperatorLog> models = XSOperatorLogBLO.GetPageList(page, requestDtoDict);
            return this.SuccessActionResult(new ActionResultPagerData<XSOperatorLog>()
            {
                TotalRecords = models.TotalRecords,
                ItemList = models.ItemList.ToList()
            });
        }
    }
}
