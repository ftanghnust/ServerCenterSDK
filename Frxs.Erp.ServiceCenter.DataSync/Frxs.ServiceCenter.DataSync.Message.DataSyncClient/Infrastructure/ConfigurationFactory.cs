/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/23/2016 9:50:09 AM
 * *******************************************************/
using System.Configuration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 配置读取
    /// </summary>
    public class ConfigurationFactory
    {
        /// <summary>
        /// 获取默认的配置信息
        /// </summary>
        /// <param name="sectionName">WEB.config配置节点名称</param>
        /// <returns></returns>
        public static Configuration GetConfiguration(string sectionName = "")
        {
            var sectionConfig = ConfigurationManager.GetSection(string.IsNullOrWhiteSpace(sectionName) ? "dataSyncClient" : sectionName);
            if (!(sectionConfig is IConfigurationSectionHandler))
            {
                return new Configuration()
                {
                    MaxRetries = 10,
                    MessageServerUrl = "",
                    Number = 200,
                    ApiRoutes = new Configuration.ApiRoute[] { },
                    DataSyncType = "0",
                    WID = 0
                };
            }
            return (Configuration)sectionConfig;
        }
    }
}
