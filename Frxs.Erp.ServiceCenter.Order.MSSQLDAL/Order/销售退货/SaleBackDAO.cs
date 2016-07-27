
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
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
    /// ### SaleBack数据库访问类
    /// </summary>
    public partial class SaleBackDAO : BaseDAL, ISaleBackDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleBackDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleBackDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "SaleBack";

        #region 成员方法
        #region 根据主键验证SaleBack是否存在
        /// <summary>
        /// 根据主键验证SaleBack是否存在
        /// </summary>
        /// <param name="model">SaleBack对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleBack model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@BackID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.BackID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.Exists",
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


        #region 事务添加一个SaleBackPre
        /// <summary>
        /// 添加一个SaleBack
        /// </summary>
        /// <param name="model">SaleBack对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleBackPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@WCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@WName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@SubWID", SqlDbType.Int),
                                new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@BackDate", SqlDbType.DateTime, 3),
                                new SqlParameter("@XSUserID", SqlDbType.BigInt),
                                new SqlParameter("@ShopID", SqlDbType.Int),
                                new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
                                new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
                                new SqlParameter("@Status", SqlDbType.Int),
                                new SqlParameter("@TotalBackAmt", SqlDbType.Money),
                                new SqlParameter("@TotalBasePoint", SqlDbType.Money),
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
                                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                                new SqlParameter("@CreateUserID", SqlDbType.Int),
                                new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@TotalBackQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@TotalAddAmt", SqlDbType.Money),
                                new SqlParameter("@PayAmount", SqlDbType.Money)
                                };
            sp[0].Value = model.BackID;
            sp[1].Value = model.SettleID;
            sp[2].Value = model.WID;
            sp[3].Value = model.WCode;
            sp[4].Value = model.WName;
            sp[5].Value = model.SubWID;
            sp[6].Value = model.SubWCode;
            sp[7].Value = model.SubWName;
            sp[8].Value = model.BackDate;
            sp[9].Value = model.XSUserID;
            sp[10].Value = model.ShopID;
            sp[11].Value = model.ShopCode;
            sp[12].Value = model.ShopName;
            sp[13].Value = model.Status;
            sp[14].Value = model.TotalBackAmt;
            sp[15].Value = model.TotalBasePoint;
            sp[16].Value = model.ConfTime;
            sp[17].Value = model.ConfUserID;
            sp[18].Value = model.ConfUserName;
            sp[19].Value = model.PostingTime;
            sp[20].Value = model.PostingUserID;
            sp[21].Value = model.PostingUserName;
            sp[22].Value = model.SettleTime;
            sp[23].Value = model.SettleUserID;
            sp[24].Value = model.SettleUserName;
            sp[25].Value = model.Remark;
            sp[26].Value = model.CreateTime;
            sp[27].Value = model.CreateUserID;
            sp[28].Value = model.CreateUserName;
            sp[29].Value = model.ModifyTime;
            sp[30].Value = model.ModifyUserID;
            sp[31].Value = model.ModifyUserName;
            sp[32].Value = model.TotalBackQty;
            sp[33].Value = model.TotalAddAmt;
            sp[34].Value = model.PayAmount;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.Save",
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


        #region 更新一个SaleBack
        /// <summary>
        /// 更新一个SaleBack
        /// </summary>
        /// <param name="model">SaleBack对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleBack model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@BackDate", SqlDbType.DateTime, 3),
new SqlParameter("@XSUserID", SqlDbType.BigInt),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalBackAmt", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
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
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@BackID", SqlDbType.VarChar, 36)

};
            sp[0].Value = model.SettleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.SubWID;
            sp[5].Value = model.SubWCode;
            sp[6].Value = model.SubWName;
            sp[7].Value = model.BackDate;
            sp[8].Value = model.XSUserID;
            sp[9].Value = model.ShopID;
            sp[10].Value = model.ShopCode;
            sp[11].Value = model.ShopName;
            sp[12].Value = model.Status;
            sp[13].Value = model.TotalBackAmt;
            sp[14].Value = model.TotalBasePoint;
            sp[15].Value = model.ConfTime;
            sp[16].Value = model.ConfUserID;
            sp[17].Value = model.ConfUserName;
            sp[18].Value = model.PostingTime;
            sp[19].Value = model.PostingUserID;
            sp[20].Value = model.PostingUserName;
            sp[21].Value = model.SettleTime;
            sp[22].Value = model.SettleUserID;
            sp[23].Value = model.SettleUserName;
            sp[24].Value = model.Remark;
            sp[25].Value = model.ModifyTime;
            sp[26].Value = model.ModifyUserID;
            sp[27].Value = model.ModifyUserName;
            sp[28].Value = model.BackID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.Edit",
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


        #region 删除一个SaleBack
        /// <summary>
        /// 删除一个SaleBack
        /// </summary>
        /// <param name="model">SaleBack对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleBack model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@BackID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.BackID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.Delete",
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


        #region 根据主键逻辑删除一个SaleBack
        /// <summary>
        /// 根据主键逻辑删除一个SaleBack
        /// </summary>
        /// <param name="backID">退货单编号</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string backID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@BackID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = backID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.LogicDelete",
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


        #region 根据字典获取SaleBack对象
        /// <summary>
        /// 根据字典获取SaleBack对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleBack对象</returns>
        public SaleBack GetModel(IDictionary<string, object> conditionDict)
        {
            SaleBack model = null;
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
                IList<SaleBack> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取SaleBack对象
        /// <summary>
        /// 根据主键获取SaleBack对象
        /// </summary>
        /// <param name="backID">退货单编号</param>
        /// <returns>SaleBack对象</returns>
        public SaleBack GetModel(string backID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleBack model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@BackID", SqlDbType.VarChar, 36)
 };
                sp[0].Value = backID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new SaleBack
                        {
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            BackDate = DataTypeHelper.GetDateTime(sdr["BackDate"]),
                            XSUserID = DataTypeHelper.GetLong(sdr["XSUserID"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TotalBackAmt = DataTypeHelper.GetDecimal(sdr["TotalBackAmt"]),
                            TotalBasePoint = DataTypeHelper.GetDecimal(sdr["TotalBasePoint"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.GetModel",
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


        #region 根据字典获取SaleBack集合
        /// <summary>
        /// 根据字典获取SaleBack集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleBack> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleBack> list = null;
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


        #region 根据字典获取SaleBack数据集
        /// <summary>
        /// 根据字典获取SaleBack数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.GetDataSet",
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


        #region 分页获取SaleBack集合
        /// <summary>
        /// 分页获取SaleBack集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleBack> GetPageList(PageListBySql<SaleBack> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "BackID,SettleID,WID,WCode,WName,SubWID,SubWCode,SubWName,BackDate,XSUserID,ShopID,ShopCode,ShopName,Status,TotalBackAmt,TotalPoint,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,SettleTime,SettleUserID,SettleUserName,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new SaleBack
                        {
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            BackDate = DataTypeHelper.GetDateTime(sdr["BackDate"]),
                            XSUserID = DataTypeHelper.GetLong(sdr["XSUserID"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TotalBackAmt = DataTypeHelper.GetDecimal(sdr["TotalBackAmt"]),
                            TotalBasePoint = DataTypeHelper.GetDecimal(sdr["TotalBasePoint"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.UpdateField",
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
                return "BackID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleBack列表
        /// <summary>
        /// 根据条件获取SaleBack列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<SaleBack> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleBack> list = new List<SaleBack>();
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
                        list.Add(new SaleBack
                        {
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            BackDate = DataTypeHelper.GetDateTime(sdr["BackDate"]),
                            XSUserID = DataTypeHelper.GetLong(sdr["XSUserID"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TotalBackAmt = DataTypeHelper.GetDecimal(sdr["TotalBackAmt"]),
                            TotalBasePoint = DataTypeHelper.GetDecimal(sdr["TotalBasePoint"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBack.GetList",
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