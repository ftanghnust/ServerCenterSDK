
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
    /// ### BuyOrderDetailsExt数据库访问接口
    /// </summary>
    public partial interface IBuyOrderDetailsExtDAO
    {


        #region 成员方法
        #region 根据主键验证BuyOrderDetailsExt是否存在
        /// <summary>
        /// 根据主键验证BuyOrderDetailsExt是否存在
        /// </summary>
        /// <param name="model">BuyOrderDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyOrderDetailsExt model);
        #endregion


        #region 事务添加一个BuyOrderDetailsExt
        /// <summary>
        /// 事务添加一个BuyOrderPreDetailsExt
        /// </summary>
        /// <param name="model">BuyOrderPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyOrderPreDetailsExt model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个BuyOrderDetailsExt
        /// <summary>
        /// 更新一个BuyOrderDetailsExt
        /// </summary>
        /// <param name="model">BuyOrderDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyOrderDetailsExt model);
        #endregion


        #region 删除一个BuyOrderDetailsExt
        /// <summary>
        /// 删除一个BuyOrderDetailsExt
        /// </summary>
        /// <param name="model">BuyOrderDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyOrderDetailsExt model);
        #endregion


        #region 根据主键逻辑删除一个BuyOrderDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个BuyOrderDetailsExt
        /// </summary>
        /// <param name="iD">编号(BuyOrderDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取BuyOrderDetailsExt对象
        /// <summary>
        /// 根据字典获取BuyOrderDetailsExt对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BuyOrderDetailsExt对象</returns>
        BuyOrderDetailsExt GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取BuyOrderDetailsExt对象
        /// <summary>
        /// 根据主键获取BuyOrderDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(BuyOrderDetails.ID)</param>
        /// <returns>BuyOrderDetailsExt对象</returns>
        BuyOrderDetailsExt GetModel(string iD);
        #endregion


        #region 根据字典获取BuyOrderDetailsExt集合
        /// <summary>
        /// 根据字典获取BuyOrderDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyOrderDetailsExt> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取BuyOrderDetailsExt数据集
        /// <summary>
        /// 根据字典获取BuyOrderDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BuyOrderDetailsExt集合
        /// <summary>
        /// 分页获取BuyOrderDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<BuyOrderDetailsExt> GetPageList(PageListBySql<BuyOrderDetailsExt> page, IDictionary<string, object> conditionDict);
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