
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
    /// ### BuyOrderPre数据库访问接口
    /// </summary>
    public partial interface IBuyOrderPreDAO : IBaseDAO
    {
        #region 根据主键验证BuyOrderPre是否存在
        /// <summary>
        /// 根据主键验证BuyOrderPre是否存在
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyOrderPre model);
        #endregion

        #region 添加一个BuyOrderPre
        /// <summary>
        /// 添加一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyOrderPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 删除一个BuyOrderPre
        /// <summary>
        /// 删除一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyOrderPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 更新一个BuyOrderPre
        /// <summary>
        /// 更新一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyOrderPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 更新一个BuyOrderPre(更改状态使用)
        /// <summary>
        /// 更新一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int EditInChange(BuyOrderPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 根据主键获取BuyOrderPre对象
        /// <summary>
        /// 根据主键获取BuyOrderPre对象
        /// </summary>
        /// <param name="buyID">采购单编号</param>
        /// <returns>BuyOrderPre对象</returns>
        BuyOrderPre GetModel(string buyID);
        #endregion

        #region 分页获取BuyOrderPre集合
        /// <summary>
        /// 分页获取BuyOrderPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        BuyOrderPageModel GetPageList(BuyOrderPageModel page, IDictionary<string, object> conditionDict);
        #endregion
    }
}