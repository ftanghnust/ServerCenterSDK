
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
    /// ### SaleFeeDetails数据库访问接口
    /// </summary>
    public partial interface ISaleFeeDetailsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证SaleFeeDetails是否存在
        /// <summary>
        /// 根据主键验证SaleFeeDetails是否存在
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleFeeDetails model);
        #endregion


        #region 添加一个SaleFeeDetails
        /// <summary>
        /// 添加一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleFeeDetails model);
        #endregion


        #region 更新一个SaleFeeDetails
        /// <summary>
        /// 更新一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleFeeDetails model);
        #endregion


        #region 删除一个SaleFeeDetails
        /// <summary>
        /// 删除一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleFeeDetails model);
        #endregion


        #region 根据主键逻辑删除一个SaleFeeDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeeDetails
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleFeeDetails对象
        /// <summary>
        /// 根据字典获取SaleFeeDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeeDetails对象</returns>
        SaleFeeDetails GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleFeeDetails对象
        /// <summary>
        /// 根据主键获取SaleFeeDetails对象
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>SaleFeeDetails对象</returns>
        SaleFeeDetails GetModel(string iD);
        #endregion


        #region 根据字典获取SaleFeeDetails集合
        /// <summary>
        /// 根据字典获取SaleFeeDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleFeeDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleFeeDetails数据集
        /// <summary>
        /// 根据字典获取SaleFeeDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleFeeDetails集合
        /// <summary>
        /// 分页获取SaleFeeDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleFeeDetails> GetPageList(PageListBySql<SaleFeeDetails> page, IDictionary<string, object> conditionDict);
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