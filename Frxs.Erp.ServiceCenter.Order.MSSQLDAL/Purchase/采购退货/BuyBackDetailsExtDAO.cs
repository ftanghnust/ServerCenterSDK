
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### BuyBackDetailsExt数据库访问类
    /// </summary>
    public partial class BuyBackDetailsExtDAO : BaseDAL, IBuyBackDetailsExtDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BuyBackDetailsExtDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BuyBackDetailsExtDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "BuyBackDetailsExt";

        #region 成员方法
        #region 根据主键验证BuyBackDetailsExt是否存在
        /// <summary>
        /// 根据主键验证BuyBackDetailsExt是否存在
        /// </summary>
        /// <param name="model">BuyBackDetailsExt对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(BuyBackDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.Exists",
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


        #region 事务添加一个BuyBackPreDetailsExt
        /// <summary>
        /// 添加一个BuyBackPreDetailsExt
        /// </summary>
        /// <param name="model">BuyBackDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(BuyBackPreDetailsExt model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@ID", SqlDbType.VarChar, 50),
                                new SqlParameter("@CategoryId1", SqlDbType.Int),
                                new SqlParameter("@CategoryId1Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@CategoryId2", SqlDbType.Int),
                                new SqlParameter("@CategoryId2Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@CategoryId3", SqlDbType.Int),
                                new SqlParameter("@CategoryId3Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@ShopCategoryId1", SqlDbType.Int),
                                new SqlParameter("@ShopCategoryId1Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@ShopCategoryId2", SqlDbType.Int),
                                new SqlParameter("@ShopCategoryId2Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@ShopCategoryId3", SqlDbType.Int),
                                new SqlParameter("@ShopCategoryId3Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@BrandId1", SqlDbType.Int),
                                new SqlParameter("@BrandId1Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@BrandId2", SqlDbType.Int),
                                new SqlParameter("@BrandId2Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36)

                                };
            sp[0].Value = model.ID;
            sp[1].Value = model.CategoryId1;
            sp[2].Value = model.CategoryId1Name;
            sp[3].Value = model.CategoryId2;
            sp[4].Value = model.CategoryId2Name;
            sp[5].Value = model.CategoryId3;
            sp[6].Value = model.CategoryId3Name;
            sp[7].Value = model.ShopCategoryId1;
            sp[8].Value = model.ShopCategoryId1Name;
            sp[9].Value = model.ShopCategoryId2;
            sp[10].Value = model.ShopCategoryId2Name;
            sp[11].Value = model.ShopCategoryId3;
            sp[12].Value = model.ShopCategoryId3Name;
            sp[13].Value = model.BrandId1;
            sp[14].Value = model.BrandId1Name;
            sp[15].Value = model.BrandId2;
            sp[16].Value = model.BrandId2Name;
            sp[17].Value = model.ModifyTime;
            sp[18].Value = model.ModifyUserID;
            sp[19].Value = model.ModifyUserName;
            sp[20].Value = model.BackID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.Save",
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


        #region 更新一个BuyBackDetailsExt
        /// <summary>
        /// 更新一个BuyBackDetailsExt
        /// </summary>
        /// <param name="model">BuyBackDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(BuyBackDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@CategoryId1", SqlDbType.Int),
new SqlParameter("@CategoryId1Name", SqlDbType.NVarChar, 100),
new SqlParameter("@CategoryId2", SqlDbType.Int),
new SqlParameter("@CategoryId2Name", SqlDbType.NVarChar, 100),
new SqlParameter("@CategoryId3", SqlDbType.Int),
new SqlParameter("@CategoryId3Name", SqlDbType.NVarChar, 100),
new SqlParameter("@ShopCategoryId1", SqlDbType.Int),
new SqlParameter("@ShopCategoryId1Name", SqlDbType.NVarChar, 100),
new SqlParameter("@ShopCategoryId2", SqlDbType.Int),
new SqlParameter("@ShopCategoryId2Name", SqlDbType.NVarChar, 100),
new SqlParameter("@ShopCategoryId3", SqlDbType.Int),
new SqlParameter("@ShopCategoryId3Name", SqlDbType.NVarChar, 100),
new SqlParameter("@BrandId1", SqlDbType.Int),
new SqlParameter("@BrandId1Name", SqlDbType.NVarChar, 100),
new SqlParameter("@BrandId2", SqlDbType.Int),
new SqlParameter("@BrandId2Name", SqlDbType.NVarChar, 100),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.CategoryId1;
            sp[1].Value = model.CategoryId1Name;
            sp[2].Value = model.CategoryId2;
            sp[3].Value = model.CategoryId2Name;
            sp[4].Value = model.CategoryId3;
            sp[5].Value = model.CategoryId3Name;
            sp[6].Value = model.ShopCategoryId1;
            sp[7].Value = model.ShopCategoryId1Name;
            sp[8].Value = model.ShopCategoryId2;
            sp[9].Value = model.ShopCategoryId2Name;
            sp[10].Value = model.ShopCategoryId3;
            sp[11].Value = model.ShopCategoryId3Name;
            sp[12].Value = model.BrandId1;
            sp[13].Value = model.BrandId1Name;
            sp[14].Value = model.BrandId2;
            sp[15].Value = model.BrandId2Name;
            sp[16].Value = model.ModifyTime;
            sp[17].Value = model.ModifyUserID;
            sp[18].Value = model.ModifyUserName;
            sp[19].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.Edit",
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


        #region 删除一个BuyBackDetailsExt
        /// <summary>
        /// 删除一个BuyBackDetailsExt
        /// </summary>
        /// <param name="model">BuyBackDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(BuyBackDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.Delete",
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


        #region 根据主键逻辑删除一个BuyBackDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个BuyBackDetailsExt
        /// </summary>
        /// <param name="iD">编号(BuyBackDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.LogicDelete",
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


        #region 根据字典获取BuyBackDetailsExt对象
        /// <summary>
        /// 根据字典获取BuyBackDetailsExt对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BuyBackDetailsExt对象</returns>
        public BuyBackDetailsExt GetModel(IDictionary<string, object> conditionDict)
        {
            BuyBackDetailsExt model = null;
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
                IList<BuyBackDetailsExt> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取BuyBackDetailsExt对象
        /// <summary>
        /// 根据主键获取BuyBackDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(BuyBackDetails.ID)</param>
        /// <returns>BuyBackDetailsExt对象</returns>
        public BuyBackDetailsExt GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            BuyBackDetailsExt model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new BuyBackDetailsExt
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            CategoryId1 = DataTypeHelper.GetInt(sdr["CategoryId1"]),
                            CategoryId1Name = DataTypeHelper.GetString(sdr["CategoryId1Name"], null),
                            CategoryId2 = DataTypeHelper.GetInt(sdr["CategoryId2"]),
                            CategoryId2Name = DataTypeHelper.GetString(sdr["CategoryId2Name"], null),
                            CategoryId3 = DataTypeHelper.GetInt(sdr["CategoryId3"]),
                            CategoryId3Name = DataTypeHelper.GetString(sdr["CategoryId3Name"], null),
                            ShopCategoryId1 = DataTypeHelper.GetInt(sdr["ShopCategoryId1"]),
                            ShopCategoryId1Name = DataTypeHelper.GetString(sdr["ShopCategoryId1Name"], null),
                            ShopCategoryId2 = DataTypeHelper.GetInt(sdr["ShopCategoryId2"]),
                            ShopCategoryId2Name = DataTypeHelper.GetString(sdr["ShopCategoryId2Name"], null),
                            ShopCategoryId3 = DataTypeHelper.GetInt(sdr["ShopCategoryId3"]),
                            ShopCategoryId3Name = DataTypeHelper.GetString(sdr["ShopCategoryId3Name"], null),
                            BrandId1 = DataTypeHelper.GetInt(sdr["BrandId1"]),
                            BrandId1Name = DataTypeHelper.GetString(sdr["BrandId1Name"], null),
                            BrandId2 = DataTypeHelper.GetInt(sdr["BrandId2"]),
                            BrandId2Name = DataTypeHelper.GetString(sdr["BrandId2Name"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.GetModel",
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


        #region 根据字典获取BuyBackDetailsExt集合
        /// <summary>
        /// 根据字典获取BuyBackDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<BuyBackDetailsExt> GetList(IDictionary<string, object> conditionDict)
        {
            IList<BuyBackDetailsExt> list = null;
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


        #region 根据字典获取BuyBackDetailsExt数据集
        /// <summary>
        /// 根据字典获取BuyBackDetailsExt数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.GetDataSet",
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


        #region 分页获取BuyBackDetailsExt集合
        /// <summary>
        /// 分页获取BuyBackDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<BuyBackDetailsExt> GetPageList(PageListBySql<BuyBackDetailsExt> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,CategoryId1,CategoryId1Name,CategoryId2,CategoryId2Name,CategoryId3,CategoryId3Name,ShopCategoryId1,ShopCategoryId1Name,ShopCategoryId2,ShopCategoryId2Name,ShopCategoryId3,ShopCategoryId3Name,BrandId1,BrandId1Name,BrandId2,BrandId2Name,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new BuyBackDetailsExt
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            CategoryId1 = DataTypeHelper.GetInt(sdr["CategoryId1"]),
                            CategoryId1Name = DataTypeHelper.GetString(sdr["CategoryId1Name"], null),
                            CategoryId2 = DataTypeHelper.GetInt(sdr["CategoryId2"]),
                            CategoryId2Name = DataTypeHelper.GetString(sdr["CategoryId2Name"], null),
                            CategoryId3 = DataTypeHelper.GetInt(sdr["CategoryId3"]),
                            CategoryId3Name = DataTypeHelper.GetString(sdr["CategoryId3Name"], null),
                            ShopCategoryId1 = DataTypeHelper.GetInt(sdr["ShopCategoryId1"]),
                            ShopCategoryId1Name = DataTypeHelper.GetString(sdr["ShopCategoryId1Name"], null),
                            ShopCategoryId2 = DataTypeHelper.GetInt(sdr["ShopCategoryId2"]),
                            ShopCategoryId2Name = DataTypeHelper.GetString(sdr["ShopCategoryId2Name"], null),
                            ShopCategoryId3 = DataTypeHelper.GetInt(sdr["ShopCategoryId3"]),
                            ShopCategoryId3Name = DataTypeHelper.GetString(sdr["ShopCategoryId3Name"], null),
                            BrandId1 = DataTypeHelper.GetInt(sdr["BrandId1"]),
                            BrandId1Name = DataTypeHelper.GetString(sdr["BrandId1Name"], null),
                            BrandId2 = DataTypeHelper.GetInt(sdr["BrandId2"]),
                            BrandId2Name = DataTypeHelper.GetString(sdr["BrandId2Name"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.UpdateField",
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


        #region 根据条件获取BuyBackDetailsExt列表
        /// <summary>
        /// 根据条件获取BuyBackDetailsExt列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<BuyBackDetailsExt> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<BuyBackDetailsExt> list = new List<BuyBackDetailsExt>();
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
                        list.Add(new BuyBackDetailsExt
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            CategoryId1 = DataTypeHelper.GetInt(sdr["CategoryId1"]),
                            CategoryId1Name = DataTypeHelper.GetString(sdr["CategoryId1Name"], null),
                            CategoryId2 = DataTypeHelper.GetInt(sdr["CategoryId2"]),
                            CategoryId2Name = DataTypeHelper.GetString(sdr["CategoryId2Name"], null),
                            CategoryId3 = DataTypeHelper.GetInt(sdr["CategoryId3"]),
                            CategoryId3Name = DataTypeHelper.GetString(sdr["CategoryId3Name"], null),
                            ShopCategoryId1 = DataTypeHelper.GetInt(sdr["ShopCategoryId1"]),
                            ShopCategoryId1Name = DataTypeHelper.GetString(sdr["ShopCategoryId1Name"], null),
                            ShopCategoryId2 = DataTypeHelper.GetInt(sdr["ShopCategoryId2"]),
                            ShopCategoryId2Name = DataTypeHelper.GetString(sdr["ShopCategoryId2Name"], null),
                            ShopCategoryId3 = DataTypeHelper.GetInt(sdr["ShopCategoryId3"]),
                            ShopCategoryId3Name = DataTypeHelper.GetString(sdr["ShopCategoryId3Name"], null),
                            BrandId1 = DataTypeHelper.GetInt(sdr["BrandId1"]),
                            BrandId1Name = DataTypeHelper.GetString(sdr["BrandId1Name"], null),
                            BrandId2 = DataTypeHelper.GetInt(sdr["BrandId2"]),
                            BrandId2Name = DataTypeHelper.GetString(sdr["BrandId2Name"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyBackDetailsExt.GetList",
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