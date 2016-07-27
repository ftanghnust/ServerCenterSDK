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
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 仓库消息 状态改变
    /// </summary>
    [ActionName("WarehouseMessage.ChangeStatus")]
    public class WarehouseMessageChangeStatusAction : ActionBase<RequestDto.WarehouseMessageChangeStatusActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;

            int result = WarehouseMessageBLO.ChangeStatus(requestDto.IDs, requestDto.Status, requestDto.UserId, requestDto.UserName, requestDto.WareHouseId.ToString());
            if (result > 0)
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "更改仓库消息状态成功！",
                    Data = result
                };
            }
            else {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "更改仓库消息状态失败！"
                };
            }
        }
    }
}
