
/*****************************
* Author:CR
*
* Date:2016-03-15
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库配送线路表WarehouseLine数据库访问接口
    /// </summary>
    public partial interface IWarehouseLineDAO
    {


        #region 成员方法
        #region 根据主键验证WarehouseLine是否存在
        /// <summary>
        /// 根据主键验证WarehouseLine是否存在
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WarehouseLine model);
        #endregion


        #region 添加一个WarehouseLine
        /// <summary>
        /// 添加一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WarehouseLine model);
        #endregion


        #region 更新一个WarehouseLine
        /// <summary>
        /// 更新一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WarehouseLine model);
        #endregion


        #region 删除一个WarehouseLine
        /// <summary>
        /// 删除一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WarehouseLine model);
        #endregion


        #region 根据主键逻辑删除一个WarehouseLine
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseLine
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(WarehouseLine model);
        #endregion


        #region 根据字典获取WarehouseLine对象
        /// <summary>
        /// 根据字典获取WarehouseLine对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseLine对象</returns>
        WarehouseLine GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WarehouseLine对象
        /// <summary>
        /// 根据主键获取WarehouseLine对象
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>WarehouseLine对象</returns>
        WarehouseLine GetModel(int lineID);
        #endregion


        #region 根据字典获取WarehouseLine集合
        /// <summary>
        /// 根据字典获取WarehouseLine集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WarehouseLine> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WarehouseLine数据集
        /// <summary>
        /// 根据字典获取WarehouseLine数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WarehouseLine集合
        /// <summary>
        /// 分页获取WarehouseLine集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WarehouseLine> GetPageList(PageListBySql<WarehouseLine> page, IDictionary<string, object> conditionDict);
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

        #region 根据送货线路ID验证是否存在
        /// <summary>
        /// 根据送货线路ID验证是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        bool ExistsWarehouseLineCode(WarehouseLine model);
       
        #endregion

        #region 根据主键获取WarehouseLine对象
        /// <summary>
        /// 根据主键获取WarehouseLine对象
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>WarehouseLine对象</returns>
        WarehouseLine GetShopModel(int ShopID);        
        #endregion

        #endregion


    }
}