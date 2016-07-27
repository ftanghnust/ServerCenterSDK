/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/5/18 15:02:27
 * *******************************************************/
using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 完成 Action.Execute() 操作后，移除指定的缓存键
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class UnloadCachekeysAttribute : Attribute
    {
        /// <summary>
        /// 待移除的缓存键（匹配键）
        /// </summary>
        public string[] UnloadCacheKeys { get; private set; }

        /// <summary>
        /// 移除指定匹配模式的缓存键
        /// </summary>
        /// <param name="unloadPrefixCacheKeys">待移除的缓存键（注意此键会采取正则的方式进行匹配，如果愿意，完全可以使用正则表达式）</param>
        public UnloadCachekeysAttribute(params string[] unloadPrefixCacheKeys)
        {
            this.UnloadCacheKeys = unloadPrefixCacheKeys ?? new List<string>().ToArray();
        }
    }
}
