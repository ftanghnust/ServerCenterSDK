
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
    /// ### BuyBackDetailsExt数据库访问接口
    /// </summary>
    public partial interface IBuyBackDetailsExtDAO
    {


        #region 成员方法
        #region 根据主键验证BuyBackDetailsExt是否存在
        /// <summary>
        /// 根据主键验证BuyBackDetailsExt是否存在
        /// </summary>
        /// <param name="model">BuyBackDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyBackDetailsExt model);
        #endregion


        #region 事务添加一个BuyBackDetailsExt
        /// <summary>
        /// 事务添加一个BuyBackDetailsExt
        /// </summary>
        /// <param name="model">BuyBackDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyBackPreDetailsExt model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个BuyBackDetailsExt
        /// <summary>
        /// 更新一个BuyBackDetailsExt
        /// </summary>
        /// <param name="model">BuyBackDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyBackDetailsExt model);
        #endregion


        #region 删除一个BuyBackDetailsExt
        /// <summary>
        /// 删除一个BuyBackDetailsExt
        /// </summary>
        /// <param name="model">BuyBackDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyBackDetailsExt model);
        #endregion


        #region 根据主键逻辑删除一个BuyBackDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个BuyBackDetailsExt
        /// </summary>
        /// <param name="iD">编号(BuyBackDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取BuyBackDetailsExt对象
        /// <summary>
        /// 根据字典获取BuyBackDetailsExt对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BuyBackDetailsExt对象</returns>
        BuyBackDetailsExt GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取BuyBackDetailsExt对象
        /// <summary>
        /// 根据主键获取BuyBackDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(BuyBackDetails.ID)</param>
        /// <returns>BuyBackDetailsExt对象</returns>
        BuyBackDetailsExt GetModel(string iD);
        #endregion


        #region 根据字典获取BuyBackDetailsExt集合
        /// <summary>
        /// 根据字典获取BuyBackDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyBackDetailsExt> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取BuyBackDetailsExt数据集
        /// <summary>
        /// 根据字典获取BuyBackDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BuyBackDetailsExt集合
        /// <summary>
        /// 分页获取BuyBackDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<BuyBackDetailsExt> GetPageList(PageListBySql<BuyBackDetailsExt> page, IDictionary<string, object> conditionDict);
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
}