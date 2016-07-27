
/*****************************
* Author:CR
*
* Date:2016-03-10
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
    /// ### 仓库主表Warehouse数据库访问类
    /// </summary>
    public partial class WarehouseDAO : BaseDAL, IWarehouseDAO
    {
        const string tableName = "Warehouse";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证Warehouse是否存在
        /// <summary>
        /// 根据主键验证Warehouse是否存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(Warehouse model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int)
            };
            sp[0].Value = model.WID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.Exists",
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


        #region 添加一个Warehouse
        /// <summary>
        /// 添加一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(Warehouse model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@WCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WName", SqlDbType.NVarChar, 50),
            new SqlParameter("@WLevel", SqlDbType.Int),
            new SqlParameter("@WSubType", SqlDbType.Int),
            new SqlParameter("@ParentWID", SqlDbType.Int),
            new SqlParameter("@WTel", SqlDbType.VarChar, 16),
            new SqlParameter("@WContact", SqlDbType.VarChar, 32),
            new SqlParameter("@ProvinceID", SqlDbType.Int),
            new SqlParameter("@CityID", SqlDbType.Int),
            new SqlParameter("@RegionID", SqlDbType.Int),
            new SqlParameter("@WAddress", SqlDbType.NVarChar, 100),
            new SqlParameter("@WFullAddress", SqlDbType.NVarChar, 200),
            new SqlParameter("@WCustomerServiceTel", SqlDbType.VarChar, 16),
            new SqlParameter("@THBTel", SqlDbType.VarChar, 16),
            new SqlParameter("@CWTel", SqlDbType.VarChar, 16),
            new SqlParameter("@YW1Tel", SqlDbType.VarChar, 16),
            new SqlParameter("@YW2Tel", SqlDbType.VarChar, 16),
            new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
            new SqlParameter("@IsFreeze", SqlDbType.Int),
            new SqlParameter("@IsDeleted", SqlDbType.Int),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@ModityTime", SqlDbType.DateTime),
            new SqlParameter("@ModityUserID", SqlDbType.Int),
            new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.WCode;
            sp[1].Value = model.WName;
            sp[2].Value = model.WLevel;
            sp[3].Value = model.WSubType;
            sp[4].Value = model.ParentWID;
            sp[5].Value = model.WTel;
            sp[6].Value = model.WContact;
            sp[7].Value = model.ProvinceID;
            sp[8].Value = model.CityID;
            sp[9].Value = model.RegionID;
            sp[10].Value = model.WAddress;
            sp[11].Value = model.WFullAddress;
            sp[12].Value = model.WCustomerServiceTel;
            sp[13].Value = model.THBTel;
            sp[14].Value = model.CWTel;
            sp[15].Value = model.YW1Tel;
            sp[16].Value = model.YW2Tel;
            sp[17].Value = model.Remark;
            sp[18].Value = model.IsFreeze;
            sp[19].Value = model.IsDeleted;
            sp[20].Value = model.CreateTime;
            sp[21].Value = model.CreateUserID;
            sp[22].Value = model.CreateUserName;
            sp[23].Value = model.ModityTime;
            sp[24].Value = model.ModityUserID;
            sp[25].Value = model.ModityUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.Save",
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


        #region 更新一个Warehouse
        /// <summary>
        /// 更新一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(Warehouse model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@WCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WName", SqlDbType.NVarChar, 50),
            new SqlParameter("@WLevel", SqlDbType.Int),
            new SqlParameter("@WSubType", SqlDbType.Int),
            new SqlParameter("@ParentWID", SqlDbType.Int),
            new SqlParameter("@WTel", SqlDbType.VarChar, 16),
            new SqlParameter("@WContact", SqlDbType.VarChar, 32),
            new SqlParameter("@ProvinceID", SqlDbType.Int),
            new SqlParameter("@CityID", SqlDbType.Int),
            new SqlParameter("@RegionID", SqlDbType.Int),
            new SqlParameter("@WAddress", SqlDbType.NVarChar, 100),
            new SqlParameter("@WFullAddress", SqlDbType.NVarChar, 200),
            new SqlParameter("@WCustomerServiceTel", SqlDbType.VarChar, 16),
            new SqlParameter("@THBTel", SqlDbType.VarChar, 16),
            new SqlParameter("@CWTel", SqlDbType.VarChar, 16),
            new SqlParameter("@YW1Tel", SqlDbType.VarChar, 16),
            new SqlParameter("@YW2Tel", SqlDbType.VarChar, 16),
            new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
            new SqlParameter("@IsFreeze", SqlDbType.Int),
            new SqlParameter("@IsDeleted", SqlDbType.Int),
            new SqlParameter("@ModityTime", SqlDbType.DateTime),
            new SqlParameter("@ModityUserID", SqlDbType.Int),
            new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int)

            };
            sp[0].Value = model.WCode;
            sp[1].Value = model.WName;
            sp[2].Value = model.WLevel;
            sp[3].Value = model.WSubType;
            sp[4].Value = model.ParentWID;
            sp[5].Value = model.WTel;
            sp[6].Value = model.WContact;
            sp[7].Value = model.ProvinceID;
            sp[8].Value = model.CityID;
            sp[9].Value = model.RegionID;
            sp[10].Value = model.WAddress;
            sp[11].Value = model.WFullAddress;
            sp[12].Value = model.WCustomerServiceTel;
            sp[13].Value = model.THBTel;
            sp[14].Value = model.CWTel;
            sp[15].Value = model.YW1Tel;
            sp[16].Value = model.YW2Tel;
            sp[17].Value = model.Remark;
            sp[18].Value = model.IsFreeze;
            sp[19].Value = model.IsDeleted;
            sp[20].Value = model.ModityTime;
            sp[21].Value = model.ModityUserID;
            sp[22].Value = model.ModityUserName;
            sp[23].Value = model.WID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.Edit",
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


        #region 删除一个Warehouse
        /// <summary>
        /// 删除一个Warehouse
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(Warehouse model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int)
            };
            sp[0].Value = model.WID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.Delete",
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


        #region 根据主键逻辑删除一个Warehouse
        /// <summary>
        /// 根据主键逻辑删除一个Warehouse
        /// </summary>
        /// <param name="wID">Warehouse对象</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(Warehouse model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@ModityTime", SqlDbType.DateTime),
            new SqlParameter("@ModityUserID", SqlDbType.Int),
            new SqlParameter("@ModityUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int)
            };
            sp[0].Value = model.ModityTime;
            sp[1].Value = model.ModityUserID;
            sp[2].Value = model.ModityUserName;
            sp[3].Value = model.WID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.LogicDelete",
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


        #region 根据字典获取Warehouse对象
        /// <summary>
        /// 根据字典获取Warehouse对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Warehouse对象</returns>
        public Warehouse GetModel(IDictionary<string, object> conditionDict)
        {
            Warehouse model = null;
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
                IList<Warehouse> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取Warehouse对象
        /// <summary>
        /// 根据主键获取Warehouse对象
        /// </summary>
        /// <param name="wID">仓库ID(从1000开始编号)</param>
        /// <returns>Warehouse对象</returns>
        public Warehouse GetModel(int wID)
        {
            DBHelper helper = DBHelper.GetInstance();
            Warehouse model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                new SqlParameter("@WID", SqlDbType.Int)
                };
                sp[0].Value = wID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new Warehouse
                        {
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            WLevel = DataTypeHelper.GetInt(sdr["WLevel"]),
                            WSubType = DataTypeHelper.GetInt(sdr["WSubType"]),
                            ParentWID = DataTypeHelper.GetInt(sdr["ParentWID"]),
                            WTel = DataTypeHelper.GetString(sdr["WTel"], null),
                            WContact = DataTypeHelper.GetString(sdr["WContact"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            WAddress = DataTypeHelper.GetString(sdr["WAddress"], null),
                            WFullAddress = DataTypeHelper.GetString(sdr["WFullAddress"], null),
                            WCustomerServiceTel = DataTypeHelper.GetString(sdr["WCustomerServiceTel"], null),
                            THBTel = DataTypeHelper.GetString(sdr["THBTel"], null),
                            CWTel = DataTypeHelper.GetString(sdr["CWTel"], null),
                            YW1Tel = DataTypeHelper.GetString(sdr["YW1Tel"], null),
                            YW2Tel = DataTypeHelper.GetString(sdr["YW2Tel"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            IsFreeze = DataTypeHelper.GetInt(sdr["IsFreeze"]),
                            FreezeStatus = DataTypeHelper.GetInt(sdr["IsFreeze"]) == 1 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTime(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.GetModel",
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


        #region 根据字典获取Warehouse集合
        /// <summary>
        /// 根据字典获取Warehouse集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<Warehouse> GetList(IDictionary<string, object> conditionDict)
        {
            IList<Warehouse> list = null;
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


        #region 根据字典获取Warehouse数据集
        /// <summary>
        /// 根据字典获取Warehouse数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.GetDataSet",
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


        #region 分页获取Warehouse集合
        /// <summary>
        /// 分页获取Warehouse集合 包含了自定义字段SubNum
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Warehouse> GetPageList(PageListBySql<Warehouse> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetPageList", base.AssemblyName, base.DatabaseName); //从配置文件读取SQL脚本信息;
                page.Fields = "ShopNum,SubNum,WID,WCode,WName,WLevel,WSubType,ParentWID,WTel,WContact,ProvinceID,CityID,RegionID,WAddress,WFullAddress,WCustomerServiceTel,THBTel,CWTel,YW1Tel,YW2Tel,Remark,IsFreeze,IsDeleted,CreateTime,CreateUserID,CreateUserName,ModityTime,ModityUserID,ModityUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);
                if (string.IsNullOrEmpty(page.Where))
                {
                    page.Where += " IsDeleted=0 ";
                }
                else
                {
                    page.Where += " and IsDeleted=0 ";
                }
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
                        page.ItemList.Add(new Warehouse
                        {
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            WLevel = DataTypeHelper.GetInt(sdr["WLevel"]),
                            WSubType = DataTypeHelper.GetInt(sdr["WSubType"]),
                            ParentWID = DataTypeHelper.GetInt(sdr["ParentWID"]),
                            WTel = DataTypeHelper.GetString(sdr["WTel"], null),
                            WContact = DataTypeHelper.GetString(sdr["WContact"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            WAddress = DataTypeHelper.GetString(sdr["WAddress"], null),
                            WFullAddress = DataTypeHelper.GetString(sdr["WFullAddress"], null),
                            WCustomerServiceTel = DataTypeHelper.GetString(sdr["WCustomerServiceTel"], null),
                            THBTel = DataTypeHelper.GetString(sdr["THBTel"], null),
                            CWTel = DataTypeHelper.GetString(sdr["CWTel"], null),
                            YW1Tel = DataTypeHelper.GetString(sdr["YW1Tel"], null),
                            YW2Tel = DataTypeHelper.GetString(sdr["YW2Tel"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            IsFreeze = DataTypeHelper.GetInt(sdr["IsFreeze"]),
                            FreezeStatus = DataTypeHelper.GetInt(sdr["IsFreeze"]) == 1 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTime(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null),
                            SubNum = DataTypeHelper.GetInt(sdr["SubNum"], 0),
                            ShopNum = DataTypeHelper.GetInt(sdr["ShopNum"], 0)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.UpdateField",
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

            if (conditionDict.ContainsKey("WCode"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "WCode",
                        FieldValue = conditionDict["WCode"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }
            if (conditionDict.ContainsKey("WName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "WName",
                        FieldValue = conditionDict["WName"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("ParentWID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ParentWID",
                        FieldValue = conditionDict["ParentWID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("WContact"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "WContact",
                        FieldValue = conditionDict["WContact"].ToString().Trim(),
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("IsFreeze"))
            {
                //var IsFreezeObj = conditionDict["IsFreeze"];                
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "IsFreeze",
                        FieldValue = conditionDict["IsFreeze"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
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
                return "WID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取Warehouse列表
        /// <summary>
        /// 根据条件获取Warehouse列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<Warehouse> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<Warehouse> list = new List<Warehouse>();
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
                        list.Add(new Warehouse
                        {
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            WLevel = DataTypeHelper.GetInt(sdr["WLevel"]),
                            WSubType = DataTypeHelper.GetInt(sdr["WSubType"]),
                            ParentWID = DataTypeHelper.GetInt(sdr["ParentWID"]),
                            WTel = DataTypeHelper.GetString(sdr["WTel"], null),
                            WContact = DataTypeHelper.GetString(sdr["WContact"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            WAddress = DataTypeHelper.GetString(sdr["WAddress"], null),
                            WFullAddress = DataTypeHelper.GetString(sdr["WFullAddress"], null),
                            WCustomerServiceTel = DataTypeHelper.GetString(sdr["WCustomerServiceTel"], null),
                            THBTel = DataTypeHelper.GetString(sdr["THBTel"], null),
                            CWTel = DataTypeHelper.GetString(sdr["CWTel"], null),
                            YW1Tel = DataTypeHelper.GetString(sdr["YW1Tel"], null),
                            YW2Tel = DataTypeHelper.GetString(sdr["YW2Tel"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            IsFreeze = DataTypeHelper.GetInt(sdr["IsFreeze"]),
                            FreezeStatus = DataTypeHelper.GetInt(sdr["IsFreeze"]) == 1 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModityTime = DataTypeHelper.GetDateTime(sdr["ModityTime"]),
                            ModityUserID = DataTypeHelper.GetInt(sdr["ModityUserID"]),
                            ModityUserName = DataTypeHelper.GetString(sdr["ModityUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.GetList",
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

    public partial class WarehouseDAO : BaseDAL, IWarehouseDAO
    {
        /// <summary>
        /// 根据仓库编号WCode验证仓库是否存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsWCode(Warehouse model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            List<SqlParameter> sp = new List<SqlParameter>();
            sp.Add(new SqlParameter("@WCode", SqlDbType.NVarChar, 100) { Value = model.WCode });
            string sql = "SELECT COUNT(1) FROM Warehouse WHERE IsDeleted=0 and WCode=@WCode";
            if (model.WID > 0)
            {
                sql += " AND WID<>@WID";
                sp.Add(new SqlParameter("@WID", SqlDbType.Int) { Value = model.WID });
            }
            try
            {
                result = int.Parse(helper.GetSingle(sql, sp.ToArray()).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.ExistsWCode",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return result > 0;
        }

        /// <summary>
        /// 根据仓库名称验证仓库是否存在
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsWName(Warehouse model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            List<SqlParameter> sp = new List<SqlParameter>();
            sp.Add(new SqlParameter("@WName", SqlDbType.NVarChar, 50) { Value = model.WName });
            string sql = "SELECT COUNT(1) FROM Warehouse WHERE IsDeleted=0 and WName=@WName";
            if (model.WID > 0)
            {
                sql += " AND WID<>@WID";
                sp.Add(new SqlParameter("@WID", SqlDbType.Int) { Value = model.WID });
            }
            try
            {
                result = int.Parse(helper.GetSingle(sql, sp.ToArray()).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.ExistsWName",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return result > 0;
        }

        /// <summary>
        /// 冻结或解冻仓库
        /// </summary>
        /// <param name="model">Warehouse对象</param>
        /// <returns>影响的记录个数</returns>
        public int WarehouseFreeze(Warehouse model)
        {

            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "WarehouseFreeze", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {    
                    new SqlParameter("@IsFreeze", SqlDbType.Int),
                    new SqlParameter("@ModityTime", SqlDbType.DateTime),
                    new SqlParameter("@ModityUserID", SqlDbType.Int),
                    new SqlParameter("@ModityUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@WID", SqlDbType.NVarChar, 100)
                };
            sp[0].Value = model.IsFreeze;
            sp[1].Value = model.ModityTime;
            sp[2].Value = model.ModityUserID;
            sp[3].Value = model.ModityUserName;
            sp[4].Value = model.WID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.Freeze",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return result;
        }


        #region 获取子机构相关信息
        /// <summary>
        /// 获取子机构相关信息
        /// </summary>
        /// <param name="conditionDict"></param>        
        /// <returns></returns>
        public IList<SubWName> GetSubWName(IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<SubWName> list = new List<SubWName>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    { where.Append(string.Format(" AND s.{0}=@{0}", s.ParameterName)); }
                }
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSubWName", base.AssemblyName, base.DatabaseName);//从配置文件读取SQL脚本信息;

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new SubWName
                        {
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWID = DataTypeHelper.GetInt(sdr["SubWID"]),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SUBWName = DataTypeHelper.GetString(sdr["SUBWName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.GetSubWName",
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


        #region 获取子机构数量
        /// <summary>
        /// 获取子机构数量
        /// </summary>
        /// <param name="WID">仓库ID</param>        
        /// <returns>子机构数量</returns>
        public int GetSubNum(int WID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSubNum", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int)
            };
            sp[0].Value = WID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.GetSubNum",
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

        #region 获取仓库中的商品数量
        /// <summary>
        /// 获取仓库中的商品数量
        /// </summary>
        /// <param name="WID">仓库ID</param>        
        /// <returns>仓库中的商品数量</returns>
        public int GetWProductsNum(int WID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetWProductsNum", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int)
            };
            sp[0].Value = WID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.GetWProductsNum",
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

        #region 获取仓库所管理的门店数量
        /// <summary>
        /// 获取仓库所管理的门店数量
        /// </summary>
        /// <param name="WID">仓库ID</param>        
        /// <returns>仓库所管理的门店数量</returns>
        public int GetShopNum(int WID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetShopNum", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int)
            };
            sp[0].Value = WID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Warehouse.GetShopNum",
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


        /// <summary>
        /// 验证仓库也仓库子机构是否合法
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="subWid"></param>
        /// <returns></returns>
        public IList<Warehouse> GetWarehouseSubWarehouse(int wid, int subWid)
        {
            DBHelper helper = DBHelper.GetInstance();
            List<SqlParameter> sp = new List<SqlParameter>();
            string sql = "select WID,WCode,WName,ParentWID,IsFreeze,IsDeleted from dbo.Warehouse where ParentWID=@ParentWID and WID=@WID";
            sp.Add(new SqlParameter("@ParentWID", SqlDbType.Int) { Value = wid });
            sp.Add(new SqlParameter("@WID", SqlDbType.Int) { Value = subWid });
            IList<Warehouse> itemList = new List<Warehouse>();
            try
            {
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp.ToArray()) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        itemList.Add(new Warehouse
                        {
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            ParentWID = DataTypeHelper.GetInt(sdr["ParentWID"]),
                            IsFreeze = DataTypeHelper.GetInt(sdr["IsFreeze"]),
                            FreezeStatus = DataTypeHelper.GetInt(sdr["IsFreeze"]) == 1 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"])
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
                        LogOperation = "GetWarehouseSubWarehouse",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return itemList;
        }
    }
}