
/*****************************
* Author:leidong
*
* Date:2016-04-20
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
    /// ### SaleEditDetails数据库访问类
    /// </summary>
    public partial class SaleEditDetailsDAO : BaseDAL, ISaleEditDetailsDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleEditDetailsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleEditDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleEditDetails";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleEditDetails是否存在
        /// <summary>
        /// 根据主键验证SaleEditDetails是否存在
        /// </summary>
        /// <param name="model">SaleEditDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleEditDetails model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.Exists",
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


        #region 添加一个SaleEditDetails
        /// <summary>
        /// 添加一个SaleEditDetails
        /// </summary>
        /// <param name="model">SaleEditDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleEditDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
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
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@StockQty", SqlDbType.Decimal, 4),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.EditID;
            sp[2].Value = model.OrderID;
            sp[3].Value = model.WID;
            sp[4].Value = model.ProductId;
            sp[5].Value = model.SKU;
            sp[6].Value = model.ProductName;
            sp[7].Value = model.BarCode;
            sp[8].Value = model.ProductImageUrl200;
            sp[9].Value = model.ProductImageUrl400;
            sp[10].Value = model.WCProductID;
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
            sp[31].Value = model.Remark;
            sp[32].Value = model.SerialNumber;
            sp[33].Value = model.ShelfAreaID;
            sp[34].Value = model.ShelfAreaCode;
            sp[35].Value = model.ShelfAreaName;
            sp[36].Value = model.ShelfID;
            sp[37].Value = model.ShelfCode;
            sp[38].Value = model.StockQty;
            sp[39].Value = model.ModifyTime;
            sp[40].Value = model.ModifyUserID;
            sp[41].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.Save",
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


        #region 添加一个SaleEditDetails(事务处理)
        /// <summary>
        /// 添加一个SaleEditDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleEditDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleEditDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
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
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@StockQty", SqlDbType.Decimal, 4),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.EditID;
            sp[2].Value = model.OrderID;
            sp[3].Value = model.WID;
            sp[4].Value = model.ProductId;
            sp[5].Value = model.SKU;
            sp[6].Value = model.ProductName;
            sp[7].Value = model.BarCode;
            sp[8].Value = model.ProductImageUrl200;
            sp[9].Value = model.ProductImageUrl400;
            sp[10].Value = model.WCProductID;
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
            sp[31].Value = model.Remark;
            sp[32].Value = model.SerialNumber;
            sp[33].Value = model.ShelfAreaID;
            sp[34].Value = model.ShelfAreaCode;
            sp[35].Value = model.ShelfAreaName;
            sp[36].Value = model.ShelfID;
            sp[37].Value = model.ShelfCode;
            sp[38].Value = model.StockQty;
            sp[39].Value = model.ModifyTime;
            sp[40].Value = model.ModifyUserID;
            sp[41].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.Save",
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


        #region 更新一个SaleEditDetails
        /// <summary>
        /// 更新一个SaleEditDetails
        /// </summary>
        /// <param name="model">SaleEditDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleEditDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
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
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@StockQty", SqlDbType.Decimal, 4),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.EditID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.WCProductID;
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
            sp[30].Value = model.Remark;
            sp[31].Value = model.SerialNumber;
            sp[32].Value = model.ShelfAreaID;
            sp[33].Value = model.ShelfAreaCode;
            sp[34].Value = model.ShelfAreaName;
            sp[35].Value = model.ShelfID;
            sp[36].Value = model.ShelfCode;
            sp[37].Value = model.StockQty;
            sp[38].Value = model.ModifyTime;
            sp[39].Value = model.ModifyUserID;
            sp[40].Value = model.ModifyUserName;
            sp[41].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.Edit",
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


        #region 更新一个SaleEditDetails(事务处理)
        /// <summary>
        /// 更新一个SaleEditDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleEditDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleEditDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
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
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@StockQty", SqlDbType.Decimal, 4),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.EditID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.WCProductID;
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
            sp[30].Value = model.Remark;
            sp[31].Value = model.SerialNumber;
            sp[32].Value = model.ShelfAreaID;
            sp[33].Value = model.ShelfAreaCode;
            sp[34].Value = model.ShelfAreaName;
            sp[35].Value = model.ShelfID;
            sp[36].Value = model.ShelfCode;
            sp[37].Value = model.StockQty;
            sp[38].Value = model.ModifyTime;
            sp[39].Value = model.ModifyUserID;
            sp[40].Value = model.ModifyUserName;
            sp[41].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.Edit",
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


        #region 删除一个SaleEditDetails
        /// <summary>
        /// 删除一个SaleEditDetails
        /// </summary>
        /// <param name="model">SaleEditDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleEditDetails model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.Delete",
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


        #region 根据主键逻辑删除一个SaleEditDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleEditDetails
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.LogicDelete",
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




        #region 根据主键获取SaleEditDetails对象
        /// <summary>
        /// 根据主键获取SaleEditDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>SaleEditDetails对象</returns>
        public SaleEditDetails GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleEditDetails model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleEditDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.GetModel",
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




        #region 根据字典获取SaleEditDetails数据集
        /// <summary>
        /// 根据字典获取SaleEditDetails数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.GetDataSet",
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


        #region 分页获取SaleEditDetails集合
        /// <summary>
        /// 分页获取SaleEditDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleEditDetails> GetPageList(PageListBySql<SaleEditDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,EditID,OrderID,WID,ProductId,SKU,ProductName,BarCode,ProductImageUrl200,ProductImageUrl400,WCProductID,SaleUnit,SalePackingQty,SalePrice,SaleQty,Unit,UnitQty,UnitPrice,PromotionUnitPrice,SubAmt,ShopAddPerc,ShopPoint,PromotionShopPoint,BasePoint,VendorPerc1,VendorPerc2,SubAddAmt,SubPoint,SubBasePoint,SubVendor1Amt,SubVendor2Amt,Remark,SerialNumber,ShelfAreaID,ShelfAreaCode,ShelfAreaName,ShelfID,ShelfCode,StockQty,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleEditDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.GetPageList",
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


        #region 根据条件获取SaleEditDetails列表
        /// <summary>
        /// 根据条件获取SaleEditDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleEditDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleEditDetails> list = new List<SaleEditDetails>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleEditDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetails.GetList",
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

    public partial class SaleEditDetailsDAO : BaseDAL, ISaleEditDetailsDAO
    {
        /// <summary>
        /// 根据EditId删除明细
        /// </summary>
        /// <param name="editId">改单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public int DeleteByEditId(string editId, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByEditId", base.AssemblyName, base.DatabaseName);
            SqlParamrterBuilder sp = new SqlParamrterBuilder();
            sp.Add("EditId", SqlDbType.VarChar, 50, editId);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditDetailsDAO.DeleteByEditId",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }



        #region ISaleEditDetailsDAO 成员

        /// <summary>
        /// 根据editId查询列表
        /// </summary>
        /// <param name="editId">改单ID</param>
        /// <returns></returns>
        public IList<SaleEditDetails> GetList(string editId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleEditDetails> list = new List<SaleEditDetails>();
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetListByEditId", base.AssemblyName, base.DatabaseName);
            SqlParamrterBuilder sp = new SqlParamrterBuilder();
            sp.Add("EditId", SqlDbType.VarChar, 50, editId);
            try
            {
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp.ToSqlParameters()) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleEditDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleEditOrdersDAO.GetList",
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
}