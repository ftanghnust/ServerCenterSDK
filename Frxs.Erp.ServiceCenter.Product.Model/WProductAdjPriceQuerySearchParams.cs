using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 查询商品参数
    /// </summary>
    public class WProductAdjPriceQuerySearchParams
    {
        /// <summary>
        /// 仓库编号（必填）
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 调价单类型（必填）,调整类型( 0:采购(进货)价; 1:配送(批发)价; 3:费率及积分)
        /// </summary>
        public int AdjType { get; set; }

        /// <summary>
        /// 调整单单号
        /// </summary>
        public int? AdjID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品（以前叫ERP编码）
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 商品条形码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 状态(0:未提交;1:已确认;2:已过帐;)
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 创建时间检索区间开始
        /// </summary>
        public DateTime? CreateTime1 { get; set; }

        /// <summary>
        /// 创建时间检索区间结束
        /// </summary>
        public DateTime? CreateTime2 { get; set; }

        /// <summary>
        /// 确认时间检索区间开始
        /// </summary>
        public DateTime? ConfTime1 { get; set; }

        /// <summary>
        /// 确认时间检索区间结束
        /// </summary>
        public DateTime? ConfTime2 { get; set; }

        /// <summary>
        /// 生效时间检索区间开始
        /// </summary>
        public DateTime? PostingTime1 { get; set; }
        /// <summary>
        /// 生效时间检索区间结束
        /// </summary>
        public DateTime? PostingTime2 { get; set; }

        /// <summary>
        /// 生效时间检索区间开始
        /// </summary>
        public DateTime? BeginTime1 { get; set; }
        /// <summary>
        /// 生效时间检索区间结束
        /// </summary>
        public DateTime? BeginTime2 { get; set; }
    }
}
