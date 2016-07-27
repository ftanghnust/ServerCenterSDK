using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/15 19:54:05
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
    /// 获取仓库商品采购价集合
    /// </summary>
    [ActionName("WProductsBuy.Get")]
    public class WProductsBuyGetAction : ActionBase<WProductsBuyGetAction.WProductsBuyGetActionRequestDto, List<Model.WProductsBuyQModel>>
    {
        /// <summary>
        /// 上送的参数对象
        /// </summary>
        public class WProductsBuyGetActionRequestDto : RequestDtoBase
        {
            /// <summary>
            /// 仓库编号
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品ID集合
            /// </summary>
            [Required, NotEmpty]
            public List<int> ProductIds { get; set; }
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<Model.WProductsBuyQModel>> Execute()
        {
            var wProductsBuys = DALFactory.GetLazyInstance<IWProductsBuyDAO>().GetWProductsBuyList(this.RequestDto.WID, this.RequestDto.ProductIds);
            return this.SuccessActionResult(wProductsBuys.ToList());
        }

    }
}
