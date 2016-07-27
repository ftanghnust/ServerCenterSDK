
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
    /// ### 仓库配送线路门店关系表WarehouseLineShop数据库访问接口
    /// </summary>
    public partial interface IWarehouseLineShopDAO
    {


        #region 成员方法
        #region 根据主键验证WarehouseLineShop是否存在
        /// <summary>
        /// 根据主键验证WarehouseLineShop是否存在
        /// </summary>
        /// <param name="model">WarehouseLineShop对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WarehouseLineShop model);
        #endregion


        #region 添加一个WarehouseLineShop
        /// <summary>
        /// 添加一个WarehouseLineShop
        /// </summary>
        /// <param name="model">WarehouseLineShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WarehouseLineShop model);
        #endregion


        #region 更新一个WarehouseLineShop
        /// <summary>
        /// 更新一个WarehouseLineShop
        /// </summary>
        /// <param name="model">WarehouseLineShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WarehouseLineShop model);
        #endregion


        #region 删除一个WarehouseLineShop
        /// <summary>
        /// 删除一个WarehouseLineShop
        /// </summary>
        /// <param name="model">WarehouseLineShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WarehouseLineShop model);
        #endregion


        #region 根据主键逻辑删除一个WarehouseLineShop
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseLineShop
        /// </summary>
        /// <param name="iD">主键(ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取WarehouseLineShop对象
        /// <summary>
        /// 根据字典获取WarehouseLineShop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseLineShop对象</returns>
        WarehouseLineShop GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WarehouseLineShop对象
        /// <summary>
        /// 根据主键获取WarehouseLineShop对象
        /// </summary>
        /// <param name="iD">主键(ID)</param>
        /// <returns>WarehouseLineShop对象</returns>
        WarehouseLineShop GetModel(int iD);
        #endregion


        #region 根据字典获取WarehouseLineShop集合
        /// <summary>
        /// 根据字典获取WarehouseLineShop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WarehouseLineShop> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WarehouseLineShop数据集
        /// <summary>
        /// 根据字典获取WarehouseLineShop数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WarehouseLineShop集合
        /// <summary>
        /// 分页获取WarehouseLineShop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WarehouseLineShop> GetPageList(PageListBySql<WarehouseLineShop> page, IDictionary<string, object> conditionDict);
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

    public partial interface IWarehouseLineShopDAO
    {
        #region 根据门店ID删除一个WarehouseLineShop
        /// <summary>
        /// 根据 门店ID 删除一个WarehouseLineShop
        /// </summary>
        /// <param name="ShopID">门店ID</param>
        /// <returns>数据库影响行数</returns>
        int DeleteByShopID(int ShopID);
        #endregion


    }

}