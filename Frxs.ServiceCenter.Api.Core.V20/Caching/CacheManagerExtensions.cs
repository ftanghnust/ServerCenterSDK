/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 2015/11/13 16:59:56
 * *******************************************************/
using System;
using System.Linq;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// ª∫¥Ê¿©’π¿‡
    /// </summary>
    public static class CacheManagerExtensions
    {
        /// <summary>
        /// Variable (lock) to support thread-safe
        /// </summary>
        private static readonly object SyncObject = new object();

        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it;
        /// the default cachetime is 30*24*60 minutes 30days
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <returns>Cached item</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 30 * 24 * 60, acquire);
        }

        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="key">Cache key</param>
        /// <param name="cacheTime">Cache time in minutes (0 - do not cache)</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <returns>Cached item</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            lock (SyncObject)
            {
                var result = acquire();
                if (cacheTime > 0)
                {
                    cacheManager.Set(key, result, cacheTime);
                }
                return result;
            }
        }

        /// <summary>
        /// Get a cached item list. If it's not in the cache yet, then load and cache it;
        /// the default cachetime is 30*24*60 minutes
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="key">Cache Key</param>
        /// <param name="acquire">Function to load item list if it's not in the cache yet</param>
        /// <returns></returns>
        public static IEnumerable<T> GetList<T>(this ICacheManager cacheManager, string key, Func<IEnumerable<T>> acquire)
        {
            return GetList<T>(cacheManager, key, 30 * 24 * 60, acquire);
        }

        /// <summary>
        /// Get a cached item list. If it's not in the cache yet, then load and cache it;
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="key">Cache Key</param>
        /// <param name="cacheTime">Cache time in minutes (0 - do not cache)</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <returns></returns>
        public static IEnumerable<T> GetList<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<IEnumerable<T>> acquire)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<IEnumerable<T>>(key);
            }

            IEnumerable<T> result = acquire();

            if (!result.IsNull() && result.Any())
            {
                lock (SyncObject)
                {
                    cacheManager.Set(key, result, cacheTime);
                }
            }

            return result;
        }

        /// <summary>
        /// Set cache data£ªthe default cachetime is 30*24*60 minutes
        /// </summary>
        /// <param name="cacheManager"></param>
        /// <param name="key">Cache Key</param>
        /// <param name="data">the data wait to Cached</param>
        public static void Set(this ICacheManager cacheManager, string key, object data)
        {
            lock (SyncObject)
            {
                cacheManager.Set(key, data, 30 * 24 * 60);
            }
        }
    }
}
