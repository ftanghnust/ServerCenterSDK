
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
    /// BuyPreAppBills业务逻辑类
    /// </summary>
    public partial class BuyPreAppBillsBLO
    {
        #region 成员方法
        #region 根据主键验证BuyPreAppBills是否存在
        /// <summary>
        /// 根据主键验证BuyPreAppBills是否存在
        /// </summary>
        /// <param name="model">BuyPreAppBills对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(BuyPreAppBills model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppBillsDAO>().Exists(model);
        }
        #endregion


        #region 添加一个BuyPreAppBills
        /// <summary>
        /// 添加一个BuyPreAppBills
        /// </summary>
        /// <param name="model">BuyPreAppBills对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(BuyPreAppBills model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppBillsDAO>().Save(model);
        }
        #endregion


        #region 更新一个BuyPreAppBills
        /// <summary>
        /// 更新一个BuyPreAppBills
        /// </summary>
        /// <param name="model">BuyPreAppBills对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(BuyPreAppBills model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppBillsDAO>().Edit(model);
        }
        #endregion


        #region 删除一个BuyPreAppBills
        /// <summary>
        /// 删除一个BuyPreAppBills
        /// </summary>
        /// <param name="model">BuyPreAppBills对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(BuyPreAppBills model)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppBillsDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个BuyPreAppBills
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreAppBills
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)只有申请单过帐后，才会有值:</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppBillsDAO>().LogicDelete(iD);
        }
        #endregion



        #region 根据主键获取BuyPreAppBills对象
        /// <summary>
        /// 根据主键获取BuyPreAppBills对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)只有申请单过帐后，才会有值:</param>
        /// <returns>BuyPreAppBills对象</returns>
        public static BuyPreAppBills GetModel(string iD)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppBillsDAO>().GetModel(iD);
        }
        #endregion



        #region 根据字典获取BuyPreAppBills数据集
        /// <summary>
        /// 根据字典获取BuyPreAppBills数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppBillsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取BuyPreAppBills集合
        /// <summary>
        /// 分页获取BuyPreAppBills集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<BuyPreAppBills> GetPageList(PageListBySql<BuyPreAppBills> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IBuyPreAppBillsDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }
}