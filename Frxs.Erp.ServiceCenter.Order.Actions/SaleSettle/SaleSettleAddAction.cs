﻿/*********************************************************
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
    /// 结算单后台保存
    /// </summary>
    [ActionName("SaleSettle.Add")]
    public class SaleSettleAddAction : ActionBase<RequestDto.SaleSettleAddOrEditRequestDto, int>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            string message = string.Empty;
            SaleSettle model = Frxs.Platform.Utility.Map.AutoMapperHelper.MapTo<SaleSettle>(RequestDto.Salesettle);

            IList<SaleSettleDetail> detail = requestDto.Details.MapToList<SaleSettleDetail>().ToList();

            message = SaleSettleBLO.Save(model, requestDto.WID.ToString(),detail);


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
