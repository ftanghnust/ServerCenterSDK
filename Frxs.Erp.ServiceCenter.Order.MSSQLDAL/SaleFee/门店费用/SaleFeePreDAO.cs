
/*****************************
* Author:chujl
*
* Date:2016-03-28
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
    /// ### SaleFeePre数据库访问类
    /// </summary>
    public partial class SaleFeePreDAO : BaseDAL, ISaleFeePreDAO
    {

        public SaleFeePreDAO(string warehouseId)
            : base(warehouseId)
        {

        }
        const string tableName = "SaleFeePre";




        #region 成员方法
        #region 根据主键验证SaleFeePre是否存在
        /// <summary>
        /// 根据主键验证SaleFeePre是否存在
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleFeePre model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.FeeID;

            try
            {
                result = int.Parse(helper.GetSingle(sql, sp).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.Exists",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result > 0;
        }
        #endregion


        #region 添加一个SaleFeePre
        /// <summary>
        /// 添加一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleFeePre model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalFeeAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@FeeDate", SqlDbType.DateTime )
};
            sp[0].Value = model.FeeID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.SubWID;
            sp[5].Value = model.SubWCode;
            sp[6].Value = model.SubWName;
            sp[7].Value = model.Status;
            sp[8].Value = model.TotalFeeAmt;
            sp[9].Value = model.Remark;
            sp[10].Value = model.CreateTime;
            sp[11].Value = model.CreateUserID;
            sp[12].Value = model.CreateUserName;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.FeeDate;

            try
            {
                result = helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.Save",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
        /// <summary>
        /// 添加一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleFeePre model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalFeeAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@FeeDate", SqlDbType.DateTime )
};
            sp[0].Value = model.FeeID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.SubWID;
            sp[5].Value = model.SubWCode;
            sp[6].Value = model.SubWName;
            sp[7].Value = model.Status;
            sp[8].Value = model.TotalFeeAmt;
            sp[9].Value = model.Remark;
            sp[10].Value = model.CreateTime;
            sp[11].Value = model.CreateUserID;
            sp[12].Value = model.CreateUserName;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.FeeDate;

            try
            {
                if (conn == null && trans == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, trans, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.Save",
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


        #region 更新一个SaleFeePre
        /// <summary>
        /// 更新一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleFeePre model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalFeeAmt", SqlDbType.Money),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 64),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SettleUserID", SqlDbType.Int),
new SqlParameter("@SettleUserName", SqlDbType.VarChar, 64),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@FeeDate", SqlDbType.DateTime)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.WCode;
            sp[2].Value = model.WName;
            sp[3].Value = model.SubWID;
            sp[4].Value = model.SubWCode;
            sp[5].Value = model.SubWName;
            sp[6].Value = model.Status;
            sp[7].Value = model.TotalFeeAmt;
            sp[8].Value = model.ConfTime;
            sp[9].Value = model.ConfUserID;
            sp[10].Value = model.ConfUserName;
            sp[11].Value = model.PostingTime;
            sp[12].Value = model.PostingUserID;
            sp[13].Value = model.PostingUserName;
            sp[14].Value = model.SettleTime;
            sp[15].Value = model.SettleUserID;
            sp[16].Value = model.SettleUserName;
            sp[17].Value = model.Remark;
            sp[18].Value = model.ModifyTime;
            sp[19].Value = model.ModifyUserID;
            sp[20].Value = model.ModifyUserName;
            sp[21].Value = model.FeeID;
            sp[22].Value = model.FeeDate;

            try
            {
                result = helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.Edit",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
        /// <summary>
        /// 更新一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleFeePre model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalFeeAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@FeeDate", SqlDbType.DateTime)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.WCode;
            sp[2].Value = model.WName;
            sp[3].Value = model.SubWID;
            sp[4].Value = model.SubWCode;
            sp[5].Value = model.SubWName;
            sp[6].Value = model.Status;
            sp[7].Value = model.TotalFeeAmt;
            sp[8].Value = model.Remark;
            sp[9].Value = model.ModifyTime;
            sp[10].Value = model.ModifyUserID;
            sp[11].Value = model.ModifyUserName;
            sp[12].Value = model.FeeID;
            sp[13].Value = model.FeeDate;

            try
            {

                if (conn == null && trans == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, trans, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.Edit",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;


        }

        /// <summary>
        /// 更新一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        public int EditStatus(SaleFeePre model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = "";
            if (model.Status > 2)
            {
                sql = SQLConfigBuilder.GetSQLScriptByTable("SaleFee", "EditStatus", base.AssemblyName, base.DatabaseName);
            }
            else
            {
                sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditStatus", base.AssemblyName, base.DatabaseName);

            }

            SqlParameter[] sp = {
new SqlParameter("@FeeID", SqlDbType.VarChar, 32),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 64),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SettleUserID", SqlDbType.Int),
new SqlParameter("@SettleUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)
};
            sp[0].Value = model.FeeID;
            sp[1].Value = model.Status;
            sp[2].Value = model.ConfTime;
            sp[3].Value = model.ConfUserID;
            sp[4].Value = model.ConfUserName;
            sp[5].Value = model.PostingTime;
            sp[6].Value = model.PostingUserID;
            sp[7].Value = model.PostingUserName;
            sp[8].Value = model.SettleTime;
            sp[9].Value = model.SettleUserID;
            sp[10].Value = model.SettleUserName;
            sp[11].Value = model.ModifyTime;
            sp[12].Value = model.ModifyUserID;
            sp[13].Value = model.ModifyUserName;

            try
            {

                #region 预处理数据操作

                if (conn == null && trans == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, trans, sql, sp);
                }

                #endregion

            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.Edit",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public int EditAndCopy(string feeId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = "";

            sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditAndCopy", base.AssemblyName, base.DatabaseName); //复制主表

            SqlParameter[] sp = {
new SqlParameter("@FeeID", SqlDbType.VarChar, 50)
};
            sp[0].Value = feeId;
            try
            {

                #region 预处理数据操作

                if (conn == null && trans == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, trans, sql, sp);
                }

                #endregion

            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.EditAndCopy",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public int EditAndCopy2(string feeId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = "";

            sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditAndCopy2", base.AssemblyName, base.DatabaseName); //复制主表

            SqlParameter[] sp = {
new SqlParameter("@FeeID", SqlDbType.VarChar, 50)
};
            sp[0].Value = feeId;
            try
            {

                #region 预处理数据操作

                if (conn == null && trans == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, trans, sql, sp);
                }

                #endregion

            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.EditAndCopy2",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public int EditStatusReset(SaleFeePre model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = "";
            if (model.Status == 1)
            {
                sql = SQLConfigBuilder.GetSQLScriptByTable("SaleFee", "EditStatusReset", base.AssemblyName, base.DatabaseName);
            }
            else
            {
                return 0;
            }

            SqlParameter[] sp = {
new SqlParameter("@FeeID", SqlDbType.VarChar, 32),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 64),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SettleUserID", SqlDbType.Int),
new SqlParameter("@SettleUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)
};
            sp[0].Value = model.FeeID;
            sp[1].Value = model.Status;
            sp[2].Value = model.ConfTime;
            sp[3].Value = model.ConfUserID;
            sp[4].Value = model.ConfUserName;
            sp[5].Value = model.PostingTime;
            sp[6].Value = model.PostingUserID;
            sp[7].Value = model.PostingUserName;
            sp[8].Value = model.SettleTime;
            sp[9].Value = model.SettleUserID;
            sp[10].Value = model.SettleUserName;
            sp[11].Value = model.ModifyTime;
            sp[12].Value = model.ModifyUserID;
            sp[13].Value = model.ModifyUserName;

            try
            {

                #region 预处理数据操作

                if (conn == null && trans == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, trans, sql, sp);
                }

                #endregion

            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.Edit",
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


        #region 删除一个SaleFeePre
        /// <summary>
        /// 删除一个SaleFeePre
        /// </summary>
        /// <param name="model">SaleFeePre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleFeePre model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.FeeID;

            try
            {
                result = helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.Delete",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }

        /// <summary>
        /// 根据主键逻辑删除一个SaleFee
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string feeID, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = feeID;

            try
            {

                if (conn == null && trans == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, trans, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.LogicDelete",
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


        #region 根据主键逻辑删除一个SaleFeePre
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeePre
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string feeID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = feeID;

            try
            {
                result = helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.LogicDelete",
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


        #region 根据字典获取SaleFeePre对象
        /// <summary>
        /// 根据字典获取SaleFeePre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeePre对象</returns>
        public SaleFeePre GetModel(IDictionary<string, object> conditionDict)
        {
            SaleFeePre model = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    { where.Append(string.Format(" AND {0}=@{0}", s.ParameterName)); }
                }
                IList<SaleFeePre> list = GetList(where.ToString(), sp);
                if (list != null && list.Count > 0)
                {
                    model = list[0];
                }
            }
            catch
            {
                throw;
            }
            return model;
        }
        #endregion


        #region 根据主键获取SaleFeePre对象
        /// <summary>
        /// 根据主键获取SaleFeePre对象
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>SaleFeePre对象</returns>
        public SaleFeePre GetModel(string feeID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleFeePre model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 36)
 };
                sp[0].Value = feeID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new SaleFeePre
                        {
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TotalFeeAmt = DataTypeHelper.GetDouble(sdr["TotalFeeAmt"]),
                            ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTimeNull(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetIntNull(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            SettleTime = DataTypeHelper.GetDateTimeNull(sdr["SettleTime"]),
                            SettleUserID = DataTypeHelper.GetIntNull(sdr["SettleUserID"]),
                            SettleUserName = DataTypeHelper.GetString(sdr["SettleUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            FeeDate = DataTypeHelper.GetDateTime(sdr["FeeDate"])
                        };
                    }
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.GetModel",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }
        #endregion


        #region 根据字典获取SaleFeePre集合
        /// <summary>
        /// 根据字典获取SaleFeePre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleFeePre> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleFeePre> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    { where.Append(string.Format(" AND {0}=@{0}", s.ParameterName)); }
                }
                list = GetList(where.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion


        #region 根据字典获取SaleFeePre数据集
        /// <summary>
        /// 根据字典获取SaleFeePre数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            DataSet ds = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    { where.Append(string.Format(" AND {0}=@{0}", s.ParameterName)); }
                }
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, sqlConfigName, base.AssemblyName, base.DatabaseName);
                ds = helper.GetDataSet(sql + where, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.GetDataSet",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return ds;
        }
        #endregion


        #region 分页获取SaleFeePre集合
        /// <summary>
        /// 分页获取SaleFeePre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleFeePre> GetPageList(PageListBySql<SaleFeePre> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = "vSaleFee";
                page.Fields = "FeeID,FeeDate,WID,WCode,WName,SubWID,SubWCode,SubWName,Status,TotalFeeAmt,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,SettleTime,SettleUserID,SettleUserName,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;

                page.Where = CreateCondition(conditionDict, ref parameters);
                StringBuilder addWhere = new StringBuilder();
                addWhere.Append("  and Exists(select 1 from vSaleFeeDetails where vSaleFee.FeeID=vSaleFeeDetails.FeeID ");
                if (conditionDict.ContainsKey("ShopCode"))
                {
                    addWhere.AppendFormat(" and vSaleFeeDetails.ShopCode ='{0}' ", conditionDict["ShopCode"]);
                }
                if (conditionDict.ContainsKey("ShopName"))
                {
                    addWhere.AppendFormat("  and vSaleFeeDetails.ShopName ='{0}' ", conditionDict["ShopName"]);
                }
                addWhere.Append(" ) ");
                page.Where = page.Where + addWhere.ToString();

                page.Parameters = (parameters as List<IDbDataParameter>).ToArray();
                string getCountSql = page.GetCountsSql();
                object counts = helper.GetSingle(getCountSql, page.Parameters);
                if (counts != null)
                {
                    int.TryParse(counts.ToString(), out totalRecords);
                }
                page.TotalRecords = totalRecords;
                string sql = page.GetRecordsSql(ref totalPages);
                page.TotalPages = totalPages;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, page.Parameters) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        page.ItemList.Add(new SaleFeePre
                        {
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            FeeDate = DataTypeHelper.GetDateTime(sdr["FeeDate"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TotalFeeAmt = DataTypeHelper.GetDouble(sdr["TotalFeeAmt"]),
                            ConfTime = DataTypeHelper.GetDateTime(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetInt(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTime(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetInt(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            SettleTime = DataTypeHelper.GetDateTime(sdr["SettleTime"]),
                            SettleUserID = DataTypeHelper.GetInt(sdr["SettleUserID"]),
                            SettleUserName = DataTypeHelper.GetString(sdr["SettleUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null)
                        });
                    }
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.GetPageList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return page;
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            try
            {
                IDbDataParameter[] parameters = null;
                string sql = new FieldUpdater().UpdateField(fieldList, whereConditionList, tableName, ref parameters);
                result = helper.ExecNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.UpdateField",
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


        #region 构建Where条件
        /// <summary>
        /// 构建Where条件
        /// </summary>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>where 条件</returns>
        string CreateCondition(IDictionary<string, object> conditionDict, ref IList<IDbDataParameter> parameters)
        {
            StringBuilder where = new StringBuilder(" 1=1 ");
            IList<WhereCondition> whereConditionList = new List<WhereCondition>();//TODO
            string result = new WhereCondition().GetWhereCondition(whereConditionList, ref parameters);
            where.Append(result);
            return Regex.Replace(where.ToString(), "^ AND ", string.Empty);
        }
        #endregion


        #region 构建Sort条件
        /// <summary>
        /// 构建Sort条件
        /// </summary>
        /// <param name="page">分页辅助类</param>
        string CreateOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return "FeeID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleFeePre列表
        /// <summary>
        /// 根据条件获取SaleFeePre列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<SaleFeePre> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleFeePre> list = new List<SaleFeePre>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new SaleFeePre
                        {
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            FeeDate = DataTypeHelper.GetDateTime(sdr["FeeDate"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TotalFeeAmt = DataTypeHelper.GetDouble(sdr["TotalFeeAmt"]),
                            ConfTime = DataTypeHelper.GetDateTime(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetInt(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTime(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetInt(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            SettleTime = DataTypeHelper.GetDateTime(sdr["SettleTime"]),
                            SettleUserID = DataTypeHelper.GetInt(sdr["SettleUserID"]),
                            SettleUserName = DataTypeHelper.GetString(sdr["SettleUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null)
                        });
                    }
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePre.GetList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }
        #endregion

        #endregion


    }
}