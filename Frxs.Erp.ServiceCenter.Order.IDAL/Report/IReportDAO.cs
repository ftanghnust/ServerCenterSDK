
/*****************************
* Author:CR
*
* Date:2016-04-11
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleSettle数据库访问接口
    /// </summary>
    public partial interface IReportDAO
    {


        #region 成员方法

        #region 根据字典获取报表
        /// <summary>
        /// 根据字典获取报表
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        DataTable GetReport(IDictionary<string, object> query, string procedure_Name);
       
        #endregion

        #endregion


    }

  
}