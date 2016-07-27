/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/23 10:36:33
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 用户指定ConfigurationSection节点配置名称映射
    /// 用于继承ConfigurationSectionHandlerBase了类的实现具体配置实现
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationSectionNameAttribute : Attribute
    {
        /// <summary>
        /// Web.config节点configuration.configSections.section名称
        /// </summary>
        public string SectionName { get; private set; }

        /// <summary>
        /// 是否自动注册到IOC容器(默认为true)
        /// </summary>
        public bool IsAutoRegister { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectionName">Web.config节点configuration.configSections.section名称</param>
        public ConfigurationSectionNameAttribute(string sectionName)
        {
            this.SectionName = sectionName;
            this.IsAutoRegister = true;
        }
    }
}
