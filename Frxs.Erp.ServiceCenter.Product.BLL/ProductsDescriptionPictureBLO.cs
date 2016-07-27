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
    /// 商品图片详情（图文详情中使用）
    /// </summary>
    public class ProductsDescriptionPictureBLO
    {

        /// <summary>
        /// √获取商品图文详情(挂靠在主商品上面，有多张，系统设置5张)
        /// </summary>
        /// <param name="baseProductId"></param>
        /// <returns></returns>
        public static IList<ProductsDescriptionPicture> ProductsDescriptionPictureGet(int baseProductId)
        {
            return DALFactory.GetLazyInstance<IProductsDescriptionPictureDAO>().ProductsDescriptionPictureGet(baseProductId);
        }



        ///// <summary>
        ///// √删除商品图文图片详情（全删除）
        ///// </summary>
        ///// <param name="baseProductId"></param>
        ///// <returns></returns>
        //public static BackMessage<int> ProductsDescriptionPictureDelete(int baseProductId)
        //{
        //    int result = DALFactory.GetLazyInstance<IProductsDescriptionPictureDAO>().ProductsDescriptionPictureDelete(baseProductId);
        //    return new BackMessage<int>()
        //    {
        //        IsSuccess = true,
        //        Message = "删除商品图文详情成功",
        //        Data = result
        //    };
        //}


        ///// <summary>
        ///// √更新新增商品图文详情(客户端自修改的时候，先调用删除，然后在调用新增)
        ///// </summary>
        ///// <param name="pics"></param>
        ///// <param name="conn"> </param>
        ///// <param name="trans"> </param>
        ///// <returns></returns>
        //public static BackMessage<int> ProductsDescriptionPictureAdd(IEnumerable<ProductsDescriptionPicture> pics, IDbConnection conn, IDbTransaction trans)
        //{
        //    foreach (var pic in pics)
        //    {
        //        pic.CreateTime = DateTime.Now;
        //        DALFactory.GetLazyInstance<IProductsDescriptionPictureDAO>().Save(pic, conn, trans);
        //    }
        //    return new BackMessage<int>()
        //    {
        //        IsSuccess = true,
        //        Message = "添加商品图文详情成功",
        //        Data = 0
        //    };
        //}

        /// <summary>
        /// 添加/修改主商品图文详情 (先删除商品图文详情,再添加商品图文详情)
        /// </summary>
        /// <param name="baseProductId">主商品ID</param>
        /// <param name="pics">图文详情</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>true or false</returns>
        public static BackMessage<int> AddProductsDescriptionPicture(int baseProductId, ICollection<ProductsDescriptionPicture> pics, IDbConnection conn, IDbTransaction trans)
        {
            int tmpcount = 0;
            DALFactory.GetLazyInstance<IProductsDescriptionPictureDAO>().Delete(new ProductsDescriptionPicture() { BaseProductId = baseProductId }, conn, trans);
            if (pics != null && pics.Count > 0)
            {
                int tmpOrder = 0;
                foreach (var productsDescriptionPicture in pics)
                {
                    tmpOrder++;
                    productsDescriptionPicture.BaseProductId = baseProductId;
                    productsDescriptionPicture.OrderNumber = tmpOrder;
                    tmpcount += DALFactory.GetLazyInstance<IProductsDescriptionPictureDAO>().Save(productsDescriptionPicture, conn, trans);
                }
            }
            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "编辑商品图片详情成功",
                Data = tmpcount
            };
        }
    }
}
