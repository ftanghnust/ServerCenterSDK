using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor
{
    /// <summary>
    /// 供应商分类 保存方法请求对象
    /// </summary>
    class VendorTypeSaveRequestDto : RequestDtoBase
    {
        
        /// <summary>
        /// 0表示新增 1表示修改
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// 供应商分类ID
        /// </summary>        
        [Required(ErrorMessage = "{0}不能为空")]
        public int VendorTypeID { get; set; }

        /// <summary>
        /// 供应商分类名称
        /// </summary>       
        [Required(ErrorMessage = "{0}不能为空")]
        public string VendorTypeName { get; set; }
    }
}
