
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
    /// ### 仓库商品货架调整表WProductAdjShelf数据库访问类
    /// </summary>
    public partial class WProductAdjShelfDAO : BaseDAL, IWProductAdjShelfDAO
    {
        const string tableName = "WProductAdjShelf";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductAdjShelf是否存在
        /// <summary>
        /// 根据主键验证WProductAdjShelf是否存在
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductAdjShelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50)
 };
            sp[0].Value = model.AdjID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.Exists",
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


        #region 添加一个WProductAdjShelf
        /// <summary>
        /// 添加一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductAdjShelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AdjType", SqlDbType.Int),
new SqlParameter("@AdjID", SqlDbType.VarChar,50)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.CreateTime;
            sp[3].Value = model.CreateUserID;
            sp[4].Value = model.CreateUserName;
            sp[5].Value = model.ModifyTime;
            sp[6].Value = model.ModifyUserID;
            sp[7].Value = model.ModifyUserName;
            sp[8].Value = model.AdjType;
            sp[9].Value = model.AdjID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.Save",
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
        /// 添加一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductAdjShelf model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AdjType", SqlDbType.Int),
new SqlParameter("@AdjID", SqlDbType.VarChar,50),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@Remark", SqlDbType.VarChar, 200)
};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value =  model.ConfTime;
            sp[3].Value = model.ConfUserID;
            sp[4].Value = model.ConfUserName;
            sp[5].Value = model.PostingTime;
            sp[6].Value = model.PostingUserID;
            sp[7].Value = model.PostingUserName;
            sp[8].Value = model.ModifyTime;
            sp[9].Value = model.ModifyUserID;
            sp[10].Value = model.ModifyUserName;
            sp[11].Value = model.AdjType;
            sp[12].Value = model.AdjID;
            sp[13].Value = model.CreateTime;
            sp[14].Value = model.CreateUserID;
            sp[15].Value = model.CreateUserName;
            sp[16].Value = model.Remark;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.Save",
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


        #region 更新一个WProductAdjShelf
        /// <summary>
        /// 更新一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductAdjShelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AdjType", SqlDbType.Int),
new SqlParameter("@AdjID", SqlDbType.VarChar,50)
};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.ConfTime;
            sp[3].Value = model.ConfUserID;
            sp[4].Value = model.ConfUserName;
            sp[5].Value = model.PostingTime;
            sp[6].Value = model.PostingUserID;
            sp[7].Value = model.PostingUserName;
            sp[8].Value = model.ModifyTime;
            sp[9].Value = model.ModifyUserID;
            sp[10].Value = model.ModifyUserName;
            sp[11].Value = model.AdjType;
            sp[12].Value = model.AdjID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.Edit",
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
        /// 更新一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductAdjShelf model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AdjType", SqlDbType.Int),
new SqlParameter("@AdjID", SqlDbType.VarChar,50),
new SqlParameter("@Remark", SqlDbType.VarChar,200)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.ConfTime;
            sp[3].Value = model.ConfUserID;
            sp[4].Value = model.ConfUserName;
            sp[5].Value = model.PostingTime;
            sp[6].Value = model.PostingUserID;
            sp[7].Value = model.PostingUserName;
            sp[8].Value = model.ModifyTime;
            sp[9].Value = model.ModifyUserID;
            sp[10].Value = model.ModifyUserName;
            sp[11].Value = model.AdjType;
            sp[12].Value = model.AdjID;
            sp[13].Value = model.Remark;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.Edit",
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
        /// 更新一个WProducts 表中的ShelfID字段
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int EditToWProduct(string adjId, int userid, string userName, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditToWProduct", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                new SqlParameter("@AdjID", SqlDbType.VarChar,50),
                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                new SqlParameter("@ModifyUserName", SqlDbType.VarChar,50)
                };
            sp[0].Value = adjId;
            sp[1].Value = DateTime.Now;
            sp[2].Value = userid;
            sp[3].Value = userName;


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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.Edit",
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


        #region 删除一个WProductAdjShelf
        /// <summary>
        /// 删除一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductAdjShelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50)
 };
            sp[0].Value = model.AdjID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.Delete",
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
        /// 删除一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(string id, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50)
 };
            sp[0].Value = id;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.Delete",
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


        #region 根据主键逻辑删除一个WProductAdjShelf
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjShelf
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50)
 };
            sp[0].Value = adjID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.LogicDelete",
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


        #region 根据字典获取WProductAdjShelf对象
        /// <summary>
        /// 根据字典获取WProductAdjShelf对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductAdjShelf对象</returns>
        public WProductAdjShelf GetModel(IDictionary<string, object> conditionDict)
        {
            WProductAdjShelf model = null;
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
                IList<WProductAdjShelf> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductAdjShelf对象
        /// <summary>
        /// 根据主键获取WProductAdjShelf对象
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>WProductAdjShelf对象</returns>
        public WProductAdjShelf GetModel(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProductAdjShelf model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar,50)
 };
                sp[0].Value = adjID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WProductAdjShelf
                        {
                            AdjID = DataTypeHelper.GetString(sdr["AdjID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTimeNull(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetIntNull(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            AdjType = DataTypeHelper.GetInt(sdr["AdjType"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"],null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.GetModel",
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


        #region 根据字典获取WProductAdjShelf集合
        /// <summary>
        /// 根据字典获取WProductAdjShelf集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductAdjShelf> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductAdjShelf> list = null;
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


        #region 根据字典获取WProductAdjShelf数据集
        /// <summary>
        /// 根据字典获取WProductAdjShelf数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.GetDataSet",
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


        #region 分页获取WProductAdjShelf集合
        /// <summary>
        /// 分页获取WProductAdjShelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductAdjShelf> GetPageList(PageListBySql<WProductAdjShelf> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "AdjID,WID,Status,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,AdjType,Remark";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);

                if (conditionDict.ContainsKey("StartDate"))
                {

                    page.Where = page.Where + string.Format(" AND CreateTime >= '{0}' ", conditionDict["StartDate"]);
                }

                if (conditionDict.ContainsKey("EndDate"))
                {

                    page.Where = page.Where + string.Format(" AND CreateTime <= '{0}' ", conditionDict["EndDate"]);

                }

                page.Parameters = (parameters as List<IDbDataParameter>).ToArray();
                string getCountSql = page.GetCountsSql();
                object counts = helper.GetSingle(getCountSql, page.Parameters);
                if (counts != null)
                {
                    int.TryParse(counts.ToString(), out totalRecords);
                }
                page.TotalRecords = totalRecords;

                string subStr = "(select COUNT(1) from WProductAdjShelfDetails detail where WProductAdjShelf.AdjID=detail.AdjID) TotalShelfCount ";
                IDictionary<string, object> fileds = new Dictionary<string, object>();
                fileds.Add("TotalShelfCount", subStr);
                string sql = page.GetRecordsSqlExt(ref totalPages, fileds);

                page.TotalPages = totalPages;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, page.Parameters) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        page.ItemList.Add(new WProductAdjShelf
                        {
                            AdjID = DataTypeHelper.GetString(sdr["AdjID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTimeNull(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetIntNull(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            AdjType = DataTypeHelper.GetInt(sdr["AdjType"]),
                            TotalShelfCount = DataTypeHelper.GetInt(sdr["TotalShelfCount"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"])
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.UpdateField",
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

            #region 构建查询

            if (conditionDict.ContainsKey("AdjID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "AdjID",
                        FieldValue = conditionDict["AdjID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }


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

            if (conditionDict.ContainsKey("Status"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "Status",
                        FieldValue = conditionDict["Status"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }




            #endregion

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
                return "AdjID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WProductAdjShelf列表
        /// <summary>
        /// 根据条件获取WProductAdjShelf列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WProductAdjShelf> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductAdjShelf> list = new List<WProductAdjShelf>();
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
                        list.Add(new WProductAdjShelf
                        {
                            AdjID = DataTypeHelper.GetString(sdr["AdjID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTime(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetInt(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTime(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetInt(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            AdjType = DataTypeHelper.GetInt(sdr["AdjType"]),
                            TotalShelfCount = DataTypeHelper.GetInt(sdr["TotalShelfCount"])
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjShelf.GetList",
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