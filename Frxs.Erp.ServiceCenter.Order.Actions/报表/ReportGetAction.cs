using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility.Pager;
using System.Data;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Platform.Utility.Json;

namespace Frxs.Erp.ServiceCenter.Order.Actions.报表
{
    /// <summary>
    /// 报表接口
    /// </summary>
    public class ReportGetAction : ActionBase<ReportGetRequestDto, string>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {
            var requestDto = this.RequestDto;

           
            Dictionary<string, object> requestDtoDict = new Dictionary<string, object>();            

            if (requestDto.parameters != null)
            {
                foreach (var item in requestDto.parameters)
                {
                    requestDtoDict.Add(item.key, item.value);
                }
            }

           DataTable dt=ReportBLO.GetReport(requestDtoDict, requestDto.WID.ToString(), requestDto.Procedure_Name);


           return new ActionResult<string>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = dt.ToJson()
            };
        }
    }
}
