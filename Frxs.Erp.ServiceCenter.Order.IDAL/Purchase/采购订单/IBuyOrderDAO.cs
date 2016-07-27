
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
    /// ### BuyOrder数据库访问接口
    /// </summary>
    public partial interface IBuyOrderDAO
    {

        #region 添加一个BuyOrderPre
        /// <summary>
        /// 添加一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyOrderPre model, IDbConnection conn, IDbTransaction trans);
        #endregion

    }
}