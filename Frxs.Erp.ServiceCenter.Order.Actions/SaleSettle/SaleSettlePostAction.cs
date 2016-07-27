/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/8 17:19:57
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
using System.Collections;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 结算单过账
    /// </summary>
    [ActionName("SaleSettle.Post")]
    public class SaleSettlePostAction : ActionBase<RequestDto.SaleSettlePostRequestDto, int>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            string message = string.Empty;

            SaleSettle model = SaleSettleBLO.GetModel(requestDto.SettleID, requestDto.WID.ToString());
            model.PostingTime = DateTime.Now;
            model.PostingUserID = requestDto.UserId;
            model.PostingUserName = requestDto.UserName;
            model.ModifyUserID = requestDto.UserId;
            model.ModifyUserName = requestDto.UserName;
            model.ModifyTime = DateTime.Now;
            model.Status = 2;
             Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            
            conditionDict.Add("SettleID", requestDto.SettleID);
            IList<SaleSettleDetail> Details = SaleSettleDetailBLO.GetList(conditionDict, requestDto.WID.ToString());
            message = SaleSettleBLO.Post(model, requestDto.WID.ToString(), Details);


            if (string.IsNullOrEmpty(message))
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "OK"
                };
            }
            else
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = message                    
                };
            }
        }
    }
}
