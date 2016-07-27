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
    /// ### SaleSettleDetail数据库访问接口
    /// </summary>
    public partial interface ISaleSettleDetailDAO
    {
    

        #region  成员方法
        #region 根据主键验证SaleSettleDetail是否存在
        /// <summary>
        /// 根据主键验证SaleSettleDetail是否存在
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleSettleDetail model);
        #endregion


        #region 添加一个SaleSettleDetail
        /// <summary>
        /// 添加一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleSettleDetail model);
        #endregion


        #region 添加一个SaleSettleDetail(事务处理)
        /// <summary>
        /// 添加一个SaleSettleDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleSettleDetail model);
        #endregion


        #region 更新一个SaleSettleDetail
        /// <summary>
        /// 更新一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleSettleDetail model);
        #endregion


        #region 更新一个SaleSettleDetail(事务处理)
        /// <summary>
        /// 更新一个SaleSettleDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleSettleDetail model);
        #endregion


        #region 删除一个SaleSettleDetail
        /// <summary>
        /// 删除一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleSettleDetail model);
        #endregion


        #region 根据主键逻辑删除一个SaleSettleDetail
        /// <summary>
        /// 根据主键逻辑删除一个SaleSettleDetail
        /// </summary>
        /// <param name="iD">主键ID(WID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleSettleDetail对象
        /// <summary>
        /// 根据字典获取SaleSettleDetail对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleSettleDetail对象</returns>
        SaleSettleDetail GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleSettleDetail对象
        /// <summary>
        /// 根据主键获取SaleSettleDetail对象
        /// </summary>
        /// <param name="iD">主键ID(WID+GUID)</param>
        /// <returns>SaleSettleDetail对象</returns>
        SaleSettleDetail GetModel(string iD);
        #endregion


        #region 根据字典获取SaleSettleDetail集合
        /// <summary>
        /// 根据字典获取SaleSettleDetail集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleSettleDetail> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleSettleDetail数据集
        /// <summary>
        /// 根据字典获取SaleSettleDetail数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleSettleDetail集合
        /// <summary>
        /// 分页获取SaleSettleDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleSettleDetail> GetPageList(PageListBySql<SaleSettleDetail> page, IDictionary<string, object> conditionDict);
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

        #region 删除一个SaleSettleDetail
        /// <summary>
        /// 删除一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(IDbConnection conn, IDbTransaction tran, string SettleID);
       
        #endregion


    #endregion


    }
}
