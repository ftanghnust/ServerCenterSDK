
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
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
    /// ### SaleBackDetails数据库访问类
    /// </summary>
    public partial class SaleBackDetailsDAO : BaseDAL, ISaleBackDetailsDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleBackDetailsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleBackDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "SaleBackDetails";

        #region 事务添加一个SaleBackPreDetails
        /// <summary>
        /// 添加一个SaleBackPreDetails
        /// </summary>
        /// <param name="model">SaleBackDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleBackPreDetails model, IDbConnection conn, IDbTransaction tran)
        {
           DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@ID", SqlDbType.VarChar, 50),
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@ProductId", SqlDbType.Int),
                                new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
                                new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
                                new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
                                new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
                                new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
                                new SqlParameter("@BackUnit", SqlDbType.VarChar, 32),
                                new SqlParameter("@BackPackingQty", SqlDbType.Decimal),
                                new SqlParameter("@BackQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@Unit", SqlDbType.VarChar, 32),
                                new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@UnitPrice", SqlDbType.Money),
                                new SqlParameter("@BasePoint", SqlDbType.Money),
                                new SqlParameter("@SubAmt", SqlDbType.Money),
                                new SqlParameter("@SubBasePoint", SqlDbType.Money),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                                new SqlParameter("@SerialNumber", SqlDbType.Int),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@BackPrice", SqlDbType.Money),
                                new SqlParameter("@ShopAddPerc", SqlDbType.Money),
                                new SqlParameter("@VendorPerc1", SqlDbType.Money),
                                new SqlParameter("@VendorPerc2", SqlDbType.Money),
                                new SqlParameter("@SubAddAmt", SqlDbType.Money),
                                new SqlParameter("@SubVendor1Amt", SqlDbType.Money),
                                new SqlParameter("@SubVendor2Amt", SqlDbType.Money)

                                };
            sp[0].Value = model.ID;
            sp[1].Value = model.BackID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.BackUnit;
            sp[10].Value = model.BackPackingQty;
            sp[11].Value = model.BackQty;
            sp[12].Value = model.Unit;
            sp[13].Value = model.UnitQty;
            sp[14].Value = model.UnitPrice;
            sp[15].Value = model.BasePoint;
            sp[16].Value = model.SubAmt;
            sp[17].Value = model.SubBasePoint;
            sp[18].Value = model.Remark;
            sp[19].Value = model.SerialNumber;
            sp[20].Value = model.ModifyTime;
            sp[21].Value = model.ModifyUserID;
            sp[22].Value = model.ModifyUserName;
            sp[23].Value = model.BackPrice;


            sp[24].Value = model.ShopAddPerc;
            sp[25].Value = model.VendorPerc1;
            sp[26].Value = model.VendorPerc2;
            sp[27].Value = model.SubAddAmt;
            sp[28].Value = model.SubVendor1Amt;
            sp[29].Value = model.SubVendor2Amt;

            try
            {
                object o = new object();
                if (conn == null && tran == null)
                {
                    o = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    o = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackDetails.Save",
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