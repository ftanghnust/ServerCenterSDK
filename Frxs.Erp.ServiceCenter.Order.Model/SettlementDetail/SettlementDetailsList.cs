/*********************************************************
 * FRXS 小马哥 2016/6/24 10:41:17
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.Utility.Filter;

namespace Frxs.Erp.ServiceCenter.Order.Model
{
    /// <summary>
    /// 获取结算单详细清单和合计实体 龙武
    /// </summary>
    [Serializable]
    public partial class SettlementDetailsList : BaseModel
    {
        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageTotal { get; set; }

        /// <summary>
        /// 结算单详细集合
        /// </summary>
        public IList<SettlementDetail> SettDetail { get; set; }
        /// <summary>
        /// 结算单分页当前页集合
        /// </summary>
        public CurrentSum SettCurrentSum { get; set; }
        /// <summary>
        /// 结算单总合计
        /// </summary>
        public TotalSum SettTotalSum { get; set; }
    }

    /// <summary>
    /// 当前页合计
    /// </summary>
    [Serializable]
    public class CurrentSum
    {
        #region 模型
        /// <summary>
        /// 期初库存数量
        /// </summary>
        public decimal BeginQty { get; set; }
        /// <summary>
        /// 期初库存金额
        /// </summary>
        public decimal BeginAmt { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        public decimal BuyQty { get; set; }
        /// <summary>
        /// 采购金额
        /// </summary>
        public decimal BuyAmt { get; set; }
        /// <summary>
        /// 采购退货数量
        /// </summary>
        public decimal BuyBackQty { get; set; }
        /// <summary>
        /// 期初库存金额
        /// </summary>
        public decimal BuyBackAmt { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public decimal SaleQty { get; set; }
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal SaleAmt { get; set; }
        /// <summary>
        /// 销售退货数量
        /// </summary>
        public decimal SaleBackQty { get; set; }
        /// <summary>
        /// 销售退货金额
        /// </summary>
        public decimal SaleBackAmt { get; set; }
        /// <summary>
        /// 盘盈数量
        /// </summary>
        public decimal AdjGainQty { get; set; }
        /// <summary>
        /// 盘盈金额
        /// </summary>
        public decimal AjgGginAmt { get; set; }
        /// <summary>
        /// 盘亏数量
        /// </summary>
        public decimal AdjLossQty { get; set; }
        /// <summary>
        /// 盘亏金额
        /// </summary>
        public decimal AjgLosssAmt { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal StockQty { get; set; }
        /// <summary>
        /// 库存金额
        /// </summary>
        public decimal StockAmt { get; set; }
        /// <summary>
        /// 期末库存数量
        /// </summary>
        public decimal EndQty { get; set; }
        /// <summary>
        /// 期末库存金额
        /// </summary>
        public decimal EndStockAmt { get; set; }
        /// <summary>
        /// 差异数量
        /// </summary>
        public decimal EndDiffQty { get; set; }
        /// <summary>
        /// 差异金额
        /// </summary>
        public decimal EndDiffStockAmt { get; set; }
        #endregion
    }

    /// <summary>
    /// 总合计
    /// </summary>
    [Serializable]
    public class TotalSum
    {
        #region 模型
        /// <summary>
        /// 期初库存数量
        /// </summary>
        public decimal SumBeginQty { get; set; }
        /// <summary>
        /// 期初库存金额
        /// </summary>
        public decimal SumBeginAmt { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        public decimal SumBuyQty { get; set; }
        /// <summary>
        /// 采购金额
        /// </summary>
        public decimal SumBuyAmt { get; set; }
        /// <summary>
        /// 采购退货数量
        /// </summary>
        public decimal SumBuyBackQty { get; set; }
        /// <summary>
        /// 期初库存金额
        /// </summary>
        public decimal SumBuyBackAmt { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public decimal SumSaleQty { get; set; }
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal SumSaleAmt { get; set; }
        /// <summary>
        /// 销售退货数量
        /// </summary>
        public decimal SumSaleBackQty { get; set; }
        /// <summary>
        /// 销售退货金额
        /// </summary>
        public decimal SumSaleBackAmt { get; set; }
        /// <summary>
        /// 盘盈数量
        /// </summary>
        public decimal SumAdjGainQty { get; set; }
        /// <summary>
        /// 盘盈金额
        /// </summary>
        public decimal SumAjgGginAmt { get; set; }
        /// <summary>
        /// 盘亏数量
        /// </summary>
        public decimal SumAdjLossQty { get; set; }
        /// <summary>
        /// 盘亏金额
        /// </summary>
        public decimal SumAjgLosssAmt { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal SumStockQty { get; set; }
        /// <summary>
        /// 库存金额
        /// </summary>
        public decimal SumStockAmt { get; set; }
        /// <summary>
        /// 期末库存数量
        /// </summary>
        public decimal SumEndQty { get; set; }
        /// <summary>
        /// 期末库存金额
        /// </summary>
        public decimal SumEndStockAmt { get; set; }
        /// <summary>
        /// 差异数量
        /// </summary>
        public decimal SumEndDiffQty { get; set; }
        /// <summary>
        /// 差异金额
        /// </summary>
        public decimal SumEndDiffStockAmt { get; set; }
        #endregion
    }
}
