
/*****************************
* Author:CR
*
* Date:2016-04-25
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
    /// BuyPreAppDetails业务逻辑类
    /// </summary>
    public partial class BuyPreAppDetailsBLO
    {
        #region 成员方法
        #region 根据主键验证BuyPreAppDetails是否存在
        /// <summary>
        /// 根据主键验证BuyPreAppDetails是否存在
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(BuyPreAppDetails model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>().Exists(model);
        }
        #endregion


        #region 添加一个BuyPreAppDetails
        /// <summary>
        /// 添加一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(BuyPreAppDetails model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>().Save(model);
        }
        #endregion


        #region 更新一个BuyPreAppDetails
        /// <summary>
        /// 更新一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(BuyPreAppDetails model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>().Edit(model);
        }
        #endregion


        #region 删除一个BuyPreAppDetails
        /// <summary>
        /// 删除一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(BuyPreAppDetails model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个BuyPreAppDetails
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreAppDetails
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>().LogicDelete(iD);
        }
        #endregion



        #region 根据主键获取BuyPreAppDetails对象
        /// <summary>
        /// 根据主键获取BuyPreAppDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>BuyPreAppDetails对象</returns>
        public static BuyPreAppDetails GetModel(string iD)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>().GetModel(iD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static IList<BuyPreAppDetails> GetModelList(int wid,string appId)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>(wid.ToString()).GetModelList(appId);
        }
        #endregion


        #region 根据字典获取BuyPreAppDetails数据集
        /// <summary>
        /// 根据字典获取BuyPreAppDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取BuyPreAppDetails集合
        /// <summary>
        /// 分页获取BuyPreAppDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<BuyPreAppDetails> GetPageList(PageListBySql<BuyPreAppDetails> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }
}