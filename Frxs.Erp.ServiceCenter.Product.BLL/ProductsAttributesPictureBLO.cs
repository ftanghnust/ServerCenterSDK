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
    public class ProductsAttributesPictureBLO
    {

        /// <summary>
        /// 商品规格图片获取
        /// </summary>
        /// <param name="productId"></param>
        public static ProductsAttributesPicture ProductsAttributesPictureGet(int productId)
        {
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("ProductId", productId);
            return DALFactory.GetLazyInstance<IProductsAttributesPictureDAO>().GetModel(conditionDict);
        }


        /// <summary>
        /// √更新商品的规格图片，一个商品只有一个商品规格图片（注意是有且只有一个）
        /// /*************请注意：不能在事务中先删除属性图后再更新属性图，会造成死锁****************/
        /// </summary>
        /// <param name="productAttributesPicture"></param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        public static BackMessage<int> ProductsAttributesPictureAddOrUpdate(ProductsAttributesPicture productAttributesPicture, IDbConnection conn, IDbTransaction trans)
        {
            //提交的数据包为null
            if (productAttributesPicture == null)
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "商品规格属性图片不能为空"
                };
            }

            //是否存在了商品规格属性图
            var productAttributesPictureObj = DALFactory.GetLazyInstance<IProductsAttributesPictureDAO>().ProductsAttributesPictureGet(productAttributesPicture.ProductId);

            //添加
            if (productAttributesPictureObj == null)
            {
                DALFactory.GetLazyInstance<IProductsAttributesPictureDAO>().Save(productAttributesPicture, conn, trans);
            }
            //修改
            else
            {
                DALFactory.GetLazyInstance<IProductsAttributesPictureDAO>().Edit(productAttributesPicture, conn, trans);
            }

            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "更新商品规格属性图成功",
                Data = 0
            };
        }

        /// <summary>
        /// 删除商品规格属性图
        /// *************请注意：不能在事务中先删除属性图后再更新属性图，会造成死锁****************/
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static BackMessage<int> ProductsAttributesPictureDelete(int productId, IDbConnection conn, IDbTransaction trans)
        {
            ProductsAttributesPicture model = new ProductsAttributesPicture { ProductId = productId };
            var result = DALFactory.GetLazyInstance<IProductsAttributesPictureDAO>().Delete(model, conn, trans);
            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "删除商品规格属性图成功",
                Data = 0
            };
        }

    }
}
