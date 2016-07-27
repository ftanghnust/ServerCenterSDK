
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
    /// BuyOrderPreDetails业务逻辑类
    /// </summary>
    public partial class BuyOrderPreDetailsBLO
    {
        #region 添加一个BuyOrderPreDetails
        /// <summary>
        /// 添加一个BuyOrderPreDetails
        /// </summary>
        /// <param name="model">BuyOrderPreDetails对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(BuyOrderPreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().Save(model, conn, trans);
        }
        #endregion

        #region 更新一个BuyOrderPreDetails
        /// <summary>
        /// 更新一个BuyOrderPreDetails
        /// </summary>
        /// <param name="model">BuyOrderPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(BuyOrderPreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().Edit(model, conn, trans);
        }
        #endregion

        #region 删除一个BuyOrderPreDetails
        /// <summary>
        /// 删除一个BuyOrderPreDetails
        /// </summary>
        /// <param name="model">BuyOrderPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(BuyOrderPreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().Delete(model, conn, trans);
        }
        #endregion

        #region 根据BuyID批量删除BuyOrderPreDetails
        /// <summary>
        /// 根据BuyID批量删除BuyOrderPreDetails
        /// </summary>
        /// <param name="BuyID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static int Delete(string BuyID, IDbConnection conn, IDbTransaction trans, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>(WID).Delete(BuyID, conn, trans);
        }
        #endregion

        #region 分页获取BuyOrderPreDetails集合
        /// <summary>
        /// 分页获取BuyOrderPreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<BuyOrderPreDetails> GetPageList(PageListBySql<BuyOrderPreDetails> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().GetPageList(page, conditionDict);
        }
        #endregion

        #region 根据字典获取BuyOrderPreDetails集合
        /// <summary>
        /// 根据字典获取BuyOrderPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<BuyOrderPreDetails> GetList(IDictionary<string, object> conditionDict, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>(WID).GetList(conditionDict);
        }
        #endregion

    }

    public partial class BuyOrderPreDetailsBLO
    {
        //#region 批量添加BuyOrderPreDetails
        ///// <summary>
        ///// 批量添加BuyOrderPreDetails
        ///// </summary>
        ///// <param name="model">BuyOrderPreDetails对象</param>
        ///// <returns>数据库影响行数</returns>
        //public static int Save(IList<BuyOrderPreDetails> models)
        //{
        //    var connection = DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().GetConnection();
        //    connection.Open();
        //    var trans = connection.BeginTransaction();
        //    int row = 0;
        //    try
        //    {
        //        foreach (var model in models)
        //        {
        //            row += DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().Save(model, connection, trans);
        //        }
        //        if (row == models.Count)
        //        {
        //            trans.Commit();
        //            return row;
        //        }
        //        else
        //        {
        //            trans.Rollback();
        //            return 0;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        trans.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        trans.Dispose();
        //        connection.Close();
        //        connection.Dispose();
        //    }
        //}
        //#endregion

        //#region 批量删除BuyOrderPreDetails
        ///// <summary>
        ///// 事务批量删除订单详情
        ///// </summary>
        ///// <param name="IDs"></param>
        ///// <returns></returns>
        //public static int Delete(string IDs)
        //{
        //    var ids = IDs.Split(',');
        //    var connection = DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().GetConnection();
        //    connection.Open();
        //    var trans = connection.BeginTransaction();
        //    int row = 0;
        //    try
        //    {
        //        foreach (string id in ids)
        //        {
        //            BuyOrderPreDetails orderdetails = new BuyOrderPreDetails();
        //            orderdetails.ID = id;
        //            row += BuyOrderPreDetailsBLO.Delete(orderdetails, connection, trans);  //物理删除
        //        }
        //        if (row == IDs.Length)
        //        {
        //            trans.Commit();
        //            return row;
        //        }
        //        else
        //        {
        //            trans.Rollback();
        //            return 0;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        trans.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        trans.Dispose();
        //        connection.Close();
        //        connection.Dispose();
        //    }
        //}
        //#endregion

        //#region 批量更新BuyOrderPreDetails
        ///// <summary>
        ///// 批量更新BuyOrderPreDetails
        ///// </summary>
        ///// <param name="model">BuyOrderPreDetails对象</param>
        ///// <returns>数据库影响行数</returns>
        //public static int Edit(IList<BuyOrderPreDetails> models)
        //{
        //    var connection = DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().GetConnection();
        //    connection.Open();
        //    var trans = connection.BeginTransaction();
        //    int row = 0;
        //    try
        //    {
        //        foreach (var model in models)
        //        {
        //            row += DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>().Edit(model, connection, trans);
        //        }
        //        if (row == models.Count)
        //        {
        //            trans.Commit();
        //            return row;
        //        }
        //        else
        //        {
        //            trans.Rollback();
        //            return 0;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        trans.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        trans.Dispose();
        //        connection.Close();
        //        connection.Dispose();
        //    }
        //}
        //#endregion

    }
}