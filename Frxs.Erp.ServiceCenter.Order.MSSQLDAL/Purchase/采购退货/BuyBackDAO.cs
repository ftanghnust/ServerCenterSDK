
/*****************************
* Author:TangFan
*
* Date:2016-03-10
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


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### BuyBack数据库访问类
    /// </summary>
    public partial class BuyBackDAO : BaseDAL, IBuyBackDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BuyBackDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BuyBackDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "BuyBack";

        #region 添加一个BuyBack
        /// <summary>
        /// 添加一个BuyBack
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public int Save(BuyBackPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@SubWID", SqlDbType.Int),
                                new SqlParameter("@PreBuyID", SqlDbType.VarChar, 36),
                                new SqlParameter("@OrderDate", SqlDbType.DateTime),
                                new SqlParameter("@WCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@WName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@VendorID", SqlDbType.Int),
                                new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@Status", SqlDbType.Int),
                                new SqlParameter("@TotalAmt", SqlDbType.Money),
                                new SqlParameter("@ConfTime", SqlDbType.DateTime),
                                new SqlParameter("@ConfUserID", SqlDbType.Int),
                                new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@PostingTime", SqlDbType.DateTime),
                                new SqlParameter("@PostingUserID", SqlDbType.Int),
                                new SqlParameter("@PostingUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@SettleTime", SqlDbType.DateTime),
                                new SqlParameter("@SettleUserID", SqlDbType.Int),
                                new SqlParameter("@SettleUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@SettleID", SqlDbType.VarChar, 50),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
                                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                                new SqlParameter("@CreateUserID", SqlDbType.Int),
                                new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime)

                                };
            sp[0].Value = model.BackID;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            sp[3].Value = model.PreBuyID;
            sp[4].Value = model.OrderDate;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.SubWCode;
            sp[8].Value = model.SubWName;
            sp[9].Value = model.VendorID;
            sp[10].Value = model.VendorCode;
            sp[11].Value = model.VendorName;
            sp[12].Value = model.Status;
            sp[13].Value = model.TotalAmt;
            sp[14].Value = model.ConfTime;
            sp[15].Value = model.ConfUserID;
            sp[16].Value = model.ConfUserName;
            sp[17].Value = model.PostingTime;
            sp[18].Value = model.PostingUserID;
            sp[19].Value = model.PostingUserName;
            sp[20].Value = model.SettleTime;
            sp[21].Value = model.SettleUserID;
            sp[22].Value = model.SettleUserName;
            sp[23].Value = model.SettleID;
            sp[24].Value = model.Remark;
            sp[25].Value = model.CreateTime;
            sp[26].Value = model.CreateUserID;
            sp[27].Value = model.CreateUserName;
            sp[28].Value = model.ModifyUserID;
            sp[29].Value = model.ModifyUserName;
            sp[30].Value = model.ModifyTime;

            try
            {
                object o = new object();
                if (conn == null && tran == null)
                {
                    o = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    o = helper.ExecNonQuery(conn, tran, sql, sp);
                }
                if (o != null)
                {
                    bool isSuccess = int.TryParse(o.ToString(), out result);
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
                    LogOperation = "Frxs.ServiceCenter.Order.MSSQLDAL.BuyBack.Save",
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

    }
}