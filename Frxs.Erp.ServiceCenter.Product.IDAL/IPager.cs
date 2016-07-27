using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// 分页接口
    /// </summary>
    public interface IPager<T>
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 页码Size
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// 获取当前查询的对象列表
        /// </summary>
        /// <returns></returns>
        IList<T> GetList();
    }
}
