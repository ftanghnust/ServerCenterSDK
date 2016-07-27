using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{

    /// <summary>
    /// 修改母商品
    /// </summary>
    [ActionName("BaseProduct.EditName")]
    public class BaseProductNameEditRequest : ActionBase<BaseProductNameEditRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            //反序列化
            var obj = this.RequestDto;
            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(obj.ProductId), ()
                => ProductsBLO.ProductsGet(obj.ProductId));

            if (null == product)
            {
                return ErrorActionResult("没有找到这个商品信息");
            }

            var baseProduct = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(product.BaseProductId), () => BaseProductsBLO.GetModel(product.BaseProductId, false));
            if (null == baseProduct)
            {
                return ErrorActionResult("找不到商品的商品信息");
            }

            if (baseProduct.IsBaseProductId == 0)
            {
                return ErrorActionResult("修改出错，这不是一个母商品");
            }

            baseProduct.ModifyTime = DateTime.Now;
            baseProduct.ModifyUserID = obj.UserId;
            baseProduct.ModifyUserName = obj.UserName;
            baseProduct.ProductBaseName = string.IsNullOrEmpty(obj.BaseProductName) ? "" : obj.BaseProductName.Trim();


            if (BaseProductsBLO.ExistProductBaseName(baseProduct))
            {
                return ErrorActionResult("母商品名已被使用");
            }

            var data = BaseProductsBLO.Edit(baseProduct);
            if (data.Data > 0)
            {
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_BASEPRODUCT_KEY.With(baseProduct.BaseProductId));
                return SuccessActionResult("修改母商品信息成功", baseProduct.BaseProductId);
            }
            return ErrorActionResult(data.Message);

        }
    }
}
