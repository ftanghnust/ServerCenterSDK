
/*****************************
* Author:CR
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库主表Warehouse数据库访问接口
    /// </summary>
    public partial interface IWarehouseDAO
    {


        #region 成员方法
        #region 根据主键验证Warehouse是否存在
        /// <summary>
        /// 根据主键验证Warehouse是否存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>是否存在</returns>
        bool Exists(Warehouse model);
        #endregion


        #region 添加一个Warehouse
        /// <summary>
        /// 添加一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(Warehouse model);
        #endregion


        #region 更新一个Warehouse
        /// <summary>
        /// 更新一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(Warehouse model);
        #endregion


        #region 删除一个Warehouse
        /// <summary>
        /// 删除一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(Warehouse model);
        #endregion


        #region 根据主键逻辑删除一个Warehouse
        /// <summary>
        /// 根据主键逻辑删除一个Warehouse
        /// </summary>
        /// <param name="wID">仓库ID(从1000开始编号)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(Model.Warehouse model);
        #endregion


        #region 根据字典获取Warehouse对象
        /// <summary>
        /// 根据字典获取Warehouse对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Warehouse对象</returns>
        Warehouse GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取Warehouse对象
        /// <summary>
        /// 根据主键获取Warehouse对象
        /// </summary>
        /// <param name="wID">仓库ID(从1000开始编号)</param>
        /// <returns>Warehouse对象</returns>
        Warehouse GetModel(int wID);
        #endregion


        #region 根据字典获取Warehouse集合
        /// <summary>
        /// 根据字典获取Warehouse集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<Warehouse> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取Warehouse数据集
        /// <summary>
        /// 根据字典获取Warehouse数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取Warehouse集合
        /// <summary>
        /// 分页获取Warehouse集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<Warehouse> GetPageList(PageListBySql<Warehouse> page, IDictionary<string, object> conditionDict);
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

    public partial interface IWarehouseDAO
    {
        #region 验证WCode是否存在
        /// <summary>
        /// 验证WCode是否存在
        /// true表示存在 false表示不存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>true表示存在 false表示不存在</returns>
        bool ExistsWCode(Warehouse model);
        #endregion

        #region 验证WName是否存在
        /// <summary>
        /// 验证仓库名称WName是否存在
        /// true表示存在 false表示不存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>true表示存在 false表示不存在</returns>
        bool ExistsWName(Warehouse model);
        #endregion

        #region 冻结或解冻仓库
        /// <summary>
        /// 冻结或解冻仓库
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>影响的对象个数</returns>
        int WarehouseFreeze(Warehouse model);
        #endregion

        #region 获取子机构信息
        /// <summary>
        /// 获取子机构信息 供其他板块调用
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns>List</returns>
        IList<SubWName> GetSubWName(IDictionary<string, object> conditionDict);
        #endregion

        #region 获取子机构数量
        /// <summary>
        /// 获取子机构数量
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <returns>子机构数量</returns>
        int GetSubNum(int WID);
        #endregion

        #region 获取仓库中的商品数量
        /// <summary>
        /// 获取仓库中的商品数量
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <returns>仓库中的商品数量</returns>
        int GetWProductsNum(int WID);
        #endregion

        #region 获取仓库所管理的门店数量
        /// <summary>
        /// 获取仓库所管理的门店数量
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <returns>仓库管理的门店数量</returns>
        int GetShopNum(int WID);
        #endregion

         /// <summary>
        /// 验证仓库也仓库子机构是否合法
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="subWid"></param>
        /// <returns></returns>
        /// <summary>
        /// 验证仓库也仓库子机构是否合法
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="subWid"></param>
        /// <returns></returns>
        IList<Warehouse> GetWarehouseSubWarehouse(int wid, int subWid);
    }

}