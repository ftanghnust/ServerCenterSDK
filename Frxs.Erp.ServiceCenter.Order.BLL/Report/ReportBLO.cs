
/*****************************
* Author:CR
*
* Date:2016-04-11
******************************/
using System;
using System.Collections.Generic;

using System.Linq;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Erp.ServiceCenter.Order.BLL.Stock;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// 报表业务逻辑类
    /// </summary>
    public partial class ReportBLO
    {
        #region 成员方法  

        #region 根据字典获取报表
        /// <summary>
        /// 根据字典获取报表
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static DataTable GetReport(IDictionary<string, object> query, string warehouseId, string procedure_Name)
        {
            return DALFactory.GetLazyInstance<IReportDAO>(warehouseId).GetReport(query, procedure_Name);
        }
        #endregion

        #endregion
    }
}