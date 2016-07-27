using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Warehouse
{
    /// <summary>
    /// 修改仓库信息
    /// </summary>
    [ActionName("Warehouse.Edit")]
    public class WarehouseEditAction : ActionBase<RequestDto.WarehouseEditRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            if (this.RequestDto != null)
            {
                var requestDto = this.RequestDto;
                Model.Warehouse model = new Model.Warehouse();
                model = requestDto.MapTo<Frxs.Erp.ServiceCenter.Product.Model.Warehouse>();

                if (WarehouseBLO.ExistsWCode(model))
                {
                    return ErrorActionResult("仓库编号已经存在!");
                }
                else if (WarehouseBLO.ExistsWName(model) && model.WLevel.HasValue && model.WLevel.Value == 1)
                {
                    return ErrorActionResult("仓库名称已经存在!");
                }
                else
                {
                    WarehouseBLO.Edit(model);
                    return this.SuccessActionResult(1);
                }
            }
            else
            {
                return this.ErrorActionResult("上送参数不对!");
            }
        }
    }
}
