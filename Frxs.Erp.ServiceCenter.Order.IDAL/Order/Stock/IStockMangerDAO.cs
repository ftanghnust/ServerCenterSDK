using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.IDAL.Order.Stock
{
    public interface IStockMangerDAO
    {
        /// <summary>
        /// 增加一条批次入库操作
        /// </summary>
        long AddStockFIFOIn(StockFIFOInModel model, IDbConnection conn, IDbTransaction tran);

            /// <summary>
        /// 增加一条数据
        /// </summary>
        long AddStockFIFOOut(StockFIFOOutModel model, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 增加更新一条批次入库信息
        /// </summary>
        bool UpdateStockFIFOIn(StockFIFOInModel model, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 查询批次库存信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<StockFIFOInModel> QueryStockFIFOInList(QueryStockFIFOInModel model,IDbConnection conn = null, IDbTransaction tran = null);



         /// <summary>
        /// 增加一条数据库存信息
        /// </summary>
        int AddStockQty(StockQtyModel model, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 查询商品库存信息
        /// </summary>
        /// <param name="qmod"></param>
        /// <returns></returns>
        IList<StockQtyModel> QueryStockQtyList(StockQtyQueryModel model, IDbConnection conn = null, IDbTransaction tran = null);
        /// <summary>
        /// 更新总部库存数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="changeType"></param>
        /// <param name="changeQty">如果是增加库存为正，减库存负</param>
        /// <param name="changeUserID"></param>
        /// <param name="changeUserName"></param>
        /// <returns></returns>
        bool UpdateStockQty(int id, StockType changeType, decimal changeQty, int changeUserID, string changeUserName, IDbConnection conn, IDbTransaction tran);
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>连接对象</returns>
        IDbConnection GetConnection();

    }
}
