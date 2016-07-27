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
    /// 电商商品库查询
    /// </summary>
    public class ProductQueryDAO : BaseDAL, IProductQueryDAO
    {
        /// <summary>
        /// 读取SQL配置文件节点Name名称
        /// </summary>
        protected override string TableName
        {
            get
            {
                return "ProductsQuery";
            }
        }

        /// <summary>
        /// 查询参数
        /// </summary>
        public ProductQuerySearchParams SearchParams { get; set; }

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
            this.sql = " (" + this.GetSQLScriptByTable("ProductsQueryList");

            //构造SQL参数
            this.sqlParametersBuilder = new SqlParamrterBuilder();


            sql += " AND Products.IsDeleted=0 ";
            if (this.SearchParams != null)
            {
                //商品ID
                if (this.SearchParams.ProductIds != null && this.SearchParams.ProductIds.Count > 0)
                {
                    if (this.SearchParams.ProductIds.Count == 1)
                    {
                        sql += string.Format(" AND Products.ProductId={0}", this.SearchParams.ProductIds[0]); //优化下
                    }
                    else
                    {
                        sql += string.Format(" AND Products.ProductId IN({0})", string.Join(",", this.SearchParams.ProductIds.ToArray()));
                    }
                }

                //母商品信息
                if (this.SearchParams.BaseProductId.HasValue)
                {
                    sql += string.Format(" AND Products.BaseProductId={0}", this.SearchParams.BaseProductId.Value);
                }

                //子商品名称
                if (!string.IsNullOrWhiteSpace(this.SearchParams.ProductName))
                {
                    sql += " AND Products.ProductName LIKE @ProductName";
                    sqlParametersBuilder.Add("ProductName", SqlDbType.NVarChar, 100, "%" + this.SearchParams.ProductName + "%");
                }

                //子商品SKU ERP编码
                if (!string.IsNullOrWhiteSpace(this.SearchParams.Sku))
                {
                    sql += " AND Products.SKU LIKE @SKU";
                    sqlParametersBuilder.Add("SKU", SqlDbType.NVarChar, 10, "%" + this.SearchParams.Sku + "%");
                }

                //母商品名称
                if (!string.IsNullOrWhiteSpace(this.SearchParams.ProductBaseName))
                {
                    sql += " AND BaseProducts.ProductBaseName LIKE @ProductBaseName";
                    sqlParametersBuilder.Add("ProductBaseName", SqlDbType.NVarChar, 100, "%" + this.SearchParams.ProductBaseName + "%");
                }

                //国际条码(子查询到国际条码标)
                if (!string.IsNullOrWhiteSpace(this.SearchParams.BarCode))
                {
                    sql += " AND EXISTS(SELECT * FROM ProductsBarCodes WHERE ProductsBarCodes.ProductId=Products.ProductId AND ProductsBarCodes.BarCode LIKE @BarCode)";
                    sqlParametersBuilder.Add("BarCode", SqlDbType.NVarChar, 32, "%" + this.SearchParams.BarCode + "%");
                }

                ////ERPcode
                //if (!string.IsNullOrWhiteSpace(this.SearchParams.ErpCode))
                //{
                //    sql += " AND Products.ErpCode LIKE @ErpCode";
                //    sqlParametersBuilder.Add("ErpCode", SqlDbType.NVarChar, 32, "%" + this.SearchParams.ErpCode + "%");
                //}

                //商品分类1
                if (this.SearchParams.CategoriesID1.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.CategoryId1={0}", this.SearchParams.CategoriesID1.Value);
                }

                //商品分类2
                if (this.SearchParams.CategoriesID2.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.CategoryId2={0}", this.SearchParams.CategoriesID2.Value);
                }

                //商品分类3 
                if (this.SearchParams.CategoriesID3.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.CategoryId3={0}", this.SearchParams.CategoriesID3.Value);
                }

                //运营分类1
                if (this.SearchParams.ShopCategoriesID1.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.ShopCategoryId1={0}", this.SearchParams.ShopCategoriesID1.Value);
                }

                //运营分类2
                if (this.SearchParams.ShopCategoriesID2.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.ShopCategoryId2={0}", this.SearchParams.ShopCategoriesID2.Value);
                }


                //运营分类3
                if (this.SearchParams.ShopCategoriesID3.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.ShopCategoryId3={0}", this.SearchParams.ShopCategoriesID3.Value);
                }

                //品牌1
                if (this.SearchParams.BrandId1.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.BrandId1={0}", this.SearchParams.BrandId1.Value);
                }

                //品牌2
                if (this.SearchParams.BrandId2.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.BrandId2={0}", this.SearchParams.BrandId2.Value);
                }

                //品牌名称关键词
                if (!string.IsNullOrWhiteSpace(this.SearchParams.BrandName))
                {
                    sql += " AND  (BaseProducts.BrandId1 IN(SELECT BrandId FROM BrandCategories WHERE BrandName LIKE @BrandName) OR BaseProducts.BrandId2 IN(SELECT BrandId FROM BrandCategories WHERE BrandName LIKE @BrandName))";
                    sqlParametersBuilder.Add("BrandName", SqlDbType.NVarChar, 32, "%" + this.SearchParams.BrandName + "%");
                }

                //是否多属性规格
                if (this.SearchParams.IsMutiAttribute.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.IsMutiAttribute={0}", this.SearchParams.IsMutiAttribute.Value);
                }

                //是否母商品
                if (this.SearchParams.IsBaseProductId.HasValue)
                {
                    sql += string.Format(" AND BaseProducts.IsBaseProductId={0}", this.SearchParams.IsBaseProductId.Value);
                }

                ////是否第三方商品
                //if (this.SearchParams.IsVendor.HasValue)
                //{
                //    sql += string.Format(" AND BaseProducts.IsVendor={0}", this.SearchParams.IsVendor.Value);
                //}

                //仅查找母商品
                if (this.SearchParams.IsOnlyBaseProduct)
                {
                    sql += " AND Products.BaseProductId=Products.ProductId and BaseProducts.IsBaseProductId=1 ";
                }

                //规格属性名称
                if (!string.IsNullOrEmpty(this.SearchParams.MutAttributes))
                {
                    sql += " AND Products.MutAttributes=@MutAttributes";
                    sqlParametersBuilder.Add("MutAttributes", SqlDbType.NVarChar, 200, this.SearchParams.MutAttributes);
                }

                //商品状态
                if (this.SearchParams.Status.HasValue)
                {
                    sql += " AND Products.Status=@Status";
                    sqlParametersBuilder.Add("Status", SqlDbType.Int, this.SearchParams.Status.Value);
                }

                ////商品零售价区间
                //if (this.SearchParams.SalePrice1.HasValue && this.SearchParams.SalePrice2.HasValue && this.SearchParams.SalePrice2 > this.SearchParams.SalePrice1)
                //{
                //    sql += string.Format(" AND Products.SalePrice>={0} AND Products.SalePrice<={1} ", this.SearchParams.SalePrice1, this.SearchParams.SalePrice2);
                //}

                //主图图片库ID
                if (this.SearchParams.ImageProductId.HasValue)
                {
                    sql += string.Format(" AND Products.ImageProductId = {0}", this.SearchParams.ImageProductId);
                }
            }

            sql += ") AS LIST";
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
                string _sql = string.Format(" SELECT COUNT(*) FROM {0} ", this.sql);
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
        public IList<ProductQueryModel> GetList()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = string.Format(" SELECT * FROM {0} WHERE RowNum BETWEEN {1} AND {2}", this.sql, (this.PageIndex - 1) * this.PageSize + 1, this.PageIndex * this.PageSize);
                using (IDataReader dataReader = helper.GetIDataReader(_sql, this.sqlParametersBuilder.ToSqlParameters()))
                {
                    return this.ExecuteTolist<ProductQueryModel>(dataReader);
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<SimpleProduct> GetSimpleProductList()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = this.sql + string.Format(" SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1}", (this.PageIndex - 1) * this.PageSize + 1, this.PageIndex * this.PageSize);
                using (IDataReader dataReader = helper.GetIDataReader(_sql, this.sqlParametersBuilder.ToSqlParameters()))
                {
                    return this.ExecuteTolist<SimpleProduct>(dataReader);
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductQueryDAO.GetSimpleProductList",
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
