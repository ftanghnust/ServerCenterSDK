
/*****************************
* Author:leidong
*
* Date:2016-04-11
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
    /// ### SaleOrderTrack数据库访问类
    /// </summary>
    public partial class SaleOrderTrackDAO : BaseDAL, ISaleOrderTrackDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleOrderTrackDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleOrderTrackDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleOrderTrack";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleOrderTrack是否存在
        /// <summary>
        /// 根据主键验证SaleOrderTrack是否存在
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderTrack model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.Exists",
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


        #region 添加一个SaleOrderTrack
        /// <summary>
        /// 添加一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleOrderTrack model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 100),
new SqlParameter("@IsDisplayUser", SqlDbType.Int),
new SqlParameter("@OrderStatus", SqlDbType.Int),
new SqlParameter("@OrderStatusName", SqlDbType.VarChar, 20),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 50)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.Remark;
            sp[4].Value = model.IsDisplayUser;
            sp[5].Value = model.OrderStatus;
            sp[6].Value = model.OrderStatusName;
            sp[7].Value = model.CreateTime;
            sp[8].Value = model.CreateUserID;
            sp[9].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.Save",
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


        #region 添加一个SaleOrderTrack(事务处理)
        /// <summary>
        /// 添加一个SaleOrderTrack(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleOrderTrack model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 100),
new SqlParameter("@IsDisplayUser", SqlDbType.Int),
new SqlParameter("@OrderStatus", SqlDbType.Int),
new SqlParameter("@OrderStatusName", SqlDbType.VarChar, 20),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 50)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.Remark;
            sp[4].Value = model.IsDisplayUser;
            sp[5].Value = model.OrderStatus;
            sp[6].Value = model.OrderStatusName;
            sp[7].Value = model.CreateTime;
            sp[8].Value = model.CreateUserID;
            sp[9].Value = model.CreateUserName;

            try
            {

                result = helper.ExecNonQuery(conn, tran, sql, sp);

            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.Save",
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


        #region 更新一个SaleOrderTrack
        /// <summary>
        /// 更新一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderTrack model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 100),
new SqlParameter("@IsDisplayUser", SqlDbType.Int),
new SqlParameter("@OrderStatus", SqlDbType.Int),
new SqlParameter("@OrderStatusName", SqlDbType.VarChar, 20),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.Remark;
            sp[3].Value = model.IsDisplayUser;
            sp[4].Value = model.OrderStatus;
            sp[5].Value = model.OrderStatusName;
            sp[6].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.Edit",
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


        #region 更新一个SaleOrderTrack(事务处理)
        /// <summary>
        /// 更新一个SaleOrderTrack(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderTrack model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 100),
new SqlParameter("@IsDisplayUser", SqlDbType.Int),
new SqlParameter("@OrderStatus", SqlDbType.Int),
new SqlParameter("@OrderStatusName", SqlDbType.VarChar, 20),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.Remark;
            sp[3].Value = model.IsDisplayUser;
            sp[4].Value = model.OrderStatus;
            sp[5].Value = model.OrderStatusName;
            sp[6].Value = model.ID;

            try
            {
                result = helper.ExecNonQuery(conn, tran, sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.Edit",
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


        #region 删除一个SaleOrderTrack
        /// <summary>
        /// 删除一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderTrack model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.Delete",
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


        #region 根据主键逻辑删除一个SaleOrderTrack
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderTrack
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.LogicDelete",
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


        #region 根据字典获取SaleOrderTrack对象
        /// <summary>
        /// 根据字典获取SaleOrderTrack对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SaleOrderTrack对象</returns>
        //public SaleOrderTrack GetModel(SaleOrderTrackQuery query)
        //{
        //    SaleOrderTrack model = null;
        //    try
        //    {
        //        IList<SaleOrderTrack> list = GetList(query);
        //        if (list != null && list.Count > 0)
        //        {
        //            model = list[0];
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return model;
        //}
        #endregion


        #region 根据主键获取SaleOrderTrack对象
        /// <summary>
        /// 根据主键获取SaleOrderTrack对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>SaleOrderTrack对象</returns>
        public SaleOrderTrack GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderTrack model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrderTrack>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.GetModel",
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


        #region 根据字典获取SaleOrderTrack集合
        /// <summary>
        /// 根据字典获取SaleOrderTrack集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        //public IList<SaleOrderTrack> GetList(SaleOrderTrackQuery query)
        //{
        //    IList<SaleOrderTrack> list = null;
        //    try
        //    {
        //        SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);
        //        StringBuilder where = new StringBuilder();
        //        if (sp != null && sp.Length > 0 && sp[0] != null)
        //        {
        //            where.Append(" WHERE 1=1 ");
        //            foreach (SqlParameter s in sp)
        //            { where.Append(string.Format(" AND {0}=@{0}", s.ParameterName)); }
        //        }
        //        list = GetList(where.ToString(), sp);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return list;
        //}
        #endregion


        #region 根据字典获取SaleOrderTrack数据集
        /// <summary>
        /// 根据字典获取SaleOrderTrack数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.GetDataSet",
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


        #region 分页获取SaleOrderTrack集合
        /// <summary>
        /// 分页获取SaleOrderTrack集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderTrack> GetPageList(PageListBySql<SaleOrderTrack> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,OrderID,WID,Remark,IsDisplayUser,OrderStatus,OrderStatusName,CreateTime,CreateUserID,CreateUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderTrack>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.UpdateField",
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


        #region 根据条件获取SaleOrderTrack列表
        /// <summary>
        /// 根据条件获取SaleOrderTrack列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderTrack> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderTrack> list = new List<SaleOrderTrack>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleOrderTrack>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderTrack.GetList",
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



        #region ISaleOrderTrackDAO 成员


        public SaleOrderTrack GetModel(IDictionary<string, object> conditionDict)
        {
            throw new NotImplementedException();
        }


        public IList<SaleOrderTrack> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleOrderTrack> list = null;
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
    }
}