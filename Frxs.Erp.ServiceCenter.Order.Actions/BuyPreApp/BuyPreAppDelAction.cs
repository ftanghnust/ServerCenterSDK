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

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 补货，返配申请单 批量删除
    /// </summary>
    [ActionName("BuyPreApp.Del")]
    public class BuyPreAppDelAction : ActionBase<BuyPreAppDelAction.BuyPreAppDelActionRequestDto, int>
    {

        /// <summary>
        /// 接口调用传入参数
        /// </summary>
        public class BuyPreAppDelActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// WID
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 申请单 集合
            /// </summary>
            [Required]
            public IList<string> BuyPreAppIDs { get; set; }

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
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            var requestDto = this.RequestDto;
            string result = "0";
            if (requestDto.BuyPreAppIDs != null && requestDto.BuyPreAppIDs.Count > 0)
            {
                result = BuyPreAppBLO.Delete(requestDto.WID, requestDto.BuyPreAppIDs);
            }

            if (result == "0" )
            {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.SUCCESS,
                    Info = "OK"
                };
            }
            else {
                return new ActionResult<int>()
                {
                    Flag = ActionResultFlag.FAIL,
                    Info = result
                };
            }
        }
    }
}
