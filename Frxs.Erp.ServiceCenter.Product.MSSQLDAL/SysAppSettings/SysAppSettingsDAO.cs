
/*****************************
* Author:TangFan
*
* Date:2016-06-24
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// ### 系统字符串配置表SysAppSettings数据库访问类
    /// </summary>
    public partial class SysAppSettingsDAO : BaseDAL, ISysAppSettingsDAO
    {
        const string tableName = "SysAppSettings";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }

        /// <summary>
        /// 根据主键获取SysAppSettings对象
        /// </summary>
        /// <param name="iD">ID主键</param>
        /// <returns>SysAppSettings对象</returns>
        public SysAppSettings GetModel(int WID, string SKey)
        {
            DBHelper helper = DBHelper.GetInstance();
            SysAppSettings model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                                        new SqlParameter("@WID", SqlDbType.Int),
                                        new SqlParameter("@SKey", SqlDbType.VarChar)
                                    };
                sp[0].Value = WID;
                sp[1].Value = SKey;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SysAppSettings>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAppSettingsDAO.GetModel",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }

    }
}