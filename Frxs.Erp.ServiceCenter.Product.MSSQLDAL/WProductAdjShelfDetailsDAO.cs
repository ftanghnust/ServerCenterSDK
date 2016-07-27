
/*****************************
* Author:CR
*
* Date:2016-03-25
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
    /// ### 仓库商品货架调整明细表WProductAdjShelfDetails数据库访问类
    /// </summary>
    public partial class WProductAdjShelfDetailsDAO : BaseDAL, IWProductAdjShelfDetailsDAO
    {
        const string tableName = "WProductAdjShelfDetails";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductAdjShelfDetails是否存在
        /// <summary>
        /// 根据主键验证WProductAdjShelfDetails是否存在
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductAdjShelfDetails model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.Exists",
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


        #region 添加一个WProductAdjShelfDetails
        /// <summary>
        /// 添加一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductAdjShelfDetails model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WProductID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@OldShelfID", SqlDbType.Int),
new SqlParameter("@OldShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@Remark", SqlDbType.NVarChar, 100),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.AdjID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.Unit;
            sp[5].Value = model.OldShelfID;
            sp[6].Value = model.OldShelfCode;
            sp[7].Value = model.ShelfID;
            sp[8].Value = model.ShelfCode;
            sp[9].Value = model.Remark;
            sp[10].Value = model.CreateTime;
            sp[11].Value = model.CreateUserID;
            sp[12].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.Save",
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
        /// 添加一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductAdjShelfDetails model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WProductID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@OldShelfID", SqlDbType.Int),
new SqlParameter("@OldShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@Remark", SqlDbType.NVarChar, 100),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.AdjID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.Unit;
            sp[5].Value = model.OldShelfID;
            sp[6].Value = string.IsNullOrEmpty(model.OldShelfCode) ? "" : model.OldShelfCode;
            sp[7].Value = model.ShelfID;
            sp[8].Value = model.ShelfCode;
            sp[9].Value = model.Remark;
            sp[10].Value = model.CreateTime;
            sp[11].Value = model.CreateUserID;
            sp[12].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.Save",
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


        #region 更新一个WProductAdjShelfDetails
        /// <summary>
        /// 更新一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductAdjShelfDetails model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WProductID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@OldShelfID", SqlDbType.Int),
new SqlParameter("@OldShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@Remark", SqlDbType.NVarChar, 100),
new SqlParameter("@ID", SqlDbType.BigInt)

};
            sp[0].Value = model.AdjID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.Unit;
            sp[5].Value = model.OldShelfID;
            sp[6].Value = model.OldShelfCode;
            sp[7].Value = model.ShelfID;
            sp[8].Value = model.ShelfCode;
            sp[9].Value = model.Remark;
            sp[10].Value = model.ID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.Edit",
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


        #region 删除一个WProductAdjShelfDetails
        /// <summary>
        /// 删除一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductAdjShelfDetails model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.Delete",
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
        /// 删除一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(string adjId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByAdjId", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50)
 };
            sp[0].Value = adjId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.Delete",
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


        #region 根据主键逻辑删除一个WProductAdjShelfDetails
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(long iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.LogicDelete",
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


        #region 根据字典获取WProductAdjShelfDetails对象
        /// <summary>
        /// 根据字典获取WProductAdjShelfDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductAdjShelfDetails对象</returns>
        public WProductAdjShelfDetails GetModel(IDictionary<string, object> conditionDict)
        {
            WProductAdjShelfDetails model = null;
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
                IList<WProductAdjShelfDetails> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductAdjShelfDetails对象
        /// <summary>
        /// 根据主键获取WProductAdjShelfDetails对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductAdjShelfDetails对象</returns>
        public WProductAdjShelfDetails GetModel(long iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProductAdjShelfDetails model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WProductAdjShelfDetails
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            AdjID = DataTypeHelper.GetString(sdr["AdjID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            OldShelfID = DataTypeHelper.GetInt(sdr["OldShelfID"]),
                            OldShelfCode = DataTypeHelper.GetString(sdr["OldShelfCode"], null),
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.GetModel",
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


        #region 根据字典获取WProductAdjShelfDetails集合
        /// <summary>
        /// 根据字典获取WProductAdjShelfDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductAdjShelfDetails> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductAdjShelfDetails> list = null;
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


        #region 根据字典获取WProductAdjShelfDetails数据集
        /// <summary>
        /// 根据字典获取WProductAdjShelfDetails数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.GetDataSet",
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


        #region 分页获取WProductAdjShelfDetails集合
        /// <summary>
        /// 分页获取WProductAdjShelfDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductAdjShelfDetails> GetPageList(PageListBySql<WProductAdjShelfDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,AdjID,WID,WProductID,ProductId,Unit,OldShelfID,OldShelfCode,ShelfID,ShelfCode,Remark,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new WProductAdjShelfDetails
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            AdjID = DataTypeHelper.GetString(sdr["AdjID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            OldShelfID = DataTypeHelper.GetInt(sdr["OldShelfID"]),
                            OldShelfCode = DataTypeHelper.GetString(sdr["OldShelfCode"], null),
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.UpdateField",
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


        #region 根据条件获取WProductAdjShelfDetails列表
        /// <summary>
        /// 根据条件获取WProductAdjShelfDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WProductAdjShelfDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductAdjShelfDetails> list = new List<WProductAdjShelfDetails>();
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
                        list.Add(new WProductAdjShelfDetails
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            AdjID = DataTypeHelper.GetString(sdr["AdjID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            OldShelfID = DataTypeHelper.GetInt(sdr["OldShelfID"]),
                            OldShelfCode = DataTypeHelper.GetString(sdr["OldShelfCode"], null),
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            BigPackingQty = DataTypeHelper.GetDecimal(sdr["BigPackingQty"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelfDetails.GetList",
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