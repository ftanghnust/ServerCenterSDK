
/*****************************
* Author:WR
*
* Date:2016-04-14
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
using Frxs.Erp.ServiceCenter.Order.MSSQLDAL;


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### StockAdj数据库访问类
    /// </summary>
    public partial class StockAdjDAO : BaseDAL, IStockAdjDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public StockAdjDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public StockAdjDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "StockAdj";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证StockAdj是否存在
        /// <summary>
        /// 根据主键验证StockAdj是否存在
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(StockAdj model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
             new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.Exists",
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


        #region 添加一个StockAdj
        /// <summary>
        /// 添加一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(StockAdj model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<StockAdj>(model, ref parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.Save",
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


        #region 添加一个StockAdj(事务处理)
        /// <summary>
        /// 添加一个StockAdj(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdj对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, StockAdj model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<StockAdj>(model, ref parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.Save",
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


        #region 更新一个StockAdj
        /// <summary>
        /// 更新一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(StockAdj model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<StockAdj>(model, null, ref parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.Edit",
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


        #region 更新一个StockAdj(事务处理)
        /// <summary>
        /// 更新一个StockAdj(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, StockAdj model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<StockAdj>(model, null, ref parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.Edit",
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


        #region 删除一个StockAdj
        /// <summary>
        /// 删除一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(StockAdj model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.Delete",
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


        #region 根据主键逻辑删除一个StockAdj
        /// <summary>
        /// 根据主键逻辑删除一个StockAdj
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.LogicDelete",
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


        #region 根据字典获取StockAdj对象
        /// <summary>
        /// 根据字典获取StockAdj对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>StockAdj对象</returns>
        public StockAdj GetModel(StockAdjQuery query)
        {
            StockAdj model = null;
            try
            {
                IList<StockAdj> list = GetList(query);
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


        #region 根据主键获取StockAdj对象
        /// <summary>
        /// 根据主键获取StockAdj对象
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>StockAdj对象</returns>
        public StockAdj GetModel(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            StockAdj model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                 new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
                 };
                sp[0].Value = adjID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<StockAdj>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetModel",
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


        #region 根据字典获取StockAdj集合
        /// <summary>
        /// 根据字典获取StockAdj集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<StockAdj> GetList(StockAdjQuery query)
        {
            IList<StockAdj> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);
                List<SqlParameter> lstSp = new List<SqlParameter>();
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    {
                        if (s == null) continue;//防止异常 空的参数不被遍历
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                        lstSp.Add(s);
                    }
                }
                list = GetList(where.ToString(), lstSp.ToArray());
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion


        #region 根据字典获取StockAdj数据集
        /// <summary>
        /// 根据字典获取StockAdj数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetDataSet",
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


        #region 分页获取StockAdj集合
        /// <summary>
        /// 分页获取StockAdj集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<StockAdj> GetPageList(PageListBySql<StockAdj> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                //********* 查询条件 特殊处理 开始 *******
                string sqlStockAdj = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetListStockAdjSql1", base.AssemblyName, base.DatabaseName);
                string sqlAdjDetail = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetListStockAdjSql2", base.AssemblyName, base.DatabaseName);
                IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string where = CreateCondition(conditionDict, ref parameters);
                string tableStr = string.Empty;
                if (string.IsNullOrWhiteSpace(where))
                {
                    tableStr = sqlStockAdj + " WHERE 1=1 ";//查询所有的主表记录
                }
                else
                {
                    //只有查询了详情表的字段才需要用 WHERE  EXISTS()语法
                    if (conditionDict.ContainsKey("ProductName") || conditionDict.ContainsKey("SKU"))//商品名称 StockAdjDetail.ProductName 商品编码 StockAdjDetail.SKU
                    {
                        sqlAdjDetail += (" WHERE " + where + " AND AD.AdjID = A.AdjID ");
                        tableStr = sqlStockAdj + string.Format(" WHERE EXISTS({0})", sqlAdjDetail);
                    }
                    else
                    {//只查询主表条件
                        tableStr = sqlStockAdj + " WHERE " + where;
                    }
                }
                page.TableName = string.Format("({0}) AdjTemp", tableStr); ;//page.TableName = tableName;

                page.Fields = "AdjID,AdjDate,PlanID,WID,WCode,WName,SubWID,SubWCode,SubWName,Status,AdjType,CreateFlag,IsDispose,RefBID,RefAdjID,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                //IList<IDbDataParameter> parameters = null;
                page.Where = string.Empty;      //CreateCondition(conditionDict, ref parameters);
                page.Parameters = (parameters as List<IDbDataParameter>).ToArray();

                //******** 查询条件 特殊处理 结束 ***********
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
                    page.ItemList = DataReaderHelper.ExecuteToList<StockAdj>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetPageList",
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

            if (conditionDict.ContainsKey("AdjID"))//单号 StockAdj.AdjID
            {
                where.Append(" AND A.AdjID like @AdjID");
                parameters.Add(new SqlParameter() { ParameterName = "@AdjID", SqlDbType = SqlDbType.VarChar, Size = 50, Value = "%" + conditionDict["AdjID"].ToString().Trim() + "%" });
            }

            //分库查询时必须传入WID,防止以后合并数据库
            if (conditionDict.ContainsKey("WID"))//仓库ID StockAdj.WID
            {
                where.Append(" AND A.WID = @WID");
                parameters.Add(new SqlParameter() { ParameterName = "@WID", SqlDbType = SqlDbType.Int, Size = 4, Value = conditionDict["WID"] });
            }

            if (conditionDict.ContainsKey("SubWID"))//仓库子机构ID StockAdj.SubWID
            {
                where.Append(" AND A.SubWID = @SubWID");
                parameters.Add(new SqlParameter() { ParameterName = "@SubWID", SqlDbType = SqlDbType.Int, Size = 4, Value = conditionDict["SubWID"] });
            }

            if (conditionDict.ContainsKey("AdjType"))//调整类型(0:调增库存;1:调减库存) StockAdj.AdjType
            {
                where.Append(" AND A.[AdjType] = @AdjType");
                parameters.Add(new SqlParameter() { ParameterName = "@AdjType", SqlDbType = SqlDbType.Int, Size = 4, Value = conditionDict["AdjType"] });
            }

            if (conditionDict.ContainsKey("Status"))//单据状态 StockAdj.[Status]
            {
                where.Append(" AND A.[Status] = @Status");
                parameters.Add(new SqlParameter() { ParameterName = "@Status", SqlDbType = SqlDbType.Int, Size = 4, Value = conditionDict["Status"] });
            }

            if (conditionDict.ContainsKey("AdjDateBegin"))//开单日期 StockAdj.AdjDate 起始时间点
            {
                where.Append(" AND A.AdjDate >= @AdjDateBegin");
                parameters.Add(new SqlParameter() { ParameterName = "@AdjDateBegin", SqlDbType = SqlDbType.DateTime, Value = conditionDict["AdjDateBegin"] });
            }

            if (conditionDict.ContainsKey("AdjDateEnd"))//开单日期 StockAdj.AdjDate 截止时间点
            {
                where.Append(" AND A.AdjDate <= @AdjDateEnd");
                parameters.Add(new SqlParameter() { ParameterName = "@AdjDateEnd", SqlDbType = SqlDbType.DateTime, Value = conditionDict["AdjDateEnd"] });
            }

            if (conditionDict.ContainsKey("CreateFlag"))//2016-6-8 主表增加了字段 CreateFlag 单据创建标识：0：手动创建　1：销售单自动盘盈
            {
                where.Append(" AND A.CreateFlag = @CreateFlag");
                parameters.Add(new SqlParameter() { ParameterName = "@CreateFlag", SqlDbType = SqlDbType.Int, Value = conditionDict["CreateFlag"] });
            }

            if (conditionDict.ContainsKey("IsDispose"))//2016-6-8 主表增加了字段 IsDispose 自动盘盈是否盘亏　0：没有盘亏　1：已盘亏
            {
                where.Append(" AND A.IsDispose = @IsDispose");
                parameters.Add(new SqlParameter() { ParameterName = "@IsDispose", SqlDbType = SqlDbType.Int, Value = conditionDict["IsDispose"] });
            }

            //以下代码：从详情表中查询
            if (conditionDict.ContainsKey("ProductName")) //产品名称 StockAdjDetail.ProductName
            {
                where.Append(" AND AD.ProductName like @ProductName");
                parameters.Add(new SqlParameter() { ParameterName = "@ProductName", SqlDbType = SqlDbType.NVarChar, Size = 200, Value = "%" + conditionDict["ProductName"].ToString().Trim() + "%" });
            }

            //if (conditionDict.ContainsKey("BarCode")) //商品条码 StockAdjDetail.BarCode
            //{
            //    where.Append(" AND AD.BarCode like @BarCode");
            //    parameters.Add(new SqlParameter() { ParameterName = "@BarCode", SqlDbType = SqlDbType.VarChar, Size = 20, Value = "%" + conditionDict["BarCode"] + "%" });
            //}

            if (conditionDict.ContainsKey("SKU")) //商品编号 StockAdjDetail.SKU
            {
                where.Append(" AND AD.SKU like @SKU");
                parameters.Add(new SqlParameter() { ParameterName = "@SKU", SqlDbType = SqlDbType.NVarChar, Size = 50, Value = "%" + conditionDict["SKU"].ToString().Trim() + "%" });
            }
            //string result = new WhereCondition().GetWhereCondition(whereConditionList, ref parameters);
            //where.Append(result);
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


        #region 根据条件获取StockAdj列表
        /// <summary>
        /// 根据条件获取StockAdj列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<StockAdj> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<StockAdj> list = new List<StockAdj>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<StockAdj>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetList",
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

    public partial class StockAdjDAO : BaseDAL, IStockAdjDAO
    {
        #region 删除一个StockAdj
        /// <summary>
        /// 删除一个StockAdj
        /// </summary>
        /// <param name="adjID">主键</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.Delete",
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

        #region 删除一个StockAdj 事务处理
        /// <summary>
        /// 删除一个StockAdj 事务处理
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="adjID">主键</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(IDbConnection conn, IDbTransaction tran, string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
            };
            sp[0].Value = adjID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.Delete",
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

        #region 根据AdjID获取明细表数量
        /// <summary>
        /// 根据AdjID获取明细表数量
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>盘点调整明细表数量</returns>
        public int GetDetailCount(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetDetailCount", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                 new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
                 };
                sp[0].Value = adjID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetDetailCount",
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

        #region 根据AdjID获取明细表最大序号
        /// <summary>
        /// 根据AdjID获取明细表最大序号
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>明细表最大序号</returns>
        public int GetDetailMaxSerialNumber(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetDetailMaxSerialNumber", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                 new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
                 };
                sp[0].Value = adjID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetDetailMaxSerialNumber",
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

        #region 根据AdjID获取调整总数和总金额
        /// <summary>
        /// 根据AdjID获取调整总数和总金额
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>盘点调整单下的总计对象(总数、总金额)</returns>
        public StockAdjSum GetSumQtyAmt(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            StockAdjSum model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSumQtyAmt", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                 new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
                 };
                sp[0].Value = adjID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<StockAdjSum>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetSumQtyAmt",
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

        #region 根据AdjID获取调整 明细的差额对象集合，适用于盘亏单过账操作的异常数据预先排查
        /// <summary>
        /// 根据AdjID获取调整 明细的差额对象集合，适用于盘亏单过账操作的异常数据预先排查
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>明细的差额对象集合</returns>
        public IList<StockAdjDif> GetAdjDif(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<StockAdjDif> list = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetAdjDif", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                 new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
                 };
                sp[0].Value = adjID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                { 
                    list = DataReaderHelper.ExecuteToList<StockAdjDif>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetAdjDif",
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

        #region 根据AdjID检查盘亏单的明细的库存和调整数差额，用于盘亏单过账操作的异常数据预先排查
        /// <summary>
        /// 根据AdjID检查盘亏单的明细的库存和调整数差额，用于盘亏单过账操作的异常数据预先排查
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <returns>明细的差额对象集合</returns>
        public IList<StockAdjDif> GetAdjQtys(string adjID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<StockAdjDif> list = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetAdjQtys", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                 new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
                 };
                sp[0].Value = adjID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<StockAdjDif>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.StockAdj.GetAdjQtys",
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
    }

    public partial class StockAdjDAO : BaseDAL, IStockAdjDAO
    {

        #region IStockAdjDAO 成员

        /// <summary>
        ///  根据orderId获取其盘盈盘亏单
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="adjType">0-盘盈单 1-盘亏单</param>
        /// <returns></returns>
        public IList<StockAdj> GetModelByOrderId(string orderId, int? adjType)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByOrderId", base.AssemblyName, base.DatabaseName);
                SqlParamrterBuilder sp=new SqlParamrterBuilder();
                sp.Add("RefBID",SqlDbType.NVarChar,orderId);
                if(adjType.HasValue)
                {
                    sql += " And AdjType=@AdjType";
                    sp.Add("AdjType",SqlDbType.Int,adjType.Value);
                }
                using (IDataReader dataReader = helper.GetIDataReader(sql, sp.ToSqlParameters()))
                {
                    return this.ExecuteTolist<StockAdj>(dataReader);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDAO.GetModelByOrderId",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        #endregion

        #region IStockAdjDAO 成员

        /// <summary>
        /// 根据单号获取列表
        /// </summary>
        /// <param name="ids">单号列表</param>
        /// <returns></returns>
        public IList<StockAdj> GetListByAdjIds(IList<string> ids)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetListByAdjIds", base.AssemblyName, base.DatabaseName);
                
                StringBuilder sb=new StringBuilder();
                if (ids == null || ids.Count <= 0)
                {
                    return null;
                }
                int i = 1;
                SqlParamrterBuilder sp = new SqlParamrterBuilder();
                foreach (var id in ids)
                {
                    sb.Append(string.Format(" @AdjID{0} ,", i));
                    sp.Add(string.Format("AdjID{0}", i), id);
                    i++;
                }
                sql += " And AdjID in (" + sb.ToString(0, sb.Length - 1) + " )";
                using (IDataReader dataReader = helper.GetIDataReader(sql, sp.ToSqlParameters()))
                {
                    return this.ExecuteTolist<StockAdj>(dataReader);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDAO.GetListByAdjIds",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        #endregion
    }
}