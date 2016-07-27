using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// 新增或者修改商品描述
    /// </summary>
    [ActionName("ProductsDescriptionAndPicture.AddOrEdit")]
    public class ProductsDescriptionAndPictureAddOrEditAction : ActionBase<ProductsDescriptionAndPictureAddOrEditRequestDto, NullResponseDto>
    {
        public override ActionResult<NullResponseDto> Execute()
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
                if (product.BaseProductId <= 0)
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

            ICollection<ProductsDescriptionPicture> pics = new Collection<ProductsDescriptionPicture>();
            if (obj.ProductsDescriptionPicture != null)
            {
                foreach (var productsDescriptionPicture in obj.ProductsDescriptionPicture)
                {
                    var pic = productsDescriptionPicture.MapTo<ProductsDescriptionPicture>(false, true);
                    pic.BaseProductId = obj.BaseProductId;
                    pic.CreateTime = DateTime.Now;
                    pic.CreateUserID = obj.UserId;
                    pic.CreateUserName = obj.UserName;
                    pics.Add(pic);
                }
            }

            var des = obj.MapTo<ProductsDescription>(false, true);
            des.ModifyTime = DateTime.Now;
            des.ModifyUserID = obj.UserId;
            des.ModifyUserName = obj.UserName;

            var data = ProductsDescriptionBLO.AddProductsDescriptionAndPicture(obj.BaseProductId, des, pics);
            if (!data.IsSuccess)
            {
                return ErrorActionResult(data.Message);
            }

            this.CacheManager.Remove(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTDESCRIPTION_KEY.With(obj.BaseProductId));
            this.CacheManager.Remove(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCTSDESCRIPTIONPICTURES_LIST_KEY.With(obj.BaseProductId));
            return SuccessActionResult("编辑母商品图文详情成功", null);
        }
    }
}
