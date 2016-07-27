/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/27 14:15:25
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 资源查找器管理器
    /// </summary>
    public class DefaultResourceFinderManager : IResourceFinderManager
    {
        private readonly IEnumerable<IResourceFinder> _resourceFinders;
        private readonly ICacheManager _cacheManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resourceFinders">资源查找器</param>
        /// <param name="cacheManager">缓存器</param>
        public DefaultResourceFinderManager(IEnumerable<IResourceFinder> resourceFinders, ICacheManager cacheManager)
        {
            resourceFinders.CheckNullThrowArgumentNullException("resourceFinders");
            this._resourceFinders = resourceFinders.OrderByDescending(o => o.Order).ToArray();
            this._cacheManager = cacheManager;
        }

        /// <summary>
        /// 系统框架注册的所有资源查找器
        /// </summary>
        public IEnumerable<IResourceFinder> ResourceFinders
        {
            get { return this._resourceFinders; }
        }

        /// <summary>
        /// 获取所有资源查找器资源并集
        /// </summary>
        /// <param name="resourceFinders">资源查找器</param>
        /// <returns></returns>
        private static IEnumerable<KeyValuePair<string, string>> GetResources(IEnumerable<IResourceFinder> resourceFinders)
        {
            IEnumerable<KeyValuePair<string, string>> resourcesKeyValuePair = new Dictionary<string, string>();
            return resourceFinders.Aggregate(resourcesKeyValuePair,
                (current, item) => current.Union(item.GetResources()));
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceName">资源名称(可以是包含部分或者全部资源名称)</param>
        /// <returns>返回资源字符串，如果是图片，则返回base64字符串，如果不存在则返回null</returns>
        public string GetResource(string resourceName)
        {
            //获取资源(相当于二级缓存)
            return this._cacheManager.Get("{0}_SYS_{1}".With(this.GetType().FullName, MD5.Encrypt(resourceName).ToUpper()), () =>
            {
                var resource = GetResources(this._resourceFinders)
                    .FirstOrDefault(o => o.Key.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));

                if (!resource.IsNull() && !resource.Key.IsNullOrEmpty())
                {
                    return resource.Value;
                }

                return null;
            });
        }
    }
}
