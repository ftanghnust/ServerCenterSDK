
/*****************************
* Author:chujl
*
* Date:2016-04-02
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Promotion.BLL
{
    /// <summary>
    /// 仓库消息所属群组表WarehouseMessageShops业务逻辑类
    /// </summary>
    public partial class WarehouseMessageShopsBLO
    {
        #region 成员方法
        #region 根据主键验证WarehouseMessageShops是否存在
        /// <summary>
        /// 根据主键验证WarehouseMessageShops是否存在
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WarehouseMessageShops model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个WarehouseMessageShops
        /// <summary>
        /// 添加一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WarehouseMessageShops model, IDbConnection conn, IDbTransaction trans, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).Save(model, conn, trans);
        }
        /// <summary>
        /// 添加一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WarehouseMessageShops model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个WarehouseMessageShops
        /// <summary>
        /// 更新一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WarehouseMessageShops model, IDbConnection conn, IDbTransaction trans, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).Edit(model, conn, trans);
        }
        /// <summary>
        /// 更新一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WarehouseMessageShops model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个WarehouseMessageShops
        /// <summary>
        /// 删除一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WarehouseMessageShops model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WarehouseMessageShops
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessageShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int messageId, IDbConnection conn, IDbTransaction trans, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).LogicDelete(messageId, conn, trans);
        }
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessageShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取WarehouseMessageShops对象
        /// <summary>
        /// 根据字典获取WarehouseMessageShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseMessageShops对象</returns>
        public static WarehouseMessageShops GetModel(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WarehouseMessageShops对象
        /// <summary>
        /// 根据主键获取WarehouseMessageShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WarehouseMessageShops对象</returns>
        public static WarehouseMessageShops GetModel(int iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取WarehouseMessageShops集合
        /// <summary>
        /// 根据字典获取WarehouseMessageShops集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WarehouseMessageShops> GetList(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WarehouseMessageShops数据集
        /// <summary>
        /// 根据字典获取WarehouseMessageShops数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WarehouseMessageShops集合
        /// <summary>
        /// 分页获取WarehouseMessageShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WarehouseMessageShops> GetPageList(PageListBySql<WarehouseMessageShops> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }
}