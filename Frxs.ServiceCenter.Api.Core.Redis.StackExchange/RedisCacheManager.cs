/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/26 11:59:08
 * *******************************************************/
using System;
using System.Collections.Generic;
using StackExchange.Redis.Extensions.Core;
using System.Text.RegularExpressions;

namespace Frxs.ServiceCenter.Api.Core.Redis.StackExchange
{
    /// <summary>
    /// StackExchange实现
    /// </summary>
    public class RedisCacheManager : ICacheManager
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICacheClient _cacheClient;

        /// <summary>
        /// Redis缓存服务器客户端实现
        /// </summary>
        /// <param name="cacheClient"></param>
        public RedisCacheManager(ICacheClient cacheClient)
        {
            this._cacheClient = cacheClient;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this._cacheClient.FlushDb();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return this._cacheClient.Get<T>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsSet(string key)
        {
            return this._cacheClient.Exists(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            this._cacheClient.Remove(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        public void RemoveByPattern(string pattern)
        {
            var keys = this._cacheClient.SearchKeys("*{0}*".With(pattern));
            foreach (var key in keys)
            {
                this.Remove(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        public void Set(string key, object data, int cacheTime)
        {
            if (null == data)
            {
                return;
            }

            //如果存在就先删除，然后添加新缓存
            if (this.IsSet(key))
            {
                this.Remove(key);
            }

            //保存到缓存
            this._cacheClient.Add(key, data, DateTimeOffset.Now.AddMinutes(cacheTime));
        }
    }
}
