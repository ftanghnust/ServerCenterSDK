/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/11 12:30:46
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core.Logging
{
    /// <summary>
    /// 接口日志记录器扩展
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
            get { return "接口日志记录组件(基于Log4Net实现)"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string IndexUrl
        {
            get
            {
                return "https://www.nuget.org/packages/log4net/";
            }
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

