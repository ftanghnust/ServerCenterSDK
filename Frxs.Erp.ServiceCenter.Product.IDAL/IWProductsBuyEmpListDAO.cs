using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    public interface IWProductsBuyEmpListDAO : IBaseDAO, IPager<WProductsBuyEmpListModel>
    {
        /// <summary>
        /// 查询参数
        /// </summary>
        WProductsBuyEmpListParams SearchParams { get; set; }
    }
}
