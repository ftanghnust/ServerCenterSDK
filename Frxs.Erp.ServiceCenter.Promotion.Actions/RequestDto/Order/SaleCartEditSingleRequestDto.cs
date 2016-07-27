using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    public class SaleCartEditSingleRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 修改类型 0：add 1:edit 2:delete
        /// </summary>
        public int EditType { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 单条cart数据
        /// </summary>
        public SaleCartAddOrEditRequestDto Cart { get; set; }
    }
}
