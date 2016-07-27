
/*****************************
* Author:CR
*
* Date:2016-03-17
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库用户拣货区表WarehouseEmpShelf数据库访问接口
    /// </summary>
    public partial interface IWarehouseEmpShelfDAO
    {


        #region 成员方法
        #region 根据主键验证WarehouseEmpShelf是否存在
        /// <summary>
        /// 根据主键验证WarehouseEmpShelf是否存在
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WarehouseEmpShelf model);
        #endregion


        #region 添加一个WarehouseEmpShelf
        /// <summary>
        /// 添加一个WarehouseEmpShelf
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WarehouseEmpShelf model);
        #endregion


        #region 更新一个WarehouseEmpShelf
        /// <summary>
        /// 更新一个WarehouseEmpShelf
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WarehouseEmpShelf model);
        #endregion


        #region 删除一个WarehouseEmpShelf
        /// <summary>
        /// 删除一个WarehouseEmpShelf
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WarehouseEmpShelf model);
        #endregion


        #region 根据主键逻辑删除一个WarehouseEmpShelf
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseEmpShelf
        /// </summary>
        /// <param name="iD">主键</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取WarehouseEmpShelf对象
        /// <summary>
        /// 根据字典获取WarehouseEmpShelf对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseEmpShelf对象</returns>
        WarehouseEmpShelf GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WarehouseEmpShelf对象
        /// <summary>
        /// 根据主键获取WarehouseEmpShelf对象
        /// </summary>
        /// <param name="iD">主键</param>
        /// <returns>WarehouseEmpShelf对象</returns>
        WarehouseEmpShelf GetModel(int iD);
        #endregion


        #region 根据字典获取WarehouseEmpShelf集合
        /// <summary>
        /// 根据字典获取WarehouseEmpShelf集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WarehouseEmpShelf> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WarehouseEmpShelf数据集
        /// <summary>
        /// 根据字典获取WarehouseEmpShelf数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WarehouseEmpShelf集合
        /// <summary>
        /// 分页获取WarehouseEmpShelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WarehouseEmp> GetPageList(PageListBySql<WarehouseEmp> page, IDictionary<string, object> conditionDict);
        #endregion

        #region 分页获取WarehouseEmpShelf集合
        /// <summary>
        /// 分页获取WarehouseEmpShelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WarehouseEmpShelf> GetPageShelfList(PageListBySql<WarehouseEmpShelf> page, IDictionary<string, object> conditionDict);
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

    public partial interface IWarehouseEmpShelfDAO
    {
        #region 添加一个WarehouseEmpShelf
        /// <summary>
        /// 添加一个WarehouseEmpShelf
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, WarehouseEmpShelf model);
        #endregion

        #region 删除一个WarehouseEmpShelf
        /// <summary>
        /// 删除一个WarehouseEmpShelf
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(IDbConnection conn, IDbTransaction tran, WarehouseEmpShelf model);
        #endregion
    }
}