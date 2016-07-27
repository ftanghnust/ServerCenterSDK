
/*****************************
* Author:CR
*
* Date:2016-03-15
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Cache;
using Frxs.Platform.Cache.Provide;
using Frxs.Platform.Utility;


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 仓库配送线路表WarehouseLine业务逻辑类
    /// </summary>
    public partial class WarehouseLineBLO
    {
        #region 成员方法
        #region 根据主键验证WarehouseLine是否存在
        /// <summary>
        /// 根据主键验证WarehouseLine是否存在
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WarehouseLine model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WarehouseLine
        /// <summary>
        /// 添加一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WarehouseLine model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().Save(model);
        }
        #endregion


        #region 更新一个WarehouseLine
        /// <summary>
        /// 更新一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WarehouseLine model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().Edit(model);
        }
        #endregion


        #region 删除一个WarehouseLine
        /// <summary>
        /// 删除一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WarehouseLine model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WarehouseLine
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseLine
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(WarehouseLine model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().LogicDelete(model);
        }
        #endregion


        #region 根据字典获取WarehouseLine对象
        /// <summary>
        /// 根据字典获取WarehouseLine对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseLine对象</returns>
        public static WarehouseLine GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WarehouseLine对象
        /// <summary>
        /// 根据主键获取WarehouseLine对象
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>WarehouseLine对象</returns>
        public static WarehouseLine GetModel(int lineID)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().GetModel(lineID);
        }
        #endregion


        #region 根据字典获取WarehouseLine集合
        /// <summary>
        /// 根据字典获取WarehouseLine集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WarehouseLine> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WarehouseLine数据集
        /// <summary>
        /// 根据字典获取WarehouseLine数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WarehouseLine集合
        /// <summary>
        /// 分页获取WarehouseLine集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WarehouseLine> GetPageList(PageListBySql<WarehouseLine> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion

        #region 根据送货线路ID验证是否存在
        /// <summary>
        /// 根据送货线路ID验证是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsWarehouseLineCode(WarehouseLine model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().ExistsWarehouseLineCode(model);
        }
        #endregion

        #region 根据主键获取WarehouseLine对象
        /// <summary>
        /// 根据主键获取WarehouseLine对象
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>WarehouseLine对象</returns>
        public static WarehouseLine GetShopModel(int ShopID)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineDAO>().GetShopModel(ShopID);
        }
        #endregion

        public static void DeleteCache(int LineID)
        {
            RedisHelper redisHelper = ErpRedisCacheProvide.GetStaffCacheHelper();

            redisHelper.DeleteCache(string.Format(ConstDefinition.CACHE_WAREHOUSELINE_KEY, LineID));
        }

        #endregion
    }
}