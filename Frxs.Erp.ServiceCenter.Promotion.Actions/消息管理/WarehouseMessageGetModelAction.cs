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
    /// 仓库消息单条获取
    /// </summary>
    [ActionName("WarehouseMessage.GetModel")]
    public class WarehouseMessageGetModelAction : ActionBase<RequestDto.WarehouseMessageGetModelActionRequestDto, ResponseDto.WarehouseMessageGetModelActionResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ResponseDto.WarehouseMessageGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;

            WarehouseMessage orderTemp = WarehouseMessageBLO.GetModel(DataTypeHelper.GetInt(requestDto.ID), requestDto.WareHouseId.ToString());

            return new ActionResult<ResponseDto.WarehouseMessageGetModelActionResponseDto>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = new ResponseDto.WarehouseMessageGetModelActionResponseDto() { order = orderTemp }
            };
        }
    }
}
