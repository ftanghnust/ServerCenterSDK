
  
/*****************************
* Author:leidong
*
* Date:2016-04-20
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
     /// ### SaleEdit数据库访问类
     /// </summary>
     public partial class SaleEditDAO: BaseDAL, ISaleEditDAO
     {
     /// <summary>
     /// 无参构造函数
     /// </summary>
     public SaleEditDAO() { }
     /// <summary>
     /// 有参构造函数
     /// </summary>
     /// <param name="warehouseId">仓库ID</param>
     public SaleEditDAO(string warehouseId)
     : base(warehouseId)
     {
     }


    const string tableName = "SaleEdit";
     /// <summary>
     /// 数据表名
     /// </summary>
     protected override string TableName
     { get { return tableName; } }


    #region 成员方法
     #region 根据主键验证SaleEdit是否存在
     /// <summary>
     /// 根据主键验证SaleEdit是否存在
     /// </summary>
     /// <param name="model">SaleEdit对象</param>
     /// <returns>是否存在</returns>
     public bool Exists(SaleEdit model)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     int result = 0;
     string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
     SqlParameter[] sp = {
     new SqlParameter("@EditID", SqlDbType.VarChar, 36)
     };
     sp[0].Value=model.EditID;

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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.Exists",
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


    #region 添加一个SaleEdit
     /// <summary>
     /// 添加一个SaleEdit
     /// </summary>
     /// <param name="model">SaleEdit对象</param>
     /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
     public int Save(SaleEdit model)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     int result = 0;
     IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
     string sql = AddOrEditSqlBuilder.GetInsertSql<SaleEdit>(model, ref parameters);
     IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.Save",
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


    #region 添加一个SaleEdit(事务处理)
     /// <summary>
     /// 添加一个SaleEdit(事务处理)
     /// </summary>
     /// <param name="conn">连接对象</param>
     /// <param name="tran">事务对象</param>
     /// <param name="model">SaleEdit对象</param>
     /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
     public int Save(IDbConnection conn, IDbTransaction tran, SaleEdit model)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     int result = 0;
     IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
     string sql = AddOrEditSqlBuilder.GetInsertSql<SaleEdit>(model, ref parameters);
     IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.Save",
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


    #region 更新一个SaleEdit
     /// <summary>
     /// 更新一个SaleEdit
     /// </summary>
     /// <param name="model">SaleEdit对象</param>
     /// <returns>数据库影响行数</returns>
     public int Edit(SaleEdit model)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     int result = 0;
     IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
     string sql = AddOrEditSqlBuilder.GetUpdateSql<SaleEdit>(model, null, ref parameters);
     IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.Edit",
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


    #region 更新一个SaleEdit(事务处理)
     /// <summary>
     /// 更新一个SaleEdit(事务处理)
     /// </summary>
     /// <param name="conn">连接对象</param>
     /// <param name="tran">事务对象</param>
     /// <param name="model">SaleEdit对象</param>
     /// <returns>数据库影响行数</returns>
     public int Edit(IDbConnection conn, IDbTransaction tran, SaleEdit model)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     int result = 0;
     IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
     string sql = AddOrEditSqlBuilder.GetUpdateSql<SaleEdit>(model, null, ref parameters);
     IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.Edit",
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


    #region 删除一个SaleEdit
     /// <summary>
     /// 删除一个SaleEdit
     /// </summary>
     /// <param name="model">SaleEdit对象</param>
     /// <returns>数据库影响行数</returns>
     public int Delete(SaleEdit model, IDbConnection conn=null, IDbTransaction tran=null)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     int result = 0;
     string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
     SqlParameter[] sp = {
     new SqlParameter("@EditID", SqlDbType.VarChar, 36)
     };
     sp[0].Value=model.EditID;

    try
     {
        if(conn==null || tran==null)
        {
            result = helper.ExecNonQuery(sql, sp);
        }
        else
        {
            result = helper.ExecNonQuery(conn,tran,sql, sp);
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.Delete",
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


    #region 根据主键逻辑删除一个SaleEdit
     /// <summary>
     /// 根据主键逻辑删除一个SaleEdit
     /// </summary>
     /// <param name="editID">改单ID</param>
     /// <returns>数据库影响行数</returns>
     public int LogicDelete(string editID)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     int result = 0;
     string sql =SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
     SqlParameter[] sp = {
     new SqlParameter("@EditID", SqlDbType.VarChar, 36)
     };
     sp[0].Value=editID;

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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.LogicDelete",
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


    #region 根据字典获取SaleEdit对象
     /// <summary>
     /// 根据字典获取SaleEdit对象
     /// </summary>
     /// <param name="query">查询对象</param>
     /// <returns>SaleEdit对象</returns>
     public SaleEdit GetModel(SaleEditQuery query)
     {
     SaleEdit model=null;
     try
     {
     IList<SaleEdit> list=GetList(query);
     if(list!=null&&list.Count>0)
     {
     model=list[0];
     }
     }
     catch
     {
     throw;
     }
     return model;
     }
     #endregion


    #region 根据主键获取SaleEdit对象
     /// <summary>
     /// 根据主键获取SaleEdit对象
     /// </summary>
     /// <param name="editID">改单ID</param>
     /// <returns>SaleEdit对象</returns>
     public SaleEdit GetModel(string editID)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     SaleEdit model=null;
     try
     {
     string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName); 
    SqlParameter[] sp = {
     new SqlParameter("@EditID", SqlDbType.VarChar, 36)
     };
     sp[0].Value=editID;

    using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
     {
     model = DataReaderHelper.ExecuteToEntity<SaleEdit>(sdr);
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.GetModel",
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


    #region 根据字典获取SaleEdit集合
     /// <summary>
     /// 根据字典获取SaleEdit集合
     /// </summary>
     /// <param name="query">查询对象</param>
     /// <returns>数据集合</returns>
     public IList<SaleEdit> GetList(SaleEditQuery query)
     {
     IList<SaleEdit> list =null;
     try
     {
     SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);
     StringBuilder where = new StringBuilder();
     if (sp != null && sp.Length > 0 && sp[0] != null)
     {
     where.Append(" WHERE 1=1 ");
     foreach (SqlParameter s in sp)
     { where.Append(string.Format(" AND {0}=@{0}", s.ParameterName)); }
     }
     list= GetList(where.ToString(), sp);
     }
     catch
     {
     throw;
     }
     return list;
     }
     #endregion


    #region 根据字典获取SaleEdit数据集
     /// <summary>
     /// 根据字典获取SaleEdit数据集
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.GetDataSet",
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


    #region 分页获取SaleEdit集合
     /// <summary>
     /// 分页获取SaleEdit集合
     /// </summary>
     /// <param name="page">分页对象</param>
     /// <param name="conditionDict">查询条件</param>
     /// <returns>分页对象集合</returns>
     public PageListBySql<SaleEdit> GetPageList(PageListBySql<SaleEdit> page, IDictionary<string, object> conditionDict)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     int totalRecords = 0;
     int totalPages = 1;
     try
     {
     page.TableName = tableName;
     page.Fields = " * ";
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
     page.ItemList = DataReaderHelper.ExecuteToList<SaleEdit>(sdr);
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.GetPageList",
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
     return "EditID";
     }
     else
     {
     return order;
     }
     }
     #endregion


    #region 根据条件获取SaleEdit列表
     /// <summary>
     /// 根据条件获取SaleEdit列表
     /// </summary>
     /// <param name="where">条件</param>
     /// <param name="sp">参数数组</param>
     /// <returns>数据集合</returns>
     IList<SaleEdit> GetList(string where,SqlParameter[] sp)
     {
     DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
     IList<SaleEdit> list = new List<SaleEdit>();
     try
     {
     StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));
 
    if(!string.IsNullOrEmpty(where))
     {
     sql.Append(where);
     } 
    using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
     {
     list = DataReaderHelper.ExecuteToList<SaleEdit>(sdr);
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
     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEdit.GetList",
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

    public partial class SaleEditDAO : BaseDAL, ISaleEditDAO
    {

        #region ISaleEditDAO 成员

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="total">总数量</param>
        /// <returns></returns>
        public IList<SaleEdit> GetList(SaleEditQuery query, out int total)
        {
            string sql = "WITH LIST AS (" + SQLConfigBuilder.GetSQLScriptByTable(tableName, "Query", base.AssemblyName, base.DatabaseName);
            StringBuilder sWhere = new StringBuilder(" where 1=1 ");
            SqlParamrterBuilder sp = new SqlParamrterBuilder();

            sql = string.Format(sql, query.SortBy);
            if (!string.IsNullOrEmpty(query.EditID))
            {
                sWhere.Append(" And e.EditID like @EditID");
                sp.Add("EditID", SqlDbType.VarChar, 55, "%" + query.EditID + "%");
            }
            if (!string.IsNullOrEmpty(query.Remark))
            {
                sWhere.Append(" And Remark like @Remark");
                sp.Add("Remark", SqlDbType.VarChar, 40, "%" + query.Remark + "%");
            }
            if (query.CreateTimeBegin.HasValue)
            {
                sWhere.Append(" And CreateTime>=@CreateTimeBegin");
                sp.Add("CreateTimeBegin", SqlDbType.DateTime, query.CreateTimeBegin.Value);
            }
            if (query.CreateTimeEnd.HasValue)
            {
                sWhere.Append(" And CreateTime<=@CreateTimeEnd");
                sp.Add("CreateTimeEnd", SqlDbType.DateTime, query.CreateTimeEnd.Value);
            }
            if (query.Status.HasValue)
            {
                sWhere.Append(" And Status=@Status");
                sp.Add("Status", SqlDbType.Int, 4, query.Status.Value);
            }
            if (query.WID.HasValue)
            {
                sWhere.Append(" And WID=@WID");
                sp.Add("WID", SqlDbType.Int, 4, query.WID.Value);
            }
            if (!string.IsNullOrEmpty(query.WCode))
            {
                sWhere.Append(" And  WCode like @WCode");
                sp.Add("WCode", SqlDbType.VarChar, 40, "%" + query.WCode + "%");
            }
            if (query.CreateUserId.HasValue)
            {
                sWhere.Append(" And CreateUserID=@CreateUserID");
                sp.Add("CreateUserID", SqlDbType.Int, 4, query.CreateUserId.Value);
            }
            if (!string.IsNullOrEmpty(query.CreateUserName))
            {
                sWhere.Append(" And  CreateUserName like @CreateUserName");
                sp.Add("CreateUserName", SqlDbType.VarChar, 40, "%" + query.CreateUserName + "%");
            }
            if(query.SubWID.HasValue)
            {
                sWhere.Append(" And SubWID=@SubWID");
                sp.Add("SubWID", SqlDbType.Int, 4, query.SubWID.Value);
            }
            if(!string.IsNullOrEmpty(query.SubWName))
            {
                sWhere.Append(" And  SubWName like @SubWName");
                sp.Add("SubWName", SqlDbType.VarChar, 40, "%" + query.SubWName + "%");
            }

            string sqlCount = "";
            sqlCount += sql + sWhere.ToString() + ") select Count(*) from LIST ";
            total = GetCount(sqlCount, sp.ToSqlParameters());
            if (query.PageIndex > 1 && query.PageSize >= total)
            {
                query.PageIndex = 1;
            }
            sql += sWhere.ToString() + string.Format(") SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1}", (query.PageIndex - 1) * query.PageSize + 1, query.PageIndex * query.PageSize);

            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            using (IDataReader dataReader = helper.GetIDataReader(sql, sp.ToSqlParameters()))
            {
                return this.ExecuteTolist<SaleEdit>(dataReader);
            }
        }
        

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        private int GetCount(string sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            var result = helper.GetSingle(sql, sp);
            if (result != null)
            {
                return int.Parse(result.ToString());
            }
            else
            {
                return 0;
            }

        }

        #endregion
    }
}