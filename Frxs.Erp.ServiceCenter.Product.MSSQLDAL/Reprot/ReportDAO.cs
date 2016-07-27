/*****************************
* Author:罗涛
*
* Date:2016/6/14 9:44:19
******************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Reprot
{
    /// <summary>
    /// ### Report数据库访问类
    /// </summary>
    public partial class ReportDAO : BaseDAL, IReportDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ReportDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public ReportDAO(string warehouseId)
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

        public DataTable GetReport(IDictionary<string, object> query, string procedure_Name)
        {
            DBHelper helper = DBHelper.GetInstance();
            DataTable dt = null;

            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);

                DataSet ds = helper.GetDataSet(procedure_Name, sp, false);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Report.GetReport",
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
    }
}
