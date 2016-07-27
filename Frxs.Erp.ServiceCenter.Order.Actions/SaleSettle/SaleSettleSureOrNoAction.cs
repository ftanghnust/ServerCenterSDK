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

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 结算单确认反确认
    /// </summary>
    [ActionName("SaleSettle.SureOrNo")]
    public class SaleSettleSureOrNoAction : ActionBase<RequestDto.SaleSettleSureOrNoRequestDto, int>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            string message = string.Empty;

            SaleSettle model = new SaleSettle();
            model.SettleID = requestDto.SettleID;
            model.ConfUserID = requestDto.UserId;
            model.ConfUserName = requestDto.UserName;
            model.ModifyUserID = requestDto.UserId;
            model.ModifyUserName = requestDto.UserName;
            message = SaleSettleBLO.SureOrNo(model, requestDto.WID.ToString(),requestDto.Sure);


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
