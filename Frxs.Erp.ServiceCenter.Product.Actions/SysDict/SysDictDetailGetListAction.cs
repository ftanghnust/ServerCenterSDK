using Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions
{
    /// <summary>
    /// 获取供应商列表
    /// </summary>
    [ActionName("SysDictDetail.GetList")]
    public class SysDictDetailGetListAction : ActionBase<Frxs.Erp.ServiceCenter.Product.Actions.SysDictDetailGetListAction.SysDictDetailGetListRequest, IList<SysDictDetail>>
    {
        /// <summary>
        ///  Vendor.Del
        /// </summary>
        public class SysDictDetailGetListRequest : RequestDtoBase
        {                
            public string dictCode { get; set; }

        }

        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<IList<SysDictDetail>> Execute()
        {
            var dictCode = this.RequestDto.dictCode;
            if (!string.IsNullOrEmpty(dictCode))
            {
               return SuccessActionResult(SysDictDetailBLO.GetModelListByDictCode(dictCode));
            }
            return ArgumentNullErrorActionResult("dictCode");
        }
    }
}
