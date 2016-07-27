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
    public class WProductsWaitAddListParams
    {
        /// <summary>
        /// 对应的仓库ID
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 商品名称关键词
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// ERP条码
        /// </summary>
        public string SKU
        {
            get;
            set;
        }

        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode
        {
            get;
            set;
        }

        /// <summary>
        /// 分类1
        /// </summary>
        public int? CategoryId1
        {
            get;
            set;
        }

        /// <summary>
        /// 分类2
        /// </summary>
        public int? CategoryId2
        {
            get;
            set;
        }

        /// <summary>
        /// 分类3
        /// </summary>
        public int? CategoryId3
        {
            get;
            set;
        }
    }
}
