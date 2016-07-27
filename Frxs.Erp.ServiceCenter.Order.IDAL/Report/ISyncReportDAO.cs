
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
    public partial interface ISyncReportDAO
    {
        #region 成员方法

        #region 获取同步报表数据
        /// <summary>
        /// 获取同步报表数据
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <param name="SarteTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="fale">是否出库(0：采购入库、销售出库，1：采购退库、销售退库)</param>
        /// <param name="SyncTableName">表名：（true：销售，false：采购）</param>
        /// <returns></returns>
        DataTable GetSyncReport(int WID, string SarteTime, string EndTime, int fale,bool SyncTableName);

        #endregion

        #region 执行插入同步数据
        /// <summary>
        /// 执行插入同步数据
        /// </summary>
        /// <param name="WID">仓库ID</param>
        /// <param name="SarteTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>        
        /// <param name="SyncTableName">表名：（true：销售，false：采购）</param>
        /// <returns></returns>
        int SetSyncReport(int WID, string SarteTime, string EndTime, bool SyncTableName);

        #endregion

        #endregion
    }
}
