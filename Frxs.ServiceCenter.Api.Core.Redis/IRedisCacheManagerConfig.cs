/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/25 9:43:33
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Api.Core.Redis
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRedisCacheManagerConfig
    {
        /// <summary>
        /// 读写服务器
        /// </summary>
        string[] ReadWriteHosts { get; }

        /// <summary>
        /// 只读服务器
        /// </summary>
        string[] ReadOnlyHosts { get; }

        /// <summary>
        /// 最大写缓冲池
        /// </summary>
        int MaxWritePoolSize { get; }

        /// <summary>
        /// 最大读缓冲池
        /// </summary>
        int MaxReadPoolSize { get; }
    }
}
