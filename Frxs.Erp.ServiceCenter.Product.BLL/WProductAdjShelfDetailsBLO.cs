
/*****************************
* Author:CHUJL
*
* Date:2016-04-09
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
    /// 仓库商品货架调整明细表WProductAdjShelfDetails业务逻辑类
    /// </summary>
    public partial class WProductAdjShelfDetailsBLO
    {
        #region 成员方法
        #region 根据主键验证WProductAdjShelfDetails是否存在
        /// <summary>
        /// 根据主键验证WProductAdjShelfDetails是否存在
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WProductAdjShelfDetails model)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WProductAdjShelfDetails
        /// <summary>
        /// 添加一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductAdjShelfDetails model)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().Save(model);
        }
        #endregion


        #region 更新一个WProductAdjShelfDetails
        /// <summary>
        /// 更新一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductAdjShelfDetails model)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().Edit(model);
        }
        #endregion


        #region 删除一个WProductAdjShelfDetails
        /// <summary>
        /// 删除一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WProductAdjShelfDetails model)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WProductAdjShelfDetails
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(long iD)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().LogicDelete(iD);
        }
        #endregion


        //#region 根据字典获取WProductAdjShelfDetails对象
        ///// <summary>
        ///// 根据字典获取WProductAdjShelfDetails对象
        ///// </summary>
        ///// <param name="query">查询对象</param>
        ///// <returns>WProductAdjShelfDetails对象</returns>
        //public static WProductAdjShelfDetails GetModel(WProductAdjShelfDetailsQuery query)
        //{
        //    return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().GetModel(query);
        //}
        //#endregion


        #region 根据主键获取WProductAdjShelfDetails对象
        /// <summary>
        /// 根据主键获取WProductAdjShelfDetails对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductAdjShelfDetails对象</returns>
        public static WProductAdjShelfDetails GetModel(long iD)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().GetModel(iD);
        }
        #endregion


        //#region 根据字典获取WProductAdjShelfDetails集合
        ///// <summary>
        ///// 根据字典获取WProductAdjShelfDetails集合
        ///// </summary>
        ///// <param name="query">查询对象</param>
        ///// <returns>数据集合</returns>
        //public static IList<WProductAdjShelfDetails> GetList(WProductAdjShelfDetailsQuery query)
        //{
        //    return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().GetList(query);
        //}
        //#endregion


        #region 根据字典获取WProductAdjShelfDetails数据集
        /// <summary>
        /// 根据字典获取WProductAdjShelfDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WProductAdjShelfDetails集合
        /// <summary>
        /// 分页获取WProductAdjShelfDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WProductAdjShelfDetails> GetPageList(PageListBySql<WProductAdjShelfDetails> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().GetPageList(page, conditionDict);
        }
        #endregion

        #region 获取WProductAdjShelfDetails集合
        /// <summary>
        /// 分页获取WProductAdjShelfDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static IList<WProductAdjShelfDetails> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().GetList(conditionDict);
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
            return DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }
}