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
    /// 销售退货单(待处理)批量状态改变
    /// </summary>
    [ActionName("SaleBackPre.ChangeStatus")]
    public class SaleBackPreChangeStatusAction : ActionBase<RequestDto.SaleBackPreChangeStatusActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto.WarehouseId <= 0)
            {
                return this.ErrorActionResult("错误的仓库编号");
            }
            if (string.IsNullOrEmpty(requestDto.BackIDs))
            {
                return this.ErrorActionResult("参数错误");
            }



            var result = SaleBackPreBLO.ChangeStatus(requestDto.BackIDs, requestDto.Status, requestDto.UserId, requestDto.UserName, requestDto.WarehouseId.ToString());
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
