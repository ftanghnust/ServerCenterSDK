using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleEditOrderRequestDto : RequestDtoParent
    {
        #region 模型
        /// <summary>
        /// 主键ID(WID+GUID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 改单ID（GUID)
        /// </summary>
        public string EditID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int ShopID { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        public string ShopCode { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 配送时间
        /// </summary>
        public DateTime SendDate { get; set; }


        #endregion
    }
}
