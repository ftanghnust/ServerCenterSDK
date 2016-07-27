/*****************************
* Author:罗涛
*
* Date:2016/6/14 9:24:39
******************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Platform.Utility.Json;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.报表
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

            DataTable dt = ReportBLO.GetReport(requestDtoDict, requestDto.WID.ToString(), requestDto.Procedure_Name);


            return new ActionResult<string>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = dt.ToJson()
            };
        }
    }
}
