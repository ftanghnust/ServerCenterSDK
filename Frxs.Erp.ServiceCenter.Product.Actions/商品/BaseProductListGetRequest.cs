using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 母商品列表查询功能
    /// </summary>
    [ActionName("BaseProductList.Get")]
    public class BaseProductListGetAction : ActionBase<BaseProductListGetRequestDto, ActionResultPagerData<BaseProductListGetAction.BaseProductListGetResponseDto>>
    {
        /// <summary>
        /// 母商品列表查询 返回数据对象
        /// </summary>
        public class BaseProductListGetResponseDto
        {
            /// <summary>
            /// 商品编码
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 母商品编码
            /// </summary>
            public int BaseProdutId { get; set; }


            /// <summary>
            /// 是否多规格商品
            /// </summary>
            public int IsMutiAttribute { get; set; }


            /// <summary>
            /// 是否是母商品
            /// </summary>
            public int IsBaseProductId { get; set; }


            /// <summary>
            /// 商品SKU
            /// </summary>
            public string Sku { get; set; }


            /// <summary>
            /// 商品名称
            /// </summary>
            public string ProductName { get; set; }


            /// <summary>
            /// 母商品名称
            /// </summary>
            public string ProductBaseName { get; set; }


            /// <summary>
            /// 多规格属性 
            /// </summary>
            public IList<ProductsAttributes> AttributeNames { get; set; }


            /// <summary>
            /// 多规格属性名称列表
            /// </summary>
            public string AttributeNamesString { get; set; }


            /// <summary>
            /// 商品条码集合
            /// </summary>
            public IList<string> Barcodes { get; set; }

            /// <summary>
            /// 商品条码集合字符串
            /// </summary>
            public string BarcodesString { get; set; }

            /// <summary>
            /// 是否第三方商品
            /// </summary>
            public int IsVendor { get; set; }


            /// <summary>
            /// 运营分类1
            /// </summary>
            public int ShopCategoryId1 { get; set; }

            /// <summary>
            /// 运营分类2
            /// </summary>
            public int ShopCategoryId2 { get; set; }


            /// <summary>
            /// 运营分类3
            /// </summary>
            public int ShopCategoryId3 { get; set; }


            /// <summary>
            /// 运营分类名称
            /// </summary>
            public string ShopCategoryName { get; set; }


            /// <summary>
            /// 品牌1
            /// </summary>
            public int BrandId1 { get; set; }

            /// <summary>
            /// 品牌2
            /// </summary>
            public int BrandId2 { get; set; }


            /// <summary>
            /// 商品分类1
            /// </summary>
            public int CategoryId1 { get; set; }

            /// <summary>
            /// 商品分类2
            /// </summary>
            public int CategoryId2 { get; set; }

            /// <summary>
            /// 商品分类3
            /// </summary>
            public int CategoryId3 { get; set; }



            /// <summary>
            /// 商品分类名称
            /// </summary>
            public string CategoryName { get; set; }


            /// <summary>
            /// 商品图片保存表集合ID
            /// </summary>
            public int ImageProductId { get; set; }

            //天下图库ID
            public string TXTKID { get; set; }

            public string MutAttributes { get; set; }


        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<BaseProductListGetResponseDto>> Execute()
        {

            var dto = this.RequestDto;

            // 查询数据
            var productQueryServices = DALFactory.GetLazyInstance<IProductQueryDAO>();
            //当前页码
            productQueryServices.PageIndex = (!dto.PageIndex.HasValue || dto.PageIndex <= 0) ? 1 : dto.PageIndex.Value;
            //每页显示条数
            productQueryServices.PageSize = (!dto.PageSize.HasValue || dto.PageSize <= 0) ? 10 : dto.PageSize.Value;
            productQueryServices.SearchParams = new ProductQuerySearchParams();
            productQueryServices.SearchParams.ProductBaseName = dto.BaseProductName;
            productQueryServices.SearchParams.Sku = dto.Sku;
            productQueryServices.SearchParams.IsOnlyBaseProduct = true;

            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(dto.ProductId), ()
                    => ProductsBLO.ProductsGet(dto.ProductId));
            if (null == product)
            {
                return ErrorActionResult("没有这个商品信息");
            }

            if (dto.CheckShopCategory)
            {
                var baseProduct =
                    this.CacheManager.Get(
                        Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId),
                        () => BaseProductsBLO.GetModel(product.BaseProductId, false));
                if (baseProduct == null)
                {
                    return ErrorActionResult("找不到商品的运营分类信息");
                }
                productQueryServices.SearchParams.ShopCategoriesID1 = baseProduct.ShopCategoryId1;
                productQueryServices.SearchParams.ShopCategoriesID2 = baseProduct.ShopCategoryId2;
                productQueryServices.SearchParams.ShopCategoriesID3 = baseProduct.ShopCategoryId3;
            }
            if (dto.CheckAttribute)
            {
                if (string.IsNullOrWhiteSpace(product.MutAttributes))
                {
                    return ErrorActionResult("找不到商品的规格属性信息");
                }
                productQueryServices.SearchParams.MutAttributes = product.MutAttributes;
            }

            //缓存的键生成依据，使用SearchParams来生成缓存键保证每次请求的参数一致


            var productQueryServicesList = productQueryServices.GetList();
            List<BaseProductListGetResponseDto> list = (from item in productQueryServicesList
                                                        let productsAttributes = ProductsAttributesBLO.ProductsAttributesGet(item.ProductId)
                                                        let productsBarCodes = ProductsBarCodesBLO.ProductsBarCodesGet(item.ProductId)
                                                        select new BaseProductListGetResponseDto
                                                                   {
                                                                       //商品编码
                                                                       ProductId = item.ProductId,
                                                                       //母商品编码
                                                                       BaseProdutId = item.BaseProductId,
                                                                       //是否多规格商品
                                                                       IsMutiAttribute = item.IsMutiAttribute,
                                                                       //是否是母商品
                                                                       IsBaseProductId = item.IsBaseProductId,
                                                                       //商品SKU
                                                                       Sku = item.SKU,
                                                                       //商品名称
                                                                       ProductName = item.ProductName,
                                                                       //母商品名称
                                                                       ProductBaseName = item.IsBaseProductId == 0 ? "" : item.ProductBaseName,

                                                                       //多规格属性 
                                                                       AttributeNames = (from o in productsAttributes
                                                                                         select new ProductsAttributes
                                                                                                    {
                                                                                                        AttributeName = o.AttributeName, ValueStr = o.ValueStr
                                                                                                    }).ToList(),

                                                                       //多规格属性名称列表
                                                                       AttributeNamesString = string.Join(",", from o in productsAttributes
                                                                                                               select o.ValueStr),

                                                                       //商品条码集合
                                                                       Barcodes = (from o in productsBarCodes
                                                                                   select o.BarCode).ToList(),

                                                                       //商品条码集合字符串
                                                                       BarcodesString = string.Join(",", from o in productsBarCodes
                                                                                                         select o.BarCode),

                                                                       ////建议零售价
                                                                       //SalePrice = item.SalePrice,
                                                                       ////零售价上限
                                                                       //MarketPrice = item.MarketPrice,

                                                                       //是否第三方商品
                                                                       IsVendor = item.IsVendor,

                                                                       //运营分类1
                                                                       ShopCategoryId1 = item.ShopCategoryId1,
                                                                       //运营分类2
                                                                       ShopCategoryId2 = item.ShopCategoryId2, ShopCategoryId3 = item.ShopCategoryId3,

                                                                       //运营分类名称
                                                                       ShopCategoryName = ShopCategoriesBLO.GetShopCategoriesString(item.ShopCategoryId1, item.ShopCategoryId2, item.ShopCategoryId3),

                                                                       //品牌1
                                                                       BrandId1 = item.BrandId1,
                                                                       //品牌2
                                                                       BrandId2 = item.BrandId2,

                                                                       //商品分类1
                                                                       CategoryId1 = item.CategoryId1,
                                                                       //商品分类2
                                                                       CategoryId2 = item.CategoryId2, CategoryId3 = item.CategoryId3,

                                                                       //商品分类名称
                                                                       CategoryName = CategoriesBLO.GetCategoriesString(item.CategoryId1, item.CategoryId2, item.CategoryId3),

                                                                       //商品图片保存表集合ID
                                                                       ImageProductId = item.ImageProductId,

                                                                       ////ERP
                                                                       //ErpCode = item.ErpCode,

                                                                       //天下图库ID
                                                                       TXTKID = item.TXTKID, MutAttributes = item.MutAttributes
                                                                   }).ToList();

            //返回结果
            return new ActionResult<ActionResultPagerData<BaseProductListGetResponseDto>>()
                       {
                           Info = "OK",
                           Flag = ActionResultFlag.SUCCESS,
                           Data = new ActionResultPagerData<BaseProductListGetResponseDto>
                                      {
                                          //总记录数
                                          TotalRecords = productQueryServices.GetCount(),
                                          //列表数据
                                          ItemList = list
                                      }
                       };

        }
    }
}
