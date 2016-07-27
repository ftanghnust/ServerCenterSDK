
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


namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// ### 仓库货区ShelfArea数据库访问类
    /// </summary>
    public partial class ShelfAreaDAO : BaseDAL, IShelfAreaDAO
    {
        const string tableName = "ShelfArea";


        protected override string TableName
        {
            get { return tableName; }
        }

        #region 成员方法
        #region 根据主键验证ShelfArea是否存在
        /// <summary>
        /// 根据主键验证ShelfArea是否存在
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ShelfAreaID", SqlDbType.Int)
 };
            sp[0].Value = model.ShelfAreaID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.Exists",
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


        #region 添加一个ShelfArea
        /// <summary>
        /// 添加一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(ShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@PickingMaxRecord", SqlDbType.Int),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.ShelfAreaCode;
            sp[2].Value = model.ShelfAreaName;
            sp[3].Value = model.PickingMaxRecord;
            sp[4].Value = model.SerialNumber;
            sp[5].Value = model.Remark;
            sp[6].Value = DateTime.Now;
            sp[7].Value = model.CreateUserID;
            sp[8].Value = model.CreateUserName;
            sp[9].Value = DateTime.Now;
            sp[10].Value = model.ModifyUserID;
            sp[11].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.Save",
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


        #region 更新一个ShelfArea
        /// <summary>
        /// 更新一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@PickingMaxRecord", SqlDbType.Int),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaID", SqlDbType.Int)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.ShelfAreaCode;
            sp[2].Value = model.ShelfAreaName;
            sp[3].Value = model.PickingMaxRecord;
            sp[4].Value = model.SerialNumber;
            sp[5].Value = model.Remark;
            sp[6].Value = DateTime.Now;
            sp[7].Value = model.ModifyUserID;
            sp[8].Value = model.ModifyUserName;
            sp[9].Value = model.ShelfAreaID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.Edit",
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


        #region 删除一个ShelfArea
        /// <summary>
        /// 删除一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ShelfAreaID", SqlDbType.Int)
 };
            sp[0].Value = model.ShelfAreaID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.Delete",
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


        #region 根据主键逻辑删除一个ShelfArea
        /// <summary>
        /// 根据主键逻辑删除一个ShelfArea
        /// </summary>
        /// <param name="shelfAreaID">ID(主键)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int shelfAreaID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ShelfAreaID", SqlDbType.Int)
 };
            sp[0].Value = shelfAreaID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.LogicDelete",
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


        #region 根据字典获取ShelfArea对象
        /// <summary>
        /// 根据字典获取ShelfArea对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShelfArea对象</returns>
        public ShelfArea GetModel(IDictionary<string, object> conditionDict)
        {
            ShelfArea model = null;
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
                IList<ShelfArea> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ShelfArea对象
        /// <summary>
        /// 根据主键获取ShelfArea对象
        /// </summary>
        /// <param name="shelfAreaID">ID(主键)</param>
        /// <returns>ShelfArea对象</returns>
        public ShelfArea GetModel(int shelfAreaID)
        {
            DBHelper helper = DBHelper.GetInstance();
            ShelfArea model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ShelfAreaID", SqlDbType.Int)
 };
                sp[0].Value = shelfAreaID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new ShelfArea
                        {
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ShelfAreaCode = DataTypeHelper.GetString(sdr["ShelfAreaCode"], null),
                            ShelfAreaName = DataTypeHelper.GetString(sdr["ShelfAreaName"], null),
                            PickingMaxRecord = DataTypeHelper.GetInt(sdr["PickingMaxRecord"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.GetModel",
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


        #region 根据字典获取ShelfArea集合
        /// <summary>
        /// 根据字典获取ShelfArea集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ShelfArea> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ShelfArea> list = null;
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


        #region 根据字典获取ShelfArea数据集
        /// <summary>
        /// 根据字典获取ShelfArea数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.GetDataSet",
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


        #region 分页获取ShelfArea集合
        /// <summary>
        /// 分页获取ShelfArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ShelfArea> GetPageList(PageListBySql<ShelfArea> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ShelfAreaID,WID,ShelfAreaCode,ShelfAreaName,PickingMaxRecord,SerialNumber,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new ShelfArea
                        {
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ShelfAreaCode = DataTypeHelper.GetString(sdr["ShelfAreaCode"], null),
                            ShelfAreaName = DataTypeHelper.GetString(sdr["ShelfAreaName"], null),
                            PickingMaxRecord = DataTypeHelper.GetInt(sdr["PickingMaxRecord"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null)                            
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.UpdateField",
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
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "WID",
                        FieldValue = conditionDict["WID"],
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
                return "SerialNumber";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取ShelfArea列表
        /// <summary>
        /// 根据条件获取ShelfArea列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<ShelfArea> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ShelfArea> list = new List<ShelfArea>();
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
                        list.Add(new ShelfArea
                        {
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ShelfAreaCode = DataTypeHelper.GetString(sdr["ShelfAreaCode"], null),
                            ShelfAreaName = DataTypeHelper.GetString(sdr["ShelfAreaName"], null),
                            PickingMaxRecord = DataTypeHelper.GetInt(sdr["PickingMaxRecord"]),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.GetList",
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

    public partial class ShelfAreaDAO : BaseDAL, IShelfAreaDAO
    {
        #region 根据货区编号(同一个仓库不能重复)验证货区是否存在
        /// <summary>
        /// 根据货区编号(同一个仓库不能重复)验证货区是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsShelfAreaCode(ShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsShelfAreaCode", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@ShelfAreaCode", SqlDbType.NVarChar, 100),
                    new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 100),
                    new SqlParameter("@WID", SqlDbType.NVarChar, 100),
                    new SqlParameter("@ShelfAreaID", SqlDbType.NVarChar, 100)
                };
            sp[0].Value = model.ShelfAreaCode;
            sp[1].Value = model.ShelfAreaName;
            sp[2].Value = model.WID;
            sp[3].Value = model.ShelfAreaID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfArea.ExistsShelfAreaCode",
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

        #region 根据货区编号(同一个仓库不能重复)验证货区是否使用
        /// <summary>
        /// 根据货区编号(同一个仓库不能重复)验证货区是否使用
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public IList<ShelfArea> ExistsShelfAreaCode(string ShelfAreaIDs)
        {
            IList<ShelfArea> list = null;

            string sql = " WHERE ShelfAreaID in(select ShelfAreaID from Shelf where ShelfAreaID in (" + ShelfAreaIDs + ")) ";
            try
            {
                list = GetList(sql, null);
            }
            catch (Exception)
            {               
                throw;
            }
            return list;
        }
        #endregion
    }
}