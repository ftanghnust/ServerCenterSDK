using Frxs.Erp.ServiceCenter.Order.IDAL.Order.Stock;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Platform.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Order.Stock
{
    public class StockMangerDAO : BaseDAL, IStockMangerDAO
    {
        #region 获取数据库连接
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>连接对象</returns>
        public IDbConnection GetConnection()
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            return helper.GetNewConnection();
        }
        #endregion

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public StockMangerDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public StockMangerDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        /// <summary>
        /// 增加一条批次入库操作
        /// </summary>
        public long AddStockFIFOIn(StockFIFOInModel model, IDbConnection conn, IDbTransaction tran)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockFIFOIn(");
            strSql.Append("BatchNO,WID,WCode,WName,SubWID,SubWName,ProductID,SKU,ProductName,StockQty,BillType,BillID,BillDetailID,Unit,Qty,TotalOutQty,Flag,VendorID,VendorCode,VendorName,InPrice,StockTime,ModifyTime)");
            strSql.Append(" values (");
            strSql.Append("@BatchNO,@WID,@WCode,@WName,@SubWID,@SubWName,@ProductID,@SKU,@ProductName,@StockQty,@BillType,@BillID,@BillDetailID,@Unit,@Qty,@TotalOutQty,@Flag,@VendorID,@VendorCode,@VendorName,@InPrice,@StockTime,@ModifyTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BatchNO", SqlDbType.VarChar,36),
					new SqlParameter("@WID", SqlDbType.Int,4),
					new SqlParameter("@WCode", SqlDbType.VarChar,32),
					new SqlParameter("@WName", SqlDbType.NVarChar,50),
					new SqlParameter("@SubWID", SqlDbType.Int,4),
					new SqlParameter("@SubWName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@SKU", SqlDbType.VarChar,32),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,100),
					new SqlParameter("@StockQty", SqlDbType.Decimal,9),
					new SqlParameter("@BillType", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.VarChar,36),
					new SqlParameter("@BillDetailID", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,32),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@TotalOutQty", SqlDbType.Decimal,9),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@VendorID", SqlDbType.Int,4),
					new SqlParameter("@VendorCode", SqlDbType.VarChar,32),
					new SqlParameter("@VendorName", SqlDbType.NVarChar,50),
					new SqlParameter("@InPrice", SqlDbType.Money,8),
					new SqlParameter("@StockTime", SqlDbType.DateTime),
					new SqlParameter("@ModifyTime", SqlDbType.DateTime)};
            parameters[0].Value = model.BatchNO;
            parameters[1].Value = model.WID;
            parameters[2].Value = model.WCode;
            parameters[3].Value = model.WName;
            parameters[4].Value = model.SubWID;
            parameters[5].Value = model.SubWName;
            parameters[6].Value = model.ProductID;
            parameters[7].Value = model.SKU;
            parameters[8].Value = model.ProductName;
            parameters[9].Value = model.StockQty;
            parameters[10].Value = model.BillType;
            parameters[11].Value = model.BillID;
            parameters[12].Value = model.BillDetailID;
            parameters[13].Value = model.Unit;
            parameters[14].Value = model.Qty;
            parameters[15].Value = model.TotalOutQty;
            parameters[16].Value = model.Flag;
            parameters[17].Value = model.VendorID;
            parameters[18].Value = model.VendorCode;
            parameters[19].Value = model.VendorName;
            parameters[20].Value = model.InPrice;
            parameters[21].Value = model.StockTime;
            parameters[22].Value = model.ModifyTime;
            int rows = DBHelper.GetInstance(base.ConnectionString).ExecNonQuery(conn, tran, strSql.ToString(), parameters);
            model.InID = rows;
            return rows;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long AddStockFIFOOut(StockFIFOOutModel model, IDbConnection conn, IDbTransaction tran)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockFIFOOut(");
            strSql.Append("InID,WID,SubWID,ProductID,StockQty,BillType,BillID,BillDetailID,OutQty,VendorID,StockTime)");
            strSql.Append(" values (");
            strSql.Append("@InID,@WID,@SubWID,@ProductID,@StockQty,@BillType,@BillID,@BillDetailID,@OutQty,@VendorID,@StockTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@InID", SqlDbType.BigInt,8),
					new SqlParameter("@WID", SqlDbType.Int,4),
					new SqlParameter("@SubWID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@StockQty", SqlDbType.Decimal,9),
					new SqlParameter("@BillType", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.VarChar,36),
					new SqlParameter("@BillDetailID", SqlDbType.VarChar,50),
					new SqlParameter("@OutQty", SqlDbType.Decimal,9),
					new SqlParameter("@VendorID", SqlDbType.Int,4),
					new SqlParameter("@StockTime", SqlDbType.DateTime)};
            parameters[0].Value = model.InID;
            parameters[1].Value = model.WID;
            parameters[2].Value = model.SubWID;
            parameters[3].Value = model.ProductID;
            parameters[4].Value = model.StockQty;
            parameters[5].Value = model.BillType;
            parameters[6].Value = model.BillID;
            parameters[7].Value = model.BillDetailID;
            parameters[8].Value = model.OutQty;
            parameters[9].Value = model.VendorID;
            parameters[10].Value = model.StockTime;

            int rows = DBHelper.GetInstance(base.ConnectionString).ExecNonQuery(conn, tran, strSql.ToString(), parameters);
            model.OutID = rows;
            return rows;
        }

        /// <summary>
        /// 查询批次库存信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<StockFIFOInModel> QueryStockFIFOInList(QueryStockFIFOInModel model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  StockFIFOIn where Flag=0 ");
            IList<SqlParameter> lisP = new List<SqlParameter>();

            if (model.ProductID != null && ((int)model.ProductID) > 0)
            {
                strSql.Append(" and ProductID=@ProductID");
                lisP.Add(new SqlParameter("@ProductID", SqlDbType.Int, 4) { Value = (int)model.ProductID });
            }
            if (!string.IsNullOrWhiteSpace(model.SKU))
            {
                strSql.Append(" and SKU=@SKU");
                lisP.Add(new SqlParameter("@SKU", SqlDbType.VarChar, 32) { Value = model.SKU });
            }
            if (((int)model.WID) > 0)
            {
                strSql.Append(" and WID=@WID");
                lisP.Add(new SqlParameter("@WID", SqlDbType.Int, 4) { Value = (int)model.WID });
            }
            if (((int)model.SubWID) > 0)
            {
                strSql.Append(" and SubWID=@SubWID");
                lisP.Add(new SqlParameter("@SubWID", SqlDbType.Int, 4) { Value = (int)model.SubWID });
            }
            //if (((int)model.Flag) > 0)
            //{
            //    strSql.Append(" and Flag=@Flag");
            //    lisP.Add(new SqlParameter("@Flag", SqlDbType.Int, 4) { Value = (int)model.Flag });
            //}
            SqlParameter[] parameters = {
					new SqlParameter("@WID", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@SubWID", SqlDbType.Int,4),
                    //new SqlParameter("@Flag", SqlDbType.Int,4),
				};
            parameters[0].Value = model.WID;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.SubWID;
            //parameters[3].Value = model.Flag;
            strSql.Append(" order by StockTime asc ");

            DataSet ds = null;
            if (conn != null && tran != null)
            {
                ds = DBHelper.GetInstance(base.ConnectionString).GetDataSet(conn, tran, strSql.ToString(), parameters);
            }
            else
            {
                ds = DBHelper.GetInstance(base.ConnectionString).GetDataSet(strSql.ToString(), parameters);
            }

            IList<StockFIFOInModel> list = new List<StockFIFOInModel>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModelStockFIFOIn(dr));
                }
            }
            ds = null;
            return list;
        }

        /// <summary>
        /// 增加更新一条批次入库信息
        /// </summary>
        public bool UpdateStockFIFOIn(StockFIFOInModel model, IDbConnection conn, IDbTransaction tran)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockFIFOIn set ");
            strSql.Append("BatchNO=@BatchNO,");
            strSql.Append("WID=@WID,");
            strSql.Append("WCode=@WCode,");
            strSql.Append("WName=@WName,");
            strSql.Append("SubWID=@SubWID,");
            strSql.Append("SubWName=@SubWName,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("SKU=@SKU,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("StockQty=@StockQty,");
            strSql.Append("BillType=@BillType,");
            strSql.Append("BillID=@BillID,");
            strSql.Append("BillDetailID=@BillDetailID,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("TotalOutQty=@TotalOutQty,");
            strSql.Append("Flag=@Flag,");
            strSql.Append("VendorID=@VendorID,");
            strSql.Append("VendorCode=@VendorCode,");
            strSql.Append("VendorName=@VendorName,");
            strSql.Append("InPrice=@InPrice,");
            strSql.Append("StockTime=@StockTime,");
            strSql.Append("ModifyTime=@ModifyTime");
            strSql.Append(" where InID=@InID");
            SqlParameter[] parameters = {
					new SqlParameter("@BatchNO", SqlDbType.VarChar,36),
					new SqlParameter("@WID", SqlDbType.Int,4),
					new SqlParameter("@WCode", SqlDbType.VarChar,32),
					new SqlParameter("@WName", SqlDbType.NVarChar,50),
					new SqlParameter("@SubWID", SqlDbType.Int,4),
					new SqlParameter("@SubWName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@SKU", SqlDbType.VarChar,32),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,100),
					new SqlParameter("@StockQty", SqlDbType.Decimal,9),
					new SqlParameter("@BillType", SqlDbType.Int,4),
					new SqlParameter("@BillID", SqlDbType.VarChar,36),
					new SqlParameter("@BillDetailID", SqlDbType.VarChar,50),
					new SqlParameter("@Unit", SqlDbType.VarChar,32),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@TotalOutQty", SqlDbType.Decimal,9),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@VendorID", SqlDbType.Int,4),
					new SqlParameter("@VendorCode", SqlDbType.VarChar,32),
					new SqlParameter("@VendorName", SqlDbType.NVarChar,50),
					new SqlParameter("@InPrice", SqlDbType.Money,8),
					new SqlParameter("@StockTime", SqlDbType.DateTime),
					new SqlParameter("@ModifyTime", SqlDbType.DateTime),
					new SqlParameter("@InID", SqlDbType.Int,4)};
            parameters[0].Value = model.BatchNO;
            parameters[1].Value = model.WID;
            parameters[2].Value = model.WCode;
            parameters[3].Value = model.WName;
            parameters[4].Value = model.SubWID;
            parameters[5].Value = model.SubWName;
            parameters[6].Value = model.ProductID;
            parameters[7].Value = model.SKU;
            parameters[8].Value = model.ProductName;
            parameters[9].Value = model.StockQty;
            parameters[10].Value = model.BillType;
            parameters[11].Value = model.BillID;
            parameters[12].Value = model.BillDetailID;
            parameters[13].Value = model.Unit;
            parameters[14].Value = model.Qty;
            parameters[15].Value = model.TotalOutQty;
            parameters[16].Value = model.Flag;
            parameters[17].Value = model.VendorID;
            parameters[18].Value = model.VendorCode;
            parameters[19].Value = model.VendorName;
            parameters[20].Value = model.InPrice;
            parameters[21].Value = model.StockTime;
            parameters[22].Value = model.ModifyTime;
            parameters[23].Value = model.InID;

            int rows = DBHelper.GetInstance(base.ConnectionString).ExecNonQuery(conn, tran, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 增加一条数据库存信息
        /// </summary>
        public int AddStockQty(StockQtyModel model, IDbConnection conn, IDbTransaction tran)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("insert into StockQty(");
            strSql.Append("WID,ProductId,SKU,ProductName,WProductID,SubWID,StockQty,SaleTranQty,BuyTranQty,UpdateStockTime,LastCheckQty,LastCheckTime,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName)");
            strSql.Append(" values (");
            strSql.Append("@WID,@ProductId,@SKU,@ProductName,@WProductID,@SubWID,@StockQty,@SaleTranQty,@BuyTranQty,@UpdateStockTime,@LastCheckQty,@LastCheckTime,@CreateTime,@CreateUserID,@CreateUserName,@ModifyTime,@ModifyUserID,@ModifyUserName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@WID", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@SKU", SqlDbType.VarChar,32),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
					new SqlParameter("@WProductID", SqlDbType.BigInt,8),
					new SqlParameter("@SubWID", SqlDbType.Int,4),
					new SqlParameter("@StockQty", SqlDbType.Decimal,9),
					new SqlParameter("@SaleTranQty", SqlDbType.Decimal,9),
					new SqlParameter("@BuyTranQty", SqlDbType.Decimal,9),
					new SqlParameter("@UpdateStockTime", SqlDbType.DateTime),
					new SqlParameter("@LastCheckQty", SqlDbType.Decimal,9),
					new SqlParameter("@LastCheckTime", SqlDbType.DateTime),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateUserName", SqlDbType.VarChar,32),
					new SqlParameter("@ModifyTime", SqlDbType.DateTime),
					new SqlParameter("@ModifyUserID", SqlDbType.Int,4),
					new SqlParameter("@ModifyUserName", SqlDbType.VarChar,32)};
            parameters[0].Value = model.WID;
            parameters[1].Value = model.ProductId;
            parameters[2].Value = model.SKU;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.WProductID;
            parameters[5].Value = model.SubWID;
            parameters[6].Value = model.StockQty;
            parameters[7].Value = model.SaleTranQty;
            parameters[8].Value = model.BuyTranQty;
            parameters[9].Value = model.UpdateStockTime;
            parameters[10].Value = model.LastCheckQty;
            parameters[11].Value = model.LastCheckTime;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.CreateUserID;
            parameters[14].Value = model.CreateUserName;
            parameters[15].Value = model.ModifyTime;
            parameters[16].Value = model.ModifyUserID;
            parameters[17].Value = model.ModifyUserName;

            int rows = DBHelper.GetInstance(base.ConnectionString).ExecNonQuery(conn, tran, strSql.ToString(), parameters);
            model.ID = rows;
            return rows;
        }


        /// <summary>
        /// 查询商品库存信息
        /// </summary>
        /// <param name="qmod"></param>
        /// <returns></returns>
        public IList<StockQtyModel> QueryStockQtyList(StockQtyQueryModel model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  StockQty where 1=1 ");
            IList<SqlParameter> lisP = new List<SqlParameter>();
            if (model.ID != null && ((int)model.ID) > 0)
            {
                strSql.Append(" and ID=@ID");
                lisP.Add(new SqlParameter("@ID", SqlDbType.Int, 4) { Value = (int)model.ID });
            }
            if (model.ProductId != null && ((int)model.ProductId) > 0)
            {
                strSql.Append(" and ProductId=@ProductId");
                lisP.Add(new SqlParameter("@ProductId", SqlDbType.Int, 4) { Value = (int)model.ProductId });
            }
            if (model.WID != null && ((int)model.WID) > 0)
            {
                strSql.Append(" and WID=@WID");
                lisP.Add(new SqlParameter("@WID", SqlDbType.Int, 4) { Value = (int)model.WID });
            }
            if (model.SubWID != null && ((int)model.SubWID) > 0)
            {
                strSql.Append(" and SubWID=@SubWID");
                lisP.Add(new SqlParameter("@SubWID", SqlDbType.Int, 4) { Value = (int)model.SubWID });
            }

            if (model.ProductList != null && model.ProductList.Count > 0)
            {
                #region 增加商品ID列表批量查询
                StringBuilder pdisSb = new StringBuilder();
                int i = 0;
                foreach (int id in model.ProductList)
                {
                    if (i == 0)
                    {
                        pdisSb.AppendFormat("{0}", id);
                    }
                    else
                    {
                        pdisSb.AppendFormat(",{0}", id);
                    }
                    i++;
                }
                #endregion
                strSql.AppendFormat(" and ProductId in({0})", pdisSb.ToString());
            }
            SqlParameter[] parameters = {
					new SqlParameter("@WID", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@WProductID", SqlDbType.BigInt,8),
					new SqlParameter("@SubWID", SqlDbType.Int,4),
				};
            parameters[0].Value = model.WID;
            parameters[1].Value = model.ProductId;
            parameters[2].Value = model.WProductID;
            parameters[3].Value = model.SubWID;
            DataSet ds = null;
            if (conn != null && tran != null)
            {
                ds = DBHelper.GetInstance(base.ConnectionString).GetDataSet(conn, tran, strSql.ToString(), parameters);
            }
            else
            {
                ds = DBHelper.GetInstance(base.ConnectionString).GetDataSet(strSql.ToString(), parameters);
            }
            IList<StockQtyModel> list = new List<StockQtyModel>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(DataRowToModelStockQty(dr));
                }
            }
            ds = null;
            return list;
        }


        /// <summary>
        /// 更新总部库存数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="changeType"></param>
        /// <param name="changeQty">如果是增加库存为正，减库存负</param>
        /// <param name="changeUserID"></param>
        /// <param name="changeUserName"></param>
        /// <returns></returns>
        public bool UpdateStockQty(int id, StockType changeType, decimal changeQty, int changeUserID, string changeUserName, IDbConnection conn, IDbTransaction tran)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockQty set ");
            List<SqlParameter> lisP = new List<SqlParameter>();
            switch (changeType)
            {
                case StockType.StockQty:
                    strSql.Append("StockQty=StockQty+@StockQty,");
                    lisP.Add(new SqlParameter("@StockQty", SqlDbType.Decimal, 9) { Value = changeQty });
                    break;
            }
            strSql.Append("ModifyTime=@ModifyTime,");
            strSql.Append("ModifyUserID=@ModifyUserID,");
            strSql.Append("ModifyUserName=@ModifyUserName");
            strSql.Append(" where ID=@ID ");

            lisP.Add(new SqlParameter("@ModifyTime", SqlDbType.DateTime) { Value = DateTime.Now });
            lisP.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int, 4) { Value = changeUserID });
            lisP.Add(new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32) { Value = changeUserName });
            lisP.Add(new SqlParameter("@ID", SqlDbType.Int, 4) { Value = id });

            int rows = DBHelper.GetInstance(base.ConnectionString).ExecNonQuery(conn, tran, strSql.ToString(), lisP.ToArray());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个库存信息对象实体
        /// </summary>
        private StockQtyModel DataRowToModelStockQty(DataRow row)
        {
            StockQtyModel model = new StockQtyModel();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["WID"] != null && row["WID"].ToString() != "")
                {
                    model.WID = int.Parse(row["WID"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(row["ProductId"].ToString());
                }
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["WProductID"] != null && row["WProductID"].ToString() != "")
                {
                    model.WProductID = long.Parse(row["WProductID"].ToString());
                }
                if (row["SubWID"] != null && row["SubWID"].ToString() != "")
                {
                    model.SubWID = int.Parse(row["SubWID"].ToString());
                }
                if (row["StockQty"] != null && row["StockQty"].ToString() != "")
                {
                    model.StockQty = decimal.Parse(row["StockQty"].ToString());
                }
                if (row["SaleTranQty"] != null && row["SaleTranQty"].ToString() != "")
                {
                    model.SaleTranQty = decimal.Parse(row["SaleTranQty"].ToString());
                }
                if (row["BuyTranQty"] != null && row["BuyTranQty"].ToString() != "")
                {
                    model.BuyTranQty = decimal.Parse(row["BuyTranQty"].ToString());
                }
                if (row["UpdateStockTime"] != null && row["UpdateStockTime"].ToString() != "")
                {
                    model.UpdateStockTime = DateTime.Parse(row["UpdateStockTime"].ToString());
                }
                if (row["LastCheckQty"] != null && row["LastCheckQty"].ToString() != "")
                {
                    model.LastCheckQty = decimal.Parse(row["LastCheckQty"].ToString());
                }
                if (row["LastCheckTime"] != null && row["LastCheckTime"].ToString() != "")
                {
                    model.LastCheckTime = DateTime.Parse(row["LastCheckTime"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["CreateUserID"] != null && row["CreateUserID"].ToString() != "")
                {
                    model.CreateUserID = int.Parse(row["CreateUserID"].ToString());
                }
                if (row["CreateUserName"] != null)
                {
                    model.CreateUserName = row["CreateUserName"].ToString();
                }
                if (row["ModifyTime"] != null && row["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(row["ModifyTime"].ToString());
                }
                if (row["ModifyUserID"] != null && row["ModifyUserID"].ToString() != "")
                {
                    model.ModifyUserID = int.Parse(row["ModifyUserID"].ToString());
                }
                if (row["ModifyUserName"] != null)
                {
                    model.ModifyUserName = row["ModifyUserName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StockFIFOInModel DataRowToModelStockFIFOIn(DataRow row)
        {
            StockFIFOInModel model = new StockFIFOInModel();
            if (row != null)
            {
                if (row["InID"] != null && row["InID"].ToString() != "")
                {
                    model.InID = int.Parse(row["InID"].ToString());
                }
                if (row["BatchNO"] != null)
                {
                    model.BatchNO = row["BatchNO"].ToString();
                }
                if (row["WID"] != null && row["WID"].ToString() != "")
                {
                    model.WID = int.Parse(row["WID"].ToString());
                }
                if (row["WCode"] != null)
                {
                    model.WCode = row["WCode"].ToString();
                }
                if (row["WName"] != null)
                {
                    model.WName = row["WName"].ToString();
                }
                if (row["SubWID"] != null && row["SubWID"].ToString() != "")
                {
                    model.SubWID = int.Parse(row["SubWID"].ToString());
                }
                if (row["SubWName"] != null)
                {
                    model.SubWName = row["SubWName"].ToString();
                }
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(row["ProductID"].ToString());
                }
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["StockQty"] != null && row["StockQty"].ToString() != "")
                {
                    model.StockQty = decimal.Parse(row["StockQty"].ToString());
                }
                if (row["BillType"] != null && row["BillType"].ToString() != "")
                {
                    model.BillType = int.Parse(row["BillType"].ToString());
                }
                if (row["BillID"] != null)
                {
                    model.BillID = row["BillID"].ToString();
                }
                if (row["BillDetailID"] != null)
                {
                    model.BillDetailID = row["BillDetailID"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(row["Qty"].ToString());
                }
                if (row["TotalOutQty"] != null && row["TotalOutQty"].ToString() != "")
                {
                    model.TotalOutQty = decimal.Parse(row["TotalOutQty"].ToString());
                }
                if (row["Flag"] != null && row["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(row["Flag"].ToString());
                }
                if (row["VendorID"] != null && row["VendorID"].ToString() != "")
                {
                    model.VendorID = int.Parse(row["VendorID"].ToString());
                }
                if (row["VendorCode"] != null)
                {
                    model.VendorCode = row["VendorCode"].ToString();
                }
                if (row["VendorName"] != null)
                {
                    model.VendorName = row["VendorName"].ToString();
                }
                if (row["InPrice"] != null && row["InPrice"].ToString() != "")
                {
                    model.InPrice = decimal.Parse(row["InPrice"].ToString());
                }
                if (row["StockTime"] != null && row["StockTime"].ToString() != "")
                {
                    model.StockTime = DateTime.Parse(row["StockTime"].ToString());
                }
                if (row["ModifyTime"] != null && row["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(row["ModifyTime"].ToString());
                }
            }
            return model;
        }


    }
}
