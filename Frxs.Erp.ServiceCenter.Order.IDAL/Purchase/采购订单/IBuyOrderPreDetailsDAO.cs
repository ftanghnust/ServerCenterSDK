
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
    /// ### BuyOrderPreDetails数据库访问接口
    /// </summary>
    public partial interface IBuyOrderPreDetailsDAO : IBaseDAO
    {

        #region 添加一个BuyOrderPreDetails
        /// <summary>
        /// 添加一个BuyOrderPreDetails
        /// </summary>
        /// <param name="model">BuyOrderPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyOrderPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 更新一个BuyOrderPreDetails
        /// <summary>
        /// 更新一个BuyOrderPreDetails
        /// </summary>
        /// <param name="model">BuyOrderPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyOrderPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 删除一个BuyOrderPreDetails
        /// <summary>
        /// 删除一个BuyOrderPreDetails
        /// </summary>
        /// <param name="model">BuyOrderPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyOrderPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 根据BuyID批量删除BuyOrderPreDetails
        /// <summary>
        /// 根据BuyID批量删除BuyOrderPreDetails
        /// </summary>
        /// <param name="BuyID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int Delete(string BuyID, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 根据字典获取BuyOrderPreDetails集合 包含历史表
        /// <summary>
        /// 根据字典获取BuyOrderPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyOrderPreDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取BuyOrderPreDetails集合 不含历史表
        /// <summary>
        /// 根据字典获取BuyOrderPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BuyOrderPreDetails> GetListByPre(IDictionary<string, object> conditionDict);
        #endregion

        #region 分页获取BuyOrderPreDetails集合
        /// <summary>
        /// 分页获取BuyOrderPreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<BuyOrderPreDetails> GetPageList(PageListBySql<BuyOrderPreDetails> page, IDictionary<string, object> conditionDict);
        #endregion

    }
}