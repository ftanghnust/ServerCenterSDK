
/*****************************
* Author:CR
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
    /// ### SaleSettle数据库访问接口
    /// </summary>
    public partial interface ISaleSettleDAO
    {


        #region 成员方法
        #region 根据主键验证SaleSettle是否存在
        /// <summary>
        /// 根据主键验证SaleSettle是否存在
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleSettle model);
        #endregion


        #region 添加一个SaleSettle
        /// <summary>
        /// 添加一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleSettle model);
        #endregion


        #region 添加一个SaleSettle(事务处理)
        /// <summary>
        /// 添加一个SaleSettle(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleSettle model);
        #endregion


        #region 更新一个SaleSettle
        /// <summary>
        /// 更新一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleSettle model);
        #endregion


        #region 更新一个SaleSettle(事务处理)
        /// <summary>
        /// 更新一个SaleSettle(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleSettle model);
        #endregion


        #region 删除一个SaleSettle
        /// <summary>
        /// 删除一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleSettle model);
        #endregion


        #region 根据主键逻辑删除一个SaleSettle
        /// <summary>
        /// 根据主键逻辑删除一个SaleSettle
        /// </summary>
        /// <param name="settleID">结算ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string settleID);
        #endregion


        #region 根据字典获取SaleSettle对象
        /// <summary>
        /// 根据字典获取SaleSettle对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleSettle对象</returns>
        SaleSettle GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleSettle对象
        /// <summary>
        /// 根据主键获取SaleSettle对象
        /// </summary>
        /// <param name="settleID">结算ID</param>
        /// <returns>SaleSettle对象</returns>
        SaleSettle GetModel(string settleID);
        #endregion


        #region 根据字典获取SaleSettle集合
        /// <summary>
        /// 根据字典获取SaleSettle集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleSettle> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleSettle数据集
        /// <summary>
        /// 根据字典获取SaleSettle数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleSettle集合

        /// <summary>
        /// 分页获取SaleSettle集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="totalAmt">添加 总页面合计字段</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleSettle> GetPageList(PageListBySql<SaleSettle> page, IDictionary<string, object> conditionDict, out decimal totalAmt);
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

    /// <summary>
    /// 扩展
    /// </summary>
    public partial interface ISaleSettleDAO
    {
        #region 扩展方法

        #region 获取零时表
        /// <summary>
        /// 根据字典获取SaleSettle集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<SaleSettleTemp> GetList(IDbConnection conn, IDbTransaction tran,int ShopID, int WID);
       
        #endregion

        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        int UpdateField(IDbConnection conn, IDbTransaction tran, IList<Field> fieldList, IList<WhereCondition> whereConditionList, string sqlTableName);
        
        #endregion

        #region 更新SaleFee结算状态
        /// <summary>
        /// 更新SaleFee结算状态
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        int SaveSaleFeeStatus(IDbConnection conn, IDbTransaction tran, string SettleID, int WID, int UserID, string UserName);
        
        #endregion

        #endregion


        #region 获取零时表
        /// <summary>
        /// 根据字典获取SaleSettle集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<SaleSettleTemp> GetList(int ShopID, int WID);
       
        #endregion

        #region 删除一个SaleSettle
        /// <summary>
        /// 删除一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        string Delete(IDbConnection conn, IDbTransaction tran, string SettleID);
        
        #endregion

        #region 根据主键获取SaleOrderPre对象(事物)
        /// <summary>
        /// 根据主键获取SaleOrderPre对象(事物)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderPre对象</returns>
        SaleSettle GetModel(IDbConnection conn, IDbTransaction tran, string settleID);
        
        #endregion

        #region 根据主键验证SaleSettle是否存在(事物)
        /// <summary>
        /// 根据主键验证SaleSettle是否存在
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>是否存在</returns>
        bool Exists(IDbConnection conn, IDbTransaction tran, SaleSettle model);
       
        #endregion
    }
}