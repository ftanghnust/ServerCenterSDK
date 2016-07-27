
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
    /// BuyPreAppDetailsExt业务逻辑类
    /// </summary>
    public partial class BuyPreAppDetailsExtBLO
    {
        #region 成员方法
        #region 根据主键验证BuyPreAppDetailsExt是否存在
        /// <summary>
        /// 根据主键验证BuyPreAppDetailsExt是否存在
        /// </summary>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(BuyPreAppDetailsExt model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>().Exists(model);
        }
        #endregion


        #region 添加一个BuyPreAppDetailsExt
        /// <summary>
        /// 添加一个BuyPreAppDetailsExt
        /// </summary>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(BuyPreAppDetailsExt model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>().Save(model);
        }
        #endregion


        #region 更新一个BuyPreAppDetailsExt
        /// <summary>
        /// 更新一个BuyPreAppDetailsExt
        /// </summary>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(BuyPreAppDetailsExt model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>().Edit(model);
        }
        #endregion


        #region 删除一个BuyPreAppDetailsExt
        /// <summary>
        /// 删除一个BuyPreAppDetailsExt
        /// </summary>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(BuyPreAppDetailsExt model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个BuyPreAppDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreAppDetailsExt
        /// </summary>
        /// <param name="iD">编号(BuyPreAppDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>().LogicDelete(iD);
        }
        #endregion



        #region 根据主键获取BuyPreAppDetailsExt对象
        /// <summary>
        /// 根据主键获取BuyPreAppDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(BuyPreAppDetails.ID)</param>
        /// <returns>BuyPreAppDetailsExt对象</returns>
        public static BuyPreAppDetailsExt GetModel(string iD)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>().GetModel(iD);
        }


       /// <summary>
       /// 
       /// </summary>
       /// <param name="iD"></param>
       /// <returns></returns>
        public static IList<BuyPreAppDetailsExt> GetModelList(int wid,string appId)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>(wid.ToString()).GetModelList(appId);
        }
        #endregion


        #region 根据字典获取BuyPreAppDetailsExt数据集
        /// <summary>
        /// 根据字典获取BuyPreAppDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取BuyPreAppDetailsExt集合
        /// <summary>
        /// 分页获取BuyPreAppDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<BuyPreAppDetailsExt> GetPageList(PageListBySql<BuyPreAppDetailsExt> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppDetailsExtDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }
}