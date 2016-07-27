using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor
{
    
    /// <summary>
    ///  Vendor.Del
    /// </summary>
    public class VendorDelRequest : RequestDtoBase
    {
        /// <summary>
        /// 供应商编号
        /// </summary>       
        public string VendorIDs { get; set; }

    }

    /// <summary>
    ///  Vendor.Del
    /// </summary>
    public class VendorIsFrozenRequest : RequestDtoBase
    {
        /// <summary>
        /// 供应商编号
        /// </summary>       
        public string VendorIDs { get; set; }

        /// <summary>
        /// 是否冻结(0:未冻结;1:已冻结)
        /// </summary>       
        public int Status { get; set; }
    }
}
