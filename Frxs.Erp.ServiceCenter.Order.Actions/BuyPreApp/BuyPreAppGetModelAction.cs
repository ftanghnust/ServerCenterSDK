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

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 货位调整获取
    /// </summary>
    [ActionName("BuyPreApp.GetModel")]
    public class BuyPreAppGetModelAction : ActionBase<BuyPreAppGetModelAction.BuyPreAppGetModelActionRequestDto, BuyPreAppGetModelAction.BuyPreAppGetModelActionResponseDto>
    {

        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class BuyPreAppGetModelActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// WID
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 申请单ID
            /// </summary>
            [Required]
            public string AppID { get; set; }

            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                return base.Valid();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        public class BuyPreAppGetModelActionResponseDto
        {
            /// <summary>
            /// 
            /// </summary>
            public BuyPreApp BuyPreApp { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public IList<BuyPreAppDetails> BuyPreAppDetailsList { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public IList<BuyPreAppDetailsExt> BuyPreAppDetailsExtList { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<BuyPreAppGetModelAction.BuyPreAppGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;

            BuyPreApp orderTemp = BuyPreAppBLO.GetModel(requestDto.WID,requestDto.AppID);
            IList<BuyPreAppDetails> detailList = BuyPreAppDetailsBLO.GetModelList(requestDto.WID, requestDto.AppID);
            IList<BuyPreAppDetailsExt> detailExtList = BuyPreAppDetailsExtBLO.GetModelList(requestDto.WID, requestDto.AppID);

            return new ActionResult<BuyPreAppGetModelAction.BuyPreAppGetModelActionResponseDto>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = new BuyPreAppGetModelAction.BuyPreAppGetModelActionResponseDto()
                {
                    BuyPreApp = orderTemp,
                    BuyPreAppDetailsList = detailList,
                    BuyPreAppDetailsExtList = detailExtList
                }
            };
        }
    }
}
