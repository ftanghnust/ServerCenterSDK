/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/28 10:14:48
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.Model;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 获取盘点调整单下的 调整总数和总金额
    /// </summary>
    [ActionName("StockAdj.QtyAmtSum.Get")]
    public class StockAdjQtyAmtSumGetAction : ActionBase<StockAdjQtyAmtSumGetAction.StockAdjQtyAmtSumActionRequestDto, StockAdjSum>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class StockAdjQtyAmtSumActionRequestDto : RequestDtoParent//RequestDtoBase //PageListRequestDto(分页列表继承基类)
        {
            /// <summary>
            /// 调整ID(WID+ ID服务)
            /// </summary>
            [Required(ErrorMessage = "盘点调整单号{0}不能为空")]
            public string AdjID { get; set; }
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
        /// 下送的数据
        /// </summary>
        public class StockAdjDetailCountGetActionResponseDto
        {

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<StockAdjSum> Execute()
        {
            
            StockAdjSum model = new StockAdjSum();
            if (RequestDto != null && !string.IsNullOrWhiteSpace(RequestDto.AdjID))
            {
                string warehouseId = RequestDto.WarehouseId.ToString();
                model = StockAdjBLO.GetSumQtyAmt(RequestDto.AdjID, warehouseId);
            }
            else
            {
                return ErrorActionResult("上传的参数不正确!");
            }
            return SuccessActionResult(string.Format("查询完成!总数{0},总金额{1}", model.AdjQtySum,model.AdjAmtSum), model);
        }
    }
}
