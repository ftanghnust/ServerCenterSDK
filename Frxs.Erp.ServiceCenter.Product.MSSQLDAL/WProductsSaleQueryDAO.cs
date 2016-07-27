/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/9 9:38:13
 * *******************************************************/

using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Pager;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Frxs.Platform.Utility.Log;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// 
    /// </summary>
    public class WProductsSaleQueryDAO : BaseDAL, IWProductsSaleQueryDAO
    {
        /// <summary>
        /// 读取SQL配置文件节点Name名称
        /// </summary>
        protected override string TableName
        {
            get
            {
                return "WProductsSaleQuery";
            }
        }

        /// <summary>
        /// 查询参数
        /// </summary>
        public WProductsSaleQuerySearchParams SearchParams { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页显示
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private SqlParamrterBuilder sqlParametersBuilder = null;
        private string sql = string.Empty;

        /// <summary>
        /// 构造查询语句
        /// </summary>
        /// <returns></returns>
        private void BuildWhereSql()
        {
            //构造SQL语句
            this.sql = "WITH LIST AS (" + this.GetSQLScriptByTable("WProductsSaleQueryList");

            //构造SQL参数
            this.sqlParametersBuilder = new SqlParamrterBuilder();
            this.sqlParametersBuilder.Add("WID", this.SearchParams.WID);

            if (!string.IsNullOrWhiteSpace(this.SearchParams.ProductId))
            {
                sql += " AND p.ProductId like @ProductId";
                this.sqlParametersBuilder.Add("ProductId", this.SearchParams.ProductId + "%");
            }
            if (this.SearchParams.ProductIds != null && this.SearchParams.ProductIds.Count>0)
            {
                //增加多ID批量搜索功能
                string productIds = string.Join(",", this.SearchParams.ProductIds);
                sql += " AND p.ProductId  in (" + productIds + ")";
                //sql += " AND p.ProductId  in @ProductIds";
                //this.sqlParametersBuilder.Add("ProductIds", "(" + productIds + ")"); 
            }
            if (!string.IsNullOrWhiteSpace(this.SearchParams.SKU))
            {
                if (this.SearchParams.SKULikeSearch)
                {
                    if (this.SearchParams.SKU.Length >= 6)
                    {
                        sql += " AND p.SKU = @Sku";
                        this.sqlParametersBuilder.Add("Sku", this.SearchParams.SKU);
                    }
                    else
                    {
                        sql += " AND p.SKU LIKE @Sku";
                        this.sqlParametersBuilder.Add("Sku", "%" + this.SearchParams.SKU + "%");
                    }
                }
                else
                {
                    sql += " AND p.SKU=@Sku";
                    this.sqlParametersBuilder.Add("Sku", this.SearchParams.SKU);
                }
            }

            if (!string.IsNullOrWhiteSpace(this.SearchParams.ProductName))
            {
                sql += " AND P.ProductName like @ProductName";
                this.sqlParametersBuilder.Add("ProductName", "%" + this.SearchParams.ProductName + "%");
            }

            if (!string.IsNullOrWhiteSpace(this.SearchParams.BarCode))
            {
                sql += " AND p.ProductId IN (SELECT ProductID FROM ProductsBarCodes WHERE BarCode LIKE @BarCode)";
                this.sqlParametersBuilder.Add("BarCode", "%" + this.SearchParams.BarCode + "%");
            }

            if (this.SearchParams.SaleBackFlag.HasValue)
            {
                //可退
                if (this.SearchParams.SaleBackFlag.Value)
                {
                    sql += " AND wp.SaleBackFlag <>'0'";
                }
                    //不可退
                else
                {
                    sql += " AND wp.SaleBackFlag = 0";
                }
            }

            //是否查询所有状态-默认查询有限状态 也就是 WState=1
            if (!this.SearchParams.AllWState.HasValue || this.SearchParams.AllWState == false)
            {
                sql += " AND wp.WStatus = 1";
            }

            sql += ")";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = this.sql + " SELECT COUNT(*) FROM LIST ";
                return int.Parse(helper.GetSingle(_sql, this.sqlParametersBuilder.ToSqlParameters()).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductQueryDAO.GetCount",
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
        public IList<WProductsSaleQueryModel> GetList()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = this.sql + string.Format(" SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1}", (this.PageIndex - 1) * this.PageSize + 1, this.PageIndex * this.PageSize);
                using (IDataReader dataReader = helper.GetIDataReader(_sql, this.sqlParametersBuilder.ToSqlParameters()))
                {
                    return this.ExecuteTolist<WProductsSaleQueryModel>(dataReader);
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductQueryDAO.GetList",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }
    }
}
