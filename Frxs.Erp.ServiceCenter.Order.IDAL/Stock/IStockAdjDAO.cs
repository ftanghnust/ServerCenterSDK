
/*****************************
* Author:CR
*
* Date:2016-04-14
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### StockAdj数据库访问接口
    /// </summary>
    public partial interface IStockAdjDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证StockAdj是否存在
        /// <summary>
        /// 根据主键验证StockAdj是否存在
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <returns>是否存在</returns>
        bool Exists(StockAdj model);
        #endregion


        #region 添加一个StockAdj
        /// <summary>
        /// 添加一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(StockAdj model);
        #endregion


        #region 添加一个StockAdj(事务处理)
        /// <summary>
        /// 添加一个StockAdj(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdj对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, StockAdj model);
        #endregion


        #region 更新一个StockAdj
        /// <summary>
        /// 更新一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(StockAdj model);
        #endregion


        #region 更新一个StockAdj(事务处理)
        /// <summary>
        /// 更新一个StockAdj(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, StockAdj model);
        #endregion


        #region 删除一个StockAdj
        /// <summary>
        /// 删除一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(StockAdj model);
        #endregion


        #region 根据主键逻辑删除一个StockAdj
        /// <summary>
        /// 根据主键逻辑删除一个StockAdj
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string adjID);
        #endregion


        #region 根据字典获取StockAdj对象
        /// <summary>
        /// 根据字典获取StockAdj对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>StockAdj对象</returns>
        StockAdj GetModel(StockAdjQuery query);
        #endregion


        #region 根据主键获取StockAdj对象
        /// <summary>
        /// 根据主键获取StockAdj对象
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>StockAdj对象</returns>
        StockAdj GetModel(string adjID);
        #endregion


        #region 根据字典获取StockAdj集合
        /// <summary>
        /// 根据字典获取StockAdj集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<StockAdj> GetList(StockAdjQuery query);
        #endregion


        #region 根据字典获取StockAdj数据集
        /// <summary>
        /// 根据字典获取StockAdj数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取StockAdj集合
        /// <summary>
        /// 分页获取StockAdj集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<StockAdj> GetPageList(PageListBySql<StockAdj> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion



    }

    public partial interface IStockAdjDAO : IBaseDAO
    {
        #region 删除一个StockAdj
        /// <summary>
        /// 删除一个StockAdj
        /// </summary>
        /// <param name="adjID">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string adjID);
        #endregion

        #region 删除一个StockAdj 事务处理
        /// <summary>
        /// 删除一个StockAdj 事务处理
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="adjID">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(IDbConnection conn, IDbTransaction tran, string adjID);
        #endregion

        #region 根据AdjID获取明细表数量
        /// <summary>
        /// 根据AdjID获取明细表数量
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <returns>盘点调整明细表数量</returns>
        int GetDetailCount(string adjID);
        #endregion

        #region 根据AdjID获取明细表最大序号
        /// <summary>
        /// 根据AdjID获取明细表最大序号
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <returns>明细表最大序号</returns>
        int GetDetailMaxSerialNumber(string adjID);
        #endregion

        #region 根据AdjID获取调整总数和总金额
        /// <summary>
        /// 根据AdjID获取调整总数和总金额
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <returns>盘点调整单下的总计对象(总数、总金额)</returns>
        StockAdjSum GetSumQtyAmt(string adjID);
        #endregion

        #region 根据AdjID获取调整 明细的差额对象集合，适用于盘亏单过账操作的异常数据预先排查
        /// <summary>
        /// 根据AdjID获取调整 明细的差额对象集合，适用于盘亏单过账操作的异常数据预先排查
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <returns>明细的差额对象集合</returns>
        IList<StockAdjDif> GetAdjDif(string adjID);
        #endregion

        #region 根据AdjID检查盘亏单的明细的实时库存和调整数差额，用于盘亏单过账操作的异常数据预先排查
        /// <summary>
        /// 根据AdjID检查盘亏单的明细的实时库存和调整数差额，用于盘亏单过账操作的异常数据预先排查
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <returns>明细的差额对象集合</returns>
        IList<StockAdjDif> GetAdjQtys(string adjID);
        #endregion
    }

    public partial interface IStockAdjDAO : IBaseDAO
    {
        /// <summary>
        ///  根据orderId获取其盘盈盘亏单
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="adjType">0-盘盈单 1-盘亏单</param>
        /// <returns></returns>
        IList<StockAdj> GetModelByOrderId(string orderId, int? adjType);

        /// <summary>
        /// 根据单号获取列表
        /// </summary>
        /// <param name="ids">单号列表</param>
        /// <returns></returns>
        IList<StockAdj> GetListByAdjIds(IList<string> ids);

    }
}