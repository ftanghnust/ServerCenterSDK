
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
    /// ### BuyBack数据库访问接口
    /// </summary>
    public partial interface IBuyBackDAO
    {
        #region 添加一个BuyBackPre
        /// <summary>
        /// 添加一个BuyBackPre
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyBackPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

    }
}