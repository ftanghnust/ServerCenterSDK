/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/21 13:21:02
 * *******************************************************/
using System.Collections.Generic;
using System.Xml;
using System.Configuration;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// SDK配置类
    /// </summary>
    public class SdkConfiguration : IConfigurationSectionHandler
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string ServerUrl { get; set; }

        /// <summary>
        /// 客户KEY
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 客户端加密密钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 获取节点属性集合，注意键全部已经转换成小写形式，这样便于比对
        /// </summary>
        /// <param name="node">当前node节点</param>
        /// <returns></returns>
        protected Dictionary<string, string> GetNodeAttributes(XmlNode node)
        {
            Dictionary<string, string> arrs = new Dictionary<string, string>();
            if (null == node)
            {
                return arrs;
            }
            int arrtCount = node.Attributes.Count;
            for (int i = 0; i < arrtCount; i++)
            {
                var arr = node.Attributes[i];
                arrs.Add(arr.Name.ToLower(), arr.Value);
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
            if (nodeAttributes.ContainsKey(attributeName.ToLower()))
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
            var config = new SdkConfiguration()
            {
                ServerUrl = string.Empty,
                AppKey = string.Empty,
                AppSecret = string.Empty
            };

            //如果没有配置节点，直接返回一个默认对象
            if (null == section)
            {
                return config;
            }

            //获取节点所有的属性
            var nodeAttributes = this.GetNodeAttributes(section);

            //接口服务器地址
            var serverUrl = string.Empty;
            if (nodeAttributes.TryGetValue("serverurl", out serverUrl))
            {
                config.ServerUrl = serverUrl;
            }

            //客户端KEY
            var appKey = string.Empty;
            if (nodeAttributes.TryGetValue("appkey", out appKey))
            {
                config.AppKey = appKey;
            }

            //客户端加密密钥
            var appSecret = string.Empty;
            if (nodeAttributes.TryGetValue("appsecret", out appSecret))
            {
                config.AppSecret = appSecret;
            }

            return config;
        }
    }
}
