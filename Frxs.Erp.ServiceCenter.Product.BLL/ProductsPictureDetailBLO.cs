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
    public class ProductsPictureDetailBLO
    {

        /// <summary>
        /// 获取商品的主图信息
        /// 这里有个逻辑
        /// 1.当商品ProductId=ImageProductId的时候，主图就是自己的
        /// 2.当商品ProductId!=ImageProductId的时候，主图是挂靠在别人上面的
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static IList<ProductsPictureDetail> ProductsPictureDetailsGet(int productId)
        {
            //1.检索出商品信息
            var product = ProductsBLO.ProductsGet(productId);
            //2.根据商品的ImageProductId获取到商品主图集合
            return DALFactory.GetLazyInstance<IProductsPictureDetailDAO>().ProductsPictureDetailsGet(product.ImageProductId);
        }

        /// <summary>
        /// √商品主图；调用新增的时候，需要调用删除方法，然后再调用新增
        /// </summary>
        /// <param name="pics"></param>
        /// <returns></returns>
        public static BackMessage<int> ProductsPictureDetailAdd(IEnumerable<ProductsPictureDetail> pics, IDbConnection conn, IDbTransaction trans)
        {
            int result = DALFactory.GetLazyInstance<IProductsPictureDetailDAO>().ProductsPictureDetailAdd(pics, conn, trans);
            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "新增成功",
                Data = result
            };
        }

        /// <summary>
        /// √商品主图删除(全部清空)
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static BackMessage<int> ProductsPictureDetailDelete(Products product, IDbConnection conn, IDbTransaction trans)
        {
            //1.获取商品详细
            //var product = LazyDAOObjectCreator.IProductsDAOObj.ProductGetByProductId(product);
            if (product == null)
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "商品信息不存在"
                };
            }

            //2.需要先判断下 Product里的ProductId是否和ImageProductId相等，如果不相等就不能删除
            if (product.ProductId != product.ImageProductId)
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "商品主图是引用的母商品图片，不能删除，修改请到母商品上修改商品主图"
                };
            }

            //2.删除是批量删除然后在新增
            var result = DALFactory.GetLazyInstance<IProductsPictureDetailDAO>().ProductsPictureDetailDelete(product.ProductId, conn, trans);

            return new BackMessage<int>()
            {
                IsSuccess = true,
                Data = result,
                Message = "删除成功"
            };
        }
    }
}
