
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;
/*****************************
* Author:zhoujin
*
* Date:2016-03-29
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
    /// ### 仓库--广告商品表WAdvertisementProduct数据库访问类
    /// </summary>
    public partial class WAdvertisementProductDAO : BaseDAL, IWAdvertisementProductDAO
    {
        const string tableName = "WAdvertisementProduct";

        public WAdvertisementProductDAO(string warehouseId)
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
        #region 根据主键验证WAdvertisementProduct是否存在
        /// <summary>
        /// 根据主键验证WAdvertisementProduct是否存在
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WAdvertisementProduct model)
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.Exists",
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


        #region 添加一个WAdvertisementProduct
        /// <summary>
        /// 添加一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WAdvertisementProduct model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@AdvertisementID", SqlDbType.Int),
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.AdvertisementID;
            sp[2].Value = model.ProductID;
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.Save",
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


        #region 更新一个WAdvertisementProduct
        /// <summary>
        /// 更新一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WAdvertisementProduct model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@AdvertisementID", SqlDbType.Int),
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@ID", SqlDbType.Int)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.AdvertisementID;
            sp[2].Value = model.ProductID;
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.Edit",
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


        #region 删除一个WAdvertisementProduct
        /// <summary>
        /// 删除一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WAdvertisementProduct model)
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.Delete",
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


        #region 根据主键逻辑删除一个WAdvertisementProduct
        /// <summary>
        /// 根据主键逻辑删除一个WAdvertisementProduct
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.LogicDelete",
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


        #region 根据字典获取WAdvertisementProduct对象
        /// <summary>
        /// 根据字典获取WAdvertisementProduct对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WAdvertisementProduct对象</returns>
        public WAdvertisementProduct GetModel(IDictionary<string, object> conditionDict)
        {
            WAdvertisementProduct model = null;
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
                IList<WAdvertisementProduct> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WAdvertisementProduct对象
        /// <summary>
        /// 根据主键获取WAdvertisementProduct对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WAdvertisementProduct对象</returns>
        public WAdvertisementProduct GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            WAdvertisementProduct model = null;
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
                        model = new WAdvertisementProduct
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            AdvertisementID = DataTypeHelper.GetInt(sdr["AdvertisementID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.GetModel",
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


        #region 根据字典获取WAdvertisementProduct集合
        /// <summary>
        /// 根据字典获取WAdvertisementProduct集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WAdvertisementProduct> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WAdvertisementProduct> list = null;
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


        #region 根据字典获取WAdvertisementProduct数据集
        /// <summary>
        /// 根据字典获取WAdvertisementProduct数据集
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.GetDataSet",
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


        #region 分页获取WAdvertisementProduct集合
        /// <summary>
        /// 分页获取WAdvertisementProduct集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WAdvertisementProduct> GetPageList(PageListBySql<WAdvertisementProduct> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,WID,AdvertisementID,ProductID,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new WAdvertisementProduct
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            AdvertisementID = DataTypeHelper.GetInt(sdr["AdvertisementID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.UpdateField",
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
            //StringBuilder where = new StringBuilder(" 1=1 ");
            //IList<WhereCondition> whereConditionList = new List<WhereCondition>();//TODO
            //string result = new WhereCondition().GetWhereCondition(whereConditionList, ref parameters);
            //where.Append(result);
            //return Regex.Replace(where.ToString(), "^ AND ", string.Empty);

            StringBuilder where = new StringBuilder(" 1=1 ");
            IList<WhereCondition> whereConditionList = new List<WhereCondition>();//TODO
            if (conditionDict.ContainsKey("AdvertisementID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "AdvertisementID",
                        FieldValue = conditionDict["AdvertisementID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
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


        #region 根据条件获取WAdvertisementProduct列表
        /// <summary>
        /// 根据条件获取WAdvertisementProduct列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WAdvertisementProduct> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WAdvertisementProduct> list = new List<WAdvertisementProduct>();
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
                        list.Add(new WAdvertisementProduct
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            AdvertisementID = DataTypeHelper.GetInt(sdr["AdvertisementID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.GetList",
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

    public partial class WAdvertisementProductDAO : BaseDAL, IWAdvertisementProductDAO
    {
        #region 添加一个WAdvertisementProduct 事务操作
        /// <summary>
        /// 添加一个WAdvertisementProduct 事务操作
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WAdvertisementProduct model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@AdvertisementID", SqlDbType.Int),
            new SqlParameter("@ProductID", SqlDbType.Int),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.WID;
            sp[1].Value = model.AdvertisementID;
            sp[2].Value = model.ProductID;
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.Save",
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

        #region 删除一个WAdvertisementProduct 事务操作
        /// <summary>
        /// 删除一个WAdvertisementProduct 事务操作
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WAdvertisementProduct model, IDbConnection conn, IDbTransaction tran)
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.Delete",
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

    public partial class WAdvertisementProductDAO : BaseDAL, IWAdvertisementProductDAO
    {
        /// <summary>
        /// 根据主键逻辑删除一个WAdvertisementProduct
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int DeleteByWAdvertisement(int WID, int AdvertisementID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByWAdvertisement", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                  new SqlParameter("@WID", SqlDbType.Int),
                                  new SqlParameter("@AdvertisementID", SqlDbType.Int)
                                 };
            sp[0].Value = WID;
            sp[1].Value = AdvertisementID;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.DeleteByWAdvertisement",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }

        public int DeleteByWAdvertisement(int WID, int AdvertisementID, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByWAdvertisement", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                  new SqlParameter("@WID", SqlDbType.Int),
                                  new SqlParameter("@AdvertisementID", SqlDbType.Int)
                                 };
            sp[0].Value = WID;
            sp[1].Value = AdvertisementID;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisementProduct.DeleteByWAdvertisement",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
    }
}