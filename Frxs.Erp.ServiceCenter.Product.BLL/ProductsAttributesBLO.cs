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
    /// 商品规格属性查询功能
    /// </summary>
    public class ProductsAttributesBLO
    {
        /// <summary>
        /// √获取商品的所有属性信息
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static IList<ProductsAttributes> ProductsAttributesGet(int productId)
        {
            return DALFactory.GetLazyInstance<IProductsAttributesDAO>().ProductsAttributesGet(productId);
        }

        ///// <summary>
        ///// 获取母商品下面所有子商品的规格属性集合并集
        ///// </summary>
        ///// <param name="baseProductId"></param>
        ///// <returns></returns>
        //public static IList<ProductsAttributes> BaseProductsAttributesGet(int baseProductId)
        //{
        //    return LazyDAOObjectCreator.IBaseProductsDAOObj.BaseProductsAttributesGet(baseProductId);
        //}


        /// <summary>
        /// √删除商品属性规格信息(删除的时候是批量全部删除，在批量一次性录入进去的)
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="conn">连接数据库对象</param>
        /// <param name="trans">事务对象</param>
        public static void ProductsAttributesDelete(int productId, IDbConnection conn, IDbTransaction trans)
        {
            DALFactory.GetLazyInstance<IProductsAttributesDAO>().ProductsAttributesDelete(productId, conn, trans);
        }


        /// <summary>
        /// √添加商品属性规格信息；新增修改的时候，请先调用delete方法进行删除，然后添加进去
        /// </summary>
        /// <param name="attrs">规格属性列表</param>
        /// <param name="conn"> 连接数据库对象</param>
        /// <param name="trans">事务对象 </param>
        public static BackMessage<int> ProductsAttributesAdd(IEnumerable<ProductsAttributes> attrs, IDbConnection conn, IDbTransaction trans)
        {
            foreach (var attr in attrs)
            {
                attr.ModifyTime = DateTime.Now;
                DALFactory.GetLazyInstance<IProductsAttributesDAO>().Save(attr, conn, trans);
            }
            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "添加商品规格属性成功",
                Data = 0
            };
        }



        /// <summary>
        /// 构建规格属性冗余字段值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        public static void InitAttributeValuesStr(Products model, ICollection<ProductsAttributes> attrs)
        {
            if (attrs == null || attrs.Count <= 0)
            {
                model.MutAttributes = "";
                model.MutValues = "";
                return;
            }

            attrs = attrs.OrderBy(x => x.AttributeId).ToList();
            StringBuilder sbAttributeValues = new StringBuilder();
            StringBuilder sbAttributes = new StringBuilder();
            foreach (var productAttribute in attrs)
            {
                sbAttributeValues.Append(productAttribute.ValuesId + ",");
                sbAttributes.Append(productAttribute.AttributeId + ",");
            }
            if (sbAttributeValues.Length > 0)
            {
                var attributesStr = sbAttributes.ToString().Substring(0, sbAttributes.Length - 1);
                var attributeValuesStr = sbAttributeValues.ToString().Substring(0, sbAttributeValues.Length - 1);
                model.MutValues = attributeValuesStr;
                model.MutAttributes = attributesStr;
                return;
            }
            else
            {
                model.MutValues = "";
                model.MutAttributes = "";
                return;
            }
        }


        /// <summary>
        /// 商品管理里更新商品规格，注意此方法为，方法里面会启用事务
        /// ProductsAttributesDelete
        /// ProductsAttributesAdd
        /// ProductsAttributesPictureAddOrUpdate
        /// 三个方法的组合，具体流程为
        /// 1.先删除所有的规格属性，然后批量添加到新的规格属性到商品，然后设置新的商品规格属性图
        /// </summary>
        /// <param name="productId"> </param>
        /// <param name="attrs"></param>
        /// <param name="productAttributesPicture"></param>
        /// <param name="isMutiAttribute">是否多规模属性 </param>
        /// <returns></returns>
        public static BackMessage<int> ProductsAttributesUpdate(int productId, IEnumerable<ProductsAttributes> attrs, ProductsAttributesPicture productAttributesPicture, int isMutiAttribute)
        {
            //商品是否存在
            var product = ProductsBLO.ProductsGet(productId);
            if (product == null)
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Data = -1,
                    Message = "指定商品不存在"
                };
            }

            var baseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(product.BaseProductId, false);
            if (baseProduct == null)
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Data = -1,
                    Message = "找不到商品的母商品"
                };
            }
            baseProduct.IsMutiAttribute = isMutiAttribute;

            if (baseProduct.IsMutiAttribute == 1)
            {
                //判断传入数据包
                if (attrs == null || productAttributesPicture == null)
                {
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "参数attrs或者productAttributesPicture不能为null"
                    };
                }
            }
            else
            {
                attrs = null;
            }


            //定义一个数据库连接
            IDbConnection conn = DALFactory.GetLazyInstance<IProductsDAO>().GetConnection();
            conn.Open();
            //获取连接事务
            IDbTransaction trans = conn.BeginTransaction();
            try
            {
                /*************请注意：不能在事务中先删除属性图后再更新属性图，会造成死锁****************/
                if (baseProduct.IsMutiAttribute == 1)
                {
                    //删除属性
                    ProductsAttributesDelete(productId, conn, trans);
                    //添加属性
                    ProductsAttributesAdd(attrs, conn, trans);

                    //更新规格属性图
                    ProductsAttributesPictureBLO.ProductsAttributesPictureAddOrUpdate(productAttributesPicture, conn, trans);
                }
                else
                {
                    //删除属性
                    ProductsAttributesDelete(productId, conn, trans);
                    //删除属性图
                    ProductsAttributesPictureBLO.ProductsAttributesPictureDelete(productId, conn, trans);
                }

                //修改母商品
                BaseProductsBLO.Edit(baseProduct, conn, trans);

                //修改商品
                if (attrs != null)
                {
                    InitAttributeValuesStr(product, attrs.ToList());
                }
                else
                {
                    product.MutAttributes = "";
                    product.MutValues = "";
                }
                ProductsBLO.Edit(product, conn, trans);

                //提交
                trans.Commit();
                return new BackMessage<int>()
                {
                    IsSuccess = true,
                    Data = 1,
                    Message = "更新商品属性成功"
                };
            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                conn.Dispose();
            }
        }


    }
}
