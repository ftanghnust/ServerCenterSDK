using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    [ActionName("WProductsBuyEmp.List.Save")]
    public class WProductsBuyEmpListSaveAction : ActionBase<WProductsBuyEmpListSaveAction.WProductsBuyEmpListSaveActionRequestDto, WProductsBuyEmpListSaveAction.WProductsBuyEmpListSaveActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsBuyEmpListSaveActionRequestDto : RequestDtoBase
        {
            public int wid { get; set; }
            public List<int> wProductIds { get; set; }
            public List<int> BuyEmpIds { get; set; }
        }

        /// <summary>
        /// 下送的参数对象
        /// </summary>
        public class WProductsBuyEmpListSaveActionResponseDto : ResponseDtoBase
        {
            public int result { get; set; }
        }

        public override ActionResult<WProductsBuyEmpListSaveActionResponseDto> Execute()
        {
            var dto = this.RequestDto;
            var result = 0;
            try
            {
                result = WProductsBuyEmpBLO.SaveWProductsBuyEmp(dto.wid, dto.UserId, dto.UserName, dto.wProductIds, dto.BuyEmpIds);
            }
            catch (Exception ex)
            {
                return ErrorActionResult("设置采购员出错：" + ex.Message);
            }
            var responseDto = new WProductsBuyEmpListSaveActionResponseDto {result = result};
            return this.SuccessActionResult(responseDto);
        }
    }
}
