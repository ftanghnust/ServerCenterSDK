using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.IDAL.Order
{
    public interface IStockQueryDAO
    {
        /// <summary>
        /// 根据条件获取SaleBack列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<StockSreachQtyModel> QueryStockQty(StockQtyQuery qmod);

        /// <summary>
        /// 查询各仓库库存信息
        /// </summary>
        /// <param name="qmod"></param>
        /// <returns></returns>
        IList<StockOQtyModel> QueryOStockQty(StockNQtyQuery qmod);


        /// <summary>
        /// 获取库存表中的当前仓库的最小日期（开档日）,如果没有时间,用当前时间去掉20天
        /// </summary>
        /// <param name="wId">仓库编号 </param>
        /// <param name="subWId">子仓库编号 </param>
        /// <returns></returns>
        DateTime GetStockQtyCreateMinDate(int wId, int subWId);
    }
}
