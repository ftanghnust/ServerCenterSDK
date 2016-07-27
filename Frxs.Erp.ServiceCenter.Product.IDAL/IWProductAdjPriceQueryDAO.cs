using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// 商品查询
    /// </summary>
    public interface IWProductAdjPriceQueryDAO : IBaseDAO, IPager<WProductAdjPrice>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        WProductAdjPriceQuerySearchParams SearchParams { get; set; }

    }
}
