/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/26 12:32:16
 * *******************************************************/
using System.Xml;

namespace Frxs.ServiceCenter.Api.Core.Redis
{
    /// <summary>
    /// <![CDATA[
    /// 缓存web.config节点配置类;无需手工配置，API系统框架会自动将此配置文件赋值给对应的换成类，系统框架IOC容器会自动注册此配置；XML配置文件格式如下：
    /// <configuration>
    /// <configSections>
    ///   <section name="redisCacheManagerConfig" type="Frxs.ServiceCenter.Api.Core.Redis.RedisCacheManagerConfig,Frxs.ServiceCenter.Api.Core.Redis"/>
    /// </configSections>
    /// <redisCacheManagerConfig readWriteHosts="127.0.0.1:6379" readOnlyHosts="" MaxWritePoolSize="5" MaxReadPoolSize="5"/>
    /// <configuration>
    /// ]]>
    /// </summary>
    [ConfigurationSectionName("redisCacheManagerConfig")]
    public class RedisCacheManagerConfig : ConfigurationSectionHandlerBase, IRedisCacheManagerConfig
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
            var config = new RedisCacheManagerConfig()
            {
                ReadWriteHosts = new string[] { "127.0.0.1:6379" },
                ReadOnlyHosts = null,
                MaxReadPoolSize = 5,
                MaxWritePoolSize = 5
            };

            if (section.IsNull())
            {
                return config;
            }

            var arrs = this.GetNodeAttributes(section);

            var readWriteHostsAttrValue = string.Empty;
            if (arrs.TryGetValue("readwritehosts", out readWriteHostsAttrValue))
            {
                config.ReadWriteHosts = readWriteHostsAttrValue.Split(new char[] { ',' });
            }

            var readOnlyHostsAttrValue = string.Empty;
            if (arrs.TryGetValue("readonlyhosts", out readOnlyHostsAttrValue))
            {
                config.ReadOnlyHosts = readOnlyHostsAttrValue.Split(new char[] { ',' });
            }

            var maxWritePoolSizeAttrValue = string.Empty;
            if (arrs.TryGetValue("maxwritepoolsize", out maxWritePoolSizeAttrValue))
            {
                int intMaxWritePoolSizeAttrValue;
                if (int.TryParse(maxWritePoolSizeAttrValue, out intMaxWritePoolSizeAttrValue))
                {
                    config.MaxWritePoolSize = intMaxWritePoolSizeAttrValue;
                }
            }

            var maxReadPoolSizeAttrValue = string.Empty;
            if (arrs.TryGetValue("maxreadpoolsize", out maxReadPoolSizeAttrValue))
            {
                int intMaxReadPoolSizeAttrValue;
                if (int.TryParse(maxReadPoolSizeAttrValue, out intMaxReadPoolSizeAttrValue))
                {
                    config.MaxReadPoolSize = intMaxReadPoolSizeAttrValue;
                }
            }

            return config;
        }

        /// <summary>
        /// 读写服务器
        /// </summary>
        public string[] ReadWriteHosts { get; private set; }

        /// <summary>
        /// 只读服务器
        /// </summary>
        public string[] ReadOnlyHosts { get; private set; }

        /// <summary>
        /// 最大写缓冲池
        /// </summary>
        public int MaxWritePoolSize { get; private set; }

        /// <summary>
        /// 最大读缓冲池
        /// </summary>
        public int MaxReadPoolSize { get; private set; }
    }
}
