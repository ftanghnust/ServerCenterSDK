/*****************************
* Author:罗靖
*
* Date:2016-06-17
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
    /// Settlement业务逻辑类
    /// </summary>
    public partial class SettlementBLO
    {
        #region 成员方法
        #region 根据主键验证Settlement是否存在
        /// <summary>
        /// 根据主键验证Settlement是否存在
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(Settlement model)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().Exists(model);
        }
        #endregion


        #region 添加一个Settlement
        /// <summary>
        /// 添加一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(Settlement model)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().Save(model);
        }
        #endregion


        #region 更新一个Settlement
        /// <summary>
        /// 更新一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(Settlement model)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().Edit(model);
        }
        #endregion


        #region 删除一个Settlement
        /// <summary>
        /// 删除一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(Settlement model)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个Settlement
        /// <summary>
        /// 根据主键逻辑删除一个Settlement
        /// </summary>
        /// <param name="iD">ID(GUID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取Settlement对象
        /// <summary>
        /// 根据字典获取Settlement对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>Settlement对象</returns>
        public static Settlement GetModel(SettlementQuery query)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().GetModel(query);
        }
        #endregion


        #region 根据主键获取Settlement对象
        /// <summary>
        /// 根据主键获取Settlement对象
        /// </summary>
        /// <param name="iD">ID(GUID)</param>
        /// <returns>Settlement对象</returns>
        public static Settlement GetModel(string iD)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取Settlement集合
        /// <summary>
        /// 根据字典获取Settlement集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public static IList<Settlement> GetList(SettlementQuery query)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().GetList(query);
        }
        #endregion


        #region 根据字典获取Settlement数据集
        /// <summary>
        /// 根据字典获取Settlement数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取Settlement集合
        /// <summary>
        /// 分页获取Settlement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Settlement> GetPageList(PageListBySql<Settlement> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }
    /// <summary>
    /// Settlement 业务逻辑类 龙武
    /// </summary>
    public partial class SettlementBLO
    {
        /// <summary>
        /// 分页获取Settlement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Settlement> GetSettlementList(PageListBySql<Settlement> page, IDictionary<string, object> conditionDict,string wid)
        {
            return DALFactory.GetLazyInstance<ISettlementDAO>(wid).GetSettlementList(page, conditionDict);
        }
    }
}
