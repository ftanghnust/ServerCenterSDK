using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取商品描述信息
    /// </summary>
    [ActionName("ProductsDescription.Get")]
    public class ProductsDescriptionAndPictureGetAction : ActionBase<ProductsDescriptionAndPictureGetRequestDto, ProductsDescriptionAndPictureGetAction.ProductsDescriptionAndPictureGetResponseDto>
    {
        /// <summary>
        /// 输出商品图文详情
        /// </summary>
        public class ProductsDescriptionAndPictureGetResponseDto
        {
            /// <summary>
            /// 商品编号
            /// </summary>
            public int ProductId { get; set; }


            /// <summary>
            /// 母商品编号
            /// </summary>
            public int BaseProductId { get; set; }

            /// <summary>
            /// 商品描述
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 母商品图文
            /// </summary>
            public ICollection<ProductsDescriptionPicture> ProductsDescriptionPicture { get; set; }

        }

        /// <summary>
        /// 执行逻辑
        /// 返回的图文详情信息：
        /// 1、都关联到母商品编号上
        /// 2、MODEL层不做其他操作，只做单个表单操作，这样功能清晰明了
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ProductsDescriptionAndPictureGetResponseDto> Execute()
        {
            //反序列化
            var obj = this.RequestDto;
            if (obj.BaseProductId <= 0)
            {
                if (obj.ProductId <= 0)
                {
                    return ErrorActionResult("没有指定母商品");
                }
                var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(obj.ProductId), ()
                    => ProductsBLO.ProductsGet(obj.ProductId));
                if (product == null)
                {
                    return ErrorActionResult("没有指定母商品");
                }
                obj.BaseProductId = product.BaseProductId;
            }

            var baseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(obj.BaseProductId), () =>
                                                        BaseProductsBLO.GetModel(obj.BaseProductId, false));

            if (baseProduct == null)
            {
                return ErrorActionResult("没有这个母商品");
            }
            #region 从缓存中取到的母商品中不包含附属信息，需另行读取
            var description = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTDESCRIPTION_KEY.With(baseProduct.BaseProductId), () =>
                                                   ProductsDescriptionBLO.ProductsDescriptionGet(baseProduct.BaseProductId));


            var descriptionsPictures = this.CacheManager.GetList(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTSDESCRIPTIONPICTURES_LIST_KEY.With(baseProduct.BaseProductId), () =>
                                                    ProductsDescriptionPictureBLO.ProductsDescriptionPictureGet(baseProduct.BaseProductId)).OrderBy(x => x.OrderNumber);


            #endregion 从缓存中取到的母商品中不包含附属信息，需另行读取

            ProductsDescriptionAndPictureGetResponseDto data = new ProductsDescriptionAndPictureGetResponseDto()
                                                                   {
                                                                       BaseProductId = baseProduct.BaseProductId,
                                                                       ProductId = obj.ProductId,
                                                                       Description = description != null ? description.Description : "",
                                                                       ProductsDescriptionPicture = descriptionsPictures.Any() ? descriptionsPictures.ToList() : null
                                                                   };
            return SuccessActionResult(data);

        }
    }
}
