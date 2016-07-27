
/*****************************
* Author:CR
*
* Date:2016-03-15
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
    /// ### 仓库配送线路表WarehouseLine数据库访问类
    /// </summary>
    public partial class WarehouseLineDAO : BaseDAL, IWarehouseLineDAO
    {
        const string tableName = "WarehouseLine";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WarehouseLine是否存在
        /// <summary>
        /// 根据主键验证WarehouseLine是否存在
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WarehouseLine model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@LineID", SqlDbType.Int)
 };
            sp[0].Value = model.LineID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.Exists",
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


        #region 添加一个WarehouseLine
        /// <summary>
        /// 添加一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WarehouseLine model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@LineCode", SqlDbType.VarChar, 20),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@LineName", SqlDbType.NVarChar, 50),
new SqlParameter("@EmpID", SqlDbType.Int),
new SqlParameter("@SendW1", SqlDbType.Int),
new SqlParameter("@SendW2", SqlDbType.Int),
new SqlParameter("@SendW6", SqlDbType.Int),
new SqlParameter("@SendW5", SqlDbType.Int),
new SqlParameter("@SendW4", SqlDbType.Int),
new SqlParameter("@SendW3", SqlDbType.Int),
new SqlParameter("@SendW7", SqlDbType.Int),
new SqlParameter("@OrderEndTime", SqlDbType.Time, 5),
new SqlParameter("@Distance", SqlDbType.Int),
new SqlParameter("@SendNeedTime", SqlDbType.Int),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@IsLocked", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)

};
            sp[0].Value = model.LineCode;
            sp[1].Value = model.WID;
            sp[2].Value = model.LineName;
            sp[3].Value = model.EmpID;
            sp[4].Value = model.SendW1;
            sp[5].Value = model.SendW2;
            sp[6].Value = model.SendW6;
            sp[7].Value = model.SendW5;
            sp[8].Value = model.SendW4;
            sp[9].Value = model.SendW3;
            sp[10].Value = model.SendW7;
            sp[11].Value = model.OrderEndTime;
            sp[12].Value = model.Distance;
            sp[13].Value = model.SendNeedTime;
            sp[14].Value = model.SerialNumber;
            sp[15].Value = model.Remark;
            sp[16].Value = model.IsLocked;
            sp[17].Value = model.IsDeleted;
            sp[18].Value = model.CreateTime;
            sp[19].Value = model.CreateUserID;
            sp[20].Value = model.CreateUserName;
            sp[21].Value = model.ModifyTime;
            sp[22].Value = model.ModifyUserID;
            sp[23].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.Save",
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


        #region 更新一个WarehouseLine
        /// <summary>
        /// 更新一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WarehouseLine model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@LineCode", SqlDbType.VarChar, 20),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@LineName", SqlDbType.NVarChar, 50),
new SqlParameter("@EmpID", SqlDbType.Int),
new SqlParameter("@SendW1", SqlDbType.Int),
new SqlParameter("@SendW2", SqlDbType.Int),
new SqlParameter("@SendW6", SqlDbType.Int),
new SqlParameter("@SendW5", SqlDbType.Int),
new SqlParameter("@SendW4", SqlDbType.Int),
new SqlParameter("@SendW3", SqlDbType.Int),
new SqlParameter("@SendW7", SqlDbType.Int),
new SqlParameter("@OrderEndTime", SqlDbType.Time, 5),
new SqlParameter("@Distance", SqlDbType.Int),
new SqlParameter("@SendNeedTime", SqlDbType.Int),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@IsLocked", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
new SqlParameter("@LineID", SqlDbType.Int)

};
            sp[0].Value = model.LineCode;
            sp[1].Value = model.WID;
            sp[2].Value = model.LineName;
            sp[3].Value = model.EmpID;
            sp[4].Value = model.SendW1;
            sp[5].Value = model.SendW2;
            sp[6].Value = model.SendW6;
            sp[7].Value = model.SendW5;
            sp[8].Value = model.SendW4;
            sp[9].Value = model.SendW3;
            sp[10].Value = model.SendW7;
            sp[11].Value = model.OrderEndTime;
            sp[12].Value = model.Distance;
            sp[13].Value = model.SendNeedTime;
            sp[14].Value = model.SerialNumber;
            sp[15].Value = model.Remark;
            sp[16].Value = model.IsLocked;
            sp[17].Value = model.IsDeleted;
            sp[18].Value = model.ModifyTime;
            sp[19].Value = model.ModifyUserID;
            sp[20].Value = model.ModifyUserName;
            sp[21].Value = model.LineID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.Edit",
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


        #region 删除一个WarehouseLine
        /// <summary>
        /// 删除一个WarehouseLine
        /// </summary>
        /// <param name="model">WarehouseLine对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WarehouseLine model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@LineID", SqlDbType.Int)
 };
            sp[0].Value = model.LineID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.Delete",
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


        #region 根据主键逻辑删除一个WarehouseLine
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseLine
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(WarehouseLine model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@LineID", SqlDbType.Int),
  new SqlParameter("@ModifyTime", SqlDbType.DateTime),
 new SqlParameter("@ModifyUserID", SqlDbType.Int),
 new SqlParameter("@ModifyUserName", SqlDbType.NVarChar,50)
 };
            sp[0].Value = model.LineID;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.LogicDelete",
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


        #region 根据字典获取WarehouseLine对象
        /// <summary>
        /// 根据字典获取WarehouseLine对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseLine对象</returns>
        public WarehouseLine GetModel(IDictionary<string, object> conditionDict)
        {
            WarehouseLine model = null;
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
                IList<WarehouseLine> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WarehouseLine对象
        /// <summary>
        /// 根据主键获取WarehouseLine对象
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>WarehouseLine对象</returns>
        public WarehouseLine GetModel(int lineID)
        {
            DBHelper helper = DBHelper.GetInstance();
            WarehouseLine model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@LineID", SqlDbType.Int)
 };
                sp[0].Value = lineID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WarehouseLine
                        {
                            LineID = DataTypeHelper.GetInt(sdr["LineID"]),
                            LineCode = DataTypeHelper.GetString(sdr["LineCode"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            EmpID = DataTypeHelper.GetInt(sdr["EmpID"]),
                            SendW1 = DataTypeHelper.GetInt(sdr["SendW1"]),
                            SendW2 = DataTypeHelper.GetInt(sdr["SendW2"]),
                            SendW6 = DataTypeHelper.GetInt(sdr["SendW6"]),
                            SendW5 = DataTypeHelper.GetInt(sdr["SendW5"]),
                            SendW4 = DataTypeHelper.GetInt(sdr["SendW4"]),
                            SendW3 = DataTypeHelper.GetInt(sdr["SendW3"]),
                            SendW7 = DataTypeHelper.GetInt(sdr["SendW7"]),
                            OrderEndTime = DataTypeHelper.GetTimeSpan(sdr["OrderEndTime"]),
                            Distance = DataTypeHelper.GetInt(sdr["Distance"]),
                            SendNeedTime = DataTypeHelper.GetInt(sdr["SendNeedTime"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            EmpName = DataTypeHelper.GetString(sdr["EmpName"], null),
                            UserMobile = DataTypeHelper.GetString(sdr["UserMobile"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.GetModel",
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


        #region 根据字典获取WarehouseLine集合
        /// <summary>
        /// 根据字典获取WarehouseLine集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WarehouseLine> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WarehouseLine> list = null;
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


        #region 根据字典获取WarehouseLine数据集
        /// <summary>
        /// 根据字典获取WarehouseLine数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.GetDataSet",
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


        #region 分页获取WarehouseLine集合
        /// <summary>
        /// 分页获取WarehouseLine集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WarehouseLine> GetPageList(PageListBySql<WarehouseLine> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = "(select a.*,b.EmpName,b.UserMobile,isnull(c.ShopNum,0) as ShopNum from WarehouseLine a left join WarehouseEmp b on a.EmpID=b.EmpID  left join (select COUNT(shopid) ShopNum,lineid from WarehouseLineShop GROUP BY lineid) c on a.LineID=c.LineID where a.IsDeleted=0) a ";
                page.Fields = "LineID,LineCode,WID,LineName,EmpID,SendW1,SendW2,SendW6,SendW5,SendW4,SendW3,SendW7,OrderEndTime,Distance,SendNeedTime,SerialNumber,Remark,IsLocked,IsDeleted,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,EmpName,UserMobile,ShopNum";
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
                    WarehouseLine model = null;
                    while (sdr.Read())
                    {
                        model = new WarehouseLine();
                        model.LineID = DataTypeHelper.GetInt(sdr["LineID"]);
                        model.LineCode = DataTypeHelper.GetString(sdr["LineCode"], null);
                        model.WID = DataTypeHelper.GetInt(sdr["WID"]);
                        model.LineName = DataTypeHelper.GetString(sdr["LineName"], null);
                        model.EmpID = DataTypeHelper.GetInt(sdr["EmpID"]);
                        model.SendW1 = DataTypeHelper.GetInt(sdr["SendW1"]);
                        model.SendW2 = DataTypeHelper.GetInt(sdr["SendW2"]);
                        model.SendW6 = DataTypeHelper.GetInt(sdr["SendW6"]);
                        model.SendW5 = DataTypeHelper.GetInt(sdr["SendW5"]);
                        model.SendW4 = DataTypeHelper.GetInt(sdr["SendW4"]);
                        model.SendW3 = DataTypeHelper.GetInt(sdr["SendW3"]);
                        model.SendW7 = DataTypeHelper.GetInt(sdr["SendW7"]);
                        model.OrderEndTime = DataTypeHelper.GetTimeSpan(sdr["OrderEndTime"]);
                        model.Distance = DataTypeHelper.GetInt(sdr["Distance"]);
                        model.SendNeedTime = DataTypeHelper.GetInt(sdr["SendNeedTime"]);
                        model.SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]);
                        model.Remark = DataTypeHelper.GetString(sdr["Remark"], null);
                        model.IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]);
                        model.IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]);
                        model.CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]);
                        model.CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]);
                        model.CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"],null);
                        model.ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]);
                        model.ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]);
                        model.ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null);
                        model.EmpName = DataTypeHelper.GetString(sdr["EmpName"], null);
                        model.UserMobile = DataTypeHelper.GetString(sdr["UserMobile"],null);
                        model.ShopNum = DataTypeHelper.GetInt(sdr["ShopNum"]);
                        model.SendW = getSendW(DataTypeHelper.GetInt(sdr["SendW1"]), DataTypeHelper.GetInt(sdr["SendW2"]), DataTypeHelper.GetInt(sdr["SendW3"]), DataTypeHelper.GetInt(sdr["SendW4"]), DataTypeHelper.GetInt(sdr["SendW5"]), DataTypeHelper.GetInt(sdr["SendW6"]), DataTypeHelper.GetInt(sdr["SendW7"]));
                       
                        page.ItemList.Add(model);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.GetPageList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return page;
        }

        public string getSendW(int sendW1,int sendW2,int sendW3,int sendW4,int sendW5,int sendW6,int sendW7)
        {
            string sendw="";
            if (sendW1 == 1)
            {
                sendw += "一,";
            }
            if (sendW2 == 1)
            {
                sendw += "二,";
            }
            if (sendW3 == 1)
            {
                sendw += "三,";
            }
            if (sendW4 == 1)
            {
                sendw += "四,";
            }
            if (sendW5 == 1)
            {
                sendw += "五,";
            }
            if (sendW6== 1)
            {
                sendw += "六,";
            }
            if (sendW7 == 1)
            {
                sendw += "日,";
            }
            if(sendw.Length>1)
            sendw = sendw.Substring(0, sendw.Length - 1);
            return sendw;
            
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.UpdateField",
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

            if (conditionDict.ContainsKey("WID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "wid",
                        FieldValue = conditionDict["WID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("LineName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "LineName",
                        FieldValue = conditionDict["LineName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

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

            if (conditionDict.ContainsKey("UserMobile"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "UserMobile",
                        FieldValue = conditionDict["UserMobile"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("SendW"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = conditionDict["SendW"].ToString(),
                        FieldValue = 1,
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
                return "SerialNumber ";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WarehouseLine列表
        /// <summary>
        /// 根据条件获取WarehouseLine列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WarehouseLine> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WarehouseLine> list = new List<WarehouseLine>();
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
                        list.Add(new WarehouseLine
                        {
                            LineID = DataTypeHelper.GetInt(sdr["LineID"]),
                            LineCode = DataTypeHelper.GetString(sdr["LineCode"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            EmpID = DataTypeHelper.GetInt(sdr["EmpID"]),
                            SendW1 = DataTypeHelper.GetInt(sdr["SendW1"]),
                            SendW2 = DataTypeHelper.GetInt(sdr["SendW2"]),
                            SendW6 = DataTypeHelper.GetInt(sdr["SendW6"]),
                            SendW5 = DataTypeHelper.GetInt(sdr["SendW5"]),
                            SendW4 = DataTypeHelper.GetInt(sdr["SendW4"]),
                            SendW3 = DataTypeHelper.GetInt(sdr["SendW3"]),
                            SendW7 = DataTypeHelper.GetInt(sdr["SendW7"]),
                            OrderEndTime = DataTypeHelper.GetTimeSpan(sdr["OrderEndTime"]),
                            Distance = DataTypeHelper.GetInt(sdr["Distance"]),
                            SendNeedTime = DataTypeHelper.GetInt(sdr["SendNeedTime"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.GetList",
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

    public partial class WarehouseLineDAO : BaseDAL, IWarehouseLineDAO
    {
        #region 根据送货线路ID验证是否存在
        /// <summary>
        /// 根据送货线路ID验证是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsWarehouseLineCode(WarehouseLine model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsWarehouseLineCode", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@LineCode", SqlDbType.NVarChar, 100),   
                    new SqlParameter("@WID", SqlDbType.NVarChar, 100),
                    new SqlParameter("@LineID", SqlDbType.NVarChar, 100),
                    new SqlParameter("@LineName", SqlDbType.NVarChar, 100)
                };
            sp[0].Value = model.LineCode;
            sp[1].Value = model.WID;
            if (model.LineID == 0)
            {
                sp[2].Value = "";
            }
            else
            {
                sp[2].Value = model.LineID;
            }
            sp[3].Value = model.LineName;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.ExistsWarehouseLineCode",
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

        #region 根据主键获取WarehouseLine对象
        /// <summary>
        /// 根据主键获取WarehouseLine对象
        /// </summary>
        /// <param name="lineID">主键(ID)</param>
        /// <returns>WarehouseLine对象</returns>
        public WarehouseLine GetShopModel(int ShopID)
        {
            DBHelper helper = DBHelper.GetInstance();
            WarehouseLine model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetShopModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ShopID", SqlDbType.Int)
 };
                sp[0].Value = ShopID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WarehouseLine
                        {
                            LineID = DataTypeHelper.GetInt(sdr["LineID"]),
                            LineCode = DataTypeHelper.GetString(sdr["LineCode"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            EmpID = DataTypeHelper.GetInt(sdr["EmpID"]),
                            SendW1 = DataTypeHelper.GetInt(sdr["SendW1"]),
                            SendW2 = DataTypeHelper.GetInt(sdr["SendW2"]),
                            SendW6 = DataTypeHelper.GetInt(sdr["SendW6"]),
                            SendW5 = DataTypeHelper.GetInt(sdr["SendW5"]),
                            SendW4 = DataTypeHelper.GetInt(sdr["SendW4"]),
                            SendW3 = DataTypeHelper.GetInt(sdr["SendW3"]),
                            SendW7 = DataTypeHelper.GetInt(sdr["SendW7"]),
                            OrderEndTime = DataTypeHelper.GetTimeSpan(sdr["OrderEndTime"]),
                            Distance = DataTypeHelper.GetInt(sdr["Distance"]),
                            SendNeedTime = DataTypeHelper.GetInt(sdr["SendNeedTime"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WarehouseLine.GetModel",
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
    }
}