/*****************************
* Author:罗涛
*
* Date:2016/6/14 9:26:21
******************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
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
