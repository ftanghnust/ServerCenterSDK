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
    /// 货位调整 批量删除
    /// </summary>
    [ActionName("WProductAdjShelf.Del")]
    public class WProductAdjShelfDelAction : ActionBase<RequestDto.WProductAdjShelfDelActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            int result = 0;
            if (requestDto.AdjIDs != null && requestDto.AdjIDs.Count>0)
            {
                var adjIDs = string.Join(",", requestDto.AdjIDs);
                result = WProductAdjShelfBLO.Delete(adjIDs);
            }

            if (result >0 )
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "OK",
                    Data = result
                };
            }
            else {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "删除货位调整失败"
                };
            }
        }
    }
}
