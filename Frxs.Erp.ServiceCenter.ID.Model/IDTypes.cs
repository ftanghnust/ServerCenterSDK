using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.ID.Model
{
    /// <summary>
    /// 获取ID类型
    /// </summary>
    public enum IDTypes
    {
        /// <summary>
        /// 采购退货单据服务ID表
        /// </summary>
        BuyBack=0,

        /// <summary>
        /// 采购单据服务ID表
        /// </summary>
        BuyOrder=1,

        /// <summary>
        /// 库存盘点库单据服务ID表
        /// </summary>
        CheckStock=2,

        /// <summary>
        /// 库存盘点库计划单据服务ID表
        /// </summary>
        CheckStockPlan=3,

        /// <summary>
        /// 销售库费用单据服务ID表2
        /// </summary>
        FeeID=4,
        /// <summary>
        /// 销售库退货单据服务ID表
        /// </summary>
        SaleBack=5,

        /// <summary>
        /// 销售库销售订单修改服务ID表
        /// </summary>
        SaleEdit=6,
        /// <summary>
        /// 销售库单据服务ID表(预订，订单，共用)
        /// </summary>
        SaleOrder=7,

        /// <summary>
        /// 销售库结算单据服务ID表
        /// </summary>
        SaleSettle=8,

        /// <summary>
        /// 库存盘点库调整服务ID表
        /// </summary>
        StockAdj=9,

        /// <summary>
        /// 基础通用单据编号
        /// </summary>
        BaseInfoID=10,

        /// <summary>
        /// 货位调整单
        /// </summary>
        ShelfAdjust=11
    }
}
