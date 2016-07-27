/*********************************************************
 * FRXS(ISC) chujl 2016/3/23  
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
    /// 门店费用 状态改变
    /// </summary>
    [ActionName("SaleFee.ChangeStatus")]
    public class SaleFeeChangeStatusAction : ActionBase<RequestDto.SaleFeeChangeStatusActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            if (string.IsNullOrEmpty(requestDto.FeeIDs))
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "参数错误！"
                };
            }
            int result = SaleFeePreBLO.ChangeStatus(requestDto.WareHouseId, requestDto.FeeIDs, requestDto.Status, requestDto.UserId, requestDto.UserName);
            if (result > 0)
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "更改门店费用状态成功！",
                    Data = result
                };
            }
            else {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "更改门店费用状态失败，请检查相应状态是否正确！"
                };
            }
        }
    }
}
