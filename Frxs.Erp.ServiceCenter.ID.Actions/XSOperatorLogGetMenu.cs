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
    /// 操作日志菜单查询方法
    /// </summary>
    [ActionName("XSOperatorLog.GetMenu")]
    public class XSOperatorLogGetMenu : ActionBase<XSOperatorLogGetListRequestDto, XSOperatorLogGetMenuResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<XSOperatorLogGetMenuResponseDto> Execute()
        {
            List<XSOperatorLogMenu> models = XSOperatorLogBLO.GetXSOperatorLogMenu().ToList();
            return this.SuccessActionResult(new XSOperatorLogGetMenuResponseDto() { menus = models });
        }
    }
}
