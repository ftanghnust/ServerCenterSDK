/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/25 9:40:40
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Api.Core.Memcached
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMemcachedManagerConfig
    {
        /// <summary>
        /// 服务器地址列表，多服务器使用,分开
        /// </summary>
        string[] Servers
        {
            get;
        }
    }
}
