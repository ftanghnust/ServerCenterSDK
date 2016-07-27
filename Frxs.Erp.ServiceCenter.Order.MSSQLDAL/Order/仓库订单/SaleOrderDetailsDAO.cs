
/*****************************
* Author:leidong
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


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### SaleOrderDetails数据库访问类
    /// </summary>
    public partial class SaleOrderDetailsDAO : BaseDAL, ISaleOrderDetailsDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleOrderDetailsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleOrderDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleOrderDetails";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleOrderDetails是否存在
        /// <summary>
        /// 根据主键验证SaleOrderDetails是否存在
        /// </summary>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderDetails model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.Exists",
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


        #region 添加一个SaleOrderDetails
        /// <summary>
        /// 添加一个SaleOrderDetails
        /// </summary>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleOrderDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@PreQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@SalePrice", SqlDbType.Money),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@PromotionUnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@ShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@PromotionShopPoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@SubAddAmt", SqlDbType.Money),
new SqlParameter("@SubPoint", SqlDbType.Money),
new SqlParameter("@SubBasePoint", SqlDbType.Money),
new SqlParameter("@SubVendor1Amt", SqlDbType.Money),
new SqlParameter("@SubVendor2Amt", SqlDbType.Money),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@IsStockOut", SqlDbType.Int),
new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
new SqlParameter("@PromotionName", SqlDbType.NVarChar, 100),
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.WCProductID;
            sp[10].Value = model.PreQty;
            sp[11].Value = model.SaleUnit;
            sp[12].Value = model.SalePackingQty;
            sp[13].Value = model.SalePrice;
            sp[14].Value = model.SaleQty;
            sp[15].Value = model.Unit;
            sp[16].Value = model.UnitQty;
            sp[17].Value = model.UnitPrice;
            sp[18].Value = model.PromotionUnitPrice;
            sp[19].Value = model.SubAmt;
            sp[20].Value = model.ShopAddPerc;
            sp[21].Value = model.ShopPoint;
            sp[22].Value = model.PromotionShopPoint;
            sp[23].Value = model.BasePoint;
            sp[24].Value = model.VendorPerc1;
            sp[25].Value = model.VendorPerc2;
            sp[26].Value = model.SubAddAmt;
            sp[27].Value = model.SubPoint;
            sp[28].Value = model.SubBasePoint;
            sp[29].Value = model.SubVendor1Amt;
            sp[30].Value = model.SubVendor2Amt;
            sp[31].Value = model.IsAppend;
            sp[32].Value = model.EditID;
            sp[33].Value = model.IsStockOut;
            sp[34].Value = model.PromotionID;
            sp[35].Value = model.PromotionName;
            sp[36].Value = model.Remark;
            sp[37].Value = model.SerialNumber;
            sp[38].Value = model.ModifyTime;
            sp[39].Value = model.ModifyUserID;
            sp[40].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.Save",
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


        #region 添加一个SaleOrderDetails(事务处理)
        /// <summary>
        /// 添加一个SaleOrderDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleOrderDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@PreQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@SalePrice", SqlDbType.Money),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@PromotionUnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@ShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@PromotionShopPoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@SubAddAmt", SqlDbType.Money),
new SqlParameter("@SubPoint", SqlDbType.Money),
new SqlParameter("@SubBasePoint", SqlDbType.Money),
new SqlParameter("@SubVendor1Amt", SqlDbType.Money),
new SqlParameter("@SubVendor2Amt", SqlDbType.Money),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@IsStockOut", SqlDbType.Int),
new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
new SqlParameter("@PromotionName", SqlDbType.NVarChar, 100),
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.WCProductID;
            sp[10].Value = model.PreQty;
            sp[11].Value = model.SaleUnit;
            sp[12].Value = model.SalePackingQty;
            sp[13].Value = model.SalePrice;
            sp[14].Value = model.SaleQty;
            sp[15].Value = model.Unit;
            sp[16].Value = model.UnitQty;
            sp[17].Value = model.UnitPrice;
            sp[18].Value = model.PromotionUnitPrice;
            sp[19].Value = model.SubAmt;
            sp[20].Value = model.ShopAddPerc;
            sp[21].Value = model.ShopPoint;
            sp[22].Value = model.PromotionShopPoint;
            sp[23].Value = model.BasePoint;
            sp[24].Value = model.VendorPerc1;
            sp[25].Value = model.VendorPerc2;
            sp[26].Value = model.SubAddAmt;
            sp[27].Value = model.SubPoint;
            sp[28].Value = model.SubBasePoint;
            sp[29].Value = model.SubVendor1Amt;
            sp[30].Value = model.SubVendor2Amt;
            sp[31].Value = model.IsAppend;
            sp[32].Value = model.EditID;
            sp[33].Value = model.IsStockOut;
            sp[34].Value = model.PromotionID;
            sp[35].Value = model.PromotionName;
            sp[36].Value = model.Remark;
            sp[37].Value = model.SerialNumber;
            sp[38].Value = model.ModifyTime;
            sp[39].Value = model.ModifyUserID;
            sp[40].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.Save",
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


        #region 更新一个SaleOrderDetails
        /// <summary>
        /// 更新一个SaleOrderDetails
        /// </summary>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@PreQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@SalePrice", SqlDbType.Money),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@PromotionUnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@ShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@PromotionShopPoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@SubAddAmt", SqlDbType.Money),
new SqlParameter("@SubPoint", SqlDbType.Money),
new SqlParameter("@SubBasePoint", SqlDbType.Money),
new SqlParameter("@SubVendor1Amt", SqlDbType.Money),
new SqlParameter("@SubVendor2Amt", SqlDbType.Money),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@IsStockOut", SqlDbType.Int),
new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
new SqlParameter("@PromotionName", SqlDbType.NVarChar, 100),
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ProductId;
            sp[3].Value = model.SKU;
            sp[4].Value = model.ProductName;
            sp[5].Value = model.BarCode;
            sp[6].Value = model.ProductImageUrl200;
            sp[7].Value = model.ProductImageUrl400;
            sp[8].Value = model.WCProductID;
            sp[9].Value = model.PreQty;
            sp[10].Value = model.SaleUnit;
            sp[11].Value = model.SalePackingQty;
            sp[12].Value = model.SalePrice;
            sp[13].Value = model.SaleQty;
            sp[14].Value = model.Unit;
            sp[15].Value = model.UnitQty;
            sp[16].Value = model.UnitPrice;
            sp[17].Value = model.PromotionUnitPrice;
            sp[18].Value = model.SubAmt;
            sp[19].Value = model.ShopAddPerc;
            sp[20].Value = model.ShopPoint;
            sp[21].Value = model.PromotionShopPoint;
            sp[22].Value = model.BasePoint;
            sp[23].Value = model.VendorPerc1;
            sp[24].Value = model.VendorPerc2;
            sp[25].Value = model.SubAddAmt;
            sp[26].Value = model.SubPoint;
            sp[27].Value = model.SubBasePoint;
            sp[28].Value = model.SubVendor1Amt;
            sp[29].Value = model.SubVendor2Amt;
            sp[30].Value = model.IsAppend;
            sp[31].Value = model.EditID;
            sp[32].Value = model.IsStockOut;
            sp[33].Value = model.PromotionID;
            sp[34].Value = model.PromotionName;
            sp[35].Value = model.Remark;
            sp[36].Value = model.SerialNumber;
            sp[37].Value = model.ModifyTime;
            sp[38].Value = model.ModifyUserID;
            sp[39].Value = model.ModifyUserName;
            sp[40].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.Edit",
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


        #region 更新一个SaleOrderDetails(事务处理)
        /// <summary>
        /// 更新一个SaleOrderDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@PreQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@SalePrice", SqlDbType.Money),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@PromotionUnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@ShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@PromotionShopPoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@SubAddAmt", SqlDbType.Money),
new SqlParameter("@SubPoint", SqlDbType.Money),
new SqlParameter("@SubBasePoint", SqlDbType.Money),
new SqlParameter("@SubVendor1Amt", SqlDbType.Money),
new SqlParameter("@SubVendor2Amt", SqlDbType.Money),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@IsStockOut", SqlDbType.Int),
new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
new SqlParameter("@PromotionName", SqlDbType.NVarChar, 100),
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ProductId;
            sp[3].Value = model.SKU;
            sp[4].Value = model.ProductName;
            sp[5].Value = model.BarCode;
            sp[6].Value = model.ProductImageUrl200;
            sp[7].Value = model.ProductImageUrl400;
            sp[8].Value = model.WCProductID;
            sp[9].Value = model.PreQty;
            sp[10].Value = model.SaleUnit;
            sp[11].Value = model.SalePackingQty;
            sp[12].Value = model.SalePrice;
            sp[13].Value = model.SaleQty;
            sp[14].Value = model.Unit;
            sp[15].Value = model.UnitQty;
            sp[16].Value = model.UnitPrice;
            sp[17].Value = model.PromotionUnitPrice;
            sp[18].Value = model.SubAmt;
            sp[19].Value = model.ShopAddPerc;
            sp[20].Value = model.ShopPoint;
            sp[21].Value = model.PromotionShopPoint;
            sp[22].Value = model.BasePoint;
            sp[23].Value = model.VendorPerc1;
            sp[24].Value = model.VendorPerc2;
            sp[25].Value = model.SubAddAmt;
            sp[26].Value = model.SubPoint;
            sp[27].Value = model.SubBasePoint;
            sp[28].Value = model.SubVendor1Amt;
            sp[29].Value = model.SubVendor2Amt;
            sp[30].Value = model.IsAppend;
            sp[31].Value = model.EditID;
            sp[32].Value = model.IsStockOut;
            sp[33].Value = model.PromotionID;
            sp[34].Value = model.PromotionName;
            sp[35].Value = model.Remark;
            sp[36].Value = model.SerialNumber;
            sp[37].Value = model.ModifyTime;
            sp[38].Value = model.ModifyUserID;
            sp[39].Value = model.ModifyUserName;
            sp[40].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.Edit",
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


        #region 删除一个SaleOrderDetails
        /// <summary>
        /// 删除一个SaleOrderDetails
        /// </summary>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderDetails model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.Delete",
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


        #region 根据主键逻辑删除一个SaleOrderDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderDetails
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.LogicDelete",
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




        #region 根据主键获取SaleOrderDetails对象
        /// <summary>
        /// 根据主键获取SaleOrderDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>SaleOrderDetails对象</returns>
        public SaleOrderDetails GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderDetails model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrderDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.GetModel",
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



        #region 根据字典获取SaleOrderDetails数据集
        /// <summary>
        /// 根据字典获取SaleOrderDetails数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.GetDataSet",
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


        #region 分页获取SaleOrderDetails集合
        /// <summary>
        /// 分页获取SaleOrderDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderDetails> GetPageList(PageListBySql<SaleOrderDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,OrderID,WID,ProductId,SKU,ProductName,BarCode,ProductImageUrl200,ProductImageUrl400,WCProductID,PreQty,SaleUnit,SalePackingQty,SalePrice,SaleQty,Unit,UnitQty,UnitPrice,PromotionUnitPrice,SubAmt,ShopAddPerc,ShopPoint,PromotionShopPoint,BasePoint,VendorPerc1,VendorPerc2,SubAddAmt,SubPoint,SubBasePoint,SubVendor1Amt,SubVendor2Amt,IsAppend,EditID,IsStockOut,PromotionID,PromotionName,Remark,SerialNumber,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.GetPageList",
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
        /// <param name="page">分页辅助类</param>
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


        #region 根据条件获取SaleOrderDetails列表
        /// <summary>
        /// 根据条件获取SaleOrderDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderDetails> list = new List<SaleOrderDetails>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleOrderDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetails.GetList",
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


        #region 根据字典获取SaleOrderPreDetails集合
        /// <summary>
        /// 根据字典获取SaleOrderPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleOrderDetails> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleOrderDetails> list = null;
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


    }
    public partial class SaleOrderDetailsDAO : BaseDAL, ISaleOrderDetailsDAO
    {

        #region ISaleOrderPreDetailsDAO 成员

        /// <summary>
        /// 根据OrderId删除商品明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public int DeleteByOrderId(string orderId, IDbConnection conn = null, IDbTransaction tran = null)
        {

            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByOrderId", base.AssemblyName, base.DatabaseName);
            SqlParamrterBuilder sp = new SqlParamrterBuilder();
            sp.Add("OrderID", SqlDbType.VarChar, 50, orderId);
            try
            {
                object o = new object();
                if (conn != null && tran != null)
                {
                    o = helper.ExecNonQuery(conn, tran, sql, sp.ToSqlParameters());
                }
                else
                {
                    o = helper.ExecNonQuery(sql, sp.ToSqlParameters());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetailsDAO.DeleteByOrderId",
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