/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/11 12:30:46
 * *******************************************************/
using System;
using System.Linq;
using System.Reflection;

namespace Frxs.ServiceCenter.Api.Core.ApiTestTool
{
    /// <summary>
    /// 调试工具扩展
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
            get { return "接口调试工具"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string IndexUrl
        {
            get { return "/apitool"; }
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
