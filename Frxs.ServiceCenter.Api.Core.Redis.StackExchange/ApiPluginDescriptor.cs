﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/11 12:30:46
 * *******************************************************/
using System;
using System.Linq;
using System.Reflection;

namespace Frxs.ServiceCenter.Api.Core.Redis.StackExchange
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
            get { return "接口缓存组件(Redis基于StackExchange.Redis实现)"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string IndexUrl
        {
            get
            {
                return "https://www.nuget.org/packages/StackExchange.Redis/1.1.604-alpha";
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