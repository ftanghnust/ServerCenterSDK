using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.商品
{
    /// <summary>
    /// 根据条件查询网仓里的商品采购价格列表信息
    /// </summary>
    [ActionName("WProducts.Base.List.Get")]
    public class WProductBaseListGetAction : ActionBase<WProductBaseListGetAction.WProductsBaseListGetActionRequestDto,
        IList<WProductsBaseQueryModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsBaseListGetActionRequestDto : PageListRequestDto
        {
            /// <summary>
            /// 对应的仓库ID编号；此参数必须传入
            /// </summary>
     
            public int Wid { get; set; }

            /// <summary>
            /// 商品编号列表
            /// </summary>
            public IList<int> ProductIds { get; set; }
        }



        public override ActionResult<IList<WProductsBaseQueryModel>> Execute()
        {
            // 查询数据
            var productBaseServices = DALFactory.GetLazyInstance<IWProductsBaseDAO>();
            IList<WProductsBaseQueryModel> responseDto = productBaseServices.GetWProductsBaseList(this.RequestDto.Wid, this.RequestDto.ProductIds);
            return this.SuccessActionResult(responseDto);
        }

    }
}
