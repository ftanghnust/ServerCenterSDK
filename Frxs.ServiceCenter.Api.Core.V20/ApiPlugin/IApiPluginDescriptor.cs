/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/11 11:45:05
 * *******************************************************/
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 用于描述API扩展工具，方便框架搜索并且显示已经加载的扩展工具
    /// </summary>
    public interface IApiPluginDescriptor
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// 如果含有首页界面，首页访问地址是多少
        /// </summary>
        string IndexUrl { get; }

        /// <summary>
        /// 版本
        /// </summary>
        string Version { get; }

        /// <summary>
        /// LOGO，URL地址
        /// </summary>
        string Logo { get; }

        /// <summary>
        /// 作者
        /// </summary>
        string Author { get; }

        /// <summary>
        /// 插件描述
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 获取依赖项
        /// </summary>
        IEnumerable<string> ReferencedAssemblies { get; }
    }
}
