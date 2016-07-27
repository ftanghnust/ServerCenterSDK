
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.Model.Order;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
	/// <summary>
	/// SaleOrderPreDetailsPick业务逻辑类
	/// </summary>
	public partial class SaleOrderPreDetailsPickBLO
	{
		#region 成员方法
		#region 根据主键验证SaleOrderPreDetailsPick是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPreDetailsPick是否存在
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleOrderPreDetailsPick model)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().Exists(model);
        }
        #endregion
        

		#region 添加一个SaleOrderPreDetailsPick
        /// <summary>
        /// 添加一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleOrderPreDetailsPick model)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().Save(model);
        }
        #endregion
        

        #region 更新一个SaleOrderPreDetailsPick
        /// <summary>
        /// 更新一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleOrderPreDetailsPick model)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().Edit(model);
        }
        #endregion
        

        #region 删除一个SaleOrderPreDetailsPick
        /// <summary>
        /// 删除一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleOrderPreDetailsPick model)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().Delete(model);
        }
        #endregion
        

        #region 根据主键逻辑删除一个SaleOrderPreDetailsPick
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="iD">编号(=SaleOrderDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().LogicDelete(iD);
        }
        #endregion
        
        

        #region 根据主键获取SaleOrderPreDetailsPick对象
        /// <summary>
        /// 根据主键获取SaleOrderPreDetailsPick对象
        /// </summary>
        /// <param name="iD">编号(=SaleOrderDetails.ID)</param>
        /// <returns>SaleOrderPreDetailsPick对象</returns>
        public static SaleOrderPreDetailsPick GetModel(string iD)
        {
             return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().GetModel(iD);   
        }
        #endregion
        
        

        #region 根据字典获取SaleOrderPreDetailsPick数据集
        /// <summary>
        /// 根据字典获取SaleOrderPreDetailsPick数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
           return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion
        

        #region 分页获取SaleOrderPreDetailsPick集合
        /// <summary>
        /// 分页获取SaleOrderPreDetailsPick集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrderPreDetailsPick> GetPageList(PageListBySql<SaleOrderPreDetailsPick> page, IDictionary<string, object> conditionDict)
        {
           return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().GetPageList(page,conditionDict);
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
            return DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion
        

        #endregion
        }
}
