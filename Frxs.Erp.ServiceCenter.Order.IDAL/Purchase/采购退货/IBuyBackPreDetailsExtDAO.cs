
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### BuyBackPreDetailsExt数据库访问接口
    /// </summary>
    public partial interface IBuyBackPreDetailsExtDAO
    {


        #region 成员方法
        #region 根据主键验证BuyBackPreDetailsExt是否存在
        /// <summary>
        /// 根据主键验证BuyBackPreDetailsExt是否存在
        /// </summary>
        /// <param name="model">BuyBackPreDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyBackPreDetailsExt model);
        #endregion


        #region 事务添加一个BuyBackPreDetailsExt
        /// <summary>
        /// 事务添加一个BuyBackPreDetailsExt
        /// </summary>
        /// <param name="model">BuyBackPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyBackPreDetailsExt model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个BuyBackPreDetailsExt
        /// <summary>
        /// 更新一个BuyBackPreDetailsExt
        /// </summary>
        /// <param name="model">BuyBackPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyBackPreDetailsExt model);
        #endregion


        #region 删除一个BuyBackPreDetailsExt
        /// <summary>
        /// 删除一个BuyBackPreDetailsExt
        /// </summary>
        /// <param name="model">BuyBackPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyBackPreDetailsExt model);
        #endregion


        #region 根据主键逻辑删除一个BuyBackPreDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个BuyBackPreDetailsExt
        /// </summary>
        /// <param name="iD">编号(BuyBackDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取BuyBackPreDetailsExt对象
        /// <summary>
        /// 根据字典获取BuyBackPreDetailsExt对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BuyBackPreDetailsExt对象</returns>
        BuyBackPreDetailsExt GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取BuyBackPreDetailsExt对象
        /// <summary>
        /// 根据主键获取BuyBackPreDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(BuyBackDetails.ID)</param>
        /// <returns>BuyBackPreDetailsExt对象</returns>
        BuyBackPreDetailsExt GetModel(string iD);
        #endregion


        #region 根据字典获取BuyBackPreDetailsExt集合  包含历史表数据
        /// <summary>
        /// 根据字典获取BuyBackPreDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyBackPreDetailsExt> GetList(IDictionary<string, object> conditionDict);
        #endregion

        #region 根据字典获取BuyBackPreDetailsExt集合  不含历史表数据
        /// <summary>
        /// 根据字典获取BuyBackPreDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyBackPreDetailsExt> GetListByPre(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取BuyBackPreDetailsExt数据集
        /// <summary>
        /// 根据字典获取BuyBackPreDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BuyBackPreDetailsExt集合
        /// <summary>
        /// 分页获取BuyBackPreDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<BuyBackPreDetailsExt> GetPageList(PageListBySql<BuyBackPreDetailsExt> page, IDictionary<string, object> conditionDict);
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList);
        #endregion


        #endregion


    }

    public partial interface IBuyBackPreDetailsExtDAO
    {
        /// <summary>
        /// 根据BackID批量删除BackOrderPreDetailsExt
        /// </summary>
        /// <param name="BackID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int Delete(string BuyID, IDbConnection conn, IDbTransaction trans);
    }
}