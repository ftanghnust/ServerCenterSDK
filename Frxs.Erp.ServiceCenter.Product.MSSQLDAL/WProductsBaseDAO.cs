using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// 获取网仓商品信息列表（比较全）
    /// </summary>
    public class WProductsBaseDAO : BaseDAL, IWProductsBaseDAO
    {
        protected override string TableName
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 获取网仓商品信息列表（比较全）
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="pdList"></param>
        /// <returns></returns>
        public IList<WProductsBaseQueryModel> GetWProductsBaseList(int wid, IList<int> pdList)
        {
            DBHelper helper = DBHelper.GetInstance();

            try
            {
                StringBuilder strSql = new StringBuilder();
                SqlParameter[] parameters = null;
                string ids = "";
                for (int i = 0; i < pdList.Count; i++)
                {
                    if (i == 0)
                    {
                        ids = pdList[i].ToString();
                    }
                    else
                    {
                        ids += "," + pdList[i].ToString();
                    }
                }
                strSql.Append(@" SELECT ROW_NUMBER() OVER (ORDER BY P.ProductId DESC) AS RowNum,
                                    wp.ProductId,
                                    p.SKU,
                                    p.ProductName,
                                    wp.Unit,
                                    c.BarCode,
                                    wp.SalePrice,
                                    wpb.BuyPrice,
                                    bp.CategoryId1,c1.Name AS CategoryId1Name, 
                                    bp.CategoryId2,c2.Name AS CategoryId2Name, 
                                    bp.CategoryId3,c3.Name AS CategoryId3Name, 
                                    bp.ShopCategoryId1,s1.CategoryName AS ShopCategoryId1Name, 
                                    bp.ShopCategoryId2,s2.CategoryName AS ShopCategoryId2Name, 
                                    bp.ShopCategoryId3,s3.CategoryName AS ShopCategoryId3Name, 
                                    bp.BrandId1,b1.BrandName AS BrandId1Name,
                                    bp.BrandId2,b2.BrandName AS BrandId2Name
                                    FROM WProducts  wp
                                    INNER JOIN Products p ON wp.ProductId=p.ProductId
                                    INNER JOIN  BaseProducts bp ON wp.ProductId=bp.BaseProductId
                                    INNER JOIN WProductsBuy wpb ON wpb.WProductID=wp.WProductID
                                    LEFT JOIN ProductsBarCodes c on wp.ProductId=c.ProductId and c.SerialNumber=1 --(可改为函数)
                                    LEFT JOIN Categories c1 ON c1.CategoryId=bp.CategoryId1
                                    LEFT JOIN Categories c2 ON c2.CategoryId=bp.CategoryId1
                                    LEFT JOIN Categories c3 ON c3.CategoryId=bp.CategoryId1
                                    LEFT JOIN ShopCategories s1 ON s1.CategoryId=bp.ShopCategoryId1
                                    LEFT JOIN ShopCategories s2 ON s2.CategoryId=bp.ShopCategoryId2
                                    LEFT JOIN ShopCategories s3 ON s3.CategoryId=bp.ShopCategoryId3
                                    LEFT JOIN BrandCategories b1 ON b1.BrandId=bp.BrandId1
                                    LEFT JOIN BrandCategories b2 ON b2.BrandId=bp.BrandId2
                           WHERE wp.WStatus!=0 ");
                //strSql.Append(" and wp.ProductId in(" + ids + ")");
                strSql.Append(" and wp.WID=@WID ");
                parameters = new SqlParameter[]{
					new SqlParameter("@WID", SqlDbType.Int,4)};
                parameters[0].Value = wid;
                using (SqlDataReader dataReader = helper.GetIDataReader(strSql.ToString(), parameters) as SqlDataReader)
                {
                    // return this.ExecuteTolist<WProductsBaseQueryModel>(dataReader);
                    return DataReqderToModelList(dataReader);
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBaseDAO.GetWProductsBaseList",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }

        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IList<WProductsBaseQueryModel> DataReqderToModelList(SqlDataReader dataReader)
        {
            IList<WProductsBaseQueryModel> modelList = new List<WProductsBaseQueryModel>();
            WProductsBaseQueryModel model = null;

            if (dataReader != null && dataReader.FieldCount != 0)
            {
                while (dataReader.Read())
                {
                    model = new WProductsBaseQueryModel();
                    if (dataReader["ProductId"] != null && dataReader["ProductId"].ToString() != "")
                    {
                        model.ProductId = int.Parse(dataReader["ProductId"].ToString());
                    }
                    if (dataReader["SKU"] != null)
                    {
                        model.SKU = dataReader["SKU"].ToString();
                    }
                    if (dataReader["ProductName"] != null)
                    {
                        model.ProductName = dataReader["ProductName"].ToString();
                    }
                    if (dataReader["Unit"] != null)
                    {
                        model.Unit = dataReader["Unit"].ToString();
                    }
                    if (dataReader["BarCode"] != null)
                    {
                        model.BarCode = dataReader["BarCode"].ToString();
                    }
                    if (dataReader["SalePrice"] != null && dataReader["SalePrice"].ToString() != "")
                    {
                        model.SalePrice = decimal.Parse(dataReader["SalePrice"].ToString());
                    }
                    if (dataReader["BuyPrice"] != null && dataReader["BuyPrice"].ToString() != "")
                    {
                        model.BuyPrice = decimal.Parse(dataReader["BuyPrice"].ToString());
                    }
                    if (dataReader["CategoryId1"] != null && dataReader["CategoryId1"].ToString() != "")
                    {
                        model.CategoryId1 = int.Parse(dataReader["CategoryId1"].ToString());
                    }
                    if (dataReader["CategoryId1Name"] != null)
                    {
                        model.CategoryId1Name = dataReader["CategoryId1Name"].ToString();
                    }
                    if (dataReader["CategoryId2"] != null && dataReader["CategoryId2"].ToString() != "")
                    {
                        model.CategoryId2 = int.Parse(dataReader["CategoryId2"].ToString());
                    }
                    if (dataReader["CategoryId2Name"] != null)
                    {
                        model.CategoryId2Name = dataReader["CategoryId2Name"].ToString();
                    }
                    if (dataReader["CategoryId3"] != null && dataReader["CategoryId3"].ToString() != "")
                    {
                        model.CategoryId3 = int.Parse(dataReader["CategoryId3"].ToString());
                    }
                    if (dataReader["CategoryId3Name"] != null)
                    {
                        model.CategoryId3Name = dataReader["CategoryId3Name"].ToString();
                    }
                    if (dataReader["ShopCategoryId1"] != null && dataReader["ShopCategoryId1"].ToString() != "")
                    {
                        model.ShopCategoryId1 = int.Parse(dataReader["ShopCategoryId1"].ToString());
                    }
                    if (dataReader["ShopCategoryId1Name"] != null)
                    {
                        model.ShopCategoryId1Name = dataReader["ShopCategoryId1Name"].ToString();
                    }
                    if (dataReader["ShopCategoryId2"] != null && dataReader["ShopCategoryId2"].ToString() != "")
                    {
                        model.ShopCategoryId2 = int.Parse(dataReader["ShopCategoryId2"].ToString());
                    }
                    if (dataReader["ShopCategoryId2Name"] != null)
                    {
                        model.ShopCategoryId2Name = dataReader["ShopCategoryId2Name"].ToString();
                    }
                    if (dataReader["ShopCategoryId3"] != null && dataReader["ShopCategoryId3"].ToString() != "")
                    {
                        model.ShopCategoryId3 = int.Parse(dataReader["ShopCategoryId3"].ToString());
                    }
                    if (dataReader["ShopCategoryId3Name"] != null)
                    {
                        model.ShopCategoryId3Name = dataReader["ShopCategoryId3Name"].ToString();
                    }
                    if (dataReader["BrandId1"] != null && dataReader["BrandId1"].ToString() != "")
                    {
                        model.BrandId1 = int.Parse(dataReader["BrandId1"].ToString());
                    }
                    if (dataReader["BrandId1Name"] != null)
                    {
                        model.BrandId1Name = dataReader["BrandId1Name"].ToString();
                    }
                    if (dataReader["BrandId2"] != null && dataReader["BrandId2"].ToString() != "")
                    {
                        model.BrandId2 = int.Parse(dataReader["BrandId2"].ToString());
                    }
                    if (dataReader["BrandId2Name"] != null)
                    {
                        model.BrandId2Name = dataReader["BrandId2Name"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

    }
}
