
/*****************************
* Author:CR
*
* Date:2016-04-13
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleOrderPrePacking数据库访问接口
    /// </summary>
    public partial interface ISaleOrderPrePackingDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderPrePacking是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPrePacking是否存在
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderPrePacking model);
        #endregion


        #region 添加一个SaleOrderPrePacking
        /// <summary>
        /// 添加一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderPrePacking model);
        #endregion


        #region 添加一个SaleOrderPrePacking(事务处理)
        /// <summary>
        /// 添加一个SaleOrderPrePacking(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleOrderPrePacking model);
        #endregion


        #region 更新一个SaleOrderPrePacking
        /// <summary>
        /// 更新一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderPrePacking model);
        #endregion


        #region 更新一个SaleOrderPrePacking(事务处理)
        /// <summary>
        /// 更新一个SaleOrderPrePacking(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderPrePacking model);
        #endregion


        #region 删除一个SaleOrderPrePacking
        /// <summary>
        /// 删除一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderPrePacking model);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPrePacking
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPrePacking
        /// </summary>
        /// <param name="orderID">订单编号(SaleOrder.OrderID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string orderID);
        #endregion


        #region 根据字典获取SaleOrderPrePacking对象
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderPrePacking对象</returns>
        SaleOrderPrePacking GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleOrderPrePacking对象
        /// <summary>
        /// 根据主键获取SaleOrderPrePacking对象
        /// </summary>
        /// <param name="orderID">订单编号(SaleOrder.OrderID)</param>
        /// <returns>SaleOrderPrePacking对象</returns>
        SaleOrderPrePacking GetModel(string orderID);
        #endregion


        #region 根据字典获取SaleOrderPrePacking集合
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPrePacking> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderPrePacking数据集
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderPrePacking集合
        /// <summary>
        /// 分页获取SaleOrderPrePacking集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderPrePacking> GetPageList(PageListBySql<SaleOrderPrePacking> page, IDictionary<string, object> conditionDict);
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

    public partial interface ISaleOrderPrePackingDAO
    {
        /// <summary>
        /// 根据OrderId删除明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        int DeleteByOrderId(string orderId, IDbConnection conn, IDbTransaction tran);
    }
}