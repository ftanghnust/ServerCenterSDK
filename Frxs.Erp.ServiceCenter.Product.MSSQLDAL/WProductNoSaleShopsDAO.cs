
/*****************************
* Author:CR
*
* Date:2016-03-31
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// ### 仓库商品限购门店明细表WProductNoSaleShops数据库访问类
    /// </summary>
    public partial class WProductNoSaleShopsDAO : BaseDAL, IWProductNoSaleShopsDAO
    {
        const string tableName = "WProductNoSaleShops";

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductNoSaleShops是否存在
        /// <summary>
        /// 根据主键验证WProductNoSaleShops是否存在
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductNoSaleShops model)
        {
            DBHelper helper = DBHelper.GetInstance();
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.Exists",
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


        #region 添加一个WProductNoSaleShops
        /// <summary>
        /// 添加一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductNoSaleShops model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@GroupID", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.NoSaleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupID;
            sp[3].Value = model.CreateTime;
            sp[4].Value = model.CreateUserID;
            sp[5].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.Save",
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


        #region 更新一个WProductNoSaleShops
        /// <summary>
        /// 更新一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductNoSaleShops model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@GroupID", SqlDbType.Int),
new SqlParameter("@ID", SqlDbType.Int)

};
            sp[0].Value = model.NoSaleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupID;
            sp[3].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.Edit",
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


        #region 删除一个WProductNoSaleShops
        /// <summary>
        /// 删除一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductNoSaleShops model)
        {
            DBHelper helper = DBHelper.GetInstance();
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.Delete",
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


        #region 根据主键逻辑删除一个WProductNoSaleShops
        /// <summary>
        /// 根据主键逻辑删除一个WProductNoSaleShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.LogicDelete",
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


        #region 根据字典获取WProductNoSaleShops对象
        /// <summary>
        /// 根据字典获取WProductNoSaleShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductNoSaleShops对象</returns>
        public WProductNoSaleShops GetModel(IDictionary<string, object> conditionDict)
        {
            WProductNoSaleShops model = null;
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
                IList<WProductNoSaleShops> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductNoSaleShops对象
        /// <summary>
        /// 根据主键获取WProductNoSaleShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductNoSaleShops对象</returns>
        public WProductNoSaleShops GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProductNoSaleShops model = null;
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
                        model = new WProductNoSaleShops
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            NoSaleID = DataTypeHelper.GetString(sdr["NoSaleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.GetModel",
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


        #region 根据字典获取WProductNoSaleShops集合
        /// <summary>
        /// 根据字典获取WProductNoSaleShops集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductNoSaleShops> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductNoSaleShops> list = null;
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


        #region 根据字典获取WProductNoSaleShops数据集
        /// <summary>
        /// 根据字典获取WProductNoSaleShops数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            DBHelper helper = DBHelper.GetInstance();
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.GetDataSet",
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


        #region 分页获取WProductNoSaleShops集合
        /// <summary>
        /// 分页获取WProductNoSaleShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductNoSaleShops> GetPageList(PageListBySql<WProductNoSaleShops> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,NoSaleID,WID,GroupID,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new WProductNoSaleShops
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            NoSaleID = DataTypeHelper.GetString(sdr["NoSaleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.GetPageList",
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
            DBHelper helper = DBHelper.GetInstance();
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.UpdateField",
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


        #region 根据条件获取WProductNoSaleShops列表
        /// <summary>
        /// 根据条件获取WProductNoSaleShops列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WProductNoSaleShops> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductNoSaleShops> list = new List<WProductNoSaleShops>();
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
                        list.Add(new WProductNoSaleShops
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            NoSaleID = DataTypeHelper.GetString(sdr["NoSaleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.GetList",
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

    public partial class WProductNoSaleShopsDAO : BaseDAL, IWProductNoSaleShopsDAO
    {
        #region 根据 NoSaleID 获取WProductNoSaleShops集合
        /// <summary>
        /// 根据 NoSaleID 获取WProductNoSaleShops集合
        /// </summary>
        /// <param name="noSaleID">限购单号</param>
        /// <returns>数据集合</returns>
        public IList<WProductNoSaleShops> GetList(string noSaleID)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductNoSaleShops> list = new List<WProductNoSaleShops>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetListByNoSaleID", base.AssemblyName, base.DatabaseName));
                SqlParameter[] sp = {
                    new SqlParameter("@NoSaleID", SqlDbType.VarChar,50)
                };
                sp[0].Value = noSaleID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new WProductNoSaleShops
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            NoSaleID = DataTypeHelper.GetString(sdr["NoSaleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            //扩展给前台编辑页面显示的属性：
                            GroupName = DataTypeHelper.GetString(sdr["GroupName"], null),
                            GroupCode = DataTypeHelper.GetString(sdr["GroupCode"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            ShopNum = DataTypeHelper.GetInt(sdr["ShopNum"])
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.GetListByNoSaleID",
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


        #region 添加一个WProductNoSaleShops
        /// <summary>
        /// 添加一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductNoSaleShops model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@NoSaleID", SqlDbType.VarChar,50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@GroupID", SqlDbType.Int),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.NoSaleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupID;
            sp[3].Value = model.CreateTime;
            sp[4].Value = model.CreateUserID;
            sp[5].Value = model.CreateUserName;

            try
            {
                object o = new object();
                if (conn == null && tran == null)
                {
                    o = helper.GetSingle(sql, sp);
                }
                else
                {
                    o = helper.GetSingle(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.Save",
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

        #region 根据 NoSaleID 删除 WProductNoSaleShops 事务操作
        /// <summary>
        /// 根据 NoSaleID 删除WProductNoSaleShops 事务操作
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(string noSaleID, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByNoSaleID", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
             new SqlParameter("@NoSaleID", SqlDbType.VarChar,50)
             };
            sp[0].Value = noSaleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSaleShops.Delete",
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
    }
}