using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
    /// <summary>
    /// 库存查询结果
    /// </summary>
    public class StockSreachQtyModel
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public decimal StockQty { get; set; }
        /// <summary>
        /// 在途数
        /// </summary>
        public decimal PreQty { get; set; }
        /// <summary>
        /// 可用数
        /// </summary>
        public decimal EnQty
        {
            get
            {
                return StockQty - PreQty;
            }
        }
    }

    /// <summary>
    /// 库存查询结果
    /// </summary>
    public class StockOQtyModel
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 仓库子机构
        /// </summary>
        public int SubWID { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public decimal StockQty { get; set; }
       
    }
}
