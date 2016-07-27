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
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 货位调整获取
    /// </summary>
    [ActionName("WProductAdjShelf.GetModel")]
    public class WProductAdjShelfGetModelAction : ActionBase<RequestDto.WProductAdjShelfGetModelActionRequestDto, WProductAdjShelfGetModelAction.WProductAdjShelfGetModelActionResponseDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public class WProductAdjShelfGetModelActionResponseDto 
        {
            /// <summary>
            /// 
            /// </summary>
            public WProductAdjShelf wProductAdjShelf { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public IList<WProductAdjShelfDetails> wProductAdjShelfDetailsList { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductAdjShelfGetModelAction.WProductAdjShelfGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;

            WProductAdjShelf orderTemp = WProductAdjShelfBLO.GetModel(requestDto.AdjId);
            IDictionary<string, object> objdic=new Dictionary<string,object>();
            objdic.Add("AdjID", requestDto.AdjId);
            IList<WProductAdjShelfDetails> orderDetailList = WProductAdjShelfDetailsBLO.GetList(objdic);

            return new ActionResult<WProductAdjShelfGetModelAction.WProductAdjShelfGetModelActionResponseDto>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = new WProductAdjShelfGetModelAction.WProductAdjShelfGetModelActionResponseDto() { wProductAdjShelf = orderTemp, wProductAdjShelfDetailsList = orderDetailList }
            };
        }
    }
}
