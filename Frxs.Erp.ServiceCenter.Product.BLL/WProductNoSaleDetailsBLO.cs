
/*****************************
* Author:CR
*
* Date:2016-03-31
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
    /// 仓库商品限购明细表WProductNoSaleDetails业务逻辑类
    /// </summary>
    public partial class WProductNoSaleDetailsBLO
    {
        #region 成员方法
        #region 根据主键验证WProductNoSaleDetails是否存在
        /// <summary>
        /// 根据主键验证WProductNoSaleDetails是否存在
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WProductNoSaleDetails model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WProductNoSaleDetails
        /// <summary>
        /// 添加一个WProductNoSaleDetails
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductNoSaleDetails model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().Save(model);
        }
        #endregion


        #region 更新一个WProductNoSaleDetails
        /// <summary>
        /// 更新一个WProductNoSaleDetails
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductNoSaleDetails model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().Edit(model);
        }
        #endregion


        #region 删除一个WProductNoSaleDetails
        /// <summary>
        /// 删除一个WProductNoSaleDetails
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WProductNoSaleDetails model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WProductNoSaleDetails
        /// <summary>
        /// 根据主键逻辑删除一个WProductNoSaleDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取WProductNoSaleDetails对象
        /// <summary>
        /// 根据字典获取WProductNoSaleDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductNoSaleDetails对象</returns>
        public static WProductNoSaleDetails GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().GetModel(conditionDict);
        }
        #endregion


        


        #region 根据字典获取WProductNoSaleDetails集合
        /// <summary>
        /// 根据字典获取WProductNoSaleDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WProductNoSaleDetails> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WProductNoSaleDetails数据集
        /// <summary>
        /// 根据字典获取WProductNoSaleDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WProductNoSaleDetails集合
        /// <summary>
        /// 分页获取WProductNoSaleDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WProductNoSaleDetails> GetPageList(PageListBySql<WProductNoSaleDetails> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class WProductNoSaleDetailsBLO
    {
        #region 根据 noSaleID 获取WProductNoSaleDetails对象
        /// <summary>
        /// 根据主键获取WProductNoSaleDetails对象
        /// </summary>
        /// <param name="noSaleID">noSaleID</param>
        /// <returns>WProductNoSaleDetails对象</returns>
        public static IList<WProductNoSaleDetails> GetList(string noSaleID)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().GetList(noSaleID);
        }
        #endregion
    }
}