﻿/*********************************************************
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
    /// 盘点商品列表查询 接口实现类
    /// </summary>
    public class WProductsAddedListForStockDAO : BaseDAL, IWProductsAddedListDAO
    {
        /// <summary>
        /// 读取SQL配置文件节点Name名称
        /// </summary>
        protected override string TableName { get { return "AddedProductsForStockQuery"; } }

        /// <summary>
        /// 
        /// </summary>
        public WProductsAddedListParams SearchParams { get; set; }

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
            this.sql = "WITH LIST AS (" + this.GetSQLScriptByTable("WProductsAddedForStockList");

            //构造SQL参数
            this.sqlParametersBuilder = new SqlParamrterBuilder();
            this.sqlParametersBuilder.Add("WID", this.SearchParams.WID);

            if (!string.IsNullOrWhiteSpace(this.SearchParams.ProductName))
            {
                sql += " AND P.ProductName like @ProductName";
                this.sqlParametersBuilder.Add("ProductName", "%" + this.SearchParams.ProductName + "%");
            }

            if (!string.IsNullOrWhiteSpace(this.SearchParams.SKU))
            {
                sql += " AND p.SKU LIKE @Sku";
                this.sqlParametersBuilder.Add("Sku", "%" + this.SearchParams.SKU + "%");
            }

            if (!string.IsNullOrWhiteSpace(this.SearchParams.BarCode))
            {
                sql += " AND p.ProductId IN (SELECT ProductID FROM ProductsBarCodes WHERE BarCode=@BarCode)";
                this.sqlParametersBuilder.Add("BarCode", this.SearchParams.BarCode);
            }

            if (this.SearchParams.CategoryId1.HasValue)
            {
                sql += " AND  bp.CategoryId1 = @CategoryId1";
                this.sqlParametersBuilder.Add("CategoryId1", this.SearchParams.CategoryId1);
            }

            if (this.SearchParams.CategoryId2.HasValue)
            {
                sql += " AND  bp.CategoryId2 = @CategoryId2";
                this.sqlParametersBuilder.Add("CategoryId2", this.SearchParams.CategoryId2);
            }

            if (this.SearchParams.CategoryId3.HasValue)
            {
                sql += " AND  bp.CategoryId3 = @CategoryId3";
                this.sqlParametersBuilder.Add("CategoryId3", this.SearchParams.CategoryId3);
            }

            if (this.SearchParams.AddedVendor.HasValue)//是否增加供应商
            {
                if (this.SearchParams.AddedVendor.Value == 1)
                {
                    sql += " AND  wp.VendorID is not null";
                }
                else
                {
                    sql += " AND  wp.VendorID is null";
                }
            }

            if (this.SearchParams.WStatus.HasValue)//商品状态
            {
                sql += " AND  wp.WStatus = @WStatus";
                this.sqlParametersBuilder.Add("WStatus", this.SearchParams.WStatus.Value);
            }

            if (!string.IsNullOrWhiteSpace(this.SearchParams.VendorName))//供应商
            {
                sql += " AND VendorName like @VendorName ";
                this.sqlParametersBuilder.Add("VendorName", "%" + this.SearchParams.VendorName.Trim() + "%");
            }

            sql += ")";

        }

        /// <summary>
        /// 统计数量
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.AddedProductForStockQueryDAO.GetCount",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<WProductsAddedListModel> GetList()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = this.sql + string.Format(" SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1}", (this.PageIndex - 1) * this.PageSize + 1, this.PageIndex * this.PageSize);
                using (IDataReader dataReader = helper.GetIDataReader(_sql, this.sqlParametersBuilder.ToSqlParameters()))
                {
                    return this.ExecuteTolist<WProductsAddedListModel>(dataReader);
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.AddedProductForStockQueryDAO.GetList",
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
