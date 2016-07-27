using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;
/*****************************
* Author:chujl
*
* Date:2016-03-23
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
    /// ### 仓库消息表WarehouseMessage数据库访问类
    /// </summary>
    public partial class WarehouseMessageDAO : BaseDAL, IWarehouseMessageDAO
    {
        const string tableName = "WarehouseMessage";

        public WarehouseMessageDAO(string warehouseId)
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
        #region 根据主键验证WarehouseMessage是否存在
        /// <summary>
        /// 根据主键验证WarehouseMessage是否存在
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WarehouseMessage model)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.Exists",
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


        #region 添加一个WarehouseMessage
        /// <summary>
        /// 添加一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WarehouseMessage model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Title", SqlDbType.NVarChar,50),
new SqlParameter("@MessageType", SqlDbType.Int),
new SqlParameter("@RangType", SqlDbType.Int),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@Message", SqlDbType.NText),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@IsFirst", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModityTime", SqlDbType.DateTime),
new SqlParameter("@ModityUserID", SqlDbType.Int),
new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Title;
            sp[2].Value = model.MessageType;
            sp[3].Value = model.RangType;
            sp[4].Value = model.BeginTime;
            sp[5].Value = model.EndTime;
            sp[6].Value = model.Message;
            sp[7].Value = model.Status;
            sp[8].Value = model.IsFirst;
            sp[9].Value = model.CreateTime;
            sp[10].Value = model.CreateUserID;
            sp[11].Value = model.CreateUserName;
            sp[12].Value = model.ModityTime;
            sp[13].Value = model.ModityUserID;
            sp[14].Value = model.ModityUserName;

            try
            {
                object o = new object();
                if (conn == null && trans == null)
                {
                    o = helper.GetSingle(sql, sp);
                }
                else
                {
                    o = helper.GetSingle(conn, trans, sql, sp);
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.Save",
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
        /// 添加一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WarehouseMessage model)
        {
            //DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            //int result = 0;
            //string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);




            //try
            //{
            //    object o = helper.ExecNonQuery(sql, sp);
            //    if (o != null)
            //    {
            //        bool isSuccess = int.TryParse(o.ToString(), out result);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
            //    Logger.GetInstance().DBOperatingLog
            //    (
            //    new NormalLog
            //    {
            //        LogSource = helper.DataSource,
            //        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.Save",
            //        LogContent = exceptionSql,
            //        LogTime = DateTime.Now
            //    },
            //    ex
            //    );
            //    throw;
            //}

            //return result;
            return 0;
        }
        #endregion


        #region 更新一个WarehouseMessage
        /// <summary>
        /// 更新一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WarehouseMessage model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Title", SqlDbType.VarChar,50),
new SqlParameter("@MessageType", SqlDbType.Int),
new SqlParameter("@RangType", SqlDbType.Int),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@Message", SqlDbType.NText),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 32),
new SqlParameter("@IsFirst", SqlDbType.Int),
new SqlParameter("@ModityTime", SqlDbType.DateTime),
new SqlParameter("@ModityUserID", SqlDbType.Int),
new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.Int)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Title;
            sp[2].Value = model.MessageType;
            sp[3].Value = model.RangType;
            sp[4].Value = model.BeginTime;
            sp[5].Value = model.EndTime;
            sp[6].Value = model.Message;
            sp[7].Value = model.Status;
            sp[8].Value = model.ConfTime;
            sp[9].Value = model.ConfUserID;
            sp[10].Value = model.ConfUserName;
            sp[11].Value = model.IsFirst;
            sp[12].Value = model.ModityTime;
            sp[13].Value = model.ModityUserID;
            sp[14].Value = model.ModityUserName;
            sp[15].Value = model.ID;

            try
            {
                object o = helper.ExecNonQuery(sql, sp);

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.Edit",
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
        /// 更新一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WarehouseMessage model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Title", SqlDbType.VarChar,50),
new SqlParameter("@MessageType", SqlDbType.Int),
new SqlParameter("@RangType", SqlDbType.Int),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@Message", SqlDbType.NText),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 32),
new SqlParameter("@IsFirst", SqlDbType.Int),
new SqlParameter("@ModityTime", SqlDbType.DateTime),
new SqlParameter("@ModityUserID", SqlDbType.Int),
new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.Int)
};
            sp[0].Value = model.WID;
            sp[1].Value = model.Title;
            sp[2].Value = model.MessageType;
            sp[3].Value = model.RangType;
            sp[4].Value = model.BeginTime;
            sp[5].Value = model.EndTime;
            sp[6].Value = model.Message;
            sp[7].Value = model.Status;
            sp[8].Value = model.ConfTime;
            sp[9].Value = model.ConfUserID;
            sp[10].Value = model.ConfUserName;
            sp[11].Value = model.IsFirst;
            sp[12].Value = model.ModityTime;
            sp[13].Value = model.ModityUserID;
            sp[14].Value = model.ModityUserName;
            sp[15].Value = model.ID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.Edit",
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


        #region 删除一个WarehouseMessage
        /// <summary>
        /// 删除一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WarehouseMessage model)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.Delete",
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


        #region 根据主键逻辑删除一个WarehouseMessage
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessage
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.LogicDelete",
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
        /// 根据主键逻辑删除一个WarehouseMessage
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int iD, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.Int)
 };
            sp[0].Value = iD;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.LogicDelete",
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


        #region 根据字典获取WarehouseMessage对象
        /// <summary>
        /// 根据字典获取WarehouseMessage对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseMessage对象</returns>
        public WarehouseMessage GetModel(IDictionary<string, object> conditionDict)
        {
            WarehouseMessage model = null;
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
                IList<WarehouseMessage> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WarehouseMessage对象
        /// <summary>
        /// 根据主键获取WarehouseMessage对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WarehouseMessage对象</returns>
        public WarehouseMessage GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            WarehouseMessage model = null;
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
                        model = new WarehouseMessage
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Title = DataTypeHelper.GetString(sdr["Title"]),
                            MessageType = DataTypeHelper.GetInt(sdr["MessageType"]),
                            RangType = DataTypeHelper.GetInt(sdr["RangType"]),
                            BeginTime = DataTypeHelper.GetDateTime(sdr["BeginTime"]),
                            EndTime = DataTypeHelper.GetDateTime(sdr["EndTime"]),
                            Message = DataTypeHelper.GetString(sdr["Message"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            IsFirst = DataTypeHelper.GetInt(sdr["IsFirst"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTime(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null),
                            IsFirstStr = DataTypeHelper.GetInt(sdr["IsFirst"]) == 0 ? "否" : "是",
                            MessageTypeStr = DataTypeHelper.GetInt(sdr["MessageType"]) == 0 ? "重要消息" : (DataTypeHelper.GetInt(sdr["MessageType"]) == 1 ? "促销" : "其他"),  //TODO 此处需要改为取数据字典值
                            RangTypeStr = DataTypeHelper.GetInt(sdr["RangType"]) == 0 ? "全部门店" : "指定群组",
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? "未发布" : (DataTypeHelper.GetInt(sdr["Status"]) == 1 ? "已发布" : "已停止")
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.GetModel",
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


        #region 根据字典获取WarehouseMessage集合
        /// <summary>
        /// 根据字典获取WarehouseMessage集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WarehouseMessage> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WarehouseMessage> list = null;
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


        #region 根据字典获取WarehouseMessage数据集
        /// <summary>
        /// 根据字典获取WarehouseMessage数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.GetDataSet",
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


        #region 分页获取WarehouseMessage集合
        /// <summary>
        /// 分页获取WarehouseMessage集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WarehouseMessage> GetPageList(PageListBySql<WarehouseMessage> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,WID,Title,MessageType,RangType,BeginTime,EndTime,Message,Status,ConfTime,ConfUserID,ConfUserName,IsFirst,CreateTime,CreateUserID,CreateUserName,ModityTime,ModityUserID,ModityUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);
                if (conditionDict.ContainsKey("RangType")) 
                {

                    if (conditionDict.ContainsKey("BeginTime"))
                    {
                        page.Where = page.Where + string.Format(" and BeginTime>='{0}' ", conditionDict["BeginTime"]);
                    }
                    if (conditionDict.ContainsKey("EndTime"))
                    {
                        page.Where = page.Where + string.Format(" and BeginTime<='{0}' ", conditionDict["EndTime"]);
                    }

                }

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
                        page.ItemList.Add(new WarehouseMessage
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Title = DataTypeHelper.GetString(sdr["Title"]),
                            MessageType = DataTypeHelper.GetInt(sdr["MessageType"]),
                            RangType = DataTypeHelper.GetInt(sdr["RangType"]),
                            BeginTime = DataTypeHelper.GetDateTimeNull(sdr["BeginTime"]),
                            EndTime = DataTypeHelper.GetDateTimeNull(sdr["EndTime"]),
                            Message = DataTypeHelper.GetString(sdr["Message"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            IsFirst = DataTypeHelper.GetInt(sdr["IsFirst"]),
                            CreateTime = DataTypeHelper.GetDateTimeNull(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTimeNull(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null),
                            IsFirstStr = DataTypeHelper.GetInt(sdr["IsFirst"]) == 0 ? "否" : "是",
                            MessageTypeStr = DataTypeHelper.GetInt(sdr["MessageType"]) == 0 ? "重要消息" : (DataTypeHelper.GetInt(sdr["MessageType"]) == 1 ? "促销" : "其他"),
                            RangTypeStr = DataTypeHelper.GetInt(sdr["RangType"]) == 0 ? "全部门店" : "指定群组",
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? "未发布" : (DataTypeHelper.GetInt(sdr["Status"]) == 1 ? "已发布" : "已停止")

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.UpdateField",
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
            #region
            if (conditionDict.ContainsKey("MessageType"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "MessageType",
                        FieldValue = conditionDict["MessageType"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("Title"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "Title",
                        FieldValue = conditionDict["Title"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("ConfUserName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ConfUserName",
                        FieldValue = conditionDict["ConfUserName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
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

            if ( ! conditionDict.ContainsKey("RangType")) //此处用于B2B
            {
                if (conditionDict.ContainsKey("BeginTime"))
                {
                    whereConditionList.Add(
                    new WhereCondition
                    {
                        AttachSymbol = Attach.And,
                        CompareSymbol = Compare.LessThanOrEquals,
                        FieldObj = new Field
                        {
                            FieldName = "BeginTime",
                            FieldValue = conditionDict["BeginTime"],
                            FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                        }
                    });
                }



                if (conditionDict.ContainsKey("EndTime"))
                {
                    whereConditionList.Add(
                    new WhereCondition
                    {
                        AttachSymbol = Attach.And,
                        CompareSymbol = Compare.MoreThanOrEquals,
                        FieldObj = new Field
                        {
                            FieldName = "EndTime",
                            FieldValue = conditionDict["EndTime"],
                            FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                        }
                    });
                }
            }


            if (true)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "WID",
                        ParamterName = "WIDStr",
                        FieldValue = base.WarehouseId,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });

            }
            #endregion


            string result = new WhereCondition().GetWhereCondition(whereConditionList, ref parameters);
            where.Append(result);

            if (conditionDict.ContainsKey("GroupIDList"))
            {
                where.Append(" and ( RangType=0 or ID in (select WarehouseMessageID from WarehouseMessageShops where GroupID in(" + conditionDict["GroupIDList"] + ") ))");
            }
            else
            {
                if (conditionDict.ContainsKey("RangType"))
                {
                }
                else
                {
                    where.Append(" and  RangType=0 ");
                }
            }



            if (conditionDict.ContainsKey("SearchTime"))
            {
                where.Append(" and DATEDIFF(DAY,BeginTime,'" + DateTime.Now + "')<= " + conditionDict["SearchTime"]);
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


        #region 根据条件获取WarehouseMessage列表
        /// <summary>
        /// 根据条件获取WarehouseMessage列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WarehouseMessage> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WarehouseMessage> list = new List<WarehouseMessage>();
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
                        list.Add(new WarehouseMessage
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Title = DataTypeHelper.GetString(sdr["Title"]),
                            MessageType = DataTypeHelper.GetInt(sdr["MessageType"]),
                            RangType = DataTypeHelper.GetInt(sdr["RangType"]),
                            BeginTime = DataTypeHelper.GetDateTime(sdr["BeginTime"]),
                            EndTime = DataTypeHelper.GetDateTime(sdr["EndTime"]),
                            Message = DataTypeHelper.GetString(sdr["Message"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTime(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetInt(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            IsFirst = DataTypeHelper.GetInt(sdr["IsFirst"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTime(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null),
                            IsFirstStr = DataTypeHelper.GetInt(sdr["IsFirst"]) == 0 ? "否" : "是",
                            MessageTypeStr = DataTypeHelper.GetInt(sdr["MessageType"]) == 0 ? "重要消息" : (DataTypeHelper.GetInt(sdr["MessageType"]) == 1 ? "促销" : "其他"),  //TODO 此处需要改为取数据字典值
                            RangTypeStr = DataTypeHelper.GetInt(sdr["RangType"]) == 0 ? "全部门店" : "指定群组",
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? "未发布" : (DataTypeHelper.GetInt(sdr["Status"]) == 1 ? "已发布" : "已停止")


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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WarehouseMessage.GetList",
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