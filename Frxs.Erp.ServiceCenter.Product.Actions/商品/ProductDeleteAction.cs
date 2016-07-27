using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 删除商品库商品接口
    /// </summary>
    [ActionName("Product.Delete")]
    public class ProductDeleteAction : ActionBase<ProductDeleteRequestDto, NullResponseDto>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<NullResponseDto> Execute()
        {
            var obj = this.RequestDto;
            if (obj.ProductIds != null)
            {
                var productList = new List<Products>();
                foreach (var productId in obj.ProductIds)
                {
                    var product = this.CacheManager.Get(Frxs.Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(productId), () => ProductsBLO.ProductsGet(productId));
                    if (null == product) continue;
                    if (product.ProductId == product.BaseProductId)
                    {
                        var products = ProductsBLO.ProductsGetByBaseProductId(product.BaseProductId);
                        if (products != null)
                        {
                            if (products.Any(productse => productse.ProductId != product.ProductId))
                            {
                                return ErrorActionResult("商品[" + product.ProductName + "]本身为母商品，且母商品下还包含其他的子商品，不能删除");
                            }
                        }
                    }

                    //本商品被 仓库引用，不能删除
                    IDictionary<string, object> conditionDict = new Dictionary<string, object>();
                    conditionDict.Add("ProductId", product.ProductId);
                    IList<WProducts> list = DALFactory.GetLazyInstance<IWProductsDAO>().GetList(conditionDict);
                    if (list != null && list.Count > 0)
                    {
                        WProducts wp = list.FirstOrDefault(i => i.WStatus != 0);
                        if (wp != null)
                        {
                            return ErrorActionResult("商品[" + product.ProductName + "]已被仓库引用，不能删除");
                        }
                    }

                    product.ModifyTime = DateTime.Now;
                    product.ModifyUserID = obj.UserId;
                    product.ModifyUserName = obj.UserName;
                    productList.Add(product);
                }
                var flag = ProductsBLO.ProductsDelete(productList);
                if (!flag.IsSuccess)
                {
                    return ErrorActionResult(flag.Message);
                }

                foreach (var productId in productList)
                {
                    this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCT_KEY.With(productId.ProductId));
                    this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTPICTUREDETAILS_LIST_KEY.With(productId.ImageProductId));
                    this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTES_LIST_KEY.With(productId.ProductId));
                    this.CacheManager.Remove(Platform.Utility.ConstDefinition.CACHE_PRODUCTATTRIBUTEPICTURE_KEY.With(productId.ProductId));
                }
            }
            return SuccessActionResult("删除商品成功", null);

        }
    }
}
