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
    /// 获取供应商列表
    /// </summary>
    [ActionName("Vendor.Save")]
    public class VendorSaveAction : ActionBase<VendorSaveActionRequestDto, Model.Vendor>
    {
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.Vendor> Execute()
        {
            int result=0;
            var requestDto = this.RequestDto;

            //获取相同
            IList<int> lisds = VendorBLO.GetExitsVendorID(requestDto.Data.VendorCode, requestDto.Data.VendorName);

            if (requestDto.Data.VendorID == 0)
            {
                if (lisds != null && lisds.Count>0)
                {
                    return this.ErrorActionResult("已存其它相同编号或名称的供应商");
                }
                result = VendorBLO.Save(requestDto.Data);
                requestDto.Data.VendorID = result;
            }
            else
            {
                if (lisds != null && (lisds.Count > 1 || (lisds.Count == 1 && lisds[0] != requestDto.Data.VendorID)))
                {
                    return this.ErrorActionResult("已存其它相同编号或名称的供应商");
                }
                result = VendorBLO.Edit(requestDto.Data);          
            }
            if(result>0)
            {
                //保存
                return this.SuccessActionResult(requestDto.Data);
            }
            else
            {
                return this.ErrorActionResult("供应商保存出错");
            }            
        }
    }
}
