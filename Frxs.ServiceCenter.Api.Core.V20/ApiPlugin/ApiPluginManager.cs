/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/11 11:48:56
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// API接口扩展插件管理类
    /// </summary>
    public class ApiPluginManager
    {
        /// <summary>
        /// 缓存所有扩展项目信息；
        /// </summary>
        private static readonly Dictionary<string, IApiPluginDescriptor> CachedApiPlugins = new Dictionary<string, IApiPluginDescriptor>();
        private static bool _initializationed = false;
        private static readonly object Locker = new object();

        /// <summary>
        /// 获取插件
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IApiPluginDescriptor> GetApiPlugins()
        {
            //还未初始化
            if (_initializationed)
            {
                return CachedApiPlugins.Select(o => o.Value);
            }

            lock (Locker)
            {
                if (!_initializationed)
                {
                    //已经初始化了标志
                    _initializationed = true;

                    var typeFinder = ServicesContainer.Current.Resolver<ITypeFinder>();

                    //搜索所有扩展插件，返回扩展插件集合
                    typeFinder.FindClassesOfType<IApiPluginDescriptor>().ToList().ForEach(type =>
                    {
                        var apiPluginDescriptor = ServicesContainer.Current.ResolverUnregistered(type);
                        CachedApiPlugins.Add(type.FullName, (IApiPluginDescriptor)apiPluginDescriptor);
                    });
                }
            }

            //直接返回缓存
            return CachedApiPlugins.Select(o => o.Value);
        }
    }
}
