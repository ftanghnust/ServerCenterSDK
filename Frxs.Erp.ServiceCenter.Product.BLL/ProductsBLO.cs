using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 电商商品主表Products业务逻辑类
    /// </summary>
    public partial class ProductsBLO
    {
        #region 成员方法
        #region 根据主键验证Products是否存在
        /// <summary>
        /// 根据主键验证Products是否存在
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(Products model)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().Exists(model);
        }
        #endregion


        #region 更新一个Products

        /// <summary>
        /// 更新一个Products
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(Products model, IDbConnection conn = null, IDbTransaction trans = null)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().Edit(model, conn, trans);
        }
        #endregion


        #region 删除一个Products
        /// <summary>
        /// 删除一个Products
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(Products model)
        {
            //var data = ProductIsUsed(model.ProductId);
            //if (!data.IsSuccess)
            //{
            //    return 0;
            //}
            return DALFactory.GetLazyInstance<IProductsDAO>().Delete(model);
        }
        #endregion


        #region 根据字典获取Products对象
        /// <summary>
        /// 根据字典获取Products对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Products对象</returns>
        public static Products GetModel(Dictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().GetModel(conditionDict);
        }
        #endregion

        #region 根据主键获取Products对象
        /// <summary>
        /// 根据主键获取Products对象
        /// </summary>
        /// <param name="productId">商品ID(主键)SKUNumberService.ID取得</param>
        /// <returns>Products对象</returns>
        public static Products GetModel(int productId)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().GetModel(productId);
        }
        #endregion

        #region 根据字典获取Products集合
        /// <summary>
        /// 根据字典获取Products集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<Products> GetList(Dictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取Products数据集
        /// <summary>
        /// 根据字典获取Products数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(Dictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取Products集合

        /// <summary>
        /// 分页获取Products集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Products> GetPageList(PageListBySql<Products> page, Dictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().GetPageList(page, conditionDict);
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// 添加商品
    /// </summary>
    public partial class ProductsBLO
    {
        /// <summary>
        /// 商品是否被使用
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <returns></returns>
        public static BackMessage<int> ProductIsUsed(int productId)
        {
            //var flag = DALFactory.GetLazyInstance<IProductsDAO>().bUsedByWc(productId);
            //if (flag)
            //{
            //    return new BackMessage<int>()
            //    {
            //        IsSuccess = false,
            //        Message = "已被网仓引用"
            //    };
            //}
            //flag = DALFactory.GetLazyInstance<IProductsDAO>().bUsedBySupplier(productId);
            //if (flag)
            //{
            //    return new BackMessage<int>()
            //    {
            //        IsSuccess = false,
            //        Message = "已被门店引用"
            //    };
            //}
            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "OK"
            };
        }


        /// <summary>
        /// 批量删除商品
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static BackMessage<int> ProductsDelete(IList<Products> products)
        {
            var connection = DALFactory.GetLazyInstance<IAttributesDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var productse in products)
                {
                    var data = ProductIsUsed(productse.ProductId);
                    if (!data.IsSuccess)
                    {
                        trans.Rollback();
                        var product = ProductsGet(productse.ProductId);
                        return new BackMessage<int>()
                        {
                            IsSuccess = false,
                            Message = "商品" + product.ProductName + data.Message
                        };
                    }
                    DALFactory.GetLazyInstance<IProductsDAO>().Delete(productse, connection, trans);
                }
                trans.Commit();
                return new BackMessage<int>()
                {
                    IsSuccess = true,
                    Message = "OK"
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

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="baseProduct"></param>
        /// <param name="product"></param>
        /// <param name="productAttributes"></param>
        /// <param name="productsPictureDetail"></param>
        /// <param name="productAttributesPicture"></param>
        /// <param name="codes"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        public static BackMessage<int> ProductAdd(
            BaseProducts baseProduct,
            Products product,
            IList<ProductsAttributes> productAttributes,
            IList<ProductsPictureDetail> productsPictureDetail,
            ProductsAttributesPicture productAttributesPicture,
            IList<ProductsBarCodes> codes,
            IList<ProductsUnit> units
            )
        {


            if (string.IsNullOrEmpty(product.ProductName))
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "请输入商品名称"
                };
            }
            if (string.IsNullOrEmpty(product.SKU))
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "请输入商品编码"
                };
            }


            var connection = DALFactory.GetLazyInstance<IAttributesDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                int productId = CreateProductId();

                if (DALFactory.GetLazyInstance<IProductsDAO>().ExistName(product))
                {
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "商品名已被使用"
                    };
                }
                if (DALFactory.GetLazyInstance<IProductsDAO>().ExistERP(product))
                {
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "商品编码已被使用"
                    };
                }


                //BaseProductId为0时，新建一个母商品，否则，只是关联到原来的母商品
                if (baseProduct.BaseProductId == 0)
                {
                    baseProduct.BaseProductId = productId;
                    if (string.IsNullOrEmpty(baseProduct.ProductBaseName) && baseProduct.IsBaseProductId == 1)
                    {
                        return new BackMessage<int>()
                        {
                            IsSuccess = false,
                            Message = "母商品名称不能为空"
                        };
                    }
                    if (baseProduct.IsBaseProductId == 0)
                    {
                        baseProduct.ProductBaseName = "";
                    }

                    BackMessage<int> backmessgae = BaseProductsBLO.Save(baseProduct, connection, trans);
                    if (backmessgae.Data <= 0)
                    {
                        trans.Rollback();
                        return backmessgae;
                    }
                }



                product.BaseProductId = baseProduct.BaseProductId;
                product.ProductId = productId;

                //product.SKU = CreateSku(productId);

                if (baseProduct.IsMutiAttribute == 1)
                {
                    ProductsAttributesBLO.InitAttributeValuesStr(product, productAttributes);
                }

                if (product.ImageProductId <= 0)
                {
                    product.ImageProductId = productId;
                }
                if (DALFactory.GetLazyInstance<IProductsDAO>().Save(product, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "保存商品信息失败"
                    };
                }
                BackMessage<int> data;
                if (baseProduct.IsMutiAttribute == 1)
                {
                    foreach (var productAttribute in productAttributes)
                    {
                        productAttribute.ProductId = productId;
                    }
                    ProductsAttributesBLO.ProductsAttributesDelete(product.ProductId, connection, trans);
                    data = ProductsAttributesBLO.ProductsAttributesAdd(productAttributes, connection, trans);
                    if (!data.IsSuccess)
                    {
                        trans.Rollback();
                        return data;
                    }

                    if (productAttributesPicture != null)
                    {
                        productAttributesPicture.ProductId = product.ProductId;
                        data = ProductsAttributesPictureBLO.ProductsAttributesPictureAddOrUpdate(productAttributesPicture, connection, trans);
                        if (!data.IsSuccess)
                        {
                            trans.Rollback();
                            return data;
                        }
                    }
                }
                else
                {
                    ProductsAttributesBLO.ProductsAttributesDelete(product.ProductId, connection, trans);
                    ProductsAttributesPictureBLO.ProductsAttributesPictureDelete(product.ProductId, connection, trans);
                }

                //商品主图处理逻辑
                if (productsPictureDetail != null)
                {
                    foreach (var detail in productsPictureDetail)
                    {
                        detail.ImageProductId = product.ImageProductId;
                    }
                    data = ProductsPictureDetailBLO.ProductsPictureDetailAdd(productsPictureDetail.AsEnumerable(), connection, trans);
                    if (!data.IsSuccess)
                    {
                        trans.Rollback();
                        return data;
                    }
                }

                //商品条码处理逻辑
                if (codes != null && codes.Count > 0)
                {
                    foreach (var productsBarCodese in codes)
                    {
                        productsBarCodese.ProductId = productId;
                        var result = ProductsBarCodesBLO.ProductBarCodesAdd(productsBarCodese, connection, trans);
                        if (!result.IsSuccess)
                        {
                            trans.Rollback();
                            return result;
                        }
                    }
                }


                //商品单位处理逻辑(先删除后添加)
                if (units != null && units.Count > 0)
                {
                    foreach (var productsUnit in units)
                    {
                        productsUnit.ProductID = productId;
                        var result = ProductsUnitBLO.ProductUnitsAdd(productsUnit, connection, trans);
                        if (!result.IsSuccess)
                        {
                            trans.Rollback();
                            return result;
                        }

                    }
                }


                trans.Commit();
                return new BackMessage<int>()
                {
                    IsSuccess = true,
                    Message = "保存商品信息成功",
                    Data = productId
                };
            }
            catch (Exception ex)
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




        /// <summary>
        /// 编辑商品
        /// </summary>
        /// <returns></returns>
        public static BackMessage<int> ProductEdit(
            BaseProducts baseProduct,
            Products product,
            IList<ProductsAttributes> productAttributes,
            IList<ProductsPictureDetail> productsPictureDetail,
            ProductsAttributesPicture productAttributesPicture,
            IList<ProductsBarCodes> codes,
            IList<ProductsUnit> units)
        {

            var connection = DALFactory.GetLazyInstance<IAttributesDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(product.ProductName))
                {
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "请输入商品名称"
                    };
                }
                if (string.IsNullOrEmpty(product.SKU))
                {
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "请输入商品编码"
                    };
                }

                if (DALFactory.GetLazyInstance<IProductsDAO>().ExistName(product))
                {
                    trans.Rollback();
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "商品名已被使用"
                    };
                }
                if (DALFactory.GetLazyInstance<IProductsDAO>().ExistERP(product))
                {
                    trans.Rollback();
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "商品编码已被使用"
                    };
                }

                var oldProduct = ProductsGet(product.ProductId);
                if (string.IsNullOrEmpty(product.Keywords))
                {
                    if (!string.IsNullOrEmpty(oldProduct.Keywords))
                    {
                        product.Keywords = oldProduct.Keywords;
                        product.SaleBackFlag = oldProduct.Keywords;
                    }
                }

                if (baseProduct.IsBaseProductId == 0)
                {
                    baseProduct.ProductBaseName = "";
                }
                var oldBaseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(baseProduct.BaseProductId);
                string msg = "";
                if (oldBaseProduct != null)
                {
                    BackMessage<int> messageInfo = BaseProductsBLO.Edit(baseProduct, connection, trans);
                    if (messageInfo.Data <= 0)
                    {
                        trans.Rollback();
                        return new BackMessage<int>()
                        {
                            IsSuccess = false,
                            Message = "修改母商品失败," + messageInfo.Message,
                            Data = 0
                        };
                    }
                }
                else
                {
                    BackMessage<int> messageInfo = BaseProductsBLO.Save(baseProduct, connection, trans);
                    if (messageInfo.Data <= 0)
                    {
                        trans.Rollback();
                        return new BackMessage<int>()
                        {
                            IsSuccess = false,
                            Message = "创建母商品失败" + messageInfo.Message,
                            Data = 0
                        };
                    }
                }

                product.BaseProductId = baseProduct.BaseProductId;
                if (baseProduct.IsMutiAttribute == 1)
                {
                    if (productAttributes != null)
                    {
                        ProductsAttributesBLO.InitAttributeValuesStr(product, productAttributes);
                        if (productAttributes.Count > 0)
                        {
                            ProductsAttributesBLO.ProductsAttributesDelete(product.ProductId, connection, trans);
                            var data = ProductsAttributesBLO.ProductsAttributesAdd(productAttributes, connection, trans);
                            if (!data.IsSuccess)
                            {
                                trans.Rollback();
                                return data;
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(product.MutValues))
                        {
                            if (!string.IsNullOrEmpty(oldProduct.MutValues))
                            {
                                product.MutValues = oldProduct.MutValues;
                            }
                        }
                    }

                    if (productAttributesPicture != null)
                    {
                        productAttributesPicture.ProductId = product.ProductId;
                        var data = ProductsAttributesPictureBLO.ProductsAttributesPictureAddOrUpdate(productAttributesPicture, connection, trans);
                        if (!data.IsSuccess)
                        {
                            trans.Rollback();
                            return data;
                        }
                    }

                }
                else
                {
                    product.MutValues = "";
                    ProductsAttributesBLO.ProductsAttributesDelete(product.ProductId, connection, trans);
                    ProductsAttributesPictureBLO.ProductsAttributesPictureDelete(product.ProductId, connection, trans);
                }

                if (productsPictureDetail != null && productsPictureDetail.Count > 0)
                {
                    ProductsPictureDetailBLO.ProductsPictureDetailDelete(product, connection, trans);
                    var data = ProductsPictureDetailBLO.ProductsPictureDetailAdd(productsPictureDetail.AsEnumerable(), connection, trans);
                    if (!data.IsSuccess)
                    {
                        trans.Rollback();
                        return data;
                    }
                }


                if (Edit(product, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return new BackMessage<int>()
                    {
                        IsSuccess = false,
                        Message = "更新商品信息失败"
                    };
                }
                
                if (codes != null && codes.Count > 0)
                {
                    DALFactory.GetLazyInstance<IProductsBarCodesDAO>().DeleteByProductId(product.ProductId, connection, trans);
                    foreach (var productsBarCodese in codes)
                    {
                        var result = ProductsBarCodesBLO.ProductBarCodesAdd(productsBarCodese, connection, trans);
                        if (!result.IsSuccess)
                        {
                            trans.Rollback();
                            return result;
                        }
                    }
                }


                //先删除后添加
                if (units != null && units.Count > 0)
                {
                    DALFactory.GetLazyInstance<IProductsUnitDAO>().DeleteByProductId(product.ProductId, connection, trans);
                    foreach (var productsUnit in units)
                    {
                        //没有做引用判断
                        var result = ProductsUnitBLO.ProductUnitsAdd(productsUnit, connection, trans);
                        if (!result.IsSuccess)
                        {
                            trans.Rollback();
                            return result;
                        }
                    }
                }




                trans.Commit();
                return new BackMessage<int>()
                {
                    IsSuccess = true,
                    Message = "编辑商品信息成功",
                    Data = product.ProductId
                };
            }
            catch (Exception ex)
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


        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static Products ProductsGet(int productId)
        {
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("ProductId", productId);
            return DALFactory.GetLazyInstance<IProductsDAO>().GetModel(conditionDict);
        }

        /// <summary>
        /// 获取母商品下面的所有子商品
        /// </summary>
        /// <param name="baseProductId"></param>
        /// <returns></returns>
        public static IList<Products> ProductsGetByBaseProductId(int baseProductId)
        {
            var baseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(baseProductId, false);
            if (baseProduct.IsBaseProductId == 0) //不是母商品
            {
                return new List<Products>();
            }
            return DALFactory.GetLazyInstance<IProductsDAO>().GetList(new Dictionary<string, object>().Append("BaseProductId", baseProductId));
        }

        /// <summary>
        /// 取母商品的子商品，如母商品IsBaseProductId为0，返回空
        /// </summary>
        /// <param name="baseProductId">母商品ID</param>
        /// <returns></returns>
        public static IList<Products> GetBaseProductChildren(int baseProductId)
        {
            var baseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(baseProductId, false);
            if (baseProduct.IsBaseProductId == 0) //不是母商品
            {
                return null;
            }
            return DALFactory.GetLazyInstance<IProductsDAO>().GetList(new Dictionary<string, object>().Append("BaseProductId", baseProductId));
        }

        ///// <summary>
        ///// 获取门店商品表商品信息
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static vWCSupplierProducts WCSupplierProductsGet(int id)
        //{
        //    return LazyDAOObjectCreator.IvWCSupplierProductsDAO.GetModel(id);
        //}




        /// <summary>
        /// 商品SEO设置
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="keyword">关键词，多个关键词,分开</param>
        /// <returns></returns>
        public static int ProductKeyWordUpdate(int productId, string keyword)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().ProductKeyWordUpdate(productId, keyword);
        }



        /// <summary>
        /// √创建商品ID号
        /// </summary>
        /// <returns>商品编号</returns>
        public static int CreateProductId()
        {
            return DALFactory.GetLazyInstance<IProductsSKUNumberServiceDAO>().CreateProductId();
        }

        ///// <summary>
        ///// √创建SKU号
        ///// </summary>
        ///// <returns></returns>
        //public static string CreateSku(int? productId)
        //{
        //    if (productId.HasValue)
        //    {
        //        return productId.Value.ToString("0000000");
        //    }
        //    else
        //    {
        //        return CreateProductId().ToString("0000000");
        //    }
        //}

        ///// <summary>
        ///// 获取网仓或者门店商品唯一ID
        ///// </summary>
        ///// <returns></returns>
        //public static long CreateWCSupplierId()
        //{
        //    return LazyDAOObjectCreator.IProductsNumberServiceDAOObj.Save(new ProductsNumberService()
        //    {
        //        States = 1
        //    });
        //}

        /// <summary>
        /// 获取ERP编码返回集合
        /// </summary>
        /// <returns>数据集合</returns>
        public static Dictionary<int, string> GetProductErpCodeList(IList<int> products)
        {
            return DALFactory.GetLazyInstance<IProductsDAO>().GetProductErpCodeList(products);
        }

        #region 添加编辑促销时--根据商品或订单促销验证同一时间段是否有相同的商品或基本分类
        /// <summary>
        /// 添加编辑促销时--根据商品或订单促销验证同一时间段是否有相同的商品或基本分类
        /// </summary>
        /// <param name="conditionDict">查询条件</param>
        /// <returns></returns>
        public static bool IsPromotionDataTimeProductList(Dictionary<string, string> conditionDict, out string info)
        {
            info = "";

            string categoryListID = conditionDict.ContainsKey("CategoryListID") ? conditionDict["CategoryListID"].ToString() : "";
            string productListID = conditionDict.ContainsKey("ProductListID") ? conditionDict["ProductListID"].ToString() : "";

            if (string.IsNullOrWhiteSpace(categoryListID) || string.IsNullOrWhiteSpace(productListID))
            {
                return false;
            }

            //判断分类ID是否全为数字
            if (!Frxs.Platform.Utility.Validator.IsNumericArray(categoryListID.Split(new char[] { ',' })))
            {
                info = "分类ID格式不正确";
                return false;
            }

            //判断商品ID是否全为数字
            if (!Frxs.Platform.Utility.Validator.IsNumericArray(productListID.ToString().Split(new char[] { ',' })))
            {
                info = "商品ID格式不正确";
                return false;
            }

            return DALFactory.GetLazyInstance<IProductsDAO>().IsPromotionDataTimeProductList(conditionDict);
        }
        #endregion
    }
}
