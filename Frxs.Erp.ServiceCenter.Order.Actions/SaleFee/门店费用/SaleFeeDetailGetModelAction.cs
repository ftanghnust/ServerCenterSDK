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
    [ActionName("SaleFeeDetail.GetModel")]
    public class SaleFeeDetailGetModelAction : ActionBase<RequestDto.SaleFeeGetModelActionRequestDto, ResponseDto.SaleFeeGetModelActionResponseDto>
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
          //  SaleFee orderTemp = SaleFeeBLO.GetModel(requestDto.WID.ToString(),requestDto.FeeID);
            IDictionary<string, object> objdic = new Dictionary<string, object>();
            objdic.Add("FeeID", requestDto.FeeID);
            IList<SaleFeeDetails> orderDetailList = SaleFeeDetailsBLO.GetList(requestDto.WareHouseId, objdic);
           
            return new ActionResult<ResponseDto.SaleFeeGetModelActionResponseDto>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = new ResponseDto.SaleFeeGetModelActionResponseDto() { saleFee = null, saleFeePreDetailsList = orderDetailList }
            };
        }
    }
}
