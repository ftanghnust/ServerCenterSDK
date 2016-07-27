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


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### Settlement数据库访问类
    /// </summary>
    public partial class SettlementDAO : BaseDAL, ISettlementDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SettlementDAO() { }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SettlementDAO(string warehouseId)
            : base(warehouseId)
        {

        }


        const string tableName = "Settlement";

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }



        #region  成员方法
        #region 根据主键验证Settlement是否存在
        /// <summary>
        /// 根据主键验证Settlement是否存在
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(Settlement model)
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.Exists",
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


        #region 添加一个Settlement
        /// <summary>
        /// 添加一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(Settlement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<Settlement>(model, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.Save",
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


        #region 添加一个Settlement(事务处理)
        /// <summary>
        /// 添加一个Settlement(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">Settlement对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, Settlement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<Settlement>(model, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.Save",
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


        #region 更新一个Settlement
        /// <summary>
        /// 更新一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(Settlement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<Settlement>(model, null, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.Edit",
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


        #region 更新一个Settlement(事务处理)
        /// <summary>
        /// 更新一个Settlement(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, Settlement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<Settlement>(model, null, ref parameters);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.Edit",
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


        #region 删除一个Settlement
        /// <summary>
        /// 删除一个Settlement
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(Settlement model)
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.Delete",
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




        #region 根据主键逻辑删除一个Settlement
        /// <summary>
        /// 根据主键逻辑删除一个Settlement
        /// </summary>
        /// <param name="iD">ID(GUID)</param>
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.LogicDelete",
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


        #region 根据字典获取Settlement对象
        /// <summary>
        /// 根据字典获取Settlement对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>Settlement对象</returns>
        public Settlement GetModel(SettlementQuery query)
        {
            Settlement model = null;
            try
            {
                IList<Settlement> list = GetList(query);
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


        #region 根据主键获取Settlement对象
        /// <summary>
        /// 根据主键获取Settlement对象
        /// </summary>
        /// <param name="iD">ID(GUID)</param>
        /// <returns>Settlement对象</returns>
        public Settlement GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            Settlement model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);

                SqlParameter[] sp = {
					new SqlParameter("@ID", SqlDbType.VarChar, 50)
					};
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<Settlement>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.GetModel",
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


        #region 根据字典获取Settlement集合
        /// <summary>
        /// 根据字典获取Settlement集合
        /// </summary>
        /// <param name="query1">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<Settlement> GetList(SettlementQuery query1)
        {
            IList<Settlement> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(query1);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    if (query1.Wid > 0)
                    {
                        where.Append(" AND WID=@WID ");
                    }
                    if (query1.SubWid > 0)
                    {
                        where.Append(" AND SubWid=@SubWid ");
                    }
                    where.Append(" AND SettleDate>=@SettleDate ");
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


        #region 根据字典获取Settlement数据集
        /// <summary>
        /// 根据字典获取Settlement数据集
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.GetDataSet",
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


        #region 分页获取Settlement集合
        /// <summary>
        /// 分页获取Settlement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Settlement> GetPageList(PageListBySql<Settlement> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,SettleNo,Status,WID,WCode,WName,SubWID,SubWCode,SubWName,SettleStartTime,SettleEndTime,BeginQty,BeginAmt,BuyQty,BuyAmt,BuyBackQty,BuyBackAmt,SaleQty,SaleAmt,SaleBackQty,SaleBackAmt,AdjGainQty,AjgGginAmt,AdjLossQty,AjgLosssAmt,StockQty,StockAmt,EndQty,EndStockAmt,CEndQty,CEndStockAmt,EndDiffQty,EndDiffStockAmt,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,Remark";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<Settlement>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.GetPageList",
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
            #region 参数-龙武
            if (conditionDict.ContainsKey("SerchTime") && Convert.ToDateTime(conditionDict["SerchTime"])!=DateTime.MinValue)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "SettleDate",
                        FieldValue = conditionDict["SerchTime"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    }
                });
            }
            if (conditionDict.ContainsKey("SubWID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "SubWID",
                        FieldValue = conditionDict["SubWID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
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


        #region 根据条件获取Settlement列表
        /// <summary>
        /// 根据条件获取Settlement列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<Settlement> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<Settlement> list = new List<Settlement>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<Settlement>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.GetList",
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
    /// 其他业务逻辑
    /// </summary>
    public partial class SettlementDAO : BaseDAL, ISettlementDAO
    {
        #region 根据仓库编号,子仓库编号,结算日期来验证Settlement对象是否存在
        /// <summary>
        /// 根据仓库编号,子仓库编号,结算日期来验证Settlement对象是否存在
        /// </summary>
        /// <param name="model">Settlement对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsSettleDate(Settlement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsSettleDate", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@WID", SqlDbType.VarChar, 50),
                    new SqlParameter("@SubWID ", SqlDbType.VarChar, 50),
                    new SqlParameter("@SettleDate", SqlDbType.Date)
                };
            sp[0].Value = model.WID;
            sp[1].Value = model.SubWID;
            sp[2].Value = model.SettleDate;
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.Exists",
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


        #region 最后 根据条件修改单据的结算单号和结算时间

        /// <summary>
        /// 最后 根据条件修改单据的结算单号和结算时间
        /// </summary>
        /// <param name="tran"> </param>
        /// <param name="query"></param>
        /// <param name="procedureName"></param>
        /// <param name="conn"> </param>
        /// <returns></returns>
        public int UpdateBillSettleIdAndSettleTime(IDbConnection conn, IDbTransaction tran, GetUpdateBillQuery query, string procedureName)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);

            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);
                return helper.ExecNonQuery(conn, tran, procedureName, sp, false);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.SettlementDAO.UpdateBillSettleIdAndSettleTime",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return 0;
        }

        #endregion


        #region 获取最后一次结算的时间

        /// <summary>
        /// 获取最后一次结算的结束时间作为这次的开始时间
        /// </summary>
        /// <param name="wId"> </param>
        /// <param name="subWId"> </param>
        /// <returns></returns>
        public DateTime? GetSettleStartTime(int wId, int subWId)
        {
            DateTime? currentDt = null;
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT MAX(SettleEndTime) AS SettleStartTime  FROM Settlement " +
                       "WHERE 1=1 ");
            if (wId > 0)
            {
                sql.Append(" AND WID=@WID");
            }

            if (subWId > 0)
            {
                sql.Append(" AND SubWID=@SubWID");
            }

            SqlParameter[] sp =
                {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@SubWID", SqlDbType.Int)
                };
            sp[0].Value = wId;
            sp[1].Value = subWId;

            try
            {
                #region 执行查询
                var result = helper.GetSingle(sql.ToString(), sp);
                if (result != null)
                {
                    currentDt = Convert.ToDateTime(result.ToString());
                }
                #endregion
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Order.SettlementDAO.GetStockQtyCreateMinDate",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }

            return currentDt;

        }

        #endregion

        #region 删除一个Settlemen(事务处理)

        /// <summary>
        /// 删除一个Settlemen(事务处理)
        /// </summary>
        /// <param name="conn">连接对象 </param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">Settlement对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(IDbConnection conn, IDbTransaction tran, Settlement model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@ID", SqlDbType.VarChar, 50)
                };
            sp[0].Value = model.ID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.Delete",
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
    /// 结算单主表数据库访问类 - 龙武
    /// </summary>
    public partial class SettlementDAO : BaseDAL, ISettlementDAO
    {
        /// <summary>
        /// 分页获取Settlement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Settlement> GetSettlementList(PageListBySql<Settlement> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,SettleNo,SettleDate,Status,WID,WCode,WName,SubWID,SubWCode,SubWName,SettleStartTime,SettleEndTime,BeginQty,BeginAmt,BuyQty,BuyAmt,BuyBackQty,BuyBackAmt,SaleQty,SaleAmt,SaleBackQty,SaleBackAmt,AdjGainQty,AjgGginAmt,AdjLossQty,AjgLosssAmt,StockQty,StockAmt,EndQty,EndStockAmt,EndDiffQty,EndDiffStockAmt,SaleSubBasePoint,SaleSubPoint,SaleSubAddAmt,SaleSubVendor1Amt,SaleSubVendor2Amt,BackSubAddAmt,BackSubVendor1Amt,BackSubVendor2Amt,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,Remark";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<Settlement>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SettlementDAO.GetPageList",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }

            return page;
        }
    }
}
