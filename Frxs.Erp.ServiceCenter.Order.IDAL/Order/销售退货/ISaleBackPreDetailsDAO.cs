
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
    /// ### SaleBackPreDetails数据库访问接口
    /// </summary>
    public partial interface ISaleBackPreDetailsDAO
    {


        #region 成员方法
        #region 根据主键验证SaleBackPreDetails是否存在
        /// <summary>
        /// 根据主键验证SaleBackPreDetails是否存在
        /// </summary>
        /// <param name="model">SaleBackPreDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleBackPreDetails model);
        #endregion


        #region 事务添加一个SaleBackPreDetails
        /// <summary>
        /// 添加一个SaleBackPreDetails
        /// </summary>
        /// <param name="model">SaleBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleBackPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个SaleBackPreDetails
        /// <summary>
        /// 更新一个SaleBackPreDetails
        /// </summary>
        /// <param name="model">SaleBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleBackPreDetails model);
        #endregion


        #region 事务删除一个SaleBackPreDetails
        /// <summary>
        /// 删除一个SaleBackPreDetails
        /// </summary>
        /// <param name="model">SaleBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleBackPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据主键逻辑删除一个SaleBackPreDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleBackPreDetails
        /// </summary>
        /// <param name="iD">编号(GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleBackPreDetails对象
        /// <summary>
        /// 根据字典获取SaleBackPreDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleBackPreDetails对象</returns>
        SaleBackPreDetails GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleBackPreDetails对象
        /// <summary>
        /// 根据主键获取SaleBackPreDetails对象
        /// </summary>
        /// <param name="iD">编号(GUID)</param>
        /// <returns>SaleBackPreDetails对象</returns>
        SaleBackPreDetails GetModel(string iD);
        #endregion


        #region 根据字典获取SaleBackPreDetails集合 包含历史表数据
        /// <summary>
        /// 根据字典获取SaleBackPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleBackPreDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleBackPreDetails数据集
        /// <summary>
        /// 根据字典获取SaleBackPreDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleBackPreDetails集合
        /// <summary>
        /// 分页获取SaleBackPreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleBackPreDetails> GetPageList(PageListBySql<SaleBackPreDetails> page, IDictionary<string, object> conditionDict);
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

    public partial interface ISaleBackPreDetailsDAO
    {
        /// <summary>
        /// 根据BuyID批量删除SaleBackPreDetails
        /// </summary>
        /// <param name="BuyID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int Delete(string BuyID, IDbConnection conn, IDbTransaction trans);

        #region 根据字典获取SaleBackPreDetails集合 不含历史表数据
        /// <summary>
        /// 根据字典获取SaleBackPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleBackPreDetails> GetListByPre(IDictionary<string, object> conditionDict);
        #endregion
    }
}