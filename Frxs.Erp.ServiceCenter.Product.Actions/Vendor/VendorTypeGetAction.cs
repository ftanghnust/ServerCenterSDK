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
    [ActionName("VendorType.Get")]
    class VendorTypeGetAction : ActionBase<VendorTypeGetRequestDto, Model.VendorType>
    {

        /// <summary>
        /// 执行业务逻辑 返回VendorType对象
        /// </summary>
        /// <returns></returns>
        public override ActionResult<Model.VendorType> Execute()
        {
            if (this.RequestDto == null || this.RequestDto.VendorTypeID <= 0)
            {
                return this.ErrorActionResult(string.Format("上送参数有误!"));
            }

            int VendorTypeID = this.RequestDto.VendorTypeID;

            Model.VendorType model = VendorTypeBLO.GetModel(VendorTypeID);
            if (model != null)
            {
                return this.SuccessActionResult(model);
            }
            return this.ErrorActionResult(string.Format("查询不到ID={0}的供应商分类信息！", VendorTypeID));
        }

    }
}
