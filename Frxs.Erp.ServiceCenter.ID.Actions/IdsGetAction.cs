/*********************************************************
 * FRXS(ISC) yeqiou@163.com 2016/3/8 10:29:17
 * *******************************************************/
using System.Collections.Generic;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.ID.Model;
using Frxs.Erp.ServiceCenter.ID.BLL;

namespace Frxs.Erp.ServiceCenter.ID.Actions
{
    /// <summary>
    /// 获取各个服务ID流水主键
    /// </summary>
    [ActionName("Ids.Get")]
    public class IdsGetAction : ActionBase<RequestDto.IdsGetRequestDto, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<string> Execute()
        {
            //取到上送参数
            var requestDto = this.RequestDto;
            string billID = IDFactoryBLO.GetID((IDTypes)requestDto.Type, requestDto.WID);
            return this.SuccessActionResult(billID);
        }
    }
}
