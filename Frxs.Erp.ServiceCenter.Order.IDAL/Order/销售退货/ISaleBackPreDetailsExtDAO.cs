
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
    /// ### SaleBackPreDetailsExt数据库访问接口
    /// </summary>
    public partial interface ISaleBackPreDetailsExtDAO
    {


        #region 成员方法
        #region 根据主键验证SaleBackPreDetailsExt是否存在
        /// <summary>
        /// 根据主键验证SaleBackPreDetailsExt是否存在
        /// </summary>
        /// <param name="model">SaleBackPreDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleBackPreDetailsExt model);
        #endregion


        #region 事务添加一个SaleBackPreDetailsExt
        /// <summary>
        /// 添加一个SaleBackPreDetailsExt
        /// </summary>
        /// <param name="model">SaleBackPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleBackPreDetailsExt model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个SaleBackPreDetailsExt
        /// <summary>
        /// 更新一个SaleBackPreDetailsExt
        /// </summary>
        /// <param name="model">SaleBackPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleBackPreDetailsExt model);
        #endregion


        #region 删除一个SaleBackPreDetailsExt
        /// <summary>
        /// 删除一个SaleBackPreDetailsExt
        /// </summary>
        /// <param name="model">SaleBackPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleBackPreDetailsExt model);
        #endregion


        #region 根据主键逻辑删除一个SaleBackPreDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个SaleBackPreDetailsExt
        /// </summary>
        /// <param name="iD">编号(SaleBackDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleBackPreDetailsExt对象
        /// <summary>
        /// 根据字典获取SaleBackPreDetailsExt对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleBackPreDetailsExt对象</returns>
        SaleBackPreDetailsExt GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleBackPreDetailsExt对象
        /// <summary>
        /// 根据主键获取SaleBackPreDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(SaleBackDetails.ID)</param>
        /// <returns>SaleBackPreDetailsExt对象</returns>
        SaleBackPreDetailsExt GetModel(string iD);
        #endregion


        #region 根据字典获取SaleBackPreDetailsExt集合 包含历史表数据
        /// <summary>
        /// 根据字典获取SaleBackPreDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleBackPreDetailsExt> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleBackPreDetailsExt数据集
        /// <summary>
        /// 根据字典获取SaleBackPreDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleBackPreDetailsExt集合
        /// <summary>
        /// 分页获取SaleBackPreDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleBackPreDetailsExt> GetPageList(PageListBySql<SaleBackPreDetailsExt> page, IDictionary<string, object> conditionDict);
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
    public partial interface ISaleBackPreDetailsExtDAO
    {
        /// <summary>
        /// 根据BackID批量删除SaleBackPreDetailsExt
        /// </summary>
        /// <param name="BackID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int Delete(string BuyID, IDbConnection conn, IDbTransaction trans);

        #region 根据字典获取SaleBackPreDetailsExt集合 不含历史表数据
        /// <summary>
        /// 根据字典获取SaleBackPreDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleBackPreDetailsExt> GetListByPre(IDictionary<string, object> conditionDict);
        #endregion
    }
}