using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// 已加入的商品查询 接口定义
    /// </summary>
    public interface IWProductsAddedListDAO : IBaseDAO, IPager<WProductsAddedListModel>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        WProductsAddedListParams SearchParams { get; set; }
    }
}
