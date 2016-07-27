
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
    /// ### BuyOrderPreDetailsExt数据库访问接口
    /// </summary>
    public partial interface IBuyOrderPreDetailsExtDAO
    {


        #region 成员方法
        #region 根据主键验证BuyOrderPreDetailsExt是否存在
        /// <summary>
        /// 根据主键验证BuyOrderPreDetailsExt是否存在
        /// </summary>
        /// <param name="model">BuyOrderPreDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyOrderPreDetailsExt model);
        #endregion


        #region 事务添加一个BuyOrderPreDetailsExt
        /// <summary>
        /// 添加一个BuyOrderPreDetailsExt
        /// </summary>
        /// <param name="model">BuyOrderPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyOrderPreDetailsExt model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个BuyOrderPreDetailsExt
        /// <summary>
        /// 更新一个BuyOrderPreDetailsExt
        /// </summary>
        /// <param name="model">BuyOrderPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyOrderPreDetailsExt model);
        #endregion


        #region 删除一个BuyOrderPreDetailsExt
        /// <summary>
        /// 删除一个BuyOrderPreDetailsExt
        /// </summary>
        /// <param name="model">BuyOrderPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyOrderPreDetailsExt model);
        #endregion


        #region 根据主键逻辑删除一个BuyOrderPreDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个BuyOrderPreDetailsExt
        /// </summary>
        /// <param name="iD">编号(BuyOrderPreDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取BuyOrderPreDetailsExt对象
        /// <summary>
        /// 根据字典获取BuyOrderPreDetailsExt对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BuyOrderPreDetailsExt对象</returns>
        BuyOrderPreDetailsExt GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取BuyOrderPreDetailsExt对象
        /// <summary>
        /// 根据主键获取BuyOrderPreDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(BuyOrderPreDetails.ID)</param>
        /// <returns>BuyOrderPreDetailsExt对象</returns>
        BuyOrderPreDetailsExt GetModel(string iD);
        #endregion


        #region 根据字典获取BuyOrderPreDetailsExt集合 包含历史表数据
        /// <summary>
        /// 根据字典获取BuyOrderPreDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyOrderPreDetailsExt> GetList(IDictionary<string, object> conditionDict);
        #endregion

        #region 根据字典获取BuyOrderPreDetailsExt集合 不含历史表数据
        /// <summary>
        /// 根据字典获取BuyOrderPreDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyOrderPreDetailsExt> GetListByPre(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取BuyOrderPreDetailsExt数据集
        /// <summary>
        /// 根据字典获取BuyOrderPreDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BuyOrderPreDetailsExt集合
        /// <summary>
        /// 分页获取BuyOrderPreDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<BuyOrderPreDetailsExt> GetPageList(PageListBySql<BuyOrderPreDetailsExt> page, IDictionary<string, object> conditionDict);
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


    public partial interface IBuyOrderPreDetailsExtDAO
    {
        /// <summary>
        /// 根据BuyID批量删除BuyOrderPreDetailsExt
        /// </summary>
        /// <param name="BuyID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int Delete(string BuyID, IDbConnection conn, IDbTransaction trans);
    }
}