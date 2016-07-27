
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
    /// ### 仓库--广告、橱窗信息表WAdvertisement数据库访问类
    /// </summary>
    public partial class WAdvertisementDAO : BaseDAL, IWAdvertisementDAO
    {
        const string tableName = "WAdvertisement";

        public WAdvertisementDAO(string warehouseId)
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
        #region 根据主键验证WAdvertisement是否存在
        /// <summary>
        /// 根据主键验证WAdvertisement是否存在
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WAdvertisement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AdvertisementID", SqlDbType.Int)
 };
            sp[0].Value = model.AdvertisementID;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.Exists",
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


        #region 添加一个WAdvertisement
        /// <summary>
        /// 添加一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WAdvertisement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@AdvertisementPosition", SqlDbType.Int),
new SqlParameter("@AdvertisementName", SqlDbType.VarChar, 32),
new SqlParameter("@Sort", SqlDbType.Int),
new SqlParameter("@ImagesSrc", SqlDbType.VarChar, 128),
new SqlParameter("@SelectImagesSrc", SqlDbType.VarChar, 128),
new SqlParameter("@AdvertisementType", SqlDbType.Int),
new SqlParameter("@IsDelete", SqlDbType.Int),
new SqlParameter("@IsLocked", SqlDbType.Int),
new SqlParameter("@StartTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModityTime", SqlDbType.DateTime),
new SqlParameter("@ModityUserID", SqlDbType.Int),
new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.AdvertisementPosition;
            sp[2].Value = model.AdvertisementName;
            sp[3].Value = model.Sort;
            sp[4].Value = model.ImagesSrc;
            sp[5].Value = model.SelectImagesSrc;
            sp[6].Value = model.AdvertisementType;
            sp[7].Value = model.IsDelete;
            sp[8].Value = model.IsLocked;
            sp[9].Value = model.StartTime;
            sp[10].Value = model.EndTime;
            sp[11].Value = model.CreateTime;
            sp[12].Value = model.CreateUserID;
            sp[13].Value = model.CreateUserName;
            sp[14].Value = model.ModityTime;
            sp[15].Value = model.ModityUserID;
            sp[16].Value = model.ModityUserName;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.Save",
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


        #region 更新一个WAdvertisement
        /// <summary>
        /// 更新一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WAdvertisement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@AdvertisementPosition", SqlDbType.Int),
new SqlParameter("@AdvertisementName", SqlDbType.VarChar, 32),
new SqlParameter("@Sort", SqlDbType.Int),
new SqlParameter("@ImagesSrc", SqlDbType.VarChar, 128),
new SqlParameter("@SelectImagesSrc", SqlDbType.VarChar, 128),
new SqlParameter("@AdvertisementType", SqlDbType.Int),
new SqlParameter("@IsDelete", SqlDbType.Int),
new SqlParameter("@IsLocked", SqlDbType.Int),
new SqlParameter("@StartTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@ModityTime", SqlDbType.DateTime),
new SqlParameter("@ModityUserID", SqlDbType.Int),
new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AdvertisementID", SqlDbType.Int)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.AdvertisementPosition;
            sp[2].Value = model.AdvertisementName;
            sp[3].Value = model.Sort;
            sp[4].Value = model.ImagesSrc;
            sp[5].Value = model.SelectImagesSrc;
            sp[6].Value = model.AdvertisementType;
            sp[7].Value = model.IsDelete;
            sp[8].Value = model.IsLocked;
            sp[9].Value = model.StartTime;
            sp[10].Value = model.EndTime;
            sp[11].Value = model.ModityTime;
            sp[12].Value = model.ModityUserID;
            sp[13].Value = model.ModityUserName;
            sp[14].Value = model.AdvertisementID;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.Edit",
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


        #region 删除一个WAdvertisement
        /// <summary>
        /// 删除一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WAdvertisement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdvertisementID", SqlDbType.Int)
 };
            sp[0].Value = model.AdvertisementID;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.Delete",
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


        #region 根据主键逻辑删除一个WAdvertisement
        /// <summary>
        /// 根据主键逻辑删除一个WAdvertisement
        /// </summary>
        /// <param name="advertisementID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int advertisementID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdvertisementID", SqlDbType.Int)
 };
            sp[0].Value = advertisementID;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.LogicDelete",
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
        public int LogicDelete(int advertisementID, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdvertisementID", SqlDbType.Int)
 };
            sp[0].Value = advertisementID;

            try
            {
                result = helper.ExecNonQuery(conn, trans, sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.LogicDelete",
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


        #region 根据字典获取WAdvertisement对象
        /// <summary>
        /// 根据字典获取WAdvertisement对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WAdvertisement对象</returns>
        public WAdvertisement GetModel(IDictionary<string, object> conditionDict)
        {
            WAdvertisement model = null;
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
                IList<WAdvertisement> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WAdvertisement对象
        /// <summary>
        /// 根据主键获取WAdvertisement对象
        /// </summary>
        /// <param name="advertisementID">主键ID</param>
        /// <returns>WAdvertisement对象</returns>
        public WAdvertisement GetModel(int advertisementID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            WAdvertisement model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@AdvertisementID", SqlDbType.Int)
 };
                sp[0].Value = advertisementID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WAdvertisement
                        {
                            AdvertisementID = DataTypeHelper.GetInt(sdr["AdvertisementID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            AdvertisementPosition = DataTypeHelper.GetInt(sdr["AdvertisementPosition"]),
                            AdvertisementName = DataTypeHelper.GetString(sdr["AdvertisementName"], null),
                            Sort = DataTypeHelper.GetInt(sdr["Sort"]),
                            ImagesSrc = DataTypeHelper.GetString(sdr["ImagesSrc"], null),
                            SelectImagesSrc = DataTypeHelper.GetString(sdr["SelectImagesSrc"], null),
                            AdvertisementType = DataTypeHelper.GetInt(sdr["AdvertisementType"]),
                            IsDelete = DataTypeHelper.GetInt(sdr["IsDelete"]),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            StartTime = DataTypeHelper.GetDateTime(sdr["StartTime"]),
                            EndTime = DataTypeHelper.GetDateTime(sdr["EndTime"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTime(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.GetModel",
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


        #region 根据字典获取WAdvertisement集合
        /// <summary>
        /// 根据字典获取WAdvertisement集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WAdvertisement> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WAdvertisement> list = null;
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


        #region 根据字典获取WAdvertisement数据集
        /// <summary>
        /// 根据字典获取WAdvertisement数据集
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.GetDataSet",
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


        #region 分页获取WAdvertisement集合
        /// <summary>
        /// 分页获取WAdvertisement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WAdvertisement> GetPageList(PageListBySql<WAdvertisement> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "AdvertisementID,WID,AdvertisementPosition,AdvertisementName,Sort,ImagesSrc,SelectImagesSrc,AdvertisementType,IsDelete,IsLocked,StartTime,EndTime,CreateTime,CreateUserID,CreateUserName,ModityTime,ModityUserID,ModityUserName";
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
                        page.ItemList.Add(new WAdvertisement
                        {
                            AdvertisementID = DataTypeHelper.GetInt(sdr["AdvertisementID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            AdvertisementPosition = DataTypeHelper.GetInt(sdr["AdvertisementPosition"]),
                            AdvertisementName = DataTypeHelper.GetString(sdr["AdvertisementName"], null),
                            Sort = DataTypeHelper.GetInt(sdr["Sort"]),
                            ImagesSrc = DataTypeHelper.GetString(sdr["ImagesSrc"], null),
                            SelectImagesSrc = DataTypeHelper.GetString(sdr["SelectImagesSrc"], null),
                            AdvertisementType = DataTypeHelper.GetInt(sdr["AdvertisementType"]),
                            IsDelete = DataTypeHelper.GetInt(sdr["IsDelete"]),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            StartTime = DataTypeHelper.GetDateTime(sdr["StartTime"]),
                            EndTime = DataTypeHelper.GetDateTime(sdr["EndTime"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTime(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.UpdateField",
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
            if (conditionDict.ContainsKey("IsDelete"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "IsDelete",
                        FieldValue = conditionDict["IsDelete"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("EffectiveTime"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.LessThanOrEquals,
                    FieldObj = new Field
                    {
                        FieldName = "StartTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)                        
                    }
                });

                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.MoreThanOrEquals,
                    FieldObj = new Field
                    {
                        FieldName = "EndTime",
                        FieldValue = DateTime.Now,
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)                        
                    }
                });
            }

            if (conditionDict.ContainsKey("AdvertisementPosition"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "AdvertisementPosition",
                        FieldValue = conditionDict["AdvertisementPosition"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
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
                return "AdvertisementID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WAdvertisement列表
        /// <summary>
        /// 根据条件获取WAdvertisement列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WAdvertisement> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WAdvertisement> list = new List<WAdvertisement>();
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
                        list.Add(new WAdvertisement
                        {
                            AdvertisementID = DataTypeHelper.GetInt(sdr["AdvertisementID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            AdvertisementPosition = DataTypeHelper.GetInt(sdr["AdvertisementPosition"]),
                            AdvertisementName = DataTypeHelper.GetString(sdr["AdvertisementName"], null),
                            Sort = DataTypeHelper.GetInt(sdr["Sort"]),
                            ImagesSrc = DataTypeHelper.GetString(sdr["ImagesSrc"], null),
                            SelectImagesSrc = DataTypeHelper.GetString(sdr["SelectImagesSrc"], null),
                            AdvertisementType = DataTypeHelper.GetInt(sdr["AdvertisementType"]),
                            IsDelete = DataTypeHelper.GetInt(sdr["IsDelete"]),
                            IsLocked = DataTypeHelper.GetInt(sdr["IsLocked"]),
                            StartTime = DataTypeHelper.GetDateTime(sdr["StartTime"]),
                            EndTime = DataTypeHelper.GetDateTime(sdr["EndTime"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTime(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.GetList",
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

    public partial class WAdvertisementDAO : BaseDAL, IWAdvertisementDAO
    {
        #region 添加一个WAdvertisement 事务操作
        /// <summary>
        /// 添加一个WAdvertisement 事务操作
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WAdvertisement model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@AdvertisementPosition", SqlDbType.Int),
            new SqlParameter("@AdvertisementName", SqlDbType.VarChar, 32),
            new SqlParameter("@Sort", SqlDbType.Int),
            new SqlParameter("@ImagesSrc", SqlDbType.VarChar, 128),
            new SqlParameter("@SelectImagesSrc", SqlDbType.VarChar, 128),
            new SqlParameter("@AdvertisementType", SqlDbType.Int),
            new SqlParameter("@IsDelete", SqlDbType.Int),
            new SqlParameter("@IsLocked", SqlDbType.Int),
            new SqlParameter("@StartTime", SqlDbType.DateTime),
            new SqlParameter("@EndTime", SqlDbType.DateTime),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@ModityTime", SqlDbType.DateTime),
            new SqlParameter("@ModityUserID", SqlDbType.Int),
            new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.WID;
            sp[1].Value = model.AdvertisementPosition;
            sp[2].Value = model.AdvertisementName;
            sp[3].Value = model.Sort;
            sp[4].Value = model.ImagesSrc;
            sp[5].Value = model.SelectImagesSrc;
            sp[6].Value = model.AdvertisementType;
            sp[7].Value = model.IsDelete;
            sp[8].Value = model.IsLocked;
            sp[9].Value = model.StartTime;
            sp[10].Value = model.EndTime;
            sp[11].Value = model.CreateTime;
            sp[12].Value = model.CreateUserID;
            sp[13].Value = model.CreateUserName;
            sp[14].Value = model.ModityTime;
            sp[15].Value = model.ModityUserID;
            sp[16].Value = model.ModityUserName;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.Save",
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

        #region 更新一个WAdvertisement 事务操作
        /// <summary>
        /// 更新一个WAdvertisement 事务操作
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WAdvertisement model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@AdvertisementPosition", SqlDbType.Int),
            new SqlParameter("@AdvertisementName", SqlDbType.VarChar, 32),
            new SqlParameter("@Sort", SqlDbType.Int),
            new SqlParameter("@ImagesSrc", SqlDbType.VarChar, 128),
            new SqlParameter("@SelectImagesSrc", SqlDbType.VarChar, 128),
            new SqlParameter("@AdvertisementType", SqlDbType.Int),
            new SqlParameter("@IsDelete", SqlDbType.Int),
            new SqlParameter("@IsLocked", SqlDbType.Int),
            new SqlParameter("@StartTime", SqlDbType.DateTime),
            new SqlParameter("@EndTime", SqlDbType.DateTime),
            new SqlParameter("@ModityTime", SqlDbType.DateTime),
            new SqlParameter("@ModityUserID", SqlDbType.Int),
            new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@AdvertisementID", SqlDbType.Int)

            };
            sp[0].Value = model.WID;
            sp[1].Value = model.AdvertisementPosition;
            sp[2].Value = model.AdvertisementName;
            sp[3].Value = model.Sort;
            sp[4].Value = model.ImagesSrc;
            sp[5].Value = model.SelectImagesSrc;
            sp[6].Value = model.AdvertisementType;
            sp[7].Value = model.IsDelete;
            sp[8].Value = model.IsLocked;
            sp[9].Value = model.StartTime;
            sp[10].Value = model.EndTime;
            sp[11].Value = model.ModityTime;
            sp[12].Value = model.ModityUserID;
            sp[13].Value = model.ModityUserName;
            sp[14].Value = model.AdvertisementID;

            try
            {
                object o = new object();
                if (conn == null && tran == null)
                {
                    o = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    o = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.Edit",
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


        #region 删除一个WAdvertisement 事务操作
        /// <summary>
        /// 删除一个WAdvertisement 事务操作
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WAdvertisement model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
             new SqlParameter("@AdvertisementID", SqlDbType.Int)
             };
            sp[0].Value = model.AdvertisementID;

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
                    LogOperation = "Frxs.ServiceCenter.Promotion.MSSQLDAL.WAdvertisement.Delete",
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