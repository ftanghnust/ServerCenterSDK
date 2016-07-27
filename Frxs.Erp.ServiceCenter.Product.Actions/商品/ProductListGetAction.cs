using System;
using System.Collections.Generic;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 电商商品库查询列表接口
    /// 此页面在获取商品运营分类和商品基本分类字符串的时候使用了缓存，缓存时间为5分钟，即同一运营分类ID和同一商品分类输出字符串会被缓存
    /// </summary>
    [ActionName("Product.List.Get")]
    //[HttpMethod("POST")]
    //[ActionResultCache(1)]
    public class BossProductListGetAction : ActionBase<GetBossProductListRepquestDto, ActionResultPagerData<BossProductListGetAction.GetBossProductListResponseDto>>
    {
        /// <summary>
        /// 返回参数
        /// </summary>
        public class GetBossProductListResponseDto
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
            /// 商品erp编码
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
            /// 商品条码集合
            /// </summary>
            public string BarcodesString { get; set; }

            ///// <summary>
            ///// 建议零售价
            ///// </summary>
            //public decimal SalePrice { get; set; }

            ///// <summary>
            ///// 零售价上限
            ///// </summary>
            //public decimal MarketPrice { get; set; }

            ///// <summary>
            ///// 是否供应商
            ///// </summary>
            //public int IsVendor { get; set; }

            /// <summary>
            /// 运营分类1
            /// </summary>
            public int ShopCategoryId1 { get; set; }

            /// <summary>
            /// 运营分类2
            /// </summary>
            public int ShopCategoryId2 { get; set; }

            /// <summary>
            /// 运营分类2
            /// </summary>
            public int ShopCategoryId3 { get; set; }

            /// <summary>
            /// 运营分类全名
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
            /// 商品基本分类名称
            /// </summary>
            public string CategoryName { get; set; }

            /// <summary>
            /// 商品图片保存表集合
            /// </summary>
            public int ImageProductId { get; set; }

            /// <summary>
            /// 天下图库编号
            /// </summary>
            public string TXTKID { get; set; }

            /// <summary>
            /// 多规格属性名称编号
            /// </summary>
            public string MutAttributes { get; set; }

            /// <summary>
            /// 库存单位
            /// </summary>
            public string Unit { get; set; }

            /// <summary>
            /// 商品状态
            /// </summary>
            public int Status { get; set; }

            /// <summary>
            /// 商品状态
            /// </summary>
            public string StatusName { get; set; }

            /// <summary>
            /// 商品状态
            /// </summary>
            public string WarehousePrice { get; set; }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ActionResultPagerData<GetBossProductListResponseDto>> Execute()
        {
            //直接从提交的data参数（JSON格式）反序列化出对应的传输对象(出现异常系统框架会自动处理)
            var dto = this.RequestDto;

            // 查询数据
            var productQueryServices = DALFactory.GetLazyInstance<IProductQueryDAO>();
            //当前页码
            productQueryServices.PageIndex = (!dto.PageIndex.HasValue || dto.PageIndex <= 0) ? 1 : dto.PageIndex.Value;
            //每页显示条数
            productQueryServices.PageSize = (!dto.PageSize.HasValue || dto.PageSize <= 0) ? 10 : dto.PageSize.Value;
            //查询参数
            productQueryServices.SearchParams = new ProductQuerySearchParams()
            {
                BarCode = dto.BarCode,
                BrandName = dto.BrandName,
                BrandId1 = dto.BrandId1,
                BrandId2 = dto.BrandId2,
                CategoriesID1 = dto.CategoriesID1,
                CategoriesID2 = dto.CategoriesID2,
                CategoriesID3 = dto.CategoriesID3,
                //ErpCode = dto.ErpCode,
                //IsVendor = dto.IsVendor,
                ProductBaseName = dto.ProductBaseName,
                ProductIds = dto.ProductIds,
                BaseProductId = dto.BaseProductId,
                ProductName = dto.ProductName,
                ShopCategoriesID1 = dto.ShopCategoriesID1,
                ShopCategoriesID2 = dto.ShopCategoriesID2,
                ShopCategoriesID3 = dto.ShopCategoriesID3,
                Sku = dto.Sku,
                Status = dto.Status,
                IsBaseProductId = dto.IsBaseProductId,
                IsOnlyBaseProduct = dto.IsOnlyBaseProduct,
                IsMutiAttribute = dto.IsMutiAttribute,
                MutAttributes = dto.MutAttributes,
                //SalePrice1 = dto.SalePrice1,
                //SalePrice2 = dto.SalePrice2,
                ImageProductId = dto.ImageProductId
            };

            //总记录数
            int totalRecords = productQueryServices.GetCount();

            //列表数据
            var itemList = productQueryServices.GetList();

            //返回结果
            var data = new ActionResult<ActionResultPagerData<BossProductListGetAction.GetBossProductListResponseDto>>()
            {
                Info = "OK",
                Flag = ActionResultFlag.SUCCESS,
                Data = new ActionResultPagerData<GetBossProductListResponseDto>
                {
                    //总记录数
                    TotalRecords = totalRecords,

                    //列表数据
                    ItemList = itemList.Select(item =>
                    {
                        //获取规格属性
                        var productsAttributes = ProductsAttributesBLO.ProductsAttributesGet(item.ProductId);

                        //国际条码集合
                        var productsBarCodes = ProductsBarCodesBLO.ProductsBarCodesGet(item.ProductId);

                        //商品库存单位
                        var stockunitName = string.Empty;
                        var productUnits = ProductsUnitBLO.ProductsUnitListGet(item.ProductId);
                        if (productUnits != null)
                        {
                            var stockunit = productUnits.FirstOrDefault(i => i.IsUnit == 1);
                            if (stockunit != null)
                            {
                                stockunitName = stockunit.Unit;
                            }
                        }

                        //运营分类(根据ID值获取缓存，缓存5分钟)
                        string shopCategoryName = ShopCategoriesBLO.GetShopCategoriesString(item.ShopCategoryId1, item.ShopCategoryId2, item.ShopCategoryId3);

                        //基本分类
                        string categoryName = CategoriesBLO.GetCategoriesString(item.CategoryId1, item.CategoryId2, item.CategoryId3);

                        //返回匿名对象
                        return new GetBossProductListResponseDto
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
                                        //商品状态
                                        Status = item.Status,
                                        StatusName = GetStatusName(item.Status),
                                        //库存单位
                                        Unit = stockunitName,
                                        //母商品名称
                                        ProductBaseName = item.IsBaseProductId == 0 ? "" : item.ProductBaseName,
                                        //多规格属性 
                                        AttributeNames = (from o in productsAttributes select new ProductsAttributes { AttributeName = o.AttributeName, ValueStr = o.ValueStr }).ToList(),

                                        //多规格属性名称列表
                                        AttributeNamesString = string.Join(",", from o in productsAttributes select o.ValueStr),
                                        //商品条码集合
                                        Barcodes = (from o in productsBarCodes select o.BarCode).ToList(),
                                        //商品条码集合字符串
                                        BarcodesString = string.Join(",", from o in productsBarCodes select o.BarCode),
                                        ////建议零售价
                                        //SalePrice = item.SalePrice,
                                        ////零售价上限
                                        //MarketPrice = item.MarketPrice,
                                        ////是否第三方商品
                                        //IsVendor = item.IsVendor,
                                        //运营分类1
                                        ShopCategoryId1 = item.ShopCategoryId1,
                                        //运营分类2
                                        ShopCategoryId2 = item.ShopCategoryId2,
                                        ShopCategoryId3 = item.ShopCategoryId3,

                                        //运营分类名称
                                        ShopCategoryName = shopCategoryName,

                                        //品牌1
                                        BrandId1 = item.BrandId1,
                                        //品牌2
                                        BrandId2 = item.BrandId2,
                                        //商品基本分类1
                                        CategoryId1 = item.CategoryId1,
                                        //商品基本分类2
                                        CategoryId2 = item.CategoryId2,
                                        //商品基本分类3
                                        CategoryId3 = item.CategoryId3,

                                        //商品分类名称
                                        CategoryName = categoryName,

                                        //商品图片保存表集合ID
                                        ImageProductId = item.ImageProductId,
                                        //天下图库ID
                                        TXTKID = string.IsNullOrWhiteSpace(item.TXTKID) ? null : item.TXTKID,
                                        //多规格属性名称ID值
                                        MutAttributes = item.MutAttributes,
                                        WarehousePrice = "",
                                    };
                    }).ToList()
                }
            };
            return data;

        }

        /// <summary>
        /// 得到商品名称
        /// </summary>
        /// <param name="status">商品状态</param>
        /// <returns></returns>
        private string GetStatusName(int status)
        {
            string statusname;
            switch ((ProductCenterEnum.ProductStatus)status)
            {
                case ProductCenterEnum.ProductStatus.正常:
                    statusname = "正常";
                    break;
                case ProductCenterEnum.ProductStatus.冻结:
                    statusname = "冻结";
                    break;
                case ProductCenterEnum.ProductStatus.淘汰:
                    statusname = "淘汰";
                    break;
                default:
                    statusname = "";
                    throw new ArgumentOutOfRangeException("status");
            }
            return statusname;
        }
    }
}
