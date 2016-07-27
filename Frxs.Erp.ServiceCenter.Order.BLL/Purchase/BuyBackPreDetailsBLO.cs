
/*****************************
* Author:TangFan
*
* Date:2016-03-10
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
    /// BuyBackPreDetails业务逻辑类
    /// </summary>
    public partial class BuyBackPreDetailsBLO
    {
        #region 添加一个BuyBackPreDetails
        /// <summary>
        /// 添加一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(BuyBackPreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>().Save(model, conn, trans);
        }
        #endregion

        #region 更新一个BuyBackPreDetails
        /// <summary>
        /// 更新一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(BuyBackPreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>().Edit(model, conn, trans);
        }
        #endregion

        #region 删除一个BuyBackPreDetails
        /// <summary>
        /// 删除一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(BuyBackPreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>().Delete(model, conn, trans);
        }
        #endregion

        #region 根据BackID批量删除BuyBackPreDetails
        /// <summary>
        /// 根据BuyID批量删除BuyBackPreDetails
        /// </summary>
        /// <param name="BuyID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static int Delete(string BackID, IDbConnection conn, IDbTransaction trans, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>(WID).Delete(BackID, conn, trans);
        }
        #endregion

        #region 分页获取BuyBackPreDetails集合
        /// <summary>
        /// 分页获取BuyBackPreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<BuyBackPreDetails> GetPageList(PageListBySql<BuyBackPreDetails> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>().GetPageList(page, conditionDict);
        }
        #endregion

        #region 根据字典获取BuyBackPreDetails集合
        /// <summary>
        /// 根据字典获取BuyBackPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<BuyBackPreDetails> GetList(IDictionary<string, object> conditionDict, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>(WID).GetList(conditionDict);
        }
        #endregion

    }

    public partial class BuyBackPreDetailsBLO
    {


    }
}