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
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions
{
    /// <summary>
    /// 广告橱窗获取
    /// </summary>
    [ActionName("WAdvertisement.GetModel")]
    public class WAdvertisementGetModelAction : ActionBase<RequestDto.WAdvertisementGetModelActionRequestDto, ResponseDto.WAdvertisementGetModelActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.WAdvertisementGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;
            if (string.IsNullOrEmpty(requestDto.ID))
            {
                return new ActionResult<ResponseDto.WAdvertisementGetModelActionResponseDto>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = "ID不能为空！"
                };
            }
            WAdvertisement orderTemp = WAdvertisementBLO.GetModel(DataTypeHelper.GetInt(requestDto.ID), requestDto.WID.ToString());
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("WID", orderTemp.WID);
            conditionDict.Add("AdvertisementID", orderTemp.AdvertisementID);
            IList<WAdvertisementProduct> products = WAdvertisementProductBLO.GetList(conditionDict, orderTemp.WID.ToString());

            return new ActionResult<ResponseDto.WAdvertisementGetModelActionResponseDto>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = new ResponseDto.WAdvertisementGetModelActionResponseDto() 
                { 
                    order = orderTemp,
                    products = products
                }
            };
        }
    }
}
