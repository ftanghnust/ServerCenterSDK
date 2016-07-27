using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Vendor
{
    /// <summary>
    /// 获取某个仓库下的商品最后一次进货的供应商信息集合
    /// </summary>
    [ActionName("Vendor.LastBuy.Get")]
    public class VendorLastBuyGetAction : ActionBase<VendorLastBuyGetAction.VendorLastBuyActionRequestDto, List<Model.VendorLastBuy>>
    {
        /// <summary>
        /// 上送参数
        /// </summary>
        public class VendorLastBuyActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库ID
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品ID集合，若不传，则返回当前仓库的所有商品的最后一次采购的供应商信息
            /// </summary>
            public IList<int> ProductIds { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<Model.VendorLastBuy>> Execute()
        {
            if (this.RequestDto == null || this.RequestDto.WID <= 0)
            {
                return this.ErrorActionResult("仓库ID有误！");
            }
            List<Model.VendorLastBuy> list = new List<Model.VendorLastBuy>();
            if (RequestDto.ProductIds != null && RequestDto.ProductIds.Count > 0)
            {
                list = VendorBLO.GetLastBuyVendors(RequestDto.WID, RequestDto.ProductIds).ToList();
            }
            else
            {
                list = VendorBLO.GetLastBuyVendors(RequestDto.WID).ToList();
            }
            if (list == null || list.Count <= 0)
            {
                return this.ErrorActionResult(string.Format("查询不到ID={0}的供应商信息！", RequestDto.WID));
            }
            return this.SuccessActionResult(list);
        }
    }
}
