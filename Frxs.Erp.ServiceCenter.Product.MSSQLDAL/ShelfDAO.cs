
/*****************************
* Author:CR
*
* Date:2016-03-07
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
using Frxs.Platform.Utility;


namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// ### 仓库货架表Shelf数据库访问类
    /// </summary>
    public partial class ShelfDAO : BaseDAL, IShelfDAO
    {
        const string tableName = "Shelf";

        protected override string TableName
        {
            get { return tableName; }
        }


        #region 成员方法
        #region 根据主键验证Shelf是否存在
        /// <summary>
        /// 根据主键验证Shelf是否存在
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(Shelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ShelfID", SqlDbType.Int)
 };
            sp[0].Value = model.ShelfID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.Exists",
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


        #region 添加一个Shelf
        /// <summary>
        /// 添加一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(Shelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ShelfCode", SqlDbType.VarChar, 50),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfType", SqlDbType.VarChar, 32),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.VarChar, 32),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)
};
            sp[0].Value = model.ShelfCode;
            sp[1].Value = model.ShelfAreaID;
            sp[2].Value = model.ShelfType;
            sp[3].Value = model.WID;
            sp[4].Value = model.Status;
            sp[5].Value = model.Remark;
            sp[6].Value = DateTime.Now;
            sp[7].Value = model.ModifyUserID;
            sp[8].Value = model.ModifyUserName;
            

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.Save",
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


        #region 更新一个Shelf
        /// <summary>
        /// 更新一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(Shelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ShelfCode", SqlDbType.VarChar, 50),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfType", SqlDbType.VarChar, 32),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.VarChar, 32),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfID", SqlDbType.Int)

};
            sp[0].Value = model.ShelfCode;
            sp[1].Value = model.ShelfAreaID;
            sp[2].Value = model.ShelfType;
            sp[3].Value = model.WID;
            sp[4].Value = model.Status;
            sp[5].Value = model.Remark;
            sp[6].Value = DateTime.Now;
            sp[7].Value = model.ModifyUserID;
            sp[8].Value = model.ModifyUserName;
           
            sp[9].Value = model.ShelfID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.Edit",
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


        #region 删除一个Shelf
        /// <summary>
        /// 删除一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(Shelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ShelfID", SqlDbType.Int)
 };
            sp[0].Value = model.ShelfID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.Delete",
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


        #region 根据主键逻辑删除一个Shelf
        /// <summary>
        /// 根据主键逻辑删除一个Shelf
        /// </summary>
        /// <param name="shelfID">ID(主键)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int shelfID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ShelfID", SqlDbType.Int)
 };
            sp[0].Value = shelfID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.LogicDelete",
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


        #region 根据字典获取Shelf对象
        /// <summary>
        /// 根据字典获取Shelf对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Shelf对象</returns>
        public Shelf GetModel(IDictionary<string, object> conditionDict)
        {
            Shelf model = null;
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
                IList<Shelf> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取Shelf对象
        /// <summary>
        /// 根据主键获取Shelf对象
        /// </summary>
        /// <param name="shelfID">ID(主键)</param>
        /// <returns>Shelf对象</returns>
        public Shelf GetModel(int shelfID)
        {
            DBHelper helper = DBHelper.GetInstance();
            Shelf model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ShelfID", SqlDbType.Int)
 };
                sp[0].Value = shelfID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new Shelf
                        {
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null),
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            ShelfType = DataTypeHelper.GetString(sdr["ShelfType"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetString(sdr["Status"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.GetModel",
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


        #region 根据字典获取Shelf集合
        /// <summary>
        /// 根据字典获取Shelf集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<Shelf> GetList(IDictionary<string, object> conditionDict)
        {
            IList<Shelf> list = null;
            try
            {
                
                
                IList<IDbDataParameter> parameters = null;
                string where = " where "+CreateCondition(conditionDict, ref parameters);

                #region 增加扩展条件
                if (conditionDict.ContainsKey("ShelfCodeList")) 
                {
                    var inStr=string.Join(",",(IList<string>)conditionDict["ShelfCodeList"]);
                    where = where + string.Format(" and ShelfCode in({0}) ", inStr);
                }
                #endregion
                list = GetList(where.ToString(), (parameters as List<IDbDataParameter>).ToArray());
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion


        #region 根据字典获取Shelf数据集
        /// <summary>
        /// 根据字典获取Shelf数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.GetDataSet",
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



        #region 分页获取Shelf集合
        /// <summary>
        /// 分页获取Shelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Shelf> GetPageList(PageListBySql<Shelf> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = " (select a.*,b.ShelfAreaName,c.WName from Shelf a inner join ShelfArea b on a.ShelfAreaID=b.ShelfAreaID inner join Warehouse c on a.WID=c.WID) a ";
                page.Fields = "ShelfID,ShelfCode,ShelfAreaID,ShelfType,WID,Status,ShelfAreaName,WName,Remark";
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
                        page.ItemList.Add(new Shelf
                        {
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null),
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            ShelfType = DataTypeHelper.GetString(sdr["ShelfType"], null)=="0"?"存储":"",
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetString(sdr["Status"], null),
                            ShelfAreaName = DataTypeHelper.GetString(sdr["ShelfAreaName"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 1 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.UpdateField",
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

            if (conditionDict.ContainsKey("ShelfCode"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ShelfCode",
                        FieldValue = conditionDict["ShelfCode"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("ShelfAreaID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ShelfAreaID",
                        FieldValue = conditionDict["ShelfAreaID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("Status"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "Status",
                        FieldValue = conditionDict["Status"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

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

            if (conditionDict.ContainsKey("ShelfCodeStart"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.MoreThanOrEquals,
                    FieldObj = new Field
                    {
                        FieldName = "ShelfCode",
                        FieldValue = conditionDict["ShelfCodeStart"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }
            
            if (conditionDict.ContainsKey("ShelfCodeEnd"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.LessThanOrEquals,
                    FieldObj = new Field
                    {
                        FieldName = "ShelfCode",
                        ParamterName = "ShelfCodeWhere",
                        FieldValue = conditionDict["ShelfCodeEnd"],
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
                return "ModifyTime desc";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取Shelf列表
        /// <summary>
        /// 根据条件获取Shelf列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<Shelf> GetList(string where, IDbDataParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<Shelf> list = new List<Shelf>();
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
                        list.Add(new Shelf
                        {
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null),
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            ShelfType = DataTypeHelper.GetString(sdr["ShelfType"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            Status = DataTypeHelper.GetString(sdr["Status"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.GetList",
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

    public partial class ShelfDAO : BaseDAL, IShelfDAO
    {
        #region 根据货位编号(同一个仓库不能重复)验证货位是否存在
        /// <summary>
        /// 根据名称验证ProductName是否存在
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsShelfCode(Shelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsShelfCode", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@ShelfCode", SqlDbType.NVarChar, 100),
                    new SqlParameter("@WID", SqlDbType.NVarChar, 100),
                    new SqlParameter("@ShelfID", SqlDbType.NVarChar, 100)
                };
            sp[0].Value = model.ShelfCode;
            sp[1].Value = model.WID;
            sp[2].Value = model.ShelfID;
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.ExistsShelfCode",
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

        #region 获取连接
        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns>连接对象</returns>
        public IDbConnection GetConnection()
        {            
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString());
        }
        #endregion

        #region 根据货位编号(同一个仓库不能重复)验证货位是否使用
        /// <summary>
        /// 根据货位编号(同一个仓库不能重复)验证货位是否使用
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public IList<Shelf> ExistsShelIDs(string ShelIDs)
        {
            IList<Shelf> list = null;

            string sql = " where ShelfID in(select ShelfID from WProducts where ShelfID in(" + ShelIDs + ")) ";
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

        #region 添加一个Shelf(事务处理)
        /// <summary>
        /// 添加一个Shelf(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">Shelf对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, Shelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ShelfCode", SqlDbType.VarChar, 50),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfType", SqlDbType.VarChar, 32),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.VarChar, 32),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ShelfCode;
            sp[1].Value = model.ShelfAreaID;
            sp[2].Value = model.ShelfType;
            sp[3].Value = model.WID;
            sp[4].Value = model.Status;
            sp[5].Value = model.Remark;
            sp[6].Value = model.ModifyTime;
            sp[7].Value = model.ModifyUserID;
            sp[8].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShelfDAO.Save",
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

        #region 根据货位编号(同一个仓库不能重复)验证货位是否存在（事物处理）
        /// <summary>
        /// 根据名称验证ProductName是否存在
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsShelfCode(IDbConnection conn, IDbTransaction tran, Shelf model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsShelfCode", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@ShelfCode", SqlDbType.NVarChar, 100),
                    new SqlParameter("@WID", SqlDbType.NVarChar, 100),
                    new SqlParameter("@ShelfID", SqlDbType.NVarChar, 100)
                };
            sp[0].Value = model.ShelfCode;
            sp[1].Value = model.WID;
            sp[2].Value = model.ShelfID;
            try
            {
                result = int.Parse(helper.GetSingle(conn, tran,sql, sp).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shelf.ExistsShelfCode",
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

    }
}