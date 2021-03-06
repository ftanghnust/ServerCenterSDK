/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/4/28 13:28:38
 * *******************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace Frxs.ServiceCenter.Api.Core.Caching.Impl
{
    /// <summary>
    /// Represents a manager for caching during an HTTP request (short term caching)
    /// </summary>
    public partial class PerRequestCacheManager : ICacheManager
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly HttpContextBase _httpContext;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Context</param>
        public PerRequestCacheManager(HttpContextBase context)
        {
            this._httpContext = context;
        }

        /// <summary>
        /// Creates a new instance of the NopRequestCache class
        /// </summary>
        protected virtual IDictionary GetItems()
        {
            return !_httpContext.IsNull() ? _httpContext.Items : null;
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public virtual T Get<T>(string key)
        {
            var items = GetItems();
            if (items.IsNull())
            {
                return default(T);
            }
            return (T)items[key];
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            var items = GetItems();
            if (items.IsNull() || data.IsNull())
            {
                return;
            }
            if (items.Contains(key))
            {
                items[key] = data;
            }
            else
            {
                items.Add(key, data);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public virtual bool IsSet(string key)
        {
            var items = GetItems();
            if (items.IsNull())
            {
                return false;
            }
            return (!items[key].IsNull());
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public virtual void Remove(string key)
        {
            var items = GetItems();
            if (items.IsNull())
            {
                return;
            }
            items.Remove(key);
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public virtual void RemoveByPattern(string pattern)
        {
            var items = GetItems();
            if (items.IsNull())
            {
                return;
            }

            var enumerator = items.GetEnumerator();
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<string>();
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(enumerator.Key.ToString()))
                {
                    keysToRemove.Add(enumerator.Key.ToString());
                }
            }

            foreach (string key in keysToRemove)
            {
                items.Remove(key);
            }
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public virtual void Clear()
        {
            var items = GetItems();
            if (items.IsNull())
                return;

            var enumerator = items.GetEnumerator();
            var keysToRemove = new List<string>();
            while (enumerator.MoveNext())
            {
                keysToRemove.Add(enumerator.Key.ToString());
            }

            foreach (string key in keysToRemove)
            {
                items.Remove(key);
            }
        }
    }
}