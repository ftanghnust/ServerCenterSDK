
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
    /// ### BuyBackPreDetails数据库访问类
    /// </summary>
    public partial class BuyBackPreDetailsDAO : BaseDAL, IBuyBackPreDetailsDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BuyBackPreDetailsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BuyBackPreDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "BuyBackPreDetails";

        #region 添加一个BuyBackPreDetails
        /// <summary>
        /// 添加一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(BuyBackPreDetails model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@ID", SqlDbType.VarChar, 50),
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@ProductId", SqlDbType.Int),
                                new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
                                new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
                                new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
                                new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
                                new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
                                new SqlParameter("@BackUnit", SqlDbType.VarChar, 32),
                                new SqlParameter("@BackPackingQty", SqlDbType.Decimal),
                                new SqlParameter("@BackQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@BackPrice", SqlDbType.Money),
                                new SqlParameter("@Unit", SqlDbType.VarChar, 32),
                                new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@UnitPrice", SqlDbType.Money),
                                new SqlParameter("@SubAmt", SqlDbType.Money),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                                new SqlParameter("@SerialNumber", SqlDbType.Int),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@SalePrice", SqlDbType.Money)

                                };
            sp[0].Value = model.ID;
            sp[1].Value = model.BackID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.BackUnit;
            sp[10].Value = model.BackPackingQty;
            sp[11].Value = model.BackQty;
            sp[12].Value = model.BackPrice;
            sp[13].Value = model.Unit;
            sp[14].Value = model.UnitQty;
            sp[15].Value = model.UnitPrice;
            sp[16].Value = model.SubAmt;
            sp[17].Value = model.Remark;
            sp[18].Value = model.SerialNumber;
            sp[19].Value = model.ModifyUserID;
            sp[20].Value = model.ModifyUserName;
            sp[21].Value = model.SalePrice;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.Save",
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

        #region 分页获取BuyBackPreDetails集合
        /// <summary>
        /// 分页获取BuyBackPreDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<BuyBackPreDetails> GetPageList(PageListBySql<BuyBackPreDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,BackID,WID,ProductId,SKU,ProductName,BarCode,ProductImageUrl200,ProductImageUrl400,BackUnit,BackPackingQty,BackQty,BackPrice,Unit,UnitQty,UnitPrice,SubAmt,Remark,SerialNumber,ModifyTime,ModifyUserID,ModifyUserName,SalePrice";
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
                        page.ItemList.Add(new BuyBackPreDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            ProductImageUrl200 = DataTypeHelper.GetString(sdr["ProductImageUrl200"], null),
                            ProductImageUrl400 = DataTypeHelper.GetString(sdr["ProductImageUrl400"], null),
                            BackUnit = DataTypeHelper.GetString(sdr["BackUnit"], null),
                            BackPackingQty = DataTypeHelper.GetDecimal(sdr["BackPackingQty"]),
                            BackQty = DataTypeHelper.GetDecimal(sdr["BackQty"]),
                            BackPrice = DataTypeHelper.GetDouble(sdr["BackPrice"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"]),
                            UnitQty = DataTypeHelper.GetDecimal(sdr["UnitQty"]),
                            UnitPrice = DataTypeHelper.GetDouble(sdr["UnitPrice"]),
                            SubAmt = DataTypeHelper.GetDouble(sdr["SubAmt"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"], null)

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.GetPageList",
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

        #region 根据BackID批量删除BuyBackPreDetails
        /// <summary>
        /// 根据BackID批量删除BuyBackPreDetails
        /// </summary>
        /// <param name="BackID"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int Delete(string BackID, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByBackID", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = { new SqlParameter("@BackID", SqlDbType.VarChar, 50) };
            sp[0].Value = BackID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.Delete",
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

            if (conditionDict.ContainsKey("BackID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "BackID",
                        FieldValue = conditionDict["BackID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

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


        #region 成员方法
        #region 根据主键验证BuyBackPreDetails是否存在
        /// <summary>
        /// 根据主键验证BuyBackPreDetails是否存在
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(BuyBackPreDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = { new SqlParameter("@ID", SqlDbType.VarChar, 50) };
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.Exists",
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

        #region 更新一个BuyBackPreDetails
        /// <summary>
        /// 更新一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(BuyBackPreDetails model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@ProductId", SqlDbType.Int),
                                new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
                                new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
                                new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
                                new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
                                new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
                                new SqlParameter("@BackUnit", SqlDbType.VarChar, 32),
                                new SqlParameter("@BackPackingQty", SqlDbType.Decimal),
                                new SqlParameter("@BackQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@BackPrice", SqlDbType.Money),
                                new SqlParameter("@Unit", SqlDbType.VarChar, 32),
                                new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@UnitPrice", SqlDbType.Money),
                                new SqlParameter("@SubAmt", SqlDbType.Money),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@ID", SqlDbType.VarChar, 50),
                                new SqlParameter("@SalePrice", SqlDbType.Money)

                                };
            sp[0].Value = model.BackID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ProductId;
            sp[3].Value = model.SKU;
            sp[4].Value = model.ProductName;
            sp[5].Value = model.BarCode;
            sp[6].Value = model.ProductImageUrl200;
            sp[7].Value = model.ProductImageUrl400;
            sp[8].Value = model.BackUnit;
            sp[9].Value = model.BackPackingQty;
            sp[10].Value = model.BackQty;
            sp[11].Value = model.BackPrice;
            sp[12].Value = model.Unit;
            sp[13].Value = model.UnitQty;
            sp[14].Value = model.UnitPrice;
            sp[15].Value = model.SubAmt;
            sp[16].Value = model.Remark;
            sp[17].Value = model.ModifyTime;
            sp[18].Value = model.ModifyUserID;
            sp[19].Value = model.ModifyUserName;
            sp[20].Value = model.ID;
            sp[21].Value = model.SalePrice;


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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.Edit",
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


        #region 删除一个BuyBackPreDetails
        /// <summary>
        /// 删除一个BuyBackPreDetails
        /// </summary>
        /// <param name="model">BuyBackPreDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(BuyBackPreDetails model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = { new SqlParameter("@ID", SqlDbType.VarChar, 50) };
            sp[0].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.Delete",
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


        #region 根据主键逻辑删除一个BuyBackPreDetails
        /// <summary>
        /// 根据主键逻辑删除一个BuyBackPreDetails
        /// </summary>
        /// <param name="iD">编号（仓库ID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = { new SqlParameter("@ID", SqlDbType.VarChar, 50) };
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.LogicDelete",
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


        #region 根据字典获取BuyBackPreDetails对象
        /// <summary>
        /// 根据字典获取BuyBackPreDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BuyBackPreDetails对象</returns>
        public BuyBackPreDetails GetModel(IDictionary<string, object> conditionDict)
        {
            BuyBackPreDetails model = null;
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
                IList<BuyBackPreDetails> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取BuyBackPreDetails对象
        /// <summary>
        /// 根据主键获取BuyBackPreDetails对象
        /// </summary>
        /// <param name="iD">编号（仓库ID+GUID)</param>
        /// <returns>BuyBackPreDetails对象</returns>
        public BuyBackPreDetails GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            BuyBackPreDetails model = null;
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
                        model = new BuyBackPreDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            ProductImageUrl200 = DataTypeHelper.GetString(sdr["ProductImageUrl200"], null),
                            ProductImageUrl400 = DataTypeHelper.GetString(sdr["ProductImageUrl400"], null),
                            BackUnit = DataTypeHelper.GetString(sdr["BackUnit"], null),
                            BackPackingQty = DataTypeHelper.GetDecimal(sdr["BackPackingQty"]),
                            BackQty = DataTypeHelper.GetDecimal(sdr["BackQty"]),
                            BackPrice = DataTypeHelper.GetDouble(sdr["BackPrice"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"]),
                            UnitQty = DataTypeHelper.GetDecimal(sdr["UnitQty"]),
                            UnitPrice = DataTypeHelper.GetDouble(sdr["UnitPrice"]),
                            SubAmt = DataTypeHelper.GetDouble(sdr["SubAmt"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.GetModel",
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


        #region 根据字典获取BuyBackPreDetails集合 包含历史表数据
        /// <summary>
        /// 根据字典获取BuyBackPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<BuyBackPreDetails> GetList(IDictionary<string, object> conditionDict)
        {
            IList<BuyBackPreDetails> list = null;
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


        #region 根据字典获取BuyBackPreDetails数据集
        /// <summary>
        /// 根据字典获取BuyBackPreDetails数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.GetDataSet",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.UpdateField",
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

        #region 根据条件获取BuyBackPreDetails列表 包含历史表数据
        /// <summary>
        /// 根据条件获取BuyBackPreDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<BuyBackPreDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<BuyBackPreDetails> list = new List<BuyBackPreDetails>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadAll", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new BuyBackPreDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            ProductImageUrl200 = DataTypeHelper.GetString(sdr["ProductImageUrl200"], null),
                            ProductImageUrl400 = DataTypeHelper.GetString(sdr["ProductImageUrl400"], null),
                            BackUnit = DataTypeHelper.GetString(sdr["BackUnit"], null),
                            BackPackingQty = DataTypeHelper.GetDecimal(sdr["BackPackingQty"]),
                            BackQty = DataTypeHelper.GetDecimal(sdr["BackQty"]),
                            BackPrice = DataTypeHelper.GetDouble(sdr["BackPrice"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"]),
                            UnitQty = DataTypeHelper.GetDecimal(sdr["UnitQty"]),
                            UnitPrice = DataTypeHelper.GetDouble(sdr["UnitPrice"]),
                            SubAmt = DataTypeHelper.GetDouble(sdr["SubAmt"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.GetList",
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

        #region 根据字典获取BuyBackPreDetails集合 不含历史表数据
        /// <summary>
        /// 根据字典获取BuyBackPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<BuyBackPreDetails> GetListByPre(IDictionary<string, object> conditionDict)
        {
            IList<BuyBackPreDetails> list = null;
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
                list = GetListByPre(where.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion

        #region 根据条件获取BuyBackPreDetails列表 不含历史表数据
        /// <summary>
        /// 根据条件获取BuyBackPreDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<BuyBackPreDetails> GetListByPre(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<BuyBackPreDetails> list = new List<BuyBackPreDetails>();
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
                        list.Add(new BuyBackPreDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            BackID = DataTypeHelper.GetString(sdr["BackID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            ProductImageUrl200 = DataTypeHelper.GetString(sdr["ProductImageUrl200"], null),
                            ProductImageUrl400 = DataTypeHelper.GetString(sdr["ProductImageUrl400"], null),
                            BackUnit = DataTypeHelper.GetString(sdr["BackUnit"], null),
                            BackPackingQty = DataTypeHelper.GetDecimal(sdr["BackPackingQty"]),
                            BackQty = DataTypeHelper.GetDecimal(sdr["BackQty"]),
                            BackPrice = DataTypeHelper.GetDouble(sdr["BackPrice"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"]),
                            UnitQty = DataTypeHelper.GetDecimal(sdr["UnitQty"]),
                            UnitPrice = DataTypeHelper.GetDouble(sdr["UnitPrice"]),
                            SubAmt = DataTypeHelper.GetDouble(sdr["SubAmt"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackPreDetails.GetList",
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
    }
}