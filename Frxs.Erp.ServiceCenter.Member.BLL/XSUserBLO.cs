
/*****************************
* Author:CR
*
* Date:2016-03-22
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Member.IDAL;
using Frxs.Erp.ServiceCenter.Member.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility;

namespace Frxs.Erp.ServiceCenter.Member.BLL
{
    /// <summary>
    /// 兴盛用户表(B2B,O2O,线下会员)XSUser业务逻辑类
    /// </summary>
    public partial class XSUserBLO
    {
        #region 成员方法
        #region 根据主键验证XSUser是否存在
        /// <summary>
        /// 根据主键验证XSUser是否存在
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(XSUser model)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().Exists(model);
        }
        #endregion


        #region 添加一个XSUser
        /// <summary>
        /// 添加一个XSUser
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(XSUser model)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().Save(model);
        }
        #endregion


        #region 更新一个XSUser 删对应帐号的缓存
        /// <summary>
        /// 更新一个XSUser 删对应帐号的缓存
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(XSUser model)
        {
            //删对应帐号的缓存
            DelAccountCache(model.UserAccount);
            return DALFactory.GetLazyInstance<IXSUserDAO>().Edit(model);
        }
        #endregion


        #region 删除一个XSUser
        /// <summary>
        /// 删除一个XSUser
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(XSUser model)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个XSUser
        /// <summary>
        /// 根据主键逻辑删除一个XSUser
        /// </summary>
        /// <param name="xSUserID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int xSUserID)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().LogicDelete(xSUserID);
        }
        #endregion


        #region 根据字典获取XSUser对象
        /// <summary>
        /// 根据字典获取XSUser对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>XSUser对象</returns>
        public static XSUser GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取XSUser对象
        /// <summary>
        /// 根据主键获取XSUser对象
        /// </summary>
        /// <param name="xSUserID">用户编号</param>
        /// <returns>XSUser对象</returns>
        public static XSUser GetModel(int xSUserID)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().GetModel(xSUserID);
        }
        #endregion


        #region 根据字典获取XSUser集合
        /// <summary>
        /// 根据字典获取XSUser集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<XSUser> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取XSUser数据集
        /// <summary>
        /// 根据字典获取XSUser数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取XSUser集合
        /// <summary>
        /// 分页获取XSUser集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<XSUser> GetPageList(PageListBySql<XSUser> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IXSUserDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class XSUserBLO
    {
        #region 根据帐号获取XSUser对象
        /// <summary>
        /// 根据帐号获取XSUser对象
        /// </summary>
        /// <param name="xSUserID">用户帐号</param>
        /// <returns>XSUser对象</returns>
        public static XSUser GetModelByAccount(string UserAccount)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().GetModelByAccount(UserAccount);
        }
        #endregion

        #region 根据帐号验证XSUser是否存在
        /// <summary>
        /// 根据帐号验证XSUser是否存在
        /// </summary>
        /// <param name="model">用户帐号</param>
        /// <returns>是否存在</returns>
        public static bool ExistsAccount(string UserAccount)
        {
            return DALFactory.GetLazyInstance<IXSUserDAO>().ExistsAccount(UserAccount);
        }
        #endregion

        /// <summary>
        /// 根据帐号删除对应的门店用户缓存信息
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
    }
}