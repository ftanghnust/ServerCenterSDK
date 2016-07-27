/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/11 12:30:46
 * *******************************************************/
using System;
using System.Linq;
using System.Reflection;

namespace Frxs.ServiceCenter.Api.Core.TaskManagement
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
            get { return "框架作业任务管理器"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string IndexUrl
        {
            get { return "/TaskManager"; }
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
