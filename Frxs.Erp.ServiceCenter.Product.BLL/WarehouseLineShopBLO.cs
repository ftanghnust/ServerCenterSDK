
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


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 仓库配送线路门店关系表WarehouseLineShop业务逻辑类
    /// </summary>
    public partial class WarehouseLineShopBLO
    {
        #region 成员方法
        #region 根据主键验证WarehouseLineShop是否存在
        /// <summary>
        /// 根据主键验证WarehouseLineShop是否存在
        /// </summary>
        /// <param name="model">WarehouseLineShop对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WarehouseLineShop model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WarehouseLineShop
        /// <summary>
        /// 添加一个WarehouseLineShop
        /// </summary>
        /// <param name="model">WarehouseLineShop对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WarehouseLineShop model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().Save(model);
        }
        #endregion


        #region 更新一个WarehouseLineShop
        /// <summary>
        /// 更新一个WarehouseLineShop
        /// </summary>
        /// <param name="model">WarehouseLineShop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WarehouseLineShop model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().Edit(model);
        }
        #endregion


        #region 删除一个WarehouseLineShop
        /// <summary>
        /// 删除一个WarehouseLineShop
        /// </summary>
        /// <param name="model">WarehouseLineShop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WarehouseLineShop model)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WarehouseLineShop
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseLineShop
        /// </summary>
        /// <param name="iD">主键(ID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取WarehouseLineShop对象
        /// <summary>
        /// 根据字典获取WarehouseLineShop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseLineShop对象</returns>
        public static WarehouseLineShop GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WarehouseLineShop对象
        /// <summary>
        /// 根据主键获取WarehouseLineShop对象
        /// </summary>
        /// <param name="iD">主键(ID)</param>
        /// <returns>WarehouseLineShop对象</returns>
        public static WarehouseLineShop GetModel(int iD)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取WarehouseLineShop集合
        /// <summary>
        /// 根据字典获取WarehouseLineShop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WarehouseLineShop> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WarehouseLineShop数据集
        /// <summary>
        /// 根据字典获取WarehouseLineShop数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WarehouseLineShop集合
        /// <summary>
        /// 分页获取WarehouseLineShop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WarehouseLineShop> GetPageList(PageListBySql<WarehouseLineShop> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class WarehouseLineShopBLO
    {

        #region 根据 门店ID 删除 WarehouseLineShop
        /// <summary>
        /// 根据 门店ID 删除 WarehouseLineShop
        /// </summary>
        /// <param name="ShopID">门店ID</param>
        /// <returns>数据库影响行数</returns>
        public static int DeleteByShopID(int ShopID)
        {
            return DALFactory.GetLazyInstance<IWarehouseLineShopDAO>().DeleteByShopID(ShopID);
        }
        #endregion
    }

}