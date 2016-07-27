/*********************************************************
 * FRXS(ISC) ftanghnust@gmail.com 2016/3/9 17:15:02
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.BLL;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    /// <summary>
    /// 获取费用单退货单列表查询
    /// </summary>
    [ActionName("SaleOrderFree.GetList")]
    public class SaleOrderFreeGetListAction : ActionBase<SaleOrderFreeGetListAction.SaleOrderFreeGetListActionRequestDto, IList<SaleSettleTemp>>
    {

        /// <summary>
        /// SaleSettle.GetList
        /// </summary>
        public class SaleOrderFreeGetListActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 门店编号
            /// </summary>
            [Required]
            public int ShopID { get; set; }           


            /// <summary>
            /// 校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (WID <= 0)
                {
                    yield return new RequestDtoValidatorResultError("WID");
                }
            }

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<SaleSettleTemp>> Execute()
        {
            var requestDto = this.RequestDto;

            IList<SaleSettleTemp> models = SaleSettleBLO.GetList(requestDto.ShopID, requestDto.WID);

            return this.SuccessActionResult(models);
        }

    }
}
