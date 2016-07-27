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
    /// 门店费用（待处理)批量删除
    /// </summary>
    [ActionName("SaleFee.Del")]
    public class SaleFeeDelAction : ActionBase<RequestDto.SaleFeeDelActionRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            int result = 0;
            if (!string.IsNullOrEmpty(requestDto.IDs))
            {
                result = SaleFeePreBLO.Delete(requestDto.WareHouseId.ToString(), requestDto.IDs);
            }
            var buyIds = requestDto.IDs.Split(',');

            if (buyIds.Length == result)
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
                    Info = "删除门店费用失败"
                };
            }
        }
    }
}
