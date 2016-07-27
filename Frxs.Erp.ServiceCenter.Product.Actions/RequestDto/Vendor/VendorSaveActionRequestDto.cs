using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor
{
    public class VendorSaveActionRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 请求主数据
        /// </summary>
        public Frxs.Erp.ServiceCenter.Product.Model.Vendor Data { get; set; }
    }
}
