
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
    /// ### SaleFeePreDetails数据库访问类
    /// </summary>
    public partial class SaleFeePreDetailsDAO : BaseDAL, ISaleFeePreDetailsDAO
    {

        public SaleFeePreDetailsDAO(string warehouseId)
            : base(warehouseId)
        {

        }
        const string tableName = "SaleFeePreDetails";


        #region 成员方法
        #region 根据主键验证SaleFeePreDetails是否存在
        /// <summary>
        /// 根据主键验证SaleFeePreDetails是否存在
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleFeePreDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.Exists",
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


        #region 添加一个SaleFeePreDetails
        /// <summary>
        /// 添加一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleFeePreDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@FeeCode", SqlDbType.Int),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Reason", SqlDbType.VarChar, 500),
new SqlParameter("@OrderId", SqlDbType.NVarChar, 50),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleID", SqlDbType.VarChar, 32),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.WID;
            sp[2].Value = model.FeeID;
            sp[3].Value = model.ShopID;
            sp[4].Value = model.ShopCode;
            sp[5].Value = model.ShopName;
            sp[6].Value = model.FeeCode;
            sp[7].Value = model.FeeName;
            sp[8].Value = model.Reason;
            sp[9].Value = model.OrderId;
            sp[10].Value = model.FeeAmt;
            sp[11].Value = model.SettleID;
            sp[12].Value = model.SettleTime;
            sp[13].Value = model.SerialNumber;
            sp[14].Value = model.ModifyTime;
            sp[15].Value = model.ModifyUserID;
            sp[16].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.Save",
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
        /// 添加一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleFeePreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@FeeCode", SqlDbType.Int),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Reason", SqlDbType.VarChar, 500),
new SqlParameter("@OrderId", SqlDbType.NVarChar, 50),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleID", SqlDbType.VarChar, 32),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.WID;
            sp[2].Value = model.FeeID;
            sp[3].Value = model.ShopID;
            sp[4].Value = model.ShopCode;
            sp[5].Value = model.ShopName;
            sp[6].Value = model.FeeCode;
            sp[7].Value = model.FeeName;
            sp[8].Value = model.Reason;
            sp[9].Value = model.OrderId;
            sp[10].Value = model.FeeAmt;
            sp[11].Value = model.SettleID;
            sp[12].Value = model.SettleTime;
            sp[13].Value = model.SerialNumber;
            sp[14].Value = model.ModifyTime;
            sp[15].Value = model.ModifyUserID;
            sp[16].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.Save",
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


        #region 更新一个SaleFeePreDetails
        /// <summary>
        /// 更新一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleFeePreDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@FeeCode", SqlDbType.Int),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Reason", SqlDbType.VarChar, 500),
new SqlParameter("@OrderId", SqlDbType.NVarChar, 50),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleID", SqlDbType.VarChar, 32),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.FeeID;
            sp[2].Value = model.ShopID;
            sp[3].Value = model.ShopCode;
            sp[4].Value = model.ShopName;
            sp[5].Value = model.FeeCode;
            sp[6].Value = model.FeeName;
            sp[7].Value = model.Reason;
            sp[8].Value = model.OrderId;
            sp[9].Value = model.FeeAmt;
            sp[10].Value = model.SettleID;
            sp[11].Value = model.SettleTime;
            sp[12].Value = model.SerialNumber;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.Edit",
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
        /// 更新一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleFeePreDetails model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@FeeCode", SqlDbType.Int),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Reason", SqlDbType.VarChar, 500),
new SqlParameter("@OrderId", SqlDbType.NVarChar, 50),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleID", SqlDbType.VarChar, 32),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.FeeID;
            sp[2].Value = model.ShopID;
            sp[3].Value = model.ShopCode;
            sp[4].Value = model.ShopName;
            sp[5].Value = model.FeeCode;
            sp[6].Value = model.FeeName;
            sp[7].Value = model.Reason;
            sp[8].Value = model.OrderId;
            sp[9].Value = model.FeeAmt;
            sp[10].Value = model.SettleID;
            sp[11].Value = model.SettleTime;
            sp[12].Value = model.SerialNumber;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.Edit",
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


        #region 删除一个SaleFeePreDetails
        /// <summary>
        /// 删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleFeePreDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 50)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.Delete",
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
        /// 删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="model">SaleFeePreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(string feeId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@FeeID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = feeId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.Delete",
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


        #region 根据主键逻辑删除一个SaleFeePreDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeePreDetails
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = iD;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.LogicDelete",
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


        #region 根据字典获取SaleFeePreDetails对象
        /// <summary>
        /// 根据字典获取SaleFeePreDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeePreDetails对象</returns>
        public SaleFeePreDetails GetModel(IDictionary<string, object> conditionDict)
        {
            SaleFeePreDetails model = null;
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
                IList<SaleFeePreDetails> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取SaleFeePreDetails对象
        /// <summary>
        /// 根据主键获取SaleFeePreDetails对象
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>SaleFeePreDetails对象</returns>
        public SaleFeePreDetails GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleFeePreDetails model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new SaleFeePreDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            FeeCode = DataTypeHelper.GetInt(sdr["FeeCode"]),
                            FeeName = DataTypeHelper.GetString(sdr["FeeName"], null),
                            Reason = DataTypeHelper.GetString(sdr["Reason"], null),
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            FeeAmt = DataTypeHelper.GetDouble(sdr["FeeAmt"]),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            SettleTime = DataTypeHelper.GetDateTime(sdr["SettleTime"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.GetModel",
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


        #region 根据字典获取SaleFeePreDetails集合
        /// <summary>
        /// 根据字典获取SaleFeePreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleFeePreDetails> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleFeePreDetails> list = null;
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


        #region 根据字典获取SaleFeePreDetails数据集
        /// <summary>
        /// 根据字典获取SaleFeePreDetails数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.GetDataSet",
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


        #region 分页获取SaleFeePreDetails集合
        /// <summary>
        /// 分页获取SaleFeePreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleFeePreDetails> GetPageList(PageListBySql<SaleFeePreDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = "vSaleFeeDetails";
                page.Fields = "ID,WID,FeeID,ShopID,ShopCode,ShopName,FeeCode,FeeName,Reason,OrderId,FeeAmt,SettleID,SettleTime,SerialNumber,ModifyTime,ModifyUserID,ModifyUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);
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
                        page.ItemList.Add(new SaleFeePreDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            FeeCode = DataTypeHelper.GetInt(sdr["FeeCode"]),
                            FeeName = DataTypeHelper.GetString(sdr["FeeName"], null),
                            Reason = DataTypeHelper.GetString(sdr["Reason"], null),
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            FeeAmt = DataTypeHelper.GetDouble(sdr["FeeAmt"]),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            SettleTime = DataTypeHelper.GetDateTime(sdr["SettleTime"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.UpdateField",
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
                return "ID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleFeePreDetails列表
        /// <summary>
        /// 根据条件获取SaleFeePreDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<SaleFeePreDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleFeePreDetails> list = new List<SaleFeePreDetails>();
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
                        list.Add(new SaleFeePreDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            FeeCode = DataTypeHelper.GetInt(sdr["FeeCode"]),
                            FeeName = DataTypeHelper.GetString(sdr["FeeName"], null),
                            Reason = DataTypeHelper.GetString(sdr["Reason"], null),
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            FeeAmt = DataTypeHelper.GetDouble(sdr["FeeAmt"]),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            SettleTime = DataTypeHelper.GetDateTime(sdr["SettleTime"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeePreDetails.GetList",
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