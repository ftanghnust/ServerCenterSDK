/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/10 16:47:57
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 采购收货单(待处理)批量状态改变
    /// </summary>
    [ActionName("BuyOrderPre.ChangeStatus")]
    public class BuyOrderPreChangeStatusAction : ActionBase<RequestDto.BuyOrderPreChangeStatusActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            if (string.IsNullOrEmpty(requestDto.BuyIDs))
            {
                return this.ErrorActionResult("参数错误");
            }
            if (requestDto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }
            var result = BuyOrderPreBLO.ChangeStatus(requestDto.BuyIDs, requestDto.Status, requestDto.UserId, requestDto.UserName,requestDto.WarehouseId.ToString());
            if (result.IsSuccess)
            {
                return this.SuccessActionResult();
            }
            else
            {
                return this.ErrorActionResult(result.Message);
            }
        }
    }
}
