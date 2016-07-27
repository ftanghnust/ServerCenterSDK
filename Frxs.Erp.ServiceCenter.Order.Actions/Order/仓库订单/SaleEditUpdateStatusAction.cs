using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 改单修改状态
    /// </summary>
    [ActionName("SaleEdit.UpdateStatus")]
    public class SaleEditUpdateStatusAction : ActionBase<RequestDto.SaleEditUpdateStatusRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            if (string.IsNullOrEmpty(dto.EditId))
            {
                return this.ErrorActionResult("错误的改单编号");
            }
            var user = new BaseUserModel()
                           {
                               UserName = dto.UserName,
                               UserId = dto.UserId
                           };
            if(dto.Status!=2)
            {
                var result = SaleEditBLO.UpdateStatus(dto.EditId, dto.Status, dto.WarehouseId, user);
                if (result.IsSuccess)
                {
                    return this.SuccessActionResult(true);
                }
                else
                {
                    return this.ErrorActionResult(result.Message, false);
                }
            }
            else
            {
                var result = SaleEditBLO.Modify(dto.EditId, dto.WarehouseId, user);
                if (result.IsSuccess)
                {
                    return this.SuccessActionResult(result.Message,true);
                }
                else
                {
                    return this.ErrorActionResult(result.Message, false);
                }
            }
        }
    }
}
