/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/27 14:13:02
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 资源查找过滤器
    /// </summary>
    public interface IResourceFinderManager
    {
        /// <summary>
        /// 系统框架注册的所有资源查找器
        /// </summary>
        IEnumerable<IResourceFinder> ResourceFinders { get; }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceName">资源名称（部分路径或者全部路径，如：sys.png 或者 Frxs.ServiceCenter.Api.Core.Resource.sys.png）</param>
        /// <returns></returns>
        string GetResource(string resourceName);
    }
}
