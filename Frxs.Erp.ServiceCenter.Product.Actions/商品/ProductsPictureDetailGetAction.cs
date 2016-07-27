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
    /// 取商品主图列表
    /// </summary>
    [ActionName("ProductsPictureDetail.Get")]
    public class ProductsPictureDetailGetAction : ActionBase<ProductsPictureDetailGetRequestDto, ProductsPictureDetailGetAction.ProductsPictureDetailGetResponseDto>
    {
        /// <summary>
        /// 取得商品列表数据
        /// </summary>
        public class ProductsPictureDetailGetResponseDto
        {
            /// <summary>
            /// 
            /// </summary>
            public int IsBaseProductPicture { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public List<Model.ProductsPictureDetail> ProductsPictureDetailList { get; set; }


        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<ProductsPictureDetailGetResponseDto> Execute()
        {
            //直接从提交的data参数（JSON格式）反序列化出对应的传输对象(出现异常系统框架会自动处理)
            var dto = this.RequestDto;
            try
            {
                var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(dto.ProductId), ()
                        => ProductsBLO.ProductsGet(dto.ProductId));
                if (null == product)
                {
                    return ErrorActionResult("没有这个商品");
                }

                var imgs = this.CacheManager.GetList(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTPICTUREDETAILS_LIST_KEY.With(product.ImageProductId), () =>
                                                           ProductsPictureDetailBLO.ProductsPictureDetailsGet(product.ProductId)).OrderBy(x => x.OrderNumber);
                if (!imgs.Any())
                {
                    return ErrorActionResult("商品图片详情为空");
                }

                ProductsPictureDetailGetResponseDto data = new ProductsPictureDetailGetResponseDto
                                                               {
                                                                   IsBaseProductPicture = product.ImageProductId == product.ProductId ? 0 : 1,
                                                                   ProductsPictureDetailList = imgs.OrderBy(x => x.OrderNumber).ToList()
                                                               };

                return SuccessActionResult(data);
            }
            catch (Exception ex)
            {
                return this.ErrorActionResult(ex.Message);
            }
        }
    }
}
