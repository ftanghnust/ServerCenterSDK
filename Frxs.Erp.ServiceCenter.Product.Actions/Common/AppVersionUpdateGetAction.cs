using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Api.Core;
using System.ComponentModel.DataAnnotations;
using Frxs.Erp.ServiceCenter.Product.BLL;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions.Common
{

    public class AppVersionUpdateGetRequest : RequestDtoBase
    {
        public int SysType{get;set;}
        /// <summary>
        /// AppType:(0:订货平台；1:拣货APP;2:配送APP;3:装箱APP;4:采购APP)
        /// </summary>
        public int AppType { get; set; }
    }

    [ActionName("AppVersion.UpdateGet")]
    public class AppVersionUpdateGetAction : ActionBase<AppVersionUpdateGetRequest, AppVersionModel>
    {

        public override ActionResult<AppVersionModel> Execute()
        {            
            var req = this.RequestDto;          
            var res = AppVersionBLO.GetUpdateModel(req.SysType, req.AppType);
            return this.SuccessActionResult(res);
        }
    }
}
