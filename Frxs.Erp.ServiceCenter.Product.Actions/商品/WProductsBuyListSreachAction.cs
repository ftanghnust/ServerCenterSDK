using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.IOCFactory;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取网仓商品信息
    /// </summary>
    [ActionName("WProductsBuy.ListSreach")]
    public class WProductsBuyListSreachAction : ActionBase<WProductsBuyListSreachAction.WProductsBuyListSreachRequestDto, IList<WProductsBuyQModel>>
    {
        public class WProductsBuyListSreachRequestDto:RequestDtoBase
        {
            /// <summary>
            /// 仓库ID
            /// </summary>
            public int WID { get; set; }

            /// <summary>
            /// 商品ID
            /// </summary>
            public IList<int> PDList{get;set;}
        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<WProductsBuyQModel>> Execute()
        {
            if (this.RequestDto == null || this.RequestDto.WID <= 0 || this.RequestDto.PDList == null || this.RequestDto.PDList.Count == 0)
            {
                return this.ErrorActionResult("输入参数错误！");
            }
            System.Collections.Generic.IList<WProductsBuyQModel> wpblist = DALFactory.GetLazyInstance<IWProductsBuyDAO>().GetWProductsBuyList(this.RequestDto.WID, this.RequestDto.PDList);       
            //加工将包装单位详情获取出来
            return this.SuccessActionResult(wpblist);
        }
    }
}
