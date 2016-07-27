
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;
/*****************************
* Author:chujl
*
* Date:2016-04-02
******************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;


namespace Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL
{
    /// <summary>
    /// ### 仓库消息所属群组表WarehouseMessageShops数据库访问类
    /// </summary>
    public partial class WarehouseMessageShopsDAO : BaseDAL, IWarehouseMessageShopsDAO
    {
        const string tableName = "WarehouseMessageShops";


        public WarehouseMessageShopsDAO(string warehouseId)
            : base(warehouseId)
        {

        }
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }


        #region 成员方法
        #region 根据主键验证WarehouseMessageShops是否存在
        /// <summary>
        /// 根据主键验证WarehouseMessageShops是否存在
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WarehouseMessageShops model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.Exists",
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


        #region 添加一个WarehouseMessageShops
        /// <summary>
        /// 添加一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WarehouseMessageShops model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WarehouseMessageID", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@GroupID", SqlDbType.Int),
new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@GroupCode", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.WarehouseMessageID;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupID;
            sp[3].Value = model.GroupName;
            sp[4].Value = model.CreateTime;
            sp[5].Value = model.CreateUserID;
            sp[6].Value = model.CreateUserName;
            sp[7].Value = model.GroupCode;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.Save",
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
        /// 添加一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WarehouseMessageShops model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WarehouseMessageID", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@GroupID", SqlDbType.Int),
new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@GroupCode", SqlDbType.NVarChar, 50)

};
            sp[0].Value = model.WarehouseMessageID;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupID;
            sp[3].Value = model.GroupName;
            sp[4].Value = model.CreateTime;
            sp[5].Value = model.CreateUserID;
            sp[6].Value = model.CreateUserName;
            sp[7].Value = model.GroupCode;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.Save",
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


        #region 更新一个WarehouseMessageShops
        /// <summary>
        /// 更新一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WarehouseMessageShops model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WarehouseMessageID", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@GroupID", SqlDbType.Int),
new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
new SqlParameter("@ID", SqlDbType.Int),
new SqlParameter("@GroupCode", SqlDbType.NVarChar, 50)

};
            sp[0].Value = model.WarehouseMessageID;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupID;
            sp[3].Value = model.GroupName;
            sp[4].Value = model.ID;
            sp[5].Value = model.GroupCode;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.Edit",
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
        /// 更新一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WarehouseMessageShops model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WarehouseMessageID", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@GroupID", SqlDbType.Int),
new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
new SqlParameter("@ID", SqlDbType.Int),
new SqlParameter("@GroupCode", SqlDbType.NVarChar, 50)

};
            sp[0].Value = model.WarehouseMessageID;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupID;
            sp[3].Value = model.GroupName;
            sp[4].Value = model.ID;
            sp[5].Value = model.GroupCode;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.Edit",
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


        #region 删除一个WarehouseMessageShops
        /// <summary>
        /// 删除一个WarehouseMessageShops
        /// </summary>
        /// <param name="model">WarehouseMessageShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WarehouseMessageShops model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.Delete",
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


        #region 根据主键逻辑删除一个WarehouseMessageShops
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessageShops
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.LogicDelete",
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
        /// 根据主键逻辑删除一个WarehouseMessageShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int messageId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WarehouseMessageID", SqlDbType.Int)
 };
            sp[0].Value = messageId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.LogicDelete",
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


        #region 根据字典获取WarehouseMessageShops对象
        /// <summary>
        /// 根据字典获取WarehouseMessageShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseMessageShops对象</returns>
        public WarehouseMessageShops GetModel(IDictionary<string, object> conditionDict)
        {
            WarehouseMessageShops model = null;
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
                IList<WarehouseMessageShops> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WarehouseMessageShops对象
        /// <summary>
        /// 根据主键获取WarehouseMessageShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WarehouseMessageShops对象</returns>
        public WarehouseMessageShops GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            WarehouseMessageShops model = null;
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
                        model = new WarehouseMessageShops
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WarehouseMessageID = DataTypeHelper.GetInt(sdr["WarehouseMessageID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
                            GroupName = DataTypeHelper.GetString(sdr["GroupName"], null),
                            GroupCode = DataTypeHelper.GetString(sdr["GroupCode"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.GetModel",
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


        #region 根据字典获取WarehouseMessageShops集合
        /// <summary>
        /// 根据字典获取WarehouseMessageShops集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WarehouseMessageShops> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WarehouseMessageShops> list = null;
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


        #region 根据字典获取WarehouseMessageShops数据集
        /// <summary>
        /// 根据字典获取WarehouseMessageShops数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.GetDataSet",
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


        #region 分页获取WarehouseMessageShops集合
        /// <summary>
        /// 分页获取WarehouseMessageShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WarehouseMessageShops> GetPageList(PageListBySql<WarehouseMessageShops> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,WarehouseMessageID,WID,GroupID,GroupCode,GroupName,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new WarehouseMessageShops
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WarehouseMessageID = DataTypeHelper.GetInt(sdr["WarehouseMessageID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
                            GroupCode = DataTypeHelper.GetString(sdr["GroupCode"], null),
                            GroupName = DataTypeHelper.GetString(sdr["GroupName"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.UpdateField",
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
            IList<WhereCondition> whereConditionList = new List<WhereCondition>();
            if (conditionDict.ContainsKey("WarehouseMessageID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "WarehouseMessageID",
                        FieldValue = conditionDict["WarehouseMessageID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("GroupName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "GroupName",
                        FieldValue = conditionDict["GroupName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
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


        #region 根据条件获取WarehouseMessageShops列表
        /// <summary>
        /// 根据条件获取WarehouseMessageShops列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WarehouseMessageShops> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WarehouseMessageShops> list = new List<WarehouseMessageShops>();
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
                        list.Add(new WarehouseMessageShops
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WarehouseMessageID = DataTypeHelper.GetInt(sdr["WarehouseMessageID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
                            GroupCode = DataTypeHelper.GetString(sdr["GroupCode"], null),
                            GroupName = DataTypeHelper.GetString(sdr["GroupName"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WarehouseMessageShops.GetList",
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