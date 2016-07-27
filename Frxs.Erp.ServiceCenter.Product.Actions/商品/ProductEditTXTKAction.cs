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
    /// 商品修改天下图库编号
    /// </summary>
    [ActionName("Product.EditTXTK")]
    public class ProductEditTXTKAction : ActionBase<ProductsEditTxtkRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            //反序列化
            var obj = this.RequestDto;
            var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(obj.ProductId), ()
                   => ProductsBLO.ProductsGet(obj.ProductId));
            if (null == product)
            {
                return ErrorActionResult("商品不存在,不能修改天下图库编号");
            }

            Guid guid;
            if (!string.IsNullOrWhiteSpace(product.TXTKID))
            {
                if (Guid.TryParse(product.TXTKID, out guid))
                {
                    if (!guid.Equals(Guid.Empty))
                    {
                        return ErrorActionResult("本商品已存在天下图库编号");
                    }
                }
            }
            if (!Guid.TryParse(obj.Txtkid, out guid))
            {
                return ErrorActionResult("传入的天下图库编号错误");
            }

            product.TXTKID = obj.Txtkid;
            product.ModifyTime = DateTime.Now;
            product.ModifyUserID = obj.UserId;
            product.ModifyUserName = obj.UserName;
            ProductsBLO.Edit(product);

            this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(product.ProductId));
            return SuccessActionResult("修改天下图库编号成功", null);

        }
    }
}
