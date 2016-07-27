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
    public class WProductsSaleQuerySearchParams
    {
        /// <summary>
        /// 对应的仓库ID编号；此参数必须传入
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// SKU信息
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 是否进行模糊搜索
        /// </summary>
        public bool SKULikeSearch { get; set; }

        /// <summary>
        /// 商品关键词
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 国际条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 商品ID，可以是部分ID，但是必须以开头(必须全部是数字)
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 是否可退
        /// </summary>
        public bool? SaleBackFlag { get; set; }

        /// <summary>
        /// 商品ID  
        /// </summary>
        public IList<int> ProductIds { get; set; }

        /// <summary>
        /// 是否查询所有状态-默认查询有限状态 也就是 WState=1
        /// </summary>
        public bool? AllWState { get; set; }
        
    }
}
