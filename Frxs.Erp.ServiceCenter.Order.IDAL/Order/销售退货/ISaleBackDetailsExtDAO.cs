
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
    /// ### SaleBackDetailsExt数据库访问接口
    /// </summary>
    public partial interface ISaleBackDetailsExtDAO
    {

        #region 添加一个SaleBackDetailsExt
        /// <summary>
        /// 添加一个SaleBackDetailsExt
        /// </summary>
        /// <param name="model">SaleBackDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleBackPreDetailsExt model, IDbConnection conn, IDbTransaction trans);
        #endregion

    }
}