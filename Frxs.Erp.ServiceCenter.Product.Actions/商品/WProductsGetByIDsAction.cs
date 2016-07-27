using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/24 16:51:17
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取网仓商品信息
    /// </summary>
    [ActionName("WProducts.Get.ByIDs")]
    public class WProductsGetByIDsAction : ActionBase<WProductsGetByIDsAction.WProductsGetByIDsActionRequestDto, IList<Model.WProducts>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsGetByIDsActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号，必须填写
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 商品ID，必须填写 格式"1,2,3,4,5"
            /// </summary>
            [Required]
            public IList<int> ProductIds { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<Model.WProducts>> Execute()
        {

            var productIds = string.Join(",", this.RequestDto.ProductIds);
            //查询条件
            var searchCondition = new Dictionary<string, object>()
                .Append("WID", this.RequestDto.WID)
                .Append("ProductIDs", productIds);

            //仓商品集合
            IList<Model.WProducts> wProductList = DALFactory.GetLazyInstance<IWProductsDAO>().GetListByIDs(searchCondition);
          
            return this.SuccessActionResult(wProductList);
        }
    }
}
