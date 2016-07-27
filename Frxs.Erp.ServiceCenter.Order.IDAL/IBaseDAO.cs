
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// IDAL基类
    /// </summary>
    public interface IBaseDAO
    {
        /// <summary>
        /// 获取当前数据库连接对象
        /// </summary>
        /// <returns></returns>
        IDbConnection GetConnection();
    }
}
