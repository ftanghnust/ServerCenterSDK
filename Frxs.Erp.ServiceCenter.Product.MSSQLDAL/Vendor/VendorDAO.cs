
/*****************************
* Author:叶求
*
* Date:2016-03-09
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
    /// ### 供应商表Vendor数据库访问类
    /// </summary>
    public partial class VendorDAO : BaseDAL, IVendorDAO
    {
        const string tableName = "Vendor";

        protected override string TableName
        {
            get { return tableName; }
        }


        #region 成员方法
        #region 根据主键验证Vendor是否存在
        /// <summary>
        /// 根据主键验证Vendor是否存在
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>是否存在</returns>
        public List<int> GetExitsVendorID(string vendorCode, string vendorName)
        {
            DBHelper helper = DBHelper.GetInstance();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT VendorID FROM Vendor WHERE 1=2");
            List<SqlParameter> list = new List<SqlParameter>();
            List<int> lisids = new List<int>();

            if (!string.IsNullOrEmpty(vendorCode))
            {
                sb.Append(" or VendorCode=@VendorCode");
                list.Add(new SqlParameter("@VendorCode", SqlDbType.VarChar, 32) { Value = vendorCode });
            }
            if (!string.IsNullOrEmpty(vendorName))
            {
                sb.Append(" or VendorName=@VendorName");
                list.Add(new SqlParameter("@VendorName", SqlDbType.VarChar, 50) { Value = vendorName });
            }

            try
            {
                using (SqlDataReader sdr = helper.GetIDataReader(sb.ToString(), list.ToArray()) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        lisids.Add(DataTypeHelper.GetInt(sdr["VendorID"]));
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.GetExitsVendorID",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return lisids;
        }


        #endregion


        #region 添加一个Vendor
        /// <summary>
        /// 添加一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(Vendor model, IDbTransaction tran = null, IDbConnection conn = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
                    new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@VendorShortName", SqlDbType.NVarChar, 20),
                    new SqlParameter("@VendorTypeID", SqlDbType.Int),
                    new SqlParameter("@LinkMan", SqlDbType.NVarChar, 20),
                    new SqlParameter("@Telephone", SqlDbType.VarChar, 20),
                    new SqlParameter("@Fax", SqlDbType.VarChar, 20),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@LegalPerson", SqlDbType.VarChar, 20),
                    new SqlParameter("@Email", SqlDbType.VarChar, 200),
                    new SqlParameter("@WebUrl", SqlDbType.VarChar, 200),
                    new SqlParameter("@Region", SqlDbType.VarChar, 20),
                    new SqlParameter("@SettleTimeType", SqlDbType.VarChar, 32),
                    new SqlParameter("@CreditLevel", SqlDbType.NVarChar, 32),
                    new SqlParameter("@AreaPrincipal", SqlDbType.NVarChar, 20),
                    new SqlParameter("@ProvinceID", SqlDbType.Int),
                    new SqlParameter("@CityID", SqlDbType.Int),
                    new SqlParameter("@RegionID", SqlDbType.Int),
                    new SqlParameter("@Address", SqlDbType.VarChar, 100),
                    new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
                    new SqlParameter("@IsDeleted", SqlDbType.Int),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreateUserID", SqlDbType.Int),
                    new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@PaymentDateType", SqlDbType.VarChar, 32),
                    new SqlParameter("@VExt1", SqlDbType.VarChar, 50),
                    new SqlParameter("@VExt2", SqlDbType.VarChar, 50)
                };
            sp[0].Value = model.VendorCode;
            sp[1].Value = model.VendorName;
            sp[2].Value = model.VendorShortName;
            sp[3].Value = model.VendorTypeID;
            sp[4].Value = model.LinkMan;
            sp[5].Value = model.Telephone;
            sp[6].Value = model.Fax;
            sp[7].Value = model.Status;
            sp[8].Value = model.LegalPerson;
            sp[9].Value = model.Email;
            sp[10].Value = model.WebUrl;
            sp[11].Value = model.Region;
            sp[12].Value = model.SettleTimeType;
            sp[13].Value = model.CreditLevel;
            sp[14].Value = model.AreaPrincipal;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.Address;
            sp[19].Value = model.FullAddress;
            sp[20].Value = model.IsDeleted;
            sp[21].Value = model.CreateTime;
            sp[22].Value = model.CreateUserID;
            sp[23].Value = model.CreateUserName;
            sp[24].Value = model.ModifyTime;
            sp[25].Value = model.ModifyUserID;
            sp[26].Value = model.ModifyUserName;
            sp[27].Value = model.PaymentDateType;
            sp[28].Value = model.VExt1;
            sp[29].Value = model.VExt2;
            try
            {
                object o = null;
                if (conn != null)
                {
                    o = helper.GetSingle(conn, tran, sql, sp, true);
                }
                else
                {
                    o = helper.GetSingle(sql, sp);
                }
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.Save",
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


        #region 更新一个Vendor
        /// <summary>
        /// 更新一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(Vendor model, IDbTransaction tran = null, IDbConnection conn = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
                    new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@VendorShortName", SqlDbType.NVarChar, 20),
                    new SqlParameter("@VendorTypeID", SqlDbType.Int),
                    new SqlParameter("@LinkMan", SqlDbType.NVarChar, 20),
                    new SqlParameter("@Telephone", SqlDbType.VarChar, 20),
                    new SqlParameter("@Fax", SqlDbType.VarChar, 20),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@LegalPerson", SqlDbType.VarChar, 20),
                    new SqlParameter("@Email", SqlDbType.VarChar, 200),
                    new SqlParameter("@WebUrl", SqlDbType.VarChar, 200),
                    new SqlParameter("@Region", SqlDbType.VarChar, 20),
                    new SqlParameter("@SettleTimeType", SqlDbType.VarChar, 32),
                    new SqlParameter("@CreditLevel", SqlDbType.NVarChar, 32),
                    new SqlParameter("@AreaPrincipal", SqlDbType.NVarChar, 20),
                    new SqlParameter("@ProvinceID", SqlDbType.Int),
                    new SqlParameter("@CityID", SqlDbType.Int),
                    new SqlParameter("@RegionID", SqlDbType.Int),
                    new SqlParameter("@Address", SqlDbType.VarChar, 100),
                    new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
                    new SqlParameter("@IsDeleted", SqlDbType.Int),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@PaymentDateType", SqlDbType.VarChar, 32),
                    new SqlParameter("@VExt1", SqlDbType.VarChar, 50),
                    new SqlParameter("@VExt2", SqlDbType.VarChar, 50),
                    new SqlParameter("@VendorID", SqlDbType.Int)
                };
            sp[0].Value = model.VendorCode;
            sp[1].Value = model.VendorName;
            sp[2].Value = model.VendorShortName;
            sp[3].Value = model.VendorTypeID;
            sp[4].Value = model.LinkMan;
            sp[5].Value = model.Telephone;
            sp[6].Value = model.Fax;
            sp[7].Value = model.Status;
            sp[8].Value = model.LegalPerson;
            sp[9].Value = model.Email;
            sp[10].Value = model.WebUrl;
            sp[11].Value = model.Region;
            sp[12].Value = model.SettleTimeType;
            sp[13].Value = model.CreditLevel;
            sp[14].Value = model.AreaPrincipal;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.Address;
            sp[19].Value = model.FullAddress;
            sp[20].Value = model.IsDeleted;
            sp[21].Value = model.ModifyTime;
            sp[22].Value = model.ModifyUserID;
            sp[23].Value = model.ModifyUserName;
            sp[24].Value = model.PaymentDateType;
            sp[25].Value = model.VExt1;
            sp[26].Value = model.VExt2;
            sp[27].Value = model.VendorID;
            try
            {
                if (conn != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp, true);
                }
                else
                {
                    result = helper.ExecNonQuery(sql, sp);
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.Edit",
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


        #region 删除一个Vendor
        /// <summary>
        /// 删除一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(Vendor model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@VendorID", SqlDbType.Int)
 };
            sp[0].Value = model.VendorID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.Delete",
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


        #region 根据主键逻辑删除一个Vendor
        /// <summary>
        /// 根据主键逻辑删除一个Vendor
        /// </summary>
        /// <param name="vendorID">供应商分类ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int vendorID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@VendorID", SqlDbType.Int)
 };
            sp[0].Value = vendorID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.LogicDelete",
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


        #region 根据字典获取Vendor对象
        /// <summary>
        /// 根据字典获取Vendor对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Vendor对象</returns>
        public Vendor GetModel(IDictionary<string, object> conditionDict)
        {
            Vendor model = null;
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
                IList<Vendor> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取Vendor对象
        /// <summary>
        /// 根据主键获取Vendor对象
        /// </summary>
        /// <param name="vendorID">供应商分类ID</param>
        /// <returns>Vendor对象</returns>
        public Vendor GetModel(int vendorID)
        {
            DBHelper helper = DBHelper.GetInstance();
            Vendor model = null;
            try
            {

                string sql = @" select v.*,t.VendorTypeName,s.DictLabel as SettleTimeTypeName,k.DictLabel as CreditLevelName 
from Vendor v left join  VendorType t on v.VendorTypeID=t.VendorTypeID
left join (select * from SysDictDetail where DictCode='VendorSettleTimeType') s on v.SettleTimeType=s.DictValue
left join (select * from SysDictDetail where DictCode='ShopLevel') k on v.CreditLevel=k.DictValue where v.VendorID=@VendorID";

                //string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@VendorID", SqlDbType.Int)
 };
                sp[0].Value = vendorID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new Vendor
                        {
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            VendorCode = DataTypeHelper.GetString(sdr["VendorCode"], null),
                            VendorName = DataTypeHelper.GetString(sdr["VendorName"], null),
                            VendorShortName = DataTypeHelper.GetString(sdr["VendorShortName"], null),
                            VendorTypeID = DataTypeHelper.GetInt(sdr["VendorTypeID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Fax = DataTypeHelper.GetString(sdr["Fax"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            LegalPerson = DataTypeHelper.GetString(sdr["LegalPerson"], null),
                            Email = DataTypeHelper.GetString(sdr["Email"], null),
                            WebUrl = DataTypeHelper.GetString(sdr["WebUrl"], null),
                            Region = DataTypeHelper.GetString(sdr["Region"], null),
                            SettleTimeType = DataTypeHelper.GetString(sdr["SettleTimeType"], null),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            AreaPrincipal = DataTypeHelper.GetString(sdr["AreaPrincipal"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),

                            PaymentDateType = DataTypeHelper.GetString(sdr["PaymentDateType"], null),//账期
                            VExt1 = DataTypeHelper.GetString(sdr["VExt1"], null),
                            VExt2 = DataTypeHelper.GetString(sdr["VExt2"], null),
                            VendorTypeName = DataTypeHelper.GetString(sdr["VendorTypeName"], null),//供应商类型名称
                            SettleTimeTypeName = DataTypeHelper.GetString(sdr["SettleTimeTypeName"], null),//结算方式名称
                            StatusName = (DataTypeHelper.GetInt(sdr["Status"]) == 0 ? "冻结" : "正常"),//状态名称
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.GetModel",
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


        #region 根据字典获取Vendor集合
        /// <summary>
        /// 根据字典获取Vendor集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<Vendor> GetList(IDictionary<string, object> conditionDict)
        {
            IList<Vendor> list = null;
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


        #region 根据字典获取Vendor数据集
        /// <summary>
        /// 根据字典获取Vendor数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.GetDataSet",
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


        #region 分页获取Vendor集合
        /// <summary>
        /// 分页获取Vendor集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Vendor> GetPageList(PageListBySql<Vendor> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                if (conditionDict.ContainsKey("WID") && conditionDict["WID"] != null && int.Parse(conditionDict["WID"].ToString()) > 0)
                {
                    //查询指定仓库信息
                    page.TableName = @"(select w.WID, v.*,t.VendorTypeName,s.DictLabel as SettleTimeTypeName,k.DictLabel as CreditLevelName,j.DictLabel as PaymentDateTypeName
from Vendor v left join  VendorType t on v.VendorTypeID=t.VendorTypeID
left join (select * from SysDictDetail where DictCode='VendorSettleTimeType') s on v.SettleTimeType=s.DictValue
left join (select * from SysDictDetail where DictCode='ShopLevel') k on v.CreditLevel=k.DictValue 
left join (select * from SysDictDetail where DictCode='PaymentDateType') j on v.PaymentDateType=j.DictValue 
join VendorWarehouse w on v.VendorID=w.VendorID and w.WID=@WID) tmp";
                }
                else
                {
                    //查询全部不限定仓库的供应商信息
                    page.TableName = @"(select v.*,t.VendorTypeName,s.DictLabel as SettleTimeTypeName,k.DictLabel as CreditLevelName ,j.DictLabel as PaymentDateTypeName
from Vendor v left join  VendorType t on v.VendorTypeID=t.VendorTypeID
left join (select * from SysDictDetail where DictCode='VendorSettleTimeType') s on v.SettleTimeType=s.DictValue
left join (select * from SysDictDetail where DictCode='ShopLevel') k on v.CreditLevel=k.DictValue 
left join (select * from SysDictDetail where DictCode='PaymentDateType') j on v.PaymentDateType=j.DictValue 
) tmp";
                }
                page.Fields = "PaymentDateTypeName,PaymentDateType,VendorTypeName,SettleTimeTypeName,CreditLevelName,VendorID,VendorCode,VendorName,VendorShortName,VendorTypeID,LinkMan,Telephone,Fax,Status,LegalPerson,Email,WebUrl,Region,SettleTimeType,CreditLevel,AreaPrincipal,ProvinceID,CityID,RegionID,Address,FullAddress,IsDeleted,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,VExt1,VExt2";
                page.OrderFields = " CreateTime desc"; //CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
                page.Where = CreateCondition(conditionDict, ref parameters) + " and IsDeleted=0";
                page.Parameters = parameters != null ? (parameters as List<IDbDataParameter>).ToArray() : null;
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
                        page.ItemList.Add(new Vendor
                        {
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            VendorCode = DataTypeHelper.GetString(sdr["VendorCode"], null),
                            VendorName = DataTypeHelper.GetString(sdr["VendorName"], null),
                            VendorShortName = DataTypeHelper.GetString(sdr["VendorShortName"], null),
                            VendorTypeID = DataTypeHelper.GetInt(sdr["VendorTypeID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Fax = DataTypeHelper.GetString(sdr["Fax"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            LegalPerson = DataTypeHelper.GetString(sdr["LegalPerson"], null),
                            Email = DataTypeHelper.GetString(sdr["Email"], null),
                            WebUrl = DataTypeHelper.GetString(sdr["WebUrl"], null),
                            Region = DataTypeHelper.GetString(sdr["Region"], null),
                            SettleTimeType = DataTypeHelper.GetString(sdr["SettleTimeType"], null),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            AreaPrincipal = DataTypeHelper.GetString(sdr["AreaPrincipal"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),

                            PaymentDateType = DataTypeHelper.GetString(sdr["PaymentDateType"], null),//账期
                            PaymentDateTypeName = DataTypeHelper.GetString(sdr["PaymentDateTypeName"], null),//账期

                            VExt1 = DataTypeHelper.GetString(sdr["VExt1"], null),
                            VExt2 = DataTypeHelper.GetString(sdr["VExt2"], null),

                            CreditLevelName = DataTypeHelper.GetString(sdr["CreditLevelName"], null),//供应商类型名称
                            VendorTypeName = DataTypeHelper.GetString(sdr["VendorTypeName"], null),//供应商类型名称
                            SettleTimeTypeName = DataTypeHelper.GetString(sdr["SettleTimeTypeName"], null),//结算方式名称
                            StatusName = (DataTypeHelper.GetInt(sdr["Status"]) == 0 ? "冻结" : "正常"),//状态名称

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.UpdateField",
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

            string itemValue = "";
            foreach (string key in conditionDict.Keys)
            {
                itemValue = conditionDict[key].ToString();
                if (!string.IsNullOrEmpty(itemValue) && itemValue != "")
                {
                    switch (key)
                    {
                        case "WID":
                            parameters.Add(new SqlParameter() { ParameterName = "@WID", SqlDbType = SqlDbType.Int, Value = conditionDict[key] });
                            break;
                        case "VendorCode":
                            where.Append(" AND VendorCode like @VendorCode");
                            parameters.Add(new SqlParameter() { ParameterName = "@VendorCode", SqlDbType = SqlDbType.VarChar, Value = "%" + conditionDict[key].ToString().Trim() + "%" });
                            break;
                        case "VendorID":
                            where.Append(" AND VendorID=@VendorID");
                            parameters.Add(new SqlParameter() { ParameterName = "@VendorID", SqlDbType = SqlDbType.Int, Value = conditionDict[key] });
                            break;
                        case "VendorName":
                            where.Append(" AND VendorName like @VendorName");
                            parameters.Add(new SqlParameter() { ParameterName = "@VendorName", SqlDbType = SqlDbType.NVarChar, Value = "%" + conditionDict[key].ToString().Trim() + "%" });
                            break;
                        case "VendorTypeID":
                            where.Append(" AND VendorTypeID = @VendorTypeID");
                            parameters.Add(new SqlParameter() { ParameterName = "@VendorTypeID", SqlDbType = SqlDbType.Int, Value = conditionDict[key] });
                            break;
                        case "LinkMan":
                            where.Append(" AND LinkMan like @LinkMan");
                            parameters.Add(new SqlParameter() { ParameterName = "@LinkMan", SqlDbType = SqlDbType.NVarChar, Value = "%" + conditionDict[key].ToString().Trim() + "%" });
                            break;
                        case "ProvinceID":
                            where.Append(" AND ProvinceID = @ProvinceID");
                            parameters.Add(new SqlParameter() { ParameterName = "@ProvinceID", SqlDbType = SqlDbType.Int, Value = conditionDict[key] });
                            break;
                        case "CityID":
                            where.Append(" AND RegionID = @CityID");
                            parameters.Add(new SqlParameter() { ParameterName = "@CityID", SqlDbType = SqlDbType.Int, Value = conditionDict[key] });
                            break;
                        case "RegionID":
                            where.Append(" AND RegionID = @RegionID");
                            parameters.Add(new SqlParameter() { ParameterName = "@RegionID", SqlDbType = SqlDbType.Int, Value = conditionDict[key] });
                            break;
                        case "SettleTimeType":
                            where.Append(" AND SettleTimeType = @SettleTimeType");
                            parameters.Add(new SqlParameter() { ParameterName = "@SettleTimeType", SqlDbType = SqlDbType.VarChar, Value = conditionDict[key] });
                            break;
                        case "Status":
                            where.Append(" AND Status = @Status");
                            parameters.Add(new SqlParameter() { ParameterName = "@Status", SqlDbType = SqlDbType.Int, Value = conditionDict[key] });
                            break;
                        case "PaymentDateType":
                            where.Append(" AND PaymentDateType = @PaymentDateType");
                            parameters.Add(new SqlParameter() { ParameterName = "@PaymentDateType", SqlDbType = SqlDbType.VarChar, Value = conditionDict[key] });
                            break;
                    }
                }
            }
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
                return "VendorID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取Vendor列表
        /// <summary>
        /// 根据条件获取Vendor列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<Vendor> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<Vendor> list = new List<Vendor>();
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
                        list.Add(new Vendor
                        {
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            VendorCode = DataTypeHelper.GetString(sdr["VendorCode"], null),
                            VendorName = DataTypeHelper.GetString(sdr["VendorName"], null),
                            VendorShortName = DataTypeHelper.GetString(sdr["VendorShortName"], null),
                            VendorTypeID = DataTypeHelper.GetInt(sdr["VendorTypeID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Fax = DataTypeHelper.GetString(sdr["Fax"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            LegalPerson = DataTypeHelper.GetString(sdr["LegalPerson"], null),
                            Email = DataTypeHelper.GetString(sdr["Email"], null),
                            WebUrl = DataTypeHelper.GetString(sdr["WebUrl"], null),
                            Region = DataTypeHelper.GetString(sdr["Region"], null),
                            SettleTimeType = DataTypeHelper.GetString(sdr["SettleTimeType"], null),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            AreaPrincipal = DataTypeHelper.GetString(sdr["AreaPrincipal"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            VExt1 = DataTypeHelper.GetString(sdr["VExt1"], null),
                            VExt2 = DataTypeHelper.GetString(sdr["VExt2"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.Vendor.GetList",
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
    /// ### 供应商表Vendor数据库访问类
    /// </summary>
    public partial class VendorDAO : BaseDAL, IVendorDAO
    {
        /// <summary>
        /// 更新供应商状态
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="status"></param>
        /// <param name="dateTime"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int UpdateStatus(string shelfId, int status, DateTime dateTime, int userID, string userName, IDbTransaction tran, IDbConnection conn)
        {
            int rowCount = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Vendor set ");
            strSql.Append("Status=@Status,");
            strSql.Append("ModifyTime=@ModifyTime,");
            strSql.Append("ModifyUserID=@ModifyUserID,");
            strSql.Append("ModifyUserName=@ModifyUserName");
            strSql.Append(" where VendorID=@VendorID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int,4),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar,32),
                    new SqlParameter("@VendorID", SqlDbType.Int,4)};
            parameters[0].Value = status;
            parameters[1].Value = dateTime;
            parameters[2].Value = userID;
            parameters[3].Value = userName;
            parameters[4].Value = shelfId;
            rowCount = DBHelper.GetInstance().ExecNonQuery(conn, tran, strSql.ToString(), parameters, true);
            return rowCount;
        }

        /// <summary>
        /// 获取供应商引用的仓库列表
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public IList<WarehouseSelectModel> GetVendorWarehouse(int vendorID)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WarehouseSelectModel> ilist = new List<WarehouseSelectModel>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  distinct VendorID,a.WID,b.WCode,b.WName from VendorWarehouse a,Warehouse b where a.WID=b.WID and b.IsDeleted=0 and VendorID=@VendorID");
            SqlParameter[] parameters = {
                    new SqlParameter("@VendorID", SqlDbType.Int,4)};
            parameters[0].Value = vendorID;
            using (SqlDataReader sdr = helper.GetIDataReader(strSql.ToString(), parameters) as SqlDataReader)
            {
                while (sdr.Read())
                {
                    ilist.Add(new WarehouseSelectModel
                    {
                        VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                        WID = DataTypeHelper.GetInt(sdr["WID"]),
                        WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                        WName = DataTypeHelper.GetString(sdr["WName"], null)
                    });
                }
            }
            return ilist;
        }

        /// <summary>
        /// 获取供应商没有引用的仓库列表
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public IList<WarehouseSelectModel> GetNoneVendorWarehouse(int vendorID)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WarehouseSelectModel> ilist = new List<WarehouseSelectModel>();
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            if (vendorID > 0)
            {
                strSql.Append("select WID,WCode,WName from Warehouse s where ParentWID=0 and IsDeleted=0 and NOT EXISTS(select ID,VendorID,a.WID,b.WCode,b.WName from VendorWarehouse a,Warehouse b where a.WID=b.WID and VendorID=@VendorID and s.WID=a.WID)");
                parameters = new SqlParameter[]{
                    new SqlParameter("@VendorID", SqlDbType.Int,4)};
                parameters[0].Value = vendorID;
            }
            else
            {
                strSql.Append("select WID,WCode,WName from Warehouse s where ParentWID=0  and IsDeleted=0");
            }
            using (SqlDataReader sdr = helper.GetIDataReader(strSql.ToString(), parameters) as SqlDataReader)
            {
                while (sdr.Read())
                {
                    ilist.Add(new WarehouseSelectModel
                    {
                        WID = DataTypeHelper.GetInt(sdr["WID"]),
                        WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                        WName = DataTypeHelper.GetString(sdr["WName"], null)
                    });
                }
            }
            return ilist;
        }

        /// <summary>
        /// 清空指定供应商与仓库关联关系
        /// </summary>
        /// <param name="vendorID"></param>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int ClearVendorWarehouse(int vendorID, IDbTransaction tran, IDbConnection conn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VendorWarehouse where VendorID=@VendorID)");
            SqlParameter[] parameters = {
                    new SqlParameter("@VendorID", SqlDbType.Int,4)};
            parameters[0].Value = vendorID;
            int rowCount = DBHelper.GetInstance().ExecNonQuery(conn, tran, strSql.ToString(), parameters, true);
            return rowCount;
        }

        /// <summary>
        /// 获取供应商没有引用的仓库列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tran"> </param>
        /// <param name="conn"> </param>
        /// <returns></returns>
        public int AddVendorWarehouse(WarehouseSelectModel model, IDbTransaction tran, IDbConnection conn)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WarehouseSelectModel> ilist = new List<WarehouseSelectModel>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into  VendorWarehouse(VendorID,WID,CreateTime) values(@VendorID,@WID,@CreateTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@VendorID", SqlDbType.Int,4),
                    new SqlParameter("@WID", SqlDbType.Int,4),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                                        };
            parameters[0].Value = model.VendorID;
            parameters[1].Value = model.WID;
            parameters[2].Value = DateTime.Now;
            int rowCount = DBHelper.GetInstance().ExecNonQuery(conn, tran, strSql.ToString(), parameters, true);
            return rowCount;
        }

        /// <summary>
        /// 删除现有供应商关联仓库信息
        /// </summary>
        /// <param name="vendorID"></param>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int DeleteVendorWHouseList(int vendorID, IDbTransaction tran, IDbConnection conn)
        {
            int cnt = 0;

            if (vendorID <= 0)
                return cnt;
            DBHelper helper = DBHelper.GetInstance();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from VendorWarehouse where VendorID=@VendorID");
            SqlParameter[] sp = { new SqlParameter("@VendorID", SqlDbType.Int) };
            sp[0].Value = vendorID;

            //删除原有绑定关系
            cnt = helper.ExecNonQuery(conn, tran, sb.ToString(), sp, true);
            return cnt;
        }


        /// <summary>
        /// 保存供应商所属仓库信息
        /// </summary>
        /// <param name="vendorID"> </param>
        /// <param name="userID"> </param>
        /// <param name="userName"> </param>
        /// <param name="widList"> </param>
        /// <param name="tran"> </param>
        /// <param name="conn"> </param>
        /// <returns></returns>
        public int SaveVendorWHouse(int vendorID, int userID, string userName, List<int> widList, IDbTransaction tran, IDbConnection conn)
        {
            if (widList == null || widList.Count == 0)
            {
                return 0;
            }
            int cnt = 0;

            DBHelper helper = DBHelper.GetInstance();
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO VendorWarehouse(VendorID,WID,CreateTime,CreateUserID,CreateUserName)values(@VendorID,@WID,@CreateTime,@CreateUserID,@CreateUserName)");
            SqlParameter[] sp = null;
            foreach (int wid in widList)
            {
                sp = new SqlParameter[]{ new SqlParameter("@VendorID", SqlDbType.Int),
                new SqlParameter("@WID", SqlDbType.Int),
                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                new SqlParameter("@CreateUserID", SqlDbType.Int),
                new SqlParameter("@CreateUserName", SqlDbType.VarChar,32)};
                sp[0].Value = vendorID;
                sp[1].Value = wid;
                sp[2].Value = DateTime.Now;
                sp[3].Value = userID;
                sp[4].Value = userName;
                cnt += helper.ExecNonQuery(conn, tran, sb.ToString(), sp, true);
            };
            return cnt;
        }

        /// <summary>
        /// 获取某个仓库下的商品最后一次进货的供应商信息集合
        /// </summary>
        /// <param name="wid">仓库ID</param>
        /// <param name="productIds">要指定查询的商品ID集合，允许为空</param>
        /// <returns>商品最后一次进货的供应商信息集合</returns>
        public IList<VendorLastBuy> GetLastBuyVendors(int wid, IList<int> productIds = null)
        {

            DBHelper helper = DBHelper.GetInstance();
            IList<VendorLastBuy> list = new List<VendorLastBuy>();
            try
            {
                //string sql = @"select WID, ProductId,PV.VendorID,v.VendorCode,v.VendorName,LastBuyTime,IsMaster from ProductsVendor as PV LEFT JOIN Vendor AS V ON PV.VendorID = V.VendorID where PV.ID = (select top 1 ID from ProductsVendor as b where PV.WID = b.WID and PV.ProductId = b.ProductId order by b.LastBuyTime desc) AND PV.WID =@WID"; //2016-6-30 叶求提供的查询方法

                SqlParamrterBuilder sp = new SqlParamrterBuilder();
                sp.Add("WID", SqlDbType.Int, wid);

                string where = string.Empty;
                #region 如果传入的集合有数据，则增加 ProductId in 的查询参数
                StringBuilder sb = new StringBuilder();
                if (productIds != null && productIds.Count > 0)
                {

                    int i = 1;
                    foreach (var id in productIds)
                    {
                        sb.Append(string.Format(" @ProductId{0} ,", i));
                        sp.Add(string.Format("ProductId{0}", i), id);
                        i++;
                    }
                    where = " And ProductId in (" + sb.ToString(0, sb.Length - 1) + " ) ";

                }
                #endregion

                string sql = @"SELECT N.* FROM (
	                            SELECT   a.WID,ProductId,a.VendorID,v.VendorCode,v.VendorName,LastBuyTime,IsMaster, 
	                            row_number() over(partition by ProductId  order by a.LastBuyTime desc) cnt
	                            FROM ProductsVendor a
	                            LEFT JOIN Vendor AS V ON a.VendorID = V.VendorID 
	                            WHERE a.WID = @WID " + where +
                              @"  ) N 
                             WHERE N.cnt=1";  //2016-7-1 叶求优化的查询方法

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp.ToSqlParameters()) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<VendorLastBuy>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Vendor.GetLastBuyVendors",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }


        #region 获取数据库连接
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>连接对象</returns>
        public IDbConnection GetConnection()
        {
            DBHelper helper = DBHelper.GetInstance();
            return helper.GetNewConnection();
        }
        #endregion
    }
}
