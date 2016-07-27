
/*****************************
* Author:CR
*
* Date:2016-03-07
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库货架表Shelf数据库访问接口
    /// </summary>
    public partial interface IShelfDAO
    {


        #region 成员方法
        #region 根据主键验证Shelf是否存在
        /// <summary>
        /// 根据主键验证Shelf是否存在
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>是否存在</returns>
        bool Exists(Shelf model);
        #endregion


        #region 添加一个Shelf
        /// <summary>
        /// 添加一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(Shelf model);
        #endregion


        #region 更新一个Shelf
        /// <summary>
        /// 更新一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(Shelf model);
        #endregion


        #region 删除一个Shelf
        /// <summary>
        /// 删除一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(Shelf model);
        #endregion


        #region 根据主键逻辑删除一个Shelf
        /// <summary>
        /// 根据主键逻辑删除一个Shelf
        /// </summary>
        /// <param name="shelfID">ID(主键)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int shelfID);
        #endregion


        #region 根据字典获取Shelf对象
        /// <summary>
        /// 根据字典获取Shelf对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Shelf对象</returns>
        Shelf GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取Shelf对象
        /// <summary>
        /// 根据主键获取Shelf对象
        /// </summary>
        /// <param name="shelfID">ID(主键)</param>
        /// <returns>Shelf对象</returns>
        Shelf GetModel(int shelfID);
        #endregion


        #region 根据字典获取Shelf集合
        /// <summary>
        /// 根据字典获取Shelf集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<Shelf> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取Shelf数据集
        /// <summary>
        /// 根据字典获取Shelf数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取Shelf集合
        /// <summary>
        /// 分页获取Shelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<Shelf> GetPageList(PageListBySql<Shelf> page, IDictionary<string, object> conditionDict);
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

        #region 根据货位编号(同一个仓库不能重复)验证货位是否存在
        /// <summary>
        /// 根据货位编号(同一个仓库不能重复)验证货位是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        bool ExistsShelfCode(Shelf model);
        
        #endregion

        #endregion


    }

    public partial interface IShelfDAO
    {
        #region 获取连接

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns>连接对象</returns>
        IDbConnection GetConnection();
        #endregion

        #region 根据货位编号(同一个仓库不能重复)验证货位是否使用
        /// <summary>
        /// 根据货位编号(同一个仓库不能重复)验证货位是否使用
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        IList<Shelf> ExistsShelIDs(string ShelIDs);
       
        #endregion
    }
}