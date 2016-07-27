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
    /// 商品文字详情BLL类
    /// </summary>
    public class ProductsDescriptionBLO
    {

        /// <summary>
        /// √获取商品描述详情
        /// </summary>
        /// <param name="baseProductId">母商品编号</param>
        /// <returns>商品描述对象</returns>
        public static ProductsDescription ProductsDescriptionGet(int baseProductId)
        {
            return DALFactory.GetLazyInstance<IProductsDescriptionDAO>().GetModel(baseProductId);
        }


        /// <summary>
        /// √新增或者修改商品描述
        /// </summary>
        /// <param name="desc">商品描述对象</param>
        /// <param name="conn">数据库连接对象 </param>
        /// <param name="trans">事务处理 </param>
        /// <returns></returns>
        public static BackMessage<ProductsDescription> ProductsDescriptionAddOrUpdate(ProductsDescription desc, IDbConnection conn, IDbTransaction trans)
        {
            //默认当前时间
            desc.ModifyTime = DateTime.Now;
            if (string.IsNullOrWhiteSpace(desc.ModifyUserName))
            {
                return new BackMessage<ProductsDescription>()
                {
                    IsSuccess = false,
                    Message = "编辑用户必须填写"
                };
            }

            //获取商品描述
            bool isExist = DALFactory.GetLazyInstance<IProductsDescriptionDAO>().Exists(desc);
            //不存在，添加
            if (!isExist)
            {
                DALFactory.GetLazyInstance<IProductsDescriptionDAO>().Save(desc, conn, trans);
            }
            //存在修改
            else
            {
                DALFactory.GetLazyInstance<IProductsDescriptionDAO>().Edit(desc, conn, trans);
            }
            return new BackMessage<ProductsDescription>()
            {
                IsSuccess = true,
                Message = "OK",
                Data = desc
            };
        }


        /// <summary>
        /// 添加/修改主商品图片和文字详情
        /// </summary>
        /// <param name="baseProductId">主商品编号</param>
        /// <param name="desc">商品文字详情 </param>
        /// <param name="pics">商品图片详情</param>
        /// <returns>true or false</returns>
        public static BackMessage<int> AddProductsDescriptionAndPicture(int baseProductId, ProductsDescription desc, ICollection<ProductsDescriptionPicture> pics)
        {
            var connection = DALFactory.GetLazyInstance<IAttributesDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                var flagPics = ProductsDescriptionPictureBLO.AddProductsDescriptionPicture(baseProductId, pics, connection, trans);
                if (!flagPics.IsSuccess)
                {
                    trans.Rollback();
                    return flagPics;
                }

                var flagDesc = ProductsDescriptionAddOrUpdate(desc, connection, trans);
                if (!flagDesc.IsSuccess)
                {
                    trans.Rollback();
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = flagDesc.Message,
                        Data = 0
                    };
                }
                trans.Commit();
                return new BackMessage<int>()
                {
                    IsSuccess = true,
                    Message = "编辑商品图文详情成功",
                    Data = 1
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
