
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
    /// ### StockAdjDetail数据库访问接口
    /// </summary>
    public partial interface IStockAdjDetailDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证StockAdjDetail是否存在
        /// <summary>
        /// 根据主键验证StockAdjDetail是否存在
        /// </summary>
        /// <param name="model">StockAdjDetail对象</param>
        /// <returns>是否存在</returns>
        bool Exists(StockAdjDetail model);
        #endregion


        #region 添加一个StockAdjDetail
        /// <summary>
        /// 添加一个StockAdjDetail
        /// </summary>
        /// <param name="model">StockAdjDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(StockAdjDetail model);
        #endregion


        #region 添加一个StockAdjDetail(事务处理)
        /// <summary>
        /// 添加一个StockAdjDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdjDetail对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, StockAdjDetail model);
        #endregion


        #region 更新一个StockAdjDetail
        /// <summary>
        /// 更新一个StockAdjDetail
        /// </summary>
        /// <param name="model">StockAdjDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(StockAdjDetail model);
        #endregion


        #region 更新一个StockAdjDetail(事务处理)
        /// <summary>
        /// 更新一个StockAdjDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdjDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, StockAdjDetail model);
        #endregion


        #region 删除一个StockAdjDetail
        /// <summary>
        /// 删除一个StockAdjDetail
        /// </summary>
        /// <param name="model">StockAdjDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(StockAdjDetail model);
        #endregion


        #region 根据主键逻辑删除一个StockAdjDetail
        /// <summary>
        /// 根据主键逻辑删除一个StockAdjDetail
        /// </summary>
        /// <param name="iD">主键(仓库ID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取StockAdjDetail对象
        /// <summary>
        /// 根据字典获取StockAdjDetail对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>StockAdjDetail对象</returns>
        StockAdjDetail GetModel(StockAdjDetailQuery query);
        #endregion


        #region 根据主键获取StockAdjDetail对象
        /// <summary>
        /// 根据主键获取StockAdjDetail对象
        /// </summary>
        /// <param name="iD">主键(仓库ID+GUID)</param>
        /// <returns>StockAdjDetail对象</returns>
        StockAdjDetail GetModel(string iD);
        #endregion


        #region 根据字典获取StockAdjDetail集合
        /// <summary>
        /// 根据字典获取StockAdjDetail集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<StockAdjDetail> GetList(StockAdjDetailQuery query);
        #endregion


        #region 根据字典获取StockAdjDetail数据集
        /// <summary>
        /// 根据字典获取StockAdjDetail数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取StockAdjDetail集合
        /// <summary>
        /// 分页获取StockAdjDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<StockAdjDetail> GetPageList(PageListBySql<StockAdjDetail> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }

    public partial interface IStockAdjDetailDAO : IBaseDAO
    {
        #region 删除一个StockAdjDetail
        /// <summary>
        /// 删除一个StockAdjDetail
        /// </summary>
        /// <param name="ID">详情表主键值</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string ID);
        #endregion

        #region 删除一个StockAdjDetail 事务处理
        /// <summary>
        /// 删除一个StockAdjDetail 事务处理
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="ID">详情表主键值</param>
        /// <returns>数据库影响行数</returns>
        int Delete(IDbConnection conn, IDbTransaction tran, string ID);
        #endregion

        #region 根据AdjID 删除一批 StockAdjDetail 事务处理
        /// <summary>
        /// 根据AdjID 删除一批 StockAdjDetail 事务处理
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>        
        /// <returns>数据库影响行数</returns>
        int Delete(string adjID, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 根据adjID获取所有SKU集合
        /// <summary>
        /// 根据adjID获取所有SKU集合
        /// </summary>
        /// <param name="adjID">盘点调整单号</param>
        /// <returns>商品编号集合</returns>
        IList<string> GetSkuList(string adjID);
        #endregion
    }
}