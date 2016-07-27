
/*****************************
* Author:chujl
*
* Date:2016-03-28
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleFeePre数据库访问接口
    /// </summary>
    public partial interface ISaleFeePreDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证SaleFeePre是否存在
        /// <summary>
        /// 根据主键验证SaleFeePre是否存在
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleFeePre model);
        #endregion


        #region 添加一个SaleFeePre
        /// <summary>
        /// 添加一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleFeePre model);
        /// <summary>
        /// 添加一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleFeePre model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个SaleFeePre
        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleFeePre model);
        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        int EditStatus(SaleFeePre model, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feeId"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int EditAndCopy(string feeId, IDbConnection conn, IDbTransaction trans);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feeId"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int EditAndCopy2(string feeId, IDbConnection conn, IDbTransaction trans);
        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleFeePre model, IDbConnection conn, IDbTransaction trans);
        
        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        int EditStatusReset(SaleFeePre model, IDbConnection conn, IDbTransaction trans);
        
        #endregion


        #region 删除一个SaleFeePre
        /// <summary>
        /// 删除一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleFeePre model);
        #endregion


        #region 根据主键逻辑删除一个SaleFeePre
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeePre
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string feeID);
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeePre
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string feeID, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据字典获取SaleFeePre对象
        /// <summary>
        /// 根据字典获取SaleFeePre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeePre对象</returns>
        SaleFeePre GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleFeePre对象
        /// <summary>
        /// 根据主键获取SaleFeePre对象
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>SaleFeePre对象</returns>
        SaleFeePre GetModel(string feeID);
        #endregion


        #region 根据字典获取SaleFeePre集合
        /// <summary>
        /// 根据字典获取SaleFeePre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleFeePre> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleFeePre数据集
        /// <summary>
        /// 根据字典获取SaleFeePre数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleFeePre集合
        /// <summary>
        /// 分页获取SaleFeePre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleFeePre> GetPageList(PageListBySql<SaleFeePre> page, IDictionary<string, object> conditionDict);
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