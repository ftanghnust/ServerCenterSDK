
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
    /// ### 门店资料表Shop数据库访问类
    /// </summary>
    public partial class ShopDAO : BaseDAL, IShopDAO
    {
        const string tableName = "Shop";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证Shop是否存在
        /// <summary>
        /// 根据主键验证Shop是否存在
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(Shop model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@ShopID", SqlDbType.Int)
            };
            sp[0].Value = model.ShopID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.Exists",
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

        #region 添加一个Shop
        /// <summary>
        /// 添加一个Shop
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(Shop model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
            new SqlParameter("@ShopType", SqlDbType.Int),
            new SqlParameter("@ShopName", SqlDbType.NVarChar, 50),
            new SqlParameter("@ShopAccount", SqlDbType.VarChar, 32),
            new SqlParameter("@SettleType", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@LinkMan", SqlDbType.NVarChar, 20),
            new SqlParameter("@Telephone", SqlDbType.VarChar, 20),
            new SqlParameter("@Status", SqlDbType.Int),
            new SqlParameter("@LegalPerson", SqlDbType.VarChar, 20),
            new SqlParameter("@SettleTimeType", SqlDbType.VarChar, 32),
            new SqlParameter("@CreditLevel", SqlDbType.NVarChar, 32),
            new SqlParameter("@CreditAmt", SqlDbType.Money),
            new SqlParameter("@AreaPrincipal", SqlDbType.NVarChar, 20),
            new SqlParameter("@ProvinceID", SqlDbType.Int),
            new SqlParameter("@CityID", SqlDbType.Int),
            new SqlParameter("@RegionID", SqlDbType.Int),
            new SqlParameter("@Address", SqlDbType.VarChar, 100),
            new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
            new SqlParameter("@ShopArea", SqlDbType.Decimal, 4),
            new SqlParameter("@IsDeleted", SqlDbType.Int),
            new SqlParameter("@Latitude", SqlDbType.VarChar, 20),
            new SqlParameter("@Longitude", SqlDbType.VarChar, 20),
            new SqlParameter("@TotalPoint", SqlDbType.Money),
            new SqlParameter("@BankAccount", SqlDbType.NVarChar, 50),
            new SqlParameter("@BankAccountName", SqlDbType.NVarChar, 100),
            new SqlParameter("@BankType", SqlDbType.VarChar, 32),
            new SqlParameter("@CardID", SqlDbType.VarChar, 32),
            new SqlParameter("@RegionMaster", SqlDbType.NVarChar, 50),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)

            };
            sp[0].Value = model.ShopCode;
            sp[1].Value = model.ShopType;
            sp[2].Value = model.ShopName;
            sp[3].Value = model.ShopAccount;
            sp[4].Value = model.SettleType;
            sp[5].Value = model.WID;
            sp[6].Value = model.LinkMan;
            sp[7].Value = model.Telephone;
            sp[8].Value = model.Status;
            sp[9].Value = model.LegalPerson;
            sp[10].Value = model.SettleTimeType;
            sp[11].Value = model.CreditLevel;
            sp[12].Value = model.CreditAmt;
            sp[13].Value = model.AreaPrincipal;
            sp[14].Value = model.ProvinceID;
            sp[15].Value = model.CityID;
            sp[16].Value = model.RegionID;
            sp[17].Value = model.Address;
            sp[18].Value = model.FullAddress;
            sp[19].Value = model.ShopArea;
            sp[20].Value = model.IsDeleted;
            sp[21].Value = model.Latitude;
            sp[22].Value = model.Longitude;
            sp[23].Value = model.TotalPoint;
            sp[24].Value = model.BankAccount;
            sp[25].Value = model.BankAccountName;
            sp[26].Value = model.BankType;
            sp[27].Value = model.CardID;
            sp[28].Value = model.RegionMaster;
            sp[29].Value = model.CreateTime;
            sp[30].Value = model.CreateUserID;
            sp[31].Value = model.CreateUserName;
            sp[32].Value = model.ModifyTime;
            sp[33].Value = model.ModifyUserID;
            sp[34].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.Save",
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

        #region 更新一个Shop
        /// <summary>
        /// 更新一个Shop (不会修改Status和 IsDeleted)
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(Shop model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
            new SqlParameter("@ShopType", SqlDbType.Int),
            new SqlParameter("@ShopName", SqlDbType.NVarChar, 50),
            new SqlParameter("@ShopAccount", SqlDbType.VarChar, 32),
            new SqlParameter("@SettleType", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@LinkMan", SqlDbType.NVarChar, 20),
            new SqlParameter("@Telephone", SqlDbType.VarChar, 20),            
            new SqlParameter("@LegalPerson", SqlDbType.VarChar, 20),
            new SqlParameter("@SettleTimeType", SqlDbType.VarChar, 32),
            new SqlParameter("@CreditLevel", SqlDbType.NVarChar, 32),
            new SqlParameter("@CreditAmt", SqlDbType.Money),
            new SqlParameter("@AreaPrincipal", SqlDbType.NVarChar, 20),
            new SqlParameter("@ProvinceID", SqlDbType.Int),
            new SqlParameter("@CityID", SqlDbType.Int),
            new SqlParameter("@RegionID", SqlDbType.Int),
            new SqlParameter("@Address", SqlDbType.VarChar, 100),
            new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
            new SqlParameter("@ShopArea", SqlDbType.Decimal, 4),            
            new SqlParameter("@Latitude", SqlDbType.VarChar, 20),
            new SqlParameter("@Longitude", SqlDbType.VarChar, 20),
            new SqlParameter("@TotalPoint", SqlDbType.Money),
            new SqlParameter("@BankAccount", SqlDbType.NVarChar, 50),
            new SqlParameter("@BankAccountName", SqlDbType.NVarChar, 100),
            new SqlParameter("@BankType", SqlDbType.VarChar, 32),
            new SqlParameter("@CardID", SqlDbType.VarChar, 32),
            new SqlParameter("@RegionMaster", SqlDbType.NVarChar, 50),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
            new SqlParameter("@ShopID", SqlDbType.Int)

            };
            sp[0].Value = model.ShopCode;
            sp[1].Value = model.ShopType;
            sp[2].Value = model.ShopName;
            sp[3].Value = model.ShopAccount;
            sp[4].Value = model.SettleType;
            sp[5].Value = model.WID;
            sp[6].Value = model.LinkMan;
            sp[7].Value = model.Telephone;
            sp[8].Value = model.LegalPerson;
            sp[9].Value = model.SettleTimeType;
            sp[10].Value = model.CreditLevel;
            sp[11].Value = model.CreditAmt;
            sp[12].Value = model.AreaPrincipal;
            sp[13].Value = model.ProvinceID;
            sp[14].Value = model.CityID;
            sp[15].Value = model.RegionID;
            sp[16].Value = model.Address;
            sp[17].Value = model.FullAddress;
            sp[18].Value = model.ShopArea;
            sp[19].Value = model.Latitude;
            sp[20].Value = model.Longitude;
            sp[21].Value = model.TotalPoint;
            sp[22].Value = model.BankAccount;
            sp[23].Value = model.BankAccountName;
            sp[24].Value = model.BankType;
            sp[25].Value = model.CardID;
            sp[26].Value = model.RegionMaster;
            sp[27].Value = model.ModifyTime;
            sp[28].Value = model.ModifyUserID;
            sp[29].Value = model.ModifyUserName;
            sp[30].Value = model.ShopID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.Edit",
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

        #region 删除一个Shop
        /// <summary>
        /// 删除一个Shop
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(Shop model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@ShopID", SqlDbType.Int)
            };
            sp[0].Value = model.ShopID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.Delete",
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

        #region 根据字典获取Shop对象
        /// <summary>
        /// 根据字典获取Shop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Shop对象</returns>
        public Shop GetModel(IDictionary<string, object> conditionDict)
        {
            Shop model = null;
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
                IList<Shop> list = GetList(where.ToString(), sp);
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

        #region 根据主键获取Shop对象
        /// <summary>
        /// 根据主键获取Shop对象
        /// </summary>
        /// <param name="shopID">门店ID</param>
        /// <returns>Shop对象</returns>
        public Shop GetModel(int shopID)
        {
            DBHelper helper = DBHelper.GetInstance();
            Shop model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
            new SqlParameter("@ShopID", SqlDbType.Int)
            };
                sp[0].Value = shopID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new Shop
                        {
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopType = DataTypeHelper.GetInt(sdr["ShopType"]),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            ShopAccount = DataTypeHelper.GetString(sdr["ShopAccount"], null),
                            SettleType = DataTypeHelper.GetString(sdr["SettleType"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            LegalPerson = DataTypeHelper.GetString(sdr["LegalPerson"], null),
                            SettleTimeType = DataTypeHelper.GetString(sdr["SettleTimeType"], null),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            CreditAmt = DataTypeHelper.GetDouble(sdr["CreditAmt"]),
                            AreaPrincipal = DataTypeHelper.GetString(sdr["AreaPrincipal"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            ShopArea = DataTypeHelper.GetDecimal(sdr["ShopArea"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Latitude = DataTypeHelper.GetString(sdr["Latitude"], null),
                            Longitude = DataTypeHelper.GetString(sdr["Longitude"], null),
                            TotalPoint = DataTypeHelper.GetDouble(sdr["TotalPoint"]),
                            BankAccount = DataTypeHelper.GetString(sdr["BankAccount"], null),
                            BankAccountName = DataTypeHelper.GetString(sdr["BankAccountName"], null),
                            BankType = DataTypeHelper.GetString(sdr["BankType"], null),
                            CardID = DataTypeHelper.GetString(sdr["CardID"], null),
                            RegionMaster = DataTypeHelper.GetString(sdr["RegionMaster"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            //增加的属性
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            LineID = DataTypeHelper.GetInt(sdr["LineID"], 0),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"], 0),
                            SerialNumberStr = DataTypeHelper.GetString(sdr["SerialNumber"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.GetModel",
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

        #region 根据字典获取Shop集合
        /// <summary>
        /// 根据字典获取Shop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<Shop> GetList(IDictionary<string, object> conditionDict)
        {
            IList<Shop> list = null;
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

        #region 根据字典获取Shop数据集
        /// <summary>
        /// 根据字典获取Shop数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.GetDataSet",
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

        #region 分页获取Shop集合
        /// <summary>
        /// 分页获取Shop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Shop> GetPageList(PageListBySql<Shop> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetShopPageList", base.AssemblyName, base.DatabaseName);//从配置文件读取SQL脚本信息;//TODO 测试发现，如果不用 S.*SQL中有字段名脚本会被强行转义，造成运行时报错
                page.Fields = "LineID,LineName,SerialNumber,ShopID,ShopCode,ShopType,ShopName,ShopAccount,SettleType,WID,LinkMan,Telephone,Status,LegalPerson,SettleTimeType,CreditLevel,CreditAmt,AreaPrincipal,ProvinceID,CityID,RegionID,Address,FullAddress,ShopArea,IsDeleted,Latitude,Longitude,TotalPoint,BankAccount,BankAccountName,BankType,CardID,RegionMaster,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new Shop
                        {
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopType = DataTypeHelper.GetInt(sdr["ShopType"]),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            ShopAccount = DataTypeHelper.GetString(sdr["ShopAccount"], null),
                            SettleType = DataTypeHelper.GetString(sdr["SettleType"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            LegalPerson = DataTypeHelper.GetString(sdr["LegalPerson"], null),
                            SettleTimeType = DataTypeHelper.GetString(sdr["SettleTimeType"], null),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            CreditAmt = DataTypeHelper.GetDouble(sdr["CreditAmt"]),
                            AreaPrincipal = DataTypeHelper.GetString(sdr["AreaPrincipal"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            ShopArea = DataTypeHelper.GetDecimal(sdr["ShopArea"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Latitude = DataTypeHelper.GetString(sdr["Latitude"], null),
                            Longitude = DataTypeHelper.GetString(sdr["Longitude"], null),
                            TotalPoint = DataTypeHelper.GetDouble(sdr["TotalPoint"]),
                            BankAccount = DataTypeHelper.GetString(sdr["BankAccount"], null),
                            BankAccountName = DataTypeHelper.GetString(sdr["BankAccountName"], null),
                            BankType = DataTypeHelper.GetString(sdr["BankType"], null),
                            CardID = DataTypeHelper.GetString(sdr["CardID"], null),
                            RegionMaster = DataTypeHelper.GetString(sdr["RegionMaster"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            //增加的属性
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            LineID = DataTypeHelper.GetInt(sdr["LineID"], 0),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"], 0),
                            SerialNumberStr = DataTypeHelper.GetString(sdr["SerialNumber"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.UpdateField",
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

            if (conditionDict.ContainsKey("ShopCode"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ShopCode",
                        FieldValue = conditionDict["ShopCode"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 32
                    }
                });
            }

            if (conditionDict.ContainsKey("ShopName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ShopName",
                        FieldValue = conditionDict["ShopName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("ShopAccount"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ShopAccount",
                        FieldValue = conditionDict["ShopAccount"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 32
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
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("LinkMan"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "LinkMan",
                        FieldValue = conditionDict["LinkMan"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 20
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
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("SettleTimeType"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "SettleTimeType",
                        FieldValue = conditionDict["SettleTimeType"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 32
                    }
                });
            }

            if (conditionDict.ContainsKey("LineID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "LineID",
                        FieldValue = conditionDict["LineID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("ShopIDList"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.In,
                    FieldObj = new Field
                    {
                        FieldName = "ShopID",
                        FieldValue = conditionDict["ShopIDList"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 8000
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
        /// 构建Sort条件 默认ModifyTime
        /// </summary>
        /// <param name="page">分页辅助类</param>
        string CreateOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return "ModifyTime";
            }
            else
            {
                return order;
            }
        }
        #endregion

        #region 根据条件获取Shop列表
        /// <summary>
        /// 根据条件获取Shop列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<Shop> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<Shop> list = new List<Shop>();
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
                        list.Add(new Shop
                        {
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopType = DataTypeHelper.GetInt(sdr["ShopType"]),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            ShopAccount = DataTypeHelper.GetString(sdr["ShopAccount"], null),
                            SettleType = DataTypeHelper.GetString(sdr["SettleType"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            LegalPerson = DataTypeHelper.GetString(sdr["LegalPerson"], null),
                            SettleTimeType = DataTypeHelper.GetString(sdr["SettleTimeType"], null),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            CreditAmt = DataTypeHelper.GetDouble(sdr["CreditAmt"]),
                            AreaPrincipal = DataTypeHelper.GetString(sdr["AreaPrincipal"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            ShopArea = DataTypeHelper.GetDecimal(sdr["ShopArea"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Latitude = DataTypeHelper.GetString(sdr["Latitude"], null),
                            Longitude = DataTypeHelper.GetString(sdr["Longitude"], null),
                            TotalPoint = DataTypeHelper.GetDouble(sdr["TotalPoint"]),
                            BankAccount = DataTypeHelper.GetString(sdr["BankAccount"], null),
                            BankAccountName = DataTypeHelper.GetString(sdr["BankAccountName"], null),
                            BankType = DataTypeHelper.GetString(sdr["BankType"], null),
                            CardID = DataTypeHelper.GetString(sdr["CardID"], null),
                            RegionMaster = DataTypeHelper.GetString(sdr["RegionMaster"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            //增加的属性
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            LineID = DataTypeHelper.GetInt(sdr["LineID"], 0),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"], 0),
                            SerialNumberStr = DataTypeHelper.GetString(sdr["SerialNumber"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.GetList",
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

    public partial class ShopDAO : BaseDAL, IShopDAO
    {
        #region 根据门店编号验证Shop是否存在
        /// <summary>
        /// 根据门店ID验证Shop是否存在
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsShopCode(Shop model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsShopCode", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
            new SqlParameter("@ShopID", SqlDbType.Int)
            };
            sp[0].Value = model.ShopCode;
            sp[1].Value = model.ShopID;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.ExistsShopCode",
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

        #region 根据门店名称验证Shop是否存在
        /// <summary>
        /// 根据门店名称验证Shop是否存在
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsShopName(Shop model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsShopName", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@ShopName", SqlDbType.VarChar, 50),
            new SqlParameter("@ShopID", SqlDbType.Int)
            };
            sp[0].Value = model.ShopName;
            sp[1].Value = model.ShopID;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.ExistsShopName",
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

        #region 根据对象逻辑删除一个Shop
        /// <summary>
        /// 根据对象逻辑删除一个Shop
        /// </summary>
        /// <param name="shopID">门店ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(Shop model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
            new SqlParameter("@ShopID", SqlDbType.Int)
            };

            sp[0].Value = model.ModifyUserID;
            sp[1].Value = model.ModifyUserName;
            sp[2].Value = model.ShopID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.LogicDelete",
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

        #region 根据对象逻冻结或解冻一个Shop
        /// <summary>
        /// 根据对象逻冻结或解冻一个Shop
        /// </summary>
        /// <param name="shopID">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        public int ShopFreeze(Shop model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ShopFreeze", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@Status", SqlDbType.Int),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64),
            new SqlParameter("@ShopID", SqlDbType.Int)
            };

            sp[0].Value = model.Status;
            sp[1].Value = model.ModifyUserID;
            sp[2].Value = model.ModifyUserName;
            sp[3].Value = model.ShopID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.ShopFreeze",
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

        #region 仓库后台分页获取Shop集合
        /// <summary>
        /// 分页获取Shop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Shop> GetWhPageList(PageListBySql<Shop> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetWhShopPageList", base.AssemblyName, base.DatabaseName); //从配置文件读取SQL脚本信息;;
                page.Fields = "ShopID,ShopCode,ShopType,ShopName,ShopAccount,SettleType,WID,LinkMan,Telephone,Status,LegalPerson,SettleTimeType,CreditLevel,CreditAmt,AreaPrincipal,ProvinceID,CityID,RegionID,Address,FullAddress,ShopArea,IsDeleted,Latitude,Longitude,TotalPoint,BankAccount,BankAccountName,BankType,CardID,RegionMaster,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,LineName,LineID,SerialNumber";
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
                        page.ItemList.Add(new Shop
                        {
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopType = DataTypeHelper.GetInt(sdr["ShopType"]),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            ShopAccount = DataTypeHelper.GetString(sdr["ShopAccount"], null),
                            SettleType = DataTypeHelper.GetString(sdr["SettleType"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            LegalPerson = DataTypeHelper.GetString(sdr["LegalPerson"], null),
                            SettleTimeType = DataTypeHelper.GetString(sdr["SettleTimeType"], null),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            CreditAmt = DataTypeHelper.GetDouble(sdr["CreditAmt"]),
                            AreaPrincipal = DataTypeHelper.GetString(sdr["AreaPrincipal"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            ShopArea = DataTypeHelper.GetDecimal(sdr["ShopArea"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Latitude = DataTypeHelper.GetString(sdr["Latitude"], null),
                            Longitude = DataTypeHelper.GetString(sdr["Longitude"], null),
                            TotalPoint = DataTypeHelper.GetDouble(sdr["TotalPoint"]),
                            BankAccount = DataTypeHelper.GetString(sdr["BankAccount"], null),
                            BankAccountName = DataTypeHelper.GetString(sdr["BankAccountName"], null),
                            BankType = DataTypeHelper.GetString(sdr["BankType"], null),
                            CardID = DataTypeHelper.GetString(sdr["CardID"], null),
                            RegionMaster = DataTypeHelper.GetString(sdr["RegionMaster"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            LineID = DataTypeHelper.GetInt(sdr["LineID"], 0),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            SerialNumberStr = DataTypeHelper.GetString(sdr["SerialNumber"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.GetWhPageList",
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

        #region 仓库后台 根据主键获取Shop对象
        /// <summary>
        /// 仓库后台 根据主键获取Shop对象
        /// </summary>
        /// <param name="shopID">门店ID</param>
        /// <returns>Shop对象</returns>
        public Shop GetModelInWh(int shopID)
        {
            DBHelper helper = DBHelper.GetInstance();
            Shop model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByIdInWh", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                new SqlParameter("@ShopID", SqlDbType.Int)
                };
                sp[0].Value = shopID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new Shop
                        {
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopType = DataTypeHelper.GetInt(sdr["ShopType"]),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            ShopAccount = DataTypeHelper.GetString(sdr["ShopAccount"], null),
                            SettleType = DataTypeHelper.GetString(sdr["SettleType"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            LegalPerson = DataTypeHelper.GetString(sdr["LegalPerson"], null),
                            SettleTimeType = DataTypeHelper.GetString(sdr["SettleTimeType"], null),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            CreditAmt = DataTypeHelper.GetDouble(sdr["CreditAmt"]),
                            AreaPrincipal = DataTypeHelper.GetString(sdr["AreaPrincipal"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            ShopArea = DataTypeHelper.GetDecimal(sdr["ShopArea"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Latitude = DataTypeHelper.GetString(sdr["Latitude"], null),
                            Longitude = DataTypeHelper.GetString(sdr["Longitude"], null),
                            TotalPoint = DataTypeHelper.GetDouble(sdr["TotalPoint"]),
                            BankAccount = DataTypeHelper.GetString(sdr["BankAccount"], null),
                            BankAccountName = DataTypeHelper.GetString(sdr["BankAccountName"], null),
                            BankType = DataTypeHelper.GetString(sdr["BankType"], null),
                            CardID = DataTypeHelper.GetString(sdr["CardID"], null),
                            RegionMaster = DataTypeHelper.GetString(sdr["RegionMaster"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            LineID = DataTypeHelper.GetInt(sdr["LineID"], 0),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"])
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.GetModelByIdInWh",
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

        #region 添加一个Shop 事务处理
        /// <summary>
        /// 添加一个Shop 事务处理
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(Shop model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
            new SqlParameter("@ShopType", SqlDbType.Int),
            new SqlParameter("@ShopName", SqlDbType.NVarChar, 50),
            new SqlParameter("@ShopAccount", SqlDbType.VarChar, 32),
            new SqlParameter("@SettleType", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@LinkMan", SqlDbType.NVarChar, 20),
            new SqlParameter("@Telephone", SqlDbType.VarChar, 20),
            new SqlParameter("@Status", SqlDbType.Int),
            new SqlParameter("@LegalPerson", SqlDbType.VarChar, 20),
            new SqlParameter("@SettleTimeType", SqlDbType.VarChar, 32),
            new SqlParameter("@CreditLevel", SqlDbType.NVarChar, 32),
            new SqlParameter("@CreditAmt", SqlDbType.Money),
            new SqlParameter("@AreaPrincipal", SqlDbType.NVarChar, 20),
            new SqlParameter("@ProvinceID", SqlDbType.Int),
            new SqlParameter("@CityID", SqlDbType.Int),
            new SqlParameter("@RegionID", SqlDbType.Int),
            new SqlParameter("@Address", SqlDbType.VarChar, 100),
            new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
            new SqlParameter("@ShopArea", SqlDbType.Decimal, 4),
            new SqlParameter("@IsDeleted", SqlDbType.Int),
            new SqlParameter("@Latitude", SqlDbType.VarChar, 20),
            new SqlParameter("@Longitude", SqlDbType.VarChar, 20),
            new SqlParameter("@TotalPoint", SqlDbType.Money),
            new SqlParameter("@BankAccount", SqlDbType.NVarChar, 50),
            new SqlParameter("@BankAccountName", SqlDbType.NVarChar, 100),
            new SqlParameter("@BankType", SqlDbType.VarChar, 32),
            new SqlParameter("@CardID", SqlDbType.VarChar, 32),
            new SqlParameter("@RegionMaster", SqlDbType.NVarChar, 50),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 64)

            };
            sp[0].Value = model.ShopCode;
            sp[1].Value = model.ShopType;
            sp[2].Value = model.ShopName;
            sp[3].Value = model.ShopAccount;
            sp[4].Value = model.SettleType;
            sp[5].Value = model.WID;
            sp[6].Value = model.LinkMan;
            sp[7].Value = model.Telephone;
            sp[8].Value = model.Status;
            sp[9].Value = model.LegalPerson;
            sp[10].Value = model.SettleTimeType;
            sp[11].Value = model.CreditLevel;
            sp[12].Value = model.CreditAmt;
            sp[13].Value = model.AreaPrincipal;
            sp[14].Value = model.ProvinceID;
            sp[15].Value = model.CityID;
            sp[16].Value = model.RegionID;
            sp[17].Value = model.Address;
            sp[18].Value = model.FullAddress;
            sp[19].Value = model.ShopArea;
            sp[20].Value = model.IsDeleted;
            sp[21].Value = model.Latitude;
            sp[22].Value = model.Longitude;
            sp[23].Value = model.TotalPoint;
            sp[24].Value = model.BankAccount;
            sp[25].Value = model.BankAccountName;
            sp[26].Value = model.BankType;
            sp[27].Value = model.CardID;
            sp[28].Value = model.RegionMaster;
            sp[29].Value = model.CreateTime;
            sp[30].Value = model.CreateUserID;
            sp[31].Value = model.CreateUserName;
            sp[32].Value = model.ModifyTime;
            sp[33].Value = model.ModifyUserID;
            sp[34].Value = model.ModifyUserName;

            try
            {
                object o = new object();
                if (conn == null && tran == null)
                {
                    o = helper.GetSingle(sql, sp);
                }
                else
                {
                    o = helper.GetSingle(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Shop.Save",
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
    /// chujl
    /// </summary>
    public partial class ShopDAO : BaseDAL, IShopDAO
    {

        #region 获取Shop 排单信息
        /// <summary>
        /// 分页获取Shop 排单信息
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public IList<ShopExt> GetShopAndOrderList(IDictionary<string, object> conditionDict)
        {
            IList<ShopExt> list = new List<ShopExt>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();

                StringBuilder whereStr = new StringBuilder();


                if (conditionDict.ContainsKey("ShopType"))
                {
                    whereStr.AppendFormat(" and s.ShopType={0} ", conditionDict["ShopType"]);
                }
                if (conditionDict.ContainsKey("LineId"))
                {
                    whereStr.AppendFormat(" and l.LineId={0} ", conditionDict["LineId"]);
                }

                sql.AppendFormat(@"SELECT l.LineCode,l.LineID,l.LineName,l.SendW1,l.SendW2,l.SendW3,l.SendW4,l.SendW5,l.SendW6,l.SendW7,
                 s.ShopID,s.ShopCode,s.ShopType,s.ShopName,s.ShopAccount,s.WID,L.SerialNumber 
                ,s.LinkMan,s.Telephone,s.Status,s.CreditLevel,s.Address,s.FullAddress
                FROM  WarehouseLine l
                INNER JOIN WarehouseLineShop ls ON L.LineID=ls.LineID
                INNER JOIN Shop s on ls.ShopID=s.ShopID
                WHERE l.IsDeleted=0 AND SendW1=1 and s.WID={0} {1}  
                ORDER BY l.SerialNumber,ls.SerialNumber;", conditionDict["WID"], whereStr.ToString());

                list = GetShopListAndOrder(sql.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }

        #endregion


        /// <summary>
        ///  
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<ShopExt> GetShopListAndOrder(string sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ShopExt> list = new List<ShopExt>();
            try
            {

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new ShopExt
                        {
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopType = DataTypeHelper.GetInt(sdr["ShopType"]),
                            ShopTypeStr = DataTypeHelper.GetInt(sdr["ShopType"]) == 0 ? "加盟店" : "签约店",
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            ShopAccount = DataTypeHelper.GetString(sdr["ShopAccount"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            LinkMan = DataTypeHelper.GetString(sdr["LinkMan"], null),
                            Telephone = DataTypeHelper.GetString(sdr["Telephone"], null),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            CreditLevel = DataTypeHelper.GetString(sdr["CreditLevel"], null),
                            Address = DataTypeHelper.GetString(sdr["Address"], null),
                            FullAddress = DataTypeHelper.GetString(sdr["FullAddress"], null),
                            StatusStr = DataTypeHelper.GetInt(sdr["Status"]) == 0 ? ConstDefinition.ERP_BASEDATA_NAME_FREEZE : ConstDefinition.ERP_BASEDATA_NAME_NORMAL,
                            LineID = DataTypeHelper.GetInt(sdr["LineID"], 0),
                            LineName = DataTypeHelper.GetString(sdr["LineName"], null),
                            LineCode = DataTypeHelper.GetString(sdr["LineCode"], null),
                            SendW1 = DataTypeHelper.GetInt(sdr["SendW1"]),
                            SendW2 = DataTypeHelper.GetInt(sdr["SendW2"]),
                            SendW3 = DataTypeHelper.GetInt(sdr["SendW3"]),
                            SendW4 = DataTypeHelper.GetInt(sdr["SendW4"]),
                            SendW5 = DataTypeHelper.GetInt(sdr["SendW5"]),
                            SendW6 = DataTypeHelper.GetInt(sdr["SendW6"]),
                            SendW7 = DataTypeHelper.GetInt(sdr["SendW7"])
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetShopListAndOrder",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }

    }

    /// <summary>
    /// 龙武
    /// </summary>
    public partial class ShopDAO : BaseDAL, IShopDAO
    {
        /// <summary>
        /// 根据门店编号获取门店所属线路信息
        /// </summary>
        /// <param name="shopId">门店编号</param>
        /// <returns></returns>
        public WarehouseLine GetShopLine(int shopId)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetShopLine", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParam = new SqlParameter[]{
                    new SqlParameter("@ShopID",shopId)
                };
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sParam) as SqlDataReader)
                {
                    WarehouseLine model = null;
                    if (sdr.HasRows)
                    {
                        model = DataReaderHelper.ExecuteToEntity<WarehouseLine>(sdr);
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
