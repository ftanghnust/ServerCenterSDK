using Frxs.Erp.ServiceCenter.Order.IDAL.Order;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Platform.IOCFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    public class StockQueryBLO
    {
        /// <summary>
        /// 根据条件获取库存信息
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        public static IList<StockSreachQtyModel> QueryStockQty(StockQtyQuery qmod)
        {
            return DALFactory.GetLazyInstance<IStockQueryDAO>(qmod.WID.ToString()).QueryStockQty(qmod);
        }

        /// <summary>
        /// 查询总库存信息
        /// </summary>
        /// <param name="qmod"></param>
        /// <returns></returns>
        public static IList<StockOQtyModel> QueryOStockQty(StockNQtyQuery qmod)
        {
            IList<StockOQtyModel> dataList = new List<StockOQtyModel>();
            foreach (int wid in qmod.WIDList)
            {
                StockNQtyQuery query = new StockNQtyQuery();
                query.WIDList = new List<int>() { wid };
                query.PDIDList = qmod.PDIDList;
                query.SKUList = qmod.SKUList;
                //条库分库查询
                var list = DALFactory.GetLazyInstance<IStockQueryDAO>(wid.ToString()).QueryOStockQty(query);
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        dataList.Add(list[i]);
                    }
                }
            }
            return dataList;
        }

        /// <summary>
        /// 获取库存表中的当前仓库的最小日期（开档日）
        /// </summary>
        /// <param name="wid">仓库编号 </param>
        /// <param name="subwid">子仓库编号 </param>
        /// <returns>开档日期</returns>
        public static DateTime GetStockQtyCreateMinDate(int wid, int subwid)
        {
            DateTime createMinDate = DALFactory.GetLazyInstance<IStockQueryDAO>(wid.ToString()).
                GetStockQtyCreateMinDate(wid, subwid);
            return createMinDate;
        }
    }
}
