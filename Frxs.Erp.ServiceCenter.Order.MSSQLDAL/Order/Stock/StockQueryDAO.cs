using Frxs.Erp.ServiceCenter.Order.IDAL.Order;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Order
{
    public class StockQueryDAO : BaseDAL, IStockQueryDAO
    {

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public StockQueryDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public StockQueryDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        /// <summary>
        /// 查询库存信息包括主库存、可用库存
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        public IList<StockSreachQtyModel> QueryStockQty(StockQtyQuery qmod)
        {
            //qmod.PDIDList = new List<int>();
            //qmod.PDIDList.Add(54);
            //qmod.PDIDList.Add(120);
            //qmod.PDIDList.Add(122);
            //qmod.WID = 101;
            //qmod.SubWID = 1010;
            #region 存储过程源码
            //            create procedure [dbo].[Proc_GetProductPreQty]( 
            //@ids VARCHAR(500),--输入的要拆分的字符串用户不为空的
            //@wid int,
            //@subwid int
            //)
            // AS 
            //declare  @str  varchar(500),@id  varchar(300),@m  int,@n  int , @tabname varchar(32)
            //declare @sql varchar(500)

            //set @tabname='TempTab_'+REPLACE(NEWID(),'-','');
            //set @sql='create table '+@tabname+'(tID int)' --把查询出来的数据存放 在这个表中
            //Exec (@sql);
            // if(@ids <>'')
            //set  @str=@ids    
            //set  @m=CHARINDEX('|',@str)  
            //set  @n=1   
            //WHILE  @m>0 
            //begin
            //  set  @id=substring(@str,@n,@m-@n)  
            //         if(@id <>'')
            //          BEGIN
            //          set @sql='insert into '+@tabname+'(tID)values('+@id+')' --把查询出来的数据存放 在这个表中
            //          Exec (@sql)
            //          end          
            //       set  @n=@m+1  
            //       set  @m=CHARINDEX('|',@str,@n)   
            //end	--on t.tID=s.ProductId
            //     set @sql='select t.tid,q.StockQty,k.preQty
            // from '+@tabname+' t left join (select ProductId ,sum(case when SaleQty>0 then SaleQty*SalePackingQty else PreQty*SalePackingQty end) as preQty from SaleOrderPreDetails s ,
            // dbo.SaleOrderPre m  where (m.OrderId=s.OrderID and  m.Status=4) and m.WID='+CONVERT(VARCHAR(50),@wid)+' and m.SubWID='+CONVERT(VARCHAR(50),@subwid)+'
            //group by ProductId ) k on t.tid=k.ProductId left join dbo.StockQty q on (t.tid=q.ProductId and q.WID='+CONVERT(VARCHAR(50),@wid)+' and q.SubWID='+CONVERT(VARCHAR(50),@subwid)+')
            //';
            //     Exec  (@sql)
            //     set @sql='drop table '+ @tabname
            //     Exec  (@sql)    

            //     exec [Proc_GetProductPreQty] '54|120|5455|',101,1010   --(m.Status=2 or m.Status=3 or m.Status=4)

            //现改成：被占用数量状态只为4（拣货完成的）
            #endregion

            DBHelper helper = DBHelper.GetInstance(base.ConnectionString); ;
            IList<StockSreachQtyModel> list = new List<StockSreachQtyModel>();
            if (qmod.PDIDList == null || qmod.PDIDList.Count == 0)
            {
                return list;
            }
            StringBuilder pdisSb = new StringBuilder();
            foreach (int id in qmod.PDIDList)
            {
                pdisSb.AppendFormat("{0}|", id);
            }
            try
            {
                string sql = "Proc_GetProductPreQty";
                SqlParameter[] sp = {
                                new SqlParameter("@ids", SqlDbType.VarChar),
                                new SqlParameter("@wid", SqlDbType.Int),
                                new SqlParameter("@subwid", SqlDbType.Int)
                                    };

                sp[0].Value = pdisSb.ToString();
                sp[1].Value = qmod.WID;
                sp[2].Value = qmod.SubWID;

                DataSet ds = helper.GetDataSet(sql, sp, false);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new StockSreachQtyModel()
                        {
                            PID = int.Parse(dr["tid"].ToString()),
                            PreQty = (dr["preQty"] == null || dr["preQty"].ToString() == "") ? 0 : decimal.Parse(dr["preQty"].ToString()),
                            StockQty = (dr["StockQty"] == null || dr["StockQty"].ToString() == "") ? 0 : decimal.Parse(dr["StockQty"].ToString()),
                        });
                    }
                }
                ds = null;
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Order.QueryStockQty",
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
        /// 查询各仓库库存
        /// </summary>
        /// <param name="qmod"></param>
        /// <returns></returns>
        public IList<StockOQtyModel> QueryOStockQty(StockNQtyQuery qmod)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString); ;
            IList<StockOQtyModel> list = new List<StockOQtyModel>();
            if ((qmod.PDIDList == null || qmod.PDIDList.Count == 0) && (qmod.SKUList == null || qmod.SKUList.Count == 0))
            {
                //查询商品条件全部为空
                return list;
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("select WID,SubWID,ProductId,SKU,StockQty from StockQty where ");
            List<SqlParameter> spList = new List<SqlParameter>();
            if (qmod.WIDList != null && qmod.WIDList.Count > 0)
            {
                if (qmod.WIDList.Count == 1)
                {
                    sql.Append("WID=@WID");
                    spList.Add(new SqlParameter("@wid", SqlDbType.Int) { Value = qmod.WIDList[0] });
                }
            }
            StringBuilder pdisSb = new StringBuilder();
            if (qmod.PDIDList != null && qmod.PDIDList.Count > 0)
            {
                //按商品ID查询       
                #region
                int i = 0;
                foreach (int id in qmod.PDIDList)
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
                sql.AppendFormat(" and ProductId in({0})", pdisSb.ToString());
                #endregion
            }
            else if (qmod.SKUList != null && qmod.SKUList.Count > 0)
            {
                //按商品SKU查询         
                #region
                int i = 0;
                foreach (string sku in qmod.SKUList)
                {
                    if (i == 0)
                    {
                        pdisSb.AppendFormat("'{0}'", sku);
                    }
                    else
                    {
                        pdisSb.AppendFormat(",'{0}'", sku);
                    }
                    i++;
                }
                sql.AppendFormat(" and SKU in({0})", pdisSb.ToString());
                #endregion
            }
            try
            {
                #region 执行查询
                DataSet ds = helper.GetDataSet(sql.ToString(), spList.ToArray(), true);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new StockOQtyModel()
                        {
                            PID = int.Parse(dr["ProductId"].ToString()),
                            SubWID = int.Parse(dr["SubWID"].ToString()),
                            SKU = dr["SKU"].ToString(),
                            WID = int.Parse(dr["WID"].ToString()),
                            StockQty = (dr["StockQty"] == null || dr["StockQty"].ToString() == "") ? 0 : decimal.Parse(dr["StockQty"].ToString()),
                        });
                    }
                }
                ds = null;
                #endregion
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Order.QueryStockQty",
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
        /// 获取库存表中的当前仓库的最小日期（开档日） 如果没有开档日,将时间提前-1天
        /// </summary>
        /// <param name="wId">仓库编号 </param>
        /// <param name="subWId">子仓库编号 </param>
        /// <returns></returns>
        public DateTime GetStockQtyCreateMinDate(int wId, int subWId)
        {
            DateTime currentDt = DateTime.Now.AddDays(-1);
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT MIN(CreateTime) AS StockQtyCreateMinDate FROM dbo.StockQty " +
                       "WHERE 1=1 ");
            if (wId > 0)
            {
                sql.Append(" AND WID=@WID");
            }

            if (subWId > 0)
            {
                sql.Append(" AND SubWID=@SubWID");
            }

            SqlParameter[] sp =
                {
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@SubWID", SqlDbType.Int)
                };
            sp[0].Value = wId;
            sp[1].Value = subWId;

            try
            {
                #region 执行查询
                var result = helper.GetSingle(sql.ToString(), sp);
                if (result != null)
                {
                    DateTime.TryParse(result.ToString(), out currentDt);
                }
                #endregion
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Order.QueryStockQty.GetStockQtyCreateMinDate",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }

            return currentDt;


        }
    }
}
