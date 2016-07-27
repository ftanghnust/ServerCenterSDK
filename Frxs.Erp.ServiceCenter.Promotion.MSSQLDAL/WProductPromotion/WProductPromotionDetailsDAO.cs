/*****************************
* Author:
*
* Date:2016-04-07
******************************/


using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL
{
    /// <summary>
    /// ### WProductPromotionDetails数据库访问类
    /// </summary>
    public partial class WProductPromotionDetailsDAO : BaseDAL, IWProductPromotionDetailsDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public WProductPromotionDetailsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public WProductPromotionDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "WProductPromotionDetails";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductPromotionDetails是否存在
        /// <summary>
        /// 根据主键验证WProductPromotionDetails是否存在
        /// </summary>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductPromotionDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
             new SqlParameter("@ID", SqlDbType.Int)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductPromotionDetails.Exists",
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


        #region 添加一个WProductPromotionDetails
        /// <summary>
        /// 添加一个WProductPromotionDetails
        /// </summary>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(WProductPromotionDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@WProductID", SqlDbType.Int),
            new SqlParameter("@ProductID", SqlDbType.Int),
            new SqlParameter("@SKU", SqlDbType.VarChar, 10),
            new SqlParameter("@ProductName", SqlDbType.NVarChar, 50),
            new SqlParameter("@Unit", SqlDbType.VarChar, 32),
            new SqlParameter("@PackingQty", SqlDbType.Decimal),
            new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
            new SqlParameter("@SalePrice", SqlDbType.Money),
            new SqlParameter("@OldPoint", SqlDbType.Money),
            new SqlParameter("@Point", SqlDbType.Money),
            new SqlParameter("@MaxOrderQty", SqlDbType.Decimal, 4),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.ProductID;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.Unit;
            sp[7].Value = model.PackingQty;
            sp[8].Value = model.SaleUnit;
            sp[9].Value = model.SalePrice;
            sp[10].Value = model.OldPoint;
            sp[11].Value = model.Point;
            sp[12].Value = model.MaxOrderQty;
            sp[13].Value = model.CreateTime;
            sp[14].Value = model.CreateUserID;
            sp[15].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductPromotionDetails.Save",
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


        #region 添加一个WProductPromotionDetails(事务处理)
        /// <summary>
        /// 添加一个WProductPromotionDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, WProductPromotionDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@WProductID", SqlDbType.Int),
            new SqlParameter("@ProductID", SqlDbType.Int),
            new SqlParameter("@SKU", SqlDbType.VarChar, 10),
            new SqlParameter("@ProductName", SqlDbType.NVarChar, 50),
            new SqlParameter("@Unit", SqlDbType.VarChar, 32),
            new SqlParameter("@PackingQty", SqlDbType.Decimal),
            new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
            new SqlParameter("@SalePrice", SqlDbType.Money),
            new SqlParameter("@OldPoint", SqlDbType.Money),
            new SqlParameter("@Point", SqlDbType.Money),
            new SqlParameter("@MaxOrderQty", SqlDbType.Decimal, 4),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.ProductID;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.Unit;
            sp[7].Value = model.PackingQty;
            sp[8].Value = model.SaleUnit;
            sp[9].Value = model.SalePrice;
            sp[10].Value = model.OldPoint;
            sp[11].Value = model.Point;
            sp[12].Value = model.MaxOrderQty;
            sp[13].Value = model.CreateTime;
            sp[14].Value = model.CreateUserID;
            sp[15].Value = model.CreateUserName;

            try
            {

                object o = helper.GetSingle(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.Save",
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


        #region 更新一个WProductPromotionDetails
        /// <summary>
        /// 更新一个WProductPromotionDetails
        /// </summary>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductPromotionDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@WProductID", SqlDbType.Int),
            new SqlParameter("@ProductID", SqlDbType.Int),
            new SqlParameter("@SKU", SqlDbType.VarChar, 10),
            new SqlParameter("@ProductName", SqlDbType.NVarChar, 50),
            new SqlParameter("@Unit", SqlDbType.VarChar, 32),
            new SqlParameter("@PackingQty", SqlDbType.Decimal),
            new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
            new SqlParameter("@SalePrice", SqlDbType.Money),
            new SqlParameter("@OldPoint", SqlDbType.Money),
            new SqlParameter("@Point", SqlDbType.Money),
            new SqlParameter("@MaxOrderQty", SqlDbType.Decimal, 4),
            new SqlParameter("@ID", SqlDbType.Int)

            };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.ProductID;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.Unit;
            sp[7].Value = model.PackingQty;
            sp[8].Value = model.SaleUnit;
            sp[9].Value = model.SalePrice;
            sp[10].Value = model.OldPoint;
            sp[11].Value = model.Point;
            sp[12].Value = model.MaxOrderQty;
            sp[13].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.Edit",
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


        #region 更新一个WProductPromotionDetails(事务处理)
        /// <summary>
        /// 更新一个WProductPromotionDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, WProductPromotionDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@WProductID", SqlDbType.Int),
            new SqlParameter("@ProductID", SqlDbType.Int),
            new SqlParameter("@SKU", SqlDbType.VarChar, 10),
            new SqlParameter("@ProductName", SqlDbType.NVarChar, 50),
            new SqlParameter("@Unit", SqlDbType.VarChar, 32),
            new SqlParameter("@PackingQty", SqlDbType.Decimal),
            new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
            new SqlParameter("@SalePrice", SqlDbType.Money),
            new SqlParameter("@OldPoint", SqlDbType.Money),
            new SqlParameter("@Point", SqlDbType.Money),
            new SqlParameter("@MaxOrderQty", SqlDbType.Decimal, 4),
            new SqlParameter("@ID", SqlDbType.Int)

            };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.ProductID;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.Unit;
            sp[7].Value = model.PackingQty;
            sp[8].Value = model.SaleUnit;
            sp[9].Value = model.SalePrice;
            sp[10].Value = model.OldPoint;
            sp[11].Value = model.Point;
            sp[12].Value = model.MaxOrderQty;
            sp[13].Value = model.ID;

            try
            {
                result = helper.ExecNonQuery(conn, tran, sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.Edit",
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


        #region 删除一个WProductPromotionDetails
        /// <summary>
        /// 删除一个WProductPromotionDetails
        /// </summary>
        /// <param name="model">WProductPromotionDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductPromotionDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@ID", SqlDbType.Int)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.Delete",
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


        #region 根据主键逻辑删除一个WProductPromotionDetails
        /// <summary>
        /// 根据主键逻辑删除一个WProductPromotionDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@ID", SqlDbType.Int)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.LogicDelete",
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


        #region 根据字典获取WProductPromotionDetails对象
        /// <summary>
        /// 根据字典获取WProductPromotionDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数
        /// <returns>WProductPromotionDetails对象</returns>
        public WProductPromotionDetails GetModel(IDictionary<string, object> conditionDict)
        {
            WProductPromotionDetails model = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
                }
                IList<WProductPromotionDetails> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductPromotionDetails对象
        /// <summary>
        /// 根据主键获取WProductPromotionDetails对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductPromotionDetails对象</returns>
        public WProductPromotionDetails GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            WProductPromotionDetails model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                new SqlParameter("@ID", SqlDbType.Int)
                };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WProductPromotionDetails
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            PackingQty = DataTypeHelper.GetDecimalNull(sdr["PackingQty"]),
                            SaleUnit = DataTypeHelper.GetString(sdr["SaleUnit"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"]),
                            OldPoint = DataTypeHelper.GetDecimalNull(sdr["OldPoint"]),
                            Point = DataTypeHelper.GetDecimal(sdr["Point"]),
                            MaxOrderQty = DataTypeHelper.GetDecimal(sdr["MaxOrderQty"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.GetModel",
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


        #region 根据字典获取WProductPromotionDetails集合
        /// <summary>
        /// 根据字典获取WProductPromotionDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数
        /// <returns>数据集合</returns>
        public IList<WProductPromotionDetails> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductPromotionDetails> list = null;
            try
            {
                IList<IDbDataParameter> parameters = null;
                //StringBuilder where = new StringBuilder();
                //if (sp != null && sp.Length > 0 && sp[0] != null)
                //{
                //    where.Append(" WHERE 1=1 ");
                //    foreach (SqlParameter s in sp)
                //    {
                //        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                //    }
                //}

                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);

                string where = CreateCondition(conditionDict, ref parameters);
                list = GetList(where, sp);
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion


        #region 根据字典获取WProductPromotionDetails数据集
        /// <summary>
        /// 根据字典获取WProductPromotionDetails数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.GetDataSet",
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


        #region 分页获取WProductPromotionDetails集合
        /// <summary>
        /// 分页获取WProductPromotionDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductPromotionDetails> GetPageList(PageListBySql<WProductPromotionDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,PromotionID,WID,WProductID,ProductID,SKU,ProductName,Unit,PackingQty,SaleUnit,SalePrice,OldPoint,Point,MaxOrderQty,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new WProductPromotionDetails
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            PackingQty = DataTypeHelper.GetDecimalNull(sdr["PackingQty"]),
                            SaleUnit = DataTypeHelper.GetString(sdr["SaleUnit"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"]),
                            OldPoint = DataTypeHelper.GetDecimalNull(sdr["OldPoint"]),
                            Point = DataTypeHelper.GetDecimal(sdr["Point"]),
                            MaxOrderQty = DataTypeHelper.GetDecimal(sdr["MaxOrderQty"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.UpdateField",
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
            StringBuilder where = new StringBuilder(" where 1=1 ");

            IList<WhereCondition> whereConditionList = new List<WhereCondition>();//TODO
            if (conditionDict.ContainsKey("WID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "WID",
                        FieldValue = conditionDict["WID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });

            }
            string result = new WhereCondition().GetWhereCondition(whereConditionList, ref parameters);
            where.Append(result);

            int PromotionType = 1;
            if (conditionDict.ContainsKey("ShopID"))
            {
                where.Append(" and  PromotionID in (select PromotionID from WProductPromotionShops where ShopID ='" + conditionDict["ShopID"] + "' )");
            }

            if (conditionDict.ContainsKey("ProductIDList"))
            {
                where.Append(" and  ProductID in (" + conditionDict["ProductIDList"] + ")");
            }

            if (conditionDict.ContainsKey("PromotionType"))
            {
                if (int.Parse(conditionDict["PromotionType"].ToString()) == PromotionType)
                {
                    if (conditionDict.ContainsKey("BeginTime") && conditionDict.ContainsKey("EndTime"))
                    {
                        where.Append(" and  PromotionID in (select PromotionID from dbo.WProductPromotion where PromotionType=1 and Status=2 and WID=" + conditionDict["WID"] + " and BeginTime <= '" + DateTime.Now + "' and endTime >= '" + DateTime.Now + "')");
                    }
                }
                else
                {
                    where.Append(" and  PromotionID in (select PromotionID from dbo.WProductPromotion where Status=2 and  PromotionType=2)");
                }
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
                return "ID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WProductPromotionDetails列表
        /// <summary>
        /// 根据条件获取WProductPromotionDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProductPromotionDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WProductPromotionDetails> list = new List<WProductPromotionDetails>();
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
                        list.Add(new WProductPromotionDetails
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            PackingQty = DataTypeHelper.GetDecimalNull(sdr["PackingQty"]),
                            SaleUnit = DataTypeHelper.GetString(sdr["SaleUnit"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"]),
                            OldPoint = DataTypeHelper.GetDecimalNull(sdr["OldPoint"]),
                            Point = DataTypeHelper.GetDecimal(sdr["Point"]),
                            MaxOrderQty = DataTypeHelper.GetDecimal(sdr["MaxOrderQty"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.GetList",
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

    public partial class WProductPromotionDetailsDAO : BaseDAL, IWProductPromotionDetailsDAO
    {

        #region 根据PromotionID 删除 WProductPromotionDetails 事务操作
        /// <summary>
        /// 根据PromotionID 删除 WProductPromotionDetails 事务操作
        /// </summary>        
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="promotionID">promotionID</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(IDbConnection conn, IDbTransaction tran, string promotionID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByPromotionID", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
					new SqlParameter("@PromotionID", SqlDbType.VarChar,50)
					};
            sp[0].Value = promotionID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.DeleteByPromotionID",
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

        #region 根据 PromotionID 获取WProductPromotionDetails集合
        /// <summary>
        /// 根据 PromotionID 获取WProductPromotionDetails集合
        /// </summary>
        /// <param name="PromotionID">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductPromotionDetails> GetList(string promotionID)
        {

            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WProductPromotionDetails> list = new List<WProductPromotionDetails>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetListByPromotionID", base.AssemblyName, base.DatabaseName));
                SqlParameter[] sp = {
                    new SqlParameter("@PromotionID", SqlDbType.VarChar,50)
                };
                sp[0].Value = promotionID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new WProductPromotionDetails
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            PackingQty = DataTypeHelper.GetDecimalNull(sdr["PackingQty"]),
                            SaleUnit = DataTypeHelper.GetString(sdr["SaleUnit"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"]),
                            OldPoint = DataTypeHelper.GetDecimalNull(sdr["OldPoint"]),
                            Point = DataTypeHelper.GetDecimal(sdr["Point"]),
                            MaxOrderQty = DataTypeHelper.GetDecimal(sdr["MaxOrderQty"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionDetails.GetListByPromotionID",
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
