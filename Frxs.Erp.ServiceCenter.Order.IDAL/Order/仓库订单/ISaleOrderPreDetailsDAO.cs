
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
    /// ### SaleOrderPreDetails数据库访问接口
    /// </summary>
    public partial interface ISaleOrderPreDetailsDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderPreDetails是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPreDetails是否存在
        /// </summary>
        /// <param name="model">SaleOrderPreDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderPreDetails model);
        #endregion


        #region 添加一个SaleOrderPreDetails
        /// <summary>
        /// 添加一个SaleOrderPreDetails
        /// </summary>
        /// <param name="model">SaleOrderPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderPreDetails model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 更新一个SaleOrderPreDetails
        /// <summary>
        /// 更新一个SaleOrderPreDetails
        /// </summary>
        /// <param name="model">SaleOrderPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderPreDetails model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 删除一个SaleOrderPreDetails
        /// <summary>
        /// 删除一个SaleOrderPreDetails
        /// </summary>
        /// <param name="model">SaleOrderPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderPreDetails model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPreDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPreDetails
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleOrderPreDetails对象
        /// <summary>
        /// 根据字典获取SaleOrderPreDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderPreDetails对象</returns>
        SaleOrderPreDetails GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleOrderPreDetails对象
        /// <summary>
        /// 根据主键获取SaleOrderPreDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>SaleOrderPreDetails对象</returns>
        SaleOrderPreDetails GetModel(string iD);
        #endregion


        #region 根据字典获取SaleOrderPreDetails集合
        /// <summary>
        /// 根据字典获取SaleOrderPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPreDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderPreDetails数据集
        /// <summary>
        /// 根据字典获取SaleOrderPreDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderPreDetails集合
        /// <summary>
        /// 分页获取SaleOrderPreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleOrderPreDetails> GetPageList(PageListBySql<SaleOrderPreDetails> page, IDictionary<string, object> conditionDict);
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


    public partial interface ISaleOrderPreDetailsDAO
    {
        /// <summary>
        /// 根据OrderId删除商品明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        int DeleteByOrderId(string orderId, IDbConnection conn, IDbTransaction tran);

        #region 根据字典获取SaleOrderPreDetails集合(事物)
        /// <summary>
        /// 根据字典获取SaleOrderPreDetails集合(事物)
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPreDetails> GetList(IDbConnection conn, IDbTransaction tran, IDictionary<string, object> conditionDict);
        
        #endregion
    }
}