
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


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 门店群组明细表ShopGroupDetails业务逻辑类
    /// </summary>
    public partial class ShopGroupDetailsBLO
    {
        #region 成员方法
        #region 根据主键验证ShopGroupDetails是否存在
        /// <summary>
        /// 根据主键验证ShopGroupDetails是否存在
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(ShopGroupDetails model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().Exists(model);
        }
        #endregion


        #region 添加一个ShopGroupDetails
        /// <summary>
        /// 添加一个ShopGroupDetails
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(ShopGroupDetails model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().Save(model);
        }
        #endregion


        #region 更新一个ShopGroupDetails
        /// <summary>
        /// 更新一个ShopGroupDetails
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(ShopGroupDetails model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().Edit(model);
        }
        #endregion


        #region 删除一个ShopGroupDetails
        /// <summary>
        /// 删除一个ShopGroupDetails
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(ShopGroupDetails model)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个ShopGroupDetails
        /// <summary>
        /// 根据主键逻辑删除一个ShopGroupDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取ShopGroupDetails对象
        /// <summary>
        /// 根据字典获取ShopGroupDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShopGroupDetails对象</returns>
        public static ShopGroupDetails GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取ShopGroupDetails对象
        /// <summary>
        /// 根据主键获取ShopGroupDetails对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ShopGroupDetails对象</returns>
        public static ShopGroupDetails GetModel(int iD)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取ShopGroupDetails集合
        /// <summary>
        /// 根据字典获取ShopGroupDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<ShopGroupDetails> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取ShopGroupDetails数据集
        /// <summary>
        /// 根据字典获取ShopGroupDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取ShopGroupDetails集合
        /// <summary>
        /// 分页获取ShopGroupDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<ShopGroupDetails> GetPageList(PageListBySql<ShopGroupDetails> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }


    public partial class ShopGroupDetailsBLO
    {
        #region 删除某个分组对应的详情记录
        /// <summary>
        /// 删除某个分组对应的详情记录
        /// </summary>
        /// <param name="modelGroupID">GroupID</param>
        /// <returns>数据库影响行数</returns>
        public static int DeleteByGroupID(int GroupID)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().DeleteByGroupID(GroupID);
        }
        #endregion

        #region 删除某个分组对应的详情记录 事务操作
        /// <summary>
        /// 删除某个分组对应的详情记录 事务操作        
        /// </summary>
        /// <param name="modelGroupID">GroupID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>数据库影响行数</returns>        
        public static int DeleteByGroupID(int GroupID, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().DeleteByGroupID(GroupID, conn, tran);
        }
        #endregion

        #region 添加一个ShopGroupDetails 事务操作
        /// <summary>
        /// 添加一个ShopGroupDetails 事务操作
        /// </summary>
        /// <param name="model">ShopGroupDetails对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(ShopGroupDetails model, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IShopGroupDetailsDAO>().Save(model, conn, tran);
        }
        #endregion
    }
}