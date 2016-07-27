using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor
{
    public class VerdorGetByIDActionRequestDto : RequestDtoBase
    {
        #region 模型
        /// <summary>
        /// 供应商分类ID
        /// </summary>
        [DisplayName("供应商分类ID")]
        public int VendorID { get; set; }
        #endregion
    }
}
