
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
    /// ### SaleFeePreDetails数据库访问接口
    /// </summary>
    public partial interface ISaleFeePreDetailsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证SaleFeePreDetails是否存在
        /// <summary>
        /// 根据主键验证SaleFeePreDetails是否存在
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleFeePreDetails model);
        #endregion


        #region 添加一个SaleFeePreDetails
        /// <summary>
        /// 添加一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleFeePreDetails model);
        /// <summary>
        /// 添加一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleFeePreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个SaleFeePreDetails
        /// <summary>
        /// 更新一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleFeePreDetails model);
        /// <summary>
        /// 更新一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleFeePreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 删除一个SaleFeePreDetails
        /// <summary>
        /// 删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleFeePreDetails model);
        /// <summary>
        /// 删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string feeId, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据主键逻辑删除一个SaleFeePreDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleFeePreDetails对象
        /// <summary>
        /// 根据字典获取SaleFeePreDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeePreDetails对象</returns>
        SaleFeePreDetails GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleFeePreDetails对象
        /// <summary>
        /// 根据主键获取SaleFeePreDetails对象
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>SaleFeePreDetails对象</returns>
        SaleFeePreDetails GetModel(string iD);
        #endregion


        #region 根据字典获取SaleFeePreDetails集合
        /// <summary>
        /// 根据字典获取SaleFeePreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleFeePreDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleFeePreDetails数据集
        /// <summary>
        /// 根据字典获取SaleFeePreDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleFeePreDetails集合
        /// <summary>
        /// 分页获取SaleFeePreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleFeePreDetails> GetPageList(PageListBySql<SaleFeePreDetails> page, IDictionary<string, object> conditionDict);
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