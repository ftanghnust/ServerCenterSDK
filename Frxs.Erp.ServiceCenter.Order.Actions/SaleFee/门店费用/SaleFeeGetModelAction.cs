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
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 门店费用获取
    /// </summary>
    [ActionName("SaleFee.GetModel")]
    public class SaleFeeGetModelAction : ActionBase<RequestDto.SaleFeeGetModelActionRequestDto, ResponseDto.SaleFeeGetModelActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.SaleFeeGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            if (string.IsNullOrEmpty(requestDto.FeeID))
            {
                return new ActionResult<ResponseDto.SaleFeeGetModelActionResponseDto>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "FeeID不能为空！"
                };
            }
            SaleFee orderTemp = SaleFeeBLO.GetModel(requestDto.WareHouseId.ToString(), requestDto.FeeID);
            
            return new ActionResult<ResponseDto.SaleFeeGetModelActionResponseDto>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = new ResponseDto.SaleFeeGetModelActionResponseDto() { saleFee = orderTemp, saleFeePreDetailsList = null }
            };
        }
    }
}
