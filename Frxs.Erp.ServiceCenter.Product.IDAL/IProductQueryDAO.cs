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
    public interface IProductQueryDAO : IBaseDAO, IPager<ProductQueryModel>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        ProductQuerySearchParams SearchParams { get; set; }

        /// <summary>
        /// 获取简单类型商品列表
        /// </summary>
        /// <returns></returns>
        IList<SimpleProduct> GetSimpleProductList();

    }
}
