
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
    /// ### BuyBackPre数据库访问接口
    /// </summary>
    public partial interface IBuyBackPreDAO : IBaseDAO
    {
        #region 根据主键验证BuyBackPre是否存在
        /// <summary>
        /// 根据主键验证BuyBackPre是否存在
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyBackPre model);
        #endregion

        #region 添加一个BuyBackPre
        /// <summary>
        /// 添加一个BuyBackPre
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 删除一个BuyBackPre
        /// <summary>
        /// 删除一个BuyBackPre
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 更新一个BuyBackPre
        /// <summary>
        /// 更新一个BuyBackPre
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 更新一个BuyBackPre(更改状态使用)
        /// <summary>
        /// 更新一个BuyBackPre
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int EditInChange(BuyBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 根据主键获取BuyBackPre对象
        /// <summary>
        /// 根据主键获取BuyBackPre对象
        /// </summary>
        /// <param name="buyID">采购单编号</param>
        /// <returns>BuyBackPre对象</returns>
        BuyBackPre GetModel(string buyID);
        #endregion

        #region 分页获取BuyBackPre集合
        /// <summary>
        /// 分页获取BuyBackPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        BuyBackPageModel GetPageList(BuyBackPageModel page, IDictionary<string, object> conditionDict);
        #endregion
    }
}