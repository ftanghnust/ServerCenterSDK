/*********************************************************
 * FRXS zhangliang@frxs.com 10/26/2015 10:05:19 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 版本特性用于指定版本，便于客户端直接指定版本，框架自动使用指定版本接口
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        /// <summary>
        /// 接口版本号
        /// </summary>
        public Version Version { get; private set; }

        /// <summary>
        /// 指示接口的版本信息
        /// </summary>
        /// <param name="major">主版本</param>
        /// <param name="minor">次版本</param>
        public VersionAttribute(int major, int minor)
        {
            this.Version = new Version(major, minor);
        }
    }
}