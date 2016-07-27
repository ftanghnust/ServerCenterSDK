using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    [Serializable]
    public class QueryStockQtyResponseDTO : ResponseDtoBase
    {
       public IList<StockSreachQtyModel> StockQtyList { get; set; }
    }
    [Serializable]
    public class StockQtyQueryDTO : RequestDtoBase
    {
        /// <summary>
        /// 商品ID列表
        /// </summary>
        public List<int> PDIDList { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 仓库子机构ID
        /// </summary>
        public int SubWID { get; set; }
    }

    /// <summary>
    /// 根据条件获取库存信息
    /// </summary>
    [ActionName("StockQty.Query")]
    public class QueryStockQtyAction : ActionBase<StockQtyQueryDTO, QueryStockQtyResponseDTO>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<QueryStockQtyResponseDTO> Execute()
        {
            var requestDto = this.RequestDto;

            StockQtyQuery query = new StockQtyQuery();
            query.WID = requestDto.WID;
            query.SubWID = requestDto.SubWID;
            query.PDIDList = requestDto.PDIDList;

            QueryStockQtyResponseDTO rsp = new QueryStockQtyResponseDTO();
            rsp.StockQtyList = StockQueryBLO.QueryStockQty(query);
            return SuccessActionResult(rsp);
        }
    }
}
