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
    public interface IWProductsBaseDAO : IBaseDAO
    {
        /// <summary>
        /// 获取网仓商品信息列表（比较全）
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="pdList"></param>
        /// <returns></returns>
        IList<WProductsBaseQueryModel> GetWProductsBaseList(int wid, IList<int> pdList);

    }
}
