
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleBackDetails数据库访问接口
    /// </summary>
    public partial interface ISaleBackDetailsDAO
    {
        #region 事务添加一个SaleBackPreDetails
        /// <summary>
        /// 添加一个SaleBackDetails
        /// </summary>
        /// <param name="model">SaleBackDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleBackPreDetails model, IDbConnection conn, IDbTransaction trans);
        #endregion




    }
}