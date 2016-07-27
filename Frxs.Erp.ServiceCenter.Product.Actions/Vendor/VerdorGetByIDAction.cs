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
    /// 查询当前供应商详情
    /// </summary>
    [ActionName("Vendor.GetByID")]
    public class VerdorGetByIDAction : ActionBase<VerdorGetByIDActionRequestDto, Model.Vendor>
    {

        public override ActionResult<Model.Vendor> Execute()
        {            
            if (this.RequestDto==null || this.RequestDto.VendorID <= 0)
            {
                throw new Exception("查询供应商ID有误！");
            }

            int vendorID = this.RequestDto.VendorID;

            Model.Vendor model = VendorBLO.GetModel(vendorID);
            if (model != null)
            {
                return this.SuccessActionResult(model);
            }
            return this.ErrorActionResult(string.Format("查询不到ID={0}的供应商信息！",vendorID));
        }
    }
}
