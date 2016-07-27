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
    /// WProductPromotionDetails业务逻辑类
    /// </summary>
    public partial class WProductPromotionDetailsBLO
    {
        #region 成员方法
        #region 根据主键验证WProductPromotionDetails是否存在
        /// <summary>
        /// 根据主键验证WProductPromotionDetails是否存在
        /// </summary>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WProductPromotionDetails model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个WProductPromotionDetails
        /// <summary>
        /// 添加一个WProductPromotionDetails
        /// </summary>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductPromotionDetails model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个WProductPromotionDetails
        /// <summary>
        /// 更新一个WProductPromotionDetails
        /// </summary>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductPromotionDetails model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个WProductPromotionDetails
        /// <summary>
        /// 删除一个WProductPromotionDetails
        /// </summary>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WProductPromotionDetails model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WProductPromotionDetails
        /// <summary>
        /// 根据主键逻辑删除一个WProductPromotionDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取WProductPromotionDetails对象
        /// <summary>
        /// 根据字典获取WProductPromotionDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>WProductPromotionDetails对象</returns>
        public static WProductPromotionDetails GetModel(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WProductPromotionDetails对象
        /// <summary>
        /// 根据主键获取WProductPromotionDetails对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>WProductPromotionDetails对象</returns>
        public static WProductPromotionDetails GetModel(int iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取WProductPromotionDetails集合
        /// <summary>
        /// 根据字典获取WProductPromotionDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<WProductPromotionDetails> GetList(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WProductPromotionDetails数据集
        /// <summary>
        /// 根据字典获取WProductPromotionDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WProductPromotionDetails集合
        /// <summary>
        /// 分页获取WProductPromotionDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WProductPromotionDetails> GetPageList(PageListBySql<WProductPromotionDetails> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).GetPageList(page, conditionDict);
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
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }
}
