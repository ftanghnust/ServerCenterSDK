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
    /// 保存供应商分类
    /// </summary>
    [ActionName("VendorType.Save")]
    class VendorTypeSaveAction : ActionBase<VendorTypeSaveRequestDto, int>
    {
        /// <summary>
        /// 执行业务逻辑 保存数据
        /// </summary>
        /// <returns></returns>
        public override ActionResult<int> Execute()
        {
            if (this.RequestDto == null || string.IsNullOrWhiteSpace(this.RequestDto.VendorTypeName))
            {
                return this.ErrorActionResult("上送的参数不对!");
            }
            Model.VendorType model = new Model.VendorType();
            model.VendorTypeName = RequestDto.VendorTypeName;
            model.ModifyUserID = RequestDto.UserId;
            model.ModifyUserName = RequestDto.UserName;

            if (RequestDto.Flag == 0)
            {
                model.CreateUserID = RequestDto.UserId;
                model.CreateUserName = RequestDto.UserName;
                model.IsDeleted = 0;
                model.VendorTypeID = 0;
                if (VendorTypeBLO.Exists(model))
                {
                    return this.ErrorActionResult("存在相同的记录!");
                }
                VendorTypeBLO.Save(model);
                return this.SuccessActionResult("添加供应商分类成功!", 1);
            }
            else
            {
                model.VendorTypeID = RequestDto.VendorTypeID;
                if (VendorTypeBLO.Exists(model))
                {
                    return this.ErrorActionResult("分类名称已经存在!");
                }
                VendorTypeBLO.Edit(model);
                return this.SuccessActionResult("修改供应商分类成功!", 1);
            }
        }
    }
}
