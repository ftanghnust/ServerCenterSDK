using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    public class ProductVendorBLO
    {
        //    /// <summary>
        //    /// 添加商品供应商信息
        //    /// </summary>
        //    /// <param name="product">商品</param>
        //    /// <param name="vendor">商品供应商信息</param>
        //    public static BackMessage<int> AddProductVendor(Products product, ProductsVendor vendor)
        //    {
        //        var connection = LazyDAOObjectCreator.IAttributesDAOObj.GetConnection();
        //        connection.Open();
        //        var trans = connection.BeginTransaction();
        //        try
        //        {
        //            var basePrdouct = LazyDAOObjectCreator.IBaseProductsDAOObj.GetModel(product.BaseProductId, false);
        //            LazyDAOObjectCreator.IBaseProductsDAOObj.AddVendor(product.BaseProductId, vendor, connection, trans);
        //            trans.Commit();
        //            return new BackMessage<int>()
        //            {
        //                IsSuccess = true,
        //                Message = "编辑商品供应商信息成功",
        //                Data = 1
        //            };
        //        }
        //        catch (Exception)
        //        {
        //            trans.Rollback();
        //            throw;
        //        }
        //        finally
        //        {
        //            trans.Dispose();
        //            connection.Close();
        //            connection.Dispose();
        //        }
        //    }

        //    /// <summary>
        //    /// 删除商品供应商信息
        //    /// </summary>
        //    /// <param name="product">商品</param>
        //    /// <param name="vendor">商品供应商信息</param>
        //    public static BackMessage<int> DeleteProductVendor(Products product, ProductsVendor vendor)
        //    {
        //        var connection = LazyDAOObjectCreator.IAttributesDAOObj.GetConnection();
        //        connection.Open();
        //        var trans = connection.BeginTransaction();
        //        try
        //        {
        //            var basePrdouct = LazyDAOObjectCreator.IBaseProductsDAOObj.GetModel(product.BaseProductId, false);
        //            LazyDAOObjectCreator.IBaseProductsDAOObj.DeleteVendor(product.BaseProductId, vendor.VendorID, connection,
        //                                                                  trans);
        //            trans.Commit();
        //            return new BackMessage<int>()
        //            {
        //                IsSuccess = true,
        //                Message = "删除商品供应商信息成功",
        //                Data = 1
        //            };
        //        }
        //        catch (Exception)
        //        {
        //            trans.Rollback();
        //            throw;
        //        }
        //        finally
        //        {
        //            trans.Dispose();
        //            connection.Close();
        //            connection.Dispose();
        //        }
        //    }

        /// <summary>
        /// 获取母商品供应商列表
        /// </summary>
        /// <param name="baseProductId"></param>
        /// <returns></returns>
        public static IList<ProductsVendor> ProductsVendorsGet(int baseProductId)
        {
            Dictionary<string, object> conditionDict = new Dictionary<string, object> { { "BaseProductId", baseProductId } };
            return DALFactory.GetLazyInstance<IProductsVendorDAO>().GetList(conditionDict);
        }

        //    /// <summary>
        //    /// 删除商品供应商
        //    /// </summary>
        //    /// <param name="baseProductId">母商品ID</param>
        //    /// <returns></returns>
        //    public static BackMessage<int> ProductVendorDelete(int baseProductId, int? vendorId)
        //    {
        //        LazyDAOObjectCreator.IBaseProductsDAOObj.DeleteVendor(baseProductId, vendorId);
        //        return new BackMessage<int>()
        //        {
        //            IsSuccess = true,
        //            Message = "删除商品供应商成功",
        //            Data = 0
        //        };
        //    }


        ///// <summary>
        /////  删除母商品供应商
        ///// </summary>
        ///// <param name="baseProductId">母商品ID</param>
        ///// <param name="vendorId">供应商Id，如为null，删除母商品下所有供应商信息</param>
        ///// <returns>true or false</returns>
        //public static bool DeleteVendor(int baseProductId, int? vendorId, IDbConnection conn = null, IDbTransaction tran = null)
        //{
        //    return LazyDAOObjectCreator.IBaseProductsDAOObj.DeleteVendor(baseProductId, vendorId, conn, tran);
        //}
    }
}
