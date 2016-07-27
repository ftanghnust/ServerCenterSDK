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
    /// 广告橱窗删除
    /// </summary>
    [ActionName("WAdvertisement.Del")]
    public class WAdvertisementDelAction : ActionBase<RequestDto.WAdvertisementDelActionRequestDto, int>
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
                result = WAdvertisementBLO.Delete(requestDto.IDs, requestDto.WID.ToString());
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
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "删除广告橱窗失败"
                };
            }

            //if (1 == result)
            //{
            //    return new ActionResult<int>()
            //    {
            //        Flag = ActionResultFlag.SUCCESS,
            //        Info = "OK",
            //        Data = result
            //    };
            //}
            //else {
            //    return new ActionResult<int>()
            //    {
            //        Flag = ActionResultFlag.FAIL,
            //        Info = "删除广告橱窗失败"
            //    };
            //}
        }
    }
}
