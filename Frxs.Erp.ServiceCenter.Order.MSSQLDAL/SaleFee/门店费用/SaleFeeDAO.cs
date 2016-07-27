
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
    /// ### SaleFee数据库访问类
    /// </summary>
    public partial class SaleFeeDAO : BaseDAL, ISaleFeeDAO
    {

        public SaleFeeDAO(string warehouseId)
            : base(warehouseId)
        {

        }
        const string tableName = "SaleFee";



        #region 成员方法
        #region 根据主键验证SaleFee是否存在
        /// <summary>
        /// 根据主键验证SaleFee是否存在
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleFee model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.Exists",
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


        #region 添加一个SaleFee
        /// <summary>
        /// 添加一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleFee model)
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
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 64),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SettleUserID", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
 new SqlParameter("@FeeDate", SqlDbType.DateTime),
new SqlParameter("@SettleUserName", SqlDbType.VarChar, 64)

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
            sp[9].Value = model.ConfTime;
            sp[10].Value = model.ConfUserID;
            sp[11].Value = model.ConfUserName;
            sp[12].Value = model.PostingTime;
            sp[13].Value = model.PostingUserID;
            sp[14].Value = model.PostingUserName;
            sp[15].Value = model.SettleTime;
            sp[16].Value = model.SettleUserID;
            sp[17].Value = model.Remark;
            sp[18].Value = model.CreateTime;
            sp[19].Value = model.CreateUserID;
            sp[20].Value = model.CreateUserName;
            sp[21].Value = model.ModifyTime;
            sp[22].Value = model.ModifyUserID;
            sp[23].Value = model.ModifyUserName;
            sp[24].Value = model.FeeDate;
            sp[25].Value = model.SettleUserName;

            try
            {
                object o = helper.GetSingle(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.Save",
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


        #region 更新一个SaleFee


        /// <summary>
        /// 更新一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleFee model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.Edit",
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
        public int Edit(SaleFee model)
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
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
 new SqlParameter("@FeeDate", SqlDbType.DateTime),
new SqlParameter("@SettleUserName", SqlDbType.VarChar, 64)

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
            sp[16].Value = model.Remark;
            sp[17].Value = model.ModifyTime;
            sp[18].Value = model.ModifyUserID;
            sp[19].Value = model.ModifyUserName;
            sp[20].Value = model.FeeID;
            sp[21].Value = model.FeeDate;
            sp[22].Value = model.SettleUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.Edit",
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


        #region 删除一个SaleFee
        /// <summary>
        /// 删除一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleFee model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.Delete",
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


        #region 根据主键逻辑删除一个SaleFee
        /// <summary>
        /// 根据主键逻辑删除一个SaleFee
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.LogicDelete",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.LogicDelete",
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


        #region 根据字典获取SaleFee对象
        /// <summary>
        /// 根据字典获取SaleFee对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFee对象</returns>
        public SaleFee GetModel(IDictionary<string, object> conditionDict)
        {
            SaleFee model = null;
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
                IList<SaleFee> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取SaleFee对象
        /// <summary>
        /// 根据主键获取SaleFee对象
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>SaleFee对象</returns>
        public SaleFee GetModel(string feeID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleFee model = null;
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
                        model = new SaleFee
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
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            FeeDate = DataTypeHelper.GetDateTime(sdr["FeeDate"]),
                            SettleUserName = DataTypeHelper.GetString(sdr["SettleUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.GetModel",
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


        #region 根据字典获取SaleFee集合
        /// <summary>
        /// 根据字典获取SaleFee集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleFee> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleFee> list = null;
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


        #region 根据字典获取SaleFee数据集
        /// <summary>
        /// 根据字典获取SaleFee数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.GetDataSet",
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


        #region 分页获取SaleFee集合

        /// <summary>
        /// 分页获取SaleFee集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="totalAmt">总合计</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleFee> GetPageList(PageListBySql<SaleFee> page, IDictionary<string, object> conditionDict, out decimal totalAmt)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            totalAmt = 0.0m;
            try
            {
                page.TableName = "vSaleFee";
                page.Fields = "FeeID,FeeDate,WID,WCode,WName,SubWID,SubWCode,SubWName,Status,TotalFeeAmt,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,SettleTime,SettleUserID,SettleUserName,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);

                StringBuilder addWhere = new StringBuilder();

                if (conditionDict.ContainsKey("StartFeeDate"))
                {
                    page.Where = page.Where + string.Format(" and FeeDate >= '{0}'", conditionDict["StartFeeDate"]);
                }
                if (conditionDict.ContainsKey("EndFeeDate"))
                {
                    page.Where = page.Where + string.Format(" and FeeDate <= '{0}'", conditionDict["EndFeeDate"]);
                }

                addWhere.Append("  and Exists(select 1 from vSaleFeeDetails where vSaleFee.FeeID=vSaleFeeDetails.FeeID ");
                if (conditionDict.ContainsKey("ShopCode"))
                {
                    addWhere.AppendFormat(" and vSaleFeeDetails.ShopCode like '%{0}%' ", conditionDict["ShopCode"]);
                }
                if (conditionDict.ContainsKey("ShopName"))
                {
                    addWhere.AppendFormat("and vSaleFeeDetails.ShopName like'%{0}%' ", conditionDict["ShopName"]);
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

                //添加 总页面合计字段
                string getSumAmt = string.Format("SELECT SUM(TotalFeeAmt) FROM {0} Where {1};", page.TableName, page.Where);
                object SumAmt = helper.GetSingle(getSumAmt, page.Parameters);
                if (SumAmt != null)
                {
                    decimal.TryParse(SumAmt.ToString(), out totalAmt);
                }


                page.TotalRecords = totalRecords;
                string sql = page.GetRecordsSql(ref totalPages);
                page.TotalPages = totalPages;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, page.Parameters) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        page.ItemList.Add(new SaleFee
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.UpdateField",
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
            #region 构建查询

            if (conditionDict.ContainsKey("FeeID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "FeeID",
                        FieldValue = conditionDict["FeeID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("SubWID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "SubWID",
                        FieldValue = conditionDict["SubWID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }
            
            if (conditionDict.ContainsKey("ConfUserName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ConfUserName",
                        FieldValue = conditionDict["ConfUserName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 50
                    }
                });
            }



            if (conditionDict.ContainsKey("Status"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "Status",
                        FieldValue = conditionDict["Status"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

          

            #endregion

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


        #region 根据条件获取SaleFee列表
        /// <summary>
        /// 根据条件获取SaleFee列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<SaleFee> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleFee> list = new List<SaleFee>();
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
                        list.Add(new SaleFee
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFee.GetList",
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