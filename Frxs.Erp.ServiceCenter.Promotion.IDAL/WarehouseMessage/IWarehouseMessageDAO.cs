
/*****************************
* Author:chujl
*
* Date:2016-03-23
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Promotion.IDAL
{
    /// <summary>
    /// ### WarehouseMessage数据库访问接口
    /// </summary>
    public partial interface IWarehouseMessageDAO : IBaseDAO
    {

        #region 成员方法
        #region 根据主键验证WarehouseMessage是否存在
        /// <summary>
        /// 根据主键验证WarehouseMessage是否存在
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WarehouseMessage model);
        #endregion


        #region 添加一个WarehouseMessage
        /// <summary>
        /// 添加一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WarehouseMessage model, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 添加一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WarehouseMessage model );
        #endregion


        #region 更新一个WarehouseMessage
        /// <summary>
        /// 更新一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WarehouseMessage model );

        /// <summary>
        /// 更新一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WarehouseMessage model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 删除一个WarehouseMessage
        /// <summary>
        /// 删除一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WarehouseMessage model);
        #endregion


        #region 根据主键逻辑删除一个WarehouseMessage
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessage
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessage
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据字典获取WarehouseMessage对象
        /// <summary>
        /// 根据字典获取WarehouseMessage对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseMessage对象</returns>
        WarehouseMessage GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WarehouseMessage对象
        /// <summary>
        /// 根据主键获取WarehouseMessage对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WarehouseMessage对象</returns>
        WarehouseMessage GetModel(int iD);
        #endregion


        #region 根据字典获取WarehouseMessage集合
        /// <summary>
        /// 根据字典获取WarehouseMessage集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WarehouseMessage> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WarehouseMessage数据集
        /// <summary>
        /// 根据字典获取WarehouseMessage数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WarehouseMessage集合
        /// <summary>
        /// 分页获取WarehouseMessage集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WarehouseMessage> GetPageList(PageListBySql<WarehouseMessage> page, IDictionary<string, object> conditionDict);
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