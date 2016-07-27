
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


namespace Frxs.Erp.ServiceCenter.Member.BLL
{
    /// <summary>
    /// 兴盛用户门店表XSUserShop业务逻辑类
    /// </summary>
    public partial class XSUserShopBLO
    {
        #region 成员方法
        #region 根据主键验证XSUserShop是否存在
        /// <summary>
        /// 根据主键验证XSUserShop是否存在
        /// </summary>
        /// <param name="model">XSUserShop对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(XSUserShop model)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().Exists(model);
        }
        #endregion


        #region 添加一个XSUserShop
        /// <summary>
        /// 添加一个XSUserShop
        /// </summary>
        /// <param name="model">XSUserShop对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(XSUserShop model)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().Save(model);
        }
        #endregion


        #region 更新一个XSUserShop
        /// <summary>
        /// 更新一个XSUserShop
        /// </summary>
        /// <param name="model">XSUserShop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(XSUserShop model)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().Edit(model);
        }
        #endregion


        #region 删除一个XSUserShop
        /// <summary>
        /// 删除一个XSUserShop
        /// </summary>
        /// <param name="model">XSUserShop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(XSUserShop model)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个XSUserShop
        /// <summary>
        /// 根据主键逻辑删除一个XSUserShop
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取XSUserShop对象
        /// <summary>
        /// 根据字典获取XSUserShop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>XSUserShop对象</returns>
        public static XSUserShop GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取XSUserShop对象
        /// <summary>
        /// 根据主键获取XSUserShop对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>XSUserShop对象</returns>
        public static XSUserShop GetModel(int iD)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取XSUserShop集合
        /// <summary>
        /// 根据字典获取XSUserShop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<XSUserShop> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取XSUserShop数据集
        /// <summary>
        /// 根据字典获取XSUserShop数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取XSUserShop集合
        /// <summary>
        /// 分页获取XSUserShop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<XSUserShop> GetPageList(PageListBySql<XSUserShop> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class XSUserShopBLO
    {
        #region 根据门店ID验证XSUserShop是否存在
        /// <summary>
        /// 根据ShopID验证XSUserShop是否存在
        /// </summary>
        /// <param name="ShopID">门店ID</param>
        /// <returns>是否存在</returns>
        public static bool ExistsShopID(int ShopID)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().ExistsShopID(ShopID);
        }
        #endregion

        #region 根据ShopID删除XSUserShop
        /// <summary>
        /// 根据ShopID删除XSUserShop
        /// </summary>
        /// <param name="ShopID">ShopID</param>
        /// <returns>数据库影响行数</returns>
        public static int DeleteByShopID(int ShopID)
        {
            return DALFactory.GetLazyInstance<IXSUserShopDAO>().DeleteByShopID(ShopID);
        }
        #endregion
    
    }
}