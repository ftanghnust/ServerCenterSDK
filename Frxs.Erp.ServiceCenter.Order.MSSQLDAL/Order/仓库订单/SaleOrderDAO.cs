
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
    /// ### SaleOrder数据库访问类
    /// </summary>
    public partial class SaleOrderDAO : BaseDAL, ISaleOrderDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleOrderDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleOrderDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleOrder";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleOrder是否存在
        /// <summary>
        /// 根据主键验证SaleOrder是否存在
        /// </summary>
        /// <param name="model">SaleOrder对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrder model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.OrderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.Exists",
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


        #region 添加一个SaleOrder
        /// <summary>
        /// 添加一个SaleOrder
        /// </summary>
        /// <param name="model">SaleOrder对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleOrder model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@OrderDate", SqlDbType.DateTime),
new SqlParameter("@OrderType", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ProvinceID", SqlDbType.Int),
new SqlParameter("@CityID", SqlDbType.Int),
new SqlParameter("@RegionID", SqlDbType.Int),
new SqlParameter("@ProvinceName", SqlDbType.VarChar, 100),
new SqlParameter("@CityName", SqlDbType.VarChar, 100),
new SqlParameter("@RegionName", SqlDbType.VarChar, 100),
new SqlParameter("@Address", SqlDbType.VarChar, 100),
new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
new SqlParameter("@RevLinkMan", SqlDbType.VarChar, 20),
new SqlParameter("@RevTelephone", SqlDbType.VarChar, 20),
new SqlParameter("@ConfDate", SqlDbType.DateTime),
new SqlParameter("@SendDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@LineName", SqlDbType.NVarChar, 50),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@PickingBeginDate", SqlDbType.DateTime),
new SqlParameter("@PickingEndDate", SqlDbType.DateTime),
new SqlParameter("@StockOutRate", SqlDbType.Money),
new SqlParameter("@PackingEmpID", SqlDbType.Int),
new SqlParameter("@PackingEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@PackingTime", SqlDbType.DateTime),
new SqlParameter("@IsPrinted", SqlDbType.Int),
new SqlParameter("@PrintDate", SqlDbType.DateTime),
new SqlParameter("@PrintUserID", SqlDbType.Int),
new SqlParameter("@PrintUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
new SqlParameter("@ShippingUserID", SqlDbType.Int),
new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingEndDate", SqlDbType.DateTime),
new SqlParameter("@FinishDate", SqlDbType.DateTime),
new SqlParameter("@CancelDate", SqlDbType.DateTime),
new SqlParameter("@CloseDate", SqlDbType.DateTime),
new SqlParameter("@CloseReason", SqlDbType.NVarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@TotalProductAmt", SqlDbType.Money),
new SqlParameter("@CouponAmt", SqlDbType.Money),
new SqlParameter("@TotalAddAmt", SqlDbType.Money),
new SqlParameter("@PayAmount", SqlDbType.Money),
new SqlParameter("@TotalPoint", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
new SqlParameter("@UserShowFlag", SqlDbType.Int),
new SqlParameter("@ClientType", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),

//增加日结相关字段
new SqlParameter("@Sett_ID", SqlDbType.VarChar, 50),
new SqlParameter("@Sett_Date", SqlDbType.DateTime),
new SqlParameter("@Sett_Flag", SqlDbType.Int)

};
            sp[0].Value = model.OrderId;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            sp[3].Value = model.OrderDate;
            sp[4].Value = model.OrderType;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.SubWCode;
            sp[8].Value = model.SubWName;
            sp[9].Value = model.ShopID;
            sp[10].Value = model.XSUserID;
            sp[11].Value = model.ShopType;
            sp[12].Value = model.ShopCode;
            sp[13].Value = model.ShopName;
            sp[14].Value = model.Status;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.ProvinceName;
            sp[19].Value = model.CityName;
            sp[20].Value = model.RegionName;
            sp[21].Value = model.Address;
            sp[22].Value = model.FullAddress;
            sp[23].Value = model.RevLinkMan;
            sp[24].Value = model.RevTelephone;
            sp[25].Value = model.ConfDate;
            sp[26].Value = model.SendDate;
            sp[27].Value = model.LineID;
            sp[28].Value = model.LineName;
            sp[29].Value = model.StationNumber;
            sp[30].Value = model.PickingBeginDate;
            sp[31].Value = model.PickingEndDate;
            sp[32].Value = model.StockOutRate;
            sp[33].Value = model.PackingEmpID;
            sp[34].Value = model.PackingEmpName;
            sp[35].Value = model.PackingTime;
            sp[36].Value = model.IsPrinted;
            sp[37].Value = model.PrintDate;
            sp[38].Value = model.PrintUserID;
            sp[39].Value = model.PrintUserName;
            sp[40].Value = model.ShippingBeginDate;
            sp[41].Value = model.ShippingUserID;
            sp[42].Value = model.ShippingUserName;
            sp[43].Value = model.ShippingEndDate;
            sp[44].Value = model.FinishDate;
            sp[45].Value = model.CancelDate;
            sp[46].Value = model.CloseDate;
            sp[47].Value = model.CloseReason;
            sp[48].Value = model.Remark;
            sp[49].Value = model.TotalProductAmt;
            sp[50].Value = model.CouponAmt;
            sp[51].Value = model.TotalAddAmt;
            sp[52].Value = model.PayAmount;
            sp[53].Value = model.TotalPoint;
            sp[54].Value = model.TotalBasePoint;
            sp[55].Value = model.UserShowFlag;
            sp[56].Value = model.ClientType;
            sp[57].Value = model.CreateTime;
            sp[58].Value = model.CreateUserID;
            sp[59].Value = model.CreateUserName;
            sp[60].Value = model.ModifyTime;
            sp[61].Value = model.ModifyUserID;
            sp[62].Value = model.ModifyUserName;

            //增加日结算相关字段
            sp[63].Value = model.Sett_ID;
            sp[64].Value = model.Sett_Date;
            sp[65].Value = model.Sett_Flag;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.Save",
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


        #region 添加一个SaleOrder(事务处理)
        /// <summary>
        /// 添加一个SaleOrder(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrder对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleOrder model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@OrderDate", SqlDbType.DateTime),
new SqlParameter("@OrderType", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ProvinceID", SqlDbType.Int),
new SqlParameter("@CityID", SqlDbType.Int),
new SqlParameter("@RegionID", SqlDbType.Int),
new SqlParameter("@ProvinceName", SqlDbType.VarChar, 100),
new SqlParameter("@CityName", SqlDbType.VarChar, 100),
new SqlParameter("@RegionName", SqlDbType.VarChar, 100),
new SqlParameter("@Address", SqlDbType.VarChar, 100),
new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
new SqlParameter("@RevLinkMan", SqlDbType.VarChar, 20),
new SqlParameter("@RevTelephone", SqlDbType.VarChar, 20),
new SqlParameter("@ConfDate", SqlDbType.DateTime),
new SqlParameter("@SendDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@LineName", SqlDbType.NVarChar, 50),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@PickingBeginDate", SqlDbType.DateTime),
new SqlParameter("@PickingEndDate", SqlDbType.DateTime),
new SqlParameter("@StockOutRate", SqlDbType.Money),
new SqlParameter("@PackingEmpID", SqlDbType.Int),
new SqlParameter("@PackingEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@PackingTime", SqlDbType.DateTime),
new SqlParameter("@IsPrinted", SqlDbType.Int),
new SqlParameter("@PrintDate", SqlDbType.DateTime),
new SqlParameter("@PrintUserID", SqlDbType.Int),
new SqlParameter("@PrintUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
new SqlParameter("@ShippingUserID", SqlDbType.Int),
new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingEndDate", SqlDbType.DateTime),
new SqlParameter("@FinishDate", SqlDbType.DateTime),
new SqlParameter("@CancelDate", SqlDbType.DateTime),
new SqlParameter("@CloseDate", SqlDbType.DateTime),
new SqlParameter("@CloseReason", SqlDbType.NVarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@TotalProductAmt", SqlDbType.Money),
new SqlParameter("@CouponAmt", SqlDbType.Money),
new SqlParameter("@TotalAddAmt", SqlDbType.Money),
new SqlParameter("@PayAmount", SqlDbType.Money),
new SqlParameter("@TotalPoint", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
new SqlParameter("@UserShowFlag", SqlDbType.Int),
new SqlParameter("@ClientType", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@SettleID", SqlDbType.VarChar, 32),

//增加日结相关字段
new SqlParameter("@Sett_ID", SqlDbType.VarChar, 50),
new SqlParameter("@Sett_Date", SqlDbType.DateTime),
new SqlParameter("@Sett_Flag", SqlDbType.Int)

};
            sp[0].Value = model.OrderId;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            sp[3].Value = model.OrderDate;
            sp[4].Value = model.OrderType;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.SubWCode;
            sp[8].Value = model.SubWName;
            sp[9].Value = model.ShopID;
            sp[10].Value = model.XSUserID;
            sp[11].Value = model.ShopType;
            sp[12].Value = model.ShopCode;
            sp[13].Value = model.ShopName;
            sp[14].Value = model.Status;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.ProvinceName;
            sp[19].Value = model.CityName;
            sp[20].Value = model.RegionName;
            sp[21].Value = model.Address;
            sp[22].Value = model.FullAddress;
            sp[23].Value = model.RevLinkMan;
            sp[24].Value = model.RevTelephone;
            sp[25].Value = model.ConfDate;
            sp[26].Value = model.SendDate;
            sp[27].Value = model.LineID;
            sp[28].Value = model.LineName;
            sp[29].Value = model.StationNumber;
            sp[30].Value = model.PickingBeginDate;
            sp[31].Value = model.PickingEndDate;
            sp[32].Value = model.StockOutRate;
            sp[33].Value = model.PackingEmpID;
            sp[34].Value = model.PackingEmpName;
            sp[35].Value = model.PackingTime;
            sp[36].Value = model.IsPrinted;
            sp[37].Value = model.PrintDate;
            sp[38].Value = model.PrintUserID;
            sp[39].Value = model.PrintUserName;
            sp[40].Value = model.ShippingBeginDate;
            sp[41].Value = model.ShippingUserID;
            sp[42].Value = model.ShippingUserName;
            sp[43].Value = model.ShippingEndDate;
            sp[44].Value = model.FinishDate;
            sp[45].Value = model.CancelDate;
            sp[46].Value = model.CloseDate;
            sp[47].Value = model.CloseReason;
            sp[48].Value = model.Remark;
            sp[49].Value = model.TotalProductAmt;
            sp[50].Value = model.CouponAmt;
            sp[51].Value = model.TotalAddAmt;
            sp[52].Value = model.PayAmount;
            sp[53].Value = model.TotalPoint;
            sp[54].Value = model.TotalBasePoint;
            sp[55].Value = model.UserShowFlag;
            sp[56].Value = model.ClientType;
            sp[57].Value = model.CreateTime;
            sp[58].Value = model.CreateUserID;
            sp[59].Value = model.CreateUserName;
            sp[60].Value = model.ModifyTime;
            sp[61].Value = model.ModifyUserID;
            sp[62].Value = model.ModifyUserName;
            sp[63].Value = model.SettleID;

            //增加日结算相关字段
            sp[64].Value = model.Sett_ID;
            sp[65].Value = model.Sett_Date;
            sp[66].Value = model.Sett_Flag;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.Save",
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


        #region 更新一个SaleOrder
        /// <summary>
        /// 更新一个SaleOrder
        /// </summary>
        /// <param name="model">SaleOrder对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrder model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@OrderDate", SqlDbType.DateTime),
new SqlParameter("@OrderType", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ProvinceID", SqlDbType.Int),
new SqlParameter("@CityID", SqlDbType.Int),
new SqlParameter("@RegionID", SqlDbType.Int),
new SqlParameter("@ProvinceName", SqlDbType.VarChar, 100),
new SqlParameter("@CityName", SqlDbType.VarChar, 100),
new SqlParameter("@RegionName", SqlDbType.VarChar, 100),
new SqlParameter("@Address", SqlDbType.VarChar, 100),
new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
new SqlParameter("@RevLinkMan", SqlDbType.VarChar, 20),
new SqlParameter("@RevTelephone", SqlDbType.VarChar, 20),
new SqlParameter("@ConfDate", SqlDbType.DateTime),
new SqlParameter("@SendDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@LineName", SqlDbType.NVarChar, 50),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@PickingBeginDate", SqlDbType.DateTime),
new SqlParameter("@PickingEndDate", SqlDbType.DateTime),
new SqlParameter("@StockOutRate", SqlDbType.Money),
new SqlParameter("@PackingEmpID", SqlDbType.Int),
new SqlParameter("@PackingEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@PackingTime", SqlDbType.DateTime),
new SqlParameter("@IsPrinted", SqlDbType.Int),
new SqlParameter("@PrintDate", SqlDbType.DateTime),
new SqlParameter("@PrintUserID", SqlDbType.Int),
new SqlParameter("@PrintUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
new SqlParameter("@ShippingUserID", SqlDbType.Int),
new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingEndDate", SqlDbType.DateTime),
new SqlParameter("@FinishDate", SqlDbType.DateTime),
new SqlParameter("@CancelDate", SqlDbType.DateTime),
new SqlParameter("@CloseDate", SqlDbType.DateTime),
new SqlParameter("@CloseReason", SqlDbType.NVarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@TotalProductAmt", SqlDbType.Money),
new SqlParameter("@CouponAmt", SqlDbType.Money),
new SqlParameter("@TotalAddAmt", SqlDbType.Money),
new SqlParameter("@PayAmount", SqlDbType.Money),
new SqlParameter("@TotalPoint", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
new SqlParameter("@UserShowFlag", SqlDbType.Int),
new SqlParameter("@ClientType", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@OrderId", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.SettleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            sp[3].Value = model.OrderDate;
            sp[4].Value = model.OrderType;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.SubWCode;
            sp[8].Value = model.SubWName;
            sp[9].Value = model.ShopID;
            sp[10].Value = model.XSUserID;
            sp[11].Value = model.ShopType;
            sp[12].Value = model.ShopCode;
            sp[13].Value = model.ShopName;
            sp[14].Value = model.Status;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.ProvinceName;
            sp[19].Value = model.CityName;
            sp[20].Value = model.RegionName;
            sp[21].Value = model.Address;
            sp[22].Value = model.FullAddress;
            sp[23].Value = model.RevLinkMan;
            sp[24].Value = model.RevTelephone;
            sp[25].Value = model.ConfDate;
            sp[26].Value = model.SendDate;
            sp[27].Value = model.LineID;
            sp[28].Value = model.LineName;
            sp[29].Value = model.StationNumber;
            sp[30].Value = model.PickingBeginDate;
            sp[31].Value = model.PickingEndDate;
            sp[32].Value = model.StockOutRate;
            sp[33].Value = model.PackingEmpID;
            sp[34].Value = model.PackingEmpName;
            sp[35].Value = model.PackingTime;
            sp[36].Value = model.IsPrinted;
            sp[37].Value = model.PrintDate;
            sp[38].Value = model.PrintUserID;
            sp[39].Value = model.PrintUserName;
            sp[40].Value = model.ShippingBeginDate;
            sp[41].Value = model.ShippingUserID;
            sp[42].Value = model.ShippingUserName;
            sp[43].Value = model.ShippingEndDate;
            sp[44].Value = model.FinishDate;
            sp[45].Value = model.CancelDate;
            sp[46].Value = model.CloseDate;
            sp[47].Value = model.CloseReason;
            sp[48].Value = model.Remark;
            sp[49].Value = model.TotalProductAmt;
            sp[50].Value = model.CouponAmt;
            sp[51].Value = model.TotalAddAmt;
            sp[52].Value = model.PayAmount;
            sp[53].Value = model.TotalPoint;
            sp[54].Value = model.TotalBasePoint;
            sp[55].Value = model.UserShowFlag;
            sp[56].Value = model.ClientType;
            sp[57].Value = model.ModifyTime;
            sp[58].Value = model.ModifyUserID;
            sp[59].Value = model.ModifyUserName;
            sp[59].Value = model.OrderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.Edit",
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


        #region 更新一个SaleOrder(事务处理)
        /// <summary>
        /// 更新一个SaleOrder(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrder对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleOrder model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@OrderDate", SqlDbType.DateTime),
new SqlParameter("@OrderType", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ProvinceID", SqlDbType.Int),
new SqlParameter("@CityID", SqlDbType.Int),
new SqlParameter("@RegionID", SqlDbType.Int),
new SqlParameter("@ProvinceName", SqlDbType.VarChar, 100),
new SqlParameter("@CityName", SqlDbType.VarChar, 100),
new SqlParameter("@RegionName", SqlDbType.VarChar, 100),
new SqlParameter("@Address", SqlDbType.VarChar, 100),
new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
new SqlParameter("@RevLinkMan", SqlDbType.VarChar, 20),
new SqlParameter("@RevTelephone", SqlDbType.VarChar, 20),
new SqlParameter("@ConfDate", SqlDbType.DateTime),
new SqlParameter("@SendDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@LineName", SqlDbType.NVarChar, 50),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@PickingBeginDate", SqlDbType.DateTime),
new SqlParameter("@PickingEndDate", SqlDbType.DateTime),
new SqlParameter("@StockOutRate", SqlDbType.Money),
new SqlParameter("@PackingEmpID", SqlDbType.Int),
new SqlParameter("@PackingEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@PackingTime", SqlDbType.DateTime),
new SqlParameter("@IsPrinted", SqlDbType.Int),
new SqlParameter("@PrintDate", SqlDbType.DateTime),
new SqlParameter("@PrintUserID", SqlDbType.Int),
new SqlParameter("@PrintUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
new SqlParameter("@ShippingUserID", SqlDbType.Int),
new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingEndDate", SqlDbType.DateTime),
new SqlParameter("@FinishDate", SqlDbType.DateTime),
new SqlParameter("@CancelDate", SqlDbType.DateTime),
new SqlParameter("@CloseDate", SqlDbType.DateTime),
new SqlParameter("@CloseReason", SqlDbType.NVarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@TotalProductAmt", SqlDbType.Money),
new SqlParameter("@CouponAmt", SqlDbType.Money),
new SqlParameter("@TotalAddAmt", SqlDbType.Money),
new SqlParameter("@PayAmount", SqlDbType.Money),
new SqlParameter("@TotalPoint", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
new SqlParameter("@UserShowFlag", SqlDbType.Int),
new SqlParameter("@ClientType", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@OrderId", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.SettleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            sp[3].Value = model.OrderDate;
            sp[4].Value = model.OrderType;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.SubWCode;
            sp[8].Value = model.SubWName;
            sp[9].Value = model.ShopID;
            sp[10].Value = model.XSUserID;
            sp[11].Value = model.ShopType;
            sp[12].Value = model.ShopCode;
            sp[13].Value = model.ShopName;
            sp[14].Value = model.Status;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.ProvinceName;
            sp[19].Value = model.CityName;
            sp[20].Value = model.RegionName;
            sp[21].Value = model.Address;
            sp[22].Value = model.FullAddress;
            sp[23].Value = model.RevLinkMan;
            sp[24].Value = model.RevTelephone;
            sp[25].Value = model.ConfDate;
            sp[26].Value = model.SendDate;
            sp[27].Value = model.LineID;
            sp[28].Value = model.LineName;
            sp[29].Value = model.StationNumber;
            sp[30].Value = model.PickingBeginDate;
            sp[31].Value = model.PickingEndDate;
            sp[32].Value = model.StockOutRate;
            sp[33].Value = model.PackingEmpID;
            sp[34].Value = model.PackingEmpName;
            sp[35].Value = model.PackingTime;
            sp[36].Value = model.IsPrinted;
            sp[37].Value = model.PrintDate;
            sp[38].Value = model.PrintUserID;
            sp[39].Value = model.PrintUserName;
            sp[40].Value = model.ShippingBeginDate;
            sp[41].Value = model.ShippingUserID;
            sp[42].Value = model.ShippingUserName;
            sp[43].Value = model.ShippingEndDate;
            sp[44].Value = model.FinishDate;
            sp[45].Value = model.CancelDate;
            sp[46].Value = model.CloseDate;
            sp[47].Value = model.CloseReason;
            sp[48].Value = model.Remark;
            sp[49].Value = model.TotalProductAmt;
            sp[50].Value = model.CouponAmt;
            sp[51].Value = model.TotalAddAmt;
            sp[52].Value = model.PayAmount;
            sp[53].Value = model.TotalPoint;
            sp[54].Value = model.TotalBasePoint;
            sp[55].Value = model.UserShowFlag;
            sp[56].Value = model.ClientType;
            sp[57].Value = model.ModifyTime;
            sp[58].Value = model.ModifyUserID;
            sp[59].Value = model.ModifyUserName;
            sp[59].Value = model.OrderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.Edit",
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


        #region 删除一个SaleOrder
        /// <summary>
        /// 删除一个SaleOrder
        /// </summary>
        /// <param name="model">SaleOrder对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrder model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.OrderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.Delete",
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


        #region 根据主键逻辑删除一个SaleOrder
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrder
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string orderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = orderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.LogicDelete",
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





        #region 根据主键获取SaleOrder对象
        /// <summary>
        /// 根据主键获取SaleOrder对象
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrder对象</returns>
        public SaleOrder GetModel(string orderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrder model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
                sp[0].Value = orderId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrder>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.GetModel",
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




        #region 根据字典获取SaleOrder数据集
        /// <summary>
        /// 根据字典获取SaleOrder数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.GetDataSet",
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


        #region 分页获取SaleOrder集合
        /// <summary>
        /// 分页获取SaleOrder集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrder> GetPageList(PageListBySql<SaleOrder> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "OrderId,SettleID,WID,SubWID,OrderDate,OrderType,WCode,WName,SubWCode,SubWName,ShopID,XSUserID,ShopType,ShopCode,ShopName,Status,ProvinceID,CityID,RegionID,ProvinceName,CityName,RegionName,Address,FullAddress,RevLinkMan,RevTelephone,ConfDate,SendDate,LineID,LineName,StationNumber,PickingBeginDate,PickingEndDate,StockOutRate,PackingEmpID,PackingEmpName,PackingTime,IsPrinted,PrintDate,PrintUserID,PrintUserName,ShippingBeginDate,ShippingUserID,ShippingUserName,ShippingEndDate,FinishDate,CancelDate,CloseDate,CloseReason,Remark,TotalProductAmt,CouponAmt,TotalAddAmt,PayAmount,TotalPoint,TotalBasePoint,UserShowFlag,ClientType,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrder>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.GetPageList",
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
                return "OrderId";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleOrder列表
        /// <summary>
        /// 根据条件获取SaleOrder列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrder> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrder> list = new List<SaleOrder>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleOrder>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrder.GetList",
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
}