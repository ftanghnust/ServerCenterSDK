/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/23 13:21:02
 * *******************************************************/
using System.Collections.Generic;
using System.Xml;
using System;
using System.Linq;
using System.Configuration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class Configuration : IConfigurationSectionHandler
    {
        /// <summary>
        /// 接口路由数据对象
        /// </summary>
        public class ApiRoute
        {
            /// <summary>
            /// 接口前缀
            /// </summary>
            public string Prefix { get; set; }

            /// <summary>
            /// 服务器地址
            /// </summary>
            public string ServerUrl { get; set; }
        }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 消息服务器地址
        /// </summary>
        public string MessageServerUrl { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        public int MaxRetries { get; set; }

        /// <summary>
        /// 每次读取数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 同步方式; 0:单线程  1:多线程
        /// </summary>
        public string DataSyncType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ApiRoute[] ApiRoutes { get; set; }

        /// <summary>
        /// 获取节点属性集合，注意键全部已经转换成小写形式，这样便于比对
        /// </summary>
        /// <param name="node">当前node节点</param>
        /// <returns></returns>
        protected Dictionary<string, string> GetNodeAttributes(XmlNode node)
        {
            Dictionary<string, string> arrs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (null == node)
            {
                return arrs;
            }
            int arrtCount = node.Attributes.Count;
            for (int i = 0; i < arrtCount; i++)
            {
                var arr = node.Attributes[i];
                arrs.Add(arr.Name, arr.Value);
            }
            return arrs;
        }

        /// <summary>
        /// 根据字典获取指定值
        /// </summary>
        /// <param name="nodeAttributes">数据字典</param>
        /// <param name="attributeName">key</param>
        /// <returns></returns>
        protected string GetNodeAttribute(Dictionary<string, string> nodeAttributes, string attributeName)
        {
            if (nodeAttributes.ContainsKey(attributeName))
            {
                return nodeAttributes[attributeName.ToLower()];
            }
            return null;
        }

        /// <summary>
        /// 根据节点XML文件，创建出配置低、对象
        /// </summary>
        /// <param name="parent">当前节点对应的父节点对象</param>
        /// <param name="configContext">配置文件上下文</param>
        /// <param name="section">配置文件对应的节点XML文件</param>
        /// <returns></returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new Configuration()
            {
                WID = 0,
                MessageServerUrl = "",
                MaxRetries = 10,
                Number = 200,
                ApiRoutes = new ApiRoute[] { },
                DataSyncType = "0"
            };

            //如果没有配置节点，直接返回一个默认对象
            if (null == section)
            {
                return config;
            }

            //获取节点所有的属性
            var nodeAttributes = this.GetNodeAttributes(section);

            //仓库编号
            var wid = string.Empty;
            if (nodeAttributes.TryGetValue("WID", out wid))
            {
                config.WID = wid.As<int>(config.WID);
            }

            //接口服务器地址
            var serverUrl = string.Empty;
            if (nodeAttributes.TryGetValue("MessageServerUrl", out serverUrl))
            {
                config.MessageServerUrl = serverUrl;
            }

            //重试次数
            var maxRetries = string.Empty;
            if (nodeAttributes.TryGetValue("MaxRetries", out maxRetries))
            {
                config.MaxRetries = maxRetries.As<int>(config.MaxRetries);
            }

            //每次读取数量
            var number = string.Empty;
            if (nodeAttributes.TryGetValue("Number", out number))
            {
                config.Number = number.As<int>(config.Number);
            }

            //单线程还是多线程同步
            var dataSyncType = string.Empty;
            if (nodeAttributes.TryGetValue("DataSyncType", out dataSyncType))
            {
                config.DataSyncType = dataSyncType;
            }

            //API接口路由配置
            Dictionary<string, ApiRoute> apiRoutes = new Dictionary<string, ApiRoute>();
            var routes = section.SelectNodes("apiRoutes/route");
            foreach (XmlNode route in routes)
            {
                var routeNodeAttributes = this.GetNodeAttributes(route);
                string prefix = string.Empty;
                string svrUrl = string.Empty;
                routeNodeAttributes.TryGetValue("prefix", out prefix);
                routeNodeAttributes.TryGetValue("serverUrl", out svrUrl);
                apiRoutes.Add(prefix, new ApiRoute() { Prefix = prefix, ServerUrl = svrUrl });
            }
            config.ApiRoutes = apiRoutes.Values.Select(o => o).ToArray();

            return config;
        }
    }
}
