
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
    /// ### SaleBack数据库访问接口
    /// </summary>
    public partial interface ISaleBackDAO
    {


        #region 成员方法
        #region 根据主键验证SaleBack是否存在
        /// <summary>
        /// 根据主键验证SaleBack是否存在
        /// </summary>
        /// <param name="model">SaleBack对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleBack model);
        #endregion


        #region 事务添加一个SaleBackPre
        /// <summary>
        /// 添加一个SaleBack
        /// </summary>
        /// <param name="model">SaleBack对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个SaleBack
        /// <summary>
        /// 更新一个SaleBack
        /// </summary>
        /// <param name="model">SaleBack对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleBack model);
        #endregion


        #region 删除一个SaleBack
        /// <summary>
        /// 删除一个SaleBack
        /// </summary>
        /// <param name="model">SaleBack对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleBack model);
        #endregion


        #region 根据主键逻辑删除一个SaleBack
        /// <summary>
        /// 根据主键逻辑删除一个SaleBack
        /// </summary>
        /// <param name="backID">退货单编号</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string backID);
        #endregion


        #region 根据字典获取SaleBack对象
        /// <summary>
        /// 根据字典获取SaleBack对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleBack对象</returns>
        SaleBack GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleBack对象
        /// <summary>
        /// 根据主键获取SaleBack对象
        /// </summary>
        /// <param name="backID">退货单编号</param>
        /// <returns>SaleBack对象</returns>
        SaleBack GetModel(string backID);
        #endregion


        #region 根据字典获取SaleBack集合
        /// <summary>
        /// 根据字典获取SaleBack集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleBack> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleBack数据集
        /// <summary>
        /// 根据字典获取SaleBack数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleBack集合
        /// <summary>
        /// 分页获取SaleBack集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleBack> GetPageList(PageListBySql<SaleBack> page, IDictionary<string, object> conditionDict);
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