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
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 货位调整 状态改变
    /// </summary>
    [ActionName("WProductAdjShelf.ChangeStatus"), UnloadCachekeys(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY)]
    public class WProductAdjShelfChangeStatusAction : ActionBase<RequestDto.WProductAdjShelfChangeStatusActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;

            var adjIDs = string.Join(",", this.RequestDto.AdjIDs);
            string result = WProductAdjShelfBLO.ChangeStatus(adjIDs, requestDto.Status, requestDto.UserId, requestDto.UserName);
            if (result == "1")
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "更改货位调整状态成功！",
                    Data = int.Parse(result)
                };
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = result
                };
            }
        }
    }
}
