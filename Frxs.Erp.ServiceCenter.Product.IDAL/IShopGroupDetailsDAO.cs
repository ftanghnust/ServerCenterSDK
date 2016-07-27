
/*****************************
* Author:CR
*
* Date:2016-03-25
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 门店群组明细表ShopGroupDetails数据库访问接口
    /// </summary>
    public partial interface IShopGroupDetailsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证ShopGroupDetails是否存在
        /// <summary>
        /// 根据主键验证ShopGroupDetails是否存在
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ShopGroupDetails model);
        #endregion


        #region 添加一个ShopGroupDetails
        /// <summary>
        /// 添加一个ShopGroupDetails
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ShopGroupDetails model);
        #endregion


        #region 更新一个ShopGroupDetails
        /// <summary>
        /// 更新一个ShopGroupDetails
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ShopGroupDetails model);
        #endregion


        #region 删除一个ShopGroupDetails
        /// <summary>
        /// 删除一个ShopGroupDetails
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(ShopGroupDetails model);
        #endregion


        #region 根据主键逻辑删除一个ShopGroupDetails
        /// <summary>
        /// 根据主键逻辑删除一个ShopGroupDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取ShopGroupDetails对象
        /// <summary>
        /// 根据字典获取ShopGroupDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShopGroupDetails对象</returns>
        ShopGroupDetails GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ShopGroupDetails对象
        /// <summary>
        /// 根据主键获取ShopGroupDetails对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ShopGroupDetails对象</returns>
        ShopGroupDetails GetModel(int iD);
        #endregion


        #region 根据字典获取ShopGroupDetails集合
        /// <summary>
        /// 根据字典获取ShopGroupDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ShopGroupDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ShopGroupDetails数据集
        /// <summary>
        /// 根据字典获取ShopGroupDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ShopGroupDetails集合
        /// <summary>
        /// 分页获取ShopGroupDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ShopGroupDetails> GetPageList(PageListBySql<ShopGroupDetails> page, IDictionary<string, object> conditionDict);
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

    public partial interface IShopGroupDetailsDAO : IBaseDAO
    {
        #region 删除某个分组对应的详情记录ShopGroupDetails
        /// <summary>
        /// 删除某个分组对应的详情记录
        /// </summary>
        /// <param name="GroupID">GroupID</param>
        /// <returns>数据库影响行数</returns>
        int DeleteByGroupID(int GroupID);
        #endregion

        #region 删除某个分组对应的详情记录ShopGroupDetails 事务操作
        /// <summary>
        /// 删除某个分组对应的详情记录
        /// </summary>
        /// <param name="GroupID">GroupID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int DeleteByGroupID(int GroupID, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 添加一个ShopGroupDetails 事务操作
        /// <summary>
        /// 添加一个ShopGroupDetails 事务操作
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ShopGroupDetails model, IDbConnection conn, IDbTransaction tran);
        #endregion
    }
}