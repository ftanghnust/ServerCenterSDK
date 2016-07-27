
/*****************************
* Author:leidong
*
* Date:2016-04-05
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleOrderPreDetailsExt数据库访问接口
    /// </summary>
    public partial interface ISaleOrderPreDetailsExtDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderPreDetailsExt是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPreDetailsExt是否存在
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderPreDetailsExt model);
        #endregion


        #region 添加一个SaleOrderPreDetailsExt
        /// <summary>
        /// 添加一个SaleOrderPreDetailsExt
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderPreDetailsExt model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 更新一个SaleOrderPreDetailsExt
        /// <summary>
        /// 更新一个SaleOrderPreDetailsExt
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderPreDetailsExt model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 删除一个SaleOrderPreDetailsExt
        /// <summary>
        /// 删除一个SaleOrderPreDetailsExt
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderPreDetailsExt model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPreDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPreDetailsExt
        /// </summary>
        /// <param name="iD">编号(SaleOrderDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleOrderPreDetailsExt对象
        /// <summary>
        /// 根据字典获取SaleOrderPreDetailsExt对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderPreDetailsExt对象</returns>
        SaleOrderPreDetailsExt GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleOrderPreDetailsExt对象
        /// <summary>
        /// 根据主键获取SaleOrderPreDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(SaleOrderDetails.ID)</param>
        /// <returns>SaleOrderPreDetailsExt对象</returns>
        SaleOrderPreDetailsExt GetModel(string iD);
        #endregion


        #region 根据字典获取SaleOrderPreDetailsExt集合
        /// <summary>
        /// 根据字典获取SaleOrderPreDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPreDetailsExt> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderPreDetailsExt数据集
        /// <summary>
        /// 根据字典获取SaleOrderPreDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderPreDetailsExt集合
        /// <summary>
        /// 分页获取SaleOrderPreDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleOrderPreDetailsExt> GetPageList(PageListBySql<SaleOrderPreDetailsExt> page, IDictionary<string, object> conditionDict);
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

    public partial interface ISaleOrderPreDetailsExtDAO
    {
        /// <summary>
        /// 根据OrderId删除商品明细扩展
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        int DeleteByOrderId(string orderId, IDbConnection conn, IDbTransaction tran);
    }
}