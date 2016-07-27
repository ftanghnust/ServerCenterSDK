/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 17:05:48
 * *******************************************************/
using System.Xml;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// <![CDATA[
    /// 本API访问记录器web.config节点配置对象；此配置节点会被IOC容器自动注册;
    /// <configuration>
    /// <configSections>
    ///  <section name="apiAccessRecorderConfig" type="Frxs.ServiceCenter.Api.Core.AccessRecorder.DataBaseAccessRecorderConfig,Frxs.ServiceCenter.Api.Core.AccessRecorder"/>
    /// </configSections>
    ///  <apiAccessRecorderConfig connectionStringName="connstring_sql"/>
    /// <configuration>
    /// ]]>
    /// </summary>
    [ConfigurationSectionName("apiAccessRecorderConfig")]
    public class DataBaseAccessRecorderConfig : ConfigurationSectionHandlerBase, IDataBaseAccessRecorderConfig
    {
        /// <summary>
        /// 创建配置对象信息
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public override object Create(object parent, object configContext, XmlNode section)
        {
            var config = new DataBaseAccessRecorderConfig
            {
                ConnectionStringName = string.Empty,
                EnableAccessRecorder = true
            };

            if (section.IsNull())
            {
                return config;
            }

            string serversAttrValue;
            if (this.GetNodeAttributes(section).TryGetValue("connectionstringname", out serversAttrValue))
            {
                config.ConnectionStringName = serversAttrValue;
            }

            return config;
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionStringName
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否记录日志;默认true
        /// </summary>
        public bool EnableAccessRecorder
        {
            get;
            private set;
        }
    }
}
