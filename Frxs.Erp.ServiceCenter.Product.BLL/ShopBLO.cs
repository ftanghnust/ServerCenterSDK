
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
using System.Text;
using Frxs.Platform.Utility;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 门店资料表Shop业务逻辑类
    /// </summary>
    public partial class ShopBLO
    {
        #region 成员方法
        #region 根据主键验证Shop是否存在
        /// <summary>
        /// 根据主键验证Shop是否存在
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(Shop model)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().Exists(model);
        }
        #endregion


        #region 添加一个Shop
        /// <summary>
        /// 添加一个Shop
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(Shop model)
        {
            //删对应门店帐号的缓存 一个帐号可以被多个门店关联
            DelAccountCache(model.ShopAccount);
            return DALFactory.GetLazyInstance<IShopDAO>().Save(model);
        }
        #endregion


        #region 更新一个Shop 删除帐号和门店对象缓存
        /// <summary>
        /// 更新一个Shop 删对应门店帐号的缓存 删除门店对象缓存
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(Shop model)
        {
            //删对应门店帐号的缓存
            DelAccountCache(model.ShopAccount);

            #region 删除门店对象缓存
            DelShopCache(model.ShopID);
            #endregion

            return DALFactory.GetLazyInstance<IShopDAO>().Edit(model);
        }
        #endregion


        #region 删除一个Shop
        /// <summary>
        /// 删除一个Shop
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(Shop model)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().Delete(model);
        }
        #endregion



        #region 根据字典获取Shop对象
        /// <summary>
        /// 根据字典获取Shop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Shop对象</returns>
        public static Shop GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取Shop对象
        /// <summary>
        /// 根据主键获取Shop对象
        /// </summary>
        /// <param name="shopID">门店ID</param>
        /// <returns>Shop对象</returns>
        public static Shop GetModel(int shopID)
        {
            //return DALFactory.GetLazyInstance<IShopDAO>().GetModel(shopID);
            Shop model = new Shop();
            //缓存  考虑到仓库后台、总部后台等不同应用平台读取的Shop实体是经过了业务处理后包装过的实体，实体属性细节上各不相同，使用同一个key控制会带来风险，
            //征询胡总意见后，将Shop的基本信息缓存统一写在服务中心，只缓存和数据库字段对应的最基本的Shop信息，由调用的平台各自取到后自行做业务处理。
            string shopKey = string.Format(ConstDefinition.CACHE_SHOP_KEY, shopID);
            Platform.Cache.RedisHelper redisHelper = Platform.Cache.Provide.ErpRedisCacheProvide.GetWarehouseCacheHelper();
            var cacheModel = redisHelper.GetCache<Shop>(shopKey);
            if (cacheModel != null)
            {
                model = cacheModel;
            }
            else
            {
                model = DALFactory.GetLazyInstance<IShopDAO>().GetModel(shopID);
                redisHelper.SetCache(shopKey, model, DateTime.Now.AddDays(1));
            }
            return model;
        }
        #endregion


        #region 根据字典获取Shop集合
        /// <summary>
        /// 根据字典获取Shop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<Shop> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取Shop数据集
        /// <summary>
        /// 根据字典获取Shop数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取Shop集合
        /// <summary>
        /// 分页获取Shop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Shop> GetPageList(PageListBySql<Shop> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IShopDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class ShopBLO
    {
        #region 根据对象验证Shop是否存在
        /// <summary>
        /// 根据门店编号验证Shop是否存在
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsShopCode(Shop model)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().ExistsShopCode(model);
        }
        #endregion

        #region 根据对象验证Shop是否存在
        /// <summary>
        /// 根据门店名称验证Shop是否存在
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsShopName(Shop model)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().ExistsShopName(model);
        }
        #endregion

        #region 根据对象逻辑逻辑删除一个Shop 删除门店对象缓存、删除门店帐号缓存
        /// <summary>
        /// 根据对象逻辑逻辑删除一个Shop 删除门店对象缓存、删除门店帐号缓存
        /// </summary>
        /// <param name="shopID">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(Shop model)
        {
            #region 根据门店帐号删除对应的门店用户缓存信息（前端传入的值只包含门店ID，需手动查询门店帐号）
            Shop modelNew = ShopBLO.GetModel(model.ShopID);//为了取出门店帐号
            string shopAccount = (modelNew != null && !string.IsNullOrEmpty(modelNew.ShopAccount)) ? modelNew.ShopAccount : string.Empty;
            DelAccountCache(shopAccount);
            #endregion

            #region 删除门店对象缓存
            DelShopCache(model.ShopID);
            #endregion

            return DALFactory.GetLazyInstance<IShopDAO>().LogicDelete(model);
        }
        #endregion

        #region 根据对象逻辑冻结或解冻一个Shop 删除门店对象缓存、删除门店帐号缓存
        /// <summary>
        /// 根据对象逻辑冻结或解冻一个Shop 删除门店对象缓存、删除门店帐号缓存
        /// </summary>
        /// <param name="shopID">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int ShopFreeze(Shop model)
        {
            #region 根据门店帐号删除对应的门店用户缓存信息（前端传入的值只包含门店ID，需手动查询门店帐号）
            Shop modelNow = ShopBLO.GetModel(model.ShopID);//为了取出门店帐号
            string shopAccount = (modelNow != null && !string.IsNullOrEmpty(modelNow.ShopAccount)) ? modelNow.ShopAccount : string.Empty;
            DelAccountCache(shopAccount);
            #endregion

            #region 删除门店对象缓存
            DelShopCache(model.ShopID);
            #endregion

            return DALFactory.GetLazyInstance<IShopDAO>().ShopFreeze(model);
        }
        #endregion



        #region 仓库后台分页获取Shop集合
        /// <summary>
        /// 仓库后台分页获取Shop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Shop> GetWhPageList(PageListBySql<Shop> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().GetWhPageList(page, conditionDict);
        }
        #endregion

        #region 获取门店排单集合
        /// <summary>
        /// 获取门店排单集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static IList<ShopExt> GetShopAndOrderList(IDictionary<string, object> conditionDict)
        {

            IList<ShopExt> shoplist = DALFactory.GetLazyInstance<IShopDAO>().GetShopAndOrderList(conditionDict);

            return shoplist;

        }

        #endregion

        #region 仓库后台 根据主键获取Shop对象 为统一缓存方面的实体，统一改用GetModel方法
        /// <summary>
        /// 仓库后台 根据主键获取Shop对象 为统一缓存方面的实体，统一改用GetModel方法
        /// </summary>
        /// <param name="shopID">门店ID</param>
        /// <returns>Shop对象</returns>
        [Obsolete("此方法已经过时，请使用ShopBLO.GetModel()。为统一缓存的Shop实体，统一用GetModel方法")]
        public static Shop GetModelInWh(int shopID)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().GetModelInWh(shopID);
        }
        #endregion

        #region 添加一个Shop 事务处理
        /// <summary>
        /// 添加一个Shop 事务处理
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(Shop model, IDbConnection conn, IDbTransaction tran)
        {
            //删对应门店帐号的缓存 一个帐号可以被多个门店关联
            DelAccountCache(model.ShopAccount);
            return DALFactory.GetLazyInstance<IShopDAO>().Save(model, conn, tran);
        }
        #endregion

        #region 根据门店帐号删除对应的门店用户缓存信息
        /// <summary>
        /// 根据门店帐号删除对应的门店用户缓存信息
        /// </summary>
        /// <param name="shopAccount">门店帐号</param>
        /// <returns></returns>
        private static bool DelAccountCache(string shopAccount)
        {
            bool del = false;
            if (string.IsNullOrEmpty(shopAccount))
            {
                return del;
            }
            Platform.Cache.RedisHelper redisHelper = Platform.Cache.Provide.ErpRedisCacheProvide.GetUserCacheHelper();
            //取出 XSUser_GUID  （DH_XSUSER_GUID_{KEY} ）
            var xSUser_GUID = redisHelper.GetCache<string>(string.Format(ConstDefinition.CACHE_DH_XUSER_KEY, shopAccount));
            //guid有值则删 DH_XSUSER_GUID_{KEY}
            if (xSUser_GUID != null)
            {
                del = redisHelper.DeleteCache(string.Format(ConstDefinition.CACHE_DH_XSUser_GUID_KEY, xSUser_GUID));
            }
            //删除 DH_XSUSER_{KEY}
            if (!string.IsNullOrEmpty(shopAccount))
            {
                del = redisHelper.DeleteCache(string.Format(ConstDefinition.CACHE_DH_XUSER_KEY, shopAccount));
            }
            return del;
        }
        #endregion

        #region 根据门店ID删除门店对象缓存
        /// <summary>
        /// 根据门店ID删除门店对象缓存
        /// </summary>
        /// <param name="shopID">门店ID</param>
        /// <returns></returns>
        public static bool DelShopCache(int shopID)
        {
            Platform.Cache.RedisHelper redisHelper = Platform.Cache.Provide.ErpRedisCacheProvide.GetWarehouseCacheHelper();
            return redisHelper.DeleteCache(string.Format(ConstDefinition.CACHE_SHOP_KEY, shopID));
        }
        #endregion
    }

    /// <summary>
    /// 龙武
    /// </summary>
    public partial class ShopBLO
    {
        /// <summary>
        /// 根据门店编号获取门店所属线路信息
        /// </summary>
        /// <param name="shopId">门店编号</param>
        /// <returns></returns>
        public static WarehouseLine GetShopLine(int shopId)
        {
            return DALFactory.GetLazyInstance<IShopDAO>().GetShopLine(shopId);
        }
    }
}