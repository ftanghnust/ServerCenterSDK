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
    /// ### WProductPromotionShops数据库访问类
    /// </summary>
    public partial class WProductPromotionShopsDAO : BaseDAL, IWProductPromotionShopsDAO
    {

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public WProductPromotionShopsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public WProductPromotionShopsDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "WProductPromotionShops";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductPromotionShops是否存在
        /// <summary>
        /// 根据主键验证WProductPromotionShops是否存在
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductPromotionShops model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.Exists",
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


        #region 添加一个WProductPromotionShops
        /// <summary>
        /// 添加一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(WProductPromotionShops model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@ShopID", SqlDbType.Int),
            new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
            new SqlParameter("@ShopName", SqlDbType.NVarChar, 100),
            new SqlParameter("@ShopType", SqlDbType.Int),
            new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ShopID;
            sp[3].Value = model.ShopCode;
            sp[4].Value = model.ShopName;
            sp[5].Value = model.ShopType;
            sp[6].Value = model.FullAddress;
            sp[7].Value = model.CreateTime;
            sp[8].Value = model.CreateUserID;
            sp[9].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.Save",
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


        #region 添加一个WProductPromotionShops(事务处理)
        /// <summary>
        /// 添加一个WProductPromotionShops(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, WProductPromotionShops model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@ShopID", SqlDbType.Int),
            new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
            new SqlParameter("@ShopName", SqlDbType.NVarChar, 100),
            new SqlParameter("@ShopType", SqlDbType.Int),
            new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ShopID;
            sp[3].Value = model.ShopCode;
            sp[4].Value = model.ShopName;
            sp[5].Value = model.ShopType;
            sp[6].Value = model.FullAddress;
            sp[7].Value = model.CreateTime;
            sp[8].Value = model.CreateUserID;
            sp[9].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.Save",
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


        #region 更新一个WProductPromotionShops
        /// <summary>
        /// 更新一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductPromotionShops model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@ShopID", SqlDbType.Int),
            new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
            new SqlParameter("@ShopName", SqlDbType.NVarChar, 100),
            new SqlParameter("@ShopType", SqlDbType.Int),
            new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
            new SqlParameter("@ID", SqlDbType.Int)

            };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ShopID;
            sp[3].Value = model.ShopCode;
            sp[4].Value = model.ShopName;
            sp[5].Value = model.ShopType;
            sp[6].Value = model.FullAddress;
            sp[7].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.Edit",
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


        #region 更新一个WProductPromotionShops(事务处理)
        /// <summary>
        /// 更新一个WProductPromotionShops(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, WProductPromotionShops model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@ShopID", SqlDbType.Int),
            new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
            new SqlParameter("@ShopName", SqlDbType.NVarChar, 100),
            new SqlParameter("@ShopType", SqlDbType.Int),
            new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
            new SqlParameter("@ID", SqlDbType.Int)

            };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ShopID;
            sp[3].Value = model.ShopCode;
            sp[4].Value = model.ShopName;
            sp[5].Value = model.ShopType;
            sp[6].Value = model.FullAddress;
            sp[7].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.Edit",
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


        #region 删除一个WProductPromotionShops
        /// <summary>
        /// 删除一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductPromotionShops model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.Delete",
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


        #region 根据主键逻辑删除一个WProductPromotionShops
        /// <summary>
        /// 根据主键逻辑删除一个WProductPromotionShops
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.LogicDelete",
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


        #region 根据字典获取WProductPromotionShops对象
        /// <summary>
        /// 根据字典获取WProductPromotionShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductPromotionShops对象</returns>
        public WProductPromotionShops GetModel(IDictionary<string, object> conditionDict)
        {
            WProductPromotionShops model = null;
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
                IList<WProductPromotionShops> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductPromotionShops对象
        /// <summary>
        /// 根据主键获取WProductPromotionShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductPromotionShops对象</returns>
        public WProductPromotionShops GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            WProductPromotionShops model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
            new SqlParameter("@ID", SqlDbType.Int)
            };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<WProductPromotionShops>(sdr);
                    //while (sdr.Read())
                    //{
                        //model = new WProductPromotionShops
                        //{
                        //    ID = DataTypeHelper.GetInt(sdr["ID"]),
                        //    PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                        //    WID = DataTypeHelper.GetInt(sdr["WID"]),
                        //    ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                        //    ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                        //    ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                        //    CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                        //    CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                        //    CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
                        //};
                    //}
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.GetModel",
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


        #region 根据字典获取WProductPromotionShops集合
        /// <summary>
        /// 根据字典获取WProductPromotionShops集合
        /// </summary>
        /// <param name="conditionDict">字典</param>
        /// <returns>数据集合</returns>
        public IList<WProductPromotionShops> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductPromotionShops> list = null;
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
                list = GetList(where.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion


        #region 根据字典获取WProductPromotionShops数据集
        /// <summary>
        /// 根据字典获取WProductPromotionShops数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.GetDataSet",
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


        #region 分页获取WProductPromotionShops集合
        /// <summary>
        /// 分页获取WProductPromotionShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductPromotionShops> GetPageList(PageListBySql<WProductPromotionShops> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,PromotionID,WID,ShopID,ShopCode,ShopName,CreateTime,CreateUserID,CreateUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<WProductPromotionShops>(sdr);
                    //while (sdr.Read())
                    //{
                    //    page.ItemList.Add(new WProductPromotionShops
                    //    {
                    //        ID = DataTypeHelper.GetInt(sdr["ID"]),
                    //        PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                    //        WID = DataTypeHelper.GetInt(sdr["WID"]),
                    //        ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                    //        ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                    //        ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                    //        CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                    //        CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                    //        CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
                    //    });
                    //}
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.UpdateField",
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


        #region 根据条件获取WProductPromotionShops列表
        /// <summary>
        /// 根据条件获取WProductPromotionShops列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProductPromotionShops> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WProductPromotionShops> list = new List<WProductPromotionShops>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<WProductPromotionShops>(sdr);
                    //while (sdr.Read())
                    //{
                    //    list.Add(new WProductPromotionShops
                    //    {
                    //        ID = DataTypeHelper.GetInt(sdr["ID"]),
                    //        PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                    //        WID = DataTypeHelper.GetInt(sdr["WID"]),
                    //        ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                    //        ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                    //        ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                    //        CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                    //        CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                    //        CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
                    //    });
                    //}
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.GetList",
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

    public partial class WProductPromotionShopsDAO : BaseDAL, IWProductPromotionShopsDAO
    {


        #region 根据PromotionID 删除 WProductPromotionShops
        /// <summary>
        /// 根据PromotionID 删除 WProductPromotionShops
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.DeleteByPromotionID",
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


        #region 根据字典获取WProductPromotionShops集合
        /// <summary>
        /// 根据字典获取WProductPromotionShops集合
        /// </summary>
        /// <param name="conditionDict">字典</param>
        /// <returns>数据集合</returns>
        public IList<WProductPromotionShops> GetList(string promotionID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WProductPromotionShops> list = new List<WProductPromotionShops>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetListByPromotionID", base.AssemblyName, base.DatabaseName));
                SqlParameter[] sp = {
                    new SqlParameter("@PromotionID", SqlDbType.VarChar,50)
                };
                sp[0].Value = promotionID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<WProductPromotionShops>(sdr);
                    //while (sdr.Read())
                    //{
                    //    list.Add(new WProductPromotionShops
                    //    {
                    //        ID = DataTypeHelper.GetInt(sdr["ID"]),
                    //        PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                    //        WID = DataTypeHelper.GetInt(sdr["WID"]),
                    //        ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                    //        ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                    //        ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                    //        CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                    //        CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                    //        CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
                    //    });
                    //}
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotionShops.GetListByPromotionID",
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
