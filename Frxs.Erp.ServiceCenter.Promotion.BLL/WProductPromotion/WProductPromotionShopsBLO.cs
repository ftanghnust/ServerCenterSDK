/*****************************
* Author:
*
* Date:2016-04-07
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
    /// WProductPromotionShops业务逻辑类
    /// </summary>
    public partial class WProductPromotionShopsBLO
    {
        #region 成员方法
        #region 根据主键验证WProductPromotionShops是否存在
        /// <summary>
        /// 根据主键验证WProductPromotionShops是否存在
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WProductPromotionShops model, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个WProductPromotionShops
        /// <summary>
        /// 添加一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductPromotionShops model, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个WProductPromotionShops
        /// <summary>
        /// 更新一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductPromotionShops model, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个WProductPromotionShops
        /// <summary>
        /// 删除一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WProductPromotionShops model, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WProductPromotionShops
        /// <summary>
        /// 根据主键逻辑删除一个WProductPromotionShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取WProductPromotionShops对象
        /// <summary>
        /// 根据字典获取WProductPromotionShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>WProductPromotionShops对象</returns>
        public static WProductPromotionShops GetModel(IDictionary<string, object> conditionDict, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WProductPromotionShops对象
        /// <summary>
        /// 根据主键获取WProductPromotionShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>WProductPromotionShops对象</returns>
        public static WProductPromotionShops GetModel(int iD, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取WProductPromotionShops集合
        /// <summary>
        /// 根据字典获取WProductPromotionShops集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<WProductPromotionShops> GetList(IDictionary<string, object> conditionDict, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WProductPromotionShops数据集
        /// <summary>
        /// 根据字典获取WProductPromotionShops数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WProductPromotionShops集合
        /// <summary>
        /// 分页获取WProductPromotionShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WProductPromotionShops> GetPageList(PageListBySql<WProductPromotionShops> page, IDictionary<string, object> conditionDict, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).GetPageList(page, conditionDict);
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
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, string warehouseId = null)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion

    }
}
