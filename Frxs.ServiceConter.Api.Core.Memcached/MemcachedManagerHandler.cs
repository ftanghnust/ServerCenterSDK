/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/20 11:02:30
 * *******************************************************/
using System;
using System.Xml;

namespace Frxs.ServiceCenter.Api.Core.Memcached
{
    /// <summary>
    /// <![CDATA[
    /// 缓存web.config节点配置类;无需手工配置，API系统框架会自动将此配置文件赋值给对应的换成类；XML配置文件格式如下：系统框架IOC容器会自动注册此配置
    /// <configuration>
    /// <configSections>
    ///  <section name="memcachedManagerConfig" type="Frxs.ServiceCenter.Api.Core.Memcached.MemcachedManagerConfig,Frxs.ServiceCenter.Api.Core.Memcached"/>
    /// </configSections>
    /// <memcachedManagerConfig servers="127.0.0.1:11211,192.168.0.2:11211"/>
    /// <configuration>
    /// ]]>
    /// </summary>
    [Serializable, ConfigurationSectionName("memcachedManagerConfig")]
    public class MemcachedManagerConfig : ConfigurationSectionHandlerBase, IMemcachedManagerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public override object Create(object parent, object configContext, XmlNode section)
        {
            var config = new MemcachedManagerConfig
            {
                Servers = null
            };

            if (section.IsNull())
            {
                return config;
            }

            string serversAttrValue;
            if (this.GetNodeAttributes(section).TryGetValue("servers", out serversAttrValue))
            {
                config.Servers = serversAttrValue.Split(new char[] { ',' });
            }

            return config;
        }

        /// <summary>
        /// 服务器地址列表，多服务器使用,分开
        /// </summary>
        public string[] Servers
        {
            get;
            private set;
        }
    }
}
