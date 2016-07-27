
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
using Frxs.Platform.Utility;


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### SaleBackPre数据库访问类
    /// </summary>
    public partial class SaleBackPreDAO : BaseDAL, ISaleBackPreDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleBackPreDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleBackPreDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "SaleBackPre";

        #region 成员方法



        #region 事务添加一个SaleBackPre
        /// <summary>
        /// 添加一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleBackPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@WCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@WName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@SubWID", SqlDbType.Int),
                                new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@BackDate", SqlDbType.DateTime),
                                new SqlParameter("@XSUserID", SqlDbType.BigInt),
                                new SqlParameter("@ShopID", SqlDbType.Int),
                                new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
                                new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
                                new SqlParameter("@Status", SqlDbType.Int),
                                new SqlParameter("@TotalBackAmt", SqlDbType.Money),
                                new SqlParameter("@TotalBasePoint", SqlDbType.Money),
                                new SqlParameter("@ConfUserID", SqlDbType.Int),
                                new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@PostingUserID", SqlDbType.Int),
                                new SqlParameter("@PostingUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@SettleUserID", SqlDbType.Int),
                                new SqlParameter("@SettleUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
                                new SqlParameter("@CreateUserID", SqlDbType.Int),
                                new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@ConfTime", SqlDbType.DateTime),
                                new SqlParameter("@PostingTime", SqlDbType.DateTime),
                                new SqlParameter("@SettleTime", SqlDbType.DateTime),
                                new SqlParameter("@TotalBackQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@TotalAddAmt", SqlDbType.Money),
                                new SqlParameter("@PayAmount", SqlDbType.Money),
                                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime)

                                };
            sp[0].Value = model.BackID;
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
            sp[15].Value = model.ConfUserID;
            sp[16].Value = model.ConfUserName;
            sp[17].Value = model.PostingUserID;
            sp[18].Value = model.PostingUserName;
            sp[19].Value = model.SettleUserID;
            sp[20].Value = model.SettleUserName;
            sp[21].Value = model.SettleID;
            sp[22].Value = model.Remark;
            sp[23].Value = model.CreateUserID;
            sp[24].Value = model.CreateUserName;
            sp[25].Value = model.ModifyUserID;
            sp[26].Value = model.ModifyUserName;
            sp[27].Value = model.ConfTime;
            sp[28].Value = model.PostingTime;
            sp[29].Value = model.SettleTime;
            sp[30].Value = model.TotalBackQty;
            sp[31].Value = model.TotalAddAmt;
            sp[32].Value = model.PayAmount;
            sp[33].Value = model.CreateTime;
            sp[34].Value = model.ModifyTime;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackPre.Save",
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


        #region 事务更新一个SaleBackPre
        /// <summary>
        /// 更新一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleBackPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@BackDate", SqlDbType.DateTime, 3),
                                new SqlParameter("@XSUserID", SqlDbType.BigInt),
                                new SqlParameter("@ShopID", SqlDbType.Int),
                                new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
                                new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
                                new SqlParameter("@TotalBackAmt", SqlDbType.Money),
                                new SqlParameter("@TotalBasePoint", SqlDbType.Money),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@TotalBackQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@TotalAddAmt", SqlDbType.Money),
                                new SqlParameter("@PayAmount", SqlDbType.Money),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime)
                                };

            sp[0].Value = model.BackDate;
            sp[1].Value = model.XSUserID;
            sp[2].Value = model.ShopID;
            sp[3].Value = model.ShopCode;
            sp[4].Value = model.ShopName;
            sp[5].Value = model.TotalBackAmt;
            sp[6].Value = model.TotalBasePoint;
            sp[7].Value = model.Remark;
            sp[8].Value = model.ModifyUserID;
            sp[9].Value = model.ModifyUserName;
            sp[10].Value = model.BackID;
            sp[11].Value = model.TotalBackQty;
            sp[12].Value = model.TotalAddAmt;
            sp[13].Value = model.PayAmount;
            sp[14].Value = model.ModifyTime;

            try
            {
                if (conn == null && tran == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackPre.Edit",
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

        #region √更新一个SaleBackPre(更改状态使用)
        /// <summary>
        /// 更新一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int EditInChange(SaleBackPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditInChange", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@Status", SqlDbType.Int),
                                new SqlParameter("@ConfTime", SqlDbType.DateTime),
                                new SqlParameter("@ConfUserID", SqlDbType.Int),
                                new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime)
                                };

            sp[0].Value = model.BackID;
            sp[1].Value = model.Status;
            sp[2].Value = model.ConfTime;
            sp[3].Value = model.ConfUserID;
            sp[4].Value = model.ConfUserName;
            sp[5].Value = model.ModifyUserID;
            sp[6].Value = model.ModifyUserName;
            sp[7].Value = model.ModifyTime;
            try
            {
                if (conn == null && tran == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackPreDAO.EditInChange",
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


        #region 事务删除一个SaleBackPre
        /// <summary>
        /// 删除一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleBackPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = { new SqlParameter("@BackID", SqlDbType.VarChar, 36) };
            sp[0].Value = model.BackID;

            try
            {
                if (conn == null && tran == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackPre.Delete",
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



        #region 根据字典获取SaleBackPre对象
        /// <summary>
        /// 根据字典获取SaleBackPre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleBackPre对象</returns>
        public SaleBackPre GetModel(IDictionary<string, object> conditionDict)
        {
            SaleBackPre model = null;
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
                IList<SaleBackPre> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取SaleBackPre对象
        /// <summary>
        /// 根据主键获取SaleBackPre对象
        /// </summary>
        /// <param name="backID">退货单编号</param>
        /// <returns>SaleBackPre对象</returns>
        public SaleBackPre GetModel(string backID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleBackPre model = null;
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
                        model = new SaleBackPre
                        {
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
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
                            TotalBackQty = DataTypeHelper.GetDecimal(sdr["TotalBackQty"]),
                            TotalAddAmt = DataTypeHelper.GetDecimal(sdr["TotalAddAmt"]),
                            PayAmount = DataTypeHelper.GetDecimal(sdr["PayAmount"]),

                            ConfTime = (!string.IsNullOrEmpty(sdr["ConfTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["ConfTime"]) : (DateTime?)null,
                            ConfUserID = DataTypeHelper.GetInt(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = (!string.IsNullOrEmpty(sdr["PostingTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["PostingTime"]) : (DateTime?)null,
                            PostingUserID = DataTypeHelper.GetInt(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            SettleTime = (!string.IsNullOrEmpty(sdr["SettleTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["SettleTime"]) : (DateTime?)null,
                            SettleUserID = DataTypeHelper.GetInt(sdr["SettleUserID"]),
                            SettleUserName = DataTypeHelper.GetString(sdr["SettleUserName"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackPre.GetModel",
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


        #region 根据字典获取SaleBackPre集合
        /// <summary>
        /// 根据字典获取SaleBackPre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleBackPre> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleBackPre> list = null;
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


        #region 根据字典获取SaleBackPre数据集
        /// <summary>
        /// 根据字典获取SaleBackPre数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackPre.GetDataSet",
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


        #region 分页获取SaleBackPre集合
        /// <summary>
        /// 分页获取SaleBackPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleBackPre> GetPageList(PageListBySql<SaleBackPre> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Query", base.AssemblyName, base.DatabaseName);
                page.Fields = "BackID,WID,WCode,WName,SubWID,SubWCode,SubWName,BackDate,XSUserID,ShopID,ShopCode,ShopName,Status,TotalBackAmt,TotalBasePoint,TotalAddAmt,PayAmount,TotalBackQty,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,SettleTime,SettleUserID,SettleUserName,SettleID,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                if (page.PageIndex > 1 && page.PageSize > totalRecords)
                {
                    page.PageIndex = 1;
                }
                page.TotalRecords = totalRecords;
                string sql = page.GetRecordsSql(ref totalPages);
                page.TotalPages = totalPages;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, page.Parameters) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        page.ItemList.Add(new SaleBackPre
                        {
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
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
                            TotalBackQty = DataTypeHelper.GetDecimal(sdr["TotalBackQty"]),
                            StatusStr = ConvertStatusToString(DataTypeHelper.GetInt(sdr["Status"])),
                            TotalBackAmt = DataTypeHelper.GetDecimal(sdr["TotalBackAmt"]),
                            TotalBasePoint = DataTypeHelper.GetDecimal(sdr["TotalBasePoint"]),
                            TotalAddAmt = DataTypeHelper.GetDecimal(sdr["TotalAddAmt"]),
                            PayAmount = DataTypeHelper.GetDecimal(sdr["PayAmount"]),
                            ConfTime = (!string.IsNullOrEmpty(sdr["ConfTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["ConfTime"]) : (DateTime?)null,
                            ConfUserID = DataTypeHelper.GetInt(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = (!string.IsNullOrEmpty(sdr["PostingTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["PostingTime"]) : (DateTime?)null,
                            PostingUserID = DataTypeHelper.GetInt(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            SettleTime = (!string.IsNullOrEmpty(sdr["SettleTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["SettleTime"]) : (DateTime?)null,
                            SettleUserID = DataTypeHelper.GetInt(sdr["SettleUserID"]),
                            SettleUserName = DataTypeHelper.GetString(sdr["SettleUserName"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackPre.GetPageList",
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

        /// <summary>
        /// 将订单类型转为字符
        /// </summary>
        /// <param name="orderStatus">订单类型</param>
        /// <returns></returns>
        public static string ConvertStatusToString(int orderStatus)
        {
            switch (orderStatus)
            {
                case 0:
                    return "录单";
                case 1:
                    return "确认";
                case 2:
                    return "过账";
                case 3:
                    return "结算";
                default:
                    return "交易状态不明";
            }
        }

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
            parameters = new List<IDbDataParameter>();

            if (conditionDict.ContainsKey("WID"))
            {
                where.Append(@" And WID=@WID ");
                parameters.Add(new SqlParameter() { ParameterName = "@WID ", SqlDbType = SqlDbType.Int, Value = conditionDict["WID"] });
            }

            if (conditionDict.ContainsKey("SubWID"))
            {
                where.Append(string.Format(@" And SubWID=@SubWID "));
                parameters.Add(new SqlParameter() { ParameterName = "@SubWID", SqlDbType = SqlDbType.Int, Value = conditionDict["SubWID"] });
            }

            if (conditionDict.ContainsKey("BackID"))
            {
                where.Append(string.Format(@" And BackID like @BackID ", conditionDict["BackID"]));
                parameters.Add(new SqlParameter() { ParameterName = "@BackID", SqlDbType = SqlDbType.VarChar, Value = "%" + conditionDict["BackID"] + "%" });
            }

            if (conditionDict.ContainsKey("Status"))
            {
                where.Append(string.Format(@" And Status = @Status "));
                parameters.Add(new SqlParameter() { ParameterName = "@Status", SqlDbType = SqlDbType.Int, Value = conditionDict["Status"] });
            }

            if (conditionDict.ContainsKey("OrderDateBegin") && !conditionDict.ContainsKey("OrderDateEnd"))
            {
                where.Append(string.Format(@" And BackDate >= @OrderDateBegin "));
                parameters.Add(new SqlParameter() { ParameterName = "@OrderDateBegin", SqlDbType = SqlDbType.DateTime, Value = conditionDict["OrderDateBegin"] });
            }

            if (!conditionDict.ContainsKey("OrderDateBegin") && conditionDict.ContainsKey("OrderDateEnd"))
            {
                where.Append(string.Format(@" And BackDate <= @OrderDateEnd "));
                parameters.Add(new SqlParameter() { ParameterName = "@OrderDateEnd", SqlDbType = SqlDbType.DateTime, Value = conditionDict["OrderDateEnd"] });
            }

            if (conditionDict.ContainsKey("OrderDateBegin") && conditionDict.ContainsKey("OrderDateEnd"))
            {
                where.Append(string.Format(@" And BackDate >= @OrderDateBegin And BackDate <= @OrderDateEnd "));
                parameters.Add(new SqlParameter() { ParameterName = "@OrderDateBegin", SqlDbType = SqlDbType.DateTime, Value = conditionDict["OrderDateBegin"] });
                parameters.Add(new SqlParameter() { ParameterName = "@OrderDateEnd", SqlDbType = SqlDbType.DateTime, Value = conditionDict["OrderDateEnd"] });
            }

            if (conditionDict.ContainsKey("ShopCode"))
            {
                where.Append(string.Format(@" And ShopCode like @ShopCode "));
                parameters.Add(new SqlParameter() { ParameterName = "@ShopCode", SqlDbType = SqlDbType.VarChar, Value = "%" + conditionDict["ShopCode"] + "%" });
            }
            if (conditionDict.ContainsKey("ShopName"))
            {
                where.Append(string.Format(@" And ShopName like @ShopName "));
                parameters.Add(new SqlParameter() { ParameterName = "@ShopName", SqlDbType = SqlDbType.VarChar, Value = "%" + conditionDict["ShopName"] + "%" });
            }
            if (conditionDict.ContainsKey("Remark"))
            {
                where.Append(string.Format(@" And Remark like @Remark "));
                parameters.Add(new SqlParameter() { ParameterName = "@Remark", SqlDbType = SqlDbType.NVarChar, Value = "%" + conditionDict["Remark"] + "%" });
            }
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


        #region 根据条件获取SaleBackPre列表
        /// <summary>
        /// 根据条件获取SaleBackPre列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<SaleBackPre> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleBackPre> list = new List<SaleBackPre>();
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
                        list.Add(new SaleBackPre
                        {
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
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
                            TotalAddAmt = DataTypeHelper.GetDecimal(sdr["TotalAddAmt"]),
                            PayAmount = DataTypeHelper.GetDecimal(sdr["PayAmount"]),
                            ConfTime = (!string.IsNullOrEmpty(sdr["ConfTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["ConfTime"]) : (DateTime?)null,
                            ConfUserID = DataTypeHelper.GetInt(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = (!string.IsNullOrEmpty(sdr["PostingTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["PostingTime"]) : (DateTime?)null,
                            PostingUserID = DataTypeHelper.GetInt(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            SettleTime = (!string.IsNullOrEmpty(sdr["SettleTime"].ToString())) ? DataTypeHelper.GetDateTime(sdr["SettleTime"]) : (DateTime?)null,
                            SettleUserID = DataTypeHelper.GetInt(sdr["SettleUserID"]),
                            SettleUserName = DataTypeHelper.GetString(sdr["SettleUserName"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackPre.GetList",
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

        //重载获取链接方法
        public override IDbConnection GetConnection()
        {
            if (!string.IsNullOrWhiteSpace(base.ConnectionString))
            {
                return new SqlConnection(base.ConnectionString);
            }
            else
            {
                return base.GetConnection();
            }
        }
    }
}