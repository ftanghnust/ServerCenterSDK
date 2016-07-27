using ServiceStack.Redis;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/26 11:59:08
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Frxs.ServiceCenter.Api.Core.Redis
{
    /// <summary>
    /// Redis缓存服务器客户端实现
    /// 引用文件地址：
    /// packages\ServiceStack.Redis.4.0.46\lib\net40\ServiceStack.Redis.dll
    /// packages\ServiceStack.Interfaces.4.0.46\lib\portable-wp80+sl5+net40+win8+monotouch+monoandroid+xamarin.ios10\ServiceStack.Interfaces.dll
    /// packages\ServiceStack.Text.4.0.46\lib\net40\ServiceStack.Text.dll
    /// packages\ServiceStack.Common.4.0.46\lib\net40\ServiceStack.Common.dll
    /// </summary>
    public class RedisCacheManager : ICacheManager
    {
        /// <summary>
        /// 
        /// </summary>
        private static PooledRedisClientManager _pooledRedisClientManager = null;
        private static readonly object Locker = new object();

        /// <summary>
        /// Redis缓存服务器客户端实现
        /// </summary>
        /// <param name="config">缓存配置文件</param>
        public RedisCacheManager(IRedisCacheManagerConfig config)
        {
            //为设置配置文件，直接抛出异常
            if (null == config)
            {
                throw new Exception("config参数未配置");
            }

            //客户端线程未初始化
            if (_pooledRedisClientManager.IsNull())
            {
                lock (Locker)
                {
                    _pooledRedisClientManager = new PooledRedisClientManager(config.ReadWriteHosts, config.ReadOnlyHosts,
                        new RedisClientManagerConfig
                        {
                            MaxWritePoolSize = config.MaxWritePoolSize,
                            MaxReadPoolSize = config.MaxReadPoolSize,
                            AutoStart = true
                        });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            using (var redisClient = _pooledRedisClientManager.GetClient())
            {
                foreach (var key in redisClient.GetAllKeys())
                {
                    redisClient.Remove(key);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            using (var redisClient = _pooledRedisClientManager.GetClient())
            {
                return redisClient.Get<T>(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsSet(string key)
        {
            using (var redisClient = _pooledRedisClientManager.GetClient())
            {
                return redisClient.ContainsKey(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            using (var redisClient = _pooledRedisClientManager.GetClient())
            {
                redisClient.Remove(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();
            using (var redisClient = _pooledRedisClientManager.GetClient())
            {
                keysToRemove.AddRange(redisClient.GetAllKeys().Where(key => regex.IsMatch(key)));

                foreach (string key in keysToRemove)
                {
                    this.Remove(key);
                }
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

            using (var redisClient = _pooledRedisClientManager.GetClient())
            {
                if (data is string)
                {
                    redisClient.Set<string>(key, data.ToString(), DateTime.Now.AddMinutes(cacheTime));
                }
                else
                {
                    redisClient.Set(key, data, DateTime.Now.AddMinutes(cacheTime));
                }
            }
        }
    }
}
