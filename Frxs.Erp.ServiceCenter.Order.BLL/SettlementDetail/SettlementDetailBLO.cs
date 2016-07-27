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
    /// SettlementDetail业务逻辑类
    /// </summary>
    public partial class SettlementDetailBLO
    {
        #region 成员方法
        #region 根据主键验证SettlementDetail是否存在
        /// <summary>
        /// 根据主键验证SettlementDetail是否存在
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SettlementDetail model)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().Exists(model);
        }
        #endregion


        #region 添加一个SettlementDetail
        /// <summary>
        /// 添加一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SettlementDetail model)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().Save(model);
        }
        #endregion


        #region 更新一个SettlementDetail
        /// <summary>
        /// 更新一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SettlementDetail model)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().Edit(model);
        }
        #endregion


        #region 删除一个SettlementDetail
        /// <summary>
        /// 删除一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SettlementDetail model)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SettlementDetail
        /// <summary>
        /// 根据主键逻辑删除一个SettlementDetail
        /// </summary>
        /// <param name="iD">ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取SettlementDetail对象
        /// <summary>
        /// 根据字典获取SettlementDetail对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SettlementDetail对象</returns>
        public static SettlementDetail GetModel(SettlementDetailQuery query)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().GetModel(query);
        }
        #endregion


        #region 根据主键获取SettlementDetail对象
        /// <summary>
        /// 根据主键获取SettlementDetail对象
        /// </summary>
        /// <param name="iD">ID</param>
        /// <returns>SettlementDetail对象</returns>
        public static SettlementDetail GetModel(int iD)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取SettlementDetail集合
        /// <summary>
        /// 根据字典获取SettlementDetail集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public static IList<SettlementDetail> GetList(SettlementDetailQuery query)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().GetList(query);
        }
        #endregion


        #region 根据字典获取SettlementDetail数据集
        /// <summary>
        /// 根据字典获取SettlementDetail数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SettlementDetail集合
        /// <summary>
        /// 分页获取SettlementDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SettlementDetail> GetPageList(PageListBySql<SettlementDetail> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }

    /// <summary>
    /// 结算单详细表 - SettlementDetail业务逻辑类 --- 龙武
    /// </summary>
    public partial class SettlementDetailBLO
    {
        /// <summary>
        /// 分页获取SettlementDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static SettlementDetailsList GetDetailsPageList(PageListBySql<SettlementDetail> page, IDictionary<string, object> conditionDict,string wid)
        {
            return DALFactory.GetLazyInstance<ISettlementDetailDAO>(wid).GetDetailsPageList(page, conditionDict);
        }
    }
}
