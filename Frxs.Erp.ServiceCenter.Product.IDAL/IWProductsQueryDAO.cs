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
    public interface IWProductsQueryDAO : IBaseDAO, IPager<WProductsQueryModel>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        WProductsQuerySearchParams SearchParams { get; set; }

    }
}
