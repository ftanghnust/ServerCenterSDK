using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/24 14:02:14
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取商品详情，注意：此方法比较耗时，获取对应的对象请尽量使用小粒度接口
    /// </summary>
    [ActionName("Product.Get.V20")]
    public class ProductGetV20Action : ActionBase<ProductGetV20Action.ProductGetV20ActionRequestDto, ProductGetV20Action.ProductGetV20ActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class ProductGetV20ActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 商品ID
            /// </summary>
            public int? ProductId { get; set; }

            /// <summary>
            /// 商品SKU信息
            /// </summary>
            public string SKU { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (!this.ProductId.HasValue && string.IsNullOrEmpty(this.SKU))
                {
                    yield return new RequestDtoValidatorResultError("ProductId,SKU", "SKU和ProductId不能同时为空");
                }
            }
        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class ProductGetV20ActionResponseDto
        {
            /// <summary>
            /// 商品信息
            /// </summary>
            public Products Product { get; set; }
            /// <summary>
            /// 母商品
            /// </summary>
            public BaseProducts BaseProduct { get; set; }
            /// <summary>
            /// 商品规格属性
            /// </summary>
            public List<ProductsAttributes> ProductsAttributes { get; set; }

            /// <summary>
            /// 商品规格图片
            /// </summary>
            public ProductsAttributesPicture ProductsAttributesPicture { get; set; }

            /// <summary>
            /// 商品国际条码
            /// </summary>
            public List<ProductsBarCodes> ProductsBarCodes { get; set; }

            /// <summary>
            /// 商品描述
            /// </summary>
            public ProductsDescription ProductsDescription { get; set; }

            /// <summary>
            /// 商品描述图片
            /// </summary>
            public List<ProductsDescriptionPicture> ProductsDescriptionPicture { get; set; }

            /// <summary>
            /// 商品详情图片
            /// </summary>
            public List<ProductsPictureDetail> ProductsPictureDetail { get; set; }

            /// <summary>
            /// 商品单位
            /// </summary>
            public List<ProductsUnit> ProductsUnit { get; set; }

            /// <summary>
            /// 商品供应商
            /// </summary>
            public List<ProductsVendor> ProductsVendor { get; set; }

            /// <summary>
            /// 商品分类
            /// </summary>
            public List<Categories> Categories { get; set; }

            /// <summary>
            /// 商品品牌集合
            /// </summary>
            public List<BrandCategories> BrandCategories { get; set; }

            /// <summary>
            /// 商品运营分类
            /// </summary>
            public List<ShopCategories> ShopCategories { get; set; }

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ProductGetV20ActionResponseDto> Execute()
        {
            //商品信息
            Products product = null;
            IProductsDAO iProducts = DALFactory.GetLazyInstance<IProductsDAO>();
            //上传了商品编号
            if (this.RequestDto.ProductId.HasValue)
                product = iProducts.GetModel(this.RequestDto.ProductId.Value);
            else
                product = iProducts.GetModel(new Dictionary<string, object>().Append("sku", this.RequestDto.SKU));

            //商品不存在
            if (product.IsNull())
            {
                return this.ErrorActionResult("商品不存在");
            }

            //母商品
            var baseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(product.BaseProductId);
            if (baseProduct.IsNull())
            {
                return this.ErrorActionResult("商品{0}母商品不存在".With(product.ProductId));
            }

            //查询条件
            var dict = new Dictionary<string, object>().Append("ProductId", product.ProductId);

            //商品属性
            var productsAttributes = DALFactory.GetLazyInstance<IProductsAttributesDAO>().GetList(dict).ToList();

            //商品属性图片
            var productsAttributesPicture = DALFactory.GetLazyInstance<IProductsAttributesPictureDAO>().GetModel(product.ProductId);

            //商品条码
            var productsBarCodes = DALFactory.GetLazyInstance<IProductsBarCodesDAO>().GetList(dict).ToList();

            //商品描述
            var productsDescription = DALFactory.GetLazyInstance<IProductsDescriptionDAO>().GetModel(baseProduct.BaseProductId);

            //商品详情图片
            var productsDescriptionPicture = DALFactory.GetLazyInstance<IProductsDescriptionPictureDAO>().GetList(new Dictionary<string, object>().Append("BaseProductId", baseProduct.BaseProductId)).ToList();

            //商品图片
            var productsPictureDetail = DALFactory.GetLazyInstance<IProductsPictureDetailDAO>().GetList(new Dictionary<string, object>().Append("ImageProductId", product.ImageProductId)).ToList();

            //商品单位
            var productsUnit = DALFactory.GetLazyInstance<IProductsUnitDAO>().GetList(dict).ToList();

            //供应商
            var productsVendor = DALFactory.GetLazyInstance<IProductsVendorDAO>().GetList(dict).ToList();

            //基本分类
            List<Categories> categories = new List<Categories>();
            new int[] { baseProduct.CategoryId1, baseProduct.CategoryId2, baseProduct.CategoryId3 }.ToList().ForEach(o =>
            {
                var cat = DALFactory.GetLazyInstance<ICategoriesDAO>().GetModel(o);
                if (!cat.IsNull())
                {
                    categories.Add(cat);
                }
            });

            //运营分类
            List<ShopCategories> shopCategories = new List<ShopCategories>();
            new int[] { baseProduct.ShopCategoryId1, baseProduct.ShopCategoryId2, baseProduct.ShopCategoryId3 }.ToList().ForEach(o =>
            {
                var cat = DALFactory.GetLazyInstance<IShopCategoriesDAO>().GetModel(o);
                if (!cat.IsNull())
                {
                    shopCategories.Add(cat);
                }
            });

            //品牌
            List<BrandCategories> brandCategories = new List<BrandCategories>();
            new int[] { baseProduct.BrandId1, baseProduct.BrandId2 }.ToList().ForEach(o =>
            {
                var cat = DALFactory.GetLazyInstance<IBrandCategoriesDAO>().GetModel(o);
                if (!cat.IsNull())
                {
                    brandCategories.Add(cat);
                }
            });

            //输出对象
            var responseDto = new ProductGetV20ActionResponseDto()
            {
                Product = product,
                BaseProduct = baseProduct,
                ProductsAttributes = productsAttributes,
                ProductsAttributesPicture = productsAttributesPicture,
                ProductsBarCodes = productsBarCodes,
                ProductsDescription = productsDescription,
                ProductsDescriptionPicture = productsDescriptionPicture,
                ProductsPictureDetail = productsPictureDetail,
                ProductsUnit = productsUnit,
                ProductsVendor = productsVendor,
                Categories = categories,
                BrandCategories = brandCategories,
                ShopCategories = shopCategories
            };

            //返回消息
            return this.SuccessActionResult(responseDto);
        }

    }
}