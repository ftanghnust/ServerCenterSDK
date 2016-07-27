
/*****************************
* Author:CR
*
* Date:2016-04-11
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Report
{
    public partial class SyncReportDAO : BaseDAL, ISyncReportDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SyncReportDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SyncReportDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "Report";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法


        #endregion



        #region IReportDAO 成员

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
        public DataTable GetSyncReport(int WID, string SarteTime, string EndTime, int fale, bool SyncTableName)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            DataTable dt = null;

            try
            {
                string sql = "";

                if (SyncTableName)
                {
                    sql = "select a.cCode as cVouchID,a.dDate as dVouchDate,cCusCode as cDwCode,cCusName as cCusName ,b.iPrice+b.pCost as iAmount ,b.iPrice as  cAmout, b.pCost as pCost from SyncSaleOrder a inner join (select c.cCode,SUM(c.iPrice) as iPrice,SUM(c.pCost) as pCost from SyncSaleDetailOrder c group by c.cCode ) b on a.cCode=b.cCode where a.WID=@WID  and a.IsOut=@IsOut and a.dDate>=@SarteTime and a.dDate<=@EndTime  order by cVouchID";
                }
                else
                {
                    sql = "select a.cCode as cVouchID,a.dDate as dVouchDate,cVenCode as cDwCode,cVenName as cVenName ,b.iPrice-b.cDefine32-b.cDefine33 as iAmount ,b.iPrice as  cAmout, b.cDefine32 as lCost,cDefine33 as wCost from SyncBuyOrder a inner join (select c.cCode,SUM(c.iPrice) as iPrice,SUM(c.cDefine32) as cDefine32,SUM(c.cDefine33) as cDefine33 from SyncBuyDetailOrder c group by c.cCode ) b on a.cCode=b.cCode where a.WID=@WID  and a.IsOut=@IsOut and a.dDate>=@SarteTime and a.dDate<=@EndTime order by cVouchID";
                }
                SqlParameter[] sp = {
                                    new SqlParameter("@WID", SqlDbType.Int),
                                    new SqlParameter("@IsOut", SqlDbType.Int),
                                    new SqlParameter("@SarteTime", SqlDbType.NVarChar,50),
                                    new SqlParameter("@EndTime", SqlDbType.NVarChar,50)
                                };
                sp[0].Value = WID;
                sp[1].Value = fale;
                sp[2].Value = SarteTime+" 00:00:00";
                sp[3].Value = EndTime +" 23:59:59";
                DataSet ds = helper.GetDataSet(sql, sp, true);

                if (ds != null)
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.SyncReportDAO.GetSyncReport",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }

            return dt;
        }
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
        public int SetSyncReport(int WID, string SarteTime, string EndTime, bool SyncTableName)
        {
            int result = 0;
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
               
                SqlParameter[] sp = new SqlParameter[] 
                {
                    new SqlParameter("@StartTime",SarteTime),
                    new SqlParameter("@EndTime",EndTime),
                    new SqlParameter("@WID",WID),
                };

                if (SyncTableName)
                {
                    string proc1 = "PROC_GET_SALEORDER_DATA";
                    result = helper.ExecNonQuery(proc1, sp, false);
                }
                else
                {
                    string proc2 = "PROC_GET_SALEBACK_DATA";
                    result = helper.ExecNonQuery(proc2, sp, false);
                }
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.DataSyncJob.AutoExecJob.ExecProc",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }

            return result;
        }

        #endregion

        #endregion
    }
}
