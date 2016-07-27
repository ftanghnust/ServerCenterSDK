using System;
/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/20 11:06:38
 * *******************************************************/
using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 所有自定义web.config文件section节点配置类，系统框架会在启动的时候会自动注册类实例到IOC容器里(外部系统无需进行注册)
    /// 外部定义的时候，需要另外再定义个配置接口，让具体的节点处理类来实现配置接口，这样外部类可以直接使用配置接口即可，系统框架
    /// 会自动对配置进行初始化传入
    /// </summary>
    public abstract class ConfigurationSectionHandlerBase : IConfigurationSectionHandler
    {
        /// <summary>
        /// 获取节点属性集合，注意键不会区分大小写
        /// </summary>
        /// <param name="node">当前node节点</param>
        /// <returns>返回的字典key键不区分大小写</returns>
        protected IDictionary<string, string> GetNodeAttributes(XmlNode node)
        {
            var nodeAttributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (node.IsNull())
            {
                return nodeAttributes;
            }

            int arrtCount = node.Attributes.Count;
            for (int i = 0; i < arrtCount; i++)
            {
                var arr = node.Attributes[i];
                nodeAttributes.Add(arr.Name, arr.Value);
            }

            return nodeAttributes;
        }

        /// <summary>
        /// 根据字典获取指定值
        /// </summary>
        /// <param name="nodeAttributes">数据字典</param>
        /// <param name="attributeName">key</param>
        /// <returns></returns>
        protected string GetNodeAttribute(IDictionary<string, string> nodeAttributes, string attributeName)
        {
            return nodeAttributes.ContainsKey(attributeName) ? nodeAttributes[attributeName] : null;
        }

        /// <summary>
        /// 根据节点XML文件，创建出配置低、对象
        /// </summary>
        /// <param name="parent">当前节点对应的父节点对象</param>
        /// <param name="configContext">配置文件上下文</param>
        /// <param name="section">配置文件对应的节点XML文件</param>
        /// <returns>返回当前处理对象</returns>
        public abstract object Create(object parent, object configContext, XmlNode section);
    }
}
