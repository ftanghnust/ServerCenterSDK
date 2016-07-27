using Frxs.ServiceCenter.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto.Vendor
{
    /// <summary>
    /// 供应商分类列表查询 请求对象
    /// </summary>
    public class VendorTypeTableListRequestDTO : PageListRequestDto
    {
        /// <summary>
        /// 供应商分类名称
        /// </summary>        
        public string VendorTypeName { get; set; }

        /// <summary>
        /// 是否删除(0:未删除;1:已删除); 空则查出所有的记录
        /// </summary>       
        public int? IsDeleted { get; set; }
    }
}
