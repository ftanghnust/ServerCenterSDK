using Frxs.Erp.ServiceCenter.Order.BLL;
using Frxs.Erp.ServiceCenter.Order.IDAL.Order;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions
{
    
    [Serializable]
    public class StockOQtyQueryDTO : RequestDtoBase
    {
        /// <summary>
        /// 商品ID列表
        /// </summary>
        public List<int> PDIDList { get; set; }

        public List<string> SKUList { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public List<int> WIDList { get; set; }
    }

    /// <summary>
    /// 根据条件获取库存信息
    /// </summary>
    [ActionName("StockQtyList.Query")]
    public class QueryStockQtyListAction : ActionBase<StockOQtyQueryDTO, IList<StockOQtyModel>>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<StockOQtyModel>> Execute()
        {
            var requestDto = this.RequestDto;
            if (requestDto.PDIDList == null || requestDto.PDIDList.Count == 0)
            {
                return ErrorActionResult("查询商品ID不能为空");
            }
            if (requestDto.WIDList == null || requestDto.WIDList.Count == 0)
            {
                return ErrorActionResult("仓库列表不能为空");
            }
            IList<StockOQtyModel> dataList = new List<StockOQtyModel>();

            StockNQtyQuery query = new StockNQtyQuery();
            query.WIDList = requestDto.WIDList;
            query.PDIDList = requestDto.PDIDList;
            query.SKUList = requestDto.SKUList;

            dataList = StockQueryBLO.QueryOStockQty(query);
            return SuccessActionResult(dataList);
        }
    }
}
