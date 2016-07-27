/*****************************
* Author:罗靖
*
* Date:2016-06-17
******************************/

using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### Settlement数据库访问接口
    /// </summary>
    public partial interface ISettlementDAO : IBaseDAO
    {
        #region  成员方法
        #region 根据主键验证Settlement是否存在
        /// <summary>
        /// 根据主键验证Settlement是否存在
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>是否存在</returns>
        bool Exists(Settlement model);
        #endregion


        #region 添加一个Settlement
        /// <summary>
        /// 添加一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(Settlement model);
        #endregion


        #region 添加一个Settlement(事务处理)
        /// <summary>
        /// 添加一个Settlement(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">Settlement对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, Settlement model);
        #endregion


        #region 更新一个Settlement
        /// <summary>
        /// 更新一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(Settlement model);
        #endregion


        #region 更新一个Settlement(事务处理)
        /// <summary>
        /// 更新一个Settlement(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, Settlement model);
        #endregion


        #region 删除一个Settlement
        /// <summary>
        /// 删除一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(Settlement model);
        #endregion


        #region 根据主键逻辑删除一个Settlement
        /// <summary>
        /// 根据主键逻辑删除一个Settlement
        /// </summary>
        /// <param name="iD">ID(GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取Settlement对象
        /// <summary>
        /// 根据字典获取Settlement对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>Settlement对象</returns>
        Settlement GetModel(SettlementQuery query);
        #endregion


        #region 根据主键获取Settlement对象
        /// <summary>
        /// 根据主键获取Settlement对象
        /// </summary>
        /// <param name="iD">ID(GUID)</param>
        /// <returns>Settlement对象</returns>
        Settlement GetModel(string iD);
        #endregion


        #region 根据字典获取Settlement集合
        /// <summary>
        /// 根据字典获取Settlement集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<Settlement> GetList(SettlementQuery query);
        #endregion


        #region 根据字典获取Settlement数据集
        /// <summary>
        /// 根据字典获取Settlement数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取Settlement集合
        /// <summary>
        /// 分页获取Settlement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<Settlement> GetPageList(PageListBySql<Settlement> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion
    }
    /// <summary>
    /// Settlement数据库访问接口 龙武
    /// </summary>
    public partial interface ISettlementDAO
    { 
         /// <summary>
        /// 分页获取Settlement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<Settlement> GetSettlementList(PageListBySql<Settlement> page, IDictionary<string, object> conditionDict);
    }

    /// <summary>
    /// 罗靖 业务逻辑
    /// </summary>
    public partial interface ISettlementDAO : IBaseDAO
    {

        #region 根据仓库编号,子仓库编号,结算日期来验证Settlement对象是否存在

        /// <summary>
        /// 根据仓库编号,子仓库编号,结算日期来验证Settlement对象是否存在
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>是否存在</returns>
        bool ExistsSettleDate(Settlement model);

        #endregion


        /// <summary>
        /// 获取最后一次结算的结束时间作为这次的开始时间
        /// </summary>
        /// <param name="wId"> </param>
        /// <param name="subWId"> </param>
        /// <returns></returns>
        DateTime? GetSettleStartTime(int wId, int subWId);

        /// <summary>
        /// 最后 根据条件修改单据的结算单号和结算时间
        /// </summary>
        /// <param name="query"></param>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        int UpdateBillSettleIdAndSettleTime(IDbConnection conn, IDbTransaction tran, GetUpdateBillQuery query, string procedureName);


        #region 删除一个Settlement(事务处理)

        /// <summary>
        /// 删除一个Settlement(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(IDbConnection conn, IDbTransaction tran, Settlement model);

        #endregion

    }
}
