using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Pager;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Frxs.Platform.Utility.Log;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    public partial class WProductsBuyEmpDAO : BaseDAL, IWProductsBuyEmpDAO
    {
       const string tableName = "WProductsBuyEmp";

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }



        #region  成员方法
        #region 根据主键验证WProductsBuyEmp是否存在
        /// <summary>
        /// 根据主键验证WProductsBuyEmp是否存在
        /// </summary>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductsBuyEmp model)
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.Exists",
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


        #region 添加一个WProductsBuyEmp
        /// <summary>
        /// 添加一个WProductsBuyEmp
        /// </summary>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(WProductsBuyEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<WProductsBuyEmp>(model, ref parameters);
            IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.Save",
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


        #region 添加一个WProductsBuyEmp(事务处理)
        /// <summary>
        /// 添加一个WProductsBuyEmp(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, WProductsBuyEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<WProductsBuyEmp>(model, ref parameters);
            IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
            try
            {

                object o = helper.GetSingle(conn, tran, sql, sp);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.Save",
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


        #region 更新一个WProductsBuyEmp
        /// <summary>
        /// 更新一个WProductsBuyEmp
        /// </summary>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductsBuyEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<WProductsBuyEmp>(model, null, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.Edit",
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


        #region 更新一个WProductsBuyEmp(事务处理)
        /// <summary>
        /// 更新一个WProductsBuyEmp(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, WProductsBuyEmp model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<WProductsBuyEmp>(model, null, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.Edit",
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


        #region 删除一个WProductsBuyEmp
        /// <summary>
        /// 删除一个WProductsBuyEmp
        /// </summary>
        /// <param name="model">WProductsBuyEmp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductsBuyEmp model)
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.Delete",
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


        #region 根据主键逻辑删除一个WProductsBuyEmp
        /// <summary>
        /// 根据主键逻辑删除一个WProductsBuyEmp
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.LogicDelete",
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


        #region 根据字典获取WProductsBuyEmp对象
        /// <summary>
        /// 根据字典获取WProductsBuyEmp对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>WProductsBuyEmp对象</returns>
        public WProductsBuyEmp GetModel(WProductsBuyEmpQuery query)
        {
            WProductsBuyEmp model = null;
            try
            {
                IList<WProductsBuyEmp> list = GetList(query);
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


        #region 根据主键获取WProductsBuyEmp对象
        /// <summary>
        /// 根据主键获取WProductsBuyEmp对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductsBuyEmp对象</returns>
        public WProductsBuyEmp GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProductsBuyEmp model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);

                SqlParameter[] sp = {
					new SqlParameter("@ID", SqlDbType.Int)
					};
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<WProductsBuyEmp>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.GetModel",
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


        #region 根据字典获取WProductsBuyEmp集合
        /// <summary>
        /// 根据字典获取WProductsBuyEmp集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<WProductsBuyEmp> GetList(WProductsBuyEmpQuery query)
        {
            IList<WProductsBuyEmp> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
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


        #region 根据字典获取WProductsBuyEmp数据集
        /// <summary>
        /// 根据字典获取WProductsBuyEmp数据集
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
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.GetDataSet",
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


        #region 分页获取WProductsBuyEmp集合
        /// <summary>
        /// 分页获取WProductsBuyEmp集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductsBuyEmp> GetPageList(PageListBySql<WProductsBuyEmp> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,WProductID,WID,EmpID,SerialNumber,CreateTime,CreateUserID,CreateUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<WProductsBuyEmp>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.GetPageList",
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
        /// <param name="order">排序字段</param>
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


        #region 根据条件获取WProductsBuyEmp列表
        /// <summary>
        /// 根据条件获取WProductsBuyEmp列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProductsBuyEmp> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductsBuyEmp> list = new List<WProductsBuyEmp>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<WProductsBuyEmp>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.GetList",
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

        public int DeleteByWProductID(int wid,int WProductID, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByWProductID", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
					new SqlParameter("@WProductID", SqlDbType.Int),
                    new SqlParameter("@WID", SqlDbType.Int)
					};
            sp[0].Value = WProductID;
            sp[1].Value = wid;
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.DeleteByWProductID",
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
        /// 批量删除
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="UserId"></param>
        /// <param name="UserName"></param>
        /// <param name="wProductIds"></param>
        /// <param name="BuyEmpIds"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int BatDelWProductsBuyEmp(int wid, int UserId, string UserName, List<int> wProductIds, List<int> BuyEmpIds, IDbConnection conn, IDbTransaction tran)
        {
            int result = 0;
            //批量删除
            //delete from WProductsBuyEmp where WID=105 and WProductID in (110000,110001,110002)
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from WProductsBuyEmp where WID=@WID and WProductID in(");
            for (int i = 0; i < wProductIds.Count; i++)
            {
                sb.Append(wProductIds[i]);
                if (i < wProductIds.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.AppendLine(") ");

            SqlParameter[] sp = {					
                    new SqlParameter("@WID", SqlDbType.Int)
					};
            sp[0].Value = wid;
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                result = helper.ExecNonQuery(conn, tran, sb.ToString(), sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.DeleteByWProductID",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return result;
            return result;
        }

        public int SaveWProductsBuyEmp(int wid, int UserId, string UserName, List<int> wProductIds, List<int> BuyEmpIds, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            //批量删除
            //delete from WProductsBuyEmp where WID=105 and WProductID in (110000,110001,110002)
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO WProductsBuyEmp(WProductID, WID, EmpID, SerialNumber, CreateTime, CreateUserID, CreateUserName )");
            sb.Append("VALUES");
            for (int i = 0; i < wProductIds.Count; i++)
            {
                int SerialNumber = 1;
                for (int j = 0; j < BuyEmpIds.Count; j++)
                {
                    sb.AppendFormat("({0},{1},{2},{3},GETDATE(),{4},'{5}')", wProductIds[i], wid, BuyEmpIds[j], SerialNumber, UserId, UserName);
                    if (i == wProductIds.Count - 1 && j == BuyEmpIds.Count - 1)
                    {

                    }
                    else
                    {
                        sb.Append(",");
                    }
                    SerialNumber += 1;
                }
            }
            try
            {
                result = helper.ExecNonQuery(conn, tran, sb.ToString(), null);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductsBuyEmpDAO.DeleteByWProductID",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            //INSERT INTO WProductsBuyEmp 
            //(WProductID, WID, EmpID, SerialNumber, CreateTime, CreateUserID, CreateUserName )
            //VALUES(110000,105,1110,0,GETDATE(),71,'星沙仓库-负责人'),
            //(110001,105,1110,0,GETDATE(),71,'星沙仓库-负责人'),
            //(110002,105,1110,0,GETDATE(),71,'星沙仓库-负责人')
            return result;
        }
    }
}
