
/*****************************
* Author:CR
*
* Date:2016-04-15
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// StockAdjDetailsExt业务逻辑类
    /// </summary>
    public partial class StockAdjDetailsExtBLO
    {
        #region 成员方法
        #region 根据主键验证StockAdjDetailsExt是否存在
        /// <summary>
        /// 根据主键验证StockAdjDetailsExt是否存在
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(StockAdjDetailsExt model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个StockAdjDetailsExt
        /// <summary>
        /// 添加一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(StockAdjDetailsExt model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个StockAdjDetailsExt
        /// <summary>
        /// 更新一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(StockAdjDetailsExt model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个StockAdjDetailsExt
        /// <summary>
        /// 删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(StockAdjDetailsExt model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个StockAdjDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="iD">编号(StockAdjDetails.ID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取StockAdjDetailsExt对象
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>StockAdjDetailsExt对象</returns>
        public static StockAdjDetailsExt GetModel(StockAdjDetailsExtQuery query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).GetModel(query);
        }
        #endregion


        #region 根据主键获取StockAdjDetailsExt对象
        /// <summary>
        /// 根据主键获取StockAdjDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(StockAdjDetails.ID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>StockAdjDetailsExt对象</returns>
        public static StockAdjDetailsExt GetModel(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取StockAdjDetailsExt集合
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<StockAdjDetailsExt> GetList(StockAdjDetailsExtQuery query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).GetList(query);
        }
        #endregion


        #region 根据字典获取StockAdjDetailsExt数据集
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取StockAdjDetailsExt集合
        /// <summary>
        /// 分页获取StockAdjDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<StockAdjDetailsExt> GetPageList(PageListBySql<StockAdjDetailsExt> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }

    public partial class StockAdjDetailsExtBLO
    {
        #region 删除一个StockAdjDetailsExt
        /// <summary>
        /// 删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string id, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Delete(id);
        }
        #endregion
    }
}