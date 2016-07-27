/*****************************
* Author:CR
*
* Date:2016-04-11
******************************/

using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;

using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
	/// <summary>
	/// SaleSettleDetail业务逻辑类
	/// </summary>
	public partial class SaleSettleDetailBLO
	{
		#region 成员方法
		#region 根据主键验证SaleSettleDetail是否存在
        /// <summary>
        /// 根据主键验证SaleSettleDetail是否存在
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleSettleDetail model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Exists(model);
        }
        #endregion
        

		#region 添加一个SaleSettleDetail
        /// <summary>
        /// 添加一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleSettleDetail model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Save(model);
        }
        #endregion
        

        #region 更新一个SaleSettleDetail
        /// <summary>
        /// 更新一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleSettleDetail model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Edit(model);
        }
        #endregion
        

        #region 删除一个SaleSettleDetail
        /// <summary>
        /// 删除一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleSettleDetail model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).Delete(model);
        }
        #endregion
        

        #region 根据主键逻辑删除一个SaleSettleDetail
        /// <summary>
        /// 根据主键逻辑删除一个SaleSettleDetail
        /// </summary>
        /// <param name="iD">主键ID(WID+GUID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion
        

        #region 根据字典获取SaleSettleDetail对象
        /// <summary>
        /// 根据字典获取SaleSettleDetail对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleSettleDetail对象</returns>
        public static SaleSettleDetail GetModel(IDictionary<string, object>   query, string warehouseId)
        {
           return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).GetModel(query);
        }
        #endregion
        

        #region 根据主键获取SaleSettleDetail对象
        /// <summary>
        /// 根据主键获取SaleSettleDetail对象
        /// </summary>
        /// <param name="iD">主键ID(WID+GUID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleSettleDetail对象</returns>
        public static SaleSettleDetail GetModel(string iD, string warehouseId)
        {
             return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).GetModel(iD);   
        }
        #endregion
        

        #region 根据字典获取SaleSettleDetail集合
        /// <summary>
        /// 根据字典获取SaleSettleDetail集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<SaleSettleDetail> GetList(IDictionary<string, object>   query, string warehouseId)
        {
           return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).GetList(query);
        }
        #endregion
        

        #region 根据字典获取SaleSettleDetail数据集
        /// <summary>
        /// 根据字典获取SaleSettleDetail数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
           return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion
        

        #region 分页获取SaleSettleDetail集合
        /// <summary>
        /// 分页获取SaleSettleDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleSettleDetail> GetPageList(PageListBySql<SaleSettleDetail> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
           return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).GetPageList(page,conditionDict);
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
            return DALFactory.GetLazyInstance<ISaleSettleDetailDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion
        

        #endregion
        }
}
