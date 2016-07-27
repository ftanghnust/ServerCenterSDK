
/*****************************
* Author:leidong
*
* Date:2016-04-11
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleOrderSendNumber数据库访问接口
    /// </summary>
    public partial interface ISaleOrderSendNumberDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderSendNumber是否存在
        /// <summary>
        /// 根据主键验证SaleOrderSendNumber是否存在
        /// </summary>
        /// <param name="model">SaleOrderSendNumber对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderSendNumber model);
        #endregion


        #region 添加一个SaleOrderSendNumber
        /// <summary>
        /// 添加一个SaleOrderSendNumber
        /// </summary>
        /// <param name="model">SaleOrderSendNumber对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderSendNumber model);
        #endregion


        #region 添加一个SaleOrderSendNumber(事务处理)
        /// <summary>
        /// 添加一个SaleOrderSendNumber(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderSendNumber对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleOrderSendNumber model);
        #endregion


        #region 更新一个SaleOrderSendNumber
        /// <summary>
        /// 更新一个SaleOrderSendNumber
        /// </summary>
        /// <param name="model">SaleOrderSendNumber对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderSendNumber model);
        #endregion


        #region 更新一个SaleOrderSendNumber(事务处理)
        /// <summary>
        /// 更新一个SaleOrderSendNumber(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderSendNumber对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderSendNumber model);
        #endregion


        #region 删除一个SaleOrderSendNumber
        /// <summary>
        /// 删除一个SaleOrderSendNumber
        /// </summary>
        /// <param name="model">SaleOrderSendNumber对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderSendNumber model);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderSendNumber
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderSendNumber
        /// </summary>
        /// <param name="orderID">订单编号(SaleOrder.OrderID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string orderID);
        #endregion


        #region 根据字典获取SaleOrderSendNumber对象
        /// <summary>
        /// 根据字典获取SaleOrderSendNumber对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderSendNumber对象</returns>
        SaleOrderSendNumber GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleOrderSendNumber对象
        /// <summary>
        /// 根据主键获取SaleOrderSendNumber对象
        /// </summary>
        /// <param name="orderID">订单编号(SaleOrder.OrderID)</param>
        /// <returns>SaleOrderSendNumber对象</returns>
        SaleOrderSendNumber GetModel(string orderID);
        #endregion


        #region 根据字典获取SaleOrderSendNumber集合
        /// <summary>
        /// 根据字典获取SaleOrderSendNumber集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderSendNumber> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderSendNumber数据集
        /// <summary>
        /// 根据字典获取SaleOrderSendNumber数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderSendNumber集合
        /// <summary>
        /// 分页获取SaleOrderSendNumber集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderSendNumber> GetPageList(PageListBySql<SaleOrderSendNumber> page, IDictionary<string, object> conditionDict);
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