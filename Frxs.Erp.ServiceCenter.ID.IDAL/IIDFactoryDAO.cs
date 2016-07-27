using Frxs.Erp.ServiceCenter.ID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.ID.IDAL
{
    public interface IIDFactoryDAO
    {
        /// <summary>
        /// 获取一个外部显示单据号
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>数据库影响行数</returns>
        string GetID(IDTypes idType, int wid);
    }
}
