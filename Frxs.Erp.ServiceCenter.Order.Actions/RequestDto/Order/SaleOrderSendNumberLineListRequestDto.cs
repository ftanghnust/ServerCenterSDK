using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleOrderSendNumberLineListRequestDto : RequestDtoParent
    {
        #region 模型
        /// <summary>
        /// 订单编号(SaleOrder.OrderID)
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 线路顺序(WarehouseLine.SerialNumber)
        /// </summary>
        public int LineSerialNumber { get; set; }

        /// <summary>
        /// 门店顺序(WarehouseLineShop.SerialNumber)
        /// </summary>
        public int ShopSerialNumber { get; set; }

        /// <summary>
        /// 手动调整顺序(置顶为1;置底为9999; 订单确认时默认值为999);
        /// </summary>
        public int SendNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public int? Remark { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        #endregion
    }
}
