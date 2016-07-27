
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
    /// ### SaleBackPre数据库访问接口
    /// </summary>
    public partial interface ISaleBackPreDAO : IBaseDAO
    {


        #region 成员方法


        #region 事务添加一个SaleBackPre
        /// <summary>
        /// 添加一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 事务更新一个SaleBackPre
        /// <summary>
        /// 更新一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 更新一个SaleBackPre(更改状态使用)
        /// <summary>
        /// 更新一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int EditInChange(SaleBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 事务删除一个SaleBackPre
        /// <summary>
        /// 删除一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 根据字典获取SaleBackPre对象
        /// <summary>
        /// 根据字典获取SaleBackPre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleBackPre对象</returns>
        SaleBackPre GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleBackPre对象
        /// <summary>
        /// 根据主键获取SaleBackPre对象
        /// </summary>
        /// <param name="backID">退货单编号</param>
        /// <returns>SaleBackPre对象</returns>
        SaleBackPre GetModel(string backID);
        #endregion


        #region 根据字典获取SaleBackPre集合
        /// <summary>
        /// 根据字典获取SaleBackPre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleBackPre> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleBackPre数据集
        /// <summary>
        /// 根据字典获取SaleBackPre数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleBackPre集合
        /// <summary>
        /// 分页获取SaleBackPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleBackPre> GetPageList(PageListBySql<SaleBackPre> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }
}