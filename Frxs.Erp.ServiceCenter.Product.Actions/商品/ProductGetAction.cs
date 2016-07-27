using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Product;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取商品库商品详情
    /// </summary>
    [ActionName("Product.Get")]
    //[ActionResultCache(2)] //缓存下2分钟
    public class ProductGetAction : ActionBase<RequestDto.ProductGetRequestDto, ProductGetResponseDto>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ProductGetResponseDto> Execute()
        {
            //获取接口参数
            var dto = this.RequestDto;

            //未提交商品ID
            if (!dto.ProductId.HasValue)
            {
                return this.ErrorActionResult("productId参数未提交");
            }

            //1.获取商品ID
            int productId = dto.ProductId.Value;

            //2.获取商品信息
            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(productId), () => ProductsBLO.ProductsGet(productId));

            //商品信息不存在
            if (product == null)
            {
                return this.ErrorActionResult("请求的商品不存在");
            }

            //3.获取母商品信息
            var baseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId), () =>
                                                            BaseProductsBLO.GetModel(product.BaseProductId, false));
            //4.商品属性规格
            var productsAttributes = this.CacheManager.GetList(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTES_LIST_KEY.With(productId), () =>
                                                            ProductsAttributesBLO.ProductsAttributesGet(productId));
            //5.规格属性图片
            var productsAttributesPicture = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTEPICTURE_KEY.With(productId), () =>
                                                            ProductsAttributesPictureBLO.ProductsAttributesPictureGet(productId));
            //6.国际条码信息
            var productsBarCodes = ProductsBarCodesBLO.ProductsBarCodesGet(productId);
            //7.商品描述信息
            var productsDescription = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTDESCRIPTION_KEY.With(baseProduct.BaseProductId), () =>
                                                            ProductsDescriptionBLO.ProductsDescriptionGet(baseProduct.BaseProductId));
            //8.商品图文
            var productsDescriptionPictures = this.CacheManager.GetList(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTSDESCRIPTIONPICTURES_LIST_KEY.With(baseProduct.BaseProductId), () =>
                                                            ProductsDescriptionPictureBLO.ProductsDescriptionPictureGet(baseProduct.BaseProductId)).OrderBy(x => x.OrderNumber);
            //9.商品主图
            var productsPictureDetails = this.CacheManager.GetList(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTPICTUREDETAILS_LIST_KEY.With(product.ImageProductId), () =>
                                                            ProductsPictureDetailBLO.ProductsPictureDetailsGet(productId)).OrderBy(x => x.OrderNumber);
            //10.商品单位集合
            var productsUnits = this.CacheManager.GetList(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTUNITS_LIST_KEY.With(productId), () =>
                                                            ProductsUnitBLO.ProductsUnitListGet(productId)).OrderByDescending(x => x.IsUnit);
          

            //获取商品SKU
            var sku = product.SKU;
            var baseProductBId = product.ProductId;
            if (product.BaseProductId != product.ProductId)
            {
                var mProduct =
                    this.CacheManager.Get(
                        Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(baseProduct.BaseProductId),
                        () => ProductsBLO.ProductsGet(baseProduct.BaseProductId));
                sku = mProduct.SKU;
                baseProductBId = mProduct.ProductId;
            }

            //品牌1名称获取
            IBrandCategoriesDAO iBrandCategories = DALFactory.GetLazyInstance<IBrandCategoriesDAO>();
            var brand1 = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BRAND_KEY.With(baseProduct.BrandId1), 60 * 24 * 30, () =>
                    iBrandCategories.GetModel(baseProduct.BrandId1));
            string brandName1 = "";
            if (brand1 != null)
            {
                brandName1 = brand1.BrandName;
            }

            //品牌2名称获取
            var brand2 = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BRAND_KEY.With(baseProduct.BrandId2), () =>
                         iBrandCategories.GetModel(baseProduct.BrandId2));
            string brandName2 = "";
            if (brand2 != null)
            {
                brandName2 = brand2.BrandName;
            }

            ProductGetResponseDto data = new ProductGetResponseDto
                {
                    //商品母商品信息
                    BaseProduct = new BaseProductResponseDto
                                      {
                                          //母商品ID
                                          BaseProductId = baseProduct.BaseProductId,

                                          //母商品名称
                                          ProductBaseName =
                                              baseProduct.IsBaseProductId == 0 ? "" : baseProduct.ProductBaseName,

                                          //品牌分类
                                          BrandId1 = baseProduct.BrandId1,
                                          BrandId2 = baseProduct.BrandId2,

                                          BaseProductBSKU = sku,
                                          BaseProductBId = baseProductBId,

                                          //商品分类
                                          CategoryId1 = baseProduct.CategoryId1,
                                          CategoryId2 = baseProduct.CategoryId2,
                                          CategoryId3 = baseProduct.CategoryId3,

                                          //运营分类
                                          ShopCategoryId1 = baseProduct.ShopCategoryId1,
                                          ShopCategoryId2 = baseProduct.ShopCategoryId2,
                                          ShopCategoryId3 = baseProduct.ShopCategoryId3,

                                          BrandName1 = brandName1,
                                          BrandName2 = brandName2,

                                          //是否是母商品0/1
                                          IsBaseProductId = baseProduct.IsBaseProductId,
                                          IsDeleted = baseProduct.IsDeleted,
                                          IsMutiAttribute = baseProduct.IsMutiAttribute,

                                          //是否第三方供应
                                          IsVendor = baseProduct.IsVendor,

                                          //创建者
                                          CreateTime = baseProduct.CreateTime,
                                          CreateUserID = baseProduct.CreateUserID,
                                          CreateUserName = baseProduct.CreateUserName,

                                          //修改者
                                          ModifyTime = baseProduct.ModifyTime,
                                          ModifyUserID = baseProduct.ModifyUserID,
                                          ModifyUserName = baseProduct.ModifyUserName,

                                          //商品描述
                                          ProductsDescription =
                                              productsDescription == null
                                                  ? null
                                                  : new ProductsDescription
                                                        {
                                                            //商品描述
                                                            Description = productsDescription.Description,
                                                            //创建/修改者
                                                            ModifyTime = productsDescription.ModifyTime,
                                                            ModifyUserID = productsDescription.ModifyUserID,
                                                            ModifyUserName = productsDescription.ModifyUserName
                                                        },

                                          //商品图文（集合）
                                          ProductsDescriptionPictureList = from item in productsDescriptionPictures
                                                                           select new ProductsDescriptionPicture
                                                                                      {
                                                                                          //商品图文，挂靠在在母商品
                                                                                          ImageUrlOrg = item.ImageUrlOrg,
                                                                                          ImageUrl120x120 =
                                                                                              item.ImageUrl120x120,
                                                                                          ImageUrl200x200 =
                                                                                              item.ImageUrl200x200,
                                                                                          ImageUrl400x400 =
                                                                                              item.ImageUrl400x400,
                                                                                          ImageUrl60x60 =
                                                                                              item.ImageUrl60x60,
                                                                                          OrderNumber = item.OrderNumber
                                                                                      }
                                      },

                    //商品信息
                    Product = new ProductResponseDto
                                  {

                                      //商品编码
                                      ProductId = product.ProductId,
                                      //ERPCODE编码
                                      SKU = product.SKU,
                                      //商品名称
                                      ProductName = product.ProductName,
                                      ProductName2 = product.ProductName2,

                                      //关联的主图商品信息（主图是自己的话ImageProductId=ProductId）
                                      ImageProductId = product.ImageProductId,

                                      //是否被删除
                                      IsDeleted = product.IsDeleted,
                                      //关键词
                                      Keywords = product.Keywords,

                                      //创建者
                                      CreateTime = product.CreateTime,
                                      CreateUserID = product.CreateUserID,
                                      CreateUserName = product.CreateUserName,
                                      //修改者
                                      ModifyTime = product.ModifyTime,
                                      ModifyUserID = product.ModifyUserID,
                                      ModifyUserName = product.ModifyUserName,
                                      //天下图库ID
                                      TXTKID = product.TXTKID,
                                      MutAttributes = product.MutAttributes,
                                      MutValues = product.MutValues,
                                      BackDays = product.BackDays,
                                      BaseProductId = product.BaseProductId,
                                      Mnemonic = product.Mnemonic,
                                      SaleBackFlag = product.SaleBackFlag,
                                      Status = product.Status,
                                      Volume = product.Volume,
                                      Weight = product.Weight,
                                      //add 2016.6.20 luojing
                                      VExt1 = product.VExt1,
                                      VExt2 = product.VExt2,

                                      //商品单位集合
                                      ProductsUnitList = from item in productsUnits
                                                         select new ProductsUnit
                                                                    {
                                                                        ProductsUnitID = item.ProductsUnitID,
                                                                        IsSaleUnit = item.IsSaleUnit,
                                                                        IsUnit = item.IsUnit,
                                                                        ModifyTime = item.ModifyTime,
                                                                        ModifyUserID = item.ModifyUserID,
                                                                        ModifyUserName = item.ModifyUserName,
                                                                        PackingQty = item.PackingQty,
                                                                        Spec = item.Spec,
                                                                        Unit = item.Unit
                                                                    },
                                      //商品国际条码(集合)
                                      ProductsBarCodeList = from item in productsBarCodes
                                                            select new ProductsBarCodes
                                                                       {
                                                                           //国际条码
                                                                           BarCode = item.BarCode,
                                                                           //创建者
                                                                           CreateTime = item.CreateTime,
                                                                           CreateUserID = item.CreateUserID,
                                                                           CreateUserName = item.CreateUserName
                                                                       },

                                      //商品属性规格值（集合）
                                      ProductsAttributeList = from item in productsAttributes
                                                              select new ProductsAttributes
                                                                         {
                                                                             //属性ID
                                                                             AttributeId = item.AttributeId,
                                                                             //属性名
                                                                             AttributeName = item.AttributeName,
                                                                             //属性值ID
                                                                             ValuesId = item.ValuesId,
                                                                             //属性值字符串
                                                                             ValueStr = item.ValueStr,
                                                                             //修改者
                                                                             ModifyTime = item.ModifyTime,
                                                                             ModifyUserID = item.ModifyUserID,
                                                                             ModifyUserName = item.ModifyUserName
                                                                         },
                                      //商品属性规格图片
                                      ProductsAttributesPicture =
                                          productsAttributesPicture == null
                                              ? null
                                              : new Model.ProductsAttributesPicture()
                                                    {
                                                        //原始图片
                                                        ImageUrlOrg = productsAttributesPicture.ImageUrlOrg,
                                                        ImageUrl120x120 = productsAttributesPicture.ImageUrl120x120,
                                                        ImageUrl200x200 = productsAttributesPicture.ImageUrl200x200,
                                                        ImageUrl400x400 = productsAttributesPicture.ImageUrl400x400,
                                                        ImageUrl60x60 = productsAttributesPicture.ImageUrl60x60,

                                                        //创建者
                                                        CreateTime = productsAttributesPicture.CreateTime,
                                                        CreateUserID = productsAttributesPicture.CreateUserID,
                                                        CreateUserName = productsAttributesPicture.CreateUserName
                                                    },

                                      //商品主图（集合）
                                      ProductsPictureDetailList = from item in productsPictureDetails
                                                                  select new ProductsPictureDetail
                                                                             {
                                                                                 //这里ID。如果是自己就与自己的ProductId一致，不一致说明是采用了其他商品的主图
                                                                                 ImageProductId = item.ImageProductId,

                                                                                 //商品主图信息
                                                                                 ImageUrlOrg = item.ImageUrlOrg,
                                                                                 ImageUrl120x120 = item.ImageUrl120x120,
                                                                                 ImageUrl200x200 = item.ImageUrl200x200,
                                                                                 ImageUrl400x400 = item.ImageUrl400x400,
                                                                                 ImageUrl60x60 = item.ImageUrl60x60,
                                                                                 IsMaster = item.IsMaster,
                                                                                 //排序字段
                                                                                 OrderNumber = item.OrderNumber
                                                                             }

                                  }
                };

            //10.获取商品详情
            return SuccessActionResult(data);

        }
    }
}
