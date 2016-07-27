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
    public interface IWProductsWaitAddListDAO : IBaseDAO, IPager<WProductsWaitAddListModel>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        WProductsWaitAddListParams SearchParams { get; set; }
    }
}
