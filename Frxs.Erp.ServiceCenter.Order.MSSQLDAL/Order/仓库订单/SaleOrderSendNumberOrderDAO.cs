/*****************************
* Author:周进
*
* Date:2016-04-26
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
    public partial class SaleOrderSendNumberOrderDAO : BaseDAL, ISaleOrderSendNumberOrderDAO
    {
        public SaleOrderSendNumberOrderDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "SaleOrderSendNumberOrder";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }

        public SaleOrderPre GetSearchSaleOrderSend(IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSearchSaleOrderSend", base.AssemblyName, base.DatabaseName);
                StringBuilder where = new StringBuilder("");
                IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "@WID", SqlDbType = SqlDbType.Int, Value = conditionDict["WID"] });
                if (conditionDict.ContainsKey("ShopCode"))//单号 StockAdj.AdjID
                {
                    where.Append(" AND t3.ShopCode=@ShopCode");
                    parameters.Add(new SqlParameter() { ParameterName = "@ShopCode", SqlDbType = SqlDbType.VarChar, Size = 10, Value = conditionDict["ShopCode"].ToString() });
                }
                if (conditionDict.ContainsKey("OrderId"))//单号 StockAdj.AdjID
                {
                    where.Append(" AND t3.OrderId=@OrderId");
                    parameters.Add(new SqlParameter() { ParameterName = "@OrderId", SqlDbType = SqlDbType.VarChar, Size = 50, Value = conditionDict["OrderId"].ToString() });
                }
                sql += where.ToString();
                sql += " order by LineID asc";
                using (SqlDataReader sqlDataReader = helper.GetIDataReader(sql, (parameters as List<IDbDataParameter>).ToArray()) as SqlDataReader)
                {
                    var list = DataReaderHelper.ExecuteToEntity<SaleOrderPre>(sqlDataReader);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderSendNumberOrder.GetSearchSaleOrderSend",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        public IList<SaleOrderSendNumberLine> GetSaleOrderSendNumberLineList(string WID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberOrderList", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = new SqlParameter[] { 
                    new SqlParameter("@WID", SqlDbType.Int)
                };
                sp[0].Value = int.Parse(WID);
                using (SqlDataReader sqlDataReader = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    var list = DataReaderHelper.ExecuteToList<SaleOrderSendNumberLine>(sqlDataReader);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberOrderList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        public IList<SaleOrderSendNumberShop> GetSaleOrderSendNumberShopList(string WID, int LineID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberShopList", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = new SqlParameter[] { 
                     new SqlParameter("@WID", SqlDbType.Int),
                     new SqlParameter("@LineID", SqlDbType.Int)
                };
                sp[0].Value = int.Parse(WID);
                sp[1].Value = LineID;
                using (SqlDataReader sqlDataReader = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    var list = DataReaderHelper.ExecuteToList<SaleOrderSendNumberShop>(sqlDataReader);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberOrderShopList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        public int? GetSaleOrderSendNumberLineOrderMax(string WID, int LineID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int? model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberLineOrderMax", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@LineID", SqlDbType.Int)
                };
                sp[0].Value = int.Parse(WID);
                sp[1].Value = LineID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    //model = DataReaderHelper.ExecuteToEntity<int>(sdr);
                    if(helper.GetSingle(sql, sp) ==null)
                    {
                        model = int.Parse(helper.GetSingle(sql, sp).ToString());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberLineOrderMax",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }

        public int? GetSaleOrderSendNumberLineOrderMin(string WID, int LineID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int? model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberLineOrderMin", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@LineID", SqlDbType.Int)
                };
                sp[0].Value = int.Parse(WID);
                sp[1].Value = LineID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    //model = DataReaderHelper.ExecuteToEntity<int>(sdr);
                    if(helper.GetSingle(sql, sp) !=null)
                    {
                        model = int.Parse(helper.GetSingle(sql, sp).ToString());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberLineOrderMin",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }

        public int? GetSaleOrderSendNumberLinesOrderMax(string WID, int LineID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int? model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberLinesOrderMax", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@LineID", SqlDbType.Int)
                };
                sp[0].Value = int.Parse(WID);
                sp[1].Value = LineID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    //model = DataReaderHelper.ExecuteToEntity<int>(sdr);
                    if(helper.GetSingle(sql, sp) !=null)
                    {
                        model = int.Parse(helper.GetSingle(sql, sp).ToString());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberLinesOrderMax",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }

        public int? GetSaleOrderSendNumberLinesOrderMin(string WID, int LineID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int? model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberLinesOrderMin", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@LineID", SqlDbType.Int)
                };
                sp[0].Value = int.Parse(WID);
                sp[1].Value = LineID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    //model = DataReaderHelper.ExecuteToEntity<int>(sdr);
                    if(helper.GetSingle(sql, sp) !=null)
                    {
                        model = int.Parse(helper.GetSingle(sql, sp).ToString());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberLinesOrderMin",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }

        public int ChangeSaleOrderSendNumberLineOrder(string WID, int LineID, int LineSerialNumber)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ChangeSaleOrderSendNumberLineOrder", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                new SqlParameter("@WID", SqlDbType.Int),
                new SqlParameter("@LineID", SqlDbType.Int),
                new SqlParameter("@LineSerialNumber", SqlDbType.Int)
            };
            sp[0].Value = int.Parse(WID);
            sp[1].Value = LineID;
            sp[2].Value = LineSerialNumber;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.ChangeSaleOrderSendNumberLineOrder",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }

        public int? GetSaleOrderSendNumberShopOrder(string WID, int LineID, string OrderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int? model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberShopOrder", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@LineID", SqlDbType.Int),
                    new SqlParameter("@OrderId", SqlDbType.VarChar),
                };
                sp[0].Value = int.Parse(WID);
                sp[1].Value = LineID;
                sp[2].Value = OrderId;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    //model = DataReaderHelper.ExecuteToEntity<int>(sdr);
                    if(helper.GetSingle(sql, sp) !=null)
                    {
                        model = int.Parse(helper.GetSingle(sql, sp).ToString());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberShopOrder",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }

        /// <summary>
        /// 读取 选中某仓库下 选中某送货路线 下 所有订单中 门店送货排序的最大值
        /// </summary>
        /// <param name="WID">仓库编号</param>
        /// <param name="LineID">路线编号</param>
        /// <param name="OrderId">订单编号（用来确定门店）多余的传递参数</param>
        /// <returns>某仓库下某送货路线包含门店排序最大值</returns>
        public int? GetSaleOrderSendNumberShopsOrderMax(string WID, int LineID, string OrderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int? model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberShopsOrderMax", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@LineID", SqlDbType.Int)
                };
                sp[0].Value = int.Parse(WID);
                sp[1].Value = LineID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    //model = DataReaderHelper.ExecuteToEntity<int>(sdr);
                    if (helper.GetSingle(sql, sp) !=null)
                    {
                        model = int.Parse(helper.GetSingle(sql, sp).ToString());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberShopsOrderMax",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }


        /// <summary>
        /// 读取 选中仓库下 选中送货路线 下 所有订单中 门店送货排序的最小值
        /// </summary>
        /// <param name="WID">仓库编号</param>
        /// <param name="LineID">路线编号</param>
        /// <param name="OrderId"> 订单编号（用来确定门店）多余的传递参数</param>
        /// <returns>某门店某仓库下某送货路线包含门店排序最小值</returns>
        public int? GetSaleOrderSendNumberShopsOrderMin(string WID, int LineID, string OrderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int? model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetSaleOrderSendNumberShopsOrderMin", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@LineID", SqlDbType.Int)
                };
                sp[0].Value = int.Parse(WID);
                sp[1].Value = LineID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    //model = DataReaderHelper.ExecuteToEntity<int>(sdr);
                    if (helper.GetSingle(sql, sp) != null)
                    {
                        model = int.Parse(helper.GetSingle(sql, sp).ToString());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.GetSaleOrderSendNumberShopsOrderMin",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }

        public int ChangeSaleOrderSendNumberShopOrder(string WID, int LineID, string OrderId, int ShopSerialNumber)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ChangeSaleOrderSendNumberShopOrder", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                new SqlParameter("@WID", SqlDbType.Int),
                new SqlParameter("@LineID", SqlDbType.Int),
                new SqlParameter("@OrderId", SqlDbType.VarChar),
                new SqlParameter("@ShopSerialNumber", SqlDbType.Int)
            };
            sp[0].Value = int.Parse(WID);
            sp[1].Value = LineID;
            sp[2].Value = OrderId;
            sp[3].Value = ShopSerialNumber;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.ChangeSaleOrderSendNumberShopOrder",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }

        //public int ChangeSaleOrderSendNumberLineOrderUp(string WID, int LineID)
        //{
        //    DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
        //    int result = 0;
        //    string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ChangeSaleOrderSendNumberLineOrderUp", base.AssemblyName, base.DatabaseName);

        //    SqlParameter[] sp = {
        //        new SqlParameter("@WID", SqlDbType.Int),
        //        new SqlParameter("@LineID", SqlDbType.Int)
        //    };
        //    sp[0].Value = int.Parse(WID);
        //    sp[1].Value = LineID;
        //    try
        //    {
        //        result = helper.ExecNonQuery(sql, sp);
        //    }
        //    catch (Exception ex)
        //    {
        //        string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
        //        Logger.GetInstance().DBOperatingLog
        //        (
        //        new NormalLog
        //        {
        //            LogSource = helper.DataSource,
        //            LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.ChangeSaleOrderSendNumberLineOrderUp",
        //            LogContent = exceptionSql,
        //            LogTime = DateTime.Now
        //        },
        //        ex
        //        );
        //        throw;
        //    }
        //    return result;
        //}

        //public int ChangeSaleOrderSendNumberLineOrderDown(string WID, int LineID)
        //{
        //    DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
        //    int result = 0;
        //    string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ChangeSaleOrderSendNumberLineOrderDown", base.AssemblyName, base.DatabaseName);

        //    SqlParameter[] sp = {
        //        new SqlParameter("@WID", SqlDbType.Int),
        //        new SqlParameter("@LineID", SqlDbType.Int)
        //    };
        //    sp[0].Value = int.Parse(WID);
        //    sp[1].Value = LineID;
        //    try
        //    {
        //        result = helper.ExecNonQuery(sql, sp);
        //    }
        //    catch (Exception ex)
        //    {
        //        string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
        //        Logger.GetInstance().DBOperatingLog
        //        (
        //        new NormalLog
        //        {
        //            LogSource = helper.DataSource,
        //            LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderSendNumberOrder.ChangeSaleOrderSendNumberLineOrderDown",
        //            LogContent = exceptionSql,
        //            LogTime = DateTime.Now
        //        },
        //        ex
        //        );
        //        throw;
        //    }
        //    return result;
        //}
    }
}
