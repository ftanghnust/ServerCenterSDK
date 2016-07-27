using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.Stock
{
    /// <summary>
    /// 创建自动盘亏单（对应盘盈单创建）
    /// </summary>
    [ActionName("StockAdj.CreateDeficit")]
    public class StockAdjCreateDeficitAction : ActionBase<StockAdjCreateDeficitRequestDto, bool>
     {
        public override ActionResult<bool> Execute()
        {
            var dto = this.RequestDto;
            var result = StockAdjBLO.SaveStockAdjDeficit(dto.AdjIds, dto.WarehouseId, dto.WCode, dto.WName, dto.SubWid,
                                                         dto.SubWcode, dto.SubWName,
                                                         new BaseUserModel()
                                                             {UserId = dto.UserId, UserName = dto.UserName});
            if (result.IsSuccess)
            {
                return this.SuccessActionResult(true);
            }
            else
            {
                return this.ErrorActionResult(result.Message, false);
            }
        }
     }

    public class StockAdjCreateDeficitRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 盘盈单ID列表
        /// </summary>
        public IList<string> AdjIds { get; set; }

        /// <summary>
        /// 仓库Code
        /// </summary>
        public string WCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WName { get; set; }

        /// <summary>
        /// 子仓库ID
        /// </summary>
        public int SubWid { get; set; }

        /// <summary>
        /// 子仓库code
        /// </summary>
        public string SubWcode { get; set; }

        /// <summary>
        /// 子仓库名称
        /// </summary>
        public string SubWName { get; set; }
    }
}
