using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) chujl 2016/4/10 16:51:17
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
    /// 获取网仓商品信息 ，增加部分扩展信息
    /// </summary>
    [ActionName("WProducts.Get.ByIDs.Ext")]
    public class WProductsGetByIDsExtAction : ActionBase<WProductsGetByIDsExtAction.WProductsGetByIDsExtActionRequestDto, IList<Model.WProductExt>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsGetByIDsExtActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号，必须填写
            /// </summary>
            [Required]
            public int WID { get; set; }

            /// <summary>
            /// 商品ID，必须填写 格式"1,2,3,4,5"
            /// </summary>
            public IList<int> ProductIds { get; set; }

            /// <summary>
            /// 商品SKU，必须填写 格式"1,2,3,4,5"
            /// </summary>
            public IList<string> ProductSKUs { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<Model.WProductExt>> Execute()
        {
            
                var searchCondition = new Dictionary<string, object>()
                    .Append("WID", this.RequestDto.WID);
                if (this.RequestDto.ProductIds != null)
                {
                    var productIds = string.Join(",", this.RequestDto.ProductIds);
                    //查询条件
                    searchCondition.Append("ProductIDs", productIds);
                }
                if (this.RequestDto.ProductSKUs != null)
                {
                    var productSKUs = string.Join(",", this.RequestDto.ProductSKUs);
                    //查询条件
                    searchCondition.Append("ProductSKUs", productSKUs);
                }

            //仓商品集合
            IList<Model.WProductExt> wProductList = DALFactory.GetLazyInstance<IWProductsDAO>().GetListByIDsExt(searchCondition);
          
            return this.SuccessActionResult(wProductList);
        }
    }
}
