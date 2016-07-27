using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// BaseProducts业务逻辑类
    /// </summary>
    public partial class BaseProductsBLO
    {
        #region 成员方法

        #region 根据主键验证BaseProducts是否存在
        /// <summary>
        /// 根据主键验证BaseProducts是否存在
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(BaseProducts model)
        {
            return DALFactory.GetLazyInstance<IBaseProductsDAO>().Exists(model);
        }
        #endregion


        #region 删除一个BaseProducts
        /// <summary>
        /// 删除一个BaseProducts
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(BaseProducts model)
        {
            return 0;
            //DALFactory.GetLazyInstance<IBaseProductsDAO>().Delete(model);
        }
        #endregion


        #region 根据字典获取BaseProducts对象

        /// <summary>
        /// 根据字典获取BaseProducts对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="bGetAttachedInfo">是否获取除主表外的其他信息 </param>
        /// <returns>BaseProducts对象</returns>
        public static BaseProducts GetModel(Dictionary<string, object> conditionDict, bool bGetAttachedInfo = true)
        {
            return DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(conditionDict, bGetAttachedInfo);
        }
        #endregion


        #region 根据字典获取BaseProducts集合
        /// <summary>
        /// 根据字典获取BaseProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<BaseProducts> GetList(Dictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IBaseProductsDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取BaseProducts数据集
        /// <summary>
        /// 根据字典获取BaseProducts数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(Dictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IBaseProductsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取BaseProducts集合
        /// <summary>
        /// 分页获取BaseProducts集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<BaseProducts> GetPageList(PageListBySql<BaseProducts> page, Dictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IBaseProductsDAO>().GetPageList(page, conditionDict);
        }
        #endregion
        #endregion
    }
    public partial class BaseProductsBLO
    {
        /// <summary>
        /// 根据字典获取BaseProducts对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="bGetAttachedInfo">是否获取除主表外的其他信息 </param>
        /// <returns>BaseProducts对象</returns>
        public static BaseProducts GetModel(int id, bool bGetAttachedInfo = false)
        {
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("BaseProductId", id);
            return DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(conditionDict, bGetAttachedInfo);
        }

        ///// <summary>
        ///// 是否关联了商品
        ///// </summary>
        ///// <param name="id">母商品ID</param>
        ///// <returns>关联的第一个商品名称</returns>
        //public static string UsedName(int id)
        //{
        //    return DALFactory.GetLazyInstance<IBaseProductsDAO>().UsedName(id);
        //}

        /// <summary>
        /// 是否已使用母商品名称
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <returns>true or false</returns>
        public static bool ExistProductBaseName(BaseProducts model)
        {
            return DALFactory.GetLazyInstance<IBaseProductsDAO>().ExistProductBaseName(model);
        }

        /// <summary>
        /// 带验证的删除
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <param name="msg">返回消息</param>
        /// <returns>删除记录数</returns>
        public static int Delete(BaseProducts model, ref string msg)
        {
            return 9;
            //return DALFactory.GetLazyInstance<IBaseProductsDAO>().Delete(model, ref msg);
        }

        /// <summary>
        /// 带验证的新增
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>母商品ID</returns>
        public static BackMessage<int> Save(BaseProducts model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            if (model.IsBaseProductId == 1 && string.IsNullOrEmpty(model.ProductBaseName))
            {
                return new BackMessage<int>()
                  {
                      IsSuccess = false,
                      Message = "母商品名不能为空",
                      Data = 0
                  };
            }
            else
            {
                if (model.IsBaseProductId == 0)
                {
                    model.ProductBaseName = "";
                }
            }


            int result = DALFactory.GetLazyInstance<IBaseProductsDAO>().Save(model, conn, tran);
            if (result > 0)
            {
                ////添加母商品文本详情
                //if (model.ProductsDescription != null)
                //{
                //    model.ProductsDescription.BaseProductId = model.BaseProductId;
                //    DALFactory.GetLazyInstance<IBaseProductsDAO>().AddProductsDescription(model.ProductsDescription, conn, tran);
                //}

                ////添加母商品图文详情
                //if (model.ProductsDescriptionPictures != null && model.ProductsDescriptionPictures.Count > 0)
                //{
                //    DALFactory.GetLazyInstance<IBaseProductsDAO>().AddProductsDescriptionPicture(model.BaseProductId, model.ProductsDescriptionPictures, conn, tran);
                //}

                ////添加第三方供应商
                //if (model.IsVendor > 0)
                //{
                //    if (model.ProductsVendor != null && model.ProductsVendor.Count > 0)
                //    {
                //        DeleteVendor(model.BaseProductId, null, conn, tran);
                //        foreach (var productsVendor in model.ProductsVendor)
                //        {
                //            DALFactory.GetLazyInstance<IBaseProductsDAO>().AddVendor(model.BaseProductId, productsVendor, conn, tran);
                //        }
                //    }
                //}
            }

            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "",
                Data = result
            };
        }

        /// <summary>
        /// 带验证的编辑
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>更新记录数量</returns>
        public static BackMessage<int> Edit(BaseProducts model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            if (model.IsBaseProductId == 1 && string.IsNullOrEmpty(model.ProductBaseName))
            {
                return new BackMessage<int>()
                {
                    IsSuccess = false,
                    Message = "母商品名不能为空",
                    Data = 0
                };
            }
            else
            {
                if (model.IsBaseProductId == 0)
                {
                    model.ProductBaseName = "";
                }
            }
            var result = DALFactory.GetLazyInstance<IBaseProductsDAO>().Edit(model, conn, tran);
            if (result > 0)
            {
                ////添加母商品文本详情
                //if (model.ProductsDescription != null)
                //{
                //    model.ProductsDescription.BaseProductId = model.BaseProductId;
                //    DALFactory.GetLazyInstance<IBaseProductsDAO>().AddProductsDescription(model.ProductsDescription, conn, tran);
                //}

                ////添加母商品图文详情
                //if (model.ProductsDescriptionPictures != null && model.ProductsDescriptionPictures.Count > 0)
                //{
                //    DALFactory.GetLazyInstance<IBaseProductsDAO>().AddProductsDescriptionPicture(model.BaseProductId, model.ProductsDescriptionPictures, conn, tran);
                //}

                ////添加第三方供应商
                //if (model.IsVendor > 0)
                //{
                //    if (model.ProductsVendor != null && model.ProductsVendor.Count > 0)
                //    {
                //        ProductVendorBLO.DeleteVendor(model.BaseProductId, null, conn, tran);
                //        foreach (var productsVendor in model.ProductsVendor)
                //        {
                //            DALFactory.GetLazyInstance<IBaseProductsDAO>().AddVendor(model.BaseProductId, productsVendor, conn, tran);
                //        }
                //    }
                //}

            }

            return new BackMessage<int>()
            {
                IsSuccess = true,
                Message = "",
                Data = result
            };
        }


        ///// <summary>
        ///// 添加母商品图文详情
        ///// </summary>
        ///// <param name="baseProductId">母商品ID</param>
        ///// <param name="pictures">母商品图片</param>
        ///// <param name="conn"></param>
        ///// <param name="tran"></param>
        ///// <returns></returns>
        //public static bool AddProductsDescriptionPicture(int baseProductId, ICollection<ProductsDescriptionPicture> pictures, IDbConnection conn = null, IDbTransaction tran = null)
        //{
        //    var result = DALFactory.GetLazyInstance<IBaseProductsDAO>().AddProductsDescriptionPicture(baseProductId, pictures, conn, tran);
        //    return result;
        //}

        ///// <summary>
        ///// 编辑母商品图文详情
        ///// </summary>
        ///// <param name="baseProductId">母商品ID</param>
        ///// <param name="pictures">母商品图文详情</param>
        ///// <param name="conn"></param>
        ///// <param name="tran"></param>
        ///// <returns></returns>
        //public static bool EditProductsDescriptionPicture(int baseProductId, ICollection<ProductsDescriptionPicture> pictures, IDbConnection conn = null, IDbTransaction tran = null)
        //{
        //    return DALFactory.GetLazyInstance<IBaseProductsDAO>().EditProductsDescriptionPicture(baseProductId, pictures,
        //                                                                                   conn, tran);
        //}


        ///// <summary>
        ///// 为母商品添加图文
        ///// </summary>
        ///// <param name="description"></param>
        ///// <param name="conn"></param>
        ///// <param name="tran"></param>
        ///// <returns></returns>
        //public bool AddProductsDescription(ProductsDescription description, IDbConnection conn = null, IDbTransaction tran = null)
        //{
        //    return DALFactory.GetLazyInstance<IBaseProductsDAO>().AddProductsDescription(description, conn, tran);
        //}




        ///// <summary>
        ///// 删除所有的第三方供应商，并且将母商品是否属于第三方供应商设置为false
        ///// </summary>
        ///// <param name="baseProductId"></param>
        ///// <returns></returns>
        //public static bool DeleteVendorAll(int baseProductId)
        //{
        //    //清空所有供应商
        //    ProductVendorBLO.DeleteVendor(baseProductId, null);
        //    //设置第三方供应商为false
        //    var model = GetModel(baseProductId, false);
        //    //修改
        //    model.IsVendor = 0;
        //    string msg = "";
        //    Edit(model, ref msg, null, null);
        //    return true;
        //}


        /// <summary>
        /// 绑定母商品
        /// </summary>
        /// <param name="baseProduct">母商品</param>
        /// <param name="products">商品</param>
        /// <returns></returns>
        public static BackMessage<int> BindToBaseProduct(BaseProducts baseProduct, Products products)
        {
            var conn = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetConnection();
            conn.Open();
            var trans = conn.BeginTransaction();
            try
            {
                //子商品本身为母商品且未解除绑定时，自动完成解绑过程
                if (products.BaseProductId == products.ProductId)
                {
                    var oldBaseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(products.BaseProductId, false);
                    if (oldBaseProduct.IsBaseProductId == 1)
                    {
                        oldBaseProduct.IsBaseProductId = 0;
                        oldBaseProduct.ModifyTime = DateTime.Now;
                        oldBaseProduct.ModifyUserID = products.ModifyUserID;
                        oldBaseProduct.ModifyUserName = products.ModifyUserName;
                        oldBaseProduct.ProductBaseName = "";
                        BaseProductsBLO.Edit(oldBaseProduct, conn, trans);
                    }
                }
                products.BaseProductId = baseProduct.BaseProductId;
                int num = ProductsBLO.Edit(products, conn, trans);
                trans.Commit();
                return new BackMessage<int>()
                {
                    IsSuccess = true,
                    Message = "绑定母商品成功",
                    Data = num
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
                conn.Close();
                conn.Dispose();
            }
        }


        /// <summary>
        /// 解绑母商品
        /// </summary>
        /// <param name="product">商品</param>
        /// <returns></returns>
        public static BackMessage<int> UnBindToBaseProduct(Products product)
        {
            var conn = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetConnection();
            conn.Open();
            var trans = conn.BeginTransaction();
            try
            {
                if (product.BaseProductId == product.ProductId)
                {
                    //母商品是子商品本身,将母商品的标志改掉即可
                    var baseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(product.BaseProductId, false);
                    if (baseProduct.IsBaseProductId == 1)
                    {
                        baseProduct.IsBaseProductId = 0;
                        baseProduct.ModifyTime = DateTime.Now;
                        baseProduct.ModifyUserID = product.ModifyUserID;
                        baseProduct.ModifyUserName = product.ModifyUserName;
                        baseProduct.ProductBaseName = "";
                        BaseProductsBLO.Edit(baseProduct, conn, trans);
                    }
                    //更新修改时间 修正bug 3633
                    int count = ProductsBLO.Edit(product, conn, trans);
                }
                else
                {
                    //复制一份原来的母商品，并修改部分信息
                    var baseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(product.BaseProductId, false);
                    baseProduct.BaseProductId = 0;
                    baseProduct.ProductBaseName = "";
                    baseProduct.IsBaseProductId = 0;
                    baseProduct.CreateTime = DateTime.Now;
                    baseProduct.CreateUserID = product.ModifyUserID;
                    baseProduct.CreateUserName = product.ModifyUserName;
                    baseProduct.ModifyTime = DateTime.Now;
                    baseProduct.ModifyUserID = product.ModifyUserID;
                    baseProduct.ModifyUserName = product.ModifyUserName;
                    
                    //如果ProductId!=ImgProductId，延用了母商品的图片，需复制图片
                    if (product.ImageProductId != product.ProductId)
                    {
                        var imgs =
                            DALFactory.GetLazyInstance<IProductsPictureDetailDAO>().ProductsPictureDetailsGet(
                                product.ImageProductId);
                        if (imgs != null && imgs.Count > 0)
                        {
                            foreach (var productsPictureDetail in imgs)
                            {
                                productsPictureDetail.ImageProductId = product.ProductId;
                                productsPictureDetail.CreateTime = DateTime.Now;
                                productsPictureDetail.CreateUserID = product.ModifyUserID;
                                productsPictureDetail.CreateUserName = product.ModifyUserName;
                                productsPictureDetail.ID = 0;
                            }
                            product.ImageProductId = product.ProductId;
                            var delResult = ProductsPictureDetailBLO.ProductsPictureDetailDelete(product, conn, trans);
                            if (!delResult.IsSuccess)
                            {
                                trans.Rollback();
                                return delResult;
                            }
                            var result = ProductsPictureDetailBLO.ProductsPictureDetailAdd(imgs, conn, trans);
                            if (!result.IsSuccess)
                            {
                                trans.Rollback();
                                return result;
                            }

                        }
                    }

                    //创建的母商品使用子商品ID
                    int baseProductId = product.ProductId;
                    baseProduct.BaseProductId = baseProductId;
                    var oldBaseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(baseProductId, false);
                    string msg = "";
                    if (oldBaseProduct != null)
                    {
                        //母商品表中存在与子商品ID相同的母商品，直接绑定
                        BaseProductsBLO.Edit(baseProduct, conn, trans);
                    }
                    else
                    {
                        //母商品表中不存在与子商品ID相同的母商品，添加新数据
                        BaseProductsBLO.Save(baseProduct, conn, trans);
                    }
                    //保存新的绑定信息
                    product.BaseProductId = baseProduct.BaseProductId;
                    int count = ProductsBLO.Edit(product, conn, trans);
                }
                trans.Commit();
                return new BackMessage<int>()
                {
                    IsSuccess = true,
                    Message = "解绑母商品成功",
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
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 获取母商品信息
        /// </summary>
        /// <param name="baseProductId"></param>
        /// <returns></returns>
        public static BaseProducts BaseProductsGet(int baseProductId)
        {
            Dictionary<string, object> conditionDict = new Dictionary<string, object>();
            conditionDict.Add("BaseProductId", baseProductId);
            return DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(conditionDict);
        }


    }
}
