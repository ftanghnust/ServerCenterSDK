
/*****************************
* Author:TangFan
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### BuyBackPreDetails数据库访问接口
    /// </summary>
    public partial interface IBuyBackPreDetailsDAO : IBaseDAO
    {

        #region 添加一个BuyBackPreDetails
        /// <summary>
        /// 添加一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyBackPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 更新一个BuyBackPreDetails
        /// <summary>
        /// 更新一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyBackPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 删除一个BuyBackPreDetails
        /// <summary>
        /// 删除一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyBackPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 根据BuyID批量删除BuyBackPreDetails
        /// <summary>
        /// 根据BuyID批量删除BuyBackPreDetails
        /// </summary>
        /// <param name="BuyID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int Delete(string BuyID, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 根据字典获取BuyBackPreDetails集合 包含历史表数据
        /// <summary>
        /// 根据字典获取BuyBackPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyBackPreDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion

        #region 分页获取BuyBackPreDetails集合
        /// <summary>
        /// 分页获取BuyBackPreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<BuyBackPreDetails> GetPageList(PageListBySql<BuyBackPreDetails> page, IDictionary<string, object> conditionDict);
        #endregion

        #region 根据字典获取BuyBackPreDetails集合 不含历史表数据
        /// <summary>
        /// 根据字典获取BuyBackPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyBackPreDetails> GetListByPre(IDictionary<string, object> conditionDict);
        #endregion
    }
}