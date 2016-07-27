/*****************************
* Author:罗涛
*
* Date:2016/6/14 9:25:30
******************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.IOCFactory;

namespace Frxs.Erp.ServiceCenter.Product.BLL
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
