
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
using Frxs.Platform.Utility;


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### BuyOrderPre数据库访问类
    /// </summary>
    public partial class BuyOrderPreDAO : BaseDAL, IBuyOrderPreDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BuyOrderPreDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BuyOrderPreDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "BuyOrderPre";

        #region √根据主键验证BuyOrderPre是否存在
        /// <summary>
        /// 根据主键验证BuyOrderPre是否存在
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(BuyOrderPre model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = { new SqlParameter("@BuyID", SqlDbType.VarChar, 36) };
            sp[0].Value = model.BuyID;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.Exists",
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

        #region √添加一个BuyOrderPre
        /// <summary>
        /// 添加一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(BuyOrderPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@BuyID", SqlDbType.VarChar, 36),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@SubWID", SqlDbType.Int),
                                new SqlParameter("@PreBuyID", SqlDbType.VarChar, 36),
                                new SqlParameter("@OrderDate", SqlDbType.DateTime),
                                new SqlParameter("@WCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@WName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@BuyEmpID", SqlDbType.Int),
                                new SqlParameter("@BuyEmpName", SqlDbType.VarChar, 32),
                                new SqlParameter("@VendorID", SqlDbType.Int),
                                new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@Status", SqlDbType.Int),
                                new SqlParameter("@TotalOrderAmt", SqlDbType.Money),
                                new SqlParameter("@ConfUserID", SqlDbType.Int),
                                new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@PostingUserID", SqlDbType.Int),
                                new SqlParameter("@PostingUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@SettleUserID", SqlDbType.Int),
                                new SqlParameter("@SettleUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@SettleID", SqlDbType.VarChar, 50),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
                                new SqlParameter("@CreateUserID", SqlDbType.Int),
                                new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@ConfTime", SqlDbType.DateTime),
                                new SqlParameter("@PostingTime", SqlDbType.DateTime),
                                new SqlParameter("@SettleTime", SqlDbType.DateTime),
                                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime)
                                };
            sp[0].Value = model.BuyID;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            sp[3].Value = model.PreBuyID;
            sp[4].Value = model.OrderDate;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.SubWCode;
            sp[8].Value = model.SubWName;
            sp[9].Value = model.BuyEmpID;
            sp[10].Value = model.BuyEmpName;
            sp[11].Value = model.VendorID;
            sp[12].Value = model.VendorCode;
            sp[13].Value = model.VendorName;
            sp[14].Value = model.Status;
            sp[15].Value = model.TotalOrderAmt;
            sp[16].Value = model.ConfUserID;
            sp[17].Value = model.ConfUserName;
            sp[18].Value = model.PostingUserID;
            sp[19].Value = model.PostingUserName;
            sp[20].Value = model.SettleUserID;
            sp[21].Value = model.SettleUserName;
            sp[22].Value = model.SettleID;
            sp[23].Value = model.Remark;
            sp[24].Value = model.CreateUserID;
            sp[25].Value = model.CreateUserName;
            sp[26].Value = model.ModifyUserID;
            sp[27].Value = model.ModifyUserName;
            sp[28].Value = model.ConfTime;
            sp[29].Value = model.PostingTime;
            sp[30].Value = model.SettleTime;
            sp[31].Value = model.CreateTime;
            sp[32].Value = model.ModifyTime;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.Save",
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

        #region √根据主键获取BuyOrderPre对象
        /// <summary>
        /// 根据主键获取BuyOrderPre对象
        /// </summary>
        /// <param name="buyID">采购单编号</param>
        /// <returns>BuyOrderPre对象</returns>
        public BuyOrderPre GetModel(string buyID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            BuyOrderPre model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = { new SqlParameter("@BuyID", SqlDbType.VarChar, 36) };
                sp[0].Value = buyID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new BuyOrderPre
                        {
                            BuyID = DataTypeHelper.GetString(sdr["BuyID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            PreBuyID = DataTypeHelper.GetString(sdr["PreBuyID"], null),
                            OrderDate = DataTypeHelper.GetDateTime(sdr["OrderDate"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            BuyEmpID = DataTypeHelper.GetInt(sdr["BuyEmpID"]),
                            BuyEmpName = DataTypeHelper.GetString(sdr["BuyEmpName"], null),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            VendorCode = DataTypeHelper.GetString(sdr["VendorCode"], null),
                            VendorName = DataTypeHelper.GetString(sdr["VendorName"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TotalOrderAmt = DataTypeHelper.GetDouble(sdr["TotalOrderAmt"]),
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
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.GetModel",
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

        #region √更新一个BuyOrderPre
        /// <summary>
        /// 更新一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(BuyOrderPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@OrderDate", SqlDbType.DateTime),
                                new SqlParameter("@BuyEmpID", SqlDbType.Int),
                                new SqlParameter("@BuyEmpName", SqlDbType.VarChar, 32),
                                new SqlParameter("@VendorID", SqlDbType.Int),
                                new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
                                new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
                                new SqlParameter("@TotalOrderAmt", SqlDbType.Money),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
                                new SqlParameter("@BuyID", SqlDbType.VarChar, 36),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime)

                                };

            sp[0].Value = model.OrderDate;
            sp[1].Value = model.BuyEmpID;
            sp[2].Value = model.BuyEmpName;
            sp[3].Value = model.VendorID;
            sp[4].Value = model.VendorCode;
            sp[5].Value = model.VendorName;
            sp[6].Value = model.TotalOrderAmt;
            sp[7].Value = model.ModifyUserID;
            sp[8].Value = model.ModifyUserName;
            sp[9].Value = model.Remark;
            sp[10].Value = model.BuyID;
            sp[11].Value = model.ModifyTime;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.Edit",
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

        #region √更新一个BuyOrderPre(更改状态使用)
        /// <summary>
        /// 更新一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int EditInChange(BuyOrderPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditInChange", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@BuyID", SqlDbType.VarChar, 36),
                                new SqlParameter("@Status", SqlDbType.Int),
                                new SqlParameter("@ConfTime", SqlDbType.DateTime),
                                new SqlParameter("@ConfUserID", SqlDbType.Int),
                                new SqlParameter("@ConfUserName", SqlDbType.VarChar, 64),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime)
                                };

            sp[0].Value = model.BuyID;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.EditInChange",
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

        #region √删除一个BuyOrderPre
        /// <summary>
        /// 删除一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(BuyOrderPre model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = { new SqlParameter("@BuyID", SqlDbType.VarChar, 36) };
            sp[0].Value = model.BuyID;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.Delete",
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

        #region √分页获取BuyOrderPre集合
        /// <summary>
        /// 分页获取BuyOrderPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public BuyOrderPageModel GetPageList(BuyOrderPageModel pagemodel, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            decimal totalAmt = 0.0m;
            PageListBySql<BuyOrderPre> page = pagemodel.pageModel;
            try
            {
                page.TableName = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Query", base.AssemblyName, base.DatabaseName);
                page.Fields = "BuyID,WID,OrderDate,WName,SubWCode,SubWName,VendorName,VendorCode,Status,TotalOrderAmt,BuyEmpName,Remark";
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
                //获取所有订单金额总计
                StringBuilder tempSql = new StringBuilder();
                tempSql.AppendFormat("SELECT {0} FROM {1}", page.Fields, page.TableName);
                if (!string.IsNullOrWhiteSpace(page.Where))
                {
                    tempSql.Append(" WHERE " + page.Where);
                }
                string getSumAmt = string.Format("SELECT SUM(TotalOrderAmt) FROM ({0}) AS TMP;", tempSql);
                object SumAmt = helper.GetSingle(getSumAmt, page.Parameters);
                if (SumAmt != null)
                {
                    decimal.TryParse(SumAmt.ToString(), out totalAmt);
                }
                pagemodel.SubAmt = totalAmt;
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
                        page.ItemList.Add(new BuyOrderPre
                        {
                            BuyID = DataTypeHelper.GetString(sdr["BuyID"], null),
                            OrderDate = DataTypeHelper.GetDateTime(sdr["OrderDate"]),
                            WNameStr = string.Format("【{0}】 {1}_{2}", DataTypeHelper.GetString(sdr["SubWCode"], ""), DataTypeHelper.GetString(sdr["WName"], ""), DataTypeHelper.GetString(sdr["SubWName"], "")),
                            VendorName = DataTypeHelper.GetString(sdr["VendorName"], null),
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 1 ? ConstDefinition.ERP_Order_Status_CONF : (DataTypeHelper.GetInt(sdr["Status"]) == 0 ? ConstDefinition.ERP_Order_Status_RECORDED : ConstDefinition.ERP_Order_Status_POSTING),
                            TotalOrderAmt = DataTypeHelper.GetDouble(sdr["TotalOrderAmt"]),
                            BuyEmpName = DataTypeHelper.GetString(sdr["BuyEmpName"], null),
                            VendorCode = DataTypeHelper.GetString(sdr["VendorCode"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BuyOrderPre.GetPageList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return pagemodel;
        }
        #endregion

        #region √构建Where条件
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

            if (conditionDict.ContainsKey("BuyID"))
            {
                where.Append(string.Format(@" And BuyID like @BuyID ", conditionDict["BuyID"]));
                parameters.Add(new SqlParameter() { ParameterName = "@BuyID", SqlDbType = SqlDbType.VarChar, Value = "%" + conditionDict["BuyID"] + "%" });
            }

            if (conditionDict.ContainsKey("Status"))
            {
                where.Append(string.Format(@" And Status = @Status "));
                parameters.Add(new SqlParameter() { ParameterName = "@Status", SqlDbType = SqlDbType.Int, Value = conditionDict["Status"] });
            }

            if (conditionDict.ContainsKey("OrderDateBegin") && !conditionDict.ContainsKey("OrderDateEnd"))
            {
                where.Append(string.Format(@" And OrderDate >= @OrderDateBegin "));
                parameters.Add(new SqlParameter() { ParameterName = "@OrderDateBegin", SqlDbType = SqlDbType.DateTime, Value = conditionDict["OrderDateBegin"] });
            }

            if (!conditionDict.ContainsKey("OrderDateBegin") && conditionDict.ContainsKey("OrderDateEnd"))
            {
                where.Append(string.Format(@" And OrderDate <= @OrderDateEnd "));
                parameters.Add(new SqlParameter() { ParameterName = "@OrderDateEnd", SqlDbType = SqlDbType.DateTime, Value = conditionDict["OrderDateEnd"] });
            }

            if (conditionDict.ContainsKey("OrderDateBegin") && conditionDict.ContainsKey("OrderDateEnd"))
            {
                where.Append(string.Format(@" And OrderDate >= @OrderDateBegin And OrderDate <= @OrderDateEnd "));
                parameters.Add(new SqlParameter() { ParameterName = "@OrderDateBegin", SqlDbType = SqlDbType.DateTime, Value = conditionDict["OrderDateBegin"] });
                parameters.Add(new SqlParameter() { ParameterName = "@OrderDateEnd", SqlDbType = SqlDbType.DateTime, Value = conditionDict["OrderDateEnd"] });
            }

            if (conditionDict.ContainsKey("VendorCodeOrName"))
            {
                where.Append(string.Format(@" And (VendorCode like @VendorCodeOrName or VendorName like @VendorCodeOrName) "));
                parameters.Add(new SqlParameter() { ParameterName = "@VendorCodeOrName", SqlDbType = SqlDbType.VarChar, Value = "%" + conditionDict["VendorCodeOrName"] + "%" });
            }

            if (conditionDict.ContainsKey("SKU"))
            {
                where.Append(string.Format(@"  And Exists (SELECT  1 FROM BuyOrderPreDetails b where a.BuyID=b.BuyID and SKU like @SKU  union SELECT  1 FROM BuyOrderDetails c where a.BuyID=c.BuyID and SKU like @SKU)"));
                parameters.Add(new SqlParameter() { ParameterName = "@SKU", SqlDbType = SqlDbType.VarChar, Value = "%" + conditionDict["SKU"] + "%" });
            }
            if (conditionDict.ContainsKey("ProductName"))
            {
                where.Append(string.Format(@" And Exists (SELECT  1 FROM BuyOrderPreDetails b where a.BuyID=b.BuyID and ProductName like @ProductName union SELECT  1 FROM BuyOrderDetails c where a.BuyID=c.BuyID and ProductName like @ProductName) "));
                parameters.Add(new SqlParameter() { ParameterName = "@ProductName", SqlDbType = SqlDbType.VarChar, Value = "%" + conditionDict["ProductName"] + "%" });
            }

            if(conditionDict.ContainsKey("Remark"))
            {
                where.Append(string.Format(@" And Remark like @Remark "));
                parameters.Add(new SqlParameter() { ParameterName = "@Remark", SqlDbType = SqlDbType.NVarChar, Value = "%" + conditionDict["Remark"] + "%" });
            }
            return Regex.Replace(where.ToString(), "^ AND ", string.Empty);
        }
        #endregion

        #region √构建Sort条件
        /// <summary>
        /// 构建Sort条件
        /// </summary>
        /// <param name="page">分页辅助类</param>
        string CreateOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return "BuyID";
            }
            else
            {
                return order;
            }
        }
        #endregion

        #region 成员方法

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.UpdateField",
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


        #region 根据主键逻辑删除一个BuyOrderPre
        /// <summary>
        /// 根据主键逻辑删除一个BuyOrderPre
        /// </summary>
        /// <param name="buyID">采购单编号</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string buyID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = { new SqlParameter("@BuyID", SqlDbType.VarChar, 36) };
            sp[0].Value = buyID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.LogicDelete",
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


        #region 根据字典获取BuyOrderPre对象
        /// <summary>
        /// 根据字典获取BuyOrderPre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BuyOrderPre对象</returns>
        public BuyOrderPre GetModel(IDictionary<string, object> conditionDict)
        {
            BuyOrderPre model = null;
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
                IList<BuyOrderPre> list = GetList(where.ToString(), sp);
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


        #region 根据字典获取BuyOrderPre集合
        /// <summary>
        /// 根据字典获取BuyOrderPre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<BuyOrderPre> GetList(IDictionary<string, object> conditionDict)
        {
            IList<BuyOrderPre> list = null;
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


        #region 根据字典获取BuyOrderPre数据集
        /// <summary>
        /// 根据字典获取BuyOrderPre数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.GetDataSet",
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


        #region 根据条件获取BuyOrderPre列表
        /// <summary>
        /// 根据条件获取BuyOrderPre列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<BuyOrderPre> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<BuyOrderPre> list = new List<BuyOrderPre>();
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
                        list.Add(new BuyOrderPre
                        {
                            BuyID = DataTypeHelper.GetString(sdr["BuyID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            PreBuyID = DataTypeHelper.GetString(sdr["PreBuyID"], null),
                            OrderDate = DataTypeHelper.GetDateTime(sdr["OrderDate"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            BuyEmpID = DataTypeHelper.GetInt(sdr["BuyEmpID"]),
                            BuyEmpName = DataTypeHelper.GetString(sdr["BuyEmpName"], null),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            VendorCode = DataTypeHelper.GetString(sdr["VendorCode"], null),
                            VendorName = DataTypeHelper.GetString(sdr["VendorName"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TotalOrderAmt = DataTypeHelper.GetDouble(sdr["TotalOrderAmt"]),
                            ConfTime = DataTypeHelper.GetDateTime(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetInt(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTime(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetInt(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            SettleTime = DataTypeHelper.GetDateTime(sdr["SettleTime"]),
                            SettleUserID = DataTypeHelper.GetInt(sdr["SettleUserID"]),
                            SettleUserName = DataTypeHelper.GetString(sdr["SettleUserName"], null),
                            SettleID = DataTypeHelper.GetString(sdr["SettleID"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderPre.GetList",
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