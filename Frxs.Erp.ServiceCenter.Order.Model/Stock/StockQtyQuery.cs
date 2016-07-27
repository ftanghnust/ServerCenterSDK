using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Stock
{
    /// <summary>
    /// 查询库存条件
    /// </summary>
    public class StockQtyQuery
    {
        /// <summary>
        /// 商品ID列表
        /// </summary>
        public List<int> PDIDList { get; set; }

       /// <summary>
       /// 仓库ID
       /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 仓库子机构ID
        /// </summary>
        public int SubWID { get; set; }
    }

    /// <summary>
    /// 查询库存条件
    /// </summary>
    public class StockNQtyQuery
    {
        /// <summary>
        /// 商品ID列表
        /// </summary>
        public List<int> PDIDList { get; set; }

        public List<string> SKUList { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public List<int> WIDList { get; set; }
    }
}
