﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 删除改单
    /// </summary>
    [ActionName("SaleEdit.Delete")]
    public class SaleEditDeleteAction : ActionBase<RequestDto.SaleEditBaseRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            if (string.IsNullOrEmpty(dto.EditId))
            {
                return this.ErrorActionResult("错误的改单编号");
            }
            var result = SaleEditBLO.Delete(dto.EditId, dto.WarehouseId.ToString());
            if(result.IsSuccess)
            {
                return this.SuccessActionResult(true);
            }
            else
            {
                return this.ErrorActionResult(result.Message);
            }
        }
    }
}
