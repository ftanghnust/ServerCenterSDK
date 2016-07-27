
/*****************************
* Author:CR
*
* Date:2016-03-09
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库货区ShelfArea数据库访问接口
    /// </summary>
    public partial interface IShelfAreaDAO
    {


        #region 成员方法
        #region 根据主键验证ShelfArea是否存在
        /// <summary>
        /// 根据主键验证ShelfArea是否存在
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ShelfArea model);
        #endregion


        #region 添加一个ShelfArea
        /// <summary>
        /// 添加一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ShelfArea model);
        #endregion


        #region 更新一个ShelfArea
        /// <summary>
        /// 更新一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ShelfArea model);
        #endregion


        #region 删除一个ShelfArea
        /// <summary>
        /// 删除一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(ShelfArea model);
        #endregion


        #region 根据主键逻辑删除一个ShelfArea
        /// <summary>
        /// 根据主键逻辑删除一个ShelfArea
        /// </summary>
        /// <param name="shelfAreaID">ID(主键)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int shelfAreaID);
        #endregion


        #region 根据字典获取ShelfArea对象
        /// <summary>
        /// 根据字典获取ShelfArea对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShelfArea对象</returns>
        ShelfArea GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ShelfArea对象
        /// <summary>
        /// 根据主键获取ShelfArea对象
        /// </summary>
        /// <param name="shelfAreaID">ID(主键)</param>
        /// <returns>ShelfArea对象</returns>
        ShelfArea GetModel(int shelfAreaID);
        #endregion


        #region 根据字典获取ShelfArea集合
        /// <summary>
        /// 根据字典获取ShelfArea集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ShelfArea> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ShelfArea数据集
        /// <summary>
        /// 根据字典获取ShelfArea数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ShelfArea集合
        /// <summary>
        /// 分页获取ShelfArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ShelfArea> GetPageList(PageListBySql<ShelfArea> page, IDictionary<string, object> conditionDict);
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

        #region 根据货区编号(同一个仓库不能重复)验证货区是否存在
        /// <summary>
        /// 根据货区编号(同一个仓库不能重复)验证货区是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        bool ExistsShelfAreaCode(ShelfArea model);

        #endregion

        #region 根据货区编号(同一个仓库不能重复)验证货区是否使用
        /// <summary>
        /// 根据货区编号(同一个仓库不能重复)验证货区是否使用
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        IList<ShelfArea> ExistsShelfAreaCode(string ShelfAreaIDs);
        
        #endregion

        #endregion


    }
}