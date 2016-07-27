using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.Actions.Stock;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{

    /// <summary>
    /// 创建自动盘盈单
    /// </summary>
    [ActionName("StockAdj.CreateAutoSurplus")]
    public class StockAdjCreateAutoSurplusAction : ActionBase<StockAdjCreateAutoRequestDto, bool>
    {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            var result = StockAdjBLO.CreateAutoStockAdjSurplus(dto.StockAdj.MapTo<StockAdj>(), dto.Detail, dto.DetailsExt,
                                                        dto.WarehouseId,
                                                        new BaseUserModel()
                                                            {UserId = dto.UserId, UserName = dto.UserName});
            if(result.IsSuccess)
            {
                return this.SuccessActionResult(true);
            }
            else
            {
                return this.ErrorActionResult(result.Message,false);
            }
        }
    }

    public class StockAdjCreateAutoRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 盘盈单主表
        /// </summary>
        public StockAdjSaveAction.StockAdjSaveActionRequestDto StockAdj { get; set; }

        /// <summary>
        /// 盘点调整明细表
        /// </summary>
        public IList<StockAdjDetail> Detail { get; set; }

        /// <summary>
        /// 盘点调整明细扩展表
        /// </summary>
        public IList<StockAdjDetailsExt> DetailsExt { get; set; }
    }
}
