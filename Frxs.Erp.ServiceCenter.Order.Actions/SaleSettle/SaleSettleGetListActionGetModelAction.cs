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
    /// 销售结算单据明细查询
    /// </summary>
    [ActionName("SaleSettle.GetModel")]
    public class SaleSettleGetModelAction : ActionBase<SaleSettleGetModelAction.SaleSettleGetModelActionRequestDto, ResponseDto.SaleSettleGetModelActionResponseDto>
    {
        /// <summary>
        /// SaleSettle.GetModel
        /// </summary>
        public class SaleSettleGetModelActionRequestDto : RequestDtoBase
        {

            /// <summary>
            /// ID
            /// </summary>
            [Required]
            public string SettleID { get; set; }

            /// <summary>
            /// 仓库编号(Warehouse.WID)
            /// </summary>
            [Required(ErrorMessage = "{0}不能为空")]
            public int? WID { get; set; }

            /// <summary>
            /// 门店ID
            /// </summary>
            public int ShopID { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public override void BeforeValid()
            {
                base.BeforeValid();
            }

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
        public override ActionResult<ResponseDto.SaleSettleGetModelActionResponseDto> Execute()
        {
            var requestDto = this.RequestDto;

            SaleSettle saleSettleTemp = SaleSettleBLO.GetModel(requestDto.SettleID, requestDto.WID.ToString());
             Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("WID", saleSettleTemp.WID);
            conditionDict.Add("SettleID", saleSettleTemp.SettleID);
            IList<Frxs.Erp.ServiceCenter.Order.Model.SaleSettleDetail> saleSettleDetailList = SaleSettleDetailBLO.GetList(conditionDict, saleSettleTemp.WID.ToString());

            foreach (var item in saleSettleDetailList)
            {
                item.BillTypeStr = item.BillType == 0 ? "销售订单" : item.BillType == 1 ? "销售退货单" : "销售费用单";
            }

            return new ActionResult<ResponseDto.SaleSettleGetModelActionResponseDto>()
            {
                Flag = ActionResultFlag.SUCCESS,
                Info = "OK",
                Data = new ResponseDto.SaleSettleGetModelActionResponseDto() { SaleSettle = saleSettleTemp,
                                                                               SaleSettleDetailList = saleSettleDetailList
                }
            };
        }
    }
}
