
/*****************************
* Author:CR
*
* Date:2016-03-25
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 促销门店群组表ShopGroup业务逻辑类
    /// </summary>
    public partial class ShopGroupBLO
    {
        #region 成员方法
        #region 根据主键验证ShopGroup是否存在
        /// <summary>
        /// 根据主键验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(ShopGroup model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().Exists(model);
        }
        #endregion


        #region 添加一个ShopGroup
        /// <summary>
        /// 添加一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(ShopGroup model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().Save(model);
        }
        #endregion


        #region 更新一个ShopGroup
        /// <summary>
        /// 更新一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(ShopGroup model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().Edit(model);
        }
        #endregion


        #region 删除一个ShopGroup
        /// <summary>
        /// 删除一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(ShopGroup model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个ShopGroup
        /// <summary>
        /// 根据主键逻辑删除一个ShopGroup
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int groupID)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().LogicDelete(groupID);
        }
        #endregion


        #region 根据字典获取ShopGroup对象
        /// <summary>
        /// 根据字典获取ShopGroup对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShopGroup对象</returns>
        public static ShopGroup GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取ShopGroup对象
        /// <summary>
        /// 根据主键获取ShopGroup对象
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <returns>ShopGroup对象</returns>
        public static ShopGroup GetModel(int groupID)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().GetModel(groupID);
        }
        #endregion


        #region 根据字典获取ShopGroup集合
        /// <summary>
        /// 根据字典获取ShopGroup集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<ShopGroup> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取ShopGroup数据集
        /// <summary>
        /// 根据字典获取ShopGroup数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取ShopGroup集合
        /// <summary>
        /// 分页获取ShopGroup集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<ShopGroup> GetPageList(PageListBySql<ShopGroup> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IShopGroupDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }


    public partial class ShopGroupBLO
    {
        #region 根据 群组编号 验证ShopGroup是否存在
        /// <summary>
        /// 根据 群组编号 验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsGroupCode(ShopGroup model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().ExistsGroupCode(model);
        }
        #endregion

        #region 根据 群组名称 验证ShopGroup是否存在
        /// <summary>
        /// 根据 群组名称 验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsGroupName(ShopGroup model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().ExistsGroupName(model);
        }
        #endregion

        #region 根据主键序列逻辑删除一批ShopGroup 同时会更新关联的详情表 事务操作
        /// <summary>
        /// 根据主键序列逻辑删除一批ShopGroup 
        /// 同时会更新关联的详情表 事务操作
        /// </summary> 
        /// <param name="groupID">主键ID</param>
        /// <returns>数据库影响行数</returns>               
        public static int LogicDelete(List<int> groupID)
        {
            var connection = DALFactory.GetLazyInstance<IShopGroupDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            int rows = 0;
            try
            {
                if (groupID.Count > 0)
                {
                    foreach (var id in groupID)
                    {
                        rows += ShopGroupBLO.LogicDelete(id, connection, trans);
                        if (ShopGroupBLO.LogicDelete(id, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return 0;
                        }
                        ShopGroupDetailsBLO.DeleteByGroupID(id, connection, trans);

                    }

                    if (rows == groupID.Count)
                    {
                        trans.Commit();
                        return rows;
                    }
                    else
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return rows;
        }
        #endregion

        #region 根据主键逻辑删除一个ShopGroup
        /// <summary>
        /// 根据主键逻辑删除一个ShopGroup
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int groupID, IDbConnection conn, IDbTransaction tran)
        {
            DelShopGroupCache(groupID);//删除缓存
            return DALFactory.GetLazyInstance<IShopGroupDAO>().LogicDelete(groupID, conn, tran);
        }
        #endregion

        #region 添加一个ShopGroup 事务操作
        /// <summary>
        /// 添加一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(ShopGroup model, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().Save(model, conn, tran);
        }
        #endregion

        #region 更新一个ShopGroup 事务操作
        /// <summary>
        /// 更新一个ShopGroup 事务操作
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(ShopGroup model, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IShopGroupDAO>().Edit(model);
        }
        #endregion


        #region 添加一个ShopGroup 同时保存相关的详情表 事务操作
        /// <summary>
        /// 添加一个ShopGroup 同时保存相关的详情表 事务操作
        /// </summary>
        /// <param name="model">ShopGroup对象</param>        
        /// <returns>最新标识列</returns>
        public static int SaveInfo(ShopGroup model)
        {

            var connection = DALFactory.GetLazyInstance<IShopGroupDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            int rowDetails = 0;//子表计数
            try
            {
                int GroupID = ShopGroupBLO.Save(model, connection, trans);
                //删除详情 子表
                ShopGroupDetailsBLO.DeleteByGroupID(GroupID, connection, trans);
                //保存详情 子表

                //有详情则要确保详情信息提交正确
                foreach (var shopGroupDetails in model.List)
                {
                    rowDetails = rowDetails + 1;
                    shopGroupDetails.GroupID = GroupID;
                    ShopGroupDetailsBLO.Save(shopGroupDetails, connection, trans);
                }
                trans.Commit();
                return 1;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion


        #region 更新一个ShopGroup 同时保存相关的详情表 事务操作
        /// <summary>
        /// 更新一个ShopGroup 同时保存相关的详情表 事务操作
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>最新标识列</returns>
        public static int EditInfo(ShopGroup model)
        {
            DelShopGroupCache(model.GroupID);//更新时删除缓存
            var connection = DALFactory.GetLazyInstance<IShopGroupDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            int rowDetails = 0;//子表计数
            try
            {
                //保存主表                
                ShopGroupBLO.Edit(model, connection, trans);

                //删除详情 子表
                ShopGroupDetailsBLO.DeleteByGroupID(model.GroupID, connection, trans);

                //保存详情 子表
                foreach (var shopGroupDetails in model.List)
                {
                    ShopGroupDetailsBLO.Save(shopGroupDetails, connection, trans);
                }
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return 1;
        }
        #endregion

        #region 根据门店分组ID删除门店分组、群组明细对象缓存
        /// <summary>
        /// 根据门店分组ID删除门店分组对象缓存
        /// </summary>
        /// <param name="groupID">门店分组ID</param>
        /// <returns></returns>
        public static bool DelShopGroupCache(int groupID)
        {
            Platform.Cache.RedisHelper redisHelper = Platform.Cache.Provide.ErpRedisCacheProvide.GetWarehouseCacheHelper();
            return redisHelper.DeleteCache(string.Format(ConstDefinition.CACHE_SHOPGROUP_KEY, groupID));
        }
        #endregion
    }
}