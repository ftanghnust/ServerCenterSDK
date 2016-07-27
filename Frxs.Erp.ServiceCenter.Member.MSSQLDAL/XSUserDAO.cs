
/*****************************
* Author:CR
*
* Date:2016-03-22
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Member.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Member.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Member.MSSQLDAL
{
    /// <summary>
    /// ### 兴盛用户表(B2B,O2O,线下会员)XSUser数据库访问类
    /// </summary>
    public partial class XSUserDAO : BaseDAL, IXSUserDAO
    {
        const string tableName = "XSUser";        

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证XSUser是否存在
        /// <summary>
        /// 根据主键验证XSUser是否存在
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(XSUser model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@XSUserID", SqlDbType.Int)
            };
            sp[0].Value = model.XSUserID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.Exists",
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


        #region 添加一个XSUser
        /// <summary>
        /// 添加一个XSUser
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(XSUser model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@XSUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@UserAccount", SqlDbType.VarChar, 32),
            new SqlParameter("@UserType", SqlDbType.Int),
            new SqlParameter("@UserMobile", SqlDbType.VarChar, 20),
            new SqlParameter("@Password", SqlDbType.VarChar, 128),
            new SqlParameter("@PasswordSalt", SqlDbType.VarChar, 128),
            new SqlParameter("@IsFrozen", SqlDbType.Int),
            new SqlParameter("@IsLocked", SqlDbType.Int),
            new SqlParameter("@IsDeleted", SqlDbType.Int),
            new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
            new SqlParameter("@LastPasswordChangeTime", SqlDbType.DateTime),
            new SqlParameter("@FailedPasswordCount", SqlDbType.Int),
            new SqlParameter("@FailedPasswordLockTime", SqlDbType.DateTime),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)

            };
            sp[0].Value = model.XSUserName;
            sp[1].Value = model.UserAccount;
            sp[2].Value = model.UserType;
            sp[3].Value = model.UserMobile;
            sp[4].Value = model.Password;
            sp[5].Value = model.PasswordSalt;
            sp[6].Value = model.IsFrozen;
            sp[7].Value = model.IsLocked;
            sp[8].Value = model.IsDeleted;
            sp[9].Value = model.LastLoginTime;
            sp[10].Value = model.LastPasswordChangeTime;
            sp[11].Value = model.FailedPasswordCount;
            sp[12].Value = model.FailedPasswordLockTime;
            sp[13].Value = model.CreateTime;
            sp[14].Value = model.CreateUserID;
            sp[15].Value = model.CreateUserName;
            sp[16].Value = model.ModifyTime;
            sp[17].Value = model.ModifyUserID;
            sp[18].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.Save",
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


        #region 更新一个XSUser
        /// <summary>
        /// 更新一个XSUser
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(XSUser model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@XSUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@UserAccount", SqlDbType.VarChar, 32),
            new SqlParameter("@UserType", SqlDbType.Int),
            new SqlParameter("@UserMobile", SqlDbType.VarChar, 20),
            new SqlParameter("@Password", SqlDbType.VarChar, 128),
            new SqlParameter("@PasswordSalt", SqlDbType.VarChar, 128),
            new SqlParameter("@IsFrozen", SqlDbType.Int),
            new SqlParameter("@IsLocked", SqlDbType.Int),
            new SqlParameter("@IsDeleted", SqlDbType.Int),
            new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
            new SqlParameter("@LastPasswordChangeTime", SqlDbType.DateTime),
            new SqlParameter("@FailedPasswordCount", SqlDbType.Int),
            new SqlParameter("@FailedPasswordLockTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
            new SqlParameter("@XSUserID", SqlDbType.Int)

            };
            sp[0].Value = model.XSUserName;
            sp[1].Value = model.UserAccount;
            sp[2].Value = model.UserType;
            sp[3].Value = model.UserMobile;
            sp[4].Value = model.Password;
            sp[5].Value = model.PasswordSalt;
            sp[6].Value = model.IsFrozen;
            sp[7].Value = model.IsLocked;
            sp[8].Value = model.IsDeleted;
            sp[9].Value = model.LastLoginTime;
            sp[10].Value = model.LastPasswordChangeTime;
            sp[11].Value = model.FailedPasswordCount;
            sp[12].Value = model.FailedPasswordLockTime;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.XSUserID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.Edit",
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


        #region 删除一个XSUser
        /// <summary>
        /// 删除一个XSUser
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(XSUser model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@XSUserID", SqlDbType.Int)
            };
            sp[0].Value = model.XSUserID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.Delete",
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


        #region 根据主键逻辑删除一个XSUser
        /// <summary>
        /// 根据主键逻辑删除一个XSUser
        /// </summary>
        /// <param name="xSUserID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int xSUserID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@XSUserID", SqlDbType.Int)
            };
            sp[0].Value = xSUserID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.LogicDelete",
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


        #region 根据字典获取XSUser对象
        /// <summary>
        /// 根据字典获取XSUser对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>XSUser对象</returns>
        public XSUser GetModel(IDictionary<string, object> conditionDict)
        {
            XSUser model = null;
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
                IList<XSUser> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取XSUser对象
        /// <summary>
        /// 根据主键获取XSUser对象
        /// </summary>
        /// <param name="xSUserID">用户编号</param>
        /// <returns>XSUser对象</returns>
        public XSUser GetModel(int xSUserID)
        {
            DBHelper helper = DBHelper.GetInstance();
            XSUser model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                new SqlParameter("@XSUserID", SqlDbType.Int)
            };
                sp[0].Value = xSUserID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new XSUser
                        {
                            XSUserID = DataTypeHelper.GetInt(sdr["XSUserID"]),
                            XSUserName = DataTypeHelper.GetString(sdr["XSUserName"], null),
                            UserAccount = DataTypeHelper.GetString(sdr["UserAccount"], null),
                            UserType = DataTypeHelper.GetInt(sdr["UserType"]),
                            UserMobile = DataTypeHelper.GetString(sdr["UserMobile"], null),
                            Password = DataTypeHelper.GetString(sdr["Password"], null),
                            PasswordSalt = DataTypeHelper.GetString(sdr["PasswordSalt"], null),
                            IsFrozen = DataTypeHelper.GetInt(sdr["IsFrozen"]),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            LastLoginTime = DataTypeHelper.GetDateTime(sdr["LastLoginTime"]),
                            LastPasswordChangeTime = DataTypeHelper.GetDateTime(sdr["LastPasswordChangeTime"]),
                            FailedPasswordCount = DataTypeHelper.GetInt(sdr["FailedPasswordCount"]),
                            FailedPasswordLockTime = DataTypeHelper.GetDateTime(sdr["FailedPasswordLockTime"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.GetModel",
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


        #region 根据字典获取XSUser集合
        /// <summary>
        /// 根据字典获取XSUser集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<XSUser> GetList(IDictionary<string, object> conditionDict)
        {
            IList<XSUser> list = null;
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


        #region 根据字典获取XSUser数据集
        /// <summary>
        /// 根据字典获取XSUser数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.GetDataSet",
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


        #region 分页获取XSUser集合
        /// <summary>
        /// 分页获取XSUser集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<XSUser> GetPageList(PageListBySql<XSUser> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "XSUserID,XSUserName,UserAccount,UserType,UserMobile,Password,PasswordSalt,IsFrozen,IsLocked,IsDeleted,LastLoginTime,LastPasswordChangeTime,FailedPasswordCount,FailedPasswordLockTime,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new XSUser
                        {
                            XSUserID = DataTypeHelper.GetInt(sdr["XSUserID"]),
                            XSUserName = DataTypeHelper.GetString(sdr["XSUserName"], null),
                            UserAccount = DataTypeHelper.GetString(sdr["UserAccount"], null),
                            UserType = DataTypeHelper.GetInt(sdr["UserType"]),
                            UserMobile = DataTypeHelper.GetString(sdr["UserMobile"], null),
                            Password = DataTypeHelper.GetString(sdr["Password"], null),
                            PasswordSalt = DataTypeHelper.GetString(sdr["PasswordSalt"], null),
                            IsFrozen = DataTypeHelper.GetInt(sdr["IsFrozen"]),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            LastLoginTime = DataTypeHelper.GetDateTime(sdr["LastLoginTime"]),
                            LastPasswordChangeTime = DataTypeHelper.GetDateTime(sdr["LastPasswordChangeTime"]),
                            FailedPasswordCount = DataTypeHelper.GetInt(sdr["FailedPasswordCount"]),
                            FailedPasswordLockTime = DataTypeHelper.GetDateTime(sdr["FailedPasswordLockTime"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.UpdateField",
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
                return "XSUserID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取XSUser列表
        /// <summary>
        /// 根据条件获取XSUser列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<XSUser> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<XSUser> list = new List<XSUser>();
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
                        list.Add(new XSUser
                        {
                            XSUserID = DataTypeHelper.GetInt(sdr["XSUserID"]),
                            XSUserName = DataTypeHelper.GetString(sdr["XSUserName"], null),
                            UserAccount = DataTypeHelper.GetString(sdr["UserAccount"], null),
                            UserType = DataTypeHelper.GetInt(sdr["UserType"]),
                            UserMobile = DataTypeHelper.GetString(sdr["UserMobile"], null),
                            Password = DataTypeHelper.GetString(sdr["Password"], null),
                            PasswordSalt = DataTypeHelper.GetString(sdr["PasswordSalt"], null),
                            IsFrozen = DataTypeHelper.GetInt(sdr["IsFrozen"]),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            LastLoginTime = DataTypeHelper.GetDateTime(sdr["LastLoginTime"]),
                            LastPasswordChangeTime = DataTypeHelper.GetDateTime(sdr["LastPasswordChangeTime"]),
                            FailedPasswordCount = DataTypeHelper.GetInt(sdr["FailedPasswordCount"]),
                            FailedPasswordLockTime = DataTypeHelper.GetDateTime(sdr["FailedPasswordLockTime"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.GetList",
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

    public partial class XSUserDAO : BaseDAL, IXSUserDAO
    {
        #region 根据帐号获取XSUser对象
        /// <summary>
        /// 根据帐号获取XSUser对象
        /// </summary>
        /// <param name="xSUserID">用户帐号</param>
        /// <returns>XSUser对象</returns>
        public XSUser GetModelByAccount(string UserAccount)
        {
            DBHelper helper = DBHelper.GetInstance();
            XSUser model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByAccount", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                new SqlParameter("@UserAccount", SqlDbType.VarChar, 32)
            };
                sp[0].Value = UserAccount;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new XSUser
                        {
                            XSUserID = DataTypeHelper.GetInt(sdr["XSUserID"]),
                            XSUserName = DataTypeHelper.GetString(sdr["XSUserName"], null),
                            UserAccount = DataTypeHelper.GetString(sdr["UserAccount"], null),
                            UserType = DataTypeHelper.GetInt(sdr["UserType"]),
                            UserMobile = DataTypeHelper.GetString(sdr["UserMobile"], null),
                            Password = DataTypeHelper.GetString(sdr["Password"], null),
                            PasswordSalt = DataTypeHelper.GetString(sdr["PasswordSalt"], null),
                            IsFrozen = DataTypeHelper.GetInt(sdr["IsFrozen"]),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            LastLoginTime = DataTypeHelper.GetDateTime(sdr["LastLoginTime"]),
                            LastPasswordChangeTime = DataTypeHelper.GetDateTime(sdr["LastPasswordChangeTime"]),
                            FailedPasswordCount = DataTypeHelper.GetInt(sdr["FailedPasswordCount"]),
                            FailedPasswordLockTime = DataTypeHelper.GetDateTime(sdr["FailedPasswordLockTime"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.GetModelByAccount",
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

        #region 根据帐号验证XSUser是否存在
        /// <summary>
        /// 根据帐号验证XSUser是否存在
        /// </summary>
        /// <param name="UserAccount">用户帐号</param>
        /// <returns>是否存在</returns>
        public bool ExistsAccount(string UserAccount)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsAccount", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@UserAccount", SqlDbType.VarChar, 32)
            };
            if (!string.IsNullOrWhiteSpace(UserAccount))
            {
                UserAccount = UserAccount.Trim();   //去除空白字符
            }
            sp[0].Value = UserAccount;

            try
            {
                object rst = helper.GetSingle(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Member.MSSQLDAL.XSUser.ExistsAccount",
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
    }
}