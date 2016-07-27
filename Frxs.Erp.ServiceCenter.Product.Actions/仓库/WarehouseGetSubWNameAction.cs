/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/19 17:03:50
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using System.Data;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Warehouse
{
    /// <summary>
    /// 获取仓库子机构相关信息
    /// </summary>
    [ActionName("Warehouse.GetSubWName")]
    public class WarehouseGetSubWNameAction : ActionBase<WarehouseGetSubWNameRequestDto, List<SubWName>>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<SubWName>> Execute()
        {
            var requestDto = this.RequestDto;

            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            var requestDtoDict = requestDto.GetAttributes(false);
            List<SubWName> SubWNameList = WarehouseBLO.GetSubWName(requestDtoDict).ToList();

            return this.SuccessActionResult(SubWNameList);
        }

    }
}
