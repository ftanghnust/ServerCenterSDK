
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
    /// ### SaleFeeDetails数据库访问类
    /// </summary>
    public partial class SaleFeeDetailsDAO : BaseDAL, ISaleFeeDetailsDAO
    {
        public SaleFeeDetailsDAO(string warehouseId)
            : base(warehouseId)
        {

        }
        const string tableName = "SaleFeeDetails";



        #region 成员方法
        #region 根据主键验证SaleFeeDetails是否存在
        /// <summary>
        /// 根据主键验证SaleFeeDetails是否存在
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleFeeDetails model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.Exists",
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


        #region 添加一个SaleFeeDetails
        /// <summary>
        /// 添加一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleFeeDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@FeeCode", SqlDbType.Int),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Reason", SqlDbType.VarChar, 500),
new SqlParameter("@OrderId", SqlDbType.NVarChar, 50),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.WID;
            sp[2].Value = model.FeeID;
            sp[3].Value = model.SettleID;
            sp[4].Value = model.ShopID;
            sp[5].Value = model.ShopCode;
            sp[6].Value = model.ShopName;
            sp[7].Value = model.FeeCode;
            sp[8].Value = model.FeeName;
            sp[9].Value = model.Reason;
            sp[10].Value = model.OrderId;
            sp[11].Value = model.FeeAmt;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.Save",
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


        #region 更新一个SaleFeeDetails
        /// <summary>
        /// 更新一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleFeeDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@FeeID", SqlDbType.VarChar, 36),
new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@FeeCode", SqlDbType.Int),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Reason", SqlDbType.VarChar, 500),
new SqlParameter("@OrderId", SqlDbType.NVarChar, 50),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleTime", SqlDbType.DateTime),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.FeeID;
            sp[2].Value = model.SettleID;
            sp[3].Value = model.ShopID;
            sp[4].Value = model.ShopCode;
            sp[5].Value = model.ShopName;
            sp[6].Value = model.FeeCode;
            sp[7].Value = model.FeeName;
            sp[8].Value = model.Reason;
            sp[9].Value = model.OrderId;
            sp[10].Value = model.FeeAmt;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.Edit",
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


        #region 删除一个SaleFeeDetails
        /// <summary>
        /// 删除一个SaleFeeDetails
        /// </summary>
        /// <param name="model">SaleFeeDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleFeeDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.Delete",
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


        #region 根据主键逻辑删除一个SaleFeeDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleFeeDetails
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.LogicDelete",
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


        #region 根据字典获取SaleFeeDetails对象
        /// <summary>
        /// 根据字典获取SaleFeeDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFeeDetails对象</returns>
        public SaleFeeDetails GetModel(IDictionary<string, object> conditionDict)
        {
            SaleFeeDetails model = null;
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
                IList<SaleFeeDetails> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取SaleFeeDetails对象
        /// <summary>
        /// 根据主键获取SaleFeeDetails对象
        /// </summary>
        /// <param name="iD">主键ID(GUID)</param>
        /// <returns>SaleFeeDetails对象</returns>
        public SaleFeeDetails GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleFeeDetails model = null;
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
                        model = new SaleFeeDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            FeeCode = DataTypeHelper.GetInt(sdr["FeeCode"]),
                            FeeName = DataTypeHelper.GetString(sdr["FeeName"], null),
                            Reason = DataTypeHelper.GetString(sdr["Reason"], null),
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            FeeAmt = DataTypeHelper.GetDouble(sdr["FeeAmt"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.GetModel",
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


        #region 根据字典获取SaleFeeDetails集合
        /// <summary>
        /// 根据字典获取SaleFeeDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleFeeDetails> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleFeeDetails> list = null;
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


        #region 根据字典获取SaleFeeDetails数据集
        /// <summary>
        /// 根据字典获取SaleFeeDetails数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.GetDataSet",
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


        #region 分页获取SaleFeeDetails集合
        /// <summary>
        /// 分页获取SaleFeeDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleFeeDetails> GetPageList(PageListBySql<SaleFeeDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = "vSaleFeeDetails";
                page.Fields = "ID,WID,FeeID,SettleID,ShopID,ShopCode,ShopName,FeeCode,FeeName,Reason,OrderId,FeeAmt,SettleTime,SerialNumber,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new SaleFeeDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            FeeCode = DataTypeHelper.GetInt(sdr["FeeCode"]),
                            FeeName = DataTypeHelper.GetString(sdr["FeeName"], null),
                            Reason = DataTypeHelper.GetString(sdr["Reason"], null),
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            FeeAmt = DataTypeHelper.GetDouble(sdr["FeeAmt"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.UpdateField",
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


        #region 根据条件获取SaleFeeDetails列表
        /// <summary>
        /// 根据条件获取SaleFeeDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<SaleFeeDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleFeeDetails> list = new List<SaleFeeDetails>();
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
                        list.Add(new SaleFeeDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            FeeID = DataTypeHelper.GetString(sdr["FeeID"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            FeeCode = DataTypeHelper.GetInt(sdr["FeeCode"]),
                            FeeName = DataTypeHelper.GetString(sdr["FeeName"], null),
                            Reason = DataTypeHelper.GetString(sdr["Reason"], null),
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            FeeAmt = DataTypeHelper.GetDouble(sdr["FeeAmt"]),
                            SettleTime = DataTypeHelper.GetDateTimeNull(sdr["SettleTime"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleFeeDetails.GetList",
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