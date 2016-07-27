using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public  class SaleOrderPreShelfAreaRequestDto : RequestDtoParent
    {

        #region 模型
        /// <summary>
        /// 主键ID(WID + GUID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 订单编号(SaleOrder.OrderID)
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 周转箱数(预留)
        /// </summary>
        public int? Package1Qty { get; set; }

        /// <summary>
        /// 纸箱数(预留)
        /// </summary>
        public int? Package2Qty { get; set; }

        /// <summary>
        /// 易碎品箱数(预留)
        /// </summary>
        public int? Package3Qty { get; set; }

        /// <summary>
        /// 备注(预留)
        /// </summary>
        public int? Remark { get; set; }

        /// <summary>
        /// 货架号区号ID
        /// </summary>
        public int ShelfAreaID { get; set; }

        /// <summary>
        /// 仓库货区编号(数据字典：ShelfAreaCode)
        /// </summary>
        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区名称
        /// </summary>
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 拣货人员ID
        /// </summary>
        public int? PickUserID { get; set; }

        /// <summary>
        /// 拣货人员名称
        /// </summary>
        public string PickUserName { get; set; }

        /// <summary>
        /// 开始拣货时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 完成拣货时间
        /// </summary>
        public DateTime? EndTime { get; set; }

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
