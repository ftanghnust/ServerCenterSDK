
/*****************************
* Author:TangFan
*
* Date:2016-03-09
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### BuyBackDetails数据库访问接口
    /// </summary>
    public partial interface IBuyBackDetailsDAO : IBaseDAO
    {
        #region 添加一个BuyBackPreDetails
        /// <summary>
        /// 添加一个BuyBackDetails
        /// </summary>
        /// <param name="model">BuyBackDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyBackPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion
    }
}