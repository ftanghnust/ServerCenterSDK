
/*****************************
* Author:CR
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility;
using Frxs.Platform.Cache;
using Frxs.Platform.Cache.Provide;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 仓库主表Warehouse业务逻辑类
    /// </summary>
    public partial class WarehouseBLO
    {
        #region 成员方法
        #region 根据主键验证Warehouse是否存在
        /// <summary>
        /// 根据主键验证Warehouse是否存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(Warehouse model)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().Exists(model);
        }
        #endregion


        #region 添加一个Warehouse
        /// <summary>
        /// 添加一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(Warehouse model)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().Save(model);
        }
        #endregion


        #region 更新一个Warehouse
        /// <summary>
        /// 更新一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(Warehouse model)
        {
            int wid = (model.WID.HasValue) ? model.WID.Value : 0;
            DelWarehouseCache(wid);//删除该仓库的缓存
            return DALFactory.GetLazyInstance<IWarehouseDAO>().Edit(model);
        }
        #endregion


        #region 删除一个Warehouse
        /// <summary>
        /// 删除一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(Warehouse model)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个Warehouse 删除该仓库的缓存
        /// <summary>
        /// 根据主键逻辑删除一个Warehouse 删除该仓库的缓存
        /// </summary>
        /// <param name="wID">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(Warehouse model)
        {
            int wid = (model.WID.HasValue) ? model.WID.Value : 0;
            DelWarehouseCache(wid);//删除该仓库的缓存
            return DALFactory.GetLazyInstance<IWarehouseDAO>().LogicDelete(model);
        }
        #endregion


        #region 根据字典获取Warehouse对象
        /// <summary>
        /// 根据字典获取Warehouse对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Warehouse对象</returns>
        public static Warehouse GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取Warehouse对象
        /// <summary>
        /// 根据主键获取Warehouse对象
        /// </summary>
        /// <param name="wID">仓库ID(从1000开始编号)</param>
        /// <returns>Warehouse对象</returns>
        public static Warehouse GetModel(int wID)
        {
            //return DALFactory.GetLazyInstance<IWarehouseDAO>().GetModel(wID);
            Warehouse model = new Warehouse();
            //缓存  考虑到仓库后台、总部后台等不同应用平台读取的仓库实体是经过了业务处理后包装过的实体，实体属性细节上各不相同，使用同一个key控制会带来风险，
            //征询胡总意见后，将仓库的基本信息缓存统一写在服务中心，只缓存和数据库字段对应的最基本的仓库信息，由调用的平台各自取到后自行做业务处理。
            string warehouseKey = string.Format(ConstDefinition.CACHE_WAREHOUSE_KEY, wID);
            Platform.Cache.RedisHelper redisHelper = Platform.Cache.Provide.ErpRedisCacheProvide.GetWarehouseCacheHelper();
            var cacheModel = redisHelper.GetCache<Warehouse>(warehouseKey);
            if (cacheModel != null)
            {
                model = cacheModel;
            }
            else
            {
                model = DALFactory.GetLazyInstance<IWarehouseDAO>().GetModel(wID);
                redisHelper.SetCache(warehouseKey, model, DateTime.Now.AddDays(30));
            }
            return model;
        }
        #endregion


        #region 根据字典获取Warehouse集合
        /// <summary>
        /// 根据字典获取Warehouse集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<Warehouse> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取Warehouse数据集
        /// <summary>
        /// 根据字典获取Warehouse数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取Warehouse集合
        /// <summary>
        /// 分页获取Warehouse集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Warehouse> GetPageList(PageListBySql<Warehouse> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWarehouseDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion

    }

    public partial class WarehouseBLO
    {
        /// <summary>
        /// 验证仓库编号WCode是否存在
        /// true表示存在 false表示不存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>true表示存在 false表示不存在</returns>
        public static bool ExistsWCode(Warehouse model)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().ExistsWCode(model);
        }

        /// <summary>
        /// 验证仓库名称WName是否存在
        /// true表示存在 false表示不存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>true表示存在 false表示不存在</returns>
        public static bool ExistsWName(Warehouse model)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().ExistsWName(model);
        }

        /// <summary>
        /// 冻结或解冻一个仓库 删除该仓库的缓存
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>影响的对象个数</returns>
        public static int WarehouseFreeze(Warehouse model)
        {
            int wid = (model.WID.HasValue) ? model.WID.Value : 0;
            DelWarehouseCache(wid);//删除该仓库的缓存
            return DALFactory.GetLazyInstance<IWarehouseDAO>().WarehouseFreeze(model);
        }

        /// <summary>
        /// 获取仓库子机构相关信息
        /// </summary>
        /// <param name="conditionDict"></param>        
        /// <returns>DataSet</returns>
        public static IList<SubWName> GetSubWName(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetSubWName(conditionDict);
        }

        /// <summary>
        /// 判断是否可以删除仓库 根据依赖关系的要求，基础资料项目不能反向调用订单库，判断方法只能在应用程序层调用订单项目来实现，所以本方法弃用
        /// true 表示可以删除 false表示不能删除
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <returns>true 表示可以删除 false表示不能删除</returns>
        public static bool CanRemove(int WID)
        {
            bool can = false;
            //根据依赖关系的要求，基础资料项目不能反向调用订单库，判断方法只能在应用程序层调用订单项目来实现，所以本方法弃用

            return can;
        }


        /// <summary>
        /// 获取仓库子机构数量
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <returns>仓库子机构数量</returns>
        public static int GetSubNum(int WID)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetSubNum(WID);
        }

        /// <summary>
        /// 获取仓库中的商品数量
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <returns>仓库中的商品数量</returns>
        public static int GetWProductsNum(int WID)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetWProductsNum(WID);
        }

        /// <summary>
        /// 获取仓库所管理的门店数量
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <returns>仓库管理的门店数量</returns>
        public static int GetShopNum(int WID)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetShopNum(WID);
        }

        /// <summary>
        /// 删除仓库缓存信息
        /// </summary>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        private static bool DelWarehouseCache(int wid)
        {
            RedisHelper redisHelper = ErpRedisCacheProvide.GetWarehouseCacheHelper();
            return redisHelper.DeleteCache(string.Format(ConstDefinition.CACHE_WAREHOUSE_KEY, wid));
        }

        /// <summary>
        /// 验证仓库也仓库子机构是否合法
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="subWid"></param>
        /// <returns></returns>
        public static IList<Warehouse> GetWarehouseSubWarehouse(int wid, int subWid)
        {
            return DALFactory.GetLazyInstance<IWarehouseDAO>().GetWarehouseSubWarehouse(wid, subWid);
        }
    }
}