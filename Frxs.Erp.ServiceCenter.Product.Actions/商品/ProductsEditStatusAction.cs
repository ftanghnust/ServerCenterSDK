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
    /// 修改商品状态(总部商品状态(0:正常;1:冻结[冻结的商品不再采购,不能再销售]);2:淘汰[淘汰的商品不再采购,不能再销售]))
    /// </summary>
    [ActionName("Products.EditStatus")]
    public class ProductsEditStatusAction : ActionBase<ProductsEditStatusRequestDto, NullResponseDto>
    {

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //反序列化
            var obj = this.RequestDto;

            foreach (var productId in obj.ProductIds)
            {
                int id = productId;
                var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(productId), () => ProductsBLO.ProductsGet(id));
                if (null == product) continue;

                //一些业务逻辑

                product.Status = obj.Status;
                product.ModifyTime = DateTime.Now;
                product.ModifyUserID = obj.UserId;
                product.ModifyUserName = obj.UserName;
                ProductsBLO.Edit(product);
                this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.ProductId));
            }

            return SuccessActionResult("批量修改商品状态成功", null);

        }

    }
}
