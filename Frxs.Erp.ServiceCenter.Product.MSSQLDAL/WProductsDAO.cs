
/*****************************
* Author:CR
*
* Date:2016-04-02
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
    /// ### 仓库商品表WProducts数据库访问类
    /// </summary>
    public partial class WProductsDAO : BaseDAL, IWProductsDAO
    {
        const string tableName = "WProducts";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProducts是否存在
        /// <summary>
        /// 根据主键验证WProducts是否存在
        /// </summary>
        /// <param name="model">WProducts对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProducts model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@WProductID", SqlDbType.BigInt)
 };
            sp[0].Value = model.WProductID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.Exists",
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


        #region 添加一个WProducts
        /// <summary>
        /// 添加一个WProducts
        /// </summary>
        /// <param name="model">WProducts对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProducts model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@ProductName2", SqlDbType.NVarChar, 400),
new SqlParameter("@WStatus", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@SalePrice", SqlDbType.Money),
new SqlParameter("@MarketPrice", SqlDbType.Money),
new SqlParameter("@MarketUnit", SqlDbType.VarChar, 32),
new SqlParameter("@BigProductsUnitID", SqlDbType.Int),
new SqlParameter("@BigPackingQty", SqlDbType.Decimal),
new SqlParameter("@BigUnit", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@SaleBackFlag", SqlDbType.VarChar, 20),
new SqlParameter("@BackDays", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.ProductId;
            sp[2].Value = model.ProductName2;
            sp[3].Value = model.WStatus;
            sp[4].Value = model.Unit;
            sp[5].Value = model.SalePrice;
            sp[6].Value = model.MarketPrice;
            sp[7].Value = model.MarketUnit;
            sp[8].Value = model.BigProductsUnitID;
            sp[9].Value = model.BigPackingQty;
            sp[10].Value = model.BigUnit;
            sp[11].Value = model.ShelfID;
            sp[12].Value = model.ShopAddPerc;
            sp[13].Value = model.ShopPoint;
            sp[14].Value = model.BasePoint;
            sp[15].Value = model.VendorPerc1;
            sp[16].Value = model.VendorPerc2;
            sp[17].Value = model.SaleBackFlag;
            sp[18].Value = model.BackDays;
            sp[19].Value = model.CreateTime;
            sp[20].Value = model.CreateUserID;
            sp[21].Value = model.CreateUserName;
            sp[22].Value = model.ModifyTime;
            sp[23].Value = model.ModifyUserID;
            sp[24].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.Save",
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


        #region 更新一个WProducts
        /// <summary>
        /// 更新一个WProducts
        /// </summary>
        /// <param name="model">WProducts对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProducts model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@ProductName2", SqlDbType.NVarChar, 400),
new SqlParameter("@WStatus", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@SalePrice", SqlDbType.Money),
new SqlParameter("@MarketPrice", SqlDbType.Money),
new SqlParameter("@MarketUnit", SqlDbType.VarChar, 32),
new SqlParameter("@BigProductsUnitID", SqlDbType.Int),
new SqlParameter("@BigPackingQty", SqlDbType.Decimal),
new SqlParameter("@BigUnit", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@SaleBackFlag", SqlDbType.VarChar, 20),
new SqlParameter("@BackDays", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@WProductID", SqlDbType.BigInt)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.ProductId;
            sp[2].Value = model.ProductName2;
            sp[3].Value = model.WStatus;
            sp[4].Value = model.Unit;
            sp[5].Value = model.SalePrice;
            sp[6].Value = model.MarketPrice;
            sp[7].Value = model.MarketUnit;
            sp[8].Value = model.BigProductsUnitID;
            sp[9].Value = model.BigPackingQty;
            sp[10].Value = model.BigUnit;
            sp[11].Value = model.ShelfID;
            sp[12].Value = model.ShopAddPerc;
            sp[13].Value = model.ShopPoint;
            sp[14].Value = model.BasePoint;
            sp[15].Value = model.VendorPerc1;
            sp[16].Value = model.VendorPerc2;
            sp[17].Value = model.SaleBackFlag;
            sp[18].Value = model.BackDays;
            sp[19].Value = model.ModifyTime;
            sp[20].Value = model.ModifyUserID;
            sp[21].Value = model.ModifyUserName;
            sp[22].Value = model.WProductID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.Edit",
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


        #region 删除一个WProducts
        /// <summary>
        /// 删除一个WProducts
        /// </summary>
        /// <param name="model">WProducts对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProducts model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WProductID", SqlDbType.BigInt)
 };
            sp[0].Value = model.WProductID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.Delete",
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


        #region 根据主键逻辑删除一个WProducts
        /// <summary>
        /// 根据主键逻辑删除一个WProducts
        /// </summary>
        /// <param name="wProductID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(long wProductID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WProductID", SqlDbType.BigInt)
 };
            sp[0].Value = wProductID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.LogicDelete",
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


        #region 根据字典获取WProducts对象
        /// <summary>
        /// 根据字典获取WProducts对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProducts对象</returns>
        public WProducts GetModel(IDictionary<string, object> conditionDict)
        {
            WProducts model = null;
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
                IList<WProducts> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProducts对象
        /// <summary>
        /// 根据主键获取WProducts对象
        /// </summary>
        /// <param name="wProductID">主键ID</param>
        /// <returns>WProducts对象</returns>
        public WProducts GetModel(long wProductID)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProducts model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@WProductID", SqlDbType.BigInt)
 };
                sp[0].Value = wProductID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WProducts
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            WStatus = DataTypeHelper.GetInt(sdr["WStatus"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"]),
                            MarketPrice = DataTypeHelper.GetDecimalNull(sdr["MarketPrice"]),
                            MarketUnit = DataTypeHelper.GetString(sdr["MarketUnit"], null),
                            BigProductsUnitID = DataTypeHelper.GetIntNull(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimalNull(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            ShelfID = DataTypeHelper.GetIntNull(sdr["ShelfID"]),
                            ShopAddPerc = DataTypeHelper.GetDecimalNull(sdr["ShopAddPerc"]),
                            ShopPoint = DataTypeHelper.GetDecimalNull(sdr["ShopPoint"]),
                            BasePoint = DataTypeHelper.GetDecimalNull(sdr["BasePoint"]),
                            VendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc1"]),
                            VendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc2"]),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            BackDays = DataTypeHelper.GetIntNull(sdr["BackDays"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetIntNull(sdr["ModifyUserID"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetModel",
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


        #region 根据字典获取WProducts集合
        /// <summary>
        /// 根据字典获取WProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProducts> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProducts> list = null;
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


        #region 根据字典获取WProducts数据集
        /// <summary>
        /// 根据字典获取WProducts数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetDataSet",
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


        #region 分页获取WProducts集合
        /// <summary>
        /// 分页获取WProducts集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProducts> GetPageList(PageListBySql<WProducts> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "WProductID,WID,ProductId,ProductName2,WStatus,Unit,SalePrice,MarketPrice,MarketUnit,BigProductsUnitID,BigPackingQty,BigUnit,VendorID,ShelfID,ShopAddPerc,ShopPoint,BasePoint,VendorPerc1,VendorPerc2,SaleBackFlag,BackDays,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new WProducts
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            WStatus = DataTypeHelper.GetInt(sdr["WStatus"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"]),
                            MarketPrice = DataTypeHelper.GetDecimalNull(sdr["MarketPrice"]),
                            MarketUnit = DataTypeHelper.GetString(sdr["MarketUnit"], null),
                            BigProductsUnitID = DataTypeHelper.GetIntNull(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimalNull(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            ShelfID = DataTypeHelper.GetIntNull(sdr["ShelfID"]),
                            ShopAddPerc = DataTypeHelper.GetDecimalNull(sdr["ShopAddPerc"]),
                            ShopPoint = DataTypeHelper.GetDecimalNull(sdr["ShopPoint"]),
                            BasePoint = DataTypeHelper.GetDecimalNull(sdr["BasePoint"]),
                            VendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc1"]),
                            VendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc2"]),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            BackDays = DataTypeHelper.GetIntNull(sdr["BackDays"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetIntNull(sdr["ModifyUserID"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetPageList",
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


        #region 分页获取WProducts集合(B2B平台应用 )
        /// <summary>
        /// 根据字典获取
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductExt> GetListToB2B(IDictionary<string, object> conditionDict)
        {
            IList<WProductExt> list = new List<WProductExt>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"select 
                    wp.WProductID,wp.WID,wp.ProductId,wp.ProductName2,wp.WStatus,wp.Unit,wp.SalePrice,wp.MarketPrice
                    ,wp.MarketUnit,wp.BigProductsUnitID,wp.BigPackingQty,wp.BigUnit,wp.ShelfID,wp.ShopAddPerc
                    ,wp.ShopPoint,wp.BasePoint,wp.VendorPerc1,wp.VendorPerc2,wp.SaleBackFlag,wp.BackDays,wp.CreateTime
                    ,wp.CreateUserID,wp.CreateUserName,wp.ModifyTime,wp.ModifyUserID,wp.ModifyUserName
                    ,Isnull(wp.SalePrice,0.00)*isnull(wp.BigPackingQty,0.00) as BigSalePrice
                    ,isnull(wp.ShopPoint,0.00)*isnull(wp.BigPackingQty,0.00) as BigShopPoint
                    ,p.ProductName,pbc.BarCode,p.SKU
                    ,d.ImageUrl400x400,d.ImageUrl200x200 ,0 as MaxOrderQty,
                    c1.Name as CategoryName1,c2.Name as CategoryName2, c3.Name as CategoryName3,
c1.CategoryId as CategoryId1,c2.CategoryId as CategoryId2, c3.CategoryId as CategoryId3,
                    sh.ShelfCode,sa.ShelfAreaID,sa.ShelfAreaCode,sa.ShelfAreaName 
                     from WProducts wp
                     inner join Products p on wp.ProductId=p.ProductId 
					INNER JOIN BaseProducts bp ON p.BaseProductId=bp.BaseProductId
					LEFT JOIN ProductsBarCodes pbc on p.ProductId=pbc.ProductId and pbc.SerialNumber=1
					Left join Categories c1 on  c1.CategoryId=bp.CategoryId1
					Left join Categories c2 on  c2.CategoryId=bp.CategoryId2
					Left join Categories c3 on  c3.CategoryId=bp.CategoryId3
                     left join  ProductsPictureDetail d on p.ImageProductId=d.ImageProductId and d.IsMaster=1 
                     left join Shelf sh on wp.ShelfID=sh.ShelfID  
                     left join ShelfArea sa on sh.ShelfAreaID =sa.ShelfAreaID  
                     WHERE wp.WStatus=1 and not exists
                     ( select 1 from Shop s inner join 
                    ShopGroupDetails sd on s.ShopID=sd.ShopID inner join 
                    WProductNoSaleShops nss on sd.GroupID=nss.GroupID inner join 
                    WProductNoSale ns on ns.NoSaleID=nss.NoSaleID and ns.Status=2 inner join 
                    WProductNoSaleDetails nsd on ns.NoSaleID=nsd.NoSaleID 
                    where p.ProductId=nsd.ProductID and s.ShopID={2} 
                     ) and wp.WID='{0}' and p.ProductId in({1}) ;", conditionDict["WID"], conditionDict["ProductIDs"], conditionDict["ShopID"]);

                list = GetListToB2B(sql.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }


        /// <summary>
        /// 根据字典获取(包括限购)
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductExt> GetListToB2BExt(IDictionary<string, object> conditionDict)
        {
            IList<WProductExt> list = new List<WProductExt>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"select 
                    wp.WProductID,wp.WID,wp.ProductId,wp.ProductName2,wp.WStatus,wp.Unit,wp.SalePrice,wp.MarketPrice
                    ,wp.MarketUnit,wp.BigProductsUnitID,wp.BigPackingQty,wp.BigUnit,wp.ShelfID,wp.ShopAddPerc
                    ,wp.ShopPoint,wp.BasePoint,wp.VendorPerc1,wp.VendorPerc2,wp.SaleBackFlag,wp.BackDays,wp.CreateTime
                    ,wp.CreateUserID,wp.CreateUserName,wp.ModifyTime,wp.ModifyUserID,wp.ModifyUserName
                    ,Isnull(wp.SalePrice,0.00)*isnull(wp.BigPackingQty,0.00) as BigSalePrice
                    ,isnull(wp.ShopPoint,0.00)*isnull(wp.BigPackingQty,0.00) as BigShopPoint
                    ,p.ProductName,pbc.BarCode,p.SKU
                    ,d.ImageUrl400x400,d.ImageUrl200x200 ,0 as MaxOrderQty,
                    c1.CategoryName as CategoryName1,c2.CategoryName as CategoryName2, c3.CategoryName as CategoryName3,
c1.CategoryId as CategoryId1,c2.CategoryId as CategoryId2, c3.CategoryId as CategoryId3,
                    sh.ShelfCode,sa.ShelfAreaID,sa.ShelfAreaCode,sa.ShelfAreaName 
                     from WProducts wp
                     inner join Products p on wp.ProductId=p.ProductId 
					INNER JOIN BaseProducts bp ON p.BaseProductId=bp.BaseProductId
					LEFT JOIN ProductsBarCodes pbc on p.ProductId=pbc.ProductId and pbc.SerialNumber=1
					Left join ShopCategories c1 on  c1.CategoryId=bp.CategoryId1
					Left join ShopCategories c2 on  c2.CategoryId=bp.CategoryId2
					Left join ShopCategories c3 on  c3.CategoryId=bp.CategoryId3
                     left join  ProductsPictureDetail d on p.ImageProductId=d.ImageProductId and d.IsMaster=1 
                     left join Shelf sh on wp.ShelfID=sh.ShelfID  
                     left join ShelfArea sa on sh.ShelfAreaID =sa.ShelfAreaID  
                     WHERE wp.WStatus=1 and wp.WID='{0}' and p.ProductId in({1}) ;", conditionDict["WID"], conditionDict["ProductIDs"]);

                list = GetListToB2B(sql.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }

        /// <summary>
        /// 分页获取网仓商品查询结果 排除限购的
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        public IDictionary<string, object> GetListToB2BByPage(IDictionary<string, object> conditionDict)
        {
            IDictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                #region 动态配置查询条件 及SQL

                StringBuilder whereStr = new StringBuilder();
                string shopIsStr = "";
                int pageIndex = int.Parse(conditionDict["PageIndex"].ToString());
                int pageSize = int.Parse(conditionDict["PageSize"].ToString());
                string sortBy = "";
                if (conditionDict.ContainsKey("SortBy"))
                {
                    sortBy = conditionDict["SortBy"].ToString();
                }
                else
                {
                    sortBy = " ProductId ";
                }

                if (conditionDict.ContainsKey("ShopID"))
                {
                    shopIsStr = string.Format("  and s.ShopID={0} ", conditionDict["ShopID"]);
                }
                if (conditionDict.ContainsKey("ProductIDs"))
                {
                    whereStr.AppendFormat(" and p.ProductId in({0})", conditionDict["ProductIDs"]);
                }
                if (conditionDict.ContainsKey("SKUs"))
                {
                    whereStr.AppendFormat(" and p.SKU in('{0}')", conditionDict["SKUs"].ToString().Replace(",", "','"));
                }
                if (conditionDict.ContainsKey("SKU"))
                {
                    whereStr.AppendFormat(" and p.SKU like '%{0}%' ", conditionDict["SKU"]);
                }
                if (conditionDict.ContainsKey("ProductName"))
                {
                    whereStr.AppendFormat(" and p.ProductName like '%{0}%' ", conditionDict["ProductName"]);
                }
                if (conditionDict.ContainsKey("WID"))
                {
                    whereStr.AppendFormat(" and wp.WID = {0} ", conditionDict["WID"]);
                }

                if (conditionDict.ContainsKey("CategoryId1"))
                {
                    whereStr.AppendFormat(" and bp.ShopCategoryId1 = {0} ", conditionDict["CategoryId1"]);
                }

                if (conditionDict.ContainsKey("CategoryId2"))
                {
                    whereStr.AppendFormat(" and bp.ShopCategoryId2 = {0} ", conditionDict["CategoryId2"]);
                }

                if (conditionDict.ContainsKey("CategoryId3"))
                {
                    whereStr.AppendFormat(" and bp.ShopCategoryId3 = {0} ", conditionDict["CategoryId3"]);
                }


                if (conditionDict.ContainsKey("KeyWord"))
                {
                    whereStr.AppendFormat(" and (  p.SKU like '%{0}%' or pbc.BarCode like '%{0}%' or p.ProductName like '%{0}%' or p.Keywords like '%{0}%' or  p.Mnemonic like '%{0}%'  ) ", conditionDict["KeyWord"]);
                }

                sql.AppendFormat(@"WITH LIST AS ( select ROW_NUMBER() OVER (ORDER BY p.ProductId DESC) AS RowNum, 
                    wp.WProductID,wp.WID,wp.ProductId,wp.ProductName2,wp.WStatus,wp.Unit,wp.SalePrice,wp.MarketPrice
                    ,wp.MarketUnit,wp.BigProductsUnitID,wp.BigPackingQty,wp.BigUnit,wp.ShelfID,wp.ShopAddPerc
                    ,wp.ShopPoint,wp.BasePoint,wp.VendorPerc1,wp.VendorPerc2,wp.SaleBackFlag,wp.BackDays,wp.CreateTime
                    ,wp.CreateUserID,wp.CreateUserName,wp.ModifyTime,wp.ModifyUserID,wp.ModifyUserName
                    ,Isnull(wp.SalePrice,0.00)*isnull(wp.BigPackingQty,0.00) as BigSalePrice
                    ,isnull(wp.ShopPoint,0.00)*isnull(wp.BigPackingQty,0.00) as BigShopPoint
                    ,p.ProductName,pbc.BarCode,p.SKU,d.ImageUrl400x400,d.ImageUrl200x200 ,0 as MaxOrderQty,
                    c1.CategoryName as CategoryName1,c2.CategoryName as CategoryName2, c3.CategoryName as CategoryName3,
                    c1.CategoryId as CategoryId1,c2.CategoryId as CategoryId2, c3.CategoryId as CategoryId3,
                    sh.ShelfCode,sa.ShelfAreaID,sa.ShelfAreaCode,sa.ShelfAreaName    
                     from WProducts wp
                     inner join Products p on wp.ProductId=p.ProductId 
                     INNER JOIN BaseProducts bp ON p.BaseProductId=bp.BaseProductId
					LEFT JOIN ProductsBarCodes pbc on p.ProductId=pbc.ProductId and pbc.SerialNumber=1
					Left join ShopCategories c1 on  c1.CategoryId=bp.ShopCategoryId1
					Left join ShopCategories c2 on  c2.CategoryId=bp.ShopCategoryId2
					Left join ShopCategories c3 on  c3.CategoryId=bp.ShopCategoryId3
                     left join  ProductsPictureDetail d on p.ImageProductId=d.ImageProductId and d.IsMaster=1 
                     left join Shelf sh on wp.ShelfID=sh.ShelfID 
                     left join ShelfArea sa on sh.ShelfAreaID =sa.ShelfAreaID 
                     WHERE wp.WStatus=1 and not exists
                     ( select 1 from Shop s inner join 
                    ShopGroupDetails sd on s.ShopID=sd.ShopID inner join 
                    WProductNoSaleShops nss on sd.GroupID=nss.GroupID inner join 
                    WProductNoSale ns on ns.NoSaleID=nss.NoSaleID and ns.Status=2 inner join 
                    WProductNoSaleDetails nsd on ns.NoSaleID=nsd.NoSaleID 
                    where p.ProductId=nsd.ProductID {0} 
                     ) {1} ) ", shopIsStr, whereStr.ToString());
                #endregion

                returnObject.Add("totalCount", GetCount(sql.ToString()));

                returnObject.Add("itemList", GetList(sql.ToString(), pageIndex, pageSize, sortBy, sp));

            }
            catch
            {
                throw;
            }
            return returnObject;
        }


        /// <summary>
        /// 分页获取(包括限购)
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        public IDictionary<string, object> GetListToB2BExtByPage(IDictionary<string, object> conditionDict)
        {
            IDictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                #region 动态配置查询条件 及SQL

                StringBuilder whereStr = new StringBuilder();
                int pageIndex = int.Parse(conditionDict["PageIndex"].ToString());
                int pageSize = int.Parse(conditionDict["PageSize"].ToString());
                string sortBy = "";
                if (conditionDict.ContainsKey("SortBy"))
                {
                    sortBy = conditionDict["SortBy"].ToString();
                }
                else
                {
                    sortBy = " ProductId ";
                }



                if (conditionDict.ContainsKey("ProductIDs"))
                {
                    whereStr.AppendFormat(" and p.ProductId in({0})", conditionDict["ProductIDs"]);
                }
                if (conditionDict.ContainsKey("SKU"))
                {
                    whereStr.AppendFormat(" and p.SKU like '%{0}%' ", conditionDict["SKU"]);
                }
                if (conditionDict.ContainsKey("ProductName"))
                {
                    whereStr.AppendFormat(" and p.ProductName like '%{0}%' ", conditionDict["ProductName"]);
                }
                if (conditionDict.ContainsKey("WID"))
                {
                    whereStr.AppendFormat(" and wp.WID = {0} ", conditionDict["WID"]);
                }

                if (conditionDict.ContainsKey("CategoryId1"))
                {
                    whereStr.AppendFormat(" and bp.CategoryId1 = {0} ", conditionDict["CategoryId1"]);
                }

                if (conditionDict.ContainsKey("CategoryId2"))
                {
                    whereStr.AppendFormat(" and bp.CategoryId2 = {0} ", conditionDict["CategoryId2"]);
                }

                if (conditionDict.ContainsKey("CategoryId3"))
                {
                    whereStr.AppendFormat(" and bp.CategoryId3 = {0} ", conditionDict["CategoryId3"]);
                }


                if (conditionDict.ContainsKey("KeyWord"))
                {
                    whereStr.AppendFormat(" and (  p.SKU like '%{0}%' or pbc.BarCode like '%{0}%' or p.ProductName like '%{0}%' or p.Keywords  like '%{0}%' or p.Mnemonic like '%{0}%' ) ", conditionDict["KeyWord"]);
                }

                sql.AppendFormat(@"WITH LIST AS ( select ROW_NUMBER() OVER (ORDER BY p.ProductId DESC) AS RowNum, 
                    wp.WProductID,wp.WID,wp.ProductId,wp.ProductName2,wp.WStatus,wp.Unit,wp.SalePrice,wp.MarketPrice
                    ,wp.MarketUnit,wp.BigProductsUnitID,wp.BigPackingQty,wp.BigUnit,wp.ShelfID,wp.ShopAddPerc
                    ,wp.ShopPoint,wp.BasePoint,wp.VendorPerc1,wp.VendorPerc2,wp.SaleBackFlag,wp.BackDays,wp.CreateTime
                    ,wp.CreateUserID,wp.CreateUserName,wp.ModifyTime,wp.ModifyUserID,wp.ModifyUserName
                    ,Isnull(wp.SalePrice,0.00)*isnull(wp.BigPackingQty,0.00) as BigSalePrice
                    ,isnull(wp.ShopPoint,0.00)*isnull(wp.BigPackingQty,0.00) as BigShopPoint
                    ,p.ProductName,pbc.BarCode,p.SKU,d.ImageUrl400x400,d.ImageUrl200x200 ,0 as MaxOrderQty,
                    c1.Name as CategoryName1,c2.Name as CategoryName2, c3.Name as CategoryName3,
c1.CategoryId as CategoryId1,c2.CategoryId as CategoryId2, c3.CategoryId as CategoryId3,
                    sh.ShelfCode,sa.ShelfAreaID,sa.ShelfAreaCode,sa.ShelfAreaName    
                     from WProducts wp
                     inner join Products p on wp.ProductId=p.ProductId 
                     INNER JOIN BaseProducts bp ON p.BaseProductId=bp.BaseProductId
					LEFT JOIN ProductsBarCodes pbc on p.ProductId=pbc.ProductId and pbc.SerialNumber=1
					Left join Categories c1 on  c1.CategoryId=bp.CategoryId1
					Left join Categories c2 on  c2.CategoryId=bp.CategoryId2
					Left join Categories c3 on  c3.CategoryId=bp.CategoryId3
                     left join  ProductsPictureDetail d on p.ImageProductId=d.ImageProductId and d.IsMaster=1 
                     left join Shelf sh on wp.ShelfID=sh.ShelfID 
                     left join ShelfArea sa on sh.ShelfAreaID =sa.ShelfAreaID 
                     WHERE wp.WStatus=1 {0} ) ", whereStr.ToString());
                #endregion

                returnObject.Add("totalCount", GetCount(sql.ToString()));

                returnObject.Add("itemList", GetList(sql.ToString(), pageIndex, pageSize, sortBy, sp));

            }
            catch
            {
                throw;
            }
            return returnObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetCount(string sql)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {

                string _sql = sql + " SELECT COUNT(*) FROM LIST ";
                SqlParamrterBuilder paramter = new SqlParamrterBuilder();
                return int.Parse(helper.GetSingle(_sql, paramter.ToSqlParameters()).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetCount",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<WProductExt> GetList(string sql, int pageIndex, int pageSize, string sortBy, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string _sql = sql + string.Format(" SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1} order by {2}", (pageIndex - 1) * pageSize + 1, pageIndex * pageSize, sortBy);
                SqlParamrterBuilder paramter = new SqlParamrterBuilder();
                return GetListToB2B(_sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetList",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        #endregion


        #region 分页获取WProducts集合(通过ProductIDs集合 )
        /// <summary>
        /// 根据字典获取WarehouseMessage集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProducts> GetListByIDs(IDictionary<string, object> conditionDict)
        {
            IList<WProducts> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"SELECT 
                WProductID,WID,ProductId,ProductName2,WStatus,Unit
                ,SalePrice,MarketPrice,MarketUnit,BigProductsUnitID,BigPackingQty
                ,BigUnit,ShelfID,ShopAddPerc,ShopPoint,BasePoint
                ,VendorPerc1,VendorPerc2,SaleBackFlag,BackDays,CreateTime
                ,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName
                  FROM  WProducts  where WID='{0}' and ProductId in({1}) ;",
                                                                                 conditionDict["WID"], conditionDict["ProductIDs"]);

                list = GetListByIDs(sql, sp);
            }
            catch
            {
                throw;
            }
            return list;
        }
        /// <summary>
        /// 根据字典获取WarehouseMessage集合 增加了扩展信息(包括采购员等)
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductExt> GetListByIDsExt(IDictionary<string, object> conditionDict)
        {
            IList<WProductExt> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"select 
                    wp.WProductID,wp.WID,wp.ProductId,wp.ProductName2,wp.WStatus,wp.Unit,wp.SalePrice,wp.MarketPrice
                    ,wp.MarketUnit,wp.BigProductsUnitID,wp.BigPackingQty,wp.BigUnit,wp.ShelfID,wp.ShopAddPerc
                    ,wp.ShopPoint,wp.BasePoint,wp.VendorPerc1,wp.VendorPerc2,wp.SaleBackFlag,wp.BackDays,wp.CreateTime
                    ,wp.CreateUserID,wp.CreateUserName,wp.ModifyTime,wp.ModifyUserID,wp.ModifyUserName
                    ,Isnull(wp.SalePrice,0.00)*isnull(wp.BigPackingQty,0.00) as BigSalePrice
                    ,isnull(wp.ShopPoint,0.00)*isnull(wp.BigPackingQty,0.00) as BigShopPoint
                    ,p.ProductName,pbc.BarCode,p.SKU
                    ,d.ImageUrl400x400,d.ImageUrl200x200 ,0 as MaxOrderQty,
                    c1.Name as CategoryName1,c2.Name as CategoryName2, c3.Name as CategoryName3,
                    bp.CategoryId1,bp.CategoryId2,bp.CategoryId3,
                    sh.ShelfCode,sa.ShelfAreaID,sa.ShelfAreaCode,sa.ShelfAreaName,
                    V.VendorID,V.VendorName,V.VendorCode,pv.BuyPrice,
                    wemp.EmpID,wemp.EmpName 
                     from 
                     WProducts wp  inner join Products p on wp.ProductId=p.ProductId 
                    inner join  WProductsBuy pv  on wp.WProductID=pv.WProductID
                    LEFT JOIN  Vendor V ON PV.VendorID=V.VendorID
					INNER JOIN BaseProducts bp ON p.BaseProductId=bp.BaseProductId
					LEFT JOIN ProductsBarCodes pbc on p.ProductId=pbc.ProductId and pbc.SerialNumber=1
					Left join Categories c1 on  c1.CategoryId=bp.CategoryId1
					Left join Categories c2 on  c2.CategoryId=bp.CategoryId2
					Left join Categories c3 on  c3.CategoryId=bp.CategoryId3
                     left join  ProductsPictureDetail d on p.ImageProductId=d.ImageProductId and d.IsMaster=1 
                     left join Shelf sh on wp.ShelfID=sh.ShelfID  
                     left join ShelfArea sa on sh.ShelfAreaID =sa.ShelfAreaID  
                     left join WProductsBuyEmp wpemp on wp.WProductID=wpemp.WProductID and wpemp.SerialNumber=1 
                     left join WarehouseEmp wemp on wpemp.EmpID=wemp.EmpID 
                     WHERE wp.WStatus=1  and wp.WID='{0}'  ", conditionDict["WID"]);
                if (conditionDict.ContainsKey("ProductIDs"))
                {
                    sql.AppendFormat(" and p.ProductId in({0}) ", conditionDict["ProductIDs"]);
                }
                if (conditionDict.ContainsKey("ProductSKUs"))
                {
                    sql.AppendFormat(" and p.SKU in({0}) ", conditionDict["ProductSKUs"]);
                }

                list = GetListByIDsExt(sql, sp);
            }
            catch
            {
                throw;
            }
            return list;
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.UpdateField",
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
                return "WProductID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WProducts列表
        /// <summary>
        /// 根据条件获取WProducts列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProducts> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProducts> list = new List<WProducts>();
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
                        list.Add(new WProducts
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            WStatus = DataTypeHelper.GetInt(sdr["WStatus"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            SalePrice = DataTypeHelper.GetDecimalNull(sdr["SalePrice"]),
                            MarketPrice = DataTypeHelper.GetDecimalNull(sdr["MarketPrice"]),
                            MarketUnit = DataTypeHelper.GetString(sdr["MarketUnit"], null),
                            BigProductsUnitID = DataTypeHelper.GetIntNull(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimalNull(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            ShelfID = DataTypeHelper.GetIntNull(sdr["ShelfID"]),
                            ShopAddPerc = DataTypeHelper.GetDecimalNull(sdr["ShopAddPerc"]),
                            ShopPoint = DataTypeHelper.GetDecimalNull(sdr["ShopPoint"]),
                            BasePoint = DataTypeHelper.GetDecimalNull(sdr["BasePoint"]),
                            VendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc1"]),
                            VendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc2"]),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            BackDays = DataTypeHelper.GetIntNull(sdr["BackDays"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetIntNull(sdr["ModifyUserID"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }

        /// <summary>
        /// 根据条件获取WProducts列表(B2B平台应用)
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProductExt> GetListToB2B(string sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductExt> list = new List<WProductExt>();
            try
            {

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new WProductExt
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            WStatus = DataTypeHelper.GetInt(sdr["WStatus"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            SalePrice = DataTypeHelper.GetDecimal(sdr["SalePrice"], 0),
                            MarketPrice = DataTypeHelper.GetDecimal(sdr["MarketPrice"], 0),
                            MarketUnit = DataTypeHelper.GetString(sdr["MarketUnit"], null),
                            BigProductsUnitID = DataTypeHelper.GetInt(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimalNull(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShopAddPerc = DataTypeHelper.GetDecimal(sdr["ShopAddPerc"], 0),
                            ShopPoint = DataTypeHelper.GetDecimal(sdr["ShopPoint"], 0),
                            BasePoint = DataTypeHelper.GetDecimal(sdr["BasePoint"], 0),
                            VendorPerc1 = DataTypeHelper.GetDecimal(sdr["VendorPerc1"], 0),
                            VendorPerc2 = DataTypeHelper.GetDecimal(sdr["VendorPerc2"], 0),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            BackDays = DataTypeHelper.GetInt(sdr["BackDays"], 0),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            MaxOrderQty = DataTypeHelper.GetDecimal(sdr["MaxOrderQty"], 0),
                            BigSalePrice = DataTypeHelper.GetDecimal(sdr["BigSalePrice"], 0),
                            BigShopPoint = DataTypeHelper.GetDecimal(sdr["BigShopPoint"], 0),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            ImageUrl400x400 = DataTypeHelper.GetString(sdr["ImageUrl400x400"], null),
                            ImageUrl200x200 = DataTypeHelper.GetString(sdr["ImageUrl200x200"], null),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            CategoryName1 = DataTypeHelper.GetString(sdr["CategoryName1"], null),
                            CategoryName2 = DataTypeHelper.GetString(sdr["CategoryName2"], null),
                            CategoryName3 = DataTypeHelper.GetString(sdr["CategoryName3"], null),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null),
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            ShelfAreaCode = DataTypeHelper.GetString(sdr["ShelfAreaCode"], null),
                            ShelfAreaName = DataTypeHelper.GetString(sdr["ShelfAreaName"], null),
                            CategoryId1 = DataTypeHelper.GetInt(sdr["CategoryId1"]),
                            CategoryId2 = DataTypeHelper.GetInt(sdr["CategoryId2"]),
                            CategoryId3 = DataTypeHelper.GetInt(sdr["CategoryId3"])
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetListToB2B",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }

        /// <summary>
        /// 根据条件获取WProducts列表(IDs集合)
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProducts> GetListByIDs(StringBuilder sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProducts> list = new List<WProducts>();
            try
            {

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new WProducts
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            WStatus = DataTypeHelper.GetInt(sdr["WStatus"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            SalePrice = DataTypeHelper.GetDecimal(sdr["SalePrice"], 0),
                            MarketPrice = DataTypeHelper.GetDecimal(sdr["MarketPrice"], 0),
                            MarketUnit = DataTypeHelper.GetString(sdr["MarketUnit"], null),
                            BigProductsUnitID = DataTypeHelper.GetInt(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimalNull(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShopAddPerc = DataTypeHelper.GetDecimal(sdr["ShopAddPerc"], 0),
                            ShopPoint = DataTypeHelper.GetDecimal(sdr["ShopPoint"], 0),
                            BasePoint = DataTypeHelper.GetDecimal(sdr["BasePoint"], 0),
                            VendorPerc1 = DataTypeHelper.GetDecimal(sdr["VendorPerc1"], 0),
                            VendorPerc2 = DataTypeHelper.GetDecimal(sdr["VendorPerc2"], 0),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            BackDays = DataTypeHelper.GetInt(sdr["BackDays"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetListToB2B",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }


        /// <summary>
        /// 根据条件获取WProducts列表(IDs集合)
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProductExt> GetListByIDsExt(StringBuilder sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductExt> list = new List<WProductExt>();
            try
            {

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new WProductExt
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            WStatus = DataTypeHelper.GetInt(sdr["WStatus"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            SalePrice = DataTypeHelper.GetDecimal(sdr["SalePrice"], 0),
                            MarketPrice = DataTypeHelper.GetDecimal(sdr["MarketPrice"], 0),
                            MarketUnit = DataTypeHelper.GetString(sdr["MarketUnit"], null),
                            BigProductsUnitID = DataTypeHelper.GetInt(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimalNull(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShopAddPerc = DataTypeHelper.GetDecimal(sdr["ShopAddPerc"], 0),
                            ShopPoint = DataTypeHelper.GetDecimal(sdr["ShopPoint"], 0),
                            BasePoint = DataTypeHelper.GetDecimal(sdr["BasePoint"], 0),
                            VendorPerc1 = DataTypeHelper.GetDecimal(sdr["VendorPerc1"], 0),
                            VendorPerc2 = DataTypeHelper.GetDecimal(sdr["VendorPerc2"], 0),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            BackDays = DataTypeHelper.GetInt(sdr["BackDays"], 0),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            MaxOrderQty = DataTypeHelper.GetDecimal(sdr["MaxOrderQty"], 0),
                            BigSalePrice = DataTypeHelper.GetDecimal(sdr["BigSalePrice"], 0),
                            BigShopPoint = DataTypeHelper.GetDecimal(sdr["BigShopPoint"], 0),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            ImageUrl400x400 = DataTypeHelper.GetString(sdr["ImageUrl400x400"], null),
                            ImageUrl200x200 = DataTypeHelper.GetString(sdr["ImageUrl200x200"], null),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            CategoryName1 = DataTypeHelper.GetString(sdr["CategoryName1"], null),
                            CategoryName2 = DataTypeHelper.GetString(sdr["CategoryName2"], null),
                            CategoryName3 = DataTypeHelper.GetString(sdr["CategoryName3"], null),
                            CategoryId1 = DataTypeHelper.GetInt(sdr["CategoryId1"]),
                            CategoryId2 = DataTypeHelper.GetInt(sdr["CategoryId2"]),
                            CategoryId3 = DataTypeHelper.GetInt(sdr["CategoryId3"]),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"]),
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            ShelfAreaCode = DataTypeHelper.GetString(sdr["ShelfAreaCode"], null),
                            ShelfAreaName = DataTypeHelper.GetString(sdr["ShelfAreaName"], null),
                            VendorID = DataTypeHelper.GetIntNull(sdr["VendorID"],0),
                            VendorName = DataTypeHelper.GetString(sdr["VendorName"], null),
                            VendorCode = DataTypeHelper.GetString(sdr["VendorCode"], null),
                            BuyPrice = DataTypeHelper.GetDecimal(sdr["BuyPrice"], 0),
                            EmpID = DataTypeHelper.GetString(sdr["EmpID"], null),
                            EmpName = DataTypeHelper.GetString(sdr["EmpName"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetListByIDsExt",
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

    public partial class WProductsDAO : BaseDAL, IWProductsDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<ProductVendorModel> GetProductVendors(int wid, int productId)
        {
            return this.ExecuteTolist<ProductVendorModel>("GetProductVendors", new SqlParamrterBuilder().Append("WID", wid).Append("ProductId", productId).ToSqlParameters());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wproductId"></param>
        /// <param name="vendorID"></param>
        public void VendorIDUpdate(long wproductId, int vendorID)
        {
            string sql = "update WProducts set VendorID=@VendorID where [WProductID]=@WProductID";
            DBHelper helper = DBHelper.GetInstance();
            helper.ExecNonQuery(sql, new SqlParamrterBuilder().Append("WProductID", wproductId).Append("VendorID", vendorID).ToSqlParameters());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<Products> GetSubProductIds(int wid, int productId)
        {
            return this.ExecuteTolist<Products>("GetSubProductIds", new SqlParamrterBuilder().Append("WID", wid).Append("ProductId", productId).ToSqlParameters());
        }
    }
}