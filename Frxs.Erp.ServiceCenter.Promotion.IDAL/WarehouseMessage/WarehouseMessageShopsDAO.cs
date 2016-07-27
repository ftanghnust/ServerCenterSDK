
/*****************************
* Author:chujl
*
* Date:2016-04-02
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Promotion.IDAL
{
    /// <summary>
    /// ### 仓库消息所属群组表WarehouseMessageShops数据库访问接口
    /// </summary>
    public partial interface IWarehouseMessageShopsDAO
    {


        #region 成员方法
        #region 根据主键验证WarehouseMessageShops是否存在
        /// <summary>
        /// 根据主键验证WarehouseMessageShops是否存在
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WarehouseMessageShops model);
        #endregion


        #region 添加一个WarehouseMessageShops
        /// <summary>
        /// 添加一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WarehouseMessageShops model, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 添加一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WarehouseMessageShops model);
        #endregion


        #region 更新一个WarehouseMessageShops
        /// <summary>
        /// 更新一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WarehouseMessageShops model);
        /// <summary>
        /// 更新一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WarehouseMessageShops model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 删除一个WarehouseMessageShops
        /// <summary>
        /// 删除一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WarehouseMessageShops model);
        #endregion


        #region 根据主键逻辑删除一个WarehouseMessageShops
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessageShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessageShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int messageId, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据字典获取WarehouseMessageShops对象
        /// <summary>
        /// 根据字典获取WarehouseMessageShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseMessageShops对象</returns>
        WarehouseMessageShops GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WarehouseMessageShops对象
        /// <summary>
        /// 根据主键获取WarehouseMessageShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WarehouseMessageShops对象</returns>
        WarehouseMessageShops GetModel(int iD);
        #endregion


        #region 根据字典获取WarehouseMessageShops集合
        /// <summary>
        /// 根据字典获取WarehouseMessageShops集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WarehouseMessageShops> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WarehouseMessageShops数据集
        /// <summary>
        /// 根据字典获取WarehouseMessageShops数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WarehouseMessageShops集合
        /// <summary>
        /// 分页获取WarehouseMessageShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WarehouseMessageShops> GetPageList(PageListBySql<WarehouseMessageShops> page, IDictionary<string, object> conditionDict);
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