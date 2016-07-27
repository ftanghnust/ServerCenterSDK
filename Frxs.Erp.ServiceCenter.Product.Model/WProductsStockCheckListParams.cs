using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 查询待盘点商品参数
    /// </summary>
    public class WProductsStockCheckListParams
    {
        /// <summary>
        /// 对应的仓库ID
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// erp编码 集合
        /// </summary>
        public IList<string> SKUs { get; set; }

    }
}
