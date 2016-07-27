
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
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
    /// SaleBackPreDetails业务逻辑类
    /// </summary>
    public partial class SaleBackPreDetailsBLO
    {
        #region 成员方法
        #region 根据主键验证SaleBackPreDetails是否存在
        /// <summary>
        /// 根据主键验证SaleBackPreDetails是否存在
        /// </summary>
        /// <param name="model">SaleBackPreDetails对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleBackPreDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().Exists(model);
        }
        #endregion


        #region 事务添加一个SaleBackPreDetails
        /// <summary>
        /// 添加一个SaleBackPreDetails
        /// </summary>
        /// <param name="model">SaleBackPreDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleBackPreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().Save(model, conn, trans);
        }
        #endregion


        #region 更新一个SaleBackPreDetails
        /// <summary>
        /// 更新一个SaleBackPreDetails
        /// </summary>
        /// <param name="model">SaleBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleBackPreDetails model)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().Edit(model);
        }
        #endregion


        #region 事务删除一个SaleBackPreDetails
        /// <summary>
        /// 删除一个SaleBackPreDetails
        /// </summary>
        /// <param name="model">SaleBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleBackPreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().Delete(model, conn, trans);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleBackPreDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleBackPreDetails
        /// </summary>
        /// <param name="iD">编号(GUID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取SaleBackPreDetails对象
        /// <summary>
        /// 根据字典获取SaleBackPreDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleBackPreDetails对象</returns>
        public static SaleBackPreDetails GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取SaleBackPreDetails对象
        /// <summary>
        /// 根据主键获取SaleBackPreDetails对象
        /// </summary>
        /// <param name="iD">编号(GUID)</param>
        /// <returns>SaleBackPreDetails对象</returns>
        public static SaleBackPreDetails GetModel(string iD)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取SaleBackPreDetails集合
        /// <summary>
        /// 根据字典获取SaleBackPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleBackPreDetails> GetList(IDictionary<string, object> conditionDict,string WID)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>(WID).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取SaleBackPreDetails数据集
        /// <summary>
        /// 根据字典获取SaleBackPreDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleBackPreDetails集合
        /// <summary>
        /// 分页获取SaleBackPreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleBackPreDetails> GetPageList(PageListBySql<SaleBackPreDetails> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class SaleBackPreDetailsBLO
    {
        //#region 根据BuyID批量删除SaleBackPreDetails
        ///// <summary>
        ///// 根据BuyID批量删除SaleBackPreDetails
        ///// </summary>
        ///// <param name="BuyID"></param>
        ///// <param name="conn"></param>
        ///// <param name="trans"></param>
        ///// <returns></returns>
        //public static int Delete(string BuyID, IDbConnection conn, IDbTransaction trans)
        //{
        //    return DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>().Delete(BuyID, conn, trans);
        //}
        //#endregion
    }

}