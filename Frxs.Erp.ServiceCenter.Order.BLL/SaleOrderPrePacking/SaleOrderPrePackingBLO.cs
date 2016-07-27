
/*****************************
* Author:CR
*
* Date:2016-04-13
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
    /// SaleOrderPrePacking业务逻辑类
    /// </summary>
    public partial class SaleOrderPrePackingBLO
    {
        #region 成员方法
        #region 根据主键验证SaleOrderPrePacking是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPrePacking是否存在
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleOrderPrePacking model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个SaleOrderPrePacking
        /// <summary>
        /// 添加一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleOrderPrePacking model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个SaleOrderPrePacking
        /// <summary>
        /// 更新一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleOrderPrePacking model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个SaleOrderPrePacking
        /// <summary>
        /// 删除一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleOrderPrePacking model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPrePacking
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPrePacking
        /// </summary>
        /// <param name="orderID">订单编号(SaleOrder.OrderID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string orderID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).LogicDelete(orderID);
        }
        #endregion


        #region 根据字典获取SaleOrderPrePacking对象
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleOrderPrePacking对象</returns>
        public static SaleOrderPrePacking GetModel(IDictionary<string, object> query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).GetModel(query);
        }
        #endregion


        #region 根据主键获取SaleOrderPrePacking对象
        /// <summary>
        /// 根据主键获取SaleOrderPrePacking对象
        /// </summary>
        /// <param name="orderID">订单编号(SaleOrder.OrderID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleOrderPrePacking对象</returns>
        public static SaleOrderPrePacking GetModel(string orderID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).GetModel(orderID);
        }
        #endregion


        #region 根据字典获取SaleOrderPrePacking集合
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<SaleOrderPrePacking> GetList(IDictionary<string, object> query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).GetList(query);
        }
        #endregion


        #region 根据字典获取SaleOrderPrePacking数据集
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleOrderPrePacking集合
        /// <summary>
        /// 分页获取SaleOrderPrePacking集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrderPrePacking> GetPageList(PageListBySql<SaleOrderPrePacking> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPrePackingDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }
}