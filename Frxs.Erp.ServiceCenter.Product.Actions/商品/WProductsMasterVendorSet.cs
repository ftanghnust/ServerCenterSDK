using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/5 10:09:38
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 设置仓库商品主供应商;操作成功后返回主供应商ID
    /// </summary>
    [ActionName("WProducts.MasterVendor.Set")]
    public class WProductsMasterVendorSet : ActionBase<WProductsMasterVendorSet.WProductsMasterVendorSetRequestDto, int?>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsMasterVendorSetRequestDto : RequestDtoBase, IRequiredUserIdAndUserName
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品编号
            /// </summary>
            public int ProductId { get; set; }

            /// <summary>
            /// 主供应商编号
            /// </summary>
            public int VendorID { get; set; }

            /// <summary>
            /// 自定义校验上送参数是否正确
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<RequestDtoValidatorResultError> Valid()
            {
                if (this.ProductId <= 0) yield return new RequestDtoValidatorResultError("ProductId");
                if (this.VendorID <= 0) yield return new RequestDtoValidatorResultError("VendorID");
                if (this.WID <= 0) yield return new RequestDtoValidatorResultError("WID");
            }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int?> Execute()
        {
            //获取仓库商品
            IWProductsDAO iWProducts = DALFactory.GetLazyInstance<IWProductsDAO>();
            IWProductsBuyDAO iWProductsBuyDAO = DALFactory.GetLazyInstance<IWProductsBuyDAO>();
            var wproduct = iWProducts.GetModel(new Dictionary<string, object>().Append("WID", this.RequestDto.WID).Append("ProductId", this.RequestDto.ProductId));
            var wproductBuy = iWProductsBuyDAO.GetModel(new Dictionary<string, object>().Append("WID", this.RequestDto.WID).Append("ProductId", this.RequestDto.ProductId));

            //商品不存在
            if (wproduct.IsNull())
            {
                return this.ErrorActionResult("商品不存在");
            }

            //获取仓库商品供应商集合
            IProductsVendorDAO iProductsVendor = DALFactory.GetLazyInstance<IProductsVendorDAO>();
            var productsVendors = iProductsVendor.GetList(new Dictionary<string, object>().Append("WID", this.RequestDto.WID).Append("ProductId", this.RequestDto.ProductId));

            //传入的供应商编号是否在商品供应商里面
            var item = productsVendors.FirstOrDefault(o => o.VendorID == this.RequestDto.VendorID);
            if (item.IsNull())
            {
                return this.ErrorActionResult("供应商传入错误，商品没有此供应商信息");
            }

            //循环修改
            foreach (var productsVendor in productsVendors)
            {
                iProductsVendor.IsMasterUpdate(productsVendor.ID, productsVendor.VendorID == this.RequestDto.VendorID ? 1 : 0);
            }

            //更新仓库商品主供应商
            //iWProducts.VendorIDUpdate(wproduct.WProductID, this.RequestDto.VendorID);
            wproductBuy.VendorID = this.RequestDto.VendorID;
            iWProductsBuyDAO.Edit(wproductBuy);

            //设置成功
            return this.SuccessActionResult(this.RequestDto.VendorID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            //删除匹配到的缓存键
            this.CacheManager.RemoveByPattern(WProductsCacheKey.FRXS_WPRODUCTS_PATTERN_KEY);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
