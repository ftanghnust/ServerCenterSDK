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
    /// <summary>
    /// 商品国际条码操作类
    /// </summary>
    public class ProductsBarCodesBLO
    {

        /// <summary>
        /// √删除国际条码(单条删除，无需事务)
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="barCode">国际条码号</param>
        /// <returns></returns>
        public static void ProductBarCodesDelete(int productId, string barCode)
        {
            DALFactory.GetLazyInstance<IProductsBarCodesDAO>().DeleteByProductIdAndBarCode(productId, barCode);
        }

        /// <summary>
        /// √获取商品国际条码
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static IList<ProductsBarCodes> ProductsBarCodesGet(int productId)
        {
            return DALFactory.GetLazyInstance<IProductsBarCodesDAO>().GetProductsBarCodes(productId);
        }

        /// <summary>
        /// √添加国际条码
        /// </summary>
        /// <param name="codes">国际条码信息</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns></returns>
        public static BackMessage<int> ProductBarCodesAdd(ProductsBarCodes codes, IDbConnection conn, IDbTransaction trans)
        {
            if (codes == null)
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "国际条码不能为空"
                };
            }
            if (string.IsNullOrWhiteSpace(codes.BarCode))
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "国际条码不能为空"
                };
            }

            ////已经存在国际条码了
            //if (DALFactory.GetLazyInstance<IProductsBarCodesDAO>().ProductsBarCodesIsExists(codes.ProductId, codes.BarCode))
            //{
            //    return new BackMessage<int>()
            //    {
            //        IsSuccess = false,
            //        Message = "国际条码已经存在"
            //    };
            //}

            codes.CreateTime = DateTime.Now;
            int result = DALFactory.GetLazyInstance<IProductsBarCodesDAO>().Save(codes, conn, trans);
            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "OK",
                Data = result
            };
        }

        /// <summary>
        /// 添加或删除条码（要求有事务处理,处理逻辑为先删除后添加）
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="codes">条码信息</param>
        /// <returns></returns>
        public static BackMessage<int> ProductBarCodesAddOrEdit(int productId, ICollection<ProductsBarCodes> codes)
        {
            var connection = DALFactory.GetLazyInstance<IAttributesDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                DALFactory.GetLazyInstance<IProductsBarCodesDAO>().DeleteByProductId(productId, connection, trans);

                foreach (var productsBarCodese in codes)
                {
                    productsBarCodese.ProductId = productId;
                    var data = ProductBarCodesAdd(productsBarCodese, connection, trans);
                    if (!data.IsSuccess)
                    {
                        trans.Rollback();
                        return data;
                    }
                }
                trans.Commit();
                return new BackMessage<int>()
                {
                    IsSuccess = true,
                    Message = "添加国际条码成功",
                    Data = 0
                };
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

    }
}
