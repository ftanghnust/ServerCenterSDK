/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/11 12:30:46
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server
{
    /// <summary>
    /// 插件描述
    /// </summary>
    [Serializable]
    public class ApiPluginDescriptor : ApiPluginDescriptorBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceFinderManager"></param>
        public ApiPluginDescriptor(IResourceFinderManager resourceFinderManager)
            : base(resourceFinderManager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override string DisplayName
        {
            get { return "消息中间件"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Author
        {
            get { return "zhangliang@frxs.com"; }
        }
    }
}
