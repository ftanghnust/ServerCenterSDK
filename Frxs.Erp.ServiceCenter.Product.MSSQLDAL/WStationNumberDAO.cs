
/*****************************
* Author:CR
*
* Date:2016-04-05
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
    /// ### 仓库待装区表WStationNumber数据库访问类
    /// </summary>
    public partial class WStationNumberDAO : BaseDAL, IWStationNumberDAO
    {
        const string tableName = "WStationNumber";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WStationNumber是否存在
        /// <summary>
        /// 根据主键验证WStationNumber是否存在
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WStationNumber model)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.Exists",
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


        #region 添加一个WStationNumber
        /// <summary>
        /// 添加一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WStationNumber model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderConfDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@OrderStatus", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.StationNumber;
            sp[2].Value = model.Status;
            sp[3].Value = model.ShopID;
            sp[4].Value = model.OrderID;
            sp[5].Value = model.OrderConfDate;
            sp[6].Value = model.LineID;
            sp[7].Value = model.OrderStatus;
            sp[8].Value = DateTime.Now;
            sp[9].Value = model.CreateUserID;
            sp[10].Value = model.CreateUserName;
            sp[11].Value = DateTime.Now;
            sp[12].Value = model.ModifyUserID;
            sp[13].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.Save",
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


        #region 更新一个WStationNumber
        /// <summary>
        /// 更新一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WStationNumber model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderConfDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@OrderStatus", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.Int)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.StationNumber;
            sp[2].Value = model.Status;
            sp[3].Value = model.ShopID;
            sp[4].Value = model.OrderID;
            sp[5].Value = model.OrderConfDate;
            sp[6].Value = model.LineID;
            sp[7].Value = model.OrderStatus;
            sp[8].Value = model.ModifyTime;
            sp[9].Value = model.ModifyUserID;
            sp[10].Value = model.ModifyUserName;
            sp[11].Value = model.ID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.Edit",
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

        #region 更新一个WStationNumber中的线路信息
        /// <summary>
        /// 更新一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        public int EditLineInfo(WStationNumber model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditLineInfo", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int)

};
            sp[0].Value = model.LineID;
            sp[1].Value = model.ModifyUserID;
            sp[2].Value = model.ModifyUserName;
            sp[3].Value = model.StationNumber;
            sp[4].Value = model.WID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.EditLineInfo",
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


        #region 删除一个WStationNumber
        /// <summary>
        /// 删除一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WStationNumber model)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.Delete",
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


        #region 根据主键逻辑删除一个WStationNumber
        /// <summary>
        /// 根据主键逻辑删除一个WStationNumber
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(WStationNumber model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.Int),
  new SqlParameter("@ModifyTime", SqlDbType.DateTime),
 new SqlParameter("@ModifyUserID", SqlDbType.Int),
 new SqlParameter("@ModifyUserName", SqlDbType.NVarChar,50),
      new SqlParameter("@Status", SqlDbType.Int)
 };
            sp[0].Value = model.ID;
            sp[1].Value = DateTime.Now;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;
            sp[4].Value = model.Status;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.LogicDelete",
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


        #region 根据字典获取WStationNumber对象
        /// <summary>
        /// 根据字典获取WStationNumber对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WStationNumber对象</returns>
        public WStationNumber GetModel(IDictionary<string, object> conditionDict)
        {
            WStationNumber model = null;
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
                IList<WStationNumber> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WStationNumber对象
        /// <summary>
        /// 根据主键获取WStationNumber对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WStationNumber对象</returns>
        public WStationNumber GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            WStationNumber model = null;
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
                        model = new WStationNumber
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            StationNumber = DataTypeHelper.GetInt(sdr["StationNumber"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            OrderID = DataTypeHelper.GetString(sdr["OrderID"], null),
                            OrderConfDate = DataTypeHelper.GetDateTime(sdr["OrderConfDate"]),
                            LineID = DataTypeHelper.GetInt(sdr["LineID"]),
                            OrderStatus = DataTypeHelper.GetInt(sdr["OrderStatus"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.GetModel",
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


        #region 根据字典获取WStationNumber集合
        /// <summary>
        /// 根据字典获取WStationNumber集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WStationNumber> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WStationNumber> list = null;
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


        #region 根据字典获取WStationNumber数据集
        /// <summary>
        /// 根据字典获取WStationNumber数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.GetDataSet",
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


        #region 分页获取WStationNumber集合
        /// <summary>
        /// 分页获取WStationNumber集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WStationNumber> GetPageList(PageListBySql<WStationNumber> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = "(select a.ID,a.WID,a.StationNumber,a.Status,a.OrderID,a.OrderConfDate,b.ShopCode,b.ShopName,c.LineName,d.EmpName,a.OrderStatus from WStationNumber a left join shop b on a.ShopID=b.ShopID left join WarehouseLine c on a.LineID=c.LineID left join WarehouseEmp d on c.EmpID=d.EmpID) a";
                page.Fields = "ID,WID,StationNumber,Status,OrderID,OrderConfDate,ShopCode,ShopName,LineName,EmpName,OrderStatus";
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
                        page.ItemList.Add(new WStationNumber
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            StationNumber = DataTypeHelper.GetInt(sdr["StationNumber"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            OrderID = DataTypeHelper.GetString(sdr["OrderID"], null),
                            OrderConfDate = DataTypeHelper.GetDateTimeNull(sdr["OrderConfDate"], null),
                            OrderStatus = DataTypeHelper.GetInt(sdr["OrderStatus"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            EmpName = DataTypeHelper.GetString(sdr["EmpName"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.UpdateField",
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

            if (conditionDict.ContainsKey("ShopCode"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ShopCode",
                        FieldValue = conditionDict["ShopCode"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("ShopName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ShopName",
                        FieldValue = conditionDict["ShopName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("StationNumber"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "StationNumber",
                        FieldValue = conditionDict["StationNumber"],
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
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                    }
                });
            }

            if (conditionDict.ContainsKey("OrderStatus"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "OrderStatus",
                        FieldValue = conditionDict["OrderStatus"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
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
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
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
                return "StationNumber";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WStationNumber列表
        /// <summary>
        /// 根据条件获取WStationNumber列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WStationNumber> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WStationNumber> list = new List<WStationNumber>();
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
                        list.Add(new WStationNumber
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            StationNumber = DataTypeHelper.GetInt(sdr["StationNumber"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            OrderID = DataTypeHelper.GetString(sdr["OrderID"], null),
                            OrderConfDate = DataTypeHelper.GetDateTime(sdr["OrderConfDate"]),
                            LineID = DataTypeHelper.GetInt(sdr["LineID"]),
                            OrderStatus = DataTypeHelper.GetInt(sdr["OrderStatus"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.GetList",
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

    public partial class WStationNumberDAO : BaseDAL, IWStationNumberDAO
    {
        #region
        /// <summary>
        /// 验证是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsWStationNumber(WStationNumber model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsWStationNumber", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@StationNumber", SqlDbType.Int),
                    new SqlParameter("@WID", SqlDbType.Int)                   
                };

            sp[0].Value = model.StationNumber;
            sp[1].Value = model.WID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WStationNumber.ExistsWStationNumber",
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

        #region

        /// <summary>
        /// 清空订单数据
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public int ResetWStationNumberExt(WStationNumber model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ResetWStationNumberExt", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                    new SqlParameter("@OrderID", SqlDbType.NVarChar,50),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int)
                                };
            sp[0].Value = model.OrderID;
            sp[1].Value = DateTime.Now;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;
            sp[4].Value = model.Status;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WStationNumber.ExistsWStationNumber",
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
        /// 清空订单数据
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public int ResetWStationNumber(WStationNumber model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ResetWStationNumber", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                    new SqlParameter("@ID", SqlDbType.Int),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int)
                                };
            sp[0].Value = model.ID;
            sp[1].Value = DateTime.Now;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;
            sp[4].Value = model.Status;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WStationNumber.ExistsWStationNumber",
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
        /// 清空订单数据
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public int ResetWStationNumberByOrderId(WStationNumber model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ResetWStationNumberByOrderId", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,50),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Status", SqlDbType.Int)
                                };
            sp[0].Value = model.OrderID;
            sp[1].Value = DateTime.Now;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;
            sp[4].Value = model.Status;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WStationNumber.ExistsWStationNumber",
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

    /// <summary>
    /// ### 仓库待装区表WStationNumber数据库访问类
    /// 龙武
    /// </summary>
    public partial class WStationNumberDAO : BaseDAL, IWStationNumberDAO
    {
        /// <summary>
        /// 根据仓库编号获取空闲待装区
        /// </summary>
        /// <param name="wId">仓库编号</param>
        /// <returns></returns>
        public WStationNumber GetFreeStationNumber(int wId)
        {
            DBHelper helper = DBHelper.GetInstance();
            WStationNumber models = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetFreeStationNumber", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParam = new SqlParameter[] { 
                    new SqlParameter("@WID",SqlDbType.Int)
                };
                sParam[0].Value = wId;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sParam) as SqlDataReader)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            models = new WStationNumber
                            {
                                ID = DataTypeHelper.GetInt(sdr["ID"]),
                                WID = DataTypeHelper.GetInt(sdr["WID"]),
                                StationNumber = DataTypeHelper.GetInt(sdr["StationNumber"])
                            };
                        }
                    }
                    return models;
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WStationNumber.GetFreeStation",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        /// <summary>
        /// 拣货完成还原待装区数据
        /// </summary>
        /// <param name="userId">操作人编号</param>
        /// <param name="userName">操作人姓名</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public bool UpdateStationNumberIsNull(int status, int orderStatus, int userId, string userName, string orderId)
        {
            DBHelper helper = DBHelper.GetInstance();
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UpdateStationNumberByOrderID", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sParam = new SqlParameter[] { 
                new SqlParameter("@Status",status),
                new SqlParameter("@OrderStatus",orderStatus),
                new SqlParameter("@ModifyUserID",userId),
                new SqlParameter("@ModifyUserName",userName),
                new SqlParameter("@OrderID",orderId)
            };
            int result = helper.ExecNonQuery(sql, sParam);
            return result > 0;
        }
    }
}