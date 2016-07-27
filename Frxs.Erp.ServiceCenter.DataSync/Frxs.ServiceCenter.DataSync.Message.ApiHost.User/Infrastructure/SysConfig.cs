/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 17:05:48
 * *******************************************************/
using System.Xml;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.User
{
    /// <summary>
    /// <![CDATA[
    /// web.config节点配置对象；此配置节点会被IOC容器自动注册;
    /// <configuration>
    /// <configSections>
    ///  <section name="SysConfig" type="Frxs.ServiceCenter.Api.Host.Data.DataBaseAccessConfig,Frxs.ServiceCenter.Api.Host"/>
    /// </configSections>
    ///  <SysConfig connectionStringName="connstring_sql"/>
    /// <configuration>
    /// ]]>
    /// </summary>
    [ConfigurationSectionName("SysConfig")]
    public class SysConfig : ConfigurationSectionHandlerBase
    {
        /// <summary>
        /// 配置文件对应的实体类
        /// </summary>
        public SysConfig() { }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionStringName
        {
            get;
            private set;
        }

        /// <summary>
        /// 创建配置对象信息
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public override object Create(object parent, object configContext, XmlNode section)
        {
            //初始化一个默认的配置文件
            var config = new SysConfig() { ConnectionStringName = string.Empty };

            //web.config配置节点不存在
            if (section.IsNull())
            {
                return config;
            }

            //获取数据库连接
            config.ConnectionStringName = this.GetNodeAttributes(section).GetValue("connectionstringname", key => "");

            //返回数据库配置信息
            return config;
        }

    }
}
