/*****************************
* Author:罗靖
*
* Date:2016-06-17
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
using System.Linq;


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### SettlementDetail数据库访问类
    /// </summary>
    public partial class SettlementDetailDAO : BaseDAL, ISettlementDetailDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SettlementDetailDAO() { }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SettlementDetailDAO(string warehouseId)
            : base(warehouseId)
        {

        }


        const string tableName = "SettlementDetail";

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }



        #region  成员方法
        #region 根据主键验证SettlementDetail是否存在
        /// <summary>
        /// 根据主键验证SettlementDetail是否存在
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SettlementDetail model)
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.Exists",
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


        #region 添加一个SettlementDetail
        /// <summary>
        /// 添加一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SettlementDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<SettlementDetail>(model, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.Save",
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


        #region 添加一个SettlementDetail(事务处理)
        /// <summary>
        /// 添加一个SettlementDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SettlementDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<SettlementDetail>(model, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.Save",
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


        #region 更新一个SettlementDetail
        /// <summary>
        /// 更新一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SettlementDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<SettlementDetail>(model, null, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.Edit",
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


        #region 更新一个SettlementDetail(事务处理)
        /// <summary>
        /// 更新一个SettlementDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SettlementDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<SettlementDetail>(model, null, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.Edit",
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


        #region 删除一个SettlementDetail
        /// <summary>
        /// 删除一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SettlementDetail model)
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.Delete",
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


        #region 根据主键逻辑删除一个SettlementDetail
        /// <summary>
        /// 根据主键逻辑删除一个SettlementDetail
        /// </summary>
        /// <param name="iD">ID</param>
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.LogicDelete",
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


        #region 根据字典获取SettlementDetail对象
        /// <summary>
        /// 根据字典获取SettlementDetail对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SettlementDetail对象</returns>
        public SettlementDetail GetModel(SettlementDetailQuery query)
        {
            SettlementDetail model = null;
            try
            {
                IList<SettlementDetail> list = GetList(query);
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


        #region 根据主键获取SettlementDetail对象
        /// <summary>
        /// 根据主键获取SettlementDetail对象
        /// </summary>
        /// <param name="iD">ID</param>
        /// <returns>SettlementDetail对象</returns>
        public SettlementDetail GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SettlementDetail model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);

                SqlParameter[] sp = {
					new SqlParameter("@ID", SqlDbType.Int)
					};
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SettlementDetail>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.GetModel",
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


        #region 根据字典获取SettlementDetail集合
        /// <summary>
        /// 根据字典获取SettlementDetail集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<SettlementDetail> GetList(SettlementDetailQuery query)
        {
            IList<SettlementDetail> list = null;
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


        #region 根据字典获取SettlementDetail数据集
        /// <summary>
        /// 根据字典获取SettlementDetail数据集
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.GetDataSet",
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


        #region 分页获取SettlementDetail集合
        /// <summary>
        /// 分页获取SettlementDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SettlementDetail> GetPageList(PageListBySql<SettlementDetail> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,RefSet_ID,SKU,ProductId,ProductName,BarCode,Unit,BuyPrice,SalePrice,BeginQty,BeginAmt,BuyQty,BuyAmt,BuyBackQty,BuyBackAmt,SaleQty,SaleAmt,SaleBackQty,SaleBackAmt,AdjGainQty,AjgGginAmt,AdjLossQty,AjgLosssAmt,StockQty,StockAmt,EndQty,EndStockAmt,CEndQty,CEndStockAmt,EndDiffQty,EndDiffStockAmt,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SettlementDetail>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.GetPageList",
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
            #region 查询参数 - 龙武
            if (conditionDict.ContainsKey("RefSet_ID"))//ID
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "RefSet_ID",
                        FieldValue = conditionDict["RefSet_ID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }
            if (conditionDict.ContainsKey("SKU"))//商品编码
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "SKU",
                        FieldValue = conditionDict["SKU"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }
            if (conditionDict.ContainsKey("ProductName"))//商品名称
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ProductName",
                        FieldValue = conditionDict["ProductName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 200
                    }
                });
            }
            #endregion
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


        #region 根据条件获取SettlementDetail列表
        /// <summary>
        /// 根据条件获取SettlementDetail列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SettlementDetail> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SettlementDetail> list = new List<SettlementDetail>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SettlementDetail>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.GetList",
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

    /// <summary>
    /// 罗靖添加
    /// </summary>
    public partial class SettlementDetailDAO
    {
        #region 根据条件获取SettlementDetail列表
        /// <summary>
        /// 根据条件获取日结数据列表（部分逻辑写入了存储过程）
        /// </summary>
        /// <param name="query">条件</param>
        /// <param name="procedureName">存储过程名称</param>
        /// <returns>数据集合</returns>
        public IList<SettlementDetail> GetProductStockList(GetProductStockQuery query, string procedureName)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            DataTable dt = null;

            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);

                DataSet ds = helper.GetDataSet(procedureName, sp, false);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return Frxs.Platform.Utility.Map.DataTableConverter.ConvertDataTableToList<SettlementDetail>(ds.Tables[0]);
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.SettlementDetailDAO.GetSettlementDetailList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return null;
        }

        #endregion


    }

    /// <summary>
    /// 结算单详细表-SettlementDetail 数据库访问类 - - 龙武
    /// </summary>
    public partial class SettlementDetailDAO
    {
        /// <summary>
        /// 分页获取SettlementDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public SettlementDetailsList GetDetailsPageList(PageListBySql<SettlementDetail> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,RefSet_ID,SKU,ProductId,ProductName,BarCode,Unit,BuyPrice,SalePrice,BeginQty,BeginAmt,BuyQty,BuyAmt,BuyBackQty,BuyBackAmt,SaleQty,SaleAmt,SaleBackQty,SaleBackAmt,AdjGainQty,AjgGginAmt,AdjLossQty,AjgLosssAmt,StockQty,StockAmt,EndQty,EndStockAmt,EndDiffQty,EndDiffStockAmt,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SettlementDetail>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.GetPageList",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            SettlementDetailsList parentPage = new SettlementDetailsList();
            parentPage.PageIndex = page.PageIndex;
            parentPage.PageSize = page.PageSize;
            parentPage.PageCount = page.TotalRecords;
            parentPage.PageTotal = page.TotalPages;
            parentPage.SettDetail = page.ItemList;
            parentPage.SettCurrentSum = new CurrentSum();
            parentPage.SettTotalSum = new TotalSum();
            page.ItemList.ToList().ForEach(x =>
            {
                #region 当前页合计
                parentPage.SettCurrentSum.BeginQty += x.BeginQty;
                parentPage.SettCurrentSum.BeginAmt += x.BeginAmt;
                parentPage.SettCurrentSum.BuyQty += x.BuyQty;
                parentPage.SettCurrentSum.BuyAmt += x.BuyAmt;
                parentPage.SettCurrentSum.BuyBackQty += x.BuyBackQty;
                parentPage.SettCurrentSum.BuyBackAmt += x.BuyBackAmt;
                parentPage.SettCurrentSum.SaleQty += x.SaleQty;
                parentPage.SettCurrentSum.SaleAmt += x.SaleAmt;
                parentPage.SettCurrentSum.SaleBackQty += x.SaleBackQty;
                parentPage.SettCurrentSum.SaleBackAmt += x.SaleBackAmt;
                parentPage.SettCurrentSum.AdjGainQty += x.AdjGainQty;
                parentPage.SettCurrentSum.AjgGginAmt += x.AjgGginAmt;
                parentPage.SettCurrentSum.AdjLossQty += x.AdjLossQty;
                parentPage.SettCurrentSum.AjgLosssAmt += x.AjgLosssAmt;
                parentPage.SettCurrentSum.StockQty += x.StockQty;
                parentPage.SettCurrentSum.StockAmt += x.StockAmt;
                parentPage.SettCurrentSum.EndQty += x.EndQty;
                parentPage.SettCurrentSum.EndStockAmt += x.EndStockAmt;
                parentPage.SettCurrentSum.EndDiffQty += x.EndDiffQty;
                parentPage.SettCurrentSum.EndDiffStockAmt += x.EndDiffStockAmt;
                #endregion
            });
            List<SqlParameter> list = new List<SqlParameter>();

            string strSql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetTotalSum", base.AssemblyName, base.DatabaseName);
            foreach (var item in conditionDict)
            {
                if (item.Key.Contains("RefSet_ID"))
                {
                    list.Add(new SqlParameter("@RefSetID", item.Value));
                }
                if (item.Key.Contains("SKU"))
                {
                    list.Add(new SqlParameter("@SKU", item.Value));
                    strSql += " AND SKU=@SKU ";
                }
                if (item.Key.Contains("ProductName"))
                {
                    list.Add(new SqlParameter("@ProductName", "%" + item.Value + "%"));
                    strSql += " AND ProductName like @ProductName ";
                }
            }
            using (SqlDataReader sdr = helper.GetIDataReader(strSql, list.ToArray()) as SqlDataReader)
            {
                parentPage.SettTotalSum = DataReaderHelper.ExecuteToEntity<TotalSum>(sdr);
            }
            return parentPage;
        }
        #region 删除一个SettlementDetail

        /// <summary>
        /// 删除一个SettlementDetail
        /// </summary>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int DeleteSettlementDetail(IDbConnection conn, IDbTransaction tran, SettlementDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteSettlementDetail", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@RefSet_ID", SqlDbType.VarChar,50)
                };
            sp[0].Value = model.RefSet_ID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDetailDAO.Delete",
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
