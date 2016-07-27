
/*****************************
* Author:CR
*
* Date:2016-04-15
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### StockAdjDetailsExt数据库访问接口
    /// </summary>
    public partial interface IStockAdjDetailsExtDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证StockAdjDetailsExt是否存在
        /// <summary>
        /// 根据主键验证StockAdjDetailsExt是否存在
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(StockAdjDetailsExt model);
        #endregion


        #region 添加一个StockAdjDetailsExt
        /// <summary>
        /// 添加一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(StockAdjDetailsExt model);
        #endregion


        #region 添加一个StockAdjDetailsExt(事务处理)
        /// <summary>
        /// 添加一个StockAdjDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, StockAdjDetailsExt model);
        #endregion


        #region 更新一个StockAdjDetailsExt
        /// <summary>
        /// 更新一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(StockAdjDetailsExt model);
        #endregion


        #region 更新一个StockAdjDetailsExt(事务处理)
        /// <summary>
        /// 更新一个StockAdjDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, StockAdjDetailsExt model);
        #endregion


        #region 删除一个StockAdjDetailsExt
        /// <summary>
        /// 删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(StockAdjDetailsExt model);
        #endregion


        #region 根据主键逻辑删除一个StockAdjDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="iD">编号(StockAdjDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取StockAdjDetailsExt对象
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>StockAdjDetailsExt对象</returns>
        StockAdjDetailsExt GetModel(StockAdjDetailsExtQuery query);
        #endregion


        #region 根据主键获取StockAdjDetailsExt对象
        /// <summary>
        /// 根据主键获取StockAdjDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(StockAdjDetails.ID)</param>
        /// <returns>StockAdjDetailsExt对象</returns>
        StockAdjDetailsExt GetModel(string iD);
        #endregion


        #region 根据字典获取StockAdjDetailsExt集合
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<StockAdjDetailsExt> GetList(StockAdjDetailsExtQuery query);
        #endregion


        #region 根据字典获取StockAdjDetailsExt数据集
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取StockAdjDetailsExt集合
        /// <summary>
        /// 分页获取StockAdjDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<StockAdjDetailsExt> GetPageList(PageListBySql<StockAdjDetailsExt> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }


    public partial interface IStockAdjDetailsExtDAO : IBaseDAO
    {
        #region 删除一个StockAdjDetailsExt
        /// <summary>
        /// 删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string id);
        #endregion

        #region 删除一个StockAdjDetailsExt 事务处理
        /// <summary>
        /// 删除一个StockAdjDetailsExt 事务处理
        /// </summary>        
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="id">主键</param>
        /// <returns>数据库影响行数</returns>
        int Delete(IDbConnection conn, IDbTransaction tran, string id);
        #endregion

        #region 根据AdjID 删除一批StockAdjDetailsExt 事务处理
        /// <summary>
        /// 根据AdjID 删除一批 StockAdjDetailsExt 事务处理
        /// </summary>        
        /// <param name="adjID">盘点调整单ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string adjID, IDbConnection conn, IDbTransaction tran);
        #endregion
    }
}