
/*****************************
* Author:TangFan
*
* Date:2016-04-27
******************************/
using System;
using System.Collections.Generic;
using System.Text;
using Frxs.Erp.ServiceCenter.ID.Model;
using System.Data.SqlClient;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;
using Frxs.Erp.ServiceCenter.ID.IDAL;


namespace Frxs.Erp.ServiceCenter.ID.MSSQLDAL
{
    /// <summary>
    /// ### XSOperatorLog数据库访问类
    /// </summary>
    public partial class XSOperatorLogDAO : BaseDAL, IXSOperatorLogDAO
    {
        const string tableName = "XSOperatorLog";

        #region 添加一个XSOperatorLog
        /// <summary>
        /// 添加一个XSOperatorLog
        /// </summary>
        /// <param name="model">XSOperatorLog对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(Frxs.Erp.ServiceCenter.ID.Model.XSOperatorLog model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.OpLogDatabaseName);
            SqlParameter[] sp = {
                            new SqlParameter("@IPAddress", SqlDbType.VarChar, 50),
                            new SqlParameter("@WID", SqlDbType.Int),
                            new SqlParameter("@MenuID", SqlDbType.Int),
                            new SqlParameter("@MenuName", SqlDbType.VarChar, 50),
                            new SqlParameter("@Action", SqlDbType.VarChar, 50),
                            new SqlParameter("@Remark", SqlDbType.VarChar, 1000),
                            new SqlParameter("@OperatorID", SqlDbType.Int),
                            new SqlParameter("@OperatorName", SqlDbType.VarChar, 64),
                            new SqlParameter("@CreateTime", SqlDbType.DateTime)

                            };
            sp[0].Value = model.IPAddress;
            sp[1].Value = model.WID;
            sp[2].Value = model.MenuID;
            sp[3].Value = model.MenuName;
            sp[4].Value = model.Action;
            sp[5].Value = model.Remark;
            sp[6].Value = model.OperatorID;
            sp[7].Value = model.OperatorName;
            sp[8].Value = model.CreateTime;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.ID.MSSQLDAL.XSOperatorLogDAO.Save",
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

        #region 分页获取XSOperatorLog集合
        /// <summary>
        /// 分页获取XSOperatorLog集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Frxs.Erp.ServiceCenter.ID.Model.XSOperatorLog> GetPageList(PageListBySql<Frxs.Erp.ServiceCenter.ID.Model.XSOperatorLog> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,IPAddress,WID,MenuID,MenuName,Action,Remark,OperatorID,OperatorName,CreateTime";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<Frxs.Erp.ServiceCenter.ID.Model.XSOperatorLog>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.ID.MSSQLDAL.XSOperatorLogDAO.GetPageList",
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

            if (conditionDict.ContainsKey("WID") && conditionDict["WID"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "WID",
                        FieldValue = conditionDict["WID"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                    }
                });
            }
            if (conditionDict.ContainsKey("IPAddress") && conditionDict["IPAddress"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "IPAddress",
                        FieldValue = conditionDict["IPAddress"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 50
                    }
                });
            }
            if (conditionDict.ContainsKey("MenuID") && conditionDict["MenuID"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "MenuID",
                        FieldValue = conditionDict["MenuID"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                    }
                });
            }
            if (conditionDict.ContainsKey("Action") && conditionDict["Action"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "Action",
                        FieldValue = conditionDict["Action"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 50
                    }
                });
            }
            if (conditionDict.ContainsKey("Remark") && conditionDict["Remark"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "Remark",
                        FieldValue = conditionDict["Remark"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 1000
                    }
                });
            }
            if (conditionDict.ContainsKey("OperatorID") && conditionDict["OperatorID"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "OperatorID",
                        FieldValue = conditionDict["OperatorID"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
                    }
                });
            }
            if (conditionDict.ContainsKey("OperatorName") && conditionDict["OperatorName"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "OperatorName",
                        FieldValue = conditionDict["OperatorName"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 64
                    }
                });
            }
            if (conditionDict.ContainsKey("BeginTime") && conditionDict["BeginTime"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.MoreThanOrEquals,
                    FieldObj = new Field
                    {
                        FieldName = "CreateTime",
                        FieldValue = conditionDict["BeginTime"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                    }
                });
            }
            if (conditionDict.ContainsKey("EndTime") && conditionDict["EndTime"] != null)
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.LessThanOrEquals,
                    FieldObj = new Field
                    {
                        FieldName = "CreateTime",
                        FieldValue = conditionDict["EndTime"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime),
                        ParamterName = "CreateTime1"
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

        public IList<XSOperatorLogMenu> GetXSOperatorLogMenu()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetXSOperatorLogMenu", base.AssemblyName, base.OpLogDatabaseName);
                using (var sqlDataReader = helper.GetIDataReader(sql, null))
                {
                    var list = DataReaderHelper.ExecuteToList<XSOperatorLogMenu>(sqlDataReader);
                    return list;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.ID.MSSQLDAL.XSOperatorLogDAO.GetXSOperatorLogMenu",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }
    }
}