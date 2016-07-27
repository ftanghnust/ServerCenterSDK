
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
    /// ### 仓库商品价格调整表WProductAdjPrice数据库访问类
    /// </summary>
    public partial class WProductAdjPriceDAO : BaseDAL, IWProductAdjPriceDAO
    {
        const string tableName = "WProductAdjPrice";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductAdjPrice是否存在
        /// <summary>
        /// 根据主键验证WProductAdjPrice是否存在
        /// </summary>
        /// <param name="model">WProductAdjPrice对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductAdjPrice model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.Int)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.Exists",
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


        #region 添加一个WProductAdjPrice
        /// <summary>
        /// 添加一个WProductAdjPrice
        /// </summary>
        /// <param name="model">WProductAdjPrice对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductAdjPrice model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@AdjType", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@Remark", SqlDbType.VarChar, 200)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.AdjType;
            sp[3].Value = model.ConfTime;
            sp[4].Value = model.ConfUserID;
            sp[5].Value = model.ConfUserName;
            sp[6].Value = model.PostingTime;
            sp[7].Value = model.PostingUserID;
            sp[8].Value = model.PostingUserName;
            sp[9].Value = model.CreateTime;
            sp[10].Value = model.CreateUserID;
            sp[11].Value = model.CreateUserName;
            sp[12].Value = model.ModifyTime;
            sp[13].Value = model.ModifyUserID;
            sp[14].Value = model.ModifyUserName;
            sp[15].Value = model.BeginTime;
            sp[16].Value = model.Remark;
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.Save",
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


        #region 更新一个WProductAdjPrice
        /// <summary>
        /// 更新一个WProductAdjPrice
        /// </summary>
        /// <param name="model">WProductAdjPrice对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductAdjPrice model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@AdjType", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AdjID", SqlDbType.Int),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@Remark", SqlDbType.VarChar, 200)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.AdjType;
            sp[3].Value = model.ConfTime;
            sp[4].Value = model.ConfUserID;
            sp[5].Value = model.ConfUserName;
            sp[6].Value = model.PostingTime;
            sp[7].Value = model.PostingUserID;
            sp[8].Value = model.PostingUserName;
            sp[9].Value = model.ModifyTime;
            sp[10].Value = model.ModifyUserID;
            sp[11].Value = model.ModifyUserName;
            sp[12].Value = model.AdjID;
            sp[13].Value = model.BeginTime;
            sp[14].Value = model.Remark;
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.Edit",
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


        #region 删除一个WProductAdjPrice
        /// <summary>
        /// 删除一个WProductAdjPrice
        /// </summary>
        /// <param name="model">WProductAdjPrice对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductAdjPrice model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.Int)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.Delete",
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


        #region 根据主键逻辑删除一个WProductAdjPrice
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjPrice
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int adjID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.Int)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.LogicDelete",
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


        #region 根据字典获取WProductAdjPrice对象
        /// <summary>
        /// 根据字典获取WProductAdjPrice对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductAdjPrice对象</returns>
        public WProductAdjPrice GetModel(IDictionary<string, object> conditionDict)
        {
            WProductAdjPrice model = null;
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
                IList<WProductAdjPrice> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductAdjPrice对象
        /// <summary>
        /// 根据主键获取WProductAdjPrice对象
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>WProductAdjPrice对象</returns>
        public WProductAdjPrice GetModel(int adjID)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProductAdjPrice model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.Int)
 };
                sp[0].Value = adjID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WProductAdjPrice
                        {
                            AdjID = DataTypeHelper.GetInt(sdr["AdjID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            AdjType = DataTypeHelper.GetInt(sdr["AdjType"]),
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
                            ModifyUserID = DataTypeHelper.GetIntNull(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            BeginTime = DataTypeHelper.GetDateTimeNull(sdr["BeginTime"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.GetModel",
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


        #region 根据字典获取WProductAdjPrice集合
        /// <summary>
        /// 根据字典获取WProductAdjPrice集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductAdjPrice> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductAdjPrice> list = null;
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


        #region 根据字典获取WProductAdjPrice数据集
        /// <summary>
        /// 根据字典获取WProductAdjPrice数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.GetDataSet",
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


        #region 分页获取WProductAdjPrice集合
        /// <summary>
        /// 分页获取WProductAdjPrice集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductAdjPrice> GetPageList(PageListBySql<WProductAdjPrice> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "AdjID,WID,Status,AdjType,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new WProductAdjPrice
                        {
                            AdjID = DataTypeHelper.GetInt(sdr["AdjID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            AdjType = DataTypeHelper.GetInt(sdr["AdjType"]),
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
                            ModifyUserID = DataTypeHelper.GetIntNull(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            BeginTime = DataTypeHelper.GetDateTimeNull(sdr["BeginTime"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.UpdateField",
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
                return "AdjID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WProductAdjPrice列表
        /// <summary>
        /// 根据条件获取WProductAdjPrice列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WProductAdjPrice> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductAdjPrice> list = new List<WProductAdjPrice>();
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
                        list.Add(new WProductAdjPrice
                        {
                            AdjID = DataTypeHelper.GetInt(sdr["AdjID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            AdjType = DataTypeHelper.GetInt(sdr["AdjType"]),
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
                            ModifyUserID = DataTypeHelper.GetIntNull(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            BeginTime = DataTypeHelper.GetDateTimeNull(sdr["BeginTime"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPrice.GetList",
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AdjId"></param>
        /// <returns></returns>
        public void Delete(int AdjId)
        {
            string sql = "delete from WProductAdjPrice where AdjID=@AdjID;delete from WProductAdjPriceDetails where AdjID=@AdjID";
            DBHelper.GetInstance().ExecNonQuery(sql, new SqlParamrterBuilder().Append("AdjID", AdjId).ToSqlParameters());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjType"></param>
        /// <returns></returns>
        public int JobPosting(int adjType)
        {

            string sql = "";

            switch (adjType)
            {

                case 0:

                    //进货价
                    sql = @"
                            update WProductsBuy set 
                            WProductsBuy.BuyPrice		= b.Price,
                            WProductsBuy.ModifyTime		= GETDATE(),
                            WProductsBuy.ModifyUserID	= -1,
                            WProductsBuy.ModifyUserName	= 'system'
                            from WProductsBuy,(select WProductID,Price from WProductAdjPriceDetails 
                            where AdjID in(select AdjID from WProductAdjPrice 
                            where [Status]=1 and AdjType=0 and BeginTime<=GETDATE())) as b 
                            where WProductsBuy.WProductID=b.WProductID

                            update WProductAdjPrice set 
                            [Status]=2, 
                            PostingTime=GETDATE(), 
                            PostingUserID=-1, 
                            PostingUserName='system' ,
                            ModifyTime = GETDATE(),
                            ModifyUserID = -1,
                            ModifyUserName = 'system'
                            where [Status]=1 and AdjType=0 and BeginTime<=GETDATE();";
                    break;

                case 1:

                    //销售价
                    sql = @"update WProducts set  
                            WProducts.SalePrice			= b.Price, 
                            WProducts.ModifyTime		= GETDATE(), 
                            WProducts.ModifyUserID		= -1, 
                            WProducts.ModifyUserName	= 'system' 
                            from WProducts,(select WProductID,Price from WProductAdjPriceDetails  
                            where AdjID in(select AdjID from WProductAdjPrice  
                            where [Status]=1 and AdjType=1 and BeginTime<=GETDATE())) as b  
                            where WProducts.WProductID=b.WProductID

                            update WProductAdjPrice set  
                            [Status]=2, 
                            PostingTime=GETDATE(),  
                            PostingUserID=-1,  
                            PostingUserName='system', 
                            ModifyTime = GETDATE(), 
                            ModifyUserID = -1, 
                            ModifyUserName = 'system' 
                            where [Status]=1 and AdjType=1 and BeginTime<=GETDATE();  ";

                    break;

                case 2:

                    //门店积分
                    sql = @" update WProducts set  

                            WProducts.MarketPrice		= b.MarketPrice, 
                            WProducts.ShopAddPerc       = b.ShopPerc,
                            wproducts.ShopPoint			= b.ShopPoint, 
                            wproducts.BasePoint			= b.basePoint, 
                            wproducts.VendorPerc1		= b.VendorPerc1, 
                            wproducts.VendorPerc2		= b.VendorPerc2, 

                            WProducts.ModifyTime		= GETDATE(), 
                            WProducts.ModifyUserID		= -1, 
                            WProducts.ModifyUserName	= 'system' 
                            from WProducts,(select WProductID,MarketPrice,ShopPoint,ShopPerc,BasePoint,VendorPerc1,VendorPerc2  
                            from WProductAdjPriceDetails where AdjID in(select AdjID from WProductAdjPrice  
                            where [Status]=1 and AdjType=2 and BeginTime<=GETDATE())) as b  
                            where WProducts.WProductID=b.WProductID 

                            update WProductAdjPrice set  
                            [Status]=2, 
                            PostingTime=GETDATE(),  
                            PostingUserID=-1,  
                            PostingUserName='system', 
                            ModifyTime = GETDATE(), 
                            ModifyUserID = -1, 
                            ModifyUserName = 'system' 
                            where [Status]=1 and AdjType=2 and BeginTime<=GETDATE();  ";

                    break;
            }

            if (string.IsNullOrWhiteSpace(sql))
            {
                return -1;
            }

            //返回
            return DBHelper.GetInstance().ExecNonQuery(sql, new SqlParamrterBuilder().ToSqlParameters());
        }
    }
}