using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    /// <summary>
    /// 编辑单个明细订单接口
    /// </summary>
    public class OrderShopEditSingleRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; set; }


        /// <summary>
        /// 仓库ID
        /// </summary>
        public int? WID { get; set; }

        /// <summary>
        /// 编辑类型 0：添加 1：修改 2：删除
        /// </summary>
        public int EditType { get; set; }

        /// <summary>
        /// 商品明细
        /// </summary>
        public OrderDetailRequestDto Detail { get; set; }

        /// <summary>
        /// 商品明细扩展
        /// </summary>
        public OrderDetailExtsRequestDto DetailExt { get; set; }


       

    }
}
