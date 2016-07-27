
/*****************************
* Author:CR
*
* Date:2016-03-09
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
using Frxs.Platform.Utility;


namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// ### 仓库用户员工表WarehouseEmp数据库访问类
    /// </summary>
    public partial class WarehouseEmpDAO : BaseDAL, IWarehouseEmpDAO
    {
        const string tableName = "WarehouseEmp";

        protected override string TableName
        {
            get { return tableName; }
        }

        #region 成员方法
        #region 根据主键验证WarehouseEmp是否存在
        /// <summary>
        /// 根据主键验证WarehouseEmp是否存在
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WarehouseEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@EmpID", SqlDbType.Int)
 };
            sp[0].Value = model.EmpID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.Exists",
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


        #region 添加一个WarehouseEmp
        /// <summary>
        /// 添加一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WarehouseEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@EmpName", SqlDbType.VarChar, 32),
new SqlParameter("@UserAccount", SqlDbType.VarChar, 32),
new SqlParameter("@UserType", SqlDbType.Int),
new SqlParameter("@IsMaster", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@UserMobile", SqlDbType.VarChar, 20),
new SqlParameter("@Password", SqlDbType.VarChar, 128),
new SqlParameter("@PasswordSalt", SqlDbType.VarChar, 128),
new SqlParameter("@IsFrozen", SqlDbType.Int),
new SqlParameter("@IsLocked", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)

};
            sp[0].Value = model.EmpName;
            sp[1].Value = model.UserAccount;
            sp[2].Value = model.UserType;
            sp[3].Value = model.IsMaster;
            sp[4].Value = model.WID;
            sp[5].Value = model.UserMobile;
            sp[6].Value = model.Password;
            sp[7].Value = model.PasswordSalt;
            sp[8].Value = model.IsFrozen;
            sp[9].Value = model.IsLocked;
            sp[10].Value = model.IsDeleted;
            sp[11].Value = DateTime.Now;
            sp[12].Value = model.CreateUserID;
            sp[13].Value = model.CreateUserName;
            sp[14].Value = DateTime.Now;
            sp[15].Value = model.ModifyUserID;
            sp[16].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.Save",
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


        #region 更新一个WarehouseEmp
        /// <summary>
        /// 更新一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WarehouseEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@EmpName", SqlDbType.VarChar, 32),
new SqlParameter("@UserAccount", SqlDbType.VarChar, 32),
new SqlParameter("@UserType", SqlDbType.Int),
new SqlParameter("@IsMaster", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@UserMobile", SqlDbType.VarChar, 20),
new SqlParameter("@IsFrozen", SqlDbType.Int),
new SqlParameter("@IsLocked", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@EmpID", SqlDbType.Int)

};
            sp[0].Value = model.EmpName;
            sp[1].Value = model.UserAccount;
            sp[2].Value = model.UserType;
            sp[3].Value = model.IsMaster;
            sp[4].Value = model.WID;
            sp[5].Value = model.UserMobile;
            sp[6].Value = model.IsFrozen;
            sp[7].Value = model.IsLocked;
            sp[8].Value = model.IsDeleted;
            sp[9].Value = DateTime.Now;
            sp[10].Value = model.ModifyUserID;
            sp[11].Value = model.ModifyUserName;
            sp[12].Value = model.EmpID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.Edit",
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


        #region 删除一个WarehouseEmp
        /// <summary>
        /// 删除一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WarehouseEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@EmpID", SqlDbType.Int)
 };
            sp[0].Value = model.EmpID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.Delete",
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


        #region 根据主键逻辑删除一个WarehouseEmp
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseEmp
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(WarehouseEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@EmpID", SqlDbType.Int),
 new SqlParameter("@ModifyTime", SqlDbType.DateTime),
 new SqlParameter("@ModifyUserID", SqlDbType.Int),
 new SqlParameter("@ModifyUserName", SqlDbType.NVarChar,50)
 };
            sp[0].Value = model.EmpID;
            sp[1].Value = DateTime.Now;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.LogicDelete",
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

        #region 根据主键冻结或解冻一个WarehouseEmp
        /// <summary>
        /// 根据主键冻结或解冻一个WarehouseEmp
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        public int LogicIsFrozenDelete(WarehouseEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicIsFrozenDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@EmpID", SqlDbType.Int),
 new SqlParameter("@ModifyTime", SqlDbType.DateTime),
 new SqlParameter("@ModifyUserID", SqlDbType.Int),
 new SqlParameter("@ModifyUserName", SqlDbType.NVarChar,50),
      new SqlParameter("@IsFrozen", SqlDbType.Int)
 };
            sp[0].Value = model.EmpID;
            sp[1].Value = DateTime.Now;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;
            sp[4].Value = model.IsFrozen;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.LogicDelete",
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


        #region 根据字典获取WarehouseEmp对象
        /// <summary>
        /// 根据字典获取WarehouseEmp对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseEmp对象</returns>
        public WarehouseEmp GetModel(IDictionary<string, object> conditionDict)
        {
            WarehouseEmp model = null;
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
                IList<WarehouseEmp> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WarehouseEmp对象
        /// <summary>
        /// 根据主键获取WarehouseEmp对象
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>WarehouseEmp对象</returns>
        public WarehouseEmp GetModel(int empID)
        {
            DBHelper helper = DBHelper.GetInstance();
            WarehouseEmp model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@EmpID", SqlDbType.Int)
 };
                sp[0].Value = empID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WarehouseEmp
                        {
                            EmpID = DataTypeHelper.GetInt(sdr["EmpID"]),
                            EmpName = DataTypeHelper.GetString(sdr["EmpName"], null),
                            UserAccount = DataTypeHelper.GetString(sdr["UserAccount"], null),
                            UserType = DataTypeHelper.GetInt(sdr["UserType"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.GetModel",
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


        #region 根据字典获取WarehouseEmp集合
        /// <summary>
        /// 根据字典获取WarehouseEmp集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WarehouseEmp> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WarehouseEmp> list = null;
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


        #region 根据字典获取WarehouseEmp数据集
        /// <summary>
        /// 根据字典获取WarehouseEmp数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.GetDataSet",
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


        #region 分页获取WarehouseEmp集合
        /// <summary>
        /// 分页获取WarehouseEmp集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WarehouseEmp> GetPageList(PageListBySql<WarehouseEmp> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = ("(select a.*,b.WName from WarehouseEmp a inner join (select WID,WName from Warehouse where ParentWID=" + conditionDict["WID"] + ") b on a.WID =b.WID and a.IsDeleted=0) a ");
                page.Fields = "EmpID,EmpName,UserAccount,UserType,IsMaster,WID,UserMobile,Password,PasswordSalt,IsFrozen,IsLocked,IsDeleted,LastLoginTime,LastPasswordChangeTime,FailedPasswordCount,FailedPasswordLockTime,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,WName";
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
                        page.ItemList.Add(new WarehouseEmp
                        {
                            EmpID = DataTypeHelper.GetInt(sdr["EmpID"]),
                            EmpName = DataTypeHelper.GetString(sdr["EmpName"], null),
                            UserAccount = DataTypeHelper.GetString(sdr["UserAccount"], null),
                            UserType = DataTypeHelper.GetInt(sdr["UserType"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
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
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            StatusStr = DataTypeHelper.GetInt(sdr["IsFrozen"]) == 1 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            UserTypeStr = DataTypeHelper.GetInt(sdr["UserType"]) == 1 ? ConstDefinition.ERP_BASEDATA_USERTYPE_PICKING : DataTypeHelper.GetInt(sdr["UserType"]) == 2 ? ConstDefinition.ERP_BASEDATA_USERTYPE_MARKI : DataTypeHelper.GetInt(sdr["UserType"]) == 3 ? ConstDefinition.ERP_BASEDATA_USERTYPE_MEMBER : ConstDefinition.ERP_BASEDATA_USERTYPE_PURCHASE

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.UpdateField",
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

            if (conditionDict.ContainsKey("EmpName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "EmpName",
                        FieldValue = conditionDict["EmpName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("UserType"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "UserType",
                        FieldValue = conditionDict["UserType"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("UserAccount"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "UserAccount",
                        FieldValue = conditionDict["UserAccount"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("IsFrozen"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "IsFrozen",
                        FieldValue = conditionDict["IsFrozen"],
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
                return "ModifyTime desc";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WarehouseEmp列表
        /// <summary>
        /// 根据条件获取WarehouseEmp列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WarehouseEmp> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WarehouseEmp> list = new List<WarehouseEmp>();
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
                        list.Add(new WarehouseEmp
                        {
                            EmpID = DataTypeHelper.GetInt(sdr["EmpID"]),
                            EmpName = DataTypeHelper.GetString(sdr["EmpName"], null),
                            UserAccount = DataTypeHelper.GetString(sdr["UserAccount"], null),
                            UserType = DataTypeHelper.GetInt(sdr["UserType"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.GetList",
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

    public partial class WarehouseEmpDAO : BaseDAL, IWarehouseEmpDAO
    {
        #region 根据货区编号(同一个仓库不能重复)验证货区是否存在
        /// <summary>
        /// 根据货区编号(同一个仓库不能重复)验证货区是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsWarehouseEmpCode(WarehouseEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsWarehouseEmpCode", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@EmpID", SqlDbType.NVarChar, 100),
                    new SqlParameter("@UserAccount", SqlDbType.NVarChar, 100)                     
                };
            if (model.EmpID == 0)
            {
                sp[0].Value = "";
            }
            else
            {
                sp[0].Value = model.EmpID;
            }
            sp[1].Value = model.UserAccount;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.ExistsWarehouseEmpCode",
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

        #region 根据主键重置密码
        /// <summary>
        /// 根据主键重置密码
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        public int EditResetPassWord(WarehouseEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditResetPassWord", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@EmpID", SqlDbType.Int),
 new SqlParameter("@ModifyTime", SqlDbType.DateTime),
 new SqlParameter("@ModifyUserID", SqlDbType.Int),
 new SqlParameter("@ModifyUserName", SqlDbType.NVarChar,50),
      new SqlParameter("@Password", SqlDbType.VarChar,100),
      new SqlParameter("@PasswordSalt", SqlDbType.VarChar,100)
 };
            sp[0].Value = model.EmpID;
            sp[1].Value = DateTime.Now;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;
            sp[4].Value = model.Password;
            sp[5].Value = model.PasswordSalt;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.LogicDelete",
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

        #region 检查账户关系
        /// <summary>
        /// 检查账户关系
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public string ExistsWarehouseEmp(int EmpID, int num)
        {
            DBHelper helper = DBHelper.GetInstance();
            string result = string.Empty;
            try
            {
                string sql = string.Empty;

                if (num == 2)
                {
                    sql = "select top 1 '送货线路管理' as typename from WarehouseLine where EmpID=@EmpID and IsDeleted=0";
                }
                if (num == 1)
                {
                    sql = "select top 1 '拣货员管理' as typename from WarehouseEmpShelf a inner join dbo.Shelf b on a.ShelfID=b.ShelfID where EmpID=@EmpID";
                }
                if (num == 4)
                {
                    sql = "select top 1 '采购员商品管理' as typename from WProductsBuyEmp a inner join dbo.WProducts b on a.WProductID=b.WProductID  where EmpID=@EmpID";
                }

                SqlParameter[] sp =
                {
                    new SqlParameter("@EmpID", SqlDbType.NVarChar, 100)
                                      
                };

                sp[0].Value = EmpID;


                result = helper.GetSingle(sql, sp) == null ? string.Empty : helper.GetSingle(sql, sp).ToString();
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion

    }

    /// <summary>
    /// ### 仓库用户员工表WarehouseEmp数据库访问类
    /// 龙武
    /// </summary>
    public partial class WarehouseEmpDAO : BaseDAL, IWarehouseEmpDAO
    {
        /// <summary>
        /// 登录-查询信息
        /// </summary>
        /// <param name="userAccout">帐号</param>
        /// <returns></returns>
        public WarehouseEmpInfo PickingLogin(string userAccount, int userType)
        {
            DBHelper helper = DBHelper.GetInstance();
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "PickingLogin", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sParam = new SqlParameter[] { 
                new SqlParameter("@UserAccount",SqlDbType.NVarChar),
                new SqlParameter("@UserType",SqlDbType.Int)
            };
            sParam[0].Value = userAccount;
            sParam[1].Value = userType;
            try
            {
                WarehouseEmpInfo empInfo = null;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sParam) as SqlDataReader)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            empInfo = new WarehouseEmpInfo
                            {
                                EmpID = Utils.StrToInt(sdr["EmpID"], 0),
                                EmpName = sdr["EmpName"].ToString(),
                                UserType = Utils.StrToInt(sdr["UserType"], 0),
                                PasswordSalt = sdr["PasswordSalt"].ToString(),
                                Password = sdr["Password"].ToString(),
                                WID = Utils.StrToInt(sdr["ParentWID"], 0) == 0 ? Utils.StrToInt(sdr["WID"], 0) : Utils.StrToInt(sdr["ParentWID"], 0),//Utils.StrToInt(sdr["WID"], 0),
                                ShelfAreaID = Utils.StrToInt(sdr["ShelfAreaID"], 0),
                                IsFrozen = Utils.StrToInt(sdr["IsFrozen"], 0),
                                IsLocked = Utils.StrToInt(sdr["IsLocked"], 0),
                                IsDeleted = Utils.StrToInt(sdr["IsDeleted"], 0),
                                ShelfAreaCode = sdr["ShelfAreaCode"].ToString(),
                                ShelfAreaName = sdr["ShelfAreaName"].ToString(),
                                PickingMaxRecord = Utils.StrToInt(sdr["PickingMaxRecord"], 0),
                                IsMaster = Utils.StrToInt(sdr["IsMaster"], 0),
                                UserMobile = sdr["UserMobile"].ToString(),
                                WareHouseWID = Utils.StrToInt(sdr["WID"], 0),
                                Remark = sdr["Remark"].ToString()
                            };
                        }
                    }
                    return empInfo;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.PickingLogin",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }


        /// <summary>
        /// 登录-查询信息
        /// </summary>
        /// <param name="userAccout">帐号</param>
        /// <returns></returns>
        public WarehouseEmpInfo DeliverLogin(string userAccount, int userType)
        {
            DBHelper helper = DBHelper.GetInstance();
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeliverLogin", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sParam = new SqlParameter[] { 
                new SqlParameter("@UserAccount",SqlDbType.NVarChar),
                new SqlParameter("@UserType",SqlDbType.Int)
            };
            sParam[0].Value = userAccount;
            sParam[1].Value = userType;
            try
            {
                WarehouseEmpInfo empInfo = null;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sParam) as SqlDataReader)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            empInfo = new WarehouseEmpInfo
                            {
                                EmpID = Utils.StrToInt(sdr["EmpID"], 0),
                                EmpName = sdr["EmpName"].ToString(),
                                WID = Utils.StrToInt(sdr["WID"], 0),
                                UserMobile = sdr["UserMobile"].ToString(),
                                IsMaster = Utils.StrToInt(sdr["IsMaster"], 0),
                                UserType = Utils.StrToInt(sdr["UserType"], 0),
                                PasswordSalt = sdr["PasswordSalt"].ToString(),
                                Password = sdr["Password"].ToString(),
                                IsFrozen = Utils.StrToInt(sdr["IsFrozen"], 0),
                                IsLocked = Utils.StrToInt(sdr["IsLocked"], 0),
                                IsDeleted = Utils.StrToInt(sdr["IsDeleted"], 0),
                                WareHouseWID = Utils.StrToInt(sdr["ParentWID"], 0) == 0 ? Utils.StrToInt(sdr["WID"], 0) : Utils.StrToInt(sdr["ParentWID"], 0)
                            };
                        }
                    }
                    return empInfo;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.DeliverLogin",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        /// <summary>
        /// 根据登录名获取用户信息
        /// </summary>
        /// <param name="userAccount">登录帐号</param>
        /// <returns>用户对象</returns>
        public WarehouseEmp PickingGetModelByAccount(string userAccount, int userType)
        {
            DBHelper helper = DBHelper.GetInstance();
            WarehouseEmp model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByUserAccount", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParam = new SqlParameter[] { 
                new SqlParameter("@UserAccount",SqlDbType.NVarChar),
                new SqlParameter("@UserType",SqlDbType.Int)
            };
                sParam[0].Value = userAccount;
                sParam[1].Value = userType;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sParam) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WarehouseEmp
                        {
                            EmpID = DataTypeHelper.GetInt(sdr["EmpID"]),
                            EmpName = DataTypeHelper.GetString(sdr["EmpName"], null),
                            UserAccount = DataTypeHelper.GetString(sdr["UserAccount"], null),
                            UserType = DataTypeHelper.GetInt(sdr["UserType"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
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
                return model;
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.PickingGetModelByAccount",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }


        /// <summary>
        /// 根据商品编号获取制定仓库中用户名和用户编号
        /// </summary>
        /// <param name="productIds">商品编号-多个商品编号请用,隔开(如:1,2,3,4)</param>
        /// <param name="wId">仓库编号</param>
        /// <returns></returns>
        public List<WarehouseEmp> GetPickUsersByProductId(string productIds, int wId, int userId)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string[] strProducts = productIds.Split(',');
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetPickUsersByProductId", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParam = new SqlParameter[] { 
                    new SqlParameter("@WID",SqlDbType.Int),
                    new SqlParameter("@UserId",SqlDbType.Int)
                };
                sParam[0].Value = wId;
                sParam[1].Value = userId;
                string tempSql = string.Empty;
                if (strProducts.Length > 0)
                {
                    foreach (string item in strProducts)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                        {
                            tempSql += " ProductId=" + item + " OR";
                        }
                    }
                }
                if (tempSql.Length > 0)
                {
                    sql += " AND (" + tempSql + ")";
                    sql = sql.Remove(sql.LastIndexOf("OR"), 2);
                }
                string strSql = "SELECT EmpID,N.EmpName,N.ProductId FROM ( " + sql + ") N WHERE N.RowNumber=1 ORDER BY N.ProductId,N.RowNumber";
                List<WarehouseEmp> modelList = null;
                using (SqlDataReader sdr = helper.GetIDataReader(strSql, sParam) as SqlDataReader)
                {
                    if (sdr.HasRows)
                    {
                        modelList = new List<WarehouseEmp>();
                        while (sdr.Read())
                        {
                            WarehouseEmp model = new WarehouseEmp();
                            model.EmpID = DataTypeHelper.GetInt(sdr["EmpID"]);
                            model.EmpName = DataTypeHelper.GetString(sdr["EmpName"], null);
                            model.ProductID = DataTypeHelper.GetInt(sdr["ProductID"]);
                            modelList.Add(model);
                        }
                    }
                    return modelList;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseEmp.GetPickUsersByProductId",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        /// <summary>
        /// 查询登录用户是否存在该货位信息
        /// </summary>
        /// <param name="empId">用户编号</param>
        /// <param name="shelfCode">货位编号</param>
        /// <returns></returns>
        public bool CheckShelfOfLogin(int empId, string shelfCode)
        {
            DBHelper helper = DBHelper.GetInstance();
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "CheckShelfOfLogin", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sParam = new SqlParameter[] { 
                new SqlParameter("@EmpID",SqlDbType.Int),
                new SqlParameter("@ShelfCode",SqlDbType.NVarChar)
            };
            sParam[0].Value = empId;
            sParam[1].Value = shelfCode;
            int result = Utils.StrToInt(helper.GetSingle(sql, sParam), 0);
            return result > 0;
        }
    }


}