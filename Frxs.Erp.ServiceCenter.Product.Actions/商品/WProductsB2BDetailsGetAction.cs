using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/13 9:58:39
 * *******************************************************/
using System.Collections.Generic;
using System.Linq;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using System;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取商品详情供B2B下单界面使用
    /// </summary>
    [ActionName("WProducts.B2B.Details.Get"), ActionResultCache(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY)]
    public class WProductsB2BDetailsGetAction : ActionBase<WProductsB2BDetailsGetAction.WProductsDetailsGetActionRequestDto, WProductsB2BDetailsGetAction.WProductsDetailsGetActionResponseDto>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsDetailsGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品编码
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.WID <= 0) yield return new RequestDtoValidatorResultError("WID");
                if (this.ProductId <= 0) yield return new RequestDtoValidatorResultError("ProductId");
            }
        }

        /// <summary>
        /// 下送的数据
        /// </summary>
        public class WProductsDetailsGetActionResponseDto
        {
            /// <summary>
            /// 当前商品
            /// </summary>
            public ProductInfo CurrentProduct { get; set; }

            /// <summary>
            /// 属性规格信息（此规格属性为动态生成）
            /// </summary>
            public List<Attribute> Attributes { get; set; }

            /// <summary>
            /// 当前商品的兄弟商品（包含自己)
            /// </summary>
            public List<ProductInfo> SubProducts { get; set; }

        }

        /// <summary>
        /// 属性
        /// </summary>
        public class Attribute
        {
            /// <summary>
            /// 属性ID
            /// </summary>
            public int AttributeId { get; set; }

            /// <summary>
            /// 属性名称
            /// </summary>
            public string AttributeName { get; set; }

            /// <summary>
            /// 属性值集合
            /// </summary>
            public List<AttributeValue> Values { get; set; }
        }

        /// <summary>
        /// 属性值对象
        /// </summary>
        public class AttributeValue : IEquatable<AttributeValue>
        {
            /// <summary>
            /// 属性值编号
            /// </summary>
            public int ValuesId { get; set; }

            /// <summary>
            /// 属性值
            /// </summary>
            public string ValueStr { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public bool Equals(AttributeValue other)
            {
                return this.ValuesId == other.ValuesId && this.ValueStr == other.ValueStr;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return this.ValuesId.GetHashCode() ^ this.ValueStr.GetHashCode();
            }
        }

        /// <summary>
        /// 商品信息对象
        /// </summary>
        public class ProductInfo
        {
            /// <summary>
            /// 商品运营分类；祖父节点,如：食品-->酒类-->白酒
            /// </summary>
            public List<ShopCategories> ShopCategories { get; set; }

            /// <summary>
            /// 商品信息
            /// </summary>
            public Products Product { get; set; }

            /// <summary>
            /// 商品头信息
            /// </summary>
            public BaseProducts BaseProduct { get; set; }

            /// <summary>
            /// 当前仓库商品信息
            /// </summary>
            public WProducts WProduct { get; set; }

            /// <summary>
            /// 当前商品属性
            /// </summary>
            public List<ProductsAttributes> ProductAttributes { get; set; }

            /// <summary>
            /// 当前商品规格图片
            /// </summary>
            public ProductsAttributesPicture AttributePicture { get; set; }

            /// <summary>
            /// 商品描述
            /// </summary>
            public ProductsDescription Description { get; set; }

            /// <summary>
            /// 商品描述图片详情
            /// </summary>
            public List<ProductsDescriptionPicture> DescriptionPictures { get; set; }

            /// <summary>
            /// 商品图片详情
            /// </summary>
            public List<ProductsPictureDetail> PictureDetails { get; set; }

            /// <summary>
            /// 条形码
            /// </summary>
            public List<ProductsBarCodes> ProductsBarCodes { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        private ProductInfo GetProductInfo(int wid, int productId)
        {
            //获取仓库商品信息
            var wproduct = DALFactory.GetLazyInstance<IWProductsDAO>().GetModel(
                new Dictionary<string, object>().Append("WID", wid)
                .Append("ProductId", productId)
                .Append("WStatus", 1));
            //仓库商品不存在
            if (wproduct.IsNull())
            {
                return null;
            }
            //商品总库商品信息
            var product = DALFactory.GetLazyInstance<IProductsDAO>().GetModel(productId);
            //商品基础信息
            var baseProduct = DALFactory.GetLazyInstance<IBaseProductsDAO>().GetModel(product.BaseProductId);
            //规格属性图
            var attributePicture = DALFactory.GetLazyInstance<IProductsAttributesPictureDAO>().GetModel(productId);
            //规格属性集合
            var productAttributes =
                DALFactory.GetLazyInstance<IProductsAttributesDAO>()
                    .GetList(new Dictionary<string, object>().Append("ProductId", productId))
                    .ToList();
            //商品描述
            var description = DALFactory.GetLazyInstance<IProductsDescriptionDAO>().GetModel(product.BaseProductId);
            //主图
            var pictureDetails =
                DALFactory.GetLazyInstance<IProductsPictureDetailDAO>()
                    .GetList(new Dictionary<string, object>().Append("ImageProductId", product.ImageProductId))
                    .ToList();
            //描述图片
            var descriptionPictures =
                DALFactory.GetLazyInstance<IProductsDescriptionPictureDAO>()
                    .GetList(new Dictionary<string, object>().Append("BaseProductId", product.BaseProductId))
                    .ToList();
            //条码
            var productsBarCodes =
                DALFactory.GetLazyInstance<IProductsBarCodesDAO>()
                    .GetList(new Dictionary<string, object>().Append("ProductId", productId))
                    .ToList();

            //运营分类
            var shopCategorys = DALFactory.GetLazyInstance<IShopCategoriesDAO>()
                .GetParents(baseProduct.ShopCategoryId3).ToList();

            //商品大对象数据
            return new ProductInfo()
            {
                ShopCategories = shopCategorys,
                Product = product,
                BaseProduct = baseProduct,
                WProduct = wproduct,
                AttributePicture = attributePicture,
                ProductAttributes = productAttributes,
                Description = description,
                PictureDetails = pictureDetails,
                DescriptionPictures = descriptionPictures,
                ProductsBarCodes = productsBarCodes
            };
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<WProductsDetailsGetActionResponseDto> Execute()
        {
            //当前仓库商品信息
            var currentProduct = this.GetProductInfo(this.RequestDto.WID, this.RequestDto.ProductId);
            if (currentProduct.IsNull())
            {
                return this.ErrorActionResult("仓库商品不存在");
            }

            //获取到商品兄弟商品信息
            var subProducts = DALFactory.GetLazyInstance<IWProductsDAO>()
                .GetSubProductIds(this.RequestDto.WID, this.RequestDto.ProductId);

            //兄弟商品信息
            List<ProductInfo> subProductInfos =
                subProducts.Select(p => this.GetProductInfo(this.RequestDto.WID, p.ProductId))
                    .Where(product => !product.IsNull())
                    .ToList();

            //获取所有兄弟商品的属性集合
            List<ProductsAttributes> productAttributes = new List<ProductsAttributes>();
            subProductInfos.ForEach(o =>
            {
                o.ProductAttributes.ForEach(x =>
                {
                    productAttributes.Add(x);
                });
            });

            //动态组合属性规格集合
            var q = productAttributes.IsEmpty()
                ? new List<Attribute>()
                : (from item in productAttributes
                   group item by item.AttributeName
                       into g
                       select new Attribute()
                       {
                           AttributeName = g.Key,
                           AttributeId = g.FirstOrDefault().AttributeId,
                           Values = (from x in g
                                     select new AttributeValue()
                                     {
                                         ValuesId = x.ValuesId,
                                         ValueStr = x.ValueStr
                                     }).Distinct().ToList()
                       }).ToList();

            //输出数据
            var responseDto = new WProductsDetailsGetActionResponseDto()
            {
                CurrentProduct = currentProduct,
                SubProducts = subProductInfos,
                Attributes = q
            };

            //返回数据
            return this.SuccessActionResult(responseDto);
        }
    }
}
